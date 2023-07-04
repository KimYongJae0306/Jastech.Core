using Jastech.Framework.Util.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jastech.Framework.Device.Plcs.Melsec.Parsers
{
    public class MelsecAsciiParser : IMelsecParser
    {
        #region 속성
        public ParserType ParserType { get; set; }

        public MessageType MessageType { get; set; }

        public string AddressName { get; set; }

        public short Command { get; set; }

        public short SubCommand { get; set; }

        public int DataLength { get; set; }

        public byte NetworkNo { get; } = 0;

        public byte PlcNo { get; } = 0xff;

        public short ModuleIoNo { get; } = 0x03FF;

        public byte ModuleDeviceNo { get; } = 0;

        public short CpuInspectorData { get; } = 0x0010;

        public int HeaderSize { get; } = 10;

        private const string CommandHeader = "5000";

        private const string ResponseHeader = "D000";

        public string Address { get; set; } = "";

        private const int SubHeaderSize = 4;

        private const int AccessRouteSize = 10;

        private const int ResponseDataLengthSize = 4;

        private const int EndCodeSize = 4;

        private const int ReadDataLengthSize = 8;

        private const int HeaderDeviceNumberSize = 6;
        #endregion

        #region 생성자
        public MelsecAsciiParser()
        {
            ParserType = ParserType.Ascii;
        }
        #endregion

        #region 메서드
        public void Parse(byte[] data, out byte[] unformattedPacket)
        {
            unformattedPacket = null;
            string receivedStr = Encoding.UTF8.GetString(data);
            int startPos = receivedStr.IndexOf("D000");
            if (startPos < 0)
            {
                Logger.Error(ErrorType.Comm, "Packet의 시작점을 찾을 수 없습니다.");
                return;
            }

            int headerSize = SubHeaderSize + AccessRouteSize + ResponseDataLengthSize + EndCodeSize; // 4 + 10 + 4 + 4 = 22

            if ((startPos + headerSize) > receivedStr.Length)
            {
                Logger.Error(ErrorType.Comm, "Header 길이가 부족합니다.");
                return;
            }

            byte networkNo = Convert.ToByte(receivedStr.Substring(startPos + 4, 2), 16);
            byte plcNo = Convert.ToByte(receivedStr.Substring(startPos + 6, 2), 16);
            short moduleIoNo = Convert.ToInt16(receivedStr.Substring(startPos + 8, 4), 16);
            byte moduleDeviceNo = Convert.ToByte(receivedStr.Substring(startPos + 12, 2), 16);
            int length = Convert.ToInt32(receivedStr.Substring(startPos + 14, 4), 16);
            short endCode = Convert.ToInt16(receivedStr.Substring(startPos + 18, 4), 16);

            int lastPos = startPos + headerSize + length - EndCodeSize;
            if (lastPos > receivedStr.Length)
            {
                Logger.Error(ErrorType.Comm, "Response Data 길이가 부족합니다.");
                return;
            }

            if (networkNo != NetworkNo || plcNo != PlcNo || moduleIoNo != ModuleIoNo || moduleDeviceNo != ModuleDeviceNo)
            {
                Logger.Error(ErrorType.Comm, "Access Route 정보가 일치하지 않습니다.");
                return;
            }

            if (endCode != 0)
            {
                Logger.Error(ErrorType.Comm, string.Format("MelsecAscii - EndCode is {0}", endCode.ToString("X04")));
            }

            string dataString = receivedStr.Substring(startPos + headerSize, length - EndCodeSize);
            unformattedPacket = StringHelper.HexStringToByteArray(dataString);
        }

        public void Serialize(byte[] unformattedPacket, out byte[] data)
        {
            data = null;
            string addressCode = GetAddressCode(AddressName);
            string addressNumber = new string('0', HeaderDeviceNumberSize - (AddressName.Length - 1)) + (AddressName.Substring(1));

            string header = NetworkNo.ToString("X2") + PlcNo.ToString("X2") + ModuleIoNo.ToString("X4") + ModuleDeviceNo.ToString("X2");

            string commandData = CpuInspectorData.ToString("X4") + Command.ToString("X4") + SubCommand.ToString("X4") + addressCode + addressNumber + DataLength.ToString("X4");

            List<Byte> commandByteDatas = new List<byte>();
            commandByteDatas.AddRange(Encoding.UTF8.GetBytes(CpuInspectorData.ToString("X4")));
            commandByteDatas.AddRange(Encoding.UTF8.GetBytes(Command.ToString("X4")));
            commandByteDatas.AddRange(Encoding.UTF8.GetBytes(SubCommand.ToString("X4")));
            commandByteDatas.AddRange(Encoding.UTF8.GetBytes(addressCode));
            commandByteDatas.AddRange(Encoding.UTF8.GetBytes(addressNumber));

            string numberofDevicePoints = DataLength.ToString("X4");
            commandByteDatas.AddRange(Encoding.UTF8.GetBytes(numberofDevicePoints));

            if (MessageType == MessageType.Write)
            {
                commandByteDatas.AddRange(unformattedPacket);
            }

            List<byte> unformattedFrame3E = new List<byte>();

            unformattedFrame3E.AddRange(Encoding.Default.GetBytes(header));
            unformattedFrame3E.AddRange(commandByteDatas.ToArray());

            data = unformattedFrame3E.ToArray();
        }

        private string GetAddressCode(string addressName)
        {
            switch (addressName[0])
            {
                case 'D': return "D*";  // 데이터 레지스터
                case 'M': return "M*";  // 내부 릴레이
                case 'X': return "X*";  // 입력 릴레이
                case 'Y': return "Y*";  // 출력 릴레이
                case 'R': return "R*";  // 파일 레지스터
            }

            throw new ArgumentOutOfRangeException();
        }
        #endregion

    }
}
