using Jastech.Framework.Imaging.Result;
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
        #region 속성
        public int StageNo { get; set; }

        public int TabNo { get; set; }

        public int AvgBlobCount { get; set; }

        public float AvgLength { get; set; }

        public float AvgStrength { get; set; }

        public float AvgStd { get; set; }

        public Judgement Judgement { get; set; }

        public List<LeadResult> LeadResultList = new List<LeadResult>();
        #endregion

        #region 메서드
        public void Dispose()
        {
            LeadResultList.Clear();
        }

        public AkkonResult DeepCopy()
        {
            AkkonResult result = new AkkonResult();
            result.StageNo = StageNo;
            result.TabNo = TabNo;
            result.AvgBlobCount = AvgBlobCount;
            result.AvgLength = AvgLength;
            result.Judgement = Judgement;
            result.LeadResultList = LeadResultList.Select(x => x.DeepCopy()).ToList();

            return result;
        }
        #endregion
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

        public LeadResult DeepCopy()
        {
            LeadResult result = new LeadResult();
            result.Id = Id;
            result.IsGood = IsGood;
            result.AvgStrength = AvgStrength;
            result.LeadAvg = LeadAvg;
            result.LeadStdDev = LeadStdDev;
            result.Length = Length;
            result.BlobCount = BlobCount;

            return result;
        }
    }
}
