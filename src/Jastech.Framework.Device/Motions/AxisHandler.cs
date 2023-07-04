using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Jastech.Framework.Device.Motions
{
    public class AxisHandler
    {
        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public List<Axis> AxisList { get; private set; } = new List<Axis>();

        public AxisHandler()
        {

        }

        public AxisHandler(string name)
        {
            Name = name;
        }

        public Axis AddAxis(AxisName name, Motion motion, int axisNo, int homeOrder = -1)
        {
            Axis axis = new Axis(name.ToString(), motion, axisNo);
            axis.HomeOrder = homeOrder;
            AxisList.Add(axis);

            return axis;
        }

        public Axis GetAxis(AxisName name)
        {
            if(AxisList.Where(x => x.Name == name.ToString()).Count() > 0)
                return AxisList.Where(x => x.Name == name.ToString()).First();
        
            return null;

        }
    }
}
