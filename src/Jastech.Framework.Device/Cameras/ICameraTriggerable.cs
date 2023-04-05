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
        int TriggerSource { get; }
        //TriggerSource TriggerSource { get; }

        void SetTriggerMode(TriggerMode triggerMode);

        void SetTriggerSource(int triggerSource);
        //void SetTriggerSource(TriggerSource triggerSource);
    }
}
