using Cognex.VisionPro;
using Cognex.VisionPro.PMAlign;
using Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Parameters;
using Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Results;
using System.Diagnostics;
using System.Drawing;

namespace Jastech.Framework.Imaging.VisionPro.VisionAlgorithms
{
    public class VisionProPatternMatching : CogVision
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
        public VisionProPatternMatchingResult Run(ICogImage image, VisionProPatternMatchingParam matchingParam)
        {
            VisionProPatternMatchingResult result = new VisionProPatternMatchingResult();

            if (image == null)
                return result;

            Stopwatch sw = new Stopwatch();
            sw.Restart();

            VisionProPatternMatchingParam copyParam = matchingParam.DeepCopy();
            var tl = copyParam.GetTool();
            tl.RunParams.RunAlgorithm = CogPMAlignRunAlgorithmConstants.PatMax;
            tl.RunParams.ScoreUsingClutter = false;
            //tl.RunParams.AcceptThreshold = 0.3;
            // CopyParam을 Dispose하면 Image 객체가 사라짐. 따라서 Image는 외부에서 Dispose 해줘야함
            copyParam.SetInputImage(image);
            var resultList = copyParam.Run();

            if (resultList == null)
                return null;

            sw.Stop();
            result.TactTime = sw.ElapsedMilliseconds;
            if (resultList.Count > 0)
            {
                VisionProPatternMatchPos match = new VisionProPatternMatchPos();

                CogRectangle trainRoi = copyParam.GetTrainRegion() as CogRectangle;
                var trainOrigin = copyParam.GetOrigin();
                var foundResult = resultList[0];

                match.ReferencePos = new PointF((float)trainOrigin.TranslationX, (float)trainOrigin.TranslationY);
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
