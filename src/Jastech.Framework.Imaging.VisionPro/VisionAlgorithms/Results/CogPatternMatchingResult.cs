using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Results
{
    public class CogPatternMatchingResult
    {
        public TimeSpan TactTime { get; set; }

        public bool Good { get; set; }

        //double x = ggg.GetPose().TranslationX;
        //double y = ggg.GetPose().TranslationY;
        //double y1 = ggg.GetPose().Rotation;
    }
}
