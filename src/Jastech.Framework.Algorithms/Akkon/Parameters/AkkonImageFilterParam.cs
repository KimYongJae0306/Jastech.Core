using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Algorithms.Akkon.Parameters
{
    public class AkkonImageFilterParam
    {
        public string Name { get; set; } = "";

        public double Sigma { get; set; } = 2.0;

        public int GusWidth { get; set; } = 6;

        public int LogWidth { get; set; } = 16;

        public double ScaleFactor { get; set; } = 1.3;
    }

    public class AkkonImageKernel
    {
        public string Name { get; set; } = "";

        public int GusSize { get; set; }

        public double GusDivisor { get; set; }

        public short[] GusKernel { get; set; }

        public int LogSize { get; set; }

        public double LogDivisor { get; set; }

        public short[] LogKernel { get; set; }
    }
}
