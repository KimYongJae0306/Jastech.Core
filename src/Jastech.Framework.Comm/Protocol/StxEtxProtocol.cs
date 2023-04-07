using Jastech.Framework.Util.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Comm.Protocol
{
    public class StxEtxProtocol : IProtocol
    {
        #region 필드
        #endregion

        #region 속성
        public byte[] StartChar { get; set; } = null;

        public byte[] EndChar { get; set; } = null;

        public bool UseChecksum { get; set; } = false;

        public int ChecksumSize { get; set; } = 0;
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        #endregion

        #region 메서드
        public byte[] SendPacket(SendPacket sendPacket)
        {
            if (StartChar != null && EndChar != null)
                return StartChar.Concat(sendPacket.Data).Concat(EndChar).ToArray();
            else if (StartChar != null)
                return StartChar.Concat(sendPacket.Data).ToArray();
            else
                return sendPacket.Data.Concat(EndChar).ToArray();
        }

        public ParsingResult ReceivedPacketParsing(PacketBuffer packetBuffer, out ReceivedPacket receivedPacket)
        {
            receivedPacket = new ReceivedPacket();

            // 종료 문자는 반드시 설정되어야 함
            Debug.Assert(EndChar != null);

            byte[] bufferByte = packetBuffer.FullData;

            int endPos = IndexOf(bufferByte, EndChar);
            if (endPos == -1)
                return ParsingResult.Incomplete;

            int startPos = 0;
            if (StartChar != null && StartChar.Count() > 0)
                startPos = IndexOf(bufferByte, StartChar);

            string packetSample = packetBuffer.GetString(100);

            if (startPos == -1)
            {
                string fullString = System.Text.Encoding.Default.GetString(bufferByte.ToArray());
                int strLen = Math.Min(fullString.Length, 100);

                Logger.Dedug(LogType.Device, String.Format("Invalid Packet : {0}...", packetSample));
                packetBuffer.Clear();

                return ParsingResult.PacketError;
            }

            if (endPos < startPos)
            {
                packetBuffer.RemoveData(startPos + 1);

                return ParsingResult.Incomplete;
            }

            if (StartChar != null)
                startPos += StartChar.Count();

            int length = endPos - startPos;

            Logger.Write(LogType.Device, String.Format("Packet Received {0} - {1} : {2} ...", startPos, endPos, packetSample));

            byte[] packetBody = bufferByte.Skip(startPos).Take(length).ToArray();

            if (UseChecksum)
            {
            }

            receivedPacket.ReceivedDataByte = packetBody;
            receivedPacket.ReceivedData = UTF8Encoding.Default.GetString(packetBody);
            packetBuffer.RemoveData(endPos + EndChar.Length);

            return ParsingResult.Complete;
        }

        int IndexOf(byte[] dataByte, byte[] searchByte)
        {
            for (int dataIndex = 0; dataIndex < dataByte.Count(); dataIndex++)
            {
                if (dataByte[dataIndex] != searchByte[0])
                    continue;

                if (dataByte.Count() - dataIndex < searchByte.Count())
                    return -1;

                bool found = true;
                for (int searchIndex = 0; searchIndex < searchByte.Count(); searchIndex++)
                {
                    if (searchByte[searchIndex] != dataByte[dataIndex + searchIndex])
                    {
                        dataIndex += searchIndex;
                        found = false;
                        break;
                    }
                }

                if (found)
                    return dataIndex;
            }

            return -1;
        }
        #endregion
    }
}
