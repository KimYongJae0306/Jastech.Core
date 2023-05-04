using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Macron.Akkon.Results
{
    public class AkkonResult
    {
        [JsonProperty]
        public int StageNo { get; set; }

        [JsonProperty]
        public int TabNo { get; set; }

        [JsonProperty]
        public int AvgBlobCount { get; set; }

        [JsonProperty]
        public float AvgLength { get; set; }

        [JsonProperty]
        public List<LeadResult> LeadResultList = new List<LeadResult>();
    }

    public class LeadResult
    {
        [JsonProperty]
        public int Id { get; set; }

        [JsonProperty]
        public bool IsGood { get; set; }

        [JsonProperty]
        public float AvgStrength { get; set; }

        [JsonProperty]
        public float LeadAvg { get; set; }

        [JsonProperty]
        public float LeadStdDev { get; set; }

        [JsonProperty]
        public float Length { get; set; }

        [JsonProperty]
        public int BlobCount { get; set; }
    }
}
