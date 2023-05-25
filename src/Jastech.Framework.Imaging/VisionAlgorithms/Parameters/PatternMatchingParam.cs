using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Imaging.VisionAlgorithms.Parameters
{
    public class PatternMatchingParam
    {
        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public double Score { get; set; } = 70;

        [JsonProperty]
        public double MaxAngle { get; set; } = 1;
    }
}
