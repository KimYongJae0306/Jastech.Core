using AW;
using Jastech.Framework.Util.Helper;
using Newtonsoft.Json;

namespace Jastech.Framework.Macron.Akkon.Parameters
{
    public class AkkonParam
    {
        public string Name { get; set; } = string.Empty;

        // Group
        public int GroupCount { get; set; } = 0;

        public int LeadWidth { get; set; } = 0;

        public int LeadHeight { get; set; } = 0;

        public int LeadCount { get; set; } = 0;

        public int LeadPitch { get; set; } = 0;

        // Engineer
        public int JudgeCount { get; set; } = 0;

        public double JudgeLength { get; set; } = 0.0;

        public double FilterMinSize { get; set; } = 0.0;

        public double FilterMaxSize { get; set; } = 0.0;

        public int WidthCut { get; set; } = 0;

        public int HeightCut { get; set; } = 0;

        public double GroupingDistance { get; set; } = 0.0;

        public float BWRatio { get; set; } = 0.0f;

        public float StrengthThreshold { get; set; } = 0.0f;

        public int ExtraLead { get; set; } = 0;

        // Maker
        public InspectionType InspectionType { get; set; } = InspectionType.THRESHOLD;

        public PanelType PanelType { get; set; } = PanelType.RIGID;

        public TargetType TargetType { get; set; } = TargetType.COF;

        public ShadowDirection ShadowDirection { get; set; } = ShadowDirection.UP;

        public PeakProperty PeakProperty { get; set; } = PeakProperty.NORMAL;

        public StrengthBase StrengthBase { get; set; } = StrengthBase.ENH;

        public FilterType FilterType { get; set; } = FilterType.NORMAL;

        public bool UseLogTrace { get; set; } = false;

        public FilterDirection FilterDirection { get; set; } = FilterDirection.HORIZONTAL;

        public ThresholdMode ThresholdMode { get; set; } = ThresholdMode.AUTO;

        public double ThresholdWeight { get; set; } = 0.0;

        public float StrengthScaleFactor { get; set; } = 0.0f;

        public int ThresholdPeak { get; set; } = 0;

        public int Overlap { get; set; } = 0;

        public float StdDevLeadJudge { get; set; } = 0.0f;

        // Option
        public bool UseDimple { get; set; } = false;

        public int DimpleNGCount { get; set; } = 0;

        public int DimpleThreshold { get; set; } = 0;

        public bool UseAlarm { get; set; } = false;

        public int AlarmCapacity { get; set; } = 0;

        public int AlarmNGCount { get; set; } = 0;

        public AkkonParam DeepCopy()
        {
            return JsonConvertHelper.DeepCopy(this) as AkkonParam;
        }
    }

    public class MacronParam
    {
        // Filter Param
        public MVAKKONFILTER AkkonInspectionFilter { get; set; } = null;
        public float MinStrength { get; set; } = 0.0f;
        public int RawSadowMin { get; set; } = 0;
        public float RawStdMax { get; set; } = 0.0f;
        public float RawStdMin { get; set; } = 0.0f;
        public float RawAvgMax { get; set; } = 0.0f;
        public float RawAvgMin { get; set; } = 0.0f;
        public int RawUpShootCut { get; set; } = 0;
        public int ShadowPeakCut { get; set; } = 0;
        public float EnhStdCut { get; set; } = 0.0f;
        public float BWRatioMax { get; set; } = 0.0f;
        public int WHRawPeakCut { get; set; } = 0;
        public int RawPeakCut { get; set; } = 0;
        public int HeightCut { get; set; } = 0;
        public int WidthCut { get; set; } = 0;
        public float ImulSize { get; set; } = 0.0f;
        public float AkkonInArea { get; set; } = 0.0f;
        public int AkkonInLine { get; set; } = 0;
        public int RoiDiv { get; set; } = 0;
        public int MinWidth { get; set; } = 0;
        public int MinHeight { get; set; } = 0;
        public float FilterMinSize { get; set; } = 0.0f;
        public float FilterMaxSize { get; set; } = 0.0f;
        public double GroupingDistance { get; set; } = 0.0;
        public int MinBoundaryOverlap { get; set; } = 0;
        public int RawShadowMax { get; set; } = 0;
        public bool UseEdgeFARemove { get; set; } = false;
        public int EdgeRange { get; set; } = 0;
        public int Width { get; set; } = 0;
        public int Height { get; set; } = 0;
        public float EdgeStrendgthCut { get; set; } = 0.0f;
        public int EdgeSizeCut { get; set; } = 0;
        public float BWRatio { get; set; } = 0.0f;
        public float WHRatio { get; set; } = 0.0f;

        // Insp Param
        public MVINSPPARA AkkonInspectionParameter { get; set; } = null;
        public int FilterDirection { get; set; } = 0;
        public int DLPatchSizeX { get; set; } = 0;
        public bool EdgeFilp { get; set; } = false;
        public int DLSperateCut { get; set; } = 0;
        public int DLNetWorkType { get; set; } = 0;
        public float DLSizeProb { get; set; } = 0.0f;
        public float DLPeakProb { get; set; } = 0.0f;
        public bool UseAbsoluteTreshold { get; set; } = false;
        public int ImulInspectionThreshold { get; set; } = 0;
        public int AbsoluteThresholdLow { get; set; } = 0;
        public int AbsoluteThresholdHigh { get; set; } = 0;
        public bool ImulInspection { get; set; } = false;
        public int IsFlexible { get; set; } = 0;
        public float StdDevLeadJudge { get; set; } = 0.0f;
        public int RoiDivDistance { get; set; } = 0;
        public int ExtraLead { get; set; } = 0;
        public int PanelInfo { get; set; } = 0;
        public float Postolerance { get; set; } = 0.0f;
        public int InflateLeadSize { get; set; } = 0;
        public float StrengthScaleFactor { get; set; } = 0.0f;
        public int MinShadowWidth { get; set; } = 0;
        public int ThresholdPeak { get; set; } = 0;
        public PeakProperty PeakProperty { get; set; } = PeakProperty.NORMAL;
        public StrengthBase StrengthBase { get; set; } = StrengthBase.ENH;
        public ShadowDirection ShadowDirection { get; set; } = ShadowDirection.UP;
        public ThresholdMode ThresholdMode { get; set; } = ThresholdMode.AUTO;
        public FilterType FilterType { get; set; } = FilterType.NORMAL;
        public float StrengthThreshold { get; set; } = 0.0f;
        public int ShadowOffset { get; set; } = 0;
        public double ThresholdWeight { get; set; } = 0.0;
        public int DLPatchSizeY { get; set; } = 0;

        // Option Param
        public MVINSP_OPTION AkkonInspectionOption { get; set; } = null;
        public bool UseLogTrace { get; set; } = false;
        public int InspType { get; set; } = 0;
        public float InspResizeRatio { get; set; } = 0.0f;
        public float PixelResolution { get; set; } = 0.0f;
        public int Overlap { get; set; } = 0;
        public int RotOffset { get; set; } = 0;
    }
}
