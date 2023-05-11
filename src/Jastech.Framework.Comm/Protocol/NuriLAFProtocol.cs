﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                else
                    RequestDataArray = null;
            }

            return true;
        }

        public bool ParsingReceivedPacket(byte[] packetBuffer, out byte[] packet, out int searchingLength)
        {
            packet = null;
            searchingLength = -1;

            if (packetBuffer == null)
                return false;

            if(RequestDataArray == null)
                return false;

            string receiveData = Encoding.Default.GetString(packetBuffer);
            string crlf = "\r\n";
            int splitIndex = receiveData.IndexOf(crlf);
            if (splitIndex > 0) 
            {
                string splitMessage = receiveData.Substring(splitIndex + crlf.Length);

                int count = 0;
                Dictionary<int, int> searchIndexList = new Dictionary<int, int>();
               
                lock(_lock)
                {
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
