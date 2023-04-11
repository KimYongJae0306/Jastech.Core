using Cognex.VisionPro;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Results
{
    public class VisionProCaliperResult : VisionResult
    {
        #region 필드
        #endregion

        #region 속성
        public long TactTime { get; set; } = 0;
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

        #region 이벤트
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        #endregion

        #region 메서드
        #endregion

    }

    public class CaliperMatch
    {
        public PointF ReferencePos { get; set; }

        public double ReferenceWidth { get; set; }

        public double ReferenceHeight { get; set; }

        public double ReferenceRotation { get; set; }

        public double ReferenceSkew { get; set; }

        public PointF FoundPos { get; set; }

        public float Score { get; set; }

        public CogCompositeShape ResultGraphics { get; set; }
    }
}

