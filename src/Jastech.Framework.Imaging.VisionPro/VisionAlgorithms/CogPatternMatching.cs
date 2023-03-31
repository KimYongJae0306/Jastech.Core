using Cognex.VisionPro;
using Cognex.VisionPro.PMAlign;
using Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Parameters;
using Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Results;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Imaging.VisionPro.VisionAlgorithms
{
    public class CogPatternMatching : CogVision
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
        public CogPatternMatchingResult Run(ICogImage image, CogPatternMatchingParam matchingParam)
        {
            CogPatternMatchingResult result = new CogPatternMatchingResult();
            if (image == null)
                return result;
            Stopwatch sw = new Stopwatch();
            sw.Restart();

            matchingParam.SetInputImage(image);
            var resultList = matchingParam.Run();

            sw.Stop();
            result.TactTime = sw.ElapsedMilliseconds;
            if (resultList.Count >0)
            {
                PatternMatchPos match = new PatternMatchPos();

                CogRectangle trainRoi = matchingParam.GetTrainRegion() as CogRectangle;
                var foundResult = resultList[0];

                match.ReferencePos = new PointF((float)trainRoi.CenterX, (float)trainRoi.CenterY);
                match.ReferenceWidth = (float)trainRoi.Width;
                match.ReferenceHeight = (float)trainRoi.Height;

                match.FoundPos = new PointF((float)foundResult.GetPose().TranslationX, (float)foundResult.GetPose().TranslationY);
                match.Score = (float)foundResult.Score;
                match.Angle = (float)foundResult.GetPose().Rotation;
                match.Scale = (float)foundResult.GetPose().Scaling;
                match.ResultGraphics = foundResult.CreateResultGraphics(CogPMAlignResultGraphicConstants.MatchRegion
                                                                        | CogPMAlignResultGraphicConstants.Origin);

                result.MatchPosList.Add(match);
            }
            return result;
        }
        #endregion
    }
}
