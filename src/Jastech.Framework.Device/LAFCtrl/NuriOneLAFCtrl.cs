using Jastech.Framework.Comm;
using Jastech.Framework.Comm.Protocol;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading;
using static Jastech.Framework.Device.Motions.AxisMovingParam;

namespace Jastech.Framework.Device.LAFCtrl
{
    public partial class NuriOneLAFCtrl : LAFCtrl
    {
        [JsonProperty]
        public SerialPortComm SerialPortComm { get; set; } = null;

        [JsonProperty]
        public double ResolutionAxisZ { get; set; } = 10.0;      // 1=0.1um, 10=1um 100 =10um 1000=100um 10000=1mm

        [JsonProperty]
        public double BallScrewPitchAxisZ { get; set; } = 2.0;      // mm

        [JsonProperty]
        public int MaxSppedAxisZ { get; set; } = 300000;            // Hz

        [JsonProperty]
        public int PacketResponseTimeMs { get; set; } = 100;

        public NuriLAFProtocol Protocol { get; set; }

        protected ManualResetEvent ResponseReceivedEvent { get; set; } = new ManualResetEvent(false);

        private string LastReceivedData { get; set; }

        public NuriOneLAFCtrl(string name)
         : base(name)
        {
        }

        public override bool Initialize()
        {
            if (SerialPortComm == null)
                return false;

            base.Initialize();

            Protocol = new NuriLAFProtocol();
            SerialPortComm.Initialize(Protocol);
            SerialPortComm.Received += SerialPortComm_Received;

            if (SerialPortComm.Connect())
            {
                SetDefaultParameter();

                SetLaserOnOff(true);
                return true;
            }
            else
                return false;
        }

        public override bool Release()
        {
            if (SerialPortComm != null)
            {
                SerialPortComm.Received -= SerialPortComm_Received;
                SerialPortComm.Disconnect();
            }
            base.Release();
            return true;
        }

        private void SerialPortComm_Received(byte[] data)
        {
            LastReceivedData = Encoding.Default.GetString(data);

            OnLAFReceived(data);

            //ResponseReceivedEvent.Set();
        }

        private void SetDefaultParameter()
        {
            SetMotionMaxSpeed(1000);
            SetAccDec(100);
        }

        public override void SetMotionMaxSpeed(double value)
        {
            //****Example****
            //[설정값]
            //Ball screw Pitch : 5 mm(360도 회전시 Z축 Pitch)
            //Control Resolution : 10000 cts / mm-+
            //[입력값]
            //10 mm / sec
            //계산식 : 10[mm / sec] / ((360 / (5[mm] * 10000[cts]) / 360) * 5[mm]) = 100000[Hz]
            //Velocity TO Pulse(Hz) formula
            //double hz = 1 / (BallScrewPitchAxisZ / value);
            //double pulse = hz * ResolutionAxisZ;
            double maxPulse = value / BallScrewPitchAxisZ;

            //int maxPulse = Convert.ToInt32(value / ((360.0 / (BallScrewPitchAxisZ * ResolutionAxisZ) / 360.0) * BallScrewPitchAxisZ));
            //int maxPulse2 = Convert.ToInt32(value / ((360.0 / (BallScrewPitchAxisZ * 10000) / 360.0) * BallScrewPitchAxisZ));

            maxPulse = 300000;//MaxSppedAxisZ * 10;// (maxPulse > MaxSppedAxisZ) ? MaxSppedAxisZ : maxPulse;

            string command = MakeSetCommand(CMD_WRITE_MOTION_MAX_SPEED, maxPulse.ToString());

            Send(command);
        }

        //public override void SetMotionMaxSpeed(double MaxSpped_um)
        //{
        //    //****Example****
        //    //[설정값]
        //    //Ball screw Pitch : 5 mm
        //    //Control Resolution : 10000 cts / mm-+
        //    //[입력값]
        //    //10 mm / sec
        //    //계산식 : 10[mm / sec] / ((360 / (5[mm] * 10000[cts]) / 360) * 5[mm]) = 100000[Hz]
        //    //Velocity TO Pulse(Hz) formula

        //    double MaxSpped_pulse = 
        //    int maxPulse = Convert.ToInt32(value / ((360.0 / (BallScrewPitchAxisZ * ResolutionAxisZ) / 360.0) * BallScrewPitchAxisZ));
        //    int maxPulse2 = Convert.ToInt32(value / ((360.0 / (BallScrewPitchAxisZ * 10000) / 360.0) * BallScrewPitchAxisZ));

        //    maxPulse = (maxPulse > MaxSppedAxisZ) ? MaxSppedAxisZ : maxPulse;
        //    maxPulse2 = (maxPulse2 > MaxSppedAxisZ) ? MaxSppedAxisZ : maxPulse2;

        //    string command = MakeSetCommand(CMD_WRITE_MOTION_MAX_SPEED, maxPulse.ToString());

        //    SerialPortComm.Send(command);
        //}


        public void SetAccDec(int value)
        {
            // Min : 1 Max : 200
            if (value < 1)
                value = 1;
            if (value > 200)
                value = 200;

            string command = MakeSetCommand(CMD_WRITE_ACCELDECEL, value.ToString());
            Send(command);
        }

        public void SetLaserOnOff(bool isOn)
        {
            IsLaserOn = isOn;
            string value = Convert.ToInt16(isOn).ToString();

            string command = MakeSetCommand(CMD_WRITE_LASER_ONOFF, value);
            Send(command);
        }

        public void GetLaserOnValue()
        {
            string command = MakeSetCommand(CMD_WRITE_LASER_ONOFF);
            Send(command);
        }

        public void SetAutoFocusOnOFF(bool isOn)
        {
            string value = Convert.ToInt16(isOn).ToString();

            string command = MakeSetCommand(CMD_WRITE_AF_ONOFF, value);
            Send(command);
        }

        public void GetAutoFocusValue()
        {
            string command = MakeSetCommand(CMD_WRITE_AF_ONOFF);
            Send(command);
        }

        public void SetMotionEnable(bool isOn)
        {
            string value = Convert.ToInt16(isOn).ToString();

            string command = MakeSetCommand(CMD_WRITE_MOTION_ENABLE, value);
            Send(command);
        }

        public override void SetMotionStop()
        {
            string command = MakeSetCommand(CMD_WRITE_MOTION_STOP);
            Send(command);
        }

        public override void SetMotionZeroSet()
        {
            string command = MakeSetCommand(CMD_WRITE_MOTION_ZERO);
            Send(command);
        }

        public override void SetMotionRelativeMove(Direction direction, double value)
        {
            if (value * ResolutionAxisZ < 1)
                return;

            value = Math.Abs(value * 1000);

            int directionValue = direction == Direction.CW ? -1 : 1;

            int moveAmount = Convert.ToInt32(value * ResolutionAxisZ) * directionValue;

            string command = MakeSetCommand(CMD_WRITE_MOTION_RELATIVE_MOVE, moveAmount.ToString());
            Send(command);
        }

        public override void SetMotionAbsoluteMove(double value)
        {
            int targetPosition = Convert.ToInt32(value * ResolutionAxisZ);
            string command = MakeSetCommand(CMD_WRITE_MOTION_ABSOLUTE_MOVE, targetPosition.ToString());
            Send(command);
        }

        public override void SetMotionPositiveLimit(double value)
        {
            string command = MakeSetCommand(CMD_WRITE_MOTION_LIMIT_PLUS, value.ToString());
            Send(command);
        }

        public override void SetMotionNegativeLimit(double value)
        {
            string command = MakeSetCommand(CMD_WRITE_MOTION_LIMIT_MINUS, value.ToString());
            Send(command);
        }

        public void RequestData(string command)
        {
            string makeData = MakeGetCommand(command);
            Send(makeData);
        }

        private void Send(string command)
        {
            if (command == "")
                return;

            byte[] serializedData = Encoding.UTF8.GetBytes(command);
            if (Protocol.MakePacket(serializedData, out byte[] sendData))
            {
                SerialPortComm.Send(sendData);
            }
        }

        private string MakeSetCommand(string command, string value = "")
        {
            return string.Format(";" + command + " " + value + "\r");
        }

        private string MakeGetCommand(string command)
        {
            return string.Format(";" + command + "\r");
        }

        public override void SetCenterOfGravity(int value)
        {
            int offset = (value > 10000) ? 9999 : value;
            offset = (value < -10000) ? -9999 : value;

            string command = MakeSetCommand(CMD_WRITE_FOCUS_POSITION, offset.ToString());
            SerialPortComm.Send(command);
        }
    }

    public partial class NuriOneLAFCtrl
    {
        #region Const
        const string CMD_WRITE_STORE_PERMANENT_PARAMETERS = "write_all_parameters";     // 이 커맨드는 파라미터를 영구적으로 저장시킬 수 있습니다. (Non-permanent 항목은 제외) 응답시간은 500~1000ms입니다. 이 커맨드는 센서 또는 모터 동작에 영향을 줄 수 있기 때문에, Normal Sensor 구동 중인 경우에는 사용하지 마십시오.
        const string CMD_WRITE_LASER_ONOFF = "uc lasergate";                       // SET Laser On/Off 1= gate laser on, 0= gate laser off
        const string CMD_WRITE_AF_ONOFF = "uc motiontrack";                             // SET AF On/Off 1= af on, 0= af off
        const string CMD_WRITE_MOTION_ENABLE = "uc motionenable";                       // SET Motor On/Off 1= Motor on, 0= Motor off
        const string CMD_WRITE_MOTION_STOP = "uc motionstop";                           // SET Motor Stop
        const string CMD_WRITE_MOTION_ZERO = "uc motionzero";                           // SET Motion Zero Set (mpos value 0)
        const string CMD_WRITE_MOTION_RELATIVE_MOVE = "uc move 0";                      // SET Motion Relative Move (um)
        const string CMD_WRITE_MOTION_ABSOLUTE_MOVE = "uc move 2";                      // SET Motion Absolute Move (um)
        const string CMD_WRITE_MOTION_MAX_SPEED = "uc motionmaxspeed";                  // SET Motion Max Speed (hz)
        const string CMD_WRITE_MOTION_LIMIT_PLUS = "uc motionpluslimit";                // SET Motion Limit(+) Position 
        const string CMD_WRITE_MOTION_LIMIT_MINUS = "uc motionminuslimit";              // SET Motion Limit(-) Position 
        const string CMD_WRITE_FOCUS_POSITION = "uc motionrefpos";                      // SET Focus Position Value (cog)
        const string CMD_READ_STATUS_REPORT = "uc rep cog mpos ls1 ls2";                // GET Sensor Status (cog mpos -limit +limit)
        const string CMD_WRITE_BAUDRATE = "baud %s 0";                                  // SET Focus Position Value (cog)
        const string CMD_WRITE_ACCELDECEL = "uc motionacctcms";                         // SET Motion Acceleration/Deceleration
        const int AF_SENSOR_PORT_RES_WAIT = 200;
        #endregion
    }
}
