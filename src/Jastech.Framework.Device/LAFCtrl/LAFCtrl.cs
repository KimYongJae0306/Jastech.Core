using Jastech.Framework.Comm.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Jastech.Framework.Device.Motions.AxisMovingParam;

namespace Jastech.Framework.Device.LAFCtrl
{
    public abstract partial class LAFCtrl : IDevice
    {
        public bool IsLaserOn { get; protected set; }

        public LAFStatus Status { get; set; } = new LAFStatus();

        public LAFCtrl(string name)
        {
            Name = name;
        }

        public delegate void LAFEventHandler(string name, byte[] data);

        public event LAFEventHandler DataReceived;

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
        private object _lock { get; set; } = new object();

        public string Name { get; set; }

        public int CenterofGravity { get; set; }

        public double MPos { get; set; }

        public bool IsNegativeLimit { get; set; }

        public bool IsPositiveLimit { get; set; }

        public void SetStatus(int centerOfCravity, double mPos, bool isNegativeLimit, bool isPositiveLimit)
        {
            lock (_lock)
            {
                CenterofGravity = centerOfCravity;
                MPos = mPos;
                IsNegativeLimit = isNegativeLimit;
                IsPositiveLimit = isPositiveLimit;
            }
        }

        public LAFStatus GetStatus()
        {
            lock (_lock)
                return this;
        }
    }
}
