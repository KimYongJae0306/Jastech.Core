using Cognex.VisionPro;
using Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Parameters;
using Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Results;
using System.Collections.Generic;
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
                match.ReferenceSkew = roi.Skew;

                match.FoundPos = new PointF((float)foundResult.PositionX, (float)foundResult.PositionY);
                match.Score = (float)foundResult.Score;

                match.ResultGraphics = foundResult.CreateResultGraphics(Cognex.VisionPro.Caliper.CogCaliperResultGraphicConstants.Edges);

                result.CaliperMatchList.Add(match);
            }

            return result;
        }

        public class CogAlignCaliper : CogCaliper
        {
            private List<CogRectangleAffine> DivideRegion(CogRectangleAffine orgRect, int leadCount)
            {
                if (leadCount <= 0)
                    return null;

                List<CogRectangleAffine> divideRegionList = new List<CogRectangleAffine>();

                //tool.Region.CornerXY
                double dNewX = (orgRect.CenterX - orgRect.SideXLength / 2) + orgRect.SideXLength / (leadCount * 2);
                double dNewY = orgRect.CenterY;

                for (int leadIndex = 0; leadIndex < leadCount; leadIndex++)
                {
                    CogRectangleAffine divideRegion = new CogRectangleAffine(orgRect);

                    double dX = orgRect.SideXLength / leadCount * leadIndex * System.Math.Cos(orgRect.Rotation);
                    double dY = orgRect.SideXLength / leadCount * leadIndex * orgRect.Rotation;

                    divideRegion.SideXLength = divideRegion.SideXLength / leadCount;
                    divideRegion.CenterX = dNewX + dX;
                    divideRegion.CenterY = dNewY + dY;

                    divideRegionList.Add(divideRegion);
                }

                return divideRegionList;
            }

            public CogCaliperResult RunAlignX(ICogImage image, CogCaliperParam caliperParam, int leadCount)
            {
                CogRectangleAffine rect = caliperParam.CaliperTool.Region;
                var rectList = DivideRegion(rect, leadCount);

                int totalLeadCount = leadCount * 2;

                for (int leadIndex = 0; leadIndex < totalLeadCount; leadIndex++)
                {
                    if (leadIndex % 2 == 0)
                    {
                        rectList[leadIndex].Rotation = rectList[leadIndex].Rotation - System.Math.PI;

                        if (caliperParam.CaliperTool.RunParams.Edge0Polarity == Cognex.VisionPro.Caliper.CogCaliperPolarityConstants.DarkToLight)
                            caliperParam.CaliperTool.RunParams.Edge0Polarity = Cognex.VisionPro.Caliper.CogCaliperPolarityConstants.LightToDark;
                    }
                    else
                    {
                        if (caliperParam.CaliperTool.RunParams.Edge0Polarity == Cognex.VisionPro.Caliper.CogCaliperPolarityConstants.DarkToLight)
                            caliperParam.CaliperTool.RunParams.Edge0Polarity = Cognex.VisionPro.Caliper.CogCaliperPolarityConstants.LightToDark;
                    }

                    caliperParam.CaliperTool.Region = rectList[leadIndex];
                }

                return Run(image, caliperParam);
            }

            public CogCaliperResult RunAlignY(ICogImage image, CogCaliperParam caliperParam)
            {
                return Run(image, caliperParam);
            }
        }
        #endregion
    }
}
