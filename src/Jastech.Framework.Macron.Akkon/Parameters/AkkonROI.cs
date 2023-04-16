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
        public double CornerOriginX { get; set; } = 0.0;          // 3251

        [JsonProperty]
        public double CornerOriginY { get; set; } = 0.1;          // 837

        [JsonProperty]
        public double CornerXX { get; set; } = 0.2;         // 3283

        [JsonProperty]
        public double CornerXY { get; set; } = 0.3;         // 837

        [JsonProperty]
        public double CornerOppositeX { get; set; } = 0.4;  // 3530

        [JsonProperty]
        public double CornerOppositeY { get; set; } = 0.5;   // 2435

        [JsonProperty]
        public double CornerYX { get; set; } = 0.6;         // 3498

        [JsonProperty]
        public double CornerYY { get; set; } = 0.7;         // 2435

        public AkkonROI DeepCopy()
        {
            return JsonConvertHelper.DeepCopy(this) as AkkonROI;
        }
    }
}
