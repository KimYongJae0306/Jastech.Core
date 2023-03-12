using ACS.SPiiPlusNET;
using Jastech.FrameWork.Comm.Protocol;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Jastech.FrameWork.Device.Motions.MovingParam;

namespace Jastech.FrameWork.Device.Motions
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

        public override MotionErrorStatus Initialize(IProtocol protocolType)
        {
            if(_motion != null && _motion.IsConnected)
                return MotionErrorStatus.Already_Connected;

            CreateObject();

            if (protocolType is ACSSerialProtocol)
            {
                if (OpenSerialPort())
                    return MotionErrorStatus.Initialize_Succssed;
            }
            else if (protocolType is ACSTcpIpProtocol)
            {
                if (ConectEthernet())
                    return MotionErrorStatus.Initialize_Succssed;
            }
            return MotionErrorStatus.Initialize_Fail;
        }

        public override void Release()
        {
            if (_motion.IsConnected)
                _motion.KillAll();

            _motion?.CloseComm();
        }

        public override bool IsConnected()
        {
            if (_motion == null)
                return false;

            return _motion.IsConnected;
        }

        public override void ServoOn(AxisType axis)
        {
            _motion.Enable(SetBufferNumberFromAxis(axis));
        }

        public override void ServoOff(AxisType axis)
        {
            _motion.Disable(SetBufferNumberFromAxis(axis));
        }

        public override void AllServoOff()
        {
            _motion.DisableAll();
        }

        public override void StopMove(AxisType axis)
        {
            _motion.Kill(SetBufferNumberFromAxis(axis));
        }

        public override void JogMove(AxisType axis, Direction direction)
        {
            _motion.Jog(MotionFlags.ACSC_NONE, SetBufferNumberFromAxis(axis), (double)direction);
        }

        public override double GetActualPosition(AxisType axis)
        {
            return _motion.GetFPosition(SetBufferNumberFromAxis(axis));
        }

        public override void MoveTo(AxisType axis, double targetPosition, double velocity, double accdec)
        {
            SetBasicParameter(axis, velocity, accdec);

            if (ReadyToMove(axis, targetPosition))
                _motion.ToPointAsync(MotionFlags.ACSC_NONE, SetBufferNumberFromAxis(axis), targetPosition);
        }

        public override void SetDefaultParameter(AxisType axis, double velocity = 10, double accdec = 10)
        {
            SetBasicParameter(axis, velocity, accdec);
        }

        public override bool WaitForDone(AxisType axis)
        {
            if (WaitForDone(axis))
                return true;
            else
                return false;
        }

        public override void StartHome(AxisType axis)
        {
            Home(axis);
        }

        public override string GetCurrentMotionStatus(AxisType axis)
        {
            if (!_motion.IsConnected)
                return null;

            //모터 상태 읽음
            var state = _motion.GetMotorState(SetBufferNumberFromAxis(axis));
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

        public override bool IsNegativeLimit(MovingParam.AxisType axis)
        {
            if (!_motion.IsConnected)
                return false;

            var saftyFlag = _motion.GetFault(SetBufferNumberFromAxis(axis));
            if (saftyFlag == SafetyControlMasks.ACSC_SAFETY_LL)
                return true;

            return false;
        }

        public override bool IsPositiveLimit(MovingParam.AxisType axis)
        {
            if (!_motion.IsConnected)
                return false;

            var saftyFlag = _motion.GetFault(SetBufferNumberFromAxis(axis));
            if (saftyFlag == SafetyControlMasks.ACSC_SAFETY_RL)
                return true;

            return false;
        }
    }

    public partial class ACSMotion
    {
        private Axis SetBufferNumberFromAxis(AxisType axis)
        {
            Axis convertAxis = Axis.ACSC_AXIS_0;

            switch (axis)
            {
                case AxisType.None:
                    break;

                case AxisType.X:
                    convertAxis = Axis.ACSC_AXIS_0;
                    break;

                case AxisType.Y:
                    convertAxis = Axis.ACSC_AXIS_8;
                    break;

                case AxisType.Z:
                    break;

                default:
                    break;
            }

            return convertAxis;
        }

        private void SetBasicParameter(AxisType axis, double velocity, double accdec)
        {
            // Acceleration & Deceleration : 90%, Jerk : 10%
            // Convert Acc & Dec to rate
            Axis acsAxis = SetBufferNumberFromAxis(axis);
            double jogAcceleration = Math.Abs(velocity / ((accdec * 0.9) / 1000.0));

            // Convert Jerk time to rate
            double jogJerk = Math.Abs(jogAcceleration / ((accdec * 0.1) / 1000.0));

            _motion.SetVelocity(acsAxis, velocity);
            _motion.SetAcceleration(acsAxis, jogAcceleration);
            _motion.SetDeceleration(acsAxis, jogAcceleration);
            _motion.SetKillDeceleration(acsAxis, jogAcceleration * 2);
            _motion.SetJerk(acsAxis, jogJerk);
        }

        private bool ReadyToMove(AxisType axis, double targetPosition)
        {
            // Release axis event
            _motion.FaultClear(SetBufferNumberFromAxis(axis));

            Thread.Sleep(100);

            // Read motor status
            var state = _motion.GetMotorState(SetBufferNumberFromAxis(axis));

            // Check enable to move
            if (Convert.ToBoolean(state & MotorStates.ACSC_MST_MOVE) || !Convert.ToBoolean(state & MotorStates.ACSC_MST_INPOS) || !Convert.ToBoolean(state & MotorStates.ACSC_MST_ENABLE))
                return false;

            // Check motor's error status
            var error = _motion.GetMotorError(SetBufferNumberFromAxis(axis));
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

        private bool WaitForDone(AxisType axis, int timeOut = 10)
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
                var safetyFlag = _motion.GetFault(SetBufferNumberFromAxis(axis));
                if (safetyFlag != SafetyControlMasks.ACSC_NONE)
                {
                    //Amp Fault 발생
                    //####ESTOP!!####
                    _motion.KillAll();
                    _motion.Disable(SetBufferNumberFromAxis(axis));

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

        private bool IsAxisDone(AxisType axis)
        {
            var state = _motion.GetMotorState(SetBufferNumberFromAxis(axis));
            var position = _motion.GetFPosition(SetBufferNumberFromAxis(axis));

            if (!Convert.ToBoolean(state & MotorStates.ACSC_MST_MOVE) && Convert.ToBoolean(state & MotorStates.ACSC_MST_INPOS))
                return true;
            else
                return false;
        }

        private void Home(AxisType axis)
        {
            if (!_motion.IsConnected)
                return;

            _motion.RunBuffer((ProgramBuffer)SetBufferNumberFromAxis(axis), null);
        }

        //private void MoveRepeatCommand(AxisType axis, double startPos, double endPos, int repeatCount)
        //{
        //    while (IsRepeat)
        //    {
        //        _motion.ToPointAsync(MotionFlags.ACSC_NONE, SetBufferNumberFromAxis(enumAxis), _startPosition);
        //        while (!WaitForDone(axis))
        //            Thread.Sleep(1);
        //        int Scanid = 1, TabCnt = 1;
        //        double dist = Math.Abs(endPos - startPos);
        //        Main.MilFrameGrabber.GrabLineScan(Scanid, TabCnt, 0, dist);
        //        _motion.ToPointAsync(MotionFlags.ACSC_NONE, SetBufferNumberFromAxis(enumAxis), _endPosition);
        //        while (!WaitForDone((eAxis)axis))
        //            Thread.Sleep(1);

        //        _motion.ToPointAsync(MotionFlags.ACSC_NONE, SetBufferNumberFromAxis(enumAxis), _startPosition);
        //        while (!WaitForDone((eAxis)axis))
        //            Thread.Sleep(1);

        //        _remainRepeatCount--;

        //        if (_setRepeatCount == ++_repeatCount)
        //            _isRepeat = false;

        //        if (_infiniteRepeat)
        //        {
        //            _isRepeat = true;
        //            _remainRepeatCount = 0;
        //        }

        //        Console.WriteLine("Set Repeat Count : " + _setRepeatCount.ToString() + " / " + "Remain Count : " + _remainRepeatCount.ToString() + " / " + "Repeat Count : " + _repeatCount.ToString());
        //    }
        //}
    }

}
