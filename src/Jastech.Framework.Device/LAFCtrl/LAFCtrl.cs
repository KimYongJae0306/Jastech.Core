using System;
using static Jastech.Framework.Device.Motions.AxisMovingParam;

namespace Jastech.Framework.Device.LAFCtrl
{
    public abstract partial class LAFCtrl : IDevice, IDisposable
    {
        #region 속성
        public LAFStatus Status { get; set; } = new LAFStatus();
        #endregion

        #region 이벤트
        public event LAFEventHandler DataReceived;
        #endregion

        #region 델리게이트
        public delegate void LAFEventHandler(string name, byte[] data);
        #endregion

        #region 생성자
        public LAFCtrl(string name)
        {
            Name = name;
        }
        #endregion

        #region 메서드
        public abstract void SetMotionRelativeMove(Direction direction, double value);

        public abstract void SetMotionAbsoluteMove(double value);

        public abstract void SetMotionNegativeLimit(double value);

        public abstract void SetMotionPositiveLimit(double value);

        public abstract void SetMotionMaxSpeed(double value);

        public abstract void SetDefaultParameter();

        public abstract void SetMotionZeroSet();

        public abstract void SetMotionStop();

        public abstract void SetCenterOfGravity(int value);

        public abstract void SetTrackingOnOFF(bool isOn);

        public abstract void SetLaserOnOff(bool isOn);

        public abstract void SetMotionEnable(bool isOn);

        protected void OnLAFReceived(byte[] data)
        {
            DataReceived?.Invoke(Name, data);
        }
        #endregion
    }

    public abstract partial class LAFCtrl : IDevice
    {
        #region 속성
        public string Name { get; protected set; }
        #endregion

        #region 메서드
        public virtual bool Initialize()
        {
            return true;
        }

        public virtual bool IsConnected()
        {
            return true;
        }

        public virtual bool Release()
        {
            return true;
        }
        #endregion
    }
    public abstract partial class LAFCtrl : IDisposable
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

    public class LAFStatus
    {
        #region 필드
        private object _lock { get; set; } = new object();
        #endregion

        #region 속성
        public bool IsLaserOn { get; set; }

        public bool IsTrackingOn { get; set; }

        public string Name { get; set; }

        public int CenterofGravity { get; set; }

        public double MPosPulse { get; set; }

        public bool IsNegativeLimit { get; set; }

        public bool IsPositiveLimit { get; set; }
        #endregion
    }
}
