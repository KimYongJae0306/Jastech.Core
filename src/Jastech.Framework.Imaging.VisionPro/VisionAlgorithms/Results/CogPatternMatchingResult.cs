using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Results
{
    public class CogPatternMatchingResult
    {
        #region 속성
        public long TactTime { get; set; }

        public bool Good { get; set; }

        public List<MatchPos> MatchPosList { get; set; } = new List<MatchPos>();

        public bool Found
        {
            get => MatchPosList.Count() > 0;
        }

        public float MaxScore
        {
            get => MatchPosList.Max(x => x.Score);
        }

        public MatchPos MaxMatchPos
        {
            get
            {
                MatchPos maxMatchPos = new MatchPos();
                foreach (MatchPos matchPos in MatchPosList)
                {
                    if (matchPos.Score > maxMatchPos.Score)
                        maxMatchPos = matchPos;
                }
                return maxMatchPos;
            }
        }
        #endregion
    }

    public class MatchPos
    {
        #region 속성
        public PointF ReferencePos { get; set; }

        public PointF FoundPos { get; set; }

        public float Score { get; set; }

        public float Scale { get; set; }

        public double Angle { get; set; }
        #endregion
    }
}
