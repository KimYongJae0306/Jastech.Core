using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.FrameWork.Config
{
    public enum ProgramType
    {
        None,
        ATT_LINE_PC1,
        QD_LPA_PC1,
        QD_LPA_PC2,
    }

    public class OperationConfig : Config
    {
        #region 속성
        public ProgramType ProgramType { get; set; }

        public bool OverlayImageOnf { get; set; }

        public bool LogMsgOnf { get; set; }

        public bool ManuMatchOnf { get; set; }

        public bool IsLengthCheck { get; set; }

        public bool IsInspectionOn { get; set; }

        public bool IsBmpSave { get; set; }

        public bool IsMapLimit { get; set; }

        public int MapHigh { get; set; }

        public int MapLow { get; set; }

        public bool MapFunctionOnf { get; set; }

        public double MapFunctionData { get; set; }

        public int UVWLimitX { get; set; }

        public int UVWLimitY { get; set; }

        public int UVWLimitT { get; set; }

        public double LimitAngle { get; set; }

        #endregion
    }

    public class QD_LPA_PC1OperationConfig : OperationConfig
    {
        public bool UseLoadingLimit { get; set; }

        public int LoadingLimitX_um { get; set; }

        public int LoadingLimitY_um { get; set; }

        public int InspLowLimit_um { get; set; }

        public int InspHighLimit_um { get; set; }
    }

    public class QD_LPA_PC2OperationConfig : OperationConfig
    {
        public bool UseAlign1AngleLimit { get; set; }

        public float AlignCornerAngleLimit { get; set; }

        public float AlignVerticalAngleLimit { get; set; }
    }
}
