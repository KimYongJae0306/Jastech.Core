using Jastech.Framework.Util.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Comm.Protocol
{
    public class StxLtxProtocol : IProtocol
    {
        private byte[] SendingStx { get; }

        private byte[] ReceivingStx { get; }

        private int LtxLength { get; }

        private bool Ascii { get; }

        public int Offset { get; set; }

        public bool UseSwap { get; set; }

        public int SwapBytes { get; set; }

        public int SwapUnitBytes { get; set; }

        public StxLtxProtocol(byte[] sendingStx, byte[] receivingStx, int ltxLength, bool ascii = false)
        {
            SendingStx = sendingStx;
            ReceivingStx = receivingStx;
            LtxLength = ltxLength;
            Ascii = ascii;

            if (SendingStx == null)
            {
                SendingStx = new byte[0];
            }
            if (ReceivingStx == null)
            {
                ReceivingStx = new byte[0];
            }
        }

        public bool MakePacket(byte[] unformattedPacket, out byte[] packet)
        {
            packet = new byte[SendingStx.Length + LtxLength + unformattedPacket.Length];
            Array.Copy(SendingStx, 0, packet, 0, SendingStx.Length);

            Array.Copy(unformattedPacket, 0, packet, SendingStx.Length, Offset - SendingStx.Length);
            byte[] ltx = new byte[LtxLength];
            int dataLength = unformattedPacket.Length - Offset + LtxLength;
            if (Ascii)
            {
                ltx = Encoding.Default.GetBytes(dataLength.ToString("X4"));
                Array.Copy(ltx, 0, packet, Offset, ltx.Length);
                Array.Copy(unformattedPacket, Offset - SendingStx.Length, packet, Offset + LtxLength, unformattedPacket.Length - (Offset - SendingStx.Length));
            }
            else
            {
                if (LtxLength > 4)
                    throw new Exception("StxLtxProtocol: MakePacket: 32비트 초과된 LtxLength");

                for (int i = ltx.Length - 1; i >= 0; --i)
                {
                    var andBits = 0xFF << (i * 8);
                    ltx[i] = (byte)((dataLength & andBits) >> (i * 8));
                }
                if (UseSwap)
                {
                    byte[] swapByteArray = SwapByteArray(ltx, SwapBytes, SwapUnitBytes);
                    Array.Copy(swapByteArray, 0, packet, Offset, swapByteArray.Length);
                }
                else
                {
                    Array.Copy(ltx, 0, packet, Offset, ltx.Length);
                }
            }

            Array.Copy(unformattedPacket, Offset - SendingStx.Length, packet, Offset + LtxLength, unformattedPacket.Length - (Offset - SendingStx.Length));
            return true;
        }

        public bool ParsingReceivedPacket(byte[] packetBuffer, out byte[] unformattedPacket, out int searchingLength)
        {
            unformattedPacket = null;
            searchingLength = -1;

            if (packetBuffer == null)
                return false;

            string dataStr = Encoding.Default.GetString(packetBuffer);
            string stxStr = Encoding.Default.GetString(ReceivingStx);
            int stxIndex = dataStr.IndexOf(stxStr);
            int ltxStartIndex = stxIndex + Offset;
            int ltxEndIndex = ltxStartIndex + LtxLength;

            if (stxIndex < 0)
            {
                Logger.Error(ErrorType.Comm, "stx를 찾을 수 없음");
                return false;
            }
            if (ltxEndIndex > packetBuffer.Length)
            {
                Logger.Error(ErrorType.Comm, "ltxEndIndex가 packetBuffer.Length 보다 클 수 없음");
                return false;
            }

            byte[] ltxArray = new byte[LtxLength];
            Array.Copy(packetBuffer, ltxStartIndex, ltxArray, 0, LtxLength);

            int dataLength = -1;
            if (Ascii)
            {
                byte[] dataLengthArray = new byte[LtxLength];
                Array.Copy(packetBuffer, ltxStartIndex, dataLengthArray, 0, dataLengthArray.Length);
                string temp = Encoding.Default.GetString(dataLengthArray);

                if (dataLengthArray.Length == 2)
                {
                    dataLength = Convert.ToInt16(temp, 16);
                }
                else if (dataLengthArray.Length == 4)
                {
                    dataLength = Convert.ToInt32(temp, 16);
                }
            }
            else
            {
                if (UseSwap)
                {
                    byte[] swapByteArray = SwapByteArray(ltxArray, SwapBytes, SwapUnitBytes);

                    if (swapByteArray.Length == 2)
                    {
                        dataLength = (int)BitConverter.ToInt16(swapByteArray, 0);
                    }
                    else if (swapByteArray.Length == 4)
                    {
                        dataLength = (int)BitConverter.ToInt32(swapByteArray, 0);
                    }
                }
                else
                {
                    byte[] dataLengthArray = new byte[LtxLength];
                    Array.Copy(packetBuffer, ltxStartIndex, dataLengthArray, 0, dataLengthArray.Length);

                    if (dataLengthArray.Length == 2)
                    {
                        dataLength = (int)BitConverter.ToInt16(dataLengthArray, 0);
                    }
                    else if (dataLengthArray.Length == 4)
                    {
                        dataLength = (int)BitConverter.ToInt32(dataLengthArray, 0);
                    }
                }
            }

            if (ltxEndIndex + dataLength > packetBuffer.Length)
            {
                Logger.Error(ErrorType.Comm, "Packet 길이 부족함");
                return false;
            }
            searchingLength = ltxEndIndex + (int)dataLength;
            unformattedPacket = new byte[searchingLength - stxIndex];
            Array.Copy(packetBuffer, stxIndex, unformattedPacket, 0, unformattedPacket.Length);

            return true;
        }

        private byte[] SwapByteArray(byte[] data, int swapBytes, int swapUnitBytes)
        {
            byte[] swapData = new byte[data.Length];
            Array.Copy(data, 0, swapData, 0, data.Length);

            if (swapBytes == 0 || swapUnitBytes == 0 || swapBytes >= swapUnitBytes || swapUnitBytes % swapBytes != 0)
                throw new Exception("StxLtxProtocol: MakePacket: 적절하지 않은 swapBytes 혹은 swapUnitBytes");

            int swapIterCount = swapData.Length / swapUnitBytes;
            for (int swapIter = 0; swapIter < swapIterCount; ++swapIter)
            {
                var sub = new byte[swapUnitBytes];
                Array.Copy(swapData, swapIter * swapUnitBytes, sub, 0, swapUnitBytes);
                Array.Reverse(sub);
                Array.Copy(sub, 0, swapData, swapIter * swapUnitBytes, sub.Length);
            }

            return swapData;
        }
    }
}
