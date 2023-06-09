﻿using Jastech.Framework.Algorithms.Akkon.Parameters;
using Jastech.Framework.Imaging.Result;
using System.Collections.Generic;

namespace Jastech.Framework.Algorithms.Akkon.Results
{
    public class AkkonResult
    {
        #region 속성
        public string UnitName { get; set; }

        public int TabNo { get; set; }

        public AkkonJudgement AkkonCountJudgement { get; set; }

        public int LeftCount_Avg { get; set; }

        public int LeftCount_Min { get; set; }

        public int LeftCount_Max { get; set; }

        public int RightCount_Avg { get; set; }

        public int RightCount_Min { get; set; }

        public int RightCount_Max { get; set; }

        public Judgement LengthJudgement { get; set; }

        public float Length_Left_Avg_um { get; set; }       //um

        public float Length_Left_Min_um { get; set; }      //um

        public float Length_Left_Max_um { get; set; }      //um

        public float Length_Right_Avg_um { get; set; }     //um

        public float Length_Right_Min_um { get; set; }     //um

        public float Length_Right_Max_um { get; set; }     //um

        public List<AkkonLeadResult> LeadResultList = new List<AkkonLeadResult>();
        #endregion

        #region 메서드
        public void Dispose()
        {
            LeadResultList.Clear();
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

    public enum AkkonJudgement
    {
        OK = 1,
        NG_Akkon = 2,
        NG_AlignMiss = 3,
        OK_Manual = 4,
    }
}
