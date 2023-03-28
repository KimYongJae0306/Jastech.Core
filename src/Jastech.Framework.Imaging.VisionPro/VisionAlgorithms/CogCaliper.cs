using Cognex.VisionPro;
using Cognex.VisionPro.Caliper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Imaging.VisionPro.VisionAlgorithms
{
    public class CogCaliper : CogVision
    {
        #region 필드
        public CogCaliperTool CaliperTool { get; set; }
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
        public CogCaliperTool SetRegion(CogRectangleAffine roi)
        {
            CogRectangleAffine rect = new CogRectangleAffine(roi);
            rect.Color = CogColorConstants.Green;
            rect.LineStyle = CogGraphicLineStyleConstants.Dot;

            CaliperTool.Region = new CogRectangleAffine(rect);
            CaliperTool.CurrentRecordEnable = CogCaliperCurrentRecordConstants.InputImage | CogCaliperCurrentRecordConstants.Region;

            return CaliperTool;
        }

        public ICogRegion GetRegion()
        {
            return CaliperTool.Region;
        }
        #endregion
    }
}
