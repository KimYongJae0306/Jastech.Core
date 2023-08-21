using Jastech.Framework.Comm;
using Jastech.Framework.Comm.Protocol;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using static Jastech.Framework.Device.Motions.AxisMovingParam;
using static System.Net.Mime.MediaTypeNames;

namespace Jastech.Framework.Device.LAFCtrl
{
    public partial class NuriOneLAFCtrl : LAFCtrl
    {
        [JsonProperty]
        public SerialPortComm SerialPortComm { get; set; } = null;

        [JsonProperty]
        public double BallScrewPitchAxisZ { get; set; } = 2.0;      // mm

        

        [JsonProperty]
        public int PacketResponseTimeMs { get; set; } = 100;

        [JsonIgnore]
        public NuriLAFProtocol Protocol { get; set; }

        [JsonIgnore]
        protected ManualResetEvent ResponseReceivedEvent { get; set; } = new ManualResetEvent(false);

        [JsonIgnore]
        private string LastReceivedData { get; set; }

        [JsonIgnore]
        public bool IsLaserOn { get; set; }

        [JsonIgnore]
        public bool IsTrackingOn { get; set; }

        [JsonIgnore]
        private bool IsGetMessageOn { get; set; } = false;

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
                SetBaudRate(115200);                // 누리원테크 확인 결과, 첫 연결은 9600으로 연결 후 통신속도를 115200으로 변경
                SetDefaultParameter();
                SetLaserOnOff(true);
                return true;
            }
            else
                return false;
        }

        public override bool IsConnected()
        {
            return SerialPortComm.IsConnected();
        }

        public override bool Release()
        {
            if (SerialPortComm != null)
            {
                SetTrackingOnOFF(false);
                Thread.Sleep(50);
                SetLaserOnOff(false);
                Thread.Sleep(50);

                SerialPortComm.Received -= SerialPortComm_Received;
                SerialPortComm.Disconnect();
            }

            base.Release();
            return true;
        }

        private void SerialPortComm_Received(byte[] data)
        {
            LastReceivedData = Encoding.Default.GetString(data);
            //Console.WriteLine(LastReceivedData);
            if (IsGetMessageOn == false)
                OnLAFReceived(data);
            else
            {
                string temp = LastReceivedData;
                if (temp.Contains("MLLAF3:uc lasergate"))
                {
                    CheckText(ref temp);

                    string text = "lasergate";
                    int index = temp.IndexOf(text);
                    int startIndex = index + text.Length;
                    int size = text.Length - startIndex;
                    string valueString = temp.Substring(startIndex, 2).Trim();
                    IsLaserOn = Convert.ToInt16(valueString) == 1 ? true : false;
                }

                if (temp.Contains("MLLAF3:uc motiontrack"))
                {
                    CheckText(ref temp);

                    string text = "motiontrack";
                    int index = temp.IndexOf(text);
                    int startIndex = index + text.Length;
                    int size = text.Length - startIndex;
                    string valueString = temp.Substring(startIndex, 2).Trim();

                    IsTrackingOn = Convert.ToInt16(valueString) == 1 ? true : false;
                    Console.WriteLine("-------------------------Tracking : " + IsTrackingOn + "  " + Name.ToString());
                }
                if(temp.Contains("uc motionrefpos"))
                {
                    int g1 = 1;
                }
            }

            ResponseReceivedEvent.Set();
            IsGetMessageOn = false;
        }

        private void CheckText(ref string value)
        {
            while (value.Contains("\n4"))
                value = value.Replace("\n4", "");

            while (value.Contains("\n"))
                value = value.Replace("\n", "");

            while (value.Contains("\r"))
                value = value.Replace("\r", "");

            while (value.Contains("0x00000000"))
                value = value.Replace("0x00000000", "");

            while (value.Contains("0x00000001"))
                value = value.Replace("0x00000001", "");
        }

        public override void SetDefaultParameter()
        {
            SetMotionMaxSpeed(MaxSppedAxisZ);
            SetAccDec(AccDec);
        }

        public override void SetMotionMaxSpeed(double velocity)
        {
            double maxPulse = velocity * ResolutionAxisZ;
            if (maxPulse < 0.0001)
                maxPulse = 0.0001;

            string command = MakeSetCommand(CMD_WRITE_MOTION_MAX_SPEED, maxPulse.ToString());

            Send(command);
        }

        public override void SetAccDec(int value)
        {
            if (value < 1)
                value = 1;
            if (value > 200)
                value = 200;

            string command = MakeSetCommand(CMD_WRITE_ACCELDECEL, value.ToString());
            Send(command);
        }

        private void SetBaudRate(int baudRate)
        {
            string command = MakeSetCommand(CMD_WRITE_BAUDRATE, baudRate.ToString());
            Send(command);
        }

        public override void SetLaserOnOff(bool isOn)
        {
            ResponseReceivedEvent.WaitOne(1000);
            string value = Convert.ToInt16(isOn).ToString();
            IsGetMessageOn = true;
            string command = MakeSetCommand(CMD_WRITE_LASER_ONOFF, value);
            Send(command);
        }

        public void GetLaserOnValue()
        {
            ResponseReceivedEvent.WaitOne(1000);
            IsGetMessageOn = true;
            string command = MakeSetCommand(CMD_WRITE_LASER_ONOFF);
            Send(command);
        }

        public override void SetTrackingOnOFF(bool isOn)
        {
            //if (isOn == false)
            //    return;
            ResponseReceivedEvent.WaitOne(1000);
            IsGetMessageOn = true;
            string value = Convert.ToInt16(isOn).ToString();

            string command = MakeSetCommand(CMD_WRITE_AF_ONOFF, value);
            Send(command);
        }

        public void GetAutoFocusValue()
        {
            string command = MakeSetCommand(CMD_WRITE_AF_ONOFF);
            Send(command);
        }

        public override void SetMotionEnable(bool isOn)
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
            //if (value * ResolutionAxisZ < 1)
            //    return;

            if (value <= 0.0001)
                value = 0.0001;
            value = Math.Abs(value);
            Console.WriteLine("LAF : " + value.ToString() +"   " + Status.MPosPulse);
            int directionValue = direction == Direction.CW ? -1 : 1;

            double moveAmount = Convert.ToDouble(value * ResolutionAxisZ) * directionValue;
            string command = MakeSetCommand(CMD_WRITE_MOTION_RELATIVE_MOVE, moveAmount.ToString());
            Send(command);

            Thread.Sleep(50);
        }

        public override void SetMotionAbsoluteMove(double value)
        {
            double targetPosition = value * ResolutionAxisZ;
            string command = MakeSetCommand(CMD_WRITE_MOTION_ABSOLUTE_MOVE, targetPosition.ToString());
            Send(command);
        }

        public override void SetMotionPositiveLimit(double value)
        {
            //double positiveLimit = value * ResolutionAxisZ;
            //string command = MakeSetCommand(CMD_WRITE_MOTION_LIMIT_PLUS, positiveLimit.ToString());
            //Send(command);
        }

        public override void SetMotionNegativeLimit(double value)
        {
            //double negativeLimit = value * ResolutionAxisZ;
            //string command = MakeSetCommand(CMD_WRITE_MOTION_LIMIT_MINUS, negativeLimit.ToString());
            //Send(command);
        }

        public override void SetVroOnOff(bool isOn)
        {
            int value = isOn ? 1 : 0;
            string command = MakeSetCommand(CMD_VRO, value.ToString());
            Send(command);
        }

        public override void SetYWindow(int start, int width)
        {
            string value = start.ToString() + " " + width.ToString();
            string command = MakeSetCommand(CMD_Y_WINDOW, value.ToString());
            Send(command);
        }

        public void RequestData(string command)
        {
            if (IsGetMessageOn)
                return;
            string makeData = MakeGetCommand(command);
            Send(makeData);
        }

        private void Send(string command)
        {
            if (command == "")
                return;

            ResponseReceivedEvent.WaitOne(1000);
            ResponseReceivedEvent.Reset();
            byte[] serializedData = Encoding.UTF8.GetBytes(command);

            if (Protocol.MakePacket(serializedData, out byte[] sendData))
                SerialPortComm.Send(sendData);
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
            ResponseReceivedEvent.WaitOne(1000);
            IsGetMessageOn = true;
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
        const string CMD_VRO = "uc vro";                                                // SET VRO
        const string CMD_Y_WINDOW = "uc ywindow";                                       // SET Y Window "start width"

        const int AF_SENSOR_PORT_RES_WAIT = 200;
        #endregion
    }
}
