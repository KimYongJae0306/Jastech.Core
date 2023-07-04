using Jastech.Framework.Util.Helper;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Jastech.Framework.Device.LightCtrls
{
    public class LightParameter
    {
        #region 속성
        [JsonProperty]
        public string Name { get; set; } = "";

        [JsonProperty]
        public Dictionary<string, LightValue> Map { get; private set; } = new Dictionary<string, LightValue>();
        #endregion

        #region 생성자
        public LightParameter(string name)
        {
            Name = name;
        }
        #endregion

        #region 메서드
        public void Add(LightCtrl device, LightValue lightValue)
        {
            if (Map.ContainsKey(device.Name))
                return;

            Map[device.Name] = lightValue;
        }

        public void Remove(LightCtrl device)
        {
            if (!Map.ContainsKey(device.Name))
                return;

            Map.Remove(device.Name);
        }

        public LightParameter DeepCopy()
        {
            return JsonConvertHelper.DeepCopy(this) as LightParameter;
        }
        #endregion
    }
}
