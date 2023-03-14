using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Comm.Protocol
{
    public class VieworksVTCameraPortocol : IProtocol
    {
        private SendPacket LastSendPacket = new SendPacket();
        public byte[] SendPacket(SendPacket sendPacket)
        {
            LastSendPacket = sendPacket;
            return sendPacket.Data;
        }

        public ParsingResult ReceivedPacketParsing(PacketBuffer packetBuffer, out ReceivedPacket receivedPacket)
        {
            string prompt = ">";
            string cr = "\r";
            string lf = "\n";
            string errorCmd = ">" + " " + "\r" + " " + "\n";

            receivedPacket = new ReceivedPacket();

            string packetFullDataMsg = packetBuffer.ToString();
            string LastMsg = LastSendPacket.ToString();

            int startIndex = packetFullDataMsg.IndexOf(LastMsg);

            if (startIndex < 0)
            {
                int errorEndIndex = packetFullDataMsg.IndexOf(errorCmd);

                if (errorEndIndex < 0)
                    return ParsingResult.Incomplete;
                else
                {
                    string errorCode = packetFullDataMsg.Substring(0, errorEndIndex);
                    int errStartIndex = errorCode.LastIndexOf("<") + 1;
                    errorCode = errorCode.Substring(errStartIndex, errorCode.Length - errStartIndex);
                    packetBuffer.RemoveData(errorEndIndex + errorCmd.Length);
                    return ParsingResult.Complete;
                }
            }
            else
            {
                string content = packetFullDataMsg.Substring(startIndex + startIndex + LastMsg.Length + cr.Length);
                int endIndex = content.IndexOf(prompt);

                if (endIndex < 0)
                    return ParsingResult.Incomplete;

                content = content.Substring(0, endIndex - lf.Length - cr.Length);

                receivedPacket.ReceivedData = content;
                receivedPacket.ReceivedDataByte = Encoding.UTF8.GetBytes(content);

                packetBuffer.RemoveData(endIndex);

                return ParsingResult.Complete;
            }
        }
    }
}
