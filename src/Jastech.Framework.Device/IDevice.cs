using Newtonsoft.Json;
using System;

namespace Jastech.Framework.Device
{
    public interface IDevice : IDisposable
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
