using Cognex.VisionPro;
using Jastech.Framework.Imaging.Result;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Results
{
    public class VisionProCaliperResult : VisionResult
    {
        #region 속성
        public List<CaliperMatch> CaliperMatchList { get; set; } = new List<CaliperMatch>();

        public bool Found
        {
            get => CaliperMatchList.Count() > 0;
        }

        public float MaxScore
        {
            get => CaliperMatchList.Max(x => x.Score);
        }

        public CaliperMatch MaxCaliperMatch
        {
            get
            {
                CaliperMatch maxCaliperMatch = new CaliperMatch();

                foreach (CaliperMatch caliperMatch in CaliperMatchList)
                {
                    if (caliperMatch.Score > maxCaliperMatch.Score)
                        maxCaliperMatch = caliperMatch;
                }

                return maxCaliperMatch;
            }
        }
        #endregion

        #region 메서드
        public void Dispose()
        {
            CaliperMatchList.ForEach(x => x.Dispose());
            CaliperMatchList.Clear();
        }

        public VisionProCaliperResult DeepCopy()
        {
            VisionProCaliperResult result = new VisionProCaliperResult();
            result.TactTime = TactTime;
            if(CaliperMatchList.Count > 0)
                result.CaliperMatchList = CaliperMatchList?.Select(x => x.DeepCopy()).ToList();
            return result;
        }
        #endregion
    }

    public class CaliperMatch
    {
        #region 속성
        public PointF ReferencePos { get; set; }

        public double ReferenceWidth { get; set; }

        public double ReferenceHeight { get; set; }

        public double ReferenceRotation { get; set; }

        public double ReferenceSkew { get; set; }

        public PointF FoundPos { get; set; }

        public double FoundPosX { get; set; }

        public double FoundPosY { get; set; }

        public float Score { get; set; }

        public CogCompositeShape ResultGraphics { get; set; }
        #endregion

        #region 메서드
        public void Dispose()
        {
            ResultGraphics?.Dispose();
            ResultGraphics = null;
        }

        public CaliperMatch DeepCopy()
        {
            CaliperMatch caliperMatch = new CaliperMatch();

            caliperMatch.ReferencePos = new PointF(ReferencePos.X, ReferencePos.Y);
            caliperMatch.ReferenceWidth = ReferenceWidth;
            caliperMatch.ReferenceHeight = ReferenceHeight;
            caliperMatch.ReferenceRotation = ReferenceRotation;
            caliperMatch.ReferenceSkew = ReferenceSkew;
            caliperMatch.FoundPos = new PointF(FoundPos.X, FoundPos.Y);
            caliperMatch.FoundPosX = FoundPos.X;
            caliperMatch.FoundPosY = FoundPos.Y;
            caliperMatch.Score = Score;
            caliperMatch.ResultGraphics = ResultGraphics?.Copy(CogCopyShapeConstants.GeometryOnly); // 인자 확인 필요
            
            return caliperMatch;
        }
        #endregion
    }
}

