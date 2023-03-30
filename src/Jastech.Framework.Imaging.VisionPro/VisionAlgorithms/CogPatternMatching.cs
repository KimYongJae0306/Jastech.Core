using Cognex.VisionPro;
using Cognex.VisionPro.PMAlign;
using Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Parameters;
using System;
using System.Collections.Generic;
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
        public void Run(ICogImage image, CogPatternMatchingParam matchingParam)
        {
            if (image == null)
                return;
            matchingParam.SetInputImage(image);

            var resultList = matchingParam.Run();

            if(resultList.Count >0)
            {
                var ggg = resultList[0];
                double score = ggg.Score;
                double x = ggg.GetPose().TranslationX;
                double y = ggg.GetPose().TranslationY;
                double y1 = ggg.GetPose().Rotation;
                //resultList[0].Score;
                //resultList[0].
            }
        }
        #endregion
    }
}
