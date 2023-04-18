using Jastech.Framework.Util.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Macron.Akkon.Parameters
{
    public class AkkonROI
    {
        [JsonProperty]
        public double CornerOriginX { get; set; } = 0.0;    // Left Top

        [JsonProperty]
        public double CornerOriginY { get; set; } = 0.1;    // Left Top

        [JsonProperty]
        public double CornerXX { get; set; } = 0.2;         // Right Top

        [JsonProperty]
        public double CornerXY { get; set; } = 0.3;         // Right Top

        [JsonProperty]
        public double CornerYX { get; set; } = 0.4;         // Left Bottom

        [JsonProperty]
        public double CornerYY { get; set; } = 0.5;         // Left Bottom

        [JsonProperty]
        public double CornerOppositeX { get; set; } = 0.6;  // Right Bottom

        [JsonProperty]
        public double CornerOppositeY { get; set; } = 0.7;   // Right Bottom

        public AkkonROI DeepCopy()
        {
            return JsonConvertHelper.DeepCopy(this) as AkkonROI;
        }
    }
}
