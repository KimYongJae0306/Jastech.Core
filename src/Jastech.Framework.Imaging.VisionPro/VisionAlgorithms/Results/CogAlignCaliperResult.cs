using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Results
{
    public class CogAlignCaliperResult
    {
        public List<VisionProCaliperResult> CogAlignResult { get; private set; } = new List<VisionProCaliperResult>();

        public Result Judgement { get; set; } = Result.NG;

        public void AddAlignResult(VisionProCaliperResult result)
        {
            CogAlignResult.Add(result);
        }

        public void AddAlignResult(List<VisionProCaliperResult> resultList)
        {
            CogAlignResult.AddRange(resultList);
        }
    }
}
