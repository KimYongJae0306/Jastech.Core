using Jastech.Framework.Imaging;
using Matrox.MatroxImagingLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALSA.SaperaLT.SapClassBasic;
using ACS.SPiiPlusNET;
using System.Runtime.InteropServices;
using Jastech.Framework.Imaging.Helper;
using System.Drawing;
using Emgu.CV.Reg;
using System.IO;

namespace Jastech.Framework.Device.Cameras
{
    public partial class CameraDalsa : Camera, ICameraTriggerable
    {
        #region 필드
        private const int Timeout = 300;

        private SapAcquisition _acquisition;

        private SapAcqDevice _acquisitionDevice;

        private SapBuffer _buffer;

        private SapTransfer _transfer;

        private byte[] LastImageData;
        #endregion

        #region 속성
        [JsonProperty]
        public string CameraServerName { get; set; }

        [JsonProperty]
        public CameraType CcfFile { get; set; }

        [JsonProperty]
        public int AcquisitionIndex { get; set; }

        [JsonProperty]
        public int DeviceIndex { get; set; }
        #endregion

        #region 생성자
        public CameraDalsa(string name, int imageWidth, int imageHeight, ColorFormat colorFormat, SensorType sensorType) 
            : base(name, imageWidth, imageHeight, colorFormat, sensorType)
        {
        }
        #endregion

        #region 메서드
        public override bool Initialize()
        {
            SapLocation cameraLinkAcquisitionLocation = new SapLocation(CameraServerName, AcquisitionIndex);

            _acquisition = new SapAcquisition(cameraLinkAcquisitionLocation, GetCcfFile(CcfFile));
            _acquisition.EventType = SapAcquisition.AcqEventType.EndOfFrame;
            if (CcfFile == CameraType.LA_HM_16K07A_00_R)
                _acquisition.SetParameter(SapAcquisition.Prm.SYNC, SapAcquisition.Val.SYNC_COMP_SYNC, true);

            SapLocation deviceLocation = new SapLocation(CameraServerName, DeviceIndex);
            _acquisitionDevice = new SapAcqDevice(deviceLocation, false);

            _buffer = new SapBuffer(1, _acquisition, SapBuffer.MemoryType.ScatterGather);
            _buffer.Width = ImageWidth;
            _buffer.Height = ImageHeight;
            _buffer.PixelDepth = ImageChannel;
            _buffer.Format = SapFormat.Mono8;

            _transfer = new SapAcqToBuf(_acquisition, _buffer);
            _transfer.XferNotify += TransferNotify;

            LastImageData = new byte[ImageWidth * ImageHeight * ImageChannel];

            bool createSuccess = _acquisition.Create() && _acquisitionDevice.Create() && _buffer.Create() && _transfer.Create();
            return createSuccess;
        }

        private void TransferNotify(object sender, SapXferNotifyEventArgs e)       // TODO : 느리면 Unsafe 테스트
        {
            _buffer.GetAddress(out IntPtr rawImageAddress);
            Marshal.Copy(rawImageAddress, LastImageData, 0, LastImageData.Length);
        }

        private void UnsafeTransferNotify(object sender, SapXferNotifyEventArgs e)
        {
            unsafe
            {
                _buffer.GetAddress(out IntPtr rawImageAddress);
                byte* nativeAddress = (byte*)rawImageAddress.ToPointer();

                fixed (byte* imageDataPtr = LastImageData)
                {
                    for (int index = 0; index < LastImageData.Length; index++)
                        imageDataPtr[index] = nativeAddress[index];
                }
            }
        }

        public static string GetCcfFile(CameraType cameraType)
        {
            string filePath = "";

            if (cameraType == CameraType.LA_HM_16K07A_00_R ||
                cameraType == CameraType.AX_FM_08B12H_00)
                filePath = Path.Combine(Environment.CurrentDirectory, $"{cameraType}.ccf");

            if (File.Exists(filePath) == false)
                return "";

            return filePath;
        }


        public override int GetAnalogGain()
        {
            int featureValue = -1;
            string featureName = "TODO";

            if (_acquisitionDevice.IsFeatureAvailable(featureName))
                _acquisitionDevice.GetFeatureValue(featureName, out featureValue);
            else
                throw new Exception($"{featureName} is not exist.");
            return featureValue;
        }

        public override double GetDigitalGain()
        {
            double featureValue = -1;
            string featureName = "Gain";

            if (_acquisitionDevice.IsFeatureAvailable(featureName))
                _acquisitionDevice.GetFeatureValue(featureName, out featureValue);
            else
                throw new Exception($"{featureName} is not exist.");
            return featureValue;
        }

        public override double GetExposureTime()
        {
            double featureValue = -1;
            string featureName = "ExposureTime";

            if (_acquisitionDevice.IsFeatureAvailable(featureName))
                _acquisitionDevice.GetFeatureValue(featureName, out featureValue);
            else
                throw new Exception($"{featureName} is not exist.");
            return featureValue;
        }

        public override int GetImageWidth()
        {
            int featureValue = -1;
            string featureName = "Width";

            if (_acquisitionDevice.IsFeatureAvailable(featureName))
                _acquisitionDevice.GetFeatureValue(featureName, out featureValue);
            else
                throw new Exception($"{featureName} is not exist.");
            return featureValue;
        }

        public override int GetOffsetX()
        {
            int featureValue = -1;
            string featureName = "TODO";

            if (_acquisitionDevice.IsFeatureAvailable(featureName))
                _acquisitionDevice.GetFeatureValue(featureName, out featureValue);
            else
                throw new Exception($"{featureName} is not exist.");
            return featureValue;
        }

        public override byte[] GetGrabbedImage()
        {
            return LastImageData;
        }

        public override void GrabContinous()
        {
            if (_transfer.Grabbing == false)
                _transfer.Grab();
        }

        public override void GrabMulti(int grabCount)
        {
            Stop();
            _transfer.Snap(grabCount);
        }

        public override void GrabOnce()
        {
            Stop();
            _transfer.Snap();
        }

        public override bool IsGrabbing()
        {
            return _transfer.Grabbing;
        }

        public override void SetAnalogGain(int value)
        {
            string featureName = "TODO";

            if (_acquisitionDevice.IsFeatureAvailable(featureName))
                _acquisitionDevice.SetFeatureValue(featureName, value);
            else
                throw new Exception($"{featureName} is not exist.");
        }

        public override void SetDigitalGain(double value)
        {
            string featureName = "Gain";

            if (_acquisitionDevice.IsFeatureAvailable(featureName))
                _acquisitionDevice.SetFeatureValue(featureName, value);
            else
                throw new Exception($"{featureName} is not exist.");
        }

        public override void SetExposureTime(double value)
        {
            string featureName = "ExposureTime";

            if (_acquisitionDevice.IsFeatureAvailable(featureName))
                _acquisitionDevice.SetFeatureValue(featureName, value);
            else
                throw new Exception($"{featureName} is not exist.");
        }

        public override void SetImageWidth(int value)
        {
            string featureName = "Width";

            if (_acquisitionDevice.IsFeatureAvailable(featureName))
                _acquisitionDevice.SetFeatureValue(featureName, value);
            else
                throw new Exception($"{featureName} is not exist.");
        }

        public override void SetImageHeight(int value)
        {
            string featureName = "Height";

            if (_acquisitionDevice.IsFeatureAvailable(featureName))
                _acquisitionDevice.SetFeatureValue(featureName, value);
            else
                throw new Exception($"{featureName} is not exist.");
        }

        public override void SetOffsetX(int value)
        {
            string featureName = "TODO";

            if (_acquisitionDevice.IsFeatureAvailable(featureName))
                _acquisitionDevice.SetFeatureValue(featureName, value);
            else
                throw new Exception($"{featureName} is not exist.");
        }

        public override void SetReverseX(bool reverse)
        {
            string featureName = "ReverseX";
            if (_acquisitionDevice.IsFeatureAvailable(featureName))
                _acquisitionDevice.SetFeatureValue(featureName, reverse);
            else
                throw new Exception($"{featureName} is not exist.");
        }

        public override void Stop()
        {
            if (_transfer.Grabbing)
            {
                _transfer.Freeze();
                if (_transfer.Wait(Timeout) == false)
                    _transfer.Abort();
            }
        }
        #endregion
    }

    public partial class CameraDalsa : ICameraTriggerable
    {
        #region 속성
        public int TriggerChannel { get; set; } = 0;

        public TriggerMode TriggerMode { get; set; } = TriggerMode.Software;

        public int TriggerSource { get; set; } = 0;

        [JsonProperty]
        public DalsaTriggerSignalType TriggerSignalType { get; set; } = DalsaTriggerSignalType.None;

        [JsonProperty]
        public DalsaIoSourceType TriggerIoSourceType { get; set; } = DalsaIoSourceType.None;
        #endregion

        #region 메서드
        public void ActiveTriggerCommand()
        {
            if (TriggerMode == TriggerMode.Software)
                _acquisitionDevice.SetFeatureValue("TriggerMode", 0);
            else
            {
                _acquisitionDevice.SetFeatureValue("TriggerMode", 1);

                //DalsaTriggerSourceType source = (DalsaTriggerSourceType)TriggerSource;
                _acquisitionDevice.SetFeatureValue("TriggerSource", TriggerSource);
            }
        }

        public void SetTriggerMode(TriggerMode triggerMode)
        {
            TriggerMode = triggerMode;
            ActiveTriggerCommand();
        }

        private int GetTriggerSignalType(DalsaTriggerSignalType signalType)
        {
            int value = 0;
            switch (signalType)
            {
                case DalsaTriggerSignalType.None:
                    break;

                default:
                    break;
            }
            return value;
        }

        private int GetTriggerIoSource(DalsaIoSourceType sourceType)
        {
            int value = 0;
            switch (sourceType)
            {
                case DalsaIoSourceType.None:
                    break;

                default:
                    break;
            }
            return value;
        }
        #endregion
    }

    public partial class CameraDalsa : ICameraTDIavailable
    {
        #region 속성
        public TDIOperationMode TDIOperationMode { get; set; }

        public TDIDirectionType TDIDirection { get; set; }

        public int TDIStages { get; set; }
        #endregion

        #region 메서드
        public void SetTDIOperationMode(TDIOperationMode mode)
        {
            if (mode == TDIOperationMode.TDI)
                _acquisitionDevice.SetFeatureValue("DeviceScanType", "LineScan");
            else if (mode == TDIOperationMode.Area)
                _acquisitionDevice.SetFeatureValue("DeviceScanType", "AreaScan");
        }

        public void SetTDIScanDriection(TDIDirectionType direction)
        {
            if (direction == TDIDirectionType.Forward || direction == TDIDirectionType.Reverse)
                _acquisitionDevice.SetFeatureValue("sensorScanDirection", $"{direction}");
        }
        #endregion
    }

    public enum DalsaTriggerSignalType
    {
        // TODO : CamExpert에서 확인 후 필요 시 추가
        None,
    }

    public enum DalsaTriggerSourceType
    {
        // TODO : CamExpert에서 확인 후 필요 시 추가
        CC1,
    }

    public enum DalsaIoSourceType
    {
        // TODO : CamExpert에서 확인 후 필요 시 추가
        None,
    }
}
