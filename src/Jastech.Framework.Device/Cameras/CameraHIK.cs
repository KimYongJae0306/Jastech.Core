using Jastech.Framework.Imaging;
using Jastech.Framework.Util.Helper;
using MvCamCtrl.NET;
using Newtonsoft.Json;
using System;
using System.CodeDom;
using System.ComponentModel.Composition.Primitives;
using System.Runtime.InteropServices;
using System.Threading;
using static MvCamCtrl.NET.MyCamera;

namespace Jastech.Framework.Device.Cameras
{
    public partial class CameraHIK : Camera, ICameraTriggerable
    {
        #region 필드
        private object _lock { get; set; } = new object();

        private MyCamera _camera { get; set; } = new MyCamera();

        private bool _isGrabbing { get; set; } = false;
        #endregion

        #region 속성
        [JsonProperty]
        public string SerialNo { get; set; }

        [JsonIgnore]
        public byte[] LastImageData { get; set; } = null;

        private UInt32 PayLoadSize { get; set; }

        private bool IsReleaseBuf { get; set; } = true;

        private IntPtr BufForDriver { get; set; }

        private MyCamera.MV_CC_DEVICE_INFO SelectedDeviceInfo = new MyCamera.MV_CC_DEVICE_INFO();

        private MyCamera.MVCC_INTVALUE IntValueParam = new MyCamera.MVCC_INTVALUE();

        private MyCamera.cbOutputExdelegate ImageCallback;

        private MyCamera.cbExceptiondelegate ExceptionCallback;
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        public CameraHIK(string name, int imageWidth, int imageHeight, ColorFormat colorFormat, SensorType sensorType)
         : base(name, imageWidth, imageHeight, colorFormat, sensorType)
        {

        }
        #endregion

        #region 메서드
        public override bool Initialize()
        {
            Logger.Write(LogType.Device, "Initialize HIK Camera");
            base.Initialize();

            if (FindDevice() == false)
            {
                Logger.Error(ErrorType.Camera, string.Format("HIK Camera Not Found. Name : {0}", Name));
                return false;
            }

            if (OpenDevice() == false)
            {
                Logger.Error(ErrorType.Camera, string.Format("HIK Camera Open Device Fail. Name : {0}", Name));
                return false;
            }

            if (SetGigEGevSCPSPacketSize() == false)
            {
                Logger.Error(ErrorType.Camera, string.Format("HIK Camera SetGigEGevSCPSPacketSize. Name : {0}", Name));
                return false;
            }

            SetAcquisitionMode(MV_CAM_ACQUISITION_MODE.MV_ACQ_MODE_CONTINUOUS);

            ActiveTriggerCommand();

            SetReverseX(EnableReverseX);
            SetExposureTime(Exposure);

            PayLoadSize = GetPayLoadSize();

            //Register Callback
            ImageCallback = new MyCamera.cbOutputExdelegate(OnImageGrabbed);
            int result = _camera.MV_CC_RegisterImageCallBackEx_NET(ImageCallback, IntPtr.Zero);
            if (MV_OK != result)
            {
                var errorMessage = GetErrorMessage($"HIK Camera Register image callback failed. Name : {Name}", result);
                Logger.Error(ErrorType.Camera, errorMessage);
                return false;
            }

            // Register Disconnect Callback
            ExceptionCallback = new cbExceptiondelegate(DisconnectCallback);
            int exception = _camera.MV_CC_RegisterExceptionCallBack_NET(ExceptionCallback, IntPtr.Zero);
            if (MV_OK != exception)
            {
                var errorMessage = GetErrorMessage($"HIK Camera Register exception callback failed. Name : {Name}", exception);
                Logger.Error(ErrorType.Camera, errorMessage);
                return false;
            }

            return true;
        }

        private void OnImageGrabbed(IntPtr pData, ref MyCamera.MV_FRAME_OUT_INFO_EX FrameInfo, IntPtr pUser)
        {
            lock (_lock)
            {
                if (pData == null)
                    return;

                byte[] temp = new byte[PayLoadSize];
                Marshal.Copy(pData, temp, 0, (int)PayLoadSize);

                LastImageData = temp;
            }

            ImageGrabbedCallback();
            OnceGrabEvent.Set();
        }

        private void DisconnectCallback(uint message, IntPtr pData)
        {
            if (message == MV_EXCEPTION_DEV_DISCONNECT)
            {
                Logger.Error(ErrorType.Camera, "MV_EXCEPTION_DEV_DISCONNECT");

                Release();
                Thread.Sleep(100);

                Initialize();
            }
        }

        public override bool Release()
        {
            base.Release();

            bool result = base.Release();
            if (IsReleaseBuf == false)
                Marshal.FreeHGlobal(BufForDriver);

            _camera.MV_CC_StopGrabbing_NET();
            _camera.MV_CC_CloseDevice_NET();
            _camera.MV_CC_DestroyDevice_NET();

            return true;
        }

        public override byte[] GetGrabbedImage()
        {
            lock (_lock)
            {
                if (LastImageData != null)
                    return LastImageData;
                else
                    return null;
            }
        }

        public override void GrabOnce()
        {
            Stop();
            OnceGrabEvent.Reset();

            _isGrabbing = true;
            SetAcquisitionMode(MV_CAM_ACQUISITION_MODE.MV_ACQ_MODE_SINGLE);
            _camera.MV_CC_StartGrabbing_NET();

            OnceGrabEvent.WaitOne(OnceGrabResponseTimeMs);
        }

        public override void GrabMulti(int grabCount)
        {
            _isGrabbing = true;
            SetAcquisitionMode(MV_CAM_ACQUISITION_MODE.MV_ACQ_MODE_MUTLI);
            _camera.MV_CC_StartGrabbing_NET();
        }

        public override void GrabContinous()
        {
            _isGrabbing = true;
            SetAcquisitionMode(MV_CAM_ACQUISITION_MODE.MV_ACQ_MODE_CONTINUOUS);
            _camera.MV_CC_StartGrabbing_NET();
        }

        public override void Stop()
        {
            _isGrabbing = false;
            int result = _camera.MV_CC_StopGrabbing_NET();
            if (MV_OK != result)
            {
                var errorMessage = GetErrorMessage($"HIK Camera Stop Grab failed. Name : {Name}", result);
                Logger.Error(ErrorType.Camera, errorMessage);
                return;
            }
        }

        public override bool IsGrabbing()
        {
            return _isGrabbing;
        }

        public override void SetExposureTime(double value)
        {
            float expose = (float)(value);
            int result = _camera.MV_CC_SetFloatValue_NET("ExposureTime", expose);
            if (result != MV_OK)
            {
                var errorMessage = GetErrorMessage($"HIK Camera SetExposureTime failed({expose}). Name : {Name}", result);
                Logger.Error(ErrorType.Camera, errorMessage);
                return;
            }
        }

        public override double GetExposureTime()
        {
            MyCamera.MVCC_FLOATVALUE stFloatVal = new MyCamera.MVCC_FLOATVALUE();
            _camera.MV_CC_GetFloatValue_NET("ExposureTime", ref stFloatVal);

            return (double)stFloatVal.fCurValue;
        }

        public override void SetReverseX(bool reverse)
        {
            //MVS 연결 후 작성 예정
            int result = _camera.MV_CC_SetBoolValue_NET("ReverseX", reverse);
            if (result != MV_OK)
            {
                var errorMessage = GetErrorMessage($"HIK Camera Reverse failed({reverse}). Name : {Name}", result);
                Logger.Error(ErrorType.Camera, errorMessage);
                return;
            }
        }

        public override void SetAnalogGain(int value)
        {
            //MVS 연결 후 작성 예정
        }

        public override void SetDigitalGain(double value)
        {
            //MVS 연결 후 작성 예정
        }

        public override void SetOffsetX(int value)
        {
            //MVS 연결 후 작성 예정
        }

        public override void SetImageWidth(int value)
        {
            //MVS 연결 후 작성 예정
        }

        public override void SetImageHeight(int value)
        {
            //MVS 연결 후 작성 예정
        }

        public override int GetAnalogGain()
        {
            return 0;
        }

        public override double GetDigitalGain()
        {
            return 0;
        }

        public override int GetOffsetX()
        {
            return 0;
        }

        public override int GetImageWidth()
        {
            return 0;
        }
        #endregion

    }

    public partial class CameraHIK : ICameraTriggerable
    {
        #region 속성
        public int TriggerChannel { get; set; }

        public TriggerMode TriggerMode { get; set; }

        public int TriggerSource { get; set; }
        #endregion

        #region 메서드
        public void ActiveTriggerCommand()
        {
            int result = MV_OK;

            // Trigger Mode
            if (TriggerMode == TriggerMode.Software)
            {
                MV_CAM_TRIGGER_MODE currentTriggerMode = (MV_CAM_TRIGGER_MODE)GetEnumValue("TriggerMode").nCurValue;

                if (currentTriggerMode != MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_OFF)
                    result = _camera.MV_CC_SetEnumValue_NET("TriggerMode", (uint)MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_OFF);
                else
                    Logger.Error(ErrorType.Camera, $"Already Set Trigger Mode : {TriggerMode}");
            }
            else if (TriggerMode == TriggerMode.Hardware)
            {
                MV_CAM_TRIGGER_MODE currentTriggerMode = (MV_CAM_TRIGGER_MODE)GetEnumValue("TriggerMode").nCurValue;

                if (currentTriggerMode != MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON)
                    result = _camera.MV_CC_SetEnumValue_NET("TriggerMode", (uint)MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON);
                else
                    Logger.Error(ErrorType.Camera, $"Already Set Trigger Mode : {TriggerMode}");
            }

            if (result != MV_OK)
            {
                var errorMessage = GetErrorMessage($"HIK Camera SetTriggerMode failed({TriggerMode}). Name : {Name}", result);
                Logger.Error(ErrorType.Camera, errorMessage);
                return;
            }

            // Trigger Source
            TriggerSource = 7;

            MV_CAM_TRIGGER_SOURCE currentTriggerSource = (MV_CAM_TRIGGER_SOURCE)GetEnumValue("TriggerSource").nCurValue;
            if (currentTriggerSource != (MV_CAM_TRIGGER_SOURCE)TriggerSource)
                result = _camera.MV_CC_SetEnumValue_NET("TriggerSource", (uint)TriggerSource);
            else
                Logger.Error(ErrorType.Camera, $"Already Set Trigger Source : {TriggerSource}");

            if (result != MV_OK)
            {
                MyCamera.MV_CAM_TRIGGER_SOURCE source = (MyCamera.MV_CAM_TRIGGER_SOURCE)TriggerSource;
                var errorMessage = GetErrorMessage($"HIK Camera TriggerSource set failed({source}). Name : {Name}", result);
                Logger.Error(ErrorType.Camera, errorMessage);
                return;
            }
        }

        public void SetTriggerMode(TriggerMode triggerMode)
        {
            TriggerMode = triggerMode;
            ActiveTriggerCommand();
        }
        #endregion
    }
    public enum HIKTriggerSourceType
    {
        MV_TRIGGER_SOURCE_LINE0 = 0,
        MV_TRIGGER_SOURCE_LINE1 = 1,
        MV_TRIGGER_SOURCE_LINE2 = 2,
        MV_TRIGGER_SOURCE_LINE3 = 3,
        MV_TRIGGER_SOURCE_COUNTER0 = 4,
        MV_TRIGGER_SOURCE_SOFTWARE = 7,
        MV_TRIGGER_SOURCE_FrequencyConverter = 8
    }

    public partial class CameraHIK
    {
        public bool FindDevice()
        {
            int result = MV_OK;

            // 현재 연결된 Camera 정보 가져오기
            var currentDeviceList = new MyCamera.MV_CC_DEVICE_INFO_LIST();
            result = MV_CC_EnumDevices_NET(MV_GIGE_DEVICE | MV_USB_DEVICE, ref currentDeviceList);
            if (result != MV_OK)
                return false;

            // 연결된 Camera 중 설정된 Serial 값과 동일한 정보 축출
            for (int i = 0; i < currentDeviceList.nDeviceNum; i++)
            {
                MyCamera.MV_CC_DEVICE_INFO deviceInfo = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(currentDeviceList.pDeviceInfo[i], typeof(MyCamera.MV_CC_DEVICE_INFO));

                if (deviceInfo.nTLayerType == MV_GIGE_DEVICE)
                {
                    if (GetGigESerialNumber(deviceInfo) == SerialNo)
                    {
                        SelectedDeviceInfo = deviceInfo;
                        return true;
                    }
                }
                else if (deviceInfo.nTLayerType == MV_USB_DEVICE)
                {
                    if (GetUSBSerialNumber(deviceInfo) == SerialNo)
                    {
                        SelectedDeviceInfo = deviceInfo;
                        return true;
                    }
                }
            }
            return false;
        }

        public bool OpenDevice()
        {
            int result = MV_OK;

            // 축출된 정보로 객체 생성
            result = _camera.MV_CC_CreateDevice_NET(ref SelectedDeviceInfo);
            if (MV_OK != result)
                return false;

            //카메라 오픈이 안됬을 경우 재시도한다.
            result = _camera.MV_CC_OpenDevice_NET();
            if (MV_OK != result)
            {
                ReConnectTry(tryCount: 30, sleepTime: 2000);
            }
#if DEBUG
#else
            _camera.MV_CC_SetHeartBeatTimeout_NET(1000);
#endif
            return true;
        }

        public bool SetGigEGevSCPSPacketSize()
        {
            int result = MV_OK;
            if (SelectedDeviceInfo.nTLayerType == MV_GIGE_DEVICE)
            {
                int packetSize = _camera.MV_CC_GetOptimalPacketSize_NET();
                if (packetSize > 0)
                {
                    result = _camera.MV_CC_SetIntValue_NET("GevSCPSPacketSize", (uint)packetSize);
                    if (result != MV_OK)
                    {
                        var errorMessage = GetErrorMessage($"HIK Camera Set Packet Size failed. Name : {Name}", result);
                        Logger.Error(ErrorType.Camera, errorMessage);
                        return false;
                    }
                }
                else
                {
                    Logger.Error(ErrorType.Camera, $"HIK Camera Get Packet Size failed. Name : {Name}");
                    return false;
                }
            }
            return true;
        }

        private string GetGigESerialNumber(MyCamera.MV_CC_DEVICE_INFO stDevInfo)
        {
            if (MV_GIGE_DEVICE == stDevInfo.nTLayerType)
            {
                MyCamera.MV_GIGE_DEVICE_INFO stGigeDeviceInfo = (MyCamera.MV_GIGE_DEVICE_INFO)ByteToStruct(stDevInfo.SpecialInfo.stGigEInfo, typeof(MyCamera.MV_GIGE_DEVICE_INFO));
                return stGigeDeviceInfo.chSerialNumber;
            }
            return "";
        }

        private string GetUSBSerialNumber(MyCamera.MV_CC_DEVICE_INFO stDevInfo)
        {
            if (MV_GIGE_DEVICE == stDevInfo.nTLayerType)
            {
                MyCamera.MV_USB3_DEVICE_INFO usbDeviceInfo = (MyCamera.MV_USB3_DEVICE_INFO)ByteToStruct(stDevInfo.SpecialInfo.stUsb3VInfo, typeof(MyCamera.MV_USB3_DEVICE_INFO));
                return usbDeviceInfo.chSerialNumber;
            }
            return "";
        }

        private bool SetAcquisitionMode(MyCamera.MV_CAM_ACQUISITION_MODE type)
        {
            var getValue = (MV_CAM_ACQUISITION_MODE)GetEnumValue("AcquisitionMode").nCurValue;

            if (type != getValue)
            {
                int result = _camera.MV_CC_SetEnumValue_NET("AcquisitionMode", (uint)type);
                if (result != 0)
                {
                    var errorMessage = GetErrorMessage($"HIK Camera Acquisition Mode set failed. Name : {Name}", result);
                    Logger.Error(ErrorType.Camera, errorMessage);
                    return false;
                }
            }
            else
                Logger.Error(ErrorType.Camera, $"Already Set SetAcquisitionMode Mode : {type}");

            return true;
        }

        private MyCamera.MVCC_ENUMVALUE GetEnumValue(string enumString)
        {
            MyCamera.MVCC_ENUMVALUE getValue = new MyCamera.MVCC_ENUMVALUE();

            _camera.MV_CC_GetEnumValue_NET(enumString, ref getValue);

            return getValue;
        }

        public uint GetPayLoadSize()
        {
            int result = _camera.MV_CC_GetIntValue_NET("PayloadSize", ref IntValueParam);
            if (MV_OK != result)
            {
                var errorMessage = GetErrorMessage($"HIK Camera Get PayloadSize failed. Name : {Name}", result);
                Logger.Error(ErrorType.Camera, errorMessage);
            }

            return IntValueParam.nCurValue;
        }

        #region 메서드

        private void ReConnectTry(int tryCount = 30, int sleepTime = 2000)
        {
            int result = MV_OK;
            _camera.MV_CC_CloseDevice_NET();
            _camera.MV_CC_DestroyDevice_NET();

            result = _camera.MV_CC_CreateDevice_NET(ref SelectedDeviceInfo);
            if (MV_OK != result)
                throw new Exception(GetErrorMessage($"Device Create Fail!", result));

            int reTry = 0;
            while (true)
            {
                Thread.Sleep(sleepTime);
                result = _camera.MV_CC_OpenDevice_NET();
                if (MV_OK != result)
                {
                    if (tryCount < reTry++)
                        throw new Exception(GetErrorMessage($"Device Create Fail!", result));
                    else
                        Logger.Error(ErrorType.Camera, $"HIK Camera Open Error. ReConnectTry...{reTry}");
                }
                else
                    break;
            }
        }

        private string GetErrorMessage(string problem, int errorCode)
        {
            var errorMessage = errorCode == MV_OK ? problem : $"{problem}, ErrorCode : {errorCode:X2}";
            switch (errorCode)
            {
                case MV_E_HANDLE:
                    errorMessage = $"{errorMessage}, Detail : Error or invalid handle";
                    break;
                case MV_E_SUPPORT:
                    errorMessage = $"{errorMessage}, Detail : Not supported function";
                    break;
                case MV_E_BUFOVER:
                    errorMessage = $"{errorMessage}, Detail : Cache is full ";
                    break;
                case MV_E_CALLORDER:
                    errorMessage = $"{errorMessage}, Detail : Function calling order error";
                    break;
                case MV_E_PARAMETER:
                    errorMessage = $"{errorMessage}, Detail : Incorrect parameter";
                    break;
                case MV_E_RESOURCE:
                    errorMessage = $"{errorMessage}, Detail : Applying resource failed";
                    break;
                case MV_E_NODATA:
                    errorMessage = $"{errorMessage}, Detail : No data";
                    break;
                case MV_E_PRECONDITION:
                    errorMessage = $"{errorMessage}, Detail : Precondition error, or running environment changed";
                    break;
                case MV_E_VERSION:
                    errorMessage = $"{errorMessage}, Detail : Version mismatches";
                    break;
                case MV_E_NOENOUGH_BUF:
                    errorMessage = $"{errorMessage}, Detail : Insufficient memory";
                    break;
                case MV_E_UNKNOW:
                    errorMessage = $"{errorMessage}, Detail : Unknown error";
                    break;
                case MV_E_GC_GENERIC:
                    errorMessage = $"{errorMessage}, Detail : General error";
                    break;
                case MV_E_GC_ACCESS:
                    errorMessage = $"{errorMessage}, Detail : Node accessing condition error";
                    break;
                case MV_E_ACCESS_DENIED:
                    errorMessage = $"{errorMessage}, Detail : No permission";
                    break;
                case MV_E_BUSY:
                    errorMessage = $"{errorMessage}, Detail : Device is busy, or network disconnected";
                    break;
                case MV_E_NETER:
                    errorMessage = $"{errorMessage}, Detail : Network error";
                    break;
            }

            return errorMessage;
        }
        #endregion
    }
}
