using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Comm.Protocol
{
    public class SendPacket
    {
        #region 필드 
        private byte[] _data;
        #endregion

        #region 속성
        public string Contents { get; private set; }

        public byte[] Data { get => _data; }
        #endregion

        #region 생성자
        public SendPacket()
        {

        }

        public SendPacket(string contents)
        {
            Contents = contents;
            _data = Encoding.UTF8.GetBytes(contents);
        }

        public SendPacket(byte[] data)
        {
            Contents = Encoding.Default.GetString(data);
            _data = data;
        }

        public override string ToString()
        {
            return Contents;
        }
        #endregion
    }

    public class ReceivedPacket
    {
        public byte[] ReceivedDataByte { get; set; }

        public string ReceivedData { get; set; }
    }
}
