using Jastech.Framework.Imaging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Device.Cameras
{
    public partial class CameraVirtual : Camera , ICameraTDIavailable, ICameraTriggerable, ICameraPRNUavailable
    {
        #region 생성자
        public CameraVirtual(string name, int imageWidth, int imageHeight, ColorFormat colorFormat, SensorType sensorType)
           : base(name, imageWidth, imageHeight, colorFormat, sensorType)
        {
        }
        #endregion

        #region 메서드
        public override double GetExposureTime()
        {
            return 0.0;
        }

        public override byte[] GetGrabbedImage()
        {
            return null;
        }

        public override void GrabMulti(int grabCount)
        {

        }

        public override void GrabOnce()
        {

        }

        public override void GrabContinous()
        {
            
        }

        public override void ReverseX(bool reverse)
        {

        }

        public override void SetAnalogGain(int value)
        {

        }

        public override void SetDigitalGain(double value)
        {

        }

        public override void SetExposureTime(double value)
        {

        }

        public override void SetImageWidth(int value)
        {

        }

        public override void SetOffsetX(int value)
        {

        }

        public override void Stop()
        {

        }

        public override bool IsGrabbing()
        {
            return false;
        }
        #endregion
    }

    public partial class CameraVirtual : ICameraTDIavailable
    {
        #region 속성
        public TDIOperationMode TDIOperationMode { get; private set; }

        public TDIDirectionType TDIDirection { get; private set; }

        public int TDIStages { get; set; }
        #endregion

        #region 메서드
        public void SetTDIOperationMode(TDIOperationMode mode)
        {
            TDIOperationMode = mode;
        }

        public void SetTDIScanDriection(TDIDirectionType direction)
        {
            TDIDirection = direction;
        }
        #endregion
    }

    public partial class CameraVirtual : ICameraTriggerable
    {
        #region 속성
        public int TriggerChannel { get; set; }

        public TriggerMode TriggerMode { get; set; }

        public int TriggerSource { get; set; }
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
        #endregion
    }

    public partial class CameraVirtual : ICameraPRNUavailable
    {
        #region 메서드
        public void SetStrobeMode(StrobeMode mode)
        {
        }

        public void SetStrobeDuration(int us)
        {
        }

        public void SetStrobeCurrent(int channel, int value)
        {
        }

        public void SetStrobeBrightness(int channel, int value)
        {
        }

        public void SetOutputFrequency(int value)
        {
        }

        public void SetFFCEnable(int value)
        {
        }

        public void SetFFCCalibration(int value)
        {
        }

        public void SetPRNUCalibration(int value)
        {
        }
        #endregion
    }
}
