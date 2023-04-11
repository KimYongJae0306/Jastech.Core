using Cognex.VisionPro;
using Cognex.VisionPro.Caliper;
using Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Parameters;
using Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Imaging.VisionPro.VisionAlgorithms
{
    public class CogAlignCaliper : CogCaliper
    {
        public List<VisionProCaliperResult> RunAlignX(ICogImage image, VisionProCaliperParam caliperParam, int leadCount)
        {
            List<VisionProCaliperResult> resultList = new List<VisionProCaliperResult>();

            CogRectangleAffine rect = caliperParam.CaliperTool.Region;
            var rectList = CogImageHelper.DivideRegion(rect, leadCount);

            int totalLeadCount = leadCount * 2;

            CogCaliperPolarityConstants polarityConstants = caliperParam.CaliperTool.RunParams.Edge0Polarity;

            for (int leadIndex = 0; leadIndex < rectList.Count; leadIndex++)
            {
                if (leadIndex % 2 == 0)
                {
                    caliperParam.CaliperTool.RunParams.Edge0Polarity = polarityConstants;

                }
                else
                {
                    if (polarityConstants == CogCaliperPolarityConstants.DarkToLight)
                    {
                        caliperParam.CaliperTool.RunParams.Edge0Polarity = CogCaliperPolarityConstants.LightToDark;
                    }
                    else if (polarityConstants == CogCaliperPolarityConstants.LightToDark)
                    {
                        caliperParam.CaliperTool.RunParams.Edge0Polarity = CogCaliperPolarityConstants.DarkToLight;
                    }
                    else
                    {
                        caliperParam.CaliperTool.RunParams.Edge0Polarity = CogCaliperPolarityConstants.DontCare;
                    }
                }

                caliperParam.CaliperTool.Region = rectList[leadIndex];
                var currentResult = Run(image, caliperParam);

                if (currentResult != null)
                    resultList.Add(currentResult);
            }

            caliperParam.CaliperTool.Region = rect;
            return resultList;
        }

        public VisionProCaliperResult RunAlignY(ICogImage image, VisionProCaliperParam caliperParam)
        {
            return Run(image, caliperParam);
        }
    }
}
