using Newtonsoft.Json;
using System;
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

    public abstract partial class Motion : IDisposable
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
}

