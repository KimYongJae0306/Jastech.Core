using Cognex.VisionPro;
using Jastech.Framework.Imaging.Result;
using Jastech.Framework.Imaging.VisionAlgorithms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Results
{
    public class VisionProPatternMatchingResult : VisionResult
    {
        #region 속성
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
            result.TactTime = TactTime;
            result.MatchPosList = MatchPosList.Select(x => (VisionProPatternMatchPos)x.DeepCopy()).ToList();
        
            return result;
        }
        #endregion
    }

    public class VisionProPatternMatchPos : PatternMatchPos
    {
        #region 속성
        public CogCompositeShape ResultGraphics { get; set; }
        #endregion

        #region 메서드
        public override void Dispose()
        {
            ResultGraphics?.Dispose();
        }

        public override PatternMatchPos DeepCopy()
        {
            VisionProPatternMatchPos matchPos = new VisionProPatternMatchPos();

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
