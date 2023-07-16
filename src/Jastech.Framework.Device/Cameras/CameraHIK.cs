using Jastech.Framework.Imaging;
using Jastech.Framework.Util.Helper;
using MvCamCtrl.NET;
using Newtonsoft.Json;
using System;
using System.ComponentModel.Composition.Primitives;
using System.Runtime.InteropServices;
using System.Threading;

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

        public byte[] LastImageData { get; set; } = null;

        private UInt32 PayLoadSize { get; set; }

        private bool IsReleaseBuf { get; set; } = true;

        private IntPtr BufForDriver { get; set; }

        private MyCamera.MV_CC_DEVICE_INFO SelectedDeviceInfo = new MyCamera.MV_CC_DEVICE_INFO();

        private MyCamera.MVCC_INTVALUE IntValueParam = new MyCamera.MVCC_INTVALUE();

        private MyCamera.cbOutputExdelegate ImageCallback;
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

            SetAcquisitionMode(MyCamera.MV_CAM_ACQUISITION_MODE.MV_ACQ_MODE_CONTINUOUS);

            ActiveTriggerCommand();

            ReverseX(IsReverseX);

            PayLoadSize = GetPayLoadSize();

            //Register Callback
            ImageCallback = new MyCamera.cbOutputExdelegate(OnImageGrabbed);
            int result = _camera.MV_CC_RegisterImageCallBackEx_NET(ImageCallback, IntPtr.Zero);
            if (MyCamera.MV_OK != result)
            {
                Logger.Error(ErrorType.Camera, string.Format("HIK Camera Register image callback failed. Name : {0}", Name));
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
            lock(_lock)
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

            _isGrabbing = true;
            SetAcquisitionMode(MyCamera.MV_CAM_ACQUISITION_MODE.MV_ACQ_MODE_SINGLE);
            _camera.MV_CC_StartGrabbing_NET();
        }

        public override void GrabMulti(int grabCount)
        {
            _isGrabbing = true;
            SetAcquisitionMode(MyCamera.MV_CAM_ACQUISITION_MODE.MV_ACQ_MODE_MUTLI);
            _camera.MV_CC_StartGrabbing_NET();
        }

        public override void GrabContinous()
        {
            _isGrabbing = true;
            SetAcquisitionMode(MyCamera.MV_CAM_ACQUISITION_MODE.MV_ACQ_MODE_CONTINUOUS);
            _camera.MV_CC_StartGrabbing_NET();
        }

        public override void Stop()
        {
            _isGrabbing = false;
            int nRet = _camera.MV_CC_StopGrabbing_NET();
            if (MyCamera.MV_OK != nRet)
            {
                Logger.Error(ErrorType.Camera, string.Format("HIK Camera Stop Grab failed. Name : {0}", Name));
                return;
            }
        }

        public override bool IsGrabbing()
        {
            return _isGrabbing;
        }

        public override void SetExposureTime(double value)
        {
            float expose = (float)(value * 1000.0F);
            int nRet = _camera.MV_CC_SetFloatValue_NET("ExposureTime", expose);
            if (nRet != MyCamera.MV_OK)
            {
                Logger.Error(ErrorType.Camera, string.Format("HIK Camera SetExposureTime failed({0}). Name : {1}", expose, Name));
                return;
            }
        }

        public override double GetExposureTime()
        {
            MyCamera.MVCC_FLOATVALUE stFloatVal = new MyCamera.MVCC_FLOATVALUE();
            _camera.MV_CC_GetFloatValue_NET("ExposureTime", ref stFloatVal);

            return (double)stFloatVal.fCurValue;
        }

        public override void ReverseX(bool reverse)
        {
            //MVS 연결 후 작성 예정
            int nRet = _camera.MV_CC_SetBoolValue_NET("ReverseX", reverse);
            if (nRet != MyCamera.MV_OK)
            {
                Logger.Error(ErrorType.Camera, string.Format("HIK Camera Reverse failed({0}). Name : {1}", reverse, Name));
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
            int result = MyCamera.MV_OK;

            // Trigger Mode
            if (TriggerMode == TriggerMode.Software)
                result = _camera.MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_OFF);
            else if (TriggerMode == TriggerMode.Hardware)
                result = _camera.MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON);

            if (result != MyCamera.MV_OK)
            {
                Logger.Error(ErrorType.Camera, string.Format("HIK Camera SetTriggerMode failed({0}). Name : {1}", TriggerMode.ToString(), Name));
                return;
            }

            // Trigger Source
            TriggerSource = 7;
            result = _camera.MV_CC_SetEnumValue_NET("TriggerSource", (uint)TriggerSource);

            if (result != MyCamera.MV_OK)
            {
                MyCamera.MV_CAM_TRIGGER_SOURCE source = (MyCamera.MV_CAM_TRIGGER_SOURCE)TriggerSource;
                Logger.Error(ErrorType.Camera, string.Format("HIK Camera TriggerSource set failed({0}). Name : {1}", source.ToString(), Name));
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
            int result = MyCamera.MV_OK;

            // 현재 연결된 Camera 정보 가져오기
            var currentDeviceList = new MyCamera.MV_CC_DEVICE_INFO_LIST();
            result = MyCamera.MV_CC_EnumDevices_NET(MyCamera.MV_GIGE_DEVICE | MyCamera.MV_USB_DEVICE, ref currentDeviceList);
            if (result != MyCamera.MV_OK)
                return false;

            // 연결된 Camera 중 설정된 Serial 값과 동일한 정보 축출
            for (int i = 0; i < currentDeviceList.nDeviceNum; i++)
            {
                MyCamera.MV_CC_DEVICE_INFO deviceInfo = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(currentDeviceList.pDeviceInfo[i], typeof(MyCamera.MV_CC_DEVICE_INFO));

                if (deviceInfo.nTLayerType == MyCamera.MV_GIGE_DEVICE)
                {
                    if (GetGigESerialNumber(deviceInfo) == SerialNo)
                    {
                        SelectedDeviceInfo = deviceInfo;
                        return true;
                    }
                }
                else if (deviceInfo.nTLayerType == MyCamera.MV_USB_DEVICE)
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
            int result = MyCamera.MV_OK;

            // 축출된 정보로 객체 생성
            result = _camera.MV_CC_CreateDevice_NET(ref SelectedDeviceInfo);
            if (MyCamera.MV_OK != result)
                return false;

            //카메라 오픈이 안됬을 경우 재시도한다.
            result = _camera.MV_CC_OpenDevice_NET();
            if (MyCamera.MV_OK != result)
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
            int result = MyCamera.MV_OK;
            if (SelectedDeviceInfo.nTLayerType == MyCamera.MV_GIGE_DEVICE)
            {
                int packetSize = _camera.MV_CC_GetOptimalPacketSize_NET();
                if (packetSize > 0)
                {
                    result = _camera.MV_CC_SetIntValue_NET("GevSCPSPacketSize", (uint)packetSize);
                    if (result != MyCamera.MV_OK)
                    {
                        Logger.Error(ErrorType.Camera, string.Format("HIK Camera Set Packet Size failed. Name : {0}", Name));
                        return false;
                    }
                }
                else
                {
                    Logger.Error(ErrorType.Camera, string.Format("HIK Camera Get Packet Size failed. Name : {0}", Name));
                    return false;
                }
            }
            return true;
        }

        private string GetGigESerialNumber(MyCamera.MV_CC_DEVICE_INFO stDevInfo)
        {
            if (MyCamera.MV_GIGE_DEVICE == stDevInfo.nTLayerType)
            {
                MyCamera.MV_GIGE_DEVICE_INFO stGigeDeviceInfo = (MyCamera.MV_GIGE_DEVICE_INFO)MyCamera.ByteToStruct(stDevInfo.SpecialInfo.stGigEInfo, typeof(MyCamera.MV_GIGE_DEVICE_INFO));
                return stGigeDeviceInfo.chSerialNumber;
            }
            return "";
        }

        private string GetUSBSerialNumber(MyCamera.MV_CC_DEVICE_INFO stDevInfo)
        {
            if (MyCamera.MV_GIGE_DEVICE == stDevInfo.nTLayerType)
            {
                MyCamera.MV_USB3_DEVICE_INFO usbDeviceInfo = (MyCamera.MV_USB3_DEVICE_INFO)MyCamera.ByteToStruct(stDevInfo.SpecialInfo.stUsb3VInfo, typeof(MyCamera.MV_USB3_DEVICE_INFO));
                return usbDeviceInfo.chSerialNumber;
            }
            return "";
        }

        private bool SetAcquisitionMode(MyCamera.MV_CAM_ACQUISITION_MODE type)
        {
            int result = _camera.MV_CC_SetEnumValue_NET("AcquisitionMode", (uint)type);
            if (result != 0)
            {
                Logger.Error(ErrorType.Camera, string.Format("HIK Camera Acquisition Mode set failed. Name : {0}", Name));
                return false;
            }
            return true;
        }

        public uint GetPayLoadSize()
        {
            int result = _camera.MV_CC_GetIntValue_NET("PayloadSize", ref IntValueParam);
            if (MyCamera.MV_OK != result)
            {
                Logger.Error(ErrorType.Camera, string.Format("HIK Camera Get PayloadSize failed. Name : {0}", Name));
            }

            return IntValueParam.nCurValue;
        }

        #region 메서드

        private void ReConnectTry(int tryCount = 30, int sleepTime = 2000)
        {
            int nRet = MyCamera.MV_OK;
            _camera.MV_CC_CloseDevice_NET();
            _camera.MV_CC_DestroyDevice_NET();

            nRet = _camera.MV_CC_CreateDevice_NET(ref SelectedDeviceInfo);
            if (MyCamera.MV_OK != nRet)
                throw new Exception(ErrorMessage("Device Create Fail!", nRet));

            int reTry = 0;
            while (true)
            {
                Thread.Sleep(sleepTime);
                nRet = _camera.MV_CC_OpenDevice_NET();
                if (MyCamera.MV_OK != nRet)
                {
                    if (tryCount < reTry++)
                        throw new Exception(ErrorMessage("Device Create Fail!", nRet));
                    else
                        Logger.Error(ErrorType.Camera, $"HIK Camera Open Error. ReConnectTry...{reTry}");
                }
                else
                    break;
            }
        }

        private string ErrorMessage(string csMessage, int nErrorNum)
        {
            var errorMsg = nErrorNum == 0 ? csMessage : csMessage + ": Error =" + String.Format("{0:X}", nErrorNum);
            switch (nErrorNum)
            {
                case MyCamera.MV_E_HANDLE:
                    errorMsg += " Error or invalid handle ";
                    break;
                case MyCamera.MV_E_SUPPORT:
                    errorMsg += " Not supported function ";
                    break;
                case MyCamera.MV_E_BUFOVER:
                    errorMsg += " Cache is full ";
                    break;
                case MyCamera.MV_E_CALLORDER:
                    errorMsg += " Function calling order error ";
                    break;
                case MyCamera.MV_E_PARAMETER:
                    errorMsg += " Incorrect parameter ";
                    break;
                case MyCamera.MV_E_RESOURCE:
                    errorMsg += " Applying resource failed ";
                    break;
                case MyCamera.MV_E_NODATA:
                    errorMsg += " No data ";
                    break;
                case MyCamera.MV_E_PRECONDITION:
                    errorMsg += " Precondition error, or running environment changed ";
                    break;
                case MyCamera.MV_E_VERSION:
                    errorMsg += " Version mismatches ";
                    break;
                case MyCamera.MV_E_NOENOUGH_BUF:
                    errorMsg += " Insufficient memory ";
                    break;
                case MyCamera.MV_E_UNKNOW:
                    errorMsg += " Unknown error ";
                    break;
                case MyCamera.MV_E_GC_GENERIC:
                    errorMsg += " General error ";
                    break;
                case MyCamera.MV_E_GC_ACCESS:
                    errorMsg += " Node accessing condition error ";
                    break;
                case MyCamera.MV_E_ACCESS_DENIED:
                    errorMsg += " No permission ";
                    break;
                case MyCamera.MV_E_BUSY:
                    errorMsg += " Device is busy, or network disconnected ";
                    break;
                case MyCamera.MV_E_NETER:
                    errorMsg += " Network error ";
                    break;
            }

            return errorMsg;
        }
        #endregion
    }
}
