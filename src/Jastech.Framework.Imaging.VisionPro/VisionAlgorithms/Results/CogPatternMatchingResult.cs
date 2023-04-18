using Cognex.VisionPro;
using Jastech.Framework.Imaging.Result;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Results
{
    public class CogPatternMatchingResult : VisionResult
    {
        #region 속성
        public long TactTime { get; set; }

        public List<PatternMatchPos> MatchPosList { get; set; } = new List<PatternMatchPos>();

        public bool Found
        {
            get => MatchPosList.Count() > 0;
        }

        public float MaxScore
        {
            get => MatchPosList.Max(x => x.Score);
        }

        public PatternMatchPos MaxMatchPos
        {
            get
            {
                PatternMatchPos maxMatchPos = new PatternMatchPos();
                foreach (PatternMatchPos matchPos in MatchPosList)
                {
                    if (matchPos.Score > maxMatchPos.Score)
                        maxMatchPos = matchPos;
                }
                return maxMatchPos;
            }
        }
        #endregion
    }

    public class PatternMatchPos
    {
        #region 속성
        public PointF ReferencePos { get; set; }

        public float ReferenceWidth { get; set; }

        public float ReferenceHeight { get; set; }

        public PointF FoundPos { get; set; }

        public float Score { get; set; }

        public float Scale { get; set; }

        public double Angle { get; set; }

        public CogCompositeShape ResultGraphics { get; set; }
        #endregion
    }
}
