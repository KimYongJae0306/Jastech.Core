using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.FrameWork.Structure
{
    public class Recipe
    {
        public int ScanCount { get; set; }

        public int TabCount { get; set; }

        public double PatternYSize { get; set; }

        public double MarkToPatternXDistance { get; set; }

        public double MarkToPatternYDistance { get; set; }

        public double PatternToPatternXDistance { get; set; }

        public double PatternToPatternYDistance { get; set; }
    }
}
