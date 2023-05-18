using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Algorithms.Akkon.Parameters
{
    public class AkkonParameters
    {
        public double ResizeRatio { get; set; } = 1.0;

        public FilterDirection FilterDirection { get; set; } = FilterDirection.Vertical;
    }

    public enum FilterDirection
    {
        Vertical,
        Horizontal,
    }
}
