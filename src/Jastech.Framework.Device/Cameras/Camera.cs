using Jastech.Framework.Imaging;
using Newtonsoft.Json;
using System;
using System.Threading;

namespace Jastech.Framework.Device.Cameras
{
    public abstract partial class Camera : IDevice
    {
        #region 속성
        [JsonProperty]
        public int ImageWidth { get; protected set; }

        [JsonProperty]
        public int ImageHeight { get; protected set; }

        [JsonProperty]
        public int OffsetX { get; set; }

        public int ImageChannel { get => ColorFormat == ColorFormat.RGB24 ? 3 : 1; }

        [JsonProperty]
        public ColorFormat ColorFormat { get; protected set; }

        [JsonProperty]
        public SensorType SensorType { get; protected set; }

        [JsonProperty]
        public float PixelResolution_um { get; set; } = 0.35F;

        [JsonProperty]
        public float LensScale { get; set; } = 10F;

        [JsonIgnore]
        public int GrabCount { get; set; } = 0;

        [JsonProperty]
        public bool IsReverseX { get; set; } = false;

        [JsonProperty]
        public double Exposure { get; set; } = 5000;

        [JsonProperty]
        public int AnalogGain { get; set; } = 1;

        [JsonProperty]
        public int OnceGrabResponseTimeMs { get; set; } = 1000;

        protected ManualResetEvent OnceGrabEvent { get; set; } = new ManualResetEvent(false);
        #endregion

        #region 이벤트
        public event CameraEventDelegate ImageGrabbed;
        #endregion

        #region 델리게이트
        public delegate void CameraEventDelegate(Camera camera);
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
        public abstract void SetExposureTime(double value);

        public abstract double GetExposureTime();

        public abstract void ReverseX(bool reverse);

        public abstract void SetAnalogGain(int value);

        public abstract int GetAnalogGain();

        public abstract void SetDigitalGain(double value);

        public abstract double GetDigitalGain();

        public abstract void SetOffsetX(int value);

        public abstract int GetOffsetX();

        public abstract void SetImageWidth(int value);

        public abstract int GetImageWidth();

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

    public abstract partial class Camera : IDisposable
    {
        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 관리형 상태(관리형 개체)를 삭제합니다.
                }

                // TODO: 비관리형 리소스(비관리형 개체)를 해제하고 종료자를 재정의합니다.
                // TODO: 큰 필드를 null로 설정합니다.
                disposedValue = true;
            }
        }

        // // TODO: 비관리형 리소스를 해제하는 코드가 'Dispose(bool disposing)'에 포함된 경우에만 종료자를 재정의합니다.
        // ~Camera()
        // {
        //     // 이 코드를 변경하지 마세요. 'Dispose(bool disposing)' 메서드에 정리 코드를 입력합니다.
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // 이 코드를 변경하지 마세요. 'Dispose(bool disposing)' 메서드에 정리 코드를 입력합니다.
            Dispose(disposing: true);
            //GC.SuppressFinalize(this);
        }
    }
    public enum SensorType
    {
        Area,
        Line
    }

    public enum CameraType
    {
        VT_4K5X_H200,
        VT_6K3_5X_H160,
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
