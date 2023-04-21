using AW;
using Jastech.Framework.Imaging.Helper;
using Jastech.Framework.Macron.Akkon.Parameters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Macron.Akkon
{
    public partial class MacronAkkon
    {
        public static CATTWrapper ATTWrapper { get; private set; } = new CATTWrapper();

        public static CALLBACKFUNC cb { get; private set; } = new CALLBACKFUNC(cbProgress);

        public static MacronAkkonPrepareInspParam PrevinitalizeParam { get; private set; } = new MacronAkkonPrepareInspParam();

        private static void cbProgress(int nStageNo, int nTabNo, bool bSliceInsp, int nError)
        {
            unsafe
            {

            }
        }

        /// <summary>
        /// 검사 Thread 생성
        /// </summary>
        /// <param name="pHandle">실행 프로그램의 핸들</param>
        /// <param name="nThreadCnt">검사에 사용할 Thread 개수</param>
        /// <param name="nCoreMask">Thread에 할당할 Core Number</param>
        public void ATT_InitSystem(IntPtr pHandle, int nThreadCnt, UInt32 nCoreMask)
        {
            ATTWrapper.AWCreateProcessingThread();
            ATTWrapper.AWCreateAttThread(pHandle, nThreadCnt, nCoreMask);
            NativeMethods.CallBackRegistry(cb);

        }

        public void CreateDllBuffer(MacronAkkonPrepareInspParam param)
        {
            if (IsNewInitalizeParam(param))
                return;
          
            // Release();

            ATTWrapper.AWFreeInspectionFlag();
            ATTWrapper.AWDeleteInspManager();
            ATTWrapper.AWCreateInspManager(param.StageCount, param.TabCount);
            ATTWrapper.AWCreateAttSliceImageBuffer(param.TabCount, param.ThreadCount, param.SliceWidth, param.SliceHeight, param.ResizeRatio);

            PrevinitalizeParam = param;
        }

        private bool IsNewInitalizeParam(MacronAkkonPrepareInspParam param)
        {
            if (PrevinitalizeParam.StageCount == param.StageCount && PrevinitalizeParam.TabCount == param.TabCount 
                            && PrevinitalizeParam.ThreadCount == param.ThreadCount && PrevinitalizeParam.SliceWidth == param.SliceWidth
              && PrevinitalizeParam.SliceHeight == param.SliceHeight && PrevinitalizeParam.ResizeRatio == param.ResizeRatio)
                return false;

            return true;
        }

        public void CreateImageBuffer(int stageNo, int tabNo, int imageWidth, int imageHeight, float resizeRatio)
        {
            ATTWrapper.AWCreateAttFullImageBuffer(stageNo, tabNo, imageWidth, imageHeight, resizeRatio);
        }

        public int[][] CalcATTROI(MacronAkkonGroup group, int stageNo, int tabNo, PointF centerPoint, PointF offset, double angle)
        {
            int leadCount = group.AkkonROIList.Count();

            int[][] leadPoints = ConvertROI(leadCount, group, centerPoint, offset, angle);

            return leadPoints;

//            ATTWrapper.AWReadROI(stageNo, tabNo, leadPoints, 1); 
        }

        //public int PrepareInspect(ref int[][] sliceCounts, int stageNo, int tabNo, int imageWidth, int imageHeight, float resizeRatio)
        //{
        //    int overlap = ATTWrapper.AWCalcSliceOverlap(stageNo, tabNo);

        //    int totalSliceCount = ATTWrapper.AWCalcTotalSliceCnt(stageNo, tabNo, overlap, imageWidth, imageHeight, false);
        //    sliceCounts[stageNo][tabNo] = totalSliceCount;


        //    //ATTWrapper.AWAllocInspectionFlag(totalSliceCount);
        //    return totalSliceCount;
        //}

        static List<List<int>> m_vvSliceOverlap;
        static List<List<int>> m_vvTotalSliceCnt;
        public bool PrepareInspect(MacronAkkonPrepareInspParam param, int stageNo, int[][] leadPoints)
        {
            CreateDllBuffer(param);

            List<int> tabSliceOverLapList = new List<int>();
            List<int> tabTotalSliceCountList = new List<int>();

            for (int tabNo = 0; tabNo < param.TabCount; tabNo++)
            {
                ATTWrapper.AWCreateAttFullImageBuffer(stageNo, tabNo, param.SliceWidth, param.SliceHeight, param.ResizeRatio);

                bool readRoi = ATTWrapper.AWReadROI(stageNo, tabNo, leadPoints, 1);// AWReadROI ResizeRatio : 1 로 고정(Macron 측과 약속)

                if (readRoi == false)
                {
                    Logger.Error(ErrorType.Macron, "AW ReadROI Fail.");
                    return false;
                }

                int overlap = ATTWrapper.AWCalcSliceOverlap(stageNo, tabNo);
                int calcTotalSliceCount = ATTWrapper.AWCalcTotalSliceCnt(stageNo, tabNo, overlap, param.SliceWidth, param.SliceHeight, false);

                tabSliceOverLapList.Add(overlap);
                tabTotalSliceCountList.Add(calcTotalSliceCount);
            }

           

            int totalSliceCount = ATTWrapper.AWCalcTotalSliceCnt(stageNo, tabNo, overlap, imageWidth, imageHeight, false);
            sliceCounts[stageNo][tabNo] = totalSliceCount;


            //ATTWrapper.AWAllocInspectionFlag(totalSliceCount);
            return totalSliceCount;
        }


        public void Inspection(byte[] imageBytes, int imageWidth, int imageHeight,int stageNo, int tabNo, float resizeRatio)
        {
           // int totalSliceCount =  PrepareInspect(stageNo, tabNo, imageWidth, imageHeight, resizeRatio);
        }
        public void SetParam(int stageNo, int tabNo, MacronAkkonParam param)
        {
            var inspParam = GetCovertInspParamToMacron(param.InspParam);
            var filterParam = GetConvertFilterParamToMacron(param.FilterParam);
            var drawOption = GetConvertDrawOptionToMacron(param.DrawOption);
            var inspOption = GetCovertInspOptionToMacron(param.InspOption);

            ATTWrapper.AWSetAllPara(stageNo, tabNo, ref inspParam, ref filterParam, ref drawOption, ref inspOption);
        }
    }

    public partial class MacronAkkon
    {
        private MVINSPPARA GetCovertInspParamToMacron(MacronAkkonInspParam param)
        {
            MVINSPPARA inspParam = new MVINSPPARA();

            inspParam.s_nFilterDir = param.FilterDir;
            inspParam.s_nDLPatchSizeX = param.DLPatchSizeX;
            inspParam.s_bEdgeFlip = param.EdgeFlip;
            inspParam.s_nDLSperateCut = param.DLSperateCut;
            inspParam.s_nDLNetWorkType = param.DLNetWorkType;
            inspParam.s_fDLSizeProb = param.DLSizeProb;
            inspParam.s_fDLPeakProb = param.DLPeakProb;
            inspParam.s_bUseAbsTh = param.UseAbsTh;
            inspParam.s_nImulInspectionThresh = param.ImulInspectionThresh;
            inspParam.s_nAbsoluteThLow = param.AbsoluteThLow;
            inspParam.s_nAbsoluteThHi = param.AbsoluteThHi;
            inspParam.s_bImulInspection = param.ImulInspection;
            inspParam.s_nIsFlexible = param.IsFlexible;
            inspParam.s_fStdDevLeadJudge = param.StdDevLeadJudge;
            inspParam.s_nRoiDivDistance = param.RoiDivDistance;
            inspParam.s_nExtraLead = param.ExtraLead;
            inspParam.s_nPanelInfo = param.PanelInfo;
            inspParam.s_fPosTolerance = param.PosTolerance;
            inspParam.s_nInflateLeadSize = param.InflateLeadSize;
            inspParam.s_fStrengthScaleFactor = param.StrengthScaleFactor;
            inspParam.s_nMinShadowWidth = param.MinShadowWidth;
            inspParam.s_nThPeak = param.ThPeak;
            inspParam.s_ePeakProp = param.PeakProp;
            inspParam.s_eStrengthBase = param.StrengthBase;
            inspParam.s_eShadowDir = param.ShadowDir;
            inspParam.s_eThMode = param.ThMode;
            inspParam.s_eFilterType = param.FilterType;
            inspParam.s_fStrengthThreshold = param.StrengthThreshold;
            inspParam.s_nShadowOffset = param.ShadowOffset;
            inspParam.s_fThWeight = param.ThWeight;
            inspParam.s_nDLPatchSizeY = param.DLPatchSizeY;

            return inspParam;
        }

        private MVAKKONFILTER GetConvertFilterParamToMacron(MacronAkkonFilterParam param)
        {
            MVAKKONFILTER filterParam = new MVAKKONFILTER();

            filterParam.s_fMinStrength = param.MinStrength;
            filterParam.s_fRawShadowMin = param.RawShadowMin;
            filterParam.s_fRawStdMax = param.RawStdMax;
            filterParam.s_fRawStdMin = param.RawStdMin;
            filterParam.s_fRawAvgMax = param.RawAvgMax;
            filterParam.s_fRawAvgMin = param.RawAvgMin;
            filterParam.s_nRawUpShootcut = param.RawUpShootcut;
            filterParam.s_nShadowPeakcut = param.ShadowPeakcut;
            filterParam.s_fEnhstdcut = param.Enhstdcut;
            filterParam.s_fBWRatioMax = param.BWRatioMax;
            filterParam.s_nWHRawPeakCut = param.WHRawPeakCut;
            filterParam.s_nRawPeakCut = param.RawPeakCut;
            filterParam.s_nHeightCut = param.HeightCut;
            filterParam.s_nWidthCut = param.WidthCut;
            filterParam.s_fImulSize = param.ImulSize;
            filterParam.s_fAkkonInArea = param.AkkonInArea;
            filterParam.s_nAkkonInLine = param.AkkonInLine;
            filterParam.s_nROIDiv = param.ROIDiv;
            filterParam.s_nMinWidth = param.MinWidth;
            filterParam.s_nMinHeight = param.MinHeight;
            filterParam.s_fMinSize = param.MinSize;
            filterParam.s_fMaxSize = param.MaxSize;
            filterParam.s_fGroupingDistance = param.GroupingDistance;
            filterParam.s_nMinBoundaryOverlap = param.MinBoundaryOverlap;
            filterParam.s_fRawShadowMax = param.RawShadowMax;
            filterParam.s_bUseEdgeFARemove = param.UseEdgeFARemove;
            filterParam.s_nEdgeRange = param.EdgeRange;
            filterParam.s_nWidth = param.Width;
            filterParam.s_nHeight = param.Height;
            filterParam.s_fEdgeStrengthCut = param.EdgeStrengthCut;
            filterParam.s_fEdgeSizeCut = param.EdgeSizeCut;
            filterParam.s_fBWRatio = param.BWRatio;
            filterParam.s_fWHRatio = param.WHRatio;

            return filterParam;
        }

        private MVDRAWOPTION GetConvertDrawOptionToMacron(MacronAkkonDrawOption param)
        {
            MVDRAWOPTION optionParam = new MVDRAWOPTION();

            optionParam.s_bCenter = param.Center;
            optionParam.s_bContour = param.Contour;
            optionParam.s_bShadowBox = param.ShadowBox;
            optionParam.s_bFirstLastPoint = param.FirstLastPoint;
            optionParam.s_bColorStrength = param.ColorStrength;
            optionParam.s_fPixelSize_um = param.PixelSize_um;
            optionParam.s_bShowSize = param.ShowSize;
            optionParam.s_bShowStrength = param.ShowStrength;
            optionParam.s_bDrawBlobNumbering = param.DrawBlobNumbering;
            optionParam.s_bSelectLeadDisplay = param.SelectLeadDisplay;
            optionParam.s_bDisplayLength = param.DisplayLength;
            optionParam.s_nPanelnfo = param.Panelnfo;
            optionParam.s_nExtraLead = param.ExtraLead;
            optionParam.s_fDrawResizeRatio = param.DrawResizeRatio;

            return optionParam;
        }

        private MVINSP_OPTION GetCovertInspOptionToMacron(MacronAkkonInspOption param)
        {
            MVINSP_OPTION optionParam = new MVINSP_OPTION();

            optionParam.s_bLogTrace = param.LogTrace;
            optionParam.s_nInspType = param.InspType;
            optionParam.s_fInspResizeRatio = param.InspResizeRatio;
            optionParam.s_fPixelResolution = param.PixelResolution;
            optionParam.s_nOverlap = param.Overlap;
            optionParam.s_nRotOffset = param.RotOffset;

            return optionParam;
        }

        private int[][] ConvertROI(int leadCount, MacronAkkonGroup group, PointF centerPoint, PointF offset, double angle)
        {
            int[][] leadPoint = new int[leadCount][];

            OpenCvSharp.Point2d centerPoint2d = new OpenCvSharp.Point2d(centerPoint.X, centerPoint.Y);
            OpenCvSharp.Point2d offset2d = new OpenCvSharp.Point2d(offset.X, offset.Y);

            for (int i = 0; i < leadCount; i++)
            {
                OpenCvSharp.Point2d cornerOriginPt = new OpenCvSharp.Point2d();
                cornerOriginPt.X = group.AkkonROIList[i].CornerOriginX;
                cornerOriginPt.Y = group.AkkonROIList[i].CornerOriginX;

                OpenCvSharp.Point2d cornerXPt = new OpenCvSharp.Point2d();
                cornerXPt.X = group.AkkonROIList[i].CornerXX;
                cornerXPt.Y = group.AkkonROIList[i].CornerXY;

                OpenCvSharp.Point2d cornerOppositePt = new OpenCvSharp.Point2d();
                cornerOppositePt.X = group.AkkonROIList[i].CornerOppositeX;
                cornerOppositePt.Y = group.AkkonROIList[i].CornerOppositeY;

                OpenCvSharp.Point2d cornerYPt = new OpenCvSharp.Point2d();
                cornerYPt.X = group.AkkonROIList[i].CornerYX;
                cornerYPt.Y = group.AkkonROIList[i].CornerYY;

                var calcCornerOriginPt = MatHelper.RotationPoint(cornerOriginPt, centerPoint2d, offset2d, angle);
                var calcCornerXPt = MatHelper.RotationPoint(cornerXPt, centerPoint2d, offset2d, angle);
                var calcCornerOppositePt = MatHelper.RotationPoint(cornerOppositePt, centerPoint2d, offset2d, angle);
                var calcCornerYPt = MatHelper.RotationPoint(cornerYPt, centerPoint2d, offset2d, angle);

                leadPoint[i][0] = (int)calcCornerOriginPt.X;
                leadPoint[i][1] = (int)calcCornerOriginPt.Y;

                leadPoint[i][2] = (int)cornerXPt.X;
                leadPoint[i][3] = (int)cornerXPt.Y;

                leadPoint[i][4] = (int)cornerOppositePt.X;
                leadPoint[i][5] = (int)cornerOppositePt.Y;

                leadPoint[i][6] = (int)cornerYPt.X;
                leadPoint[i][7] = (int)cornerYPt.Y;
            }

            return leadPoint;
        }
    }
}
