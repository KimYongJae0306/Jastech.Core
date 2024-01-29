using Cognex.VisionPro;
using Cognex.VisionPro.Caliper;
using Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Parameters;
using Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Results;
using System.Collections.Generic;
using static Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Parameters.VisionProCaliperParam;

namespace Jastech.Framework.Imaging.VisionPro.VisionAlgorithms
{
    public class CogAlignCaliper : VisionProCaliper
    {
        public List<VisionProCaliperResult> RunAlignX(ICogImage image, VisionProCaliperParam caliperParam, int leadCount, CaliperSearchDirection searchDirecton, bool isPanel)
        {
            List<VisionProCaliperResult> resultList = new List<VisionProCaliperResult>();

            CogRectangleAffine rect = caliperParam.CaliperTool.Region;

            var rectList = VisionProShapeHelper.DivideRegion(rect, leadCount, searchDirecton);
            if (rectList == null)
                return resultList;

            int totalLeadCount = leadCount * 2;

            CogCaliperPolarityConstants polarityConstants = caliperParam.CaliperTool.RunParams.Edge0Polarity;

            for (int leadIndex = 0; leadIndex < rectList.Count; leadIndex++)
            {
                caliperParam.CaliperTool.Region = rectList[leadIndex];
                caliperParam.CaliperTool.LastRunRecordDiagEnable = CogCaliperLastRunRecordDiagConstants.None;

                if (isPanel)
                {
                    caliperParam.CaliperTool.RunParams.SingleEdgeScorers.Clear();
                    var scorerPosition = new CogCaliperScorerPosition();
                    scorerPosition.Enabled = true;

                    var scorerPositionNeg = new CogCaliperScorerPositionNeg();
                    scorerPositionNeg.Enabled = true;
                    scorerPosition.SetXYParameters(0, 0, 10000, 1, 0.1);
                    caliperParam.CaliperTool.RunParams.SingleEdgeScorers.Add(scorerPosition);
                    caliperParam.CaliperTool.RunParams.SingleEdgeScorers.Add(scorerPositionNeg);
                }

                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                sw.Restart();

                var currentResult = Run(image, caliperParam);

                sw.Stop();
                resultList.Add(currentResult);
            }

            caliperParam.CaliperTool.RunParams.Edge0Polarity = polarityConstants;
            caliperParam.CaliperTool.Region = rect;
            return resultList;
        }

        public VisionProCaliperResult RunAlignY(ICogImage image, VisionProCaliperParam caliperParam)
        {
            return Run(image, caliperParam);
        }
    }
}
