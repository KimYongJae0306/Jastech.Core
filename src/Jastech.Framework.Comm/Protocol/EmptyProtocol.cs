using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Comm.Protocol
{
    public class EmptyProtocol : IProtocol
    {
        public bool MakePacket(byte[] unformattedPacket, out byte[] packet)
        {
            packet = new byte[unformattedPacket.Length];
            if (packet.Length > 0)
            {
                Array.Copy(unformattedPacket, packet, packet.Length);
            }
            return true;
        }

        public bool ParsingReceivedPacket(byte[] packetBuffer, out byte[] packet, out int searchingLength)
        {
            packet = new byte[packetBuffer.Length];
            if (packet.Length > 0)
            {
                Array.Copy(packetBuffer, packet, packet.Length);
            }
            searchingLength = packet.Length;
            return true;
        }
    }
}
