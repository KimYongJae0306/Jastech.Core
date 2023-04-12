using AW;
using Newtonsoft.Json;

namespace Jastech.Framework.Macron.Akkon.Parameters
{
    public class AkkonParam
    {
        [JsonProperty]
        public string Name { get; set; } = string.Empty;

        [JsonProperty]
        public double ATTMarkScore { get; set; } = 0.90;

        [JsonProperty]
        public int GroupCount { get; set; } = 5;

        [JsonProperty]
        public int LeadPitch { get; set; } = 0;

        [JsonProperty]
        public double LeadWidth { get; set; } = 0.0;

        [JsonProperty]
        public double LeadHeight { get; set; } = 0.0;



        [JsonProperty]
        public int JudgeCount { get; set; } = 0;

        [JsonProperty]
        public double JudgeLength { get; set; } = 0;

        [JsonIgnore]
        public MVAKKONFILTER AkkonInspectionFilter { get; set; } = new MVAKKONFILTER();

        [JsonIgnore]
        public MVINSPPARA AkkonInspectionParameter { get; set; } = new MVINSPPARA();

        [JsonIgnore]
        public MVINSP_OPTION AkkonInspectionOption { get; set; } = new MVINSP_OPTION();

        [JsonProperty]
        public double JudgeGray { get; set; } = 0;

        [JsonProperty]
        public double JudgeDistribution { get; set; } = 0;

        public void Dispose()
        {
            
        }

        public AkkonParam DeepCopy()
        {
            AkkonParam akkon = new AkkonParam();

            return akkon;
        }
    }
}
