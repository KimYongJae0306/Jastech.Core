using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Comm.Protocol
{
    public class NuriLAFProtocol : IProtocol
    {
        private string[] RequestDataArray = null;

        public bool MakePacket(byte[] unformattedPacket, out byte[] packet)
        {
            packet = new byte[unformattedPacket.Length];
            if (packet.Length > 0)
            {
                Array.Copy(unformattedPacket, packet, packet.Length);
            }

            string requestData = Encoding.Default.GetString(packet);

            if (requestData.Contains("uc rep"))
                RequestDataArray = requestData.Split(' '); // 공백으로 메세지 자르기
            else
                RequestDataArray = null;

            return true;
        }

        public bool ParsingReceivedPacket(byte[] packetBuffer, out byte[] packet, out int searchingLength)
        {
            packet = null;
            searchingLength = -1;

            if (packetBuffer == null)
                return false;

            if(RequestDataArray == null)
            {
                packet = new byte[packetBuffer.Length];
                if (packet.Length > 0)
                {
                    Array.Copy(packetBuffer, packet, packet.Length);
                }
                searchingLength = packet.Length;
                return true;
            }

            string receiveData = Encoding.Default.GetString(packetBuffer);

            bool isAllContain = true;
            Dictionary<int, int> searchIndexList = new Dictionary<int, int>();
            foreach (var data in RequestDataArray)
            {
                bool isContain = receiveData.Contains(data);
                isAllContain |= isContain;

                if (isContain)
                    searchIndexList.Add(receiveData.IndexOf(data), data.Length);
            }

            if (isAllContain)
            {
                if(searchIndexList.Count > 0)
                {
                    int maxKey = searchIndexList.Keys.Max();
                    searchIndexList.TryGetValue(maxKey, out int value);
                    searchingLength = maxKey + value;

                    return true;
                }
                return false;
            }
            else
                return false;
        
        }
    }
}
