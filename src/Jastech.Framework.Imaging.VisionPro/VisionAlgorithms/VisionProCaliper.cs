using Cognex.VisionPro;
using Cognex.VisionPro.Caliper;
using Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Parameters;
using Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Results;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace Jastech.Framework.Imaging.VisionPro.VisionAlgorithms
{
    public class VisionProCaliper : CogVision
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
        public VisionProCaliperResult Run(ICogImage image, VisionProCaliperParam caliperParam)
        {
            VisionProCaliperResult result = new VisionProCaliperResult();

            if (image == null)
                return result;

            caliperParam.CaliperTool.LastRunRecordDiagEnable = CogCaliperLastRunRecordDiagConstants.None;

            Stopwatch sw = new Stopwatch();
            sw.Restart();

            caliperParam.SetInputImage(image);
            var resultList = caliperParam.Run();

            sw.Stop();

            result.TactTime = sw.ElapsedMilliseconds;
            if (resultList == null)
                return null;

            if (resultList.Count > 0)
            {
                CaliperMatch match = new CaliperMatch();

                CogRectangleAffine roi = caliperParam.GetRegion() as CogRectangleAffine;
                var foundResult = resultList[0];

                match.ReferencePos = new PointF((float)roi.CenterX, (float)roi.CenterY);
                match.ReferenceWidth = roi.SideXLength;
                match.ReferenceHeight = roi.SideYLength;
                match.ReferenceRotation = roi.Rotation;
                match.ReferenceSkew = roi.Skew;

                match.FoundPos = new PointF((float)foundResult.PositionX, (float)foundResult.PositionY);
                match.Score = (float)foundResult.Score;

                match.ResultGraphics = foundResult.CreateResultGraphics(Cognex.VisionPro.Caliper.CogCaliperResultGraphicConstants.Edges);

                result.CaliperMatchList.Add(match);

                return result;
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}
