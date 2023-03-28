using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Config
{
     public class OperationConfig : Config
    {
        #region 속성
        [JsonProperty]
        public bool VirtualMode { get; set; } = false;

        [JsonProperty]
        public string LastModelName { get; set; } = "";

        [JsonProperty]
        public string SystemVersion { get; set; } = "1.0.0";
        #endregion
    }
}
