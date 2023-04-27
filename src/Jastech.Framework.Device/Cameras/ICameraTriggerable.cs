using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Device.Cameras
{
    public interface ICameraTriggerable
    {
        [JsonProperty]
        int TriggerChannel { get; set; }

        [JsonProperty]
        TriggerMode TriggerMode { get; set; }

        [JsonProperty]
        int TriggerSource { get; set; }

        void ActiveTriggerCommand();

        void SetTriggerMode(TriggerMode triggerMode);
    }
}
