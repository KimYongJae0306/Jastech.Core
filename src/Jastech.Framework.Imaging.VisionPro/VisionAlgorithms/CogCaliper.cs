using Cognex.VisionPro;
using Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Parameters;
using Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Results;
using System.Diagnostics;
using System.Drawing;

namespace Jastech.Framework.Imaging.VisionPro.VisionAlgorithms
{
    public class CogCaliper : CogVision
    {
        #region 필드
        #endregion

        #region 속성
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        #endregion

        #region 메서드
        public CogCaliperResult Run(ICogImage image, CogCaliperParam caliperParam)
        {
            CogCaliperResult result = new CogCaliperResult();

            if (image == null)
                return result;

            Stopwatch sw = new Stopwatch();
            sw.Restart();

            caliperParam.SetInputImage(image);
            var resultList = caliperParam.Run();

            sw.Stop();

            result.TactTime = sw.ElapsedMilliseconds;

            if (resultList.Count > 0)
            {
                CaliperMatch match = new CaliperMatch();

                CogRectangleAffine roi = caliperParam.GetRegion() as CogRectangleAffine;
                var foundResult = resultList[0];

                match.ReferencePos = new PointF((float)roi.CenterX, (float)roi.CenterY);
                match.ReferenceWidth = roi.SideXLength;
                match.ReferenceHeight = roi.SideYLength;
                match.ReferenceRotation = roi.Rotation;
                match.RefercneSkew = roi.Skew;

                match.FoundPos = new PointF((float)foundResult.PositionX, (float)foundResult.PositionY);
                match.Score = (float)foundResult.Score;

                result.CaliperMatchList.Add(match);
            }

            return result;
        }
        #endregion
    }
}
