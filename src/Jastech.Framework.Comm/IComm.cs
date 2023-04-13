using Jastech.Framework.Comm.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Comm
{
    public interface IComm
    {
        #region 속성
        event ReceivedEventHandler Received;
        #endregion


        #region 메서드
        bool Initialize(IProtocol protocol);

        bool Release();

        bool Connect();

        bool IsConnected();

        bool Disconnect();

        bool Send(byte[] data);

        bool Send(string data);
        #endregion
    }

    public delegate void ReceivedEventHandler(byte[] data);
}
