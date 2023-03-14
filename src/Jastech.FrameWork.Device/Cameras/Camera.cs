using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.FrameWork.Device.Cameras
{
    public  abstract class Camera
    {
        #region 속성
        [JsonProperty]
        public CameraInfo CameraInfo { get; set; }
        #endregion

        #region 이벤트
        public event CameraEventDelegate ImageGrabbed;
        #endregion

        #region 델리게이트
        public delegate void CameraEventDelegate(Camera camera);
        #endregion

        #region 생성자
        public Camera(CameraInfo cameraInfo)
        {
            CameraInfo = cameraInfo;
        }
        #endregion

        #region 메서드
        public abstract bool Initialize();

        public abstract void Release();

        public abstract void SetExposureTime(double value);

        public abstract double GetExposureTime();

        public abstract void ReverseX(bool reverse);

        public abstract void SetAnalogGain(int value);

        public abstract void SetDigitalGain(double value);

        public abstract void SetOffsetX(int value);

        public abstract void SetImageWidth(int value);

        public abstract byte[] GetGrabbedImage();

        public abstract void GrabOnce();

        public abstract void GrabMuti(int grabCount);

        public abstract void Stop();

        protected void ImageGrabbedCallback()
        {
            if (ImageGrabbed != null)
            {
                ImageGrabbed.Invoke(this);
            }
        }
        #endregion
    }

    public enum SensorType
    {
        Area, Line
    }

    public enum ColorFormat
    {
        Gray,
        RGB24
    }

    public enum CameraType
    {
        VT_6k35c_trigger,
    }

    public enum TriggerMode
    {
        Software,
        Hardware,
        Off
    }
}
