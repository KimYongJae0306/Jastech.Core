using Jastech.FrameWork.Comm.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Jastech.FrameWork.Device.Motions.MovingParam;

namespace Jastech.FrameWork.Device.Motions
{
    public abstract class Motion
    {
        #region 메서드
        public abstract MotionErrorStatus Initialize(IProtocol protocolType);

        public abstract void Release();

        public abstract bool IsConnected();

        public abstract void ServoOn(AxisType axis);

        public abstract void ServoOff(AxisType axis);

        public abstract void AllServoOff();

        public abstract void StopMove(AxisType axis);

        public abstract void JogMove(AxisType axis, Direction direction);

        public abstract double GetActualPosition(AxisType axis);

        public abstract void MoveTo(AxisType axis, double targetPosition, double velocity, double accdec);

        public abstract void SetDefaultParameter(AxisType axis, double velocity = 10, double accdec = 10);

        public abstract bool WaitForDone(AxisType axis);

        public abstract void StartHome(AxisType axis);

        public abstract string GetCurrentMotionStatus(AxisType axis);

        public abstract bool IsNegativeLimit(AxisType axis);

        public abstract bool IsPositiveLimit(AxisType axis);
        #endregion
    }
}

