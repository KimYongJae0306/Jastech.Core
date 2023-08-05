using ACS.SPiiPlusNET;
using Jastech.Framework.Util.Helper;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Threading;
using static Jastech.Framework.Device.Motions.AxisMovingParam;

namespace Jastech.Framework.Device.Motions
{
    public partial class ACSMotion : Motion
    {

        #region 필드
        private const int _bufferCount = 8;

      

        private Thread _repeatThread { get; set; } = null;
        #endregion

        #region 속성
        [JsonProperty]
        public ACSConnectType ConnectType { get; set; }

        [JsonProperty]
        public int PortNo { get; set; }

        [JsonProperty]
        public int BaudRate { get; set; }

        [JsonProperty]
        public string IpAddress { get; set; }

        [JsonProperty]
        public ACSBufferNumber TriggerBuffer { get; set; }

        [JsonIgnore]
        public Api Api { get; set; } = null;
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        public ACSMotion(string name, int axisNumber, ACSConnectType connectType)
            : base(name, axisNumber)
        {
            ConnectType = connectType;
        }
        #endregion

        #region 메서드
        private bool OpenSerialPort()
        {
            Api.OpenCommSerial(PortNo, BaudRate);
            return true;
        }

        private bool ConectEthernet()
        {
            Api.OpenCommEthernet(IpAddress, (int)EthernetCommOption.ACSC_SOCKET_STREAM_PORT);
            return true;
        }

        public override bool Initialize()
        {
            base.Initialize();

            if (Api != null && Api.IsConnected)
                return false;

            Api = new Api();

            if (ConnectType == ACSConnectType.Serial)
            {
                if (OpenSerialPort())
                {
                    SetTriggerMode(TriggerBuffer);
                    return true;
                }
            }
            else if(ConnectType == ACSConnectType.Ethernet)
            {
                if (ConectEthernet())
                {
                    SetTriggerMode(TriggerBuffer);
                    return true;
                }
            }

            return false;
        }

        public override bool Release()
        {
            base.Release();

            if (Api.IsConnected)
                Api.KillAll();

            Api?.CloseComm();

            return true;
        }

        public override bool IsConnected()
        {
            if (Api == null)
                return false;

            return Api.IsConnected;
        }

        public override void TurnOnServo(int axisNo, bool bOnOff)
        {
            if (bOnOff)
                Api.Enable((ACS.SPiiPlusNET.Axis)axisNo);
            else
                Api.Disable((ACS.SPiiPlusNET.Axis)axisNo);
        }

        public override void AllServoOff()
        {
            Api.DisableAll();
        }

        public override void StopMove(int axisNo)
        {
            Api.Kill((ACS.SPiiPlusNET.Axis)axisNo);
        }

        public override bool IsMoving(int axisNo)
        {
            //var gg = Api.GetAxisStateAsync((ACS.SPiiPlusNET.Axis)axisNo).Ret;
            var value = Api.GetAxisState((ACS.SPiiPlusNET.Axis)axisNo);
            // 확인 필요.
            return Api.GetAxisState((ACS.SPiiPlusNET.Axis)axisNo) == AxisStates.ACSC_AST_MOVE ? true : false;
        }

        public override void JogMove(int axisNo, Direction direction)
        {
            Api.Jog(MotionFlags.ACSC_NONE, (ACS.SPiiPlusNET.Axis)axisNo, (double)direction);
        }

        public override double GetActualPosition(int axisNo)
        {
            return Api.GetFPosition((ACS.SPiiPlusNET.Axis)axisNo);
        }

        public override void StartAbsoluteMove(int axisNo, double targetPosition, double velocity, double accdec)
        {
            SetBasicParameter((ACS.SPiiPlusNET.Axis)axisNo, velocity, accdec);
            
            if (ReadyToMove((ACS.SPiiPlusNET.Axis)axisNo))
                Api.ToPointAsync(MotionFlags.ACSC_NONE, (ACS.SPiiPlusNET.Axis)axisNo, targetPosition);
        }

        public override void StartRelativeMove(int axisNo, double amount, double velocity, double accdec)
        {
            SetBasicParameter((ACS.SPiiPlusNET.Axis)axisNo, velocity, accdec);

            if (ReadyToMove((ACS.SPiiPlusNET.Axis)axisNo))
                Api.ToPoint(MotionFlags.ACSC_AMF_RELATIVE, (ACS.SPiiPlusNET.Axis)axisNo, amount);
        }

        public override void SetDefaultParameter(int axisNo, double velocity = 10, double accdec = 10)
        {
            SetBasicParameter((ACS.SPiiPlusNET.Axis)axisNo, velocity, accdec);
        }

        public override bool WaitForDone(int axisNo)
        {
            if (WaitForDone(axisNo))
                return true;
            else
                return false;
        }

        private bool WaitForDone(int axis, int timeOut = 10)
        {
            Stopwatch timeoutChecker = new Stopwatch();

            if (!Api.IsConnected)
                return false;

            timeoutChecker.Start();
            while (!IsAxisDone((ACS.SPiiPlusNET.Axis)axis))
            {
                var safetyFlag = Api.GetFault((ACS.SPiiPlusNET.Axis)axis);
                if (safetyFlag != SafetyControlMasks.ACSC_NONE)
                {
                    Api.KillAll();
                    Api.Disable((ACS.SPiiPlusNET.Axis)axis);

                    Logger.Error(ErrorType.Motion, "Fault occurs in axis Amp.");
                    return false;
                }

                if (timeoutChecker.ElapsedMilliseconds / 1000 >= timeOut)
                {
                    Logger.Error(ErrorType.Motion, "Axis movement has exceeded the set time.");
                    return false;
                }

                Thread.Sleep(1);
            }
            timeoutChecker.Reset();

            Logger.Error(ErrorType.Motion, "Axis movement has arrived at its destination.");

            return true;
        }

        public override bool StartHome(int axisNo)
        {
            return Home(axisNo);
        }

        public override string GetCurrentMotionStatus(int axisNo)
        {
            if (!Api.IsConnected)
                return null;

            //모터 상태 읽음
            var state = Api.GetMotorState((ACS.SPiiPlusNET.Axis)axisNo);
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
        
        public override bool IsEnable(int axisNo)
        {
            var state = Api.GetMotorState((ACS.SPiiPlusNET.Axis)axisNo);
            return Convert.ToBoolean(state & MotorStates.ACSC_MST_ENABLE);
        }

        public override bool IsNegativeLimit(int axisNo)
        {
            if (!Api.IsConnected)
                return false;

            var saftyFlag = Api.GetFault((ACS.SPiiPlusNET.Axis)axisNo);
            if (saftyFlag == SafetyControlMasks.ACSC_SAFETY_LL)
                return true;

            return false;
        }

        public override bool IsPositiveLimit(int axisNo)
        {
            if (!Api.IsConnected)
                return false;

            var saftyFlag = Api.GetFault((ACS.SPiiPlusNET.Axis)axisNo);
            if (saftyFlag == SafetyControlMasks.ACSC_SAFETY_RL)
                return true;

            return false;
        }

        private void SetBasicParameter(ACS.SPiiPlusNET.Axis axis, double velocity, double accdec)
        {
            // Acceleration & Deceleration : 90%, Jerk : 10%
            // Convert Acc & Dec to rate
            double jogAcceleration = Math.Abs(velocity / ((accdec * 0.9) / 1000.0));

            // Convert Jerk time to rate
            double jogJerk = Math.Abs(jogAcceleration / ((accdec * 0.1) / 1000.0));

            Api.SetVelocity(axis, velocity);
            Api.SetAcceleration(axis, jogAcceleration);
            Api.SetDeceleration(axis, jogAcceleration);
            Api.SetKillDeceleration(axis, jogAcceleration * 2);
            Api.SetJerk(axis, jogJerk);

            Thread.Sleep(300);
        }

        private bool ReadyToMove(ACS.SPiiPlusNET.Axis axis)
        {
            // Release axis event
            Api.FaultClear(axis);

            Thread.Sleep(100);

            // Read motor status
            var state = Api.GetMotorState(axis);

            // Check enable to move
            if (Convert.ToBoolean(state & MotorStates.ACSC_MST_MOVE) || !Convert.ToBoolean(state & MotorStates.ACSC_MST_INPOS) || !Convert.ToBoolean(state & MotorStates.ACSC_MST_ENABLE))
                return false;

            // Check motor's error status
            var error = Api.GetMotorError(axis);
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

        private bool WaitForDone(ACS.SPiiPlusNET.Axis axis, int timeOut = 10)
        {
            Stopwatch timeoutChecker = new Stopwatch();

            if (!Api.IsConnected)
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
                var safetyFlag = Api.GetFault(axis);
                if (safetyFlag != SafetyControlMasks.ACSC_NONE)
                {
                    //Amp Fault 발생
                    //####ESTOP!!####
                    Api.KillAll();
                    Api.Disable(axis);

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

        private bool IsAxisDone(ACS.SPiiPlusNET.Axis axis)
        {
            var state = Api.GetMotorState(axis);
            var position = Api.GetFPosition(axis);

            if (!Convert.ToBoolean(state & MotorStates.ACSC_MST_MOVE) && Convert.ToBoolean(state & MotorStates.ACSC_MST_INPOS))
                return true;
            else
                return false;
        }

        private bool Home(int axisNo)
        {
            if (!Api.IsConnected)
                return false;

            ACS.SPiiPlusNET.Axis axis = (ACS.SPiiPlusNET.Axis)axisNo;
            Api.RunBuffer((ProgramBuffer)axis, null);
           // Api.GetAxisState
            return true;
        }

        private void SetTriggerMode(ACSBufferNumber triggerBuffer)
        {
            if (!Api.IsConnected)
                return;

            Api.RunBuffer((ProgramBuffer)triggerBuffer, null);
        }
        #endregion
    }

    public enum ACSBufferNumber
    {
        Buffer0 = 0,
        Buffer1 = 1,
        Buffer2 = 2,
        Buffer3 = 3,    
        Buffer4 = 4,
        Buffer5 = 5,
        Buffer6 = 6,
        Buffer7 = 7,
    }

    public enum ACSConnectType
    {
        Serial,
        Ethernet,
    }
}
