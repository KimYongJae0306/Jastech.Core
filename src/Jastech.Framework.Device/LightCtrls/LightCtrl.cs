using Jastech.Framework.Comm;
using Jastech.Framework.Comm.Protocol;
using Newtonsoft.Json;
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

            return true;
        }

        public virtual bool Release()
        {
            bool isSuccess = true;

            isSuccess |= Communition.Release();

            return isSuccess;
        }
        #endregion
    }
}
