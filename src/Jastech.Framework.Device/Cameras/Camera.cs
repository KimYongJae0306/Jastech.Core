﻿using Jastech.Framework.Imaging;
using Newtonsoft.Json;
using System;

namespace Jastech.Framework.Device.Cameras
{
    public abstract partial class Camera : IDevice
    {
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

        #region 속성
        [JsonProperty]
        public int ImageWidth { get; protected set; }

        [JsonProperty]
        public int ImageHeight { get; protected set; }

        public int ImageChannel { get => ColorFormat == ColorFormat.RGB24 ? 3 : 1; }

        [JsonProperty]
        public ColorFormat ColorFormat { get; protected set; }

        [JsonProperty]
        public SensorType SensorType { get; protected set; }

        [JsonProperty]
        public double PixelResolution_um { get; set; } = 1;

        [JsonProperty]
        public double LensScale { get; set; } = 1;

        [JsonIgnore]
        public int GrabCount { get; set; } = 0;
        #endregion

        #region 이벤트
        public event CameraEventDelegate ImageGrabbed;
        #endregion

        #region 델리게이트
        public delegate void CameraEventDelegate(Camera camera);
        #endregion

        #region 메서드
        public abstract void SetExposureTime(double value);

        public abstract double GetExposureTime();

        public abstract void ReverseX(bool reverse);

        public abstract void SetAnalogGain(int value);

        public abstract int GetAnalogGain();

        public abstract void SetDigitalGain(double value);

        public abstract double GetDigitalGain();

        public abstract void SetOffsetX(int value);

        public abstract void SetImageWidth(int value);

        public abstract void SetImageHeight(int value);

        public abstract byte[] GetGrabbedImage();

        public abstract void GrabOnce();

        public abstract void GrabMulti(int grabCount);

        public abstract void GrabContinous();

        public abstract void Stop();

        public abstract bool IsGrabbing();

        protected void ImageGrabbedCallback()
        {
            if (ImageGrabbed != null)
            {
                ImageGrabbed.Invoke(this);
            }
        }

        public void GrabMuti(object grabCount)
        {
            throw new NotImplementedException();
        }
        #endregion

    }

    public abstract partial class Camera : IDevice
    {
        #region 속성
        public string Name { get; protected set; }
        #endregion

        #region 메서드
        public virtual bool Initialize()
        {
            return true;
        }

        public virtual bool Release()
        {
            Stop();
            return true;
        }
        #endregion
    }

    public enum SensorType
    {
        Area,
        Line
    }

    public enum CameraType
    {
        VT_6k35c_trigger,
    }

    public enum TriggerMode
    {
        Software,
        Hardware,
    }

    public enum MilCxpTriggerSource
    {
        Lin0 = 0,
        Cxp = 1,
    }

    public enum OperationMode
    {
        Area,
        TDI,
    }
}
