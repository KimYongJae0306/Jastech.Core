using ACS.SPiiPlusNET;
using Jastech.Framework.Comm.Protocol;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Jastech.Framework.Device.Motions.MovingParam;

namespace Jastech.Framework.Device.Motions
{
    public partial class ACSMotion : Motion
    {

        #region 필드
        private const int _bufferCount = 8;

        private Api _motion { get; set; } = null;

        private Thread _repeatThread { get; set; } = null;
        #endregion

        #region 속성
        public IProtocol Protocol { get; set; } = null;
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        public ACSMotion(string name, int axisNumber)
            : base(name, axisNumber)
        {

        }
        #endregion

        #region 메서드
        #endregion

        private bool OpenSerialPort()
        {
            var portInfo = (Protocol as ACSSerialProtocol).PortInfo;

            _motion.OpenCommSerial(portInfo.PortNo, portInfo.BaudRate);

            return true;
        }

        private bool ConectEthernet()
        {
            var info = (Protocol as ACSTcpIpProtocol).TcpInfo;

            _motion.OpenCommEthernet(info.IpAddress, (int)EthernetCommOption.ACSC_SOCKET_STREAM_PORT);

            return true;
        }

        private void CreateObject()
        {
            _motion = new Api();

            foreach (var info in _motion.GetConnectionsList())
            {
                // Except ACS Framework 
                if (!info.Application.Contains("ACS"))
                    _motion.TerminateConnection(info);
            }
        }

        public override bool Initialize()
        {
            base.Initialize();

            if (_motion != null && _motion.IsConnected)
                return false;

            CreateObject();

            if (Protocol is ACSSerialProtocol)
            {
                if (OpenSerialPort())
                    return true;
            }
            else if (Protocol is ACSTcpIpProtocol)
            {
                if (ConectEthernet())
                    return true;
            }
            return false;
        }

        public override bool Release()
        {
            base.Release();

            if (_motion.IsConnected)
                _motion.KillAll();

            _motion?.CloseComm();

            return true;
        }

        public override bool IsConnected()
        {
            if (_motion == null)
                return false;

            return _motion.IsConnected;
        }

        public override void TurnOnServo(int axisNo, bool bOnOff)
        {
            if(bOnOff)
                _motion.Enable((Axis)axisNo);
            else
                _motion.Disable((Axis)axisNo);
        }

        public override void AllServoOff()
        {
            _motion.DisableAll();
        }

        public override void StopMove(int axisNo)
        {
            _motion.Kill((Axis)axisNo);
        }

        public override void JogMove(int axisNo, Direction direction)
        {
            _motion.Jog(MotionFlags.ACSC_NONE, (Axis)axisNo, (double)direction);
        }

        public override double GetActualPosition(int axisNo)
        {
            return _motion.GetFPosition((Axis)axisNo);
        }

        public override void MoveTo(int axisNo, double targetPosition, double velocity, double accdec)
        {
            SetBasicParameter((Axis)axisNo, velocity, accdec);

            if (ReadyToMove((Axis)axisNo, targetPosition))
                _motion.ToPointAsync(MotionFlags.ACSC_NONE, (Axis)axisNo, targetPosition);
        }

        public override void SetDefaultParameter(int axisNo, double velocity = 10, double accdec = 10)
        {
            SetBasicParameter((Axis)axisNo, velocity, accdec);
        }

        public override bool WaitForDone(int axisNo)
        {
            if (WaitForDone(axisNo))
                return true;
            else
                return false;
        }

        public override void StartHome(int axisNo)
        {
            Home(axisNo);
        }

        public override string GetCurrentMotionStatus(int axisNo)
        {
            if (!_motion.IsConnected)
                return null;

            //모터 상태 읽음
            var state = _motion.GetMotorState((Axis)axisNo);
            string strMotorStates = "";

            //사용가능 상태인지, 멈춘 상태인지, 이동중이 아닌지 확인
            if (Convert.ToBoolean(state & MotorStates.ACSC_MST_MOVE))
                strMotorStates = "MOVING";
            else if (!Convert.ToBoolean(state & MotorStates.ACSC_MST_INPOS))
                strMotorStates = "STOP";
            else if (!Convert.ToBoolean(state & MotorStates.ACSC_MST_ENABLE))
                strMotorStates = "NOT ENABLE";
            else
                strMotorStates = "NORMAL";

            return strMotorStates;
        }

        public override bool IsNegativeLimit(int axisNo)
        {
            if (!_motion.IsConnected)
                return false;

            var saftyFlag = _motion.GetFault((Axis)axisNo);
            if (saftyFlag == SafetyControlMasks.ACSC_SAFETY_LL)
                return true;

            return false;
        }

        public override bool IsPositiveLimit(int axisNo)
        {
            if (!_motion.IsConnected)
                return false;

            var saftyFlag = _motion.GetFault((Axis)axisNo);
            if (saftyFlag == SafetyControlMasks.ACSC_SAFETY_RL)
                return true;

            return false;
        }
    }

    public partial class ACSMotion
    {
        private void SetBasicParameter(Axis axis, double velocity, double accdec)
        {
            // Acceleration & Deceleration : 90%, Jerk : 10%
            // Convert Acc & Dec to rate
            double jogAcceleration = Math.Abs(velocity / ((accdec * 0.9) / 1000.0));

            // Convert Jerk time to rate
            double jogJerk = Math.Abs(jogAcceleration / ((accdec * 0.1) / 1000.0));

            _motion.SetVelocity(axis, velocity);
            _motion.SetAcceleration(axis, jogAcceleration);
            _motion.SetDeceleration(axis, jogAcceleration);
            _motion.SetKillDeceleration(axis, jogAcceleration * 2);
            _motion.SetJerk(axis, jogJerk);
        }

        private bool ReadyToMove(Axis axis, double targetPosition)
        {
            // Release axis event
            _motion.FaultClear(axis);

            Thread.Sleep(100);

            // Read motor status
            var state = _motion.GetMotorState(axis);

            // Check enable to move
            if (Convert.ToBoolean(state & MotorStates.ACSC_MST_MOVE) || !Convert.ToBoolean(state & MotorStates.ACSC_MST_INPOS) || !Convert.ToBoolean(state & MotorStates.ACSC_MST_ENABLE))
                return false;

            // Check motor's error status
            var error = _motion.GetMotorError(axis);
            if (error != (int)MotorStates.ACSC_NONE)
            {
                Console.WriteLine("Motor error has occurred.");
                return false;
            }

            // Check sw limit
            //if (targetPosition < _propertyList[(int)axis].NegativeSWLimit)
            //{
            //    Console.WriteLine("The point to move out of software limit setting. [NAGATIVE_LIMIT]");
            //    return false;
            //}

            //if (targetPosition > _propertyList[(int)axis].PositiveSWLimit)
            //{
            //    Console.WriteLine("The point to move out of software limit setting. [POSITIVE_LIMIT]");
            //    return false;
            //}

            return true;
        }

        private bool WaitForDone(Axis axis, int timeOut = 10)
        {
            Stopwatch timeoutChecker = new Stopwatch();

            if (!_motion.IsConnected)
                return false;

            timeoutChecker.Start();
            while (!IsAxisDone(axis))
            {
                //축 상태 확인
                //if (false == CheckAxisState(_axis))
                //{
                //    //TODO LOG
                //    return ACS_MOTION_RESULT.ERR_AXIS_ALREADY_USED_AXIS_ID;
                //}

                //Amp Fault 확인
                var safetyFlag = _motion.GetFault(axis);
                if (safetyFlag != SafetyControlMasks.ACSC_NONE)
                {
                    //Amp Fault 발생
                    //####ESTOP!!####
                    _motion.KillAll();
                    _motion.Disable(axis);

                    Console.WriteLine("Fault occurs in axis Amp.");

                    return false;
                }

                // Check timeout
                if (timeoutChecker.ElapsedMilliseconds / 1000 >= timeOut)
                {
                    Console.WriteLine("Axis movement has exceeded the set time.");
                    return false;
                }

                Thread.Sleep(1);
            }
            timeoutChecker.Reset();

            Console.WriteLine("Axis movement has arrived at its destination.");

            return true;
        }

        private bool IsAxisDone(Axis axis)
        {
            var state = _motion.GetMotorState(axis);
            var position = _motion.GetFPosition(axis);

            if (!Convert.ToBoolean(state & MotorStates.ACSC_MST_MOVE) && Convert.ToBoolean(state & MotorStates.ACSC_MST_INPOS))
                return true;
            else
                return false;
        }

        private void Home(int axisNo)
        {
            if (!_motion.IsConnected)
                return;

            Axis axis = (Axis)axisNo;
            _motion.RunBuffer((ProgramBuffer)axis, null);
        }
    }
}
