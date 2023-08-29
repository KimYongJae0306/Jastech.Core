using Jastech.Framework.Algorithms.Akkon.Parameters;
using Jastech.Framework.Imaging.Result;
using System.Collections.Generic;

namespace Jastech.Framework.Algorithms.Akkon.Results
{
    public class AkkonResult
    {
        #region 속성
        public string UnitName { get; set; }

        public Judgement Judgement { get; set; } = Judgement.NG;

        public int TabNo { get; set; }

        public float ResizeRatio { get; set; }

        public int LeftCount_Avg { get; set; }

        public int LeftCount_Min { get; set; }

        public int LeftCount_Max { get; set; }

        public int RightCount_Avg { get; set; }

        public int RightCount_Min { get; set; }

        public int RightCount_Max { get; set; }

        public float Length_Left_Avg_um { get; set; }       //um

        public float Length_Left_Min_um { get; set; }      //um

        public float Length_Left_Max_um { get; set; }      //um

        public float Length_Right_Avg_um { get; set; }     //um

        public float Length_Right_Min_um { get; set; }     //um

        public float Length_Right_Max_um { get; set; }     //um

        public List<AkkonLeadResult> LeadResultList { get; set; } = new List<AkkonLeadResult>();

        public List<AkkonROI> TrackingROIList { get; set; } = new List<AkkonROI>();
        #endregion

        #region 메서드
        public void Dispose()
        {
            LeadResultList.Clear();
            TrackingROIList.Clear();
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
