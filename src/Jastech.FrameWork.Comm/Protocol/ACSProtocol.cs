using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Comm.Protocol
{
    public class ACSSerialProtocol : IProtocol
    {
        public SerialPortInfo PortInfo { get; set; } = new SerialPortInfo();

        public ACSSerialProtocol(SerialPortInfo portInfo)
        {
            PortInfo = portInfo;
        }

        public byte[] SendPacket(SendPacket send)
        {
            // Motion API를 통해 직접 구현됨
            return null;
        }

        public ParsingResult ReceivedPacketParsing(PacketBuffer packetBuffer, out ReceivedPacket receivedPacket)
        {
            // Motion API를 통해 직접 구현됨
            receivedPacket = new ReceivedPacket();
            return ParsingResult.Complete;
        }
    }

    public class ACSTcpIpProtocol : IProtocol
    {
        public TcpIpInfo TcpInfo { get; set; } = new TcpIpInfo();

        public ACSTcpIpProtocol(TcpIpInfo tcpIpInfo)
        {
            TcpInfo = tcpIpInfo;
        }

        public byte[] SendPacket(SendPacket send)
        {
            // Motion API를 통해 직접 구현됨
            return null;
        }

        public ParsingResult ReceivedPacketParsing(PacketBuffer packetBuffer, out ReceivedPacket receivedPacket)
        {
            // Motion API를 통해 직접 구현됨
            receivedPacket = new ReceivedPacket();
            return ParsingResult.Complete;
        }
    }
}
