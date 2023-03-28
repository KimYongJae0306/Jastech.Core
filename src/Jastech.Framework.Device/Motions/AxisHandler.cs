using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Device.Motions
{
    public class AxisHandler
    {
        public string Name { get; set; }

        public List<Axis> AxisList { get; set; } = new List<Axis>();
    }
}
