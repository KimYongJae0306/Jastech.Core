using Jastech.Framework.Util.Helper;

namespace Jastech.Framework.Device.LightCtrls
{
    public class LightCtrlHandler : DeviceHandler<LightCtrl>
    {
        #region 메서드
        public void TurnOn(LightParameter lightParameter)
        {
            foreach (var pair in lightParameter.Map)
            {
                LightCtrl lightCtrl = Get(pair.Key);
                if (lightCtrl == null)
                {
                    Logger.Error(ErrorType.LightCtrl, $"Light controller not found. Name: {pair.Key}");
                    continue;
                }
                LightValue lightValue = pair.Value;
                lightCtrl.TurnOn(lightValue);
            }
        }

        public void TurnOff()
        {
            foreach (var lightCtrl in Devices)
            {
                lightCtrl.TurnOff();
            }
        }
        #endregion
    }
}
