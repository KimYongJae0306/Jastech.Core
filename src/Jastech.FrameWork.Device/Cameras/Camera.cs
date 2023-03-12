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
        public string Name { get; private set; }

        [JsonProperty]
        public int ImageWidth { get; protected set; }

        [JsonProperty]
        public int ImageHeight { get; protected set; }

        [JsonProperty]
        public ColorFormat ColorFormat { get; protected set; }

        [JsonProperty]
        public SensorType SensorType { get; protected set; }
        #endregion

        #region 이벤트

        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        public Camera(string name, int imageWidth, int imageHeight, ColorFormat colorFormat, SensorType sensorType)
        {
            Name = name;
            ImageWidth = imageWidth;
            ImageHeight = imageHeight;
            ColorFormat = colorFormat;
            SensorType = sensorType;
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
}
