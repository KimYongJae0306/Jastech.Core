using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Comm.Protocol
{
    public delegate void DataReceivedDelegate(ReceivedPacket receivedPacket);

    public interface IProtocol
    {
        byte[] SendPacket(SendPacket sendPacket);

        ParsingResult ReceivedPacketParsing(PacketBuffer packetBuffer, out ReceivedPacket receivedPacket);
    }

    public enum ParsingResult
    {
        Complete,
        Incomplete,
        PacketError
    }
}
