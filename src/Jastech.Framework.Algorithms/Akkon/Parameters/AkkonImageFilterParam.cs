﻿using Newtonsoft.Json;

namespace Jastech.Framework.Algorithms.Akkon.Parameters
{
    public class AkkonImageFilterParam
    {
        [JsonProperty]
        public string Name { get; set; } = "";

        [JsonProperty]
        public double Sigma { get; set; } = 2.0;

        [JsonProperty]
        public int GusWidth { get; set; } = 6;

        [JsonProperty]
        public int LogWidth { get; set; } = 16;

        [JsonProperty]
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
