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
        public int SliceWidth { get; set; } = 2048;

        [JsonProperty]
        public int SliceHeight { get; set; } = 3072;

        [JsonProperty]
        public int StageCount { get; set; } = -1;

        [JsonProperty]
        public int TabCount { get; set; } = -1;

        [JsonProperty]
        public int ResizeRatio { get; set; } = 1;

        [JsonProperty]
        public AkkonInspParam InspParam = new AkkonInspParam();

        [JsonProperty]
        public AkkonFilterParam FilterParam = new AkkonFilterParam();

        [JsonProperty]
        public AkkonDrawOption DrawOption = new AkkonDrawOption();

        [JsonProperty]
        public AkkonInspOption InspOption = new AkkonInspOption();

        [JsonProperty]
        public DimpleInspParam DimpleInspParam { get; set; } = new DimpleInspParam();

        public void SetDefaultParameter()
        {
            InspParam.ShadowDir = EN_SHADOWDIR_WRAP._MV_SHADOW_DN;
            InspParam.FilterDir = 1; // 0 Horizontal, 1 Vertical
            InspParam.ThWeight = 1.5;
            InspParam.ShadowOffset = 0;
            InspParam.StrengthThreshold = 0;
            InspParam.PeakProp = EN_PEAK_PROP_WRAP._MV_PEAK_NEAR;
            InspParam.StrengthBase = EN_STRENGTH_BASE_WRAP._MV_STRENGTH_RAW;
            InspParam.ThPeak = 70;
            InspParam.MinShadowWidth = 5;
            InspParam.StrengthScaleFactor = 0.2f;
            InspParam.ExtraLead = 20;
            InspParam.EdgeFlip = false;
            InspParam.StdDevLeadJudge = 0;
            InspParam.PanelInfo = 1;// 0 COF, 1 COG, 2 FOG
            InspParam.IsFlexible = 0; // 0 Rigid, 1 Flexible
            InspParam.AbsoluteThHi = 255;
            InspParam.AbsoluteThLow = 0;
            InspParam.UseAbsTh = false;

            InspParam.DLPeakProb = 0.9f;
            InspParam.DLSizeProb = 0.9f;
            InspParam.DLNetWorkType = 1;
            InspParam.DLSperateCut = 0;
            InspParam.DLPatchSizeX = -1;
            InspParam.DLPatchSizeY = -1;
            InspParam.FilterType = EN_MVFILTERTYPE_WRAP._MV_FILTER_4;
            InspParam.ThMode = EN_THMODE_WRAP._MV_TH_WHITE;

            InspOption.LogTrace = false;
            InspOption.InspType = 0;
            InspOption.InspResizeRatio = 1.0f;
            InspOption.PixelResolution = 0.07f; /*Main.DEFINE.LINE_SCAN_PIXEL_SIZE(0.0035) / Main.DEFINE.CAM_LENS_SCALE(5);*/
            InspOption.Overlap = 0; //  m_vvSliceOverlap[nStageNo][nTapNo];
            InspOption.RotOffset = 0;

            DrawOption.SelectLeadDisplay = false;
            DrawOption.ColorStrength = false;
            DrawOption.FirstLastPoint = false;
            DrawOption.ShadowBox = false;
            DrawOption.ShowSize = false;
            DrawOption.ShowStrength = false;
            DrawOption.Contour = false;
            DrawOption.Center = !DrawOption.Contour;
            DrawOption.DrawBlobNumbering = false;
            DrawOption.PixelSize_um = 0.07f; /*Main.DEFINE.LINE_SCAN_PIXEL_SIZE(0.0035) / Main.DEFINE.CAM_LENS_SCALE(5);*/
            DrawOption.DisplayLength = false;
            DrawOption.Panelnfo = 0;
            DrawOption.ExtraLead = 0;
            DrawOption.DrawResizeRatio = 1.0f;

            FilterParam.MinStrength = InspParam.StrengthThreshold;
            FilterParam.MinSize = 2.0f;
            FilterParam.MaxSize = 20.0f;
            FilterParam.GroupingDistance = 2;
            FilterParam.BWRatio = -100;
            FilterParam.ROIDiv = 0;
            FilterParam.WidthCut = 50;
            FilterParam.HeightCut = 50;
            FilterParam.RawPeakCut = 0;
        }

        public void SetParam(int overlap, float pixelResolution, int panelInfo, int extrLead)
        {
            InspOption.PixelResolution = 0.07f; /*Main.DEFINE.LINE_SCAN_PIXEL_SIZE(0.0035) / Main.DEFINE.CAM_LENS_SCALE(5);*/
            InspOption.Overlap = 0; //  m_vvSliceOverlap[nStageNo][nTapNo];
            DrawOption.PixelSize_um = 0.07f; /*Main.DEFINE.LINE_SCAN_PIXEL_SIZE(0.0035) / Main.DEFINE.CAM_LENS_SCALE(5);*/

            DrawOption.Panelnfo = 0;
            DrawOption.ExtraLead = 0;

            FilterParam.MinStrength = InspParam.StrengthThreshold;
            FilterParam.MinSize = 2.0f;
            FilterParam.MaxSize = 20.0f;
        }

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

    public class AkkonInspParam
    {
        #region 속성
        [JsonProperty]
        public int FilterDir { get; set; } = 1;

        [JsonProperty]
        public int DLPatchSizeX { get; set; } = -1;

        [JsonProperty]
        public bool EdgeFlip { get; set; } = false;

        [JsonProperty]
        public int DLSperateCut { get; set; } = 0;

        [JsonProperty]
        public int DLNetWorkType { get; set; } = 1; // 0 or 1

        [JsonProperty]
        public float DLSizeProb { get; set; } = 0.9f;

        [JsonProperty]
        public float DLPeakProb { get; set; } = 0.9f;

        [JsonProperty]
        public bool UseAbsTh { get; set; } = false;

        [JsonProperty]
        public int ImulInspectionThresh { get; set; }

        [JsonProperty]
        public int AbsoluteThLow { get; set; } = 0;

        [JsonProperty]
        public int AbsoluteThHi { get; set; } = 255;

        [JsonProperty]
        public bool ImulInspection { get; set; }

        [JsonProperty]
        public int IsFlexible { get; set; } = 0; // 0 : Ridig, 1 : Flexible

        [JsonProperty]
        public float StdDevLeadJudge { get; set; } = 0;

        [JsonProperty]
        public int RoiDivDistance { get; set; }

        [JsonProperty]
        public int ExtraLead { get; set; }

        [JsonProperty]
        public int PanelInfo { get; set; } = 1; // 0 : COF, 1 : COG, 2 : FOG

        [JsonProperty]
        public float PosTolerance { get; set; }

        [JsonProperty]
        public int InflateLeadSize { get; set; }

        [JsonProperty]
        public float StrengthScaleFactor { get; set; } = 0.2f;

        [JsonProperty]
        public int MinShadowWidth { get; set; } = 5;

        [JsonProperty]
        public int ThPeak { get; set; } = 70;

        [JsonProperty]
        public EN_PEAK_PROP_WRAP PeakProp { get; set; } = EN_PEAK_PROP_WRAP._MV_PEAK_NEAR;

        [JsonProperty]
        public EN_STRENGTH_BASE_WRAP StrengthBase { get; set; } = EN_STRENGTH_BASE_WRAP._MV_STRENGTH_RAW;

        [JsonProperty]
        public EN_SHADOWDIR_WRAP ShadowDir { get; set; } = EN_SHADOWDIR_WRAP._MV_SHADOW_DN;

        [JsonProperty]
        public EN_THMODE_WRAP ThMode { get; set; } = EN_THMODE_WRAP._MV_TH_WHITE;

        [JsonProperty]
        public EN_MVFILTERTYPE_WRAP FilterType { get; set; } = EN_MVFILTERTYPE_WRAP._MV_FILTER_4;

        [JsonProperty]
        public float StrengthThreshold { get; set; } = 0;

        [JsonProperty]
        public int ShadowOffset { get; set; } = 0;

        [JsonProperty]
        public double ThWeight { get; set; } = 1.5;

        [JsonProperty]
        public int DLPatchSizeY { get; set; } = -1;
        #endregion
    }

    public class AkkonFilterParam
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
        public int WHRawPeakCut { get; set; } = 0;

        [JsonProperty]
        public int RawPeakCut;

        [JsonProperty]
        public int HeightCut { get; set; } = 50;

        [JsonProperty]
        public int WidthCut { get; set; } = 50;

        [JsonProperty]
        public float ImulSize;

        [JsonProperty]
        public float AkkonInArea;

        [JsonProperty]
        public int AkkonInLine;

        [JsonProperty]
        public int ROIDiv { get; set; } = 0;

        [JsonProperty]
        public int MinWidth;

        [JsonProperty]
        public int MinHeight;

        [JsonProperty]
        public float MinSize;

        [JsonProperty]
        public float MaxSize;

        [JsonProperty]
        public double GroupingDistance { get; set; } = 2;

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
        public float BWRatio { get; set; } = -100;

        [JsonProperty]
        public float WHRatio;
        #endregion
    }

    public class AkkonDrawOption
    {
        #region 속성
        [JsonProperty]
        public bool Center { get; set; }

        [JsonProperty]
        public bool Contour { get; set; } = true;

        [JsonProperty]
        public bool ShadowBox { get; set; } = false;

        [JsonProperty]
        public bool FirstLastPoint { get; set; } = false;

        [JsonProperty]
        public bool ColorStrength { get; set; } = false;

        [JsonProperty]
        public float PixelSize_um { get; set; } = 0.0007f; /* = Main.DEFINE.LINE_SCAN_PIXEL_SIZE(0.0035) / Main.DEFINE.CAM_LENS_SCALE(5);*/

        [JsonProperty]
        public bool ShowSize { get; set; } = false;

        [JsonProperty]
        public bool ShowStrength { get; set; } = false;

        [JsonProperty]
        public bool DrawBlobNumbering { get; set; } = false;

        [JsonProperty]
        public bool SelectLeadDisplay = false;

        [JsonProperty]
        public bool DisplayLength { get; set; } = false;

        [JsonProperty]
        public int Panelnfo { get; set; }

        [JsonProperty]
        public int ExtraLead { get; set; }

        [JsonProperty]
        public float DrawResizeRatio { get; set; } //s_fInspResizeRatio
        #endregion

        #region 생성자

        #endregion
    }

    public class AkkonInspOption
    {
        #region 속성
        [JsonProperty]
        public bool LogTrace { get; set; } = false;

        [JsonProperty]
        public int InspType { get; set; } = 0; // 0 ThresholdMode, 1 DLMode0, 2 DLMode1, 3 DLMode2

        [JsonProperty]
        public float InspResizeRatio { get; set; } = 1.0f;

        [JsonProperty]
        public float PixelResolution { get; set; } = 0.0007f; /*Main.DEFINE.LINE_SCAN_PIXEL_SIZE(0.0035) / Main.DEFINE.CAM_LENS_SCALE(5);*/

        [JsonProperty]
        public int Overlap { get; set; } // m_vvSliceOverlap[nStageNo][nTapNo];

        [JsonProperty]
        public int RotOffset { get; set; } = 0;
        #endregion
    }
}
