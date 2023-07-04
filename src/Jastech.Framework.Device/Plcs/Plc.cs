namespace Jastech.Framework.Device.Plcs
{
    public abstract partial class Plc : IDevice
    {
        #region 필드
        #endregion

        #region 속성
        #endregion

        #region 이벤트
        public event PlcEventHandler PlcReceived;
        #endregion

        #region 델리게이트
        public delegate void PlcEventHandler(byte[] data);
        #endregion

        #region 생성자
        public Plc(string name)
        {
            Name = name;
        }
        #endregion

        #region 메서드
        public abstract void Write(string address, byte[] value);

        public abstract void Read(string address, int length);

        public abstract void SendData(byte[] data);

        protected void OnPlcReceived(byte[] data)
        {
            PlcReceived?.Invoke(data);
        }
        #endregion
    }

    public abstract partial class Plc : IDevice
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
            return false;
        }

        public virtual bool Release()
        {
            return true;
        }
        #endregion
    }
}
