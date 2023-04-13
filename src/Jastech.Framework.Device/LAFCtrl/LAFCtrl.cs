using Jastech.Framework.Comm.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Jastech.Framework.Device.LAFCtrl
{
    public abstract partial class LAFCtrl : IDevice
    {
        public LAFCtrl(string name)
        {
            Name = name;
        }

        public delegate void LAFEventHandler(string name, byte[] data);

        public event LAFEventHandler DataReceived;

        protected void OnLAFReceived(byte[] data)
        {
            DataReceived?.Invoke(Name, data);
        }
    }

    public abstract partial class LAFCtrl : IDevice
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
