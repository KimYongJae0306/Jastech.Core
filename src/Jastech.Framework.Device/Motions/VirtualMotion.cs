using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Device.Motions
{
    public class VirtualMotion : Motion
    {
        #region 생성자
        public VirtualMotion(string name, int axisNumber)
            : base(name, axisNumber)
        {

        }
        #endregion

        #region 메서드
        public override void AllServoOff()
        {

        }

        public override double GetActualPosition(int axisNo)
        {
            return 0.0;
        }

        public override string GetCurrentMotionStatus(int axisNo)
        {
            return "";
        }

        public override bool IsConnected()
        {
            return false;
        }

        public override bool IsNegativeLimit(int axisNo)
        {
            return false;
        }

        public override bool IsPositiveLimit(int axisNo)
        {
            return false;
        }

        public override void JogMove(int axisNo, MovingParam.Direction direction)
        {

        }

        public override void MoveTo(int axisNo, double targetPosition, double velocity, double accdec)
        {

        }

        public override void SetDefaultParameter(int axisNo, double velocity = 10, double accdec = 10)
        {

        }

        public override void StartHome(int axisNo)
        {

        }

        public override void StopMove(int axisNo)
        {

        }

        public override void TurnOnServo(int axisNo, bool bOnOff)
        {

        }

        public override bool WaitForDone(int axisNo)
        {
            return true;
        }
        #endregion
    }
}
