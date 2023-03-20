using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
