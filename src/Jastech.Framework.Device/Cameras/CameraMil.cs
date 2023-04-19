using Jastech.Framework.Device.Grabbers;
using Jastech.Framework.Imaging;
using Matrox.MatroxImagingLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Jastech.Framework.Device.Cameras
{
    public partial class CameraMil : Camera, ICameraTriggerable
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

            //MIL.MdigHookFunction(DigitizerId, MIL.M_GRAB_END, new MIL_DIG_HOOK_FUNCTION_PTR(HookHandlerPtr), GCHandle.ToIntPtr(_thisHandle));
            //MIL.MdigControl(DigitizerId, MIL.M_GRAB_MODE, MIL.M_ASYNCHRONOUS);
            //MIL.MdigControl(DigitizerId, MIL.M_GRAB_MODE, MIL.M_ASYNCHRONOUS);

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
            base.Release();
            MIL.MdigFree(DigitizerId);

            MIL.MdigFree(LastGrabImage);

            for (int i = 0; i < BufferPoolCount; i++)
            {
                MIL.MdigFree(_grabImageBuffer[i]);
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

                    //byte[] UserArrayPtr = new byte[CameraInfo.ImageWidth * CameraInfo.ImageHeight];
                    byte[] dataArray = new byte[pitch * ImageHeight];

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
            MIL.MdigGrab(DigitizerId, LastGrabImage);
        }

        public override void GrabMuti(int grabCount)
        {
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
            if (_processingFunctionPtr != null)
                _processingFunctionPtr = new MIL_DIG_HOOK_FUNCTION_PTR(ProcessingFunction);

            // Stop 명령어 올때 까지 계속해서 Grab
            MIL.MdigProcess(DigitizerId, _grabImageBuffer, BufferPoolCount, MIL.M_START, MIL.M_DEFAULT, _processingFunctionPtr, GCHandle.ToIntPtr(_thisHandle));
        }

        public override void Stop()
        {
            if (TriggerMode == TriggerMode.Software)
            {
                MIL.MdigProcess(DigitizerId, _grabImageBuffer, BufferPoolCount, MIL.M_STOP, MIL.M_SYNCHRONOUS, _processingFunctionPtr,  GCHandle.ToIntPtr(_thisHandle));
            }
            else
            {
                MIL.MdigProcess(DigitizerId, _grabImageBuffer, BufferPoolCount, MIL.M_STOP, MIL.M_DEFAULT, _processingFunctionPtr, GCHandle.ToIntPtr(_thisHandle));
            }
            Thread.Sleep(50);
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
            cameraMil.LastGrabImage = currentImageId;
            cameraMil.ImageGrabbedCallback();

            return MIL.M_NULL;
        }

        public override void SetExposureTime(double value)
        {
            // dcf 파일에서 설정함
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
            // dcf 파일에서 설정함
        }

        public override void SetDigitalGain(double value)
        {
            // dcf 파일에서 설정함
        }

        public override void SetOffsetX(int value)
        {
            // dcf 파일에서 설정함
        }

        public override void SetImageWidth(int value)
        {
            // dcf 파일에서 설정함
        }
        #endregion
    }

    public partial class CameraMil : ICameraTriggerable
    {
        #region 속성
        public int TriggerChannel { get; private set; }

        public TriggerMode TriggerMode { get; private set; }

        public int TriggerSource { get; private set; }
        #endregion

        #region 메서드
        public void SetTriggerMode(TriggerMode triggerMode)
        {
            TriggerMode = triggerMode;
        }

        public void SetTriggerSource(int triggerSource)
        {
            TriggerSource = triggerSource;
        }
        #endregion
    }
}
