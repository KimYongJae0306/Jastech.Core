using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Device.Motions
{
    public partial class AxisMovingParam
    {
        #region 속성
        [JsonProperty]
        public double Velocity { get; set; } = 10;

        [JsonProperty]
        public double Acceleration { get; set; } = 30;

        [JsonProperty]
        public double Deceleration { get; set; } = 30;

        [JsonProperty]
        public double MovingTimeOut { get; set; } = 3 * 1000; // ms

        [JsonProperty]
        public double AferWaitTime { get; set; } = 0; // ms
        #endregion

    }

    public partial class AxisMovingParam
    {
        #region 열거형
        public enum Direction
        {
            CW = -1,
            CCW = 1,
        }

        public enum JogSpeedMode
        {
            Slow,
            Medium,
            Fast
        }

        public enum JogMode
        {
            Jog,
            Increase
        }
        #endregion
    }
}
