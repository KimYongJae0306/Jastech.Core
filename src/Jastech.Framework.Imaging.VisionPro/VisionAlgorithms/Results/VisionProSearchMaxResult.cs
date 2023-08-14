using Jastech.Framework.Imaging.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Results
{
    public class VisionProSearchMaxResult : VisionResult
    {
        #region 속성
        public string Name { get; set; } = "";

        public Judgement Judgement { get; set; } = Judgement.FAIL;

        public List<VisionProPatternMatchPos> MatchPosList { get; set; } = new List<VisionProPatternMatchPos>();

        public bool Found
        {
            get => MatchPosList.Count() > 0;
        }

        public float MaxScore
        {
            get => MatchPosList.Max(x => x.Score);
        }

        public VisionProPatternMatchPos MaxMatchPos
        {
            get
            {
                VisionProPatternMatchPos maxMatchPos = new VisionProPatternMatchPos();
                foreach (VisionProPatternMatchPos matchPos in MatchPosList)
                {
                    if (matchPos.Score > maxMatchPos.Score)
                        maxMatchPos = matchPos;
                }
                return maxMatchPos;
            }
        }
        #endregion

        #region 메서드
        public void Dispose()
        {
            MatchPosList.ForEach(x => x.Dispose());
            MatchPosList.Clear();
        }

        public VisionProPatternMatchingResult DeepCopy()
        {
            VisionProPatternMatchingResult result = new VisionProPatternMatchingResult();
            result.Name = Name;
            result.TactTime = TactTime;
            result.MatchPosList = MatchPosList.Select(x => (VisionProPatternMatchPos)x.DeepCopy()).ToList();

            return result;
        }
        #endregion
    }
}
