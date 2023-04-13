using Jastech.Framework.Comm.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Comm
{
    public class ReceivedPacket
    {
        #region 속성
        private byte[] Buffer { get; set; }
        #endregion


        #region 메서드
        public bool Enqueue(byte[] packet)
        {
            if (packet == null)
                return false;
            if (packet.Length == 0)
                return false;

            int oldBufferLength = Buffer == null ? 0 : Buffer.Length;
            var newBuffer = new byte[oldBufferLength + packet.Length];
            if (oldBufferLength > 0)
            {
                Array.Copy(Buffer, 0, newBuffer, 0, oldBufferLength);
            }
            Array.Copy(packet, 0, newBuffer, oldBufferLength, packet.Length);
            Buffer = newBuffer;
            return true;
        }

        private bool Remove(int length)
        {
            if (length == 0)
                return false;

            int oldBufferLength = Buffer == null ? 0 : Buffer.Length;
            if (oldBufferLength == 0)
                return false;

            int newbufferLength = oldBufferLength - length;
            if (newbufferLength > 0)
            {
                var newBuffer = new byte[oldBufferLength - length];
                Array.Copy(Buffer, length, newBuffer, 0, newBuffer.Length);
                Buffer = newBuffer;
            }
            else
            {
                Buffer = null;
            }
            return true;
        }

        public bool Dequeue(IProtocol protocol, out List<byte[]> datas)
        {
            datas = new List<byte[]>();
            while (true)
            {
                if (Buffer == null)
                    break;
                if (protocol.ParsingReceivedPacket(Buffer, out byte[] data, out int searchingLength) == false)
                    break;

                datas.Add(data);
                Remove(searchingLength);
            }
            return datas.Count > 0;
        }
        #endregion
    }
}
