using System;
using System.Text;

namespace Jastech.Framework.Comm.Protocol
{
    public class ViewworksVTSerialProtocol : IProtocol
    {
        public string LastCommand { get; private set; }

        public bool MakePacket(byte[] unformattedPacket, out byte[] packet)
        {
            packet = new byte[unformattedPacket.Length];
            if (packet.Length > 0)
            {
                Array.Copy(unformattedPacket, packet, packet.Length);
                LastCommand = Encoding.Default.GetString(unformattedPacket).Replace(" ", "");
            }
            else
            {
                LastCommand = "";
            }
            return true;
        }

        public bool ParsingReceivedPacket(byte[] packetBuffer, out byte[] packet, out int searchingLength)
        {
            packet = null;
            searchingLength = -1;

            string orgPacketMsg = Encoding.Default.GetString(packetBuffer);
            string packetMsg = orgPacketMsg.Replace(" ", "");

            string prompt = ">";
            string cr = "<cr>";
            string lf = "<lf>";
            string errorCmd = "><cr><lf>";

            int startIndex = packetMsg.IndexOf(LastCommand);

            if (startIndex < 0)
            {
                int errorEndIndex = packetMsg.IndexOf(errorCmd);
                if(errorEndIndex < 0)
                    return false;
                else
                {
                    string errorCode = packetMsg.Substring(0, errorEndIndex);
                    int errStartIndex = errorCode.LastIndexOf("<") + 1;
                    errorCode = errorCode.Substring(errStartIndex, errorCode.Length - errStartIndex);

                    packet = Encoding.UTF8.GetBytes(errorCode);
                    searchingLength = orgPacketMsg.IndexOf(errorCode) + errorCode.Length;

                    return true;
                }
            }
            else
            {
                int tempIndex = startIndex + LastCommand.Length;
                int tempLength = packetMsg.Length - tempIndex;

                string content = packetMsg.Substring(tempIndex, tempLength);
                int endIndex = content.LastIndexOf(prompt);

                if (endIndex < 0)
                    return false;

                content = content.Substring(0, endIndex - lf.Length - cr.Length);
                content = content.Substring(lf.Length, content.Length - lf.Length);

                int index = content.IndexOf(cr);

                content = content.Substring(0, index);

                packet = Encoding.UTF8.GetBytes(content);

                searchingLength = orgPacketMsg.IndexOf(content) + content.Length;
                return true;
            }
        }
    }
}
