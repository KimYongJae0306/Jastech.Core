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

        [JsonProperty]
        public int JudgeCount { get; set; } = 10;

        [JsonProperty]
        public double JudgeLength { get; set; } = 10;
       
        [JsonProperty]
        public bool UseAlarm { get; set; } = false;

        [JsonProperty]
        public int AlarmCapacity { get; set; } = 10;

        [JsonProperty]
        public int AlarmNGCount { get; set; } = 60;

        [JsonProperty]
        public MacronAkkonInspParam InspParam = new MacronAkkonInspParam();

        [JsonProperty]
        public MacronAkkonFilterParam FilterParam = new MacronAkkonFilterParam();

        [JsonProperty]
        public MacronAkkonDrawOption DrawOption = new MacronAkkonDrawOption();

        [JsonProperty]
        public MacronAkkonInspOption InspOption = new MacronAkkonInspOption();

        [JsonProperty]
        public DimpleInspParam DimpleInspParam { get; set; } = new DimpleInspParam();


        public MacronAkkonParam DeepCopy()
        {
            return JsonConvertHelper.DeepCopy(this) as MacronAkkonParam;
        }
    }

    public class DimpleInspParam
    {
        [JsonProperty]
        public bool IsEnable { get; set; } = false;

        [JsonProperty]
        public int NGCount { get; set; } = 10;

        [JsonProperty]
        public int Threshold { get; set; } = 60;
    }

    public class MacronAkkonInspParam
    {
        #region 속성
        [JsonProperty]
        public int FilterDir { get; set; }

        [JsonProperty]
        public int DLPatchSizeX { get; set; }

        [JsonProperty]
        public bool EdgeFlip { get; set; }

        [JsonProperty]
        public int DLSperateCut { get; set; }

        [JsonProperty]
        public int DLNetWorkType { get; set; }

        [JsonProperty]
        public float DLSizeProb { get; set; }

        [JsonProperty]
        public float DLPeakProb { get; set; }

        [JsonProperty]
        public bool UseAbsTh { get; set; }

        [JsonProperty]
        public int ImulInspectionThresh { get; set; }

        [JsonProperty]
        public int AbsoluteThLow { get; set; }

        [JsonProperty]
        public int AbsoluteThHi { get; set; }

        [JsonProperty]
        public bool ImulInspection { get; set; }

        [JsonProperty]
        public int IsFlexible { get; set; }

        [JsonProperty]
        public float StdDevLeadJudge { get; set; }

        [JsonProperty]
        public int RoiDivDistance { get; set; }

        [JsonProperty]
        public int ExtraLead { get; set; }

        [JsonProperty]
        public int PanelInfo { get; set; }

        [JsonProperty]
        public float PosTolerance { get; set; }

        [JsonProperty]
        public int InflateLeadSize { get; set; }

        [JsonProperty]
        public float StrengthScaleFactor { get; set; }

        [JsonProperty]
        public int MinShadowWidth { get; set; }

        [JsonProperty]
        public int ThPeak { get; set; }

        [JsonProperty]
        public EN_PEAK_PROP_WRAP PeakProp { get; set; }

        [JsonProperty]
        public EN_STRENGTH_BASE_WRAP StrengthBase { get; set; }

        [JsonProperty]
        public EN_SHADOWDIR_WRAP ShadowDir { get; set; }

        [JsonProperty]
        public EN_THMODE_WRAP ThMode { get; set; }

        [JsonProperty]
        public EN_MVFILTERTYPE_WRAP FilterType { get; set; }

        [JsonProperty]
        public float StrengthThreshold { get; set; }

        [JsonProperty]
        public int ShadowOffset { get; set; }

        [JsonProperty]
        public double ThWeight { get; set; }

        [JsonProperty]
        public int DLPatchSizeY { get; set; }
        #endregion
    }

    public class MacronAkkonFilterParam
    {
        #region 속성
        [JsonProperty]
        public float MinStrength;

        [JsonProperty]
        public int RawShadowMin;

        [JsonProperty]
        public float RawStdMax;

        [JsonProperty]
        public float RawStdMin;

        [JsonProperty]
        public float RawAvgMax;

        [JsonProperty]
        public float RawAvgMin;

        [JsonProperty]
        public int RawUpShootcut;

        [JsonProperty]
        public int ShadowPeakcut;

        [JsonProperty]
        public float Enhstdcut;

        [JsonProperty]
        public float BWRatioMax;

        [JsonProperty]
        public int WHRawPeakCut;

        [JsonProperty]
        public int RawPeakCut;

        [JsonProperty]
        public int HeightCut;

        [JsonProperty]
        public int WidthCut;

        [JsonProperty]
        public float ImulSize;

        [JsonProperty]
        public float AkkonInArea;

        [JsonProperty]
        public int AkkonInLine;

        [JsonProperty]
        public int ROIDiv;

        [JsonProperty]
        public int MinWidth;

        [JsonProperty]
        public int MinHeight;

        [JsonProperty]
        public float MinSize;

        [JsonProperty]
        public float MaxSize;

        [JsonProperty]
        public double GroupingDistance;

        [JsonProperty]
        public int MinBoundaryOverlap;

        [JsonProperty]
        public int RawShadowMax;

        [JsonProperty]
        public bool UseEdgeFARemove;

        [JsonProperty]
        public int EdgeRange;

        [JsonProperty]
        public int Width;

        [JsonProperty]
        public int Height;

        [JsonProperty]
        public float EdgeStrengthCut;

        [JsonProperty]
        public int EdgeSizeCut;

        [JsonProperty]
        public float BWRatio;

        [JsonProperty]
        public float WHRatio;
        #endregion
    }

    public class MacronAkkonDrawOption
    {
        #region 속성
        [JsonProperty]
        public bool Center;

        [JsonProperty]
        public bool Contour;

        [JsonProperty]
        public bool ShadowBox;

        [JsonProperty]
        public bool FirstLastPoint;

        [JsonProperty]
        public bool ColorStrength;

        [JsonProperty]
        public float PixelSize_um;

        [JsonProperty]
        public bool ShowSize;

        [JsonProperty]
        public bool ShowStrength;

        [JsonProperty]
        public bool DrawBlobNumbering;

        [JsonProperty]
        public bool SelectLeadDisplay;

        [JsonProperty]
        public bool DisplayLength;

        [JsonProperty]
        public int Panelnfo;

        [JsonProperty]
        public int ExtraLead;

        [JsonProperty]
        public float DrawResizeRatio;
        #endregion
    }

    public class MacronAkkonInspOption
    {
        #region 속성
        [JsonProperty]
        public bool LogTrace;

        [JsonProperty]
        public int InspType;

        [JsonProperty]
        public float InspResizeRatio;

        [JsonProperty]
        public float PixelResolution;

        [JsonProperty]
        public int Overlap;

        [JsonProperty]
        public int RotOffset;
        #endregion
    }

}
