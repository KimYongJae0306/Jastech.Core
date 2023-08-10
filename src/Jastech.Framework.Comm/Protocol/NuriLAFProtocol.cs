using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jastech.Framework.Comm.Protocol
{
    public class NuriLAFProtocol : IProtocol
    {
        private object _lock = new object();
        private string[] RequestDataArray = null;

        public bool MakePacket(byte[] unformattedPacket, out byte[] packet)
        {
            packet = new byte[unformattedPacket.Length];
            if (packet.Length > 0)
            {
                Array.Copy(unformattedPacket, packet, packet.Length);
            }

            string requestData = Encoding.Default.GetString(packet);

            lock (_lock)
            {
                if (requestData.Contains("uc rep"))
                    RequestDataArray = requestData.Split(' '); // 공백으로 메세지 자르기
                else if(requestData.Contains("uc"))
                {
                    RequestDataArray = requestData.Split(' '); // 공백으로 메세지 자르기
                }
                else
                    RequestDataArray = null;
            }

            return true;
        }

        public bool ParsingReceivedPacket(byte[] packetBuffer, out byte[] packet, out int searchingLength)
        {
            //packet = new byte[packetBuffer.Length];
            //if (packet.Length > 0)
            //{
            //    Array.Copy(packetBuffer, packet, packet.Length);
            //}
            //searchingLength = packet.Length;
            //return true;

            packet = null;
            searchingLength = -1;

            if (packetBuffer == null)
                return false;

            if (RequestDataArray == null)
                return false;

            string receiveData = Encoding.Default.GetString(packetBuffer);
            //MLLAF3:
            string crlf = "\r\n";
            //string crlf = "MLLAF";
            int splitIndex = receiveData.IndexOf(crlf);
            if (splitIndex > 0)
            {
                string splitMessage = receiveData.Substring(splitIndex + crlf.Length);

                int count = 0;
                Dictionary<int, int> searchIndexList = new Dictionary<int, int>();

                lock (_lock)
                {
                    if (RequestDataArray == null)
                        return false;
                    foreach (var data in RequestDataArray)
                    {
                        if (data == ";uc")
                            continue;

                        bool isContain = splitMessage.Contains(data);

                        if (isContain)
                            searchIndexList.Add(splitMessage.IndexOf(data), data.Length);
                        else
                            count++;
                    }
                }

                if (count == 0)
                {
                    if (searchIndexList.Count > 0)
                    {
                        int maxKey = searchIndexList.Keys.Max();
                        searchIndexList.TryGetValue(maxKey, out int value);
                        searchingLength = splitIndex + maxKey + value;

                        packet = new byte[splitMessage.Length];

                        Array.Copy(packetBuffer, splitIndex + crlf.Length, packet, 0, packet.Length);

                        return true;
                    }
                }
            }
            return false;
        }
    }
}
