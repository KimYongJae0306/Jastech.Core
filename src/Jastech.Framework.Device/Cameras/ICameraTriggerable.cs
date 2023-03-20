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
        int TriggerChannel { get; }

        [JsonProperty]
        TriggerMode TriggerMode { get; }

        [JsonProperty]
        TriggerSource TriggerSource { get; }

        void SetTriggerMode(TriggerMode triggerMode);

        void SetTriggerSource(TriggerSource triggerSource);
    }
}
