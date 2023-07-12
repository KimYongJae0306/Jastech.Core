using Newtonsoft.Json;
using static Jastech.Framework.Device.Motions.AxisMovingParam;

namespace Jastech.Framework.Device.Motions
{
    public abstract partial class Motion : IDevice
    {
        #region 생성자
        public Motion(string name, int axisNumber)
        {
            Name = name;
            AxisNumber = axisNumber;
        }
        #endregion

        #region 속성
        [JsonProperty]
        public int AxisNumber { get; }
        #endregion

        #region 메서드
        public abstract bool IsConnected();

        public abstract void TurnOnServo(int axisNo, bool bOnOff);

        public abstract void AllServoOff();

        public abstract void StopMove(int axisNo);

        public abstract void JogMove(int axisNo, Direction direction);

        public abstract double GetActualPosition(int axisNo);

        public abstract void StartAbsoluteMove(int axisNo, double targetPosition, double velocity, double accdec);

        public abstract void StartRelativeMove(int axisNo, double amount,  double velocity, double accdec);

        public abstract void SetDefaultParameter(int axisNo, double velocity = 10, double accdec = 10);

        public abstract bool WaitForDone(int axisNo);

        public abstract bool StartHome(int axisNo);

        public abstract string GetCurrentMotionStatus(int axisNo);

        public abstract bool IsEnable(int axisNo);

        public abstract bool IsNegativeLimit(int axisNo);

        public abstract bool IsPositiveLimit(int axisNo);
        #endregion
    }

    public abstract partial class Motion : IDevice
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
            return true;
        }
        #endregion
    }
}

