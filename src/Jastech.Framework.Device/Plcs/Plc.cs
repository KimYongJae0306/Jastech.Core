using System;

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

    public abstract partial class Plc : IDisposable
    {
        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 관리형 상태(관리형 개체)를 삭제합니다.
                }

                // TODO: 비관리형 리소스(비관리형 개체)를 해제하고 종료자를 재정의합니다.
                // TODO: 큰 필드를 null로 설정합니다.
                disposedValue = true;
            }
        }

        // // TODO: 비관리형 리소스를 해제하는 코드가 'Dispose(bool disposing)'에 포함된 경우에만 종료자를 재정의합니다.
        // ~Camera()
        // {
        //     // 이 코드를 변경하지 마세요. 'Dispose(bool disposing)' 메서드에 정리 코드를 입력합니다.
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // 이 코드를 변경하지 마세요. 'Dispose(bool disposing)' 메서드에 정리 코드를 입력합니다.
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
