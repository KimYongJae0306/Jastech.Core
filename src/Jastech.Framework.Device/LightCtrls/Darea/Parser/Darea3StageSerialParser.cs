using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;

namespace Jastech.Framework.Device.LightCtrls.Darea.Parser
{
    #region Enum Definitions
    internal enum DareaSendCommand
	{
		RESET, // Reset alarm
		PWW,   // Set On/Off state to entire channel
		PWR,   // Get On/Off state from entire channel
		CDW,   // Set light value to single channel 
		CDR,   // Get light value from single channel 
		ADW,   // Set light value to entire channel 
		OSW,   // Set offset light value to each channel
		OSR,   // Get offset light value from each channel
		LTR,   // Get temperature
		ALR    // Get alarm number
	}
	internal enum DareaReceieveCommand   // Require suffix "\r\n"
	{
		RPW, // return value of PWR => RPW:{powerState}\r\n
		RLV, // return value of CDR => RLV{channel}:{lightValue}\r\n
		ROS, // return value of OSR => ROS:{offsetCh1}{offsetCh2}{offestCh3}\r\n
		RET, // return value of LTR => RET:{temperature}\r\n
		ERR  // return value of ALR => ERR:{alarmInfo}\r\n
	}
    internal enum DareaAlarmBit
    {
        Temperature = 0,
        Dummy1 = 1,
        Dummy2 = 2,
        Dummy3 = 3,
        Dummy4 = 4,
        Dummy5 = 5,
        Dummy6 = 6,
        Dummy7 = 7
    }
    #endregion

    internal partial class Darea3StageSerialParser : IDareaParser
	{
		#region 속성
		public int Channel { get; set; }
		public int Value { get; set; }
		#endregion

		#region 메서드
		public void Serialize(out byte[] data)
		{
			var command = (DareaSendCommand)Enum.Parse(typeof(DareaSendCommand), Command);

			switch (command)
			{
				case DareaSendCommand.PWW:
					ValidateRange(nameof(Value), Value, min: 0b000, max: 0b111);
					data = Encoding.ASCII.GetBytes(GenerateCommandWithValue());
					break;

				case DareaSendCommand.CDW:
					ValidateRange(nameof(Channel), Channel, min: 1, max: 3);
					ValidateRange(nameof(Value), Value, min: byte.MinValue, max: byte.MaxValue);
					data = Encoding.ASCII.GetBytes(GenerateCommandWithChannelAndValue());
					break;

				case DareaSendCommand.CDR:
					ValidateRange(nameof(Channel), Channel, min: 1, max: 3);
					data = Encoding.ASCII.GetBytes(GenerateCommandWithChannel());
					break;

				case DareaSendCommand.ADW:
					ValidateRange(nameof(Value), Value, min: byte.MinValue, max: byte.MaxValue);
					data = Encoding.ASCII.GetBytes(GenerateCommandWithValue());
					break;

				case DareaSendCommand.OSW:
					ValidateOffsets();
					data = Encoding.ASCII.GetBytes(GenerateCommandWithOffsets());
					break;

				case DareaSendCommand.RESET:
				case DareaSendCommand.PWR:
				case DareaSendCommand.OSR:
				case DareaSendCommand.LTR:
				case DareaSendCommand.ALR:
					data = Encoding.ASCII.GetBytes(GenerateCommonCommand());
					break;

				default:
					throw new ArgumentException($"Invalid arguments on Darea3StageParser.Serialize(). Command : {Command}");
			}
		}

		public void Deserialize(byte[] data)
		{
			if (data[0] == 0x06)
				return;

			var receivedString = Encoding.ASCII.GetString(data);
			var match = Regex.Match(receivedString, @"(\w+):(.+)\r\n?");

			ValidateReturnCommand(ref receivedString, out int channelNo);

			if (match.Success)
			{
				var matchedCommand = match.Groups[0].Value;
				var matchedParameter = match.Groups[1].Value;

				switch ((DareaReceieveCommand)Enum.Parse(typeof(DareaReceieveCommand), matchedCommand))
				{
					case DareaReceieveCommand.RPW:
						UpdateChannelPowerStates(matchedParameter);
						break;
					case DareaReceieveCommand.RLV:
						UpdateChannelLightValues(channelNo, matchedParameter);
						break;
					case DareaReceieveCommand.ROS:
						// TODO: Offset 값 날아오는거 형태 확인 필요
						break;
					case DareaReceieveCommand.RET:
						UpdateControllerTemperature(matchedParameter);
						break;
					case DareaReceieveCommand.ERR:
						UpdateAlarmInfo(matchedParameter);
						break;
				}
			}
		}
		#endregion
	}

    internal partial class Darea3StageSerialParser
    {
        #region 필드
        private const int _channelCount = 3;
        #endregion

        #region 속성
        //송신부
        public string Command { get; set; }
        public byte[] Offsets { get; set; } = new byte[_channelCount];

        //수신부
        public bool[] ChannelPowerOnStates { get; private set; } = new bool[_channelCount];
        public byte[] ChannelLightValues { get; private set; } = new byte[_channelCount];
        public byte[] ChannelOffsetValues { get; private set; } = new byte[_channelCount];
        public int Temperature { get; private set; }
        private BitArray AlarmInfo { get; set; } = new BitArray(8);
        #endregion

        #region 메서드
        // 송신부
        private void ValidateRange(string paramName, int value, int min, int max)
        {
            if (value < min || value > max)
                Console.WriteLine($"Invalid arguments on Darea3StageParser.Serialize(). {paramName} range ({min} ~ {max})");
        }

        private void ValidateOffsets()
        {
            if (Offsets.Length != 3)
                Console.WriteLine("Invalid arguments on Darea3StageParser.Serialize(). Require offset values of all 3 channels");
        }
        private string GenerateCommonCommand() => $"[{Command}#";

        private string GenerateCommandWithValue() => $"[{Command},{Value}#";

        private string GenerateCommandWithChannel() => $"[{Command}{Channel}#";

        private string GenerateCommandWithChannelAndValue() => $"[{Command}{Channel},{Value}#";

        private string GenerateCommandWithOffsets() => $"]{Command},{Offsets[0]}{Offsets[1]}{Offsets[2]}#";

        //수신부
        private void ValidateReturnCommand(ref string command, out int channel)
        {
            if (command.Length < 3)
                channel = -1;
            else
            {
                channel = int.Parse(command.Substring(3));
                command = command.Substring(0, 3);
            }
        }
        private void UpdateChannelPowerStates(string parameter)
        {
            int channelPowerStates = int.Parse(parameter);
            for (int digit = 0; digit < _channelCount; digit++)
                ChannelPowerOnStates[digit] = (channelPowerStates & (1 << digit)) != 0x00;
        }
        private void UpdateAlarmInfo(string parameter)
        {
            int alarmInfo = int.Parse(parameter);
            for (int digit = 0; digit < AlarmInfo.Count; digit++)
                AlarmInfo[digit] = (alarmInfo & (1 << digit)) != 0b0;
        }
        private void UpdateChannelLightValues(int channelNo, string parameter) => ChannelLightValues[channelNo] = byte.Parse(parameter);
        private void UpdateControllerTemperature(string parameter) => Temperature = int.Parse(parameter);
        #endregion
    }
}
