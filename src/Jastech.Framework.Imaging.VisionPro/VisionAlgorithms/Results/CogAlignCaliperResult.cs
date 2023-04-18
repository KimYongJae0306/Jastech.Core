using Jastech.Framework.Imaging.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Results
{
    public class CogAlignCaliperResult : VisionResult
    {
        public List<VisionProCaliperResult> CogAlignResult { get; private set; } = new List<VisionProCaliperResult>();

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
