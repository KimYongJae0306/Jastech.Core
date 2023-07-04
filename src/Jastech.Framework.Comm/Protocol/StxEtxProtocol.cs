using Jastech.Framework.Util.Helper;
using System;
using System.Text;

namespace Jastech.Framework.Comm.Protocol
{
    public class StxEtxProtocol : IProtocol
    {
        #region 생성자
        public StxEtxProtocol(byte[] sendingStx, byte[] sendingEtx, byte[] receivingStx, byte[] receivingEtx)
        {
            SendingStx = sendingStx;
            SendingEtx = sendingEtx;
            ReceivingStx = receivingStx;
            ReceivingEtx = receivingEtx;
        }
        #endregion


        #region 속성
        private byte[] SendingStx { get; }

        private byte[] SendingEtx { get; }

        private byte[] ReceivingStx { get; }

        private byte[] ReceivingEtx { get; }
        #endregion


        #region 메서드
        public bool MakePacket(byte[] unformattedPacket, out byte[] packet)
        {
            packet = new byte[SendingStx.Length + unformattedPacket.Length + SendingEtx.Length];

            if (unformattedPacket == null)
                return false;
            if (unformattedPacket.Length == 0)
                return false;

            if (SendingStx.Length > 0)
            {
                Array.Copy(SendingStx, 0, packet, 0, SendingStx.Length);
            }
            Array.Copy(unformattedPacket, 0, packet, SendingStx.Length, unformattedPacket.Length);
            if (SendingEtx.Length > 0)
            {
                Array.Copy(SendingEtx, 0, packet, SendingStx.Length + unformattedPacket.Length, SendingEtx.Length);
            }
            else
            {
                Logger.Error(ErrorType.Comm, "Etx는 비어있을 수 없음");
                return false;
            }

            return true;
        }

        public bool ParsingReceivedPacket(byte[] packetBuffer, out byte[] packet, out int searchingLength)
        {
            packet = null;
            searchingLength = -1;
            if (ReceivingStx.Length == 0 && ReceivingEtx.Length == 0)
            {
                Logger.Error(ErrorType.Comm, "Etx는 비어있을 수 없음");
                return false;
            }

            if (packetBuffer == null)
                return false;

            string dataStr = Encoding.Default.GetString(packetBuffer);
            string stxStr = Encoding.Default.GetString(ReceivingStx);
            string etxStr = Encoding.Default.GetString(ReceivingEtx);
            int stxIndex = -1;
            int etxIndex = -1;
            if (ReceivingStx.Length > 0 && ReceivingEtx.Length == 0)
            {
                Logger.Error(ErrorType.Comm, "Etx는 비어있을 수 없음");
                return false;
            }
            else if (ReceivingStx.Length == 0 && ReceivingEtx.Length > 0)
            {
                stxIndex = 0;
                etxIndex = dataStr.IndexOf(etxStr);
            }
            else
            {
                stxIndex = dataStr.IndexOf(stxStr);
                etxIndex = dataStr.IndexOf(etxStr);
            }
            if (stxIndex == -1 || etxIndex == -1)
                return false;

            searchingLength = etxIndex + ReceivingEtx.Length;
            packet = new byte[searchingLength - stxIndex - stxStr.Length - etxStr.Length];
            Array.Copy(packetBuffer, stxIndex + stxStr.Length, packet, 0, packet.Length);
            return true;
        }
        #endregion
    }
}
