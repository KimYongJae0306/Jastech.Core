using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Macron.Akkon.Results
{
    public class AkkonResult
    {
        public int StageNo { get; set; }

        public int TabNo { get; set; }

        public int AvgBlobCount { get; set; }

        public float AvgLength { get; set; }

        public List<LeadResult> LeadResultList = new List<LeadResult>();
    }

    public class LeadResult
    {
        public int Id { get; set; }

        public bool IsGood { get; set; }

        public float AvgStrength { get; set; }

        public float LeadAvg { get; set; }

        public float LeadStdDev { get; set; }

        public float Length { get; set; }

        public int BlobCount { get; set; }
    }
}
