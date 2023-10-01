using Jastech.Framework.Comm;
using Jastech.Framework.Comm.Protocol;
using Jastech.Framework.Device.Plcs.Melsec.Parsers;
using Newtonsoft.Json;
using System.Threading;

namespace Jastech.Framework.Device.Plcs.Melsec
{
    public class MelsecPlc : Plc
    {
        [JsonProperty]
        public IComm Communication { get; set; } = null;
        
        [JsonProperty]
        public IMelsecParser MelsecParser { get; set; }

        protected IProtocol Protocol { get; set; }

        public MelsecPlc(string name, IComm communication, IMelsecParser melsecParser)
            : base(name)
        {
            Communication = communication;
            MelsecParser = melsecParser;
        }

        public override bool Initialize()
        {
            if (Communication == null)
                return false;

            if(Communication.GetType() == typeof(SocketComm))
            {
                if (MelsecParser.GetType() == typeof(MelsecBinaryParser))
                {
                    Protocol = new StxLtxProtocol(new byte[] { 0x50, 0x00 }, new byte[] { 0xD0, 0x00 }, 2, false);
                    var binaryProtocol = Protocol as StxLtxProtocol;
                    binaryProtocol.Offset = 7;
                    binaryProtocol.UseSwap = false;
                }
                else
                {
                    Protocol = new StxLtxProtocol(new byte[] { 0x35, 0x30, 0x30, 0x30 }, new byte[] { 0x44, 0x30, 0x30, 0x30 }, 4, true);
                    var asciiProtocol = Protocol as StxLtxProtocol;
                    asciiProtocol.Offset = 14;
                    asciiProtocol.UseSwap = false;
                }
            }

            if (Communication == null || Protocol == null)
                return false;
            Communication.Initialize(Protocol);
            Communication.Received += Data_Received;
            return base.Initialize();
        }

        public override bool IsConnected()
        {
            return Communication.IsConnected();
        }

        public override bool Release()
        {
            base.Release();
            Communication.Release();
            return true;
        }

        private void Data_Received(byte[] packet)
        {
            if (MelsecParser.MessageType == MessageType.Read)
            {
                MelsecParser.Parse(packet, out byte[] data);
                OnPlcReceived(data);
            }
        }

        public override void Write(string address, byte[] value)
        {
            MelsecParser.AddressName = address;
            MelsecParser.MessageType = MessageType.Write;
            MelsecParser.Command = 0x1401;
            MelsecParser.SubCommand = 0x0000;
            MelsecParser.DataLength = value.Length / 4;

            MelsecParser.Serialize(value, out byte[] unformattedPacket);
            Protocol.MakePacket(unformattedPacket, out byte[] packet);
            Communication.Send(packet);

            Thread.Sleep(0);
        }

        public override void Read(string address, int length)
        {
            MelsecParser.AddressName = address;
            MelsecParser.MessageType = MessageType.Read;
            MelsecParser.Command = 0x0401;
            MelsecParser.SubCommand = 0x0000;
            MelsecParser.DataLength = length;

            MelsecParser.Serialize(new byte[] { }, out byte[] unformattedPacket);
            Protocol.MakePacket(unformattedPacket, out byte[] packet);
            Communication.Send(packet);
        }

        public override void SendData(byte[] data)
        {
            Communication.Send(data);
        }

        //protected override void Communication_Received(byte[] packet)
        //{
        //    if (MelsecParser.MessageType == MessageType.Read)
        //    {
        //        MelsecParser.Parse(packet, out byte[] data);
        //        OnPlcReceived(data);
        //    }
        //}
    }
}
