using Jastech.Framework.Device.Grabbers;
using Jastech.Framework.Imaging;
using Jastech.Framework.Matrox;
using Jastech.Framework.Util.Helper;
using Matrox.MatroxImagingLibrary;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Jastech.Framework.Device.Cameras
{
    public partial class CameraMil : Camera, ICameraTriggerable, ICameraTDIavailable
    {
        #region 필드
        const int BufferPoolCount = 10;

        private static object _lock = new object();

        private MilSystem MilSystem { get; set; } = null;

        private MIL_ID DigitizerId { get; set; }

        private GCHandle _thisHandle;

        private MIL_ID LastGrabImage = MIL.M_NULL;

        private MIL_ID[] _grabImageBuffer = new MIL_ID[BufferPoolCount];

        private MIL_DIG_HOOK_FUNCTION_PTR _processingFunctionPtr = null;

        private bool _isGrabbing { get; set; } = false;
        #endregion

        #region 속성
        [JsonProperty]
        public int CamCount { get; set; } = 1;

        [JsonProperty]
        public MilSystemType MilSystemType { get; set; } = MilSystemType.Rapixo;

        [JsonProperty]
        public uint DigitizerNum { get; set; } = 0; // 1개의 Frame Grabber에 연결된 카메라 Index

        [JsonProperty]
        public uint SystemNum { get; set; } = 0; // 설치된 Frame Grabber Index

        [JsonProperty]
        public int NumOfBand { get; set; }

        [JsonProperty]
        public int ImagePitch { get; set; }

        [JsonProperty]
        public CameraType CameraType { get; set; }

        public int GrabCount { get; set; } = 0;
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        public CameraMil(string name, int imageWidth, int imageHeight, ColorFormat colorFormat, SensorType sensorType)
          : base(name, imageWidth, imageHeight, colorFormat, sensorType)
        {
        }
        #endregion

        #region 메서드
        public override bool Initialize()
        {
            base.Initialize();
        
            MilSystem = GrabberMil.GetMilSystem(MilSystemType, SystemNum);

            if (MilSystem == null)
                return false;

            string dcfFile = GetDcfFile(CameraType);
            if (MilSystemType == MilSystemType.Rapixo)
                dcfFile = "";
            else
            {
                if (dcfFile == "")
                    return false;
            }
            
            if (CreateDigitizerId(dcfFile) == false)
                return false;

            MIL.MappControl(MIL.M_ERROR, MIL.M_PRINT_ENABLE);
#if DEBUG
            MIL.MdigControl(DigitizerId, MIL.M_GRAB_TIMEOUT, MIL.M_INFINITE);
#elif RELEASE
                        MIL.MdigControl(MilDigitizerId, MIL.M_GRAB_TIMEOUT, 5000);
#endif
            // MIL M_GRAB_END 콜백 등록
            _thisHandle = GCHandle.Alloc(this);
            _processingFunctionPtr = new MIL_DIG_HOOK_FUNCTION_PTR(ProcessingFunction);

            //ActiveTriggerCommand();

            MIL_INT tempValue = 0;
            MIL_INT width = 0;
            MIL_INT height = 0;

            MIL.MdigInquire(DigitizerId, MIL.M_SIZE_X, ref width);
            MIL.MdigInquire(DigitizerId, MIL.M_SIZE_Y, ref height);

            MIL.MdigInquire(DigitizerId, MIL.M_SIZE_BAND, ref tempValue);
            NumOfBand = (int)tempValue;

            ImagePitch = (int)width * NumOfBand;

            if (NumOfBand == 1)
            {
                for (int i = 0; i < BufferPoolCount; i++)
                    _grabImageBuffer[i] = MIL.MbufAlloc2d(MilSystem.SystemId, width, height, MIL.M_UNSIGNED + 8, MIL.M_IMAGE + MIL.M_PROC + MIL.M_GRAB, MIL.M_NULL);
            }
            else
            {
                for (int i = 0; i < BufferPoolCount; i++)
                    _grabImageBuffer[i] = MIL.MbufAllocColor(MilSystem.SystemId, 3, width, height, MIL.M_UNSIGNED + 8, MIL.M_IMAGE + MIL.M_PROC + MIL.M_GRAB, MIL.M_NULL);
            }
            return true;
        }

        public override bool Release()
        {
            if (DigitizerId == MIL.M_NULL)
                return true;

            base.Release();
            MIL.MdigFree(DigitizerId);
            DigitizerId = MIL.M_NULL;

            for (int i = 0; i < _grabImageBuffer.Length; i++)
            {
                MIL.MbufFree(_grabImageBuffer[i]);
                _grabImageBuffer[i] = MIL.M_NULL;
            }
            return true;
        }

        private bool CreateDigitizerId(string dcfFile)
        {
            MIL_ID milDigitizer = MIL.MdigAlloc(MilSystem.SystemId, DigitizerNum, dcfFile, MIL.M_DEFAULT, MIL.M_NULL);

            if (milDigitizer == null)
                return false;

            DigitizerId = milDigitizer;

            return true;
        }

        private string GetDcfFile(CameraType cameraType)
        {
            string dcfFile = "";
            switch (cameraType)
            {
                case CameraType.VT_6k35c_trigger:
                    dcfFile = "VT-6k3.5c_trigger.dcf";
                    break;
                default:
                    break;
            }
            return dcfFile;
        }

        public override byte[] GetGrabbedImage()
        {
            lock (_lock)
            {
                if (LastGrabImage != null)
                {
                    IntPtr ptr = IntPtr.Zero;
                    var pitch = MIL.MbufInquire(LastGrabImage, MIL.M_PITCH, ptr);
                    byte[] dataArray = new byte[ImageWidth * ImageHeight * ImageChannel];

                    MIL.MbufGet(LastGrabImage, dataArray);
                    
                    return dataArray;
                }
                else
                {
                    return null;
                }
            }
        }

        public override void GrabOnce()
        {
            if(LastGrabImage == MIL.M_NULL)
            {
                LastGrabImage = _grabImageBuffer[0];
            }
            _isGrabbing = true;
            MIL.MdigGrab(DigitizerId, LastGrabImage);
            _isGrabbing = false;
        }

        public override void GrabMulti(int grabCount)
        {
            _isGrabbing = true;
            if (TriggerMode == TriggerMode.Software)
            {
                if (_processingFunctionPtr == null)
                    _processingFunctionPtr = new MIL_DIG_HOOK_FUNCTION_PTR(ProcessingFunction);

                MIL.MdigProcess(DigitizerId, _grabImageBuffer, BufferPoolCount, MIL.M_START, MIL.M_DEFAULT, _processingFunctionPtr, GCHandle.ToIntPtr(_thisHandle));
            }
            else
            {
                if (_processingFunctionPtr == null)
                    _processingFunctionPtr = new MIL_DIG_HOOK_FUNCTION_PTR(ProcessingFunction);

                // 정해진 GrabCount 만큼 영상 취득
                int count = grabCount < BufferPoolCount ? grabCount : BufferPoolCount;
                MIL.MdigProcess(DigitizerId, _grabImageBuffer, BufferPoolCount, MIL.M_SEQUENCE + MIL.M_COUNT(count), MIL.M_ASYNCHRONOUS, _processingFunctionPtr, GCHandle.ToIntPtr(_thisHandle));
            }
        }

        public override void GrabContinous()
        {
            _isGrabbing = true;

            if (_processingFunctionPtr != null)
                _processingFunctionPtr = new MIL_DIG_HOOK_FUNCTION_PTR(ProcessingFunction);

            // Stop 명령어 올때 까지 계속해서 Grab
            MIL.MdigProcess(DigitizerId, _grabImageBuffer, BufferPoolCount, MIL.M_START, MIL.M_DEFAULT, _processingFunctionPtr, GCHandle.ToIntPtr(_thisHandle));
        }
        public override void Stop()
        {
            _isGrabbing = false;
            if (TriggerMode == TriggerMode.Software)
            {
                MIL.MdigProcess(DigitizerId, _grabImageBuffer, BufferPoolCount, MIL.M_STOP, MIL.M_SYNCHRONOUS, _processingFunctionPtr,  GCHandle.ToIntPtr(_thisHandle));
            }
            else
            {
                MIL.MdigProcess(DigitizerId, _grabImageBuffer, BufferPoolCount, MIL.M_STOP, MIL.M_DEFAULT, _processingFunctionPtr, GCHandle.ToIntPtr(_thisHandle));
            }
            //Thread.Sleep(50);
        }

        public override bool IsGrabbing()
        {
            return _isGrabbing;
        }

        static MIL_INT ProcessingFunction(MIL_INT HookType, MIL_ID HookId, IntPtr HookDataPtr)
        {
            if (IntPtr.Zero.Equals(HookDataPtr) == true)
                return MIL.M_NULL;
            MIL_ID currentImageId = MIL.M_NULL;
            MIL.MdigGetHookInfo(HookId, MIL.M_MODIFIED_BUFFER + MIL.M_BUFFER_ID, ref currentImageId);

            GCHandle hUserData = GCHandle.FromIntPtr(HookDataPtr);

            // get a reference to the DigHookUserData object
            CameraMil cameraMil = hUserData.Target as CameraMil;
            cameraMil.GrabCount = cameraMil.GrabCount++;
            cameraMil.LastGrabImage = currentImageId;
            cameraMil.ImageGrabbedCallback();

            string message = string.Format("Camera Name : {0} Grab Count : {1}", cameraMil.Name, cameraMil.GrabCount);
            Logger.Debug(LogType.Device, message);

            return MIL.M_NULL;
        }

        public override void SetExposureTime(double value)
        {
            long exposureTimeInus = (long)value;
            MIL.MdigControlFeature(DigitizerId, MIL.M_FEATURE_VALUE, "ExposureTime", MIL.M_TYPE_DOUBLE, ref exposureTimeInus);
        }

        public override double GetExposureTime()
        {
            // dcf 파일에서 설정함
            return 0.0;
        }

        public override void ReverseX(bool reverse)
        {
            // dcf 파일에서 설정함
        }

        public override void SetAnalogGain(int value)
        {
            string analogGain = "X" + value.ToString();
            MIL.MdigControlFeature(DigitizerId, MIL.M_FEATURE_VALUE, "AnalogGain", MIL.M_TYPE_STRING, "X1");
        }

        public override void SetDigitalGain(double value)
        {
            double digitalGain = value;
            MIL.MdigControlFeature(DigitizerId, MIL.M_FEATURE_VALUE, "DigitalGain", MIL.M_TYPE_DOUBLE, ref digitalGain);
        }

        public override void SetOffsetX(int value)
        {
            // dcf 파일에서 설정함
        }

        public override void SetImageWidth(int value)
        {
            long width = (long)value;
            MIL.MdigControlFeature(DigitizerId, MIL.M_FEATURE_VALUE, "Width", MIL.M_TYPE_INT64, ref width);
        }
        #endregion
    }

    public partial class CameraMil : ICameraTriggerable
    {
        #region 속성
        public int TriggerChannel { get; set; }

        public TriggerMode TriggerMode { get; set; }

        public int TriggerSource { get; set; }

        [JsonProperty]
        public MilTriggerSignalType TriggerSignalType { get; set; }

        [JsonProperty]
        public MILIoSourceType TriggerIoSourceType { get; set; }
        #endregion

        #region 메서드
        public void ActiveTriggerCommand()
        {
            // Trigger Mode
            if (TriggerMode == TriggerMode.Software)
                MIL.MdigControlFeature(DigitizerId, MIL.M_FEATURE_VALUE, "TriggerMode", MIL.M_TYPE_STRING, "Off");
            else
            {
                MIL.MdigControlFeature(DigitizerId, MIL.M_FEATURE_VALUE, "TriggerMode", MIL.M_TYPE_STRING, "On");
                // Trigger Source
                MilCxpTriggerSource source = (MilCxpTriggerSource)TriggerSource;
                if (source == MilCxpTriggerSource.Lin0)
                    MIL.MdigControlFeature(DigitizerId, MIL.M_FEATURE_VALUE, "TriggerSource", MIL.M_TYPE_STRING, "LineStart");
                else if (source == MilCxpTriggerSource.Cxp)
                    MIL.MdigControlFeature(DigitizerId, MIL.M_FEATURE_VALUE, "TriggerSource", MIL.M_TYPE_STRING, "CXPin");

                // Trigger Signal 
                //ex : MIL.MdigControl(DigitizerId, MIL.M_TL_TRIGGER + MIL.M_IO_SOURCE, MIL.M_AUX_IO0);
                long controlType = GetTriggerSignalType(TriggerSignalType);
                MIL_INT controlValue = GetTriggerIoSource(TriggerIoSourceType);
                MIL.MdigControl(DigitizerId, controlType, controlValue);
            }
        }

        public void SetTriggerMode(TriggerMode triggerMode)
        {
            TriggerMode = triggerMode;
            ActiveTriggerCommand();
        }

        private int GetTriggerSignalType(MilTriggerSignalType signalType)
        {
            int value = 0;
            switch (signalType)
            {
                case MilTriggerSignalType.TL_Trigger:
                    value = MIL.M_TL_TRIGGER + MIL.M_IO_SOURCE;
                    break;
                default:
                    break;
            }
            return value;
        }

        private int GetTriggerIoSource(MILIoSourceType sourceType)
        {
            int value = 0;
            switch (sourceType)
            {
                case MILIoSourceType.AUX_IO0:
                    value = MIL.M_AUX_IO0;
                    break;
                default:
                    break;
            }
            return value;
        }
        #endregion
    }

    public partial class CameraMil : ICameraTDIavailable
    {
        public TDIOperationMode TDIOperationMode { get; set; }

        public TDIDirectionType TDIDirection { get; set; }

        public int TDIStages { get; set; }

        public void SetTDIScanDriection(TDIDirectionType direction)
        {
            TDIDirection = direction;
        }

        public void SetTDIOperationMode(TDIOperationMode mode)
        {
            
            TDIOperationMode = mode;
            if (TDIOperationMode == TDIOperationMode.Area)
            {
                MIL.MdigControlFeature(DigitizerId, MIL.M_FEATURE_VALUE, "TDIStages", MIL.M_TYPE_STRING, "TDI256");
                StringBuilder value = new StringBuilder();
                MIL.MdigInquireFeature(DigitizerId, MIL.M_FEATURE_VALUE, "TDIStages", MIL.M_TYPE_STRING, value);
                string stageString = value.ToString().Replace("TDI", "").Trim();

                TDIStages = Convert.ToInt32(stageString);

                MIL.MdigControlFeature(DigitizerId, MIL.M_FEATURE_VALUE, "OperationMode", MIL.M_TYPE_STRING, "Area");
                SetTriggerMode(TriggerMode.Software);
            }
            else
            {
                MIL.MdigControlFeature(DigitizerId, MIL.M_FEATURE_VALUE, "OperationMode", MIL.M_TYPE_STRING, "TDI");
                SetTriggerMode(TriggerMode.Hardware);
            }
        }
    }

    public enum MilTriggerSignalType
    {
        TL_Trigger,
    }

    public enum MILIoSourceType
    {
        AUX_IO0,
    }

}
