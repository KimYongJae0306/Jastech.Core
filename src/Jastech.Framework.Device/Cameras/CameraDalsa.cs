using Jastech.Framework.Imaging;
using Matrox.MatroxImagingLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Device.Cameras
{
    public partial class CameraDalsa : Camera, ICameraTriggerable
    {
        #region 생성자
        public CameraDalsa(string name, int imageWidth, int imageHeight, ColorFormat colorFormat, SensorType sensorType) 
            : base(name, imageWidth, imageHeight, colorFormat, sensorType)
        {
        }
        #endregion

        #region 메서드
        public override int GetAnalogGain()
        {
            throw new NotImplementedException();
        }

        public override double GetDigitalGain()
        {
            throw new NotImplementedException();
        }

        public override double GetExposureTime()
        {
            throw new NotImplementedException();
        }

        public override byte[] GetGrabbedImage()
        {
            throw new NotImplementedException();
        }

        public override int GetImageWidth()
        {
            throw new NotImplementedException();
        }

        public override int GetOffsetX()
        {
            throw new NotImplementedException();
        }

        public override void GrabContinous()
        {
            throw new NotImplementedException();
        }

        public override void GrabMulti(int grabCount)
        {
            throw new NotImplementedException();
        }

        public override void GrabOnce()
        {
            throw new NotImplementedException();
        }

        public override bool IsGrabbing()
        {
            throw new NotImplementedException();
        }

        public override void SetAnalogGain(int value)
        {
            throw new NotImplementedException();
        }

        public override void SetDigitalGain(double value)
        {
            throw new NotImplementedException();
        }

        public override void SetExposureTime(double value)
        {
            throw new NotImplementedException();
        }

        public override void SetImageHeight(int value)
        {
            throw new NotImplementedException();
        }

        public override void SetImageWidth(int value)
        {
            throw new NotImplementedException();
        }

        public override void SetOffsetX(int value)
        {
            throw new NotImplementedException();
        }

        public override void SetReverseX(bool reverse)
        {
            throw new NotImplementedException();
        }

        public override void Stop()
        {
            throw new NotImplementedException();
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

    public enum DalsaTriggerSignalType
    {
        None,
    }

    public enum DalsaIoSourceType
    {
        None,
    }
}
