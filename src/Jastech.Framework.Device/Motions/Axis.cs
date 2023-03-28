using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Device.Motions
{
    public class AxisParam
    {
        [JsonProperty]
        public double MoveTolerance { get; set; } = 0;

        [JsonProperty]
        public double NegativeSWLimit { get; set; } = 0;

        [JsonProperty]
        public double PositiveSWLimit { get; set; } = 100;

        [JsonProperty]
        public double HomingTimeOut { get; set; } = 120;

        [JsonProperty]
        public double MovingTimeOut { get; set; } = 10;

        [JsonProperty]
        public double AfterWaitTime { get; set; } = 0;

        [JsonProperty]
        public double CenterOfGravity { get; set; } = 0;
    }
    public class Axis
    {
        #region 속성
        public string Name { get; private set; }

        public Motion Motion { get; private set; }

        public int AxisNo { get; private set; }

        public AxisParam AxisParam { get; set; } = new AxisParam();
        #endregion

        #region 생성자 
        public Axis(string name, Motion motion, int axisNo)
        {
            Name = name;
            Motion = motion;
            AxisNo = axisNo;
        }

        public bool StartMove(float position, MovingParam movingParam = null)
        {
            Motion.MoveTo(AxisNo, position, movingParam.Velocity, movingParam.Acceleration);

            return true;
        }
        #endregion
    }
}
