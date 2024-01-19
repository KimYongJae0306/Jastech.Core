using System;
using System.Text;

namespace Jastech.Framework.Device.LightCtrls.Darea.Parser
{
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

    internal class Darea3StageSerialParser : IDareaParser
	{

		public string Command { get; set; }
		public int Channel { get; set; }    // TODO : 뭐가 제일 내부 조명 채널인지 확인할 것
		public int Value { get; set; }
		public byte[] Offsets { get; set; } = new byte[3];

		public int Temperature { get; set; }
		public int AlarmNumber { get; set; }

		public void Serialize(out byte[] data)
		{
			var command = (DareaSendCommand)Enum.Parse(typeof(DareaSendCommand), Command);

			switch (command)
			{
				case DareaSendCommand.PWW:
					ValidateRange(nameof(Value), Value, min: 0, max: 7);
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
			var command = Encoding.ASCII.GetString(data);

			// TODO : Parsing temperature, Offset, Alarm
		}

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
	}
}
