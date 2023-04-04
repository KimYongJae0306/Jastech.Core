using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Device.Motions
{
    public class AxisCommonParams
    {
        [JsonProperty]
        public double JogLowSpeed { get; set; } = 10;

        [JsonProperty]
        public double JogHighSpeed { get; set; } = 20;

        [JsonProperty]
        public double MoveTolerance { get; set; } = 0;

        [JsonProperty]
        public double NegativeLimit { get; set; } = 0;

        [JsonProperty]
        public double PositiveLimit { get; set; } = 100;

        [JsonProperty]
        public double HommingTimeOut { get; set; } = 1 * 1000; //ms
    }

}
