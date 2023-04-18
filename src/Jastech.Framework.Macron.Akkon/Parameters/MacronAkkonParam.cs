using AW;
using Jastech.Framework.Util.Helper;
using Newtonsoft.Json;
using System.IO;

namespace Jastech.Framework.Macron.Akkon.Parameters
{
    public class MacronAkkonParam
    {
        [JsonProperty]
        public string Name { get; set; } = string.Empty;

        // Engineer
        [JsonProperty]
        public int JudgeCount { get; set; } = 2;

        [JsonProperty]
        public double JudgeLength { get; set; } = 10.0;

        [JsonProperty]
        public double FilterMinSize { get; set; } = 2.0;

        [JsonProperty]
        public double FilterMaxSize { get; set; } = 15.0;

        [JsonProperty]
        public int WidthCut { get; set; } = 15;

        [JsonProperty]
        public int HeightCut { get; set; } = 15;

        [JsonProperty]
        public double GroupingDistance { get; set; } = 5.0;

        [JsonProperty]
        public float BWRatio { get; set; } = 0.0f;

        [JsonProperty]
        public float StrengthThreshold { get; set; } = 15.0f;

        [JsonProperty]
        public int ExtraLead { get; set; } = 0;

        // Maker
        [JsonProperty]
        public InspectionType InspectionType { get; set; } = InspectionType.THRESHOLD;

        [JsonProperty]
        public PanelType PanelType { get; set; } = PanelType.RIGID;

        [JsonProperty]
        public TargetType TargetType { get; set; } = TargetType.COF;

        [JsonProperty]
        public ShadowDirection ShadowDirection { get; set; } = ShadowDirection.UP;

        [JsonProperty]
        public PeakProperty PeakProperty { get; set; } = PeakProperty.NORMAL;

        [JsonProperty]
        public StrengthBase StrengthBase { get; set; } = StrengthBase.ENH;

        [JsonProperty]
        public FilterType FilterType { get; set; } = FilterType.NORMAL;

        [JsonProperty]
        public bool UseLogTrace { get; set; } = false;

        [JsonProperty]
        public FilterDirection FilterDirection { get; set; } = FilterDirection.HORIZONTAL;

        [JsonProperty]
        public ThresholdMode ThresholdMode { get; set; } = ThresholdMode.AUTO;

        [JsonProperty]
        public double ThresholdWeight { get; set; } = 2.5;

        [JsonProperty]
        public float StrengthScaleFactor { get; set; } = 1.0f;

        [JsonProperty]
        public int ThresholdPeak { get; set; } = 70;

        [JsonProperty]
        public int Overlap { get; set; } = 288;

        [JsonProperty]
        public float StdDevLeadJudge { get; set; } = 0.0f;

        // Option
        [JsonProperty]
        public bool UseDimple { get; set; } = false;

        [JsonProperty]
        public int DimpleNGCount { get; set; } = 0;

        [JsonProperty]
        public int DimpleThreshold { get; set; } = 0;

        [JsonProperty]
        public bool UseAlarm { get; set; } = false;

        [JsonProperty]
        public int AlarmCapacity { get; set; } = 0;

        [JsonProperty]
        public int AlarmNGCount { get; set; } = 0;

        public MacronAkkonParam DeepCopy()
        {
            return JsonConvertHelper.DeepCopy(this) as MacronAkkonParam;
        }
    }

    //public class MacronParam
    //{
    //    // Filter Param
    //    public MVAKKONFILTER AkkonInspectionFilter { get; set; } = null;
    //    public float MinStrength { get; set; } = 0.0f;
    //    public int RawSadowMin { get; set; } = 0;
    //    public float RawStdMax { get; set; } = 0.0f;
    //    public float RawStdMin { get; set; } = 0.0f;
    //    public float RawAvgMax { get; set; } = 0.0f;
    //    public float RawAvgMin { get; set; } = 0.0f;
    //    public int RawUpShootCut { get; set; } = 0;
    //    public int ShadowPeakCut { get; set; } = 0;
    //    public float EnhStdCut { get; set; } = 0.0f;
    //    public float BWRatioMax { get; set; } = 0.0f;
    //    public int WHRawPeakCut { get; set; } = 0;
    //    public int RawPeakCut { get; set; } = 0;
    //    public int HeightCut { get; set; } = 0;
    //    public int WidthCut { get; set; } = 0;
    //    public float ImulSize { get; set; } = 0.0f;
    //    public float AkkonInArea { get; set; } = 0.0f;
    //    public int AkkonInLine { get; set; } = 0;
    //    public int RoiDiv { get; set; } = 0;
    //    public int MinWidth { get; set; } = 0;
    //    public int MinHeight { get; set; } = 0;
    //    public float FilterMinSize { get; set; } = 0.0f;
    //    public float FilterMaxSize { get; set; } = 0.0f;
    //    public double GroupingDistance { get; set; } = 0.0;
    //    public int MinBoundaryOverlap { get; set; } = 0;
    //    public int RawShadowMax { get; set; } = 0;
    //    public bool UseEdgeFARemove { get; set; } = false;
    //    public int EdgeRange { get; set; } = 0;
    //    public int Width { get; set; } = 0;
    //    public int Height { get; set; } = 0;
    //    public float EdgeStrendgthCut { get; set; } = 0.0f;
    //    public int EdgeSizeCut { get; set; } = 0;
    //    public float BWRatio { get; set; } = 0.0f;
    //    public float WHRatio { get; set; } = 0.0f;

    //    // Insp Param
    //    public MVINSPPARA AkkonInspectionParameter { get; set; } = null;
    //    public int FilterDirection { get; set; } = 0;
    //    public int DLPatchSizeX { get; set; } = 0;
    //    public bool EdgeFilp { get; set; } = false;
    //    public int DLSperateCut { get; set; } = 0;
    //    public int DLNetWorkType { get; set; } = 0;
    //    public float DLSizeProb { get; set; } = 0.0f;
    //    public float DLPeakProb { get; set; } = 0.0f;
    //    public bool UseAbsoluteTreshold { get; set; } = false;
    //    public int ImulInspectionThreshold { get; set; } = 0;
    //    public int AbsoluteThresholdLow { get; set; } = 0;
    //    public int AbsoluteThresholdHigh { get; set; } = 0;
    //    public bool ImulInspection { get; set; } = false;
    //    public int IsFlexible { get; set; } = 0;
    //    public float StdDevLeadJudge { get; set; } = 0.0f;
    //    public int RoiDivDistance { get; set; } = 0;
    //    public int ExtraLead { get; set; } = 0;
    //    public int PanelInfo { get; set; } = 0;
    //    public float Postolerance { get; set; } = 0.0f;
    //    public int InflateLeadSize { get; set; } = 0;
    //    public float StrengthScaleFactor { get; set; } = 0.0f;
    //    public int MinShadowWidth { get; set; } = 0;
    //    public int ThresholdPeak { get; set; } = 0;
    //    public PeakProperty PeakProperty { get; set; } = PeakProperty.NORMAL;
    //    public StrengthBase StrengthBase { get; set; } = StrengthBase.ENH;
    //    public ShadowDirection ShadowDirection { get; set; } = ShadowDirection.UP;
    //    public ThresholdMode ThresholdMode { get; set; } = ThresholdMode.AUTO;
    //    public FilterType FilterType { get; set; } = FilterType.NORMAL;
    //    public float StrengthThreshold { get; set; } = 0.0f;
    //    public int ShadowOffset { get; set; } = 0;
    //    public double ThresholdWeight { get; set; } = 0.0;
    //    public int DLPatchSizeY { get; set; } = 0;

    //    // Option Param
    //    public MVINSP_OPTION AkkonInspectionOption { get; set; } = null;
    //    public bool UseLogTrace { get; set; } = false;
    //    public int InspType { get; set; } = 0;
    //    public float InspResizeRatio { get; set; } = 0.0f;
    //    public float PixelResolution { get; set; } = 0.0f;
    //    public int Overlap { get; set; } = 0;
    //    public int RotOffset { get; set; } = 0;
    //}
}
