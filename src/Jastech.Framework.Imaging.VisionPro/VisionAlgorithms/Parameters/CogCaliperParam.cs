using Cognex.VisionPro.Caliper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Parameters
{
    public class CogCaliperParam
    {
        [JsonProperty]
        public string Name { get; set; }

        [JsonIgnore]
        public CogCaliperTool CaliperTool { get; set; } = new CogCaliperTool();

        public CogCaliperParam DeepCopy()
        {
            CogCaliperParam param = new CogCaliperParam();
            param.Name = Name;
            param.MatchingTool = new CogPMAlignTool(MatchingTool);

            return param;
        }
    }
}
