using Jastech.Framework.Comm;
using Jastech.Framework.Comm.Protocol;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Jastech.Framework.Device.LightCtrls
{
    public abstract partial class LightCtrl : IDevice
    {
        #region 속성
        [JsonProperty]
        public Dictionary<string, int> ChannelNameMap { get; private set; } = new Dictionary<string, int>();

        [JsonProperty]
        public int TotalChannelCount { get; protected set; }

        [JsonProperty]
        public int LightStableTimeMs { get; set; } = 10;

        [JsonProperty]
        public int PacketResponseTimeMs { get; set; } = 200;

        public IComm Communition { get; set; } = null;

        public IProtocol Protocol { get; set; } = null;
        #endregion

        #region 생성자
        public LightCtrl(string name, int totalChannelCount, IComm comm)
        {
            Name = name;
            TotalChannelCount = totalChannelCount;
            Communition = comm;
        }
        #endregion

        #region 메서드
        public abstract bool TurnOn(LightValue lightValue);

        public abstract bool TurnOff();

        public abstract bool TurnOn(int channel, int level);

        public abstract bool TurnOff(int channel);
        #endregion
    }

    public abstract partial class LightCtrl : IDevice
    {
        #region 속성
        public string Name { get; protected set; }
        #endregion

        #region 메서드
        public virtual bool Initialize()
        {
            if (Protocol == null || Communition == null)
                return false;

            if (Communition.Initialize(Protocol) == false)
                return false;

            bool isConnected = Communition.Connect();
            return isConnected;
        }

        public virtual bool IsConnected()
        {
            return false;
        }

        public virtual bool Release()
        {
            bool isSuccess = true;

            isSuccess |= Communition.Release();

            return isSuccess;
        }
        #endregion
    }

    public abstract partial class LightCtrl : IDisposable
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
            //GC.SuppressFinalize(this);
        }
    }
}
