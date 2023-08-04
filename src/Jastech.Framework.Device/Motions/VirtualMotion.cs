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
            return "Done";
        }

        public override bool IsEnable(int axisNo)
        {
            return false;
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

        public override void JogMove(int axisNo, AxisMovingParam.Direction direction)
        {

        }

        public override void StartAbsoluteMove(int axisNo, double targetPosition, double velocity, double accdec)
        {

        }

        public override void StartRelativeMove(int axisNo, double amount, double velocity, double accdec)
        {

        }

        public override void SetDefaultParameter(int axisNo, double velocity = 10, double accdec = 10)
        {

        }

        public override bool StartHome(int axisNo)
        {
            return true;
        }

        public override void StopMove(int axisNo)
        {

        }

        public override bool IsMoving(int axisNo)
        {
            return false;
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
