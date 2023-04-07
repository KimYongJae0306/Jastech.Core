using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int PacketResponseTimeMs { get; set; } = 10;
        #endregion

        #region 생성자
        public LightCtrl(string name, int totalChannelCount)
        {
            Name = name;
            TotalChannelCount = totalChannelCount;
        }
        #endregion

        #region 메서드
        public abstract bool TurnOff();

        public abstract bool TurnOn(int channel, int level);

        public abstract bool TurnOff(int channel, int level);
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
            return true;
        }

        public virtual bool Release()
        {
            return true;
        }
        #endregion
    }
}
