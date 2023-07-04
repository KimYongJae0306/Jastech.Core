using Newtonsoft.Json;

namespace Jastech.Framework.Device
{
    public interface IDevice
    {
        #region 속성
        [JsonProperty]
        string Name { get; }
        #endregion

        #region 메서드
        bool Initialize();

        bool Release();
        #endregion
    }

    public enum DeviceComm
    {
        Serial,
    }
}
