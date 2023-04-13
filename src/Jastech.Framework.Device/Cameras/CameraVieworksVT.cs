using Jastech.Framework.Comm;
using Jastech.Framework.Comm.Protocol;
using Jastech.Framework.Imaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Jastech.Framework.Device.Cameras
{
    public partial class CameraVieworksVT : Camera, ICameraTDIavailable, ICameraTriggerable, ICameraPRNUavailable
    {
        #region 필드
        const string SetSensorModeCmd = "som";            // Set Sensor Mode Command (0 : TDI 1 : AREA)
        const string SetScanDirectionCmd = "ssd";         // Set ScanDirection Command (0 : FWD 1 : RVS 2 : LINE1)
        const string SetExposureTimeCmd = "set";          // Set Exposure Time Command (When Area Mode, us)
        const string GetExposureTimeCmd = "get";
        const string SetTroggerModeCmd = "stm";           // Set Trigger Mode Command (0 : Free-Run 1 : Trigger Mode)
        const string SetReverseXCmd = "shf";              // Set Reverse X Command (0 : Off 1 : On)
        const string SetAnalogGainCmd = "sag";            // Set Analog Gain Command (1 : 1x 2 : 2x 3 : 3x 4 : 4x)
        const string SetDigitalGainCmd = "sdg";           // Set Digital Gain Command (1.0 ~ 8.0)
        const string SetTriggerSourceCmd = "sts";         // Set Trigger Source Command (1 : CC1 Port 5 : External Port)
        const string SetOffsetXCmd = "sox";               // Set Offset X Mode Command (ROI Start coordinate)
        const string SetImageWidthCmd = "siw";            // Set Image Width Command (VT_6K3_5C : 256 ~ 6560)
        const string SetStrobeModeCmd = "ssm";            // Set Strobe Mode Command (0 : Off 1 : Strobe Duration 2 : Trigger Pulse 3 : Successive High Pulse
        const string SetStrobeDurationCmd = "ssr";        // Set Strobe Duration Command (1.00 ~ 1000.00 us)
        const string StrobeCurrentCmd = "sscc";        // Set Strobe Current (0 ~ 1000) mA
        const string StrobeBrightnessCmd = "sscb";     // Set Strobe Brightness (0 ~ 300) %

        const string OutputFrequencyCmd = "w clfq";
        const string FFCEnableCmd = "w ffcp";
        const string FFCCalibrationCmd = "w calg";
        const string PRNUCalibrationCmd = "w calo";
        const string TriggerPresetCmd = "w sync";

        const double nullCommand = -1.0;
        #endregion

        #region 속성
        [JsonProperty]
        public SerialPortComm SerialPortComm { get; set; } = null;

        [JsonProperty]
        public int PacketResponseTimeMs { get; set; } = 100;

        public string ReceivedMessage { get; set; } = "";

        protected ManualResetEvent ResponseReceivedEvent { get; set; } = new ManualResetEvent(false);
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        public CameraVieworksVT(string name, int imageWidth, int imageHeight, ColorFormat colorFormat, SensorType sensorType)
           : base(name, imageWidth, imageHeight, colorFormat, sensorType)
        {
        }
        #endregion

        #region 메서드
        public override bool Initialize()
        {
            if (SerialPortComm == null)
                return false;

            base.Initialize();

            SerialPortComm.Initialize(new ViewworksVTSerialProtocol());
            SerialPortComm.Received += SerialPortComm_Received;

            return SerialPortComm.Connect();
        }
     
        public override bool Release()
        {
            if(SerialPortComm != null)
            {
                SerialPortComm.Received -= SerialPortComm_Received;
                SerialPortComm.Disconnect();
            }
            base.Release();
            return true;
        }

        private void SerialPortComm_Received(byte[] data)
        {
            string dataString = Encoding.Default.GetString(data);
            ResponseReceivedEvent.Set();
        }

        public override void SetExposureTime(double value)
        {
            string message = MakeSetCommand(SetExposureTimeCmd, value);
            SendMessage(message);
        }

        public override double GetExposureTime()
        {
            string message = MakeGetCommand(GetExposureTimeCmd);
            SendMessage(message);

            ResponseReceivedEvent.WaitOne(PacketResponseTimeMs);

            double exposure;
            if (double.TryParse(ReceivedMessage, out exposure))
                return exposure;
            else
                return -1;
        }

        public override void ReverseX(bool reverse)
        {
            string message = MakeSetCommand(SetReverseXCmd, reverse == false ? 0 : 1);
            SendMessage(message);
        }

        public override void SetAnalogGain(int value)
        {
            if (value < 1)
                value = 1;
            if (value > 4)
                value = 4;

            string message = MakeSetCommand(SetAnalogGainCmd, value);
            SendMessage(message);
        }

        public override void SetDigitalGain(double value)
        {
            if (value < 1)
                value = 1;
            if (value > 8)
                value = 8;

            string message = MakeSetCommand(SetDigitalGainCmd, value);
            SendMessage(message);
        }

        public override void SetOffsetX(int value)
        {
            string message = MakeSetCommand(SetOffsetXCmd, value);
            SendMessage(message);
        }

        public override void SetImageWidth(int value)
        {
            string message = MakeSetCommand(SetImageWidthCmd, value);
            SendMessage(message);
        }

        public override byte[] GetGrabbedImage()
        {
            return null;
        }

        public override void GrabOnce()
        {
        }

        public override void GrabMuti(int grabCount)
        {
        }

        public override void GrabContinous()
        {
        }

        public override void Stop()
        {
        }

        public void SendMessage(string message)
        {
            ResponseReceivedEvent.Reset();
            ReceivedMessage = "";
            SerialPortComm.Send(message);
        }

        private string MakeSetCommand(string command, double value1, double value2 = nullCommand)
        {
            if (value2 == nullCommand)
                return string.Format(command + " " + value1 + "\r");
            else
                return string.Format(command + " " + value1 + " " + value2 + "\r");
        }

        private string MakeGetCommand(string command)
        {
            return string.Format(command + " " + "\r" + "\n");
        }
        #endregion
    }

    public partial class CameraVieworksVT : ICameraTDIavailable
    {
        #region 속성
        public TDIOperationMode TDIOperationMode { get; private set; }

        public TDIDirectionType TDIDirection { get; private set; }
        #endregion

        #region 메서드
        public void SetTDISensorMode(TDIOperationMode mode)
        {
            TDIOperationMode = mode;

            string message = MakeSetCommand(SetSensorModeCmd, (int)mode);
            SendMessage(message);
        }

        public void SetTDIScanDriection(TDIDirectionType direction)
        {
            TDIDirection = direction;

            string message = MakeSetCommand(SetScanDirectionCmd, (int)direction);
            SendMessage(message);
        }
        #endregion
    }

    public partial class CameraVieworksVT : ICameraTriggerable
    {
        #region 속성
        public int TriggerChannel { get; private set; }

        public TriggerMode TriggerMode { get; private set; }

        public int TriggerSource { get; private set; }
        #endregion

        #region 메서드
        public void SetTriggerMode(TriggerMode triggerMode)
        {
            TriggerMode = triggerMode;

            string message = MakeSetCommand(SetTroggerModeCmd, (int)triggerMode);
            SendMessage(message);
        }

        /// <summary>
        ///  CC1_Port(CameraLink) = 1
        ///  External_Port(Line1) = 5
        /// </summary>
        /// <param name="triggerSource"></param>
        public void SetTriggerSource(int triggerSource)
        {
            TriggerSource = triggerSource;

            string message = MakeSetCommand(SetTriggerSourceCmd, triggerSource);
            SendMessage(message);
        }
        #endregion
    }

    public partial class CameraVieworksVT : ICameraPRNUavailable
    {
        #region 메서드
        public void SetStrobeMode(StrobeMode mode)
        {
            string message = MakeSetCommand(SetStrobeModeCmd, (int)mode);
            SendMessage(message);
        }

        public void SetStrobeDuration(int us)
        {
            string message = MakeSetCommand(SetStrobeDurationCmd, us);
            SendMessage(message);
        }

        public void SetStrobeCurrent(int channel, int value)
        {
            // Document 상 StrobeCurrentCmd 가 존재하지 않음(확인 필요)
            string message = MakeSetCommand(StrobeCurrentCmd, channel, value);
            SendMessage(message);
        }

        public void SetStrobeBrightness(int channel, int value)
        {
            // Document 상 StrobeBrightnessCmd 가 존재하지 않음(확인 필요)
            string message = MakeSetCommand(StrobeBrightnessCmd, channel, value);
            SendMessage(message);
        }

        public void SetOutputFrequency(int value)
        {
            // Document 상 OutputFrequencyCmd 가 존재하지 않음(확인 필요)
            string message = MakeSetCommand(OutputFrequencyCmd, value);
            SendMessage(message);
        }

        public void SetFFCEnable(int value)
        {
            // Document 상 FFCEnableCmd 가 존재하지 않음(확인 필요)
            string message = MakeSetCommand(FFCEnableCmd, value);
            SendMessage(message);
        }

        public void SetFFCCalibration(int value)
        {
            // Document 상 FFCCalibrationCmd 가 존재하지 않음(확인 필요)
            string message = MakeSetCommand(FFCCalibrationCmd, value);
            SendMessage(message);
        }

        public void SetPRNUCalibration(int value)
        {
            // Document 상 PRNUCalibrationCmd 가 존재하지 않음(확인 필요)
            string message = MakeSetCommand(PRNUCalibrationCmd, value);
            SendMessage(message);
        }
        #endregion
    }
}
