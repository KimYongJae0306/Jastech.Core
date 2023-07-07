using Jastech.Framework.Util.Helper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jastech.Framework.Device.Plcs.Melsec.Parsers
{
    public class MelsecBinaryParser : IMelsecParser
    {
        #region 속성
        public ParserType ParserType { get; set; }

        public MessageType MessageType { get; set; }

        public string AddressName { get; set; }

        public short Command { get; set; }

        public short SubCommand { get; set; }

        public int DataLength { get; set; }

        public byte NetworkNo { get; set; } = 0;

        public byte PlcNo { get; } = 0xff;

        public short ModuleIoNo { get; } = 0x03FF;

        public byte ModuleDeviceNo { get; set; } = 0;

        public short CpuInspectorData { get; } = 0x0010;

        public int HeaderSize { get; } = 5;

        private const string CommandHeader = "5000";

        private const string ResponseHeader = "D000";

        private const int SubHeaderSize = 2;

        private const int AccessRouteSize = 5;

        private const int ResponseDataLengthSize = 2;

        private const int EndCodeSize = 2;

        private const int ReadDataLengthSize = 4;
        #endregion

        #region 생성자
        public MelsecBinaryParser()
        {
            ParserType = ParserType.Binary;
        }
        #endregion

        #region 메서드
        public void Parse(byte[] data, out byte[] unformattedPacket)
        {
            unformattedPacket = null;
            byte[] stx = new byte[2] { 0xD0, 0x00 };

            if (data == null)
                return;

            int startPos = this.IndexOf(data, stx);
            if (startPos < 0)
            {
                Logger.Error(ErrorType.Comm, "Packet의 시작점을 찾을 수 없습니다.");
                return;
            }

            byte[] contents = data.Skip(startPos).ToArray();
            if (contents.Length < SubHeaderSize + AccessRouteSize + ResponseDataLengthSize + EndCodeSize) // 2 + 5 + 2 + 2 = 11
            {
                Logger.Error(ErrorType.Comm, "Header 길이가 부족합니다.");
                return;
            }

            byte networkNo = contents[2];
            byte plcNo = contents[3];
            short moduleIoNo = BitConverter.ToInt16(contents.Skip(4).Take(2).ToArray(), 0);
            byte moduleDeviceNo = contents[6];
            short dataLength = BitConverter.ToInt16(contents.Skip(7).Take(2).ToArray(), 0);
            ushort endCode = BitConverter.ToUInt16(contents.Skip(9).Take(2).ToArray(), 0);

            if (dataLength > contents.Length - (EndCodeSize + ReadDataLengthSize)) // 2 + 4 = 6
            {
                Logger.Error(ErrorType.Comm, "Response Data 길이가 부족합니다.");
                return;
            }

            int lastPos = startPos + SubHeaderSize + AccessRouteSize + ResponseDataLengthSize + dataLength; // 2 + 5 + 2 = 9
            if (networkNo != NetworkNo || plcNo != PlcNo || moduleIoNo != ModuleIoNo || moduleDeviceNo != ModuleDeviceNo)
            {
                Logger.Error(ErrorType.Comm, "Access Route 정보가 일치하지 않습니다.");
                return;
            }

            if (endCode != 0)
            {
                Logger.Error(ErrorType.Comm, string.Format("MelsecBinary - EndCode is {0}", endCode.ToString("X")));
            }

            unformattedPacket = contents.Skip(11).Take(dataLength - EndCodeSize).ToArray();
        }

        public void Serialize(byte[] unformattedPacket, out byte[] data)
        {
            data = null;
            byte addressCode = GetAddressCode(AddressName);
            byte[] addressNumber = BitConverter.GetBytes(int.Parse(AddressName.Substring(1)));

            List<byte> header = new List<byte>();
            header.Add(NetworkNo);
            header.Add(PlcNo);
            header.AddRange(BitConverter.GetBytes(ModuleIoNo));
            header.Add(ModuleDeviceNo);

            List<byte> command = new List<byte>();
            command.AddRange(BitConverter.GetBytes(CpuInspectorData));
            command.AddRange(BitConverter.GetBytes(Command));   // Batch Read
            command.AddRange(BitConverter.GetBytes(SubCommand));   // SubCommand
            command.Add(addressNumber[0]);
            command.Add(addressNumber[1]);
            command.Add(addressNumber[2]);
            command.Add(addressCode);
            command.AddRange(BitConverter.GetBytes((short)(DataLength)));

            if (MessageType == MessageType.Write)
            {
                string dataHexString = StringHelper.ByteToString(unformattedPacket);
                command.AddRange(StringHelper.HexStringToByteArray(dataHexString));
            }

            List<byte> unformattedFrame3E = new List<byte>();
            unformattedFrame3E.AddRange(header);

            unformattedFrame3E.AddRange(command);

            data = unformattedFrame3E.ToArray();
        }

        private byte GetAddressCode(string addressName)
        {
            switch (addressName[0])
            {
                case 'D': return 0xA8;  // 데이터 레지스터
                case 'M': return 0x90;  // 내부 릴레이
                case 'X': return 0x9C;  // 입력 릴레이
                case 'Y': return 0x9D;  // 출력 릴레이
                case 'R': return 0xAF;  // 파일 레지스터
                case 'Z': return 0xB0;  // 파일 레지스터
            }

            throw new ArgumentOutOfRangeException();
        }

        protected int IndexOf(byte[] dataByte, byte[] searchByte)
        {
            int searchByteCnt = searchByte.Count();
            for (int dataIndex = 0; dataIndex < dataByte.Count() - searchByteCnt + 1; dataIndex++)
            {
                bool match = true;
                for (int searchIndex = 0; searchIndex < searchByteCnt; searchIndex++)
                {
                    if (dataByte[dataIndex + searchIndex] != searchByte[searchIndex])
                    {
                        match = false;
                        break;
                    }
                }

                if (match == true)
                    return dataIndex;
            }

            return -1;
        }
        #endregion
    }
}
