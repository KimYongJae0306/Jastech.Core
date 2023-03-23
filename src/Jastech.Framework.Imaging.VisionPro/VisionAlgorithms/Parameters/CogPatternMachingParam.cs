using Cognex.VisionPro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Parameters
{
    public class CogPatternMachingParam
    {
        public double MatchScore { get; set; } = 80;

        public double MaxAngle { get; set; } = 1.0;
    }
}
