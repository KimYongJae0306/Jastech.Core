using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Device.Motions
{
    public partial class MovingParam
    {
        #region 속성
        [JsonProperty]
        public double JogSpeed { get; set; } = 20;

        [JsonProperty]
        public double Velocity { get; set; } = 20;

        [JsonProperty]
        public double Acceleration { get; set; } = 10;

        [JsonProperty]
        public double Deceleration { get; set; } = 10;

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
        #endregion

    }

    public partial class MovingParam
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
