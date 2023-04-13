using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Comm.Protocol
{
    public interface IProtocol
    {
        bool MakePacket(byte[] unformattedPacket, out byte[] packet);

        bool ParsingReceivedPacket(byte[] packetBuffer, out byte[] packet, out int searchingLength);
    }
}
