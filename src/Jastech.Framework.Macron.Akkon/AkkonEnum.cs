using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Macron.Akkon
{
    public enum ROICloneDirection
    {
        Horizontal,
        Vertical,
    }

    public enum InspectionType
    {
        THRESHOLD,
        DL_MODE_0,
        DL_MODE_1,
        DL_MODE_2,
    }

    public enum PanelType
    {
        RIGID,
        FLEXIBLE,
    }

    public enum TargetType
    {
        COF,
        COG,
        FOG,
    }

    public enum FilterDirection
    {
        HORIZONTAL,
        VERTICAL,
    }
    
    // Maker Insp Param
    public enum PeakProperty
    {
        NORMAL,
        NEAR,
    }

    public enum StrengthBase
    {
        ENH,
        RAW,
    }

    public enum ShadowDirection
    {
        UP,
        DOWN,
        LEFT,
        RIGHT,
    }

    public enum ThresholdMode
    {
        AUTO,
        WHITE,
        BLACK,
    }

    public enum FilterType
    {
        NORMAL,
        SMALL,
        FILTER_2,
        FILTER_3,
        FILTER_4,
        BIG,
    }
}
