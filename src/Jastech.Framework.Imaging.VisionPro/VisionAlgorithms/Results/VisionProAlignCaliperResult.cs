﻿using Jastech.Framework.Imaging.Result;
using System.Collections.Generic;
using System.Linq;

namespace Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Results
{
    public class VisionProAlignCaliperResult : VisionResult
    {
        #region 속성
        public Judgement Judgement { get; set; } = Judgement.OK;

        public List<VisionProCaliperResult> CogAlignResult { get; private set; } = new List<VisionProCaliperResult>();
        #endregion

        #region 메서드
        public void AddAlignResult(VisionProCaliperResult result)
        {
            if (result == null)
                return;

            CogAlignResult.Add(result);
        }

        public void AddAlignResult(List<VisionProCaliperResult> resultList)
        {
            if (resultList == null)
                return;

            if (resultList.Count <= 0)
                return;

            CogAlignResult.AddRange(resultList);
        }

        public void Dispose()
        {
            CogAlignResult.ForEach(x => x?.Dispose());
            CogAlignResult.Clear();
        }

        public VisionProAlignCaliperResult DeepCopy()
        {
            VisionProAlignCaliperResult result = new VisionProAlignCaliperResult();
            result.CogAlignResult = CogAlignResult?.Select(x => x.DeepCopy()).ToList();

            return result;
        }
        #endregion
    }
}
