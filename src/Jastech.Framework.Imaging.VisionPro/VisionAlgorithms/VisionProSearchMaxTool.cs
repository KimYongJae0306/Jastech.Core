using Cognex.VisionPro;
using Cognex.VisionPro.SearchMax;
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
    public class VisionProSearchMaxTool : CogVision
    {
        public VisionProSearchMaxResult Run(ICogImage image, VisionProSearchMaxToolParam matchingParam)
        {
            VisionProSearchMaxResult result = new VisionProSearchMaxResult();

            if (image == null)
                return result;

            Stopwatch sw = new Stopwatch();
            sw.Restart();

            VisionProSearchMaxToolParam copyParam = matchingParam.DeepCopy();
            copyParam.SetInputImage(image);

            copyParam.GetTool().RunParams.AcceptThreshold = 0.1;

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
                match.ResultGraphics = foundResult.CreateResultGraphics(CogSearchMaxResultGraphicConstants.MatchRegion
                                                                        | CogSearchMaxResultGraphicConstants.Origin);

                result.MatchPosList.Add(match);
            }

            return result;
        }
    }
}
