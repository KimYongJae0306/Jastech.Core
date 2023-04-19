using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Jastech.Framework.Device.Motions.AxisMovingParam;

namespace Jastech.Framework.Device.Motions
{
    public class Axis
    {
        #region 속성
        [JsonProperty]
        public string Name { get; private set; }

        public Motion Motion { get; private set; }

        [JsonProperty]
        public int AxisNo { get; private set; }

        [JsonProperty]
        public AxisCommonParams AxisCommonParams { get; set; } = new AxisCommonParams();

        [JsonProperty]
        public int HomeOrder { get; set; } = -1;
        #endregion

        #region 생성자 
        public Axis(string name, Motion motion, int axisNo)
        {
            Name = name;
            Motion = motion;
            AxisNo = axisNo;
        }
        #endregion

        #region 메서드
        public void SetMotion(Motion motion)
        {
            Motion = motion;    
        }

        public bool StartMove(float position, AxisMovingParam movingParam = null)
        {
            Motion.MoveTo(AxisNo, position, movingParam.Velocity, movingParam.Acceleration);

            return true;
        }

        public void StopMove()
        {
            Motion.StopMove(AxisNo);
        }

        public bool IsConnected()
        {
            return Motion.IsConnected();
        }

        public void TurnOnServo()
        {
            Motion.TurnOnServo(AxisNo, true);
        }

        public void TurnOffServo()
        {
            Motion.TurnOnServo(AxisNo, false);
        }

        public void JogMove(Direction direction)
        {
            Motion.JogMove(AxisNo, direction);
        }

        public double GetActualPosition()
        {
            return Motion.GetActualPosition(AxisNo);
        }

        public void MoveTo(double targetPosition, AxisMovingParam movingParam = null)
        {
            if(movingParam == null)
                Motion.MoveTo(AxisNo, targetPosition, 10, 10);
            else
                Motion.MoveTo(AxisNo, targetPosition, movingParam.Velocity, movingParam.Acceleration);
        }

        public void SetDefaultParameter(double velocity = 10, double accdec = 10)
        {
            Motion.SetDefaultParameter(AxisNo, velocity, accdec);
        }

        public bool WaitForDone()
        {
            return Motion.WaitForDone(AxisNo);
        }

        public void StartHome()
        {
            Motion.StartHome(AxisNo);
        }

        public string GetCurrentMotionStatus()
        {
            return Motion.GetCurrentMotionStatus(AxisNo);
        }

        public bool IsEnable()
        {
            return Motion.IsEnable(AxisNo);
        }

        public bool IsNegativeLimit()
        {
            return Motion.IsNegativeLimit(AxisNo);
        }

        public bool IsPositiveLimit()
        {
            return Motion.IsPositiveLimit(AxisNo);
        }
        #endregion
    }

    public enum AxisName
    {
        X,
        Y,
        Z,
        T,
    }
}
