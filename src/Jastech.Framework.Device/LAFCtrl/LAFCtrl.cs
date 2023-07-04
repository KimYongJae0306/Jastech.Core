using static Jastech.Framework.Device.Motions.AxisMovingParam;

namespace Jastech.Framework.Device.LAFCtrl
{
    public abstract partial class LAFCtrl : IDevice
    {
        #region 속성
        public bool IsLaserOn { get; protected set; }

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

        public abstract void SetMotionZeroSet();

        public abstract void SetMotionStop();

        public abstract void SetCenterOfGravity(int value);

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


    public class LAFStatus
    {
        #region 필드
        private object _lock { get; set; } = new object();
        #endregion

        #region 속성
        public bool IsLaserOn { get; set; }

        public bool IsAutoFocusOn { get; set; }

        public string Name { get; set; }

        public int CenterofGravity { get; set; }

        public double MPosPulse { get; set; }

        public bool IsNegativeLimit { get; set; }

        public bool IsPositiveLimit { get; set; }
        #endregion
    }
}
