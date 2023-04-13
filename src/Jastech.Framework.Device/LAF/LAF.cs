using Jastech.Framework.Comm.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Jastech.Framework.Device.LAF
{
    public abstract partial class LAF : IDevice
    {
        public LAF(string name)
        {
            Name = name;
        }

        //public delegate void LAFEventHandler(string data);

        //public event LAFEventHandler LAFReceived;

        //protected void OnLAFReceived(string data)
        //{
        //    LAFReceived?.Invoke(data);
        //}
    }

    public abstract partial class LAF : IDevice
    {
        #region 속성
        public string Name { get; protected set; }
        #endregion

        #region 메서드
        public virtual bool Initialize()
        {
            return true;
        }

        public virtual bool IsConnected()
        {
            return true;
        }

        public virtual bool Release()
        {
            return true;
        }
        #endregion
    }
}
