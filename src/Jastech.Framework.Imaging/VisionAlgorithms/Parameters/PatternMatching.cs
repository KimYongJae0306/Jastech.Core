using Newtonsoft.Json;

namespace Jastech.Framework.Imaging.VisionAlgorithms.Parameters
{
    public class PatternMatching
    {
        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public double Score { get; set; } = 70;

        [JsonProperty]
        public double MaxAngle { get; set; } = 1;
    }
}
