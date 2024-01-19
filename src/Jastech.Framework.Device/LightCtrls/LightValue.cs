using Jastech.Framework.Util.Helper;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Jastech.Framework.Device.LightCtrls
{
    public class LightValue
    {
        #region 속성
        [JsonProperty]
        public List<int> LightLevels { get; set; } = new List<int>();

        public int ChannelCount { get => LightLevels.Count; }
        #endregion

        #region 생성자
        public LightValue(int channelCount, int defaultValue = 0)
        {
            for (int i = 0; i < channelCount; i++)
            {
                LightLevels.Add(defaultValue);
            }
        }
        #endregion

        #region 메서드
        public void Set(int channel, int level)
        {
            if (channel < 0 || channel >= ChannelCount)
                return;

            LightLevels[channel] = level;
        }

        public int Get(int channel)
        {
            if (channel < 0 || channel >= ChannelCount)
                return 0;

            return LightLevels[channel];
        }

        public void SetAll(int level = 0)
        {
            for (int channel = 0; channel < ChannelCount; channel++)
            {
                LightLevels[channel] = level;
            }
        }

        public void SetZero()
        {
            for (int channel = 0; channel < ChannelCount; channel++)
            {
                LightLevels[channel] = 0;
            }
        }

        public LightCtrl DeepCopy()
        {
            return JsonConvertHelper.DeepCopy(this) as LightCtrl;
        }
        #endregion
    }
}
