using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Device.Motions
{
    public class AxisCommonParams
    {
        [JsonProperty]
        public double JogLowSpeed { get; set; } = 10;

        [JsonProperty]
        public double JogHighSpeed { get; set; } = 20;

        [JsonProperty]
        public double MoveTolerance { get; set; } = 0;

        [JsonProperty]
        public double NegativeLimit { get; set; } = 0;

        [JsonProperty]
        public double PositiveLimit { get; set; } = 100;

        [JsonProperty]
        public double HommingTimeOut { get; set; } = 1 * 1000; //ms

        public AxisCommonParams DeepCopy()
        {
            AxisCommonParams param = new AxisCommonParams();

            param.JogLowSpeed = JogLowSpeed;
            param.JogHighSpeed = JogHighSpeed;
            param.MoveTolerance = MoveTolerance;
            param.NegativeLimit = NegativeLimit;
            param.PositiveLimit = PositiveLimit;
            param.HommingTimeOut = HommingTimeOut;

            return param;
        }

        public void SetCommonParams(AxisCommonParams param)
        {
            this.JogLowSpeed = param.JogLowSpeed;
            this.JogHighSpeed = param.JogHighSpeed;
            this.MoveTolerance = param.MoveTolerance;
            this.NegativeLimit = param.NegativeLimit;
            this.PositiveLimit = param.PositiveLimit;
            this.HommingTimeOut = param.HommingTimeOut;
        }
    }

}
