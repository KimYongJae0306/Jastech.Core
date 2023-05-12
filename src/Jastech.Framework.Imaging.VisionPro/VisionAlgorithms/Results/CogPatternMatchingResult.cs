using Cognex.VisionPro;
using Jastech.Framework.Imaging.Result;
using Newtonsoft.Json;
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

        #region 메서드
        public void Dispose()
        {
            MatchPosList.ForEach(x => x.Dispose());
            MatchPosList.Clear();
        }

        public CogPatternMatchingResult DeepCopy()
        {
            CogPatternMatchingResult result = new CogPatternMatchingResult();
            result.TactTime = TactTime;
            result.MatchPosList = MatchPosList.Select(x => x.DeepCopy()).ToList();

            return result;
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

        #region 메서드
        public PointF TranslateOffset()
        {
            return new PointF(ReferencePos.X - FoundPos.X, ReferencePos.Y - FoundPos.Y);
        }

        public void Dispose()
        {
            ResultGraphics?.Dispose();
        }

        public PatternMatchPos DeepCopy()
        {
            PatternMatchPos matchPos = new PatternMatchPos();
            matchPos.ReferencePos = new PointF(ReferencePos.X, ReferencePos.Y);
            matchPos.ReferenceWidth = ReferenceWidth;
            matchPos.ReferenceHeight = ReferenceHeight;
            matchPos.FoundPos = new PointF(FoundPos.X, FoundPos.Y);
            matchPos.Score = Score;
            matchPos.Scale = Scale;
            matchPos.Angle = Angle;
            matchPos.ResultGraphics = ResultGraphics.CopyBase(CogCopyShapeConstants.GeometryOnly) as CogCompositeShape; // 인자 확인 필요

            return matchPos;
        }
        #endregion
    }
}
