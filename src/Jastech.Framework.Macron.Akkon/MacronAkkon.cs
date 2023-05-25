using AW;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Jastech.Framework.Imaging.Helper;
using Jastech.Framework.Macron.Akkon.Parameters;
using Jastech.Framework.Macron.Akkon.Results;
using Jastech.Framework.Util.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Jastech.Framework.Macron.Akkon
{  
    public partial class MacronAkkon
    {
        public MacronAkkonParam CurAkkonParam { get; set; } = null;

        public System.Drawing.Size CurImageSize { get; set; } = new System.Drawing.Size();

        public static CATTWrapper ATTWrapper { get; private set; } = new CATTWrapper();

        public static CALLBACKFUNC cb { get; private set; } = new CALLBACKFUNC(AkkonResultCallback);

        public List<List<int>> SliceOverlapList = new List<List<int>>();

        public List<List<int>> TotalSliceCntList = new List<List<int>>();

        private static ManualResetEvent InspectDoneEvent { get; set; } = new ManualResetEvent(false);

        static MVAKKONFILTER tempFilter;

        static Stopwatch sw = new Stopwatch();

        static int ThreadCnt { get; set; } = 8;

        static int StageCount { get; set; } = 1;

        static int TabCount { get; set; } = 5;

        static int SliceWidth { get; set; } = 2048;

        static int SliceHeight { get; set; } = 3072;

        static float ResizeRatio { get; set; } = 1.0f;

        static  MVRESULT[][] AkkonResult;

        static int ReceivedStageNo { get; set; } = -1;

        static int ReceivedTabNo { get; set; } = -1;

        private static void AkkonResultCallback(int stageNo, int tabNo, bool sliceInsp, int nError)
        {
            unsafe
            {
                AkkonResult = null;
                ReceivedStageNo = -1;
                ReceivedTabNo = -1;

                ATTWrapper.AWGetATTResultData(stageNo, tabNo, ref tempFilter, ref AkkonResult);

                ReceivedStageNo = stageNo;
                ReceivedTabNo = tabNo;

                InspectDoneEvent.Set();

                sw.Stop();
                Console.WriteLine("Akkon Callback : " + sw.ElapsedMilliseconds.ToString() + " StageNo : " + stageNo.ToString() + " TabNo : " + tabNo.ToString());
            }
        }

        /// <summary>
        /// 검사 Thread 생성
        /// </summary>
        /// <param name="pHandle">실행 프로그램의 핸들</param>
        /// <param name="nThreadCnt">검사에 사용할 Thread 개수</param>
        /// <param name="nCoreMask">Thread에 할당할 Core Number</param>
        public static void ATT_InitSystem(IntPtr pHandle, int threadCnt, UInt32 nCoreMask)
        {
            ThreadCnt = threadCnt;
            ATTWrapper.AWCreateProcessingThread();
            ATTWrapper.AWCreateAttThread(pHandle, ThreadCnt, nCoreMask);
            NativeMethods.CallBackRegistry(cb);
        }

        // 1번. Stage Count, Tab Count를 가지고 Buffer 생성
        public bool CreateDllBuffer(int stageCount, int tabCount, int sliceWidth, int sliceHeight, float resizeRatio)
        {
            if (IsNewBufferCreate(stageCount, tabCount, sliceWidth, sliceHeight, resizeRatio) == false)
                return false;

            StageCount = stageCount;
            TabCount = tabCount;
            SliceWidth = sliceWidth;
            SliceHeight = sliceHeight;
            ResizeRatio = resizeRatio;

            ATTWrapper.AWFreeInspectionFlag();
            ATTWrapper.AWDeleteInspManager();
            ATTWrapper.AWCreateInspManager(StageCount, TabCount);
            ATTWrapper.AWCreateAttSliceImageBuffer(TabCount, ThreadCnt, SliceWidth, SliceHeight, ResizeRatio);

            return true;
        }

        private bool IsNewBufferCreate(int stageCount, int tabCount, int sliceWidth, int sliceHeight, float resizeRatio)
        {
            if (ThreadCnt <= 0)
                return false;

            if (stageCount <= 0 || tabCount <= 0 || sliceWidth <= 0 || sliceHeight <= 0)
                return false;

            if (resizeRatio < 0.1 || resizeRatio > 1.0)
                return false;

            if (StageCount == stageCount && TabCount == tabCount 
                && SliceWidth == sliceWidth && SliceHeight == sliceHeight && ResizeRatio == resizeRatio)
                return false;
            else
                return true;
        }
        
        // 2-2번 이미지 사이즈만큼 Buffer 할당(개별)
        public void CreateImageBuffer(int stageNo, int tabNo, int imageWidth, int imageHeight, float resizeRatio)
        {
            // 영상 크기만큼 Buffer 할당
            ATTWrapper.AWCreateAttFullImageBuffer(stageNo, tabNo, imageWidth, imageHeight, resizeRatio);
            CurImageSize = new System.Drawing.Size(imageWidth, imageHeight);
        }

        //// 3번 ROI 설정
        public bool SetConvertROIData(List<MacronAkkonROI> roiList, int stageNo, int tabNo, PointF centerPoint, PointF offset, double angle, float resize = 1.0f)
        {
            int leadCount = roiList.Count();

            int[][] leadPoints = ConvertROI(roiList, centerPoint, offset, angle);
            bool isComplete = ATTWrapper.AWReadROI(stageNo, tabNo, leadPoints, resize); // 1 : 메크론과 개발 단계에서 정해짐 Fixed 값
            if (isComplete == false)
            {
                Logger.Error(ErrorType.Macron, "AW ReadROI Fail.");
                return false;
            }
            return true;
        }
        // 4번 Inspection Param 설정
        public void SetAkkonParam(int stageNo, int tabNo, ref MacronAkkonParam akkonParam)
        {
            TestSetParam(ref akkonParam);

            var inspParam = GetConvertMacronInsp(akkonParam.InspParam);
            var filterParam = GetConvertMacronFilter(akkonParam.FilterParam);
            var drawOption = GetConvertMacronDrawOption(akkonParam.DrawOption);
            var inspOption = GetConvertMacronInspOption(akkonParam.InspOption);

           
            ATTWrapper.AWSetAllPara(stageNo, tabNo, ref inspParam, ref filterParam, ref drawOption, ref inspOption);

            tempFilter = filterParam;
        }

        // 5번 Inspection 준비 -2
        public int PrepareInspect(int stageNo, int tabNo,ref AkkonInspOption param, int imageWidth, int imageHeight)
        {
            List<int> tabSliceOverLapList = new List<int>();
            List<int> tabTotalSliceCountList = new List<int>();

            int sliceOverlap = ATTWrapper.AWCalcSliceOverlap(stageNo, tabNo);
            param.Overlap = sliceOverlap;

            //int calcTotalSliceCount = ATTWrapper.AWCalcTotalSliceCnt(stageNo, tabNo, sliceOverlap, PrevAkkonParam.SliceWidth, PrevAkkonParam.SliceHeight, false);
            int calcTotalSliceCount = ATTWrapper.AWCalcTotalSliceCnt(stageNo, tabNo, sliceOverlap, imageWidth, imageHeight, false);
            //sliceOverlap = 180;
            //calcTotalSliceCount = 34;
            tabSliceOverLapList.Add(sliceOverlap);
            tabTotalSliceCountList.Add(calcTotalSliceCount);

            TotalSliceCntList.Add(tabTotalSliceCountList);
            TotalSliceCntList.Add(tabTotalSliceCountList);
            //var sliceCount = tabTotalSliceCountList.Select(x => x.ToArray()).ToArray();

            //ATTWrapper.AWAllocInspectionFlag(calcTotalSliceCount);  //검사 FLag 할당
            return tabSliceOverLapList[0]; // 임시
        }

        public int GetCalcSliceOverlap(int stageNo, int tabNo)
        {
            int sliceOverlap = ATTWrapper.AWCalcSliceOverlap(stageNo, tabNo);
            return sliceOverlap;
        }

        public int GetCalcTotalSliceCnt(int stageNo, int tabNo, int overlap, int width, int height)
        {
            int calcTotalSliceCount = ATTWrapper.AWCalcTotalSliceCnt(stageNo, tabNo, overlap, width, height, false);
            return calcTotalSliceCount;
        }
    
        // 6번 검사 플래그 설정
        //public void EnableInspFlag()
        //{
        //    var sliceCount = TotalSliceCntList.Select(x => x.ToArray()).ToArray();
        //    ATTWrapper.AWAllocInspectionFlag(sliceCount);  //검사 FLag 할당
        //}

        public void EnableInspFlag(int[][] intSliceCnt)
        {
            ATTWrapper.AWAllocInspectionFlag(intSliceCnt);  //검사 FLag 할당
        }

        // 6번 검사
        public AkkonResult Inspect(int stageNo, int tabNo, Mat image)
        {
            unsafe
            {
                sw.Restart();

                InspectDoneEvent.Reset();

                ATTWrapper.AWATTFullInspection(stageNo, tabNo, (byte*)image.DataPointer.ToPointer(), image.Width, image.Height);
                bool isInspected = false;
#if DEBUG
                isInspected = InspectDoneEvent.WaitOne(60 * 1000);
#else
                isInspected = InspectDoneEvent.WaitOne(20 * 1000);
#endif

                if(isInspected)
                {
                    if(AkkonResult != null)
                    {
                        var result = GetAkkonResult(stageNo, tabNo, AkkonResult);

                        return result;
                    }
                }
            }
            return new AkkonResult();
        }

        public Mat GetDrawResultImage(Mat image, int stageNo, int tabNo, ref MacronAkkonParam akkonParam)
        {
            var inspParam = GetConvertMacronInsp(akkonParam.InspParam);
            var filterParam = GetConvertMacronFilter(akkonParam.FilterParam);
            var drawOption = GetConvertMacronDrawOption(akkonParam.DrawOption);
            var inspOption = GetConvertMacronInspOption(akkonParam.InspOption);
            inspOption.s_fInspResizeRatio = 0.5f;
            unsafe
            {
                IntPtr unmanagedPointer = Marshal.AllocHGlobal(image.Width * image.Height * 3);

                ATTWrapper.AWGetATTResultImage(stageNo, tabNo, ref filterParam, ref drawOption, (byte*)unmanagedPointer, 0);
                byte[] destByteArray = new byte[image.Width * image.Height * 3];

                Marshal.Copy(unmanagedPointer, destByteArray, 0, destByteArray.Length);

                Size size = new Size(image.Width, image.Height);
                Mat resultMat = new Mat(size, DepthType.Cv8U, 3, unmanagedPointer, image.Width * 3);
                return resultMat;
            }
        }

        // 7번 검사 결과
        public static AkkonResult GetAkkonResult(int stageNo, int tabNo, MVRESULT[][] akkonResultArray)
        {
            if (akkonResultArray.Length <= 0)
                return new AkkonResult();

            AkkonResult akkonResult = new AkkonResult();
            akkonResult.StageNo = stageNo;
            akkonResult.TabNo = tabNo;

            int blobCountSum = 0;
            float lengthSum = 0;

            for (int lead = 0; lead < akkonResultArray[0].Length; lead++)
            {
                var result = akkonResultArray[0][lead];

                int id = result.s_nId;
                bool judgement = result.s_bJudgement;
                float avgStrength = result.s_fAvgStrength;
                float leadAvg = result.s_fLeadAvg;
                float leadStdDEV = result.s_fLeadStdDEV;
                float length = result.s_fLength;
                int blobCount = result.s_nNumBlobs;

                LeadResult leadResult = new LeadResult
                {
                    Id = id,
                    IsGood = judgement,
                    AvgStrength = avgStrength,
                    LeadAvg = leadAvg,
                    LeadStdDev = leadStdDEV,
                    Length = length,
                    BlobCount = blobCount,

                };

                akkonResult.LeadResultList.Add(leadResult);
                blobCountSum += blobCount;
                lengthSum += length;
            }

            akkonResult.AvgBlobCount = blobCountSum / akkonResultArray[0].Length;
            akkonResult.AvgLength = lengthSum / akkonResultArray[0].Length;

            return akkonResult;
        }

        public void SetParam(int stageNo, int tabNo, MacronAkkonParam param)
        {
            var inspParam = GetConvertMacronInsp(param.InspParam);
            var filterParam = GetConvertMacronFilter(param.FilterParam);
            var drawOption = GetConvertMacronDrawOption(param.DrawOption);
            var inspOption = GetConvertMacronInspOption(param.InspOption);

            ATTWrapper.AWSetAllPara(stageNo, tabNo, ref inspParam, ref filterParam, ref drawOption, ref inspOption);
        }

        public List<MacronAkkonROI> GetCalcROI(PointF startPoint, List<MacronAkkonROI> orgROIList)
        {
            List<MacronAkkonROI> calcROIList = new List<MacronAkkonROI>();

            foreach (var roi in orgROIList)
            {
                MacronAkkonROI calcROI = new MacronAkkonROI();
                calcROI.CornerOppositeX = roi.CornerOppositeX - startPoint.X;
                calcROI.CornerOppositeY = roi.CornerOppositeY - startPoint.Y;

                calcROI.CornerOriginX = roi.CornerOriginX - startPoint.X;
                calcROI.CornerOriginY = roi.CornerOriginY - startPoint.Y;

                calcROI.CornerXX = roi.CornerXX - startPoint.X;
                calcROI.CornerXY = roi.CornerXY - startPoint.Y;

                calcROI.CornerYX = roi.CornerYX - startPoint.X;
                calcROI.CornerYY = roi.CornerYY - startPoint.Y;

                calcROIList.Add(calcROI);
            }

            return calcROIList;
        }

        private void TestSetParam(ref MacronAkkonParam akkonParam)
        {
            akkonParam.InspParam.FilterDir = 1;
            akkonParam.InspParam.ThWeight = 2;
            akkonParam.InspParam.ShadowOffset = 7;
            akkonParam.InspParam.StrengthThreshold = 0;
            akkonParam.InspParam.FilterType = EN_MVFILTERTYPE_WRAP._MV_FILTER_4;
            akkonParam.InspParam.ThMode = EN_THMODE_WRAP._MV_TH_WHITE;
            akkonParam.InspParam.ShadowDir = EN_SHADOWDIR_WRAP._MV_SHADOW_DN;
            akkonParam.InspParam.StrengthBase = EN_STRENGTH_BASE_WRAP._MV_STRENGTH_ENH;
            akkonParam.InspParam.PeakProp = EN_PEAK_PROP_WRAP._MV_PEAK_NORMAL;
            akkonParam.InspParam.ThPeak = 70;
            akkonParam.InspParam.MinShadowWidth = 5;
            akkonParam.InspParam.StrengthScaleFactor = 1.0f;
            akkonParam.InspParam.InflateLeadSize = 0;
            akkonParam.InspParam.PosTolerance = 1.0f;
            akkonParam.InspParam.ExtraLead = 0;
            akkonParam.InspParam.RoiDivDistance = 200;
            akkonParam.InspParam.StdDevLeadJudge = 0;
            akkonParam.InspParam.ImulInspection = false;
            akkonParam.InspParam.AbsoluteThHi = 180;
            akkonParam.InspParam.AbsoluteThLow = 0;
            akkonParam.InspParam.ImulInspectionThresh = 1;
            akkonParam.InspParam.UseAbsTh = false;
            akkonParam.InspParam.DLPeakProb = 0.9f;
            akkonParam.InspParam.DLSizeProb = 0.9f;
            akkonParam.InspParam.DLNetWorkType = 1;
            akkonParam.InspParam.DLSperateCut = 0;
            akkonParam.InspParam.EdgeFlip = false;
            akkonParam.InspParam.DLPatchSizeX = 246;
            akkonParam.InspParam.DLPatchSizeY = 0;

            //inspOption.s_nOverlap = 34;
            akkonParam.InspParam.PanelInfo = 0;
            akkonParam.InspParam.FilterDir = 2;
            akkonParam.InspParam.FilterType = (EN_MVFILTERTYPE_WRAP)4;
            akkonParam.InspParam.RoiDivDistance = 200;
            akkonParam.InspParam.ImulInspectionThresh = 200;
            akkonParam.InspOption.PixelResolution = 0.07f;
            akkonParam.InspOption.LogTrace = false;

            akkonParam.DrawOption.Contour = true;
            akkonParam.DrawOption.Center = false;
            //GetConvertInspAkkonParam(inspParam, ref akkonParam.InspParam);
            //GetConvertFilterAkkonParam(filterParam, ref akkonParam.FilterParam);
            //GetConvertDrawOptionParam(drawOption, ref akkonParam.DrawOption);
            //GetConvertInspOption(inspOption, ref akkonParam.InspOption);
        }
    }

    public partial class MacronAkkon
    {
        private MVINSPPARA GetConvertMacronInsp(AkkonInspParam param)
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

        private void GetConvertInspAkkonParam(MVINSPPARA param, ref AkkonInspParam inspParam)
        {
            inspParam.FilterDir = param.s_nFilterDir;
            inspParam.DLPatchSizeX = param.s_nDLPatchSizeX;
            inspParam.EdgeFlip = param.s_bEdgeFlip;
            inspParam.DLSperateCut = param.s_nDLSperateCut;
            inspParam.DLNetWorkType = param.s_nDLNetWorkType;
            inspParam.DLSizeProb = param.s_fDLSizeProb;
            inspParam.DLPeakProb = param.s_fDLPeakProb;
            inspParam.UseAbsTh = param.s_bUseAbsTh;
            inspParam.ImulInspectionThresh = param.s_nImulInspectionThresh;
            inspParam.AbsoluteThLow = param.s_nAbsoluteThLow;
            inspParam.AbsoluteThHi = param.s_nAbsoluteThHi;
            inspParam.ImulInspection = param.s_bImulInspection;
            inspParam.IsFlexible = param.s_nIsFlexible;
            inspParam.StdDevLeadJudge = param.s_fStdDevLeadJudge;
            inspParam.RoiDivDistance = param.s_nRoiDivDistance;
            inspParam.ExtraLead = param.s_nExtraLead;
            inspParam.PanelInfo = param.s_nPanelInfo;
            inspParam.PosTolerance = param.s_fPosTolerance;
            inspParam.InflateLeadSize = param.s_nInflateLeadSize;
            inspParam.StrengthScaleFactor = param.s_fStrengthScaleFactor;
            inspParam.MinShadowWidth = param.s_nMinShadowWidth;
            inspParam.ThPeak = param.s_nThPeak;
            inspParam.PeakProp = param.s_ePeakProp;
            inspParam.StrengthBase = param.s_eStrengthBase;
            inspParam.ShadowDir = param.s_eShadowDir;
            inspParam.ThMode = param.s_eThMode;
            inspParam.FilterType = param.s_eFilterType;
            inspParam.StrengthThreshold = param.s_fStrengthThreshold;
            inspParam.ShadowOffset = param.s_nShadowOffset;
            inspParam.ThWeight = param.s_fThWeight;
            inspParam.DLPatchSizeY = param.s_nDLPatchSizeY;
        }

        private MVAKKONFILTER GetConvertMacronFilter(AkkonFilterParam param)
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

        private void GetConvertFilterAkkonParam(MVAKKONFILTER param, ref AkkonFilterParam filterParam)
        {
            filterParam.MinStrength = param.s_fMinStrength;
            filterParam.RawShadowMin = param.s_fRawShadowMin;
            filterParam.RawStdMax = param.s_fRawStdMax;
            filterParam.RawStdMin = param.s_fRawStdMin;
            filterParam.RawAvgMax = param.s_fRawAvgMax;
            filterParam.RawAvgMin = param.s_fRawAvgMin;
            filterParam.RawUpShootcut = param.s_nRawUpShootcut;
            filterParam.ShadowPeakcut = param.s_nShadowPeakcut;
            filterParam.Enhstdcut = param.s_fEnhstdcut;
            filterParam.BWRatioMax = param.s_fBWRatioMax;
            filterParam.WHRawPeakCut = param.s_nWHRawPeakCut;
            filterParam.RawPeakCut = param.s_nRawPeakCut;
            filterParam.HeightCut = param.s_nHeightCut;
            filterParam.WidthCut = param.s_nWidthCut;
            filterParam.ImulSize = param.s_fImulSize;
            filterParam.AkkonInArea = param.s_fAkkonInArea;
            filterParam.AkkonInLine = param.s_nAkkonInLine;
            filterParam.ROIDiv = param.s_nROIDiv;
            filterParam.MinWidth = param.s_nMinWidth;
            filterParam.MinHeight = param.s_nMinHeight;
            filterParam.MinSize = param.s_fMinSize;
            filterParam.MaxSize = param.s_fMaxSize;
            filterParam.GroupingDistance = param.s_fGroupingDistance;
            filterParam.MinBoundaryOverlap = param.s_nMinBoundaryOverlap;
            filterParam.RawShadowMax = param.s_fRawShadowMax;
            filterParam.UseEdgeFARemove = param.s_bUseEdgeFARemove;
            filterParam.EdgeRange = param.s_nEdgeRange;
            filterParam.Width = param.s_nWidth;
            filterParam.Height = param.s_nHeight;
            filterParam.EdgeStrengthCut = param.s_fEdgeStrengthCut;
            filterParam.EdgeSizeCut = param.s_fEdgeSizeCut;
            filterParam.BWRatio = param.s_fBWRatio;
            filterParam.WHRatio = param.s_fWHRatio;
        }

        private MVDRAWOPTION GetConvertMacronDrawOption(AkkonDrawOption param)
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

        private void GetConvertDrawOptionParam(MVDRAWOPTION param, ref AkkonDrawOption drawOption)
        {
            drawOption.Center = param.s_bCenter;
            drawOption.Contour = param.s_bContour;
            drawOption.ShadowBox = param.s_bShadowBox;
            drawOption.FirstLastPoint = param.s_bFirstLastPoint;
            drawOption.ColorStrength = param.s_bColorStrength;
            drawOption.PixelSize_um = param.s_fPixelSize_um;
            drawOption.ShowSize = param.s_bShowSize;
            drawOption.ShowStrength = param.s_bShowStrength;
            drawOption.DrawBlobNumbering = param.s_bDrawBlobNumbering;
            drawOption.SelectLeadDisplay = param.s_bSelectLeadDisplay;
            drawOption.DisplayLength = param.s_bDisplayLength;
            drawOption.Panelnfo = param.s_nPanelnfo;
            drawOption.ExtraLead = param.s_nExtraLead;
            drawOption.DrawResizeRatio = param.s_fDrawResizeRatio;
        }

        private MVINSP_OPTION GetConvertMacronInspOption(AkkonInspOption param)
        {
            MVINSP_OPTION optionParam = new MVINSP_OPTION();

            optionParam.s_bLogTrace = param.LogTrace;
            optionParam.s_nInspType = param.InspType;
            //optionParam.s_fInspResizeRatio = param.InspResizeRatio;
            optionParam.s_fPixelResolution = param.PixelResolution;
            optionParam.s_nOverlap = param.Overlap;
            optionParam.s_nRotOffset = param.RotOffset;

            return optionParam;
        }

        private void GetConvertInspOption(MVINSP_OPTION param,ref AkkonInspOption inspOption)
        {
            inspOption.LogTrace = param.s_bLogTrace;
            inspOption.InspType = param.s_nInspType;
            //inspOption.InspResizeRatio = param.s_fInspResizeRatio;
            inspOption.PixelResolution = param.s_fPixelResolution;
            inspOption.Overlap = param.s_nOverlap;
            inspOption.RotOffset = param.s_nRotOffset;
        }

        private int[][] ConvertROI(List<MacronAkkonROI> tabROIList, PointF centerPoint, PointF offset, double angle)
        {
            int leadCount = tabROIList.Count();
            if (leadCount <= 0)
                return null;

            int[][] leadPoint = new int[leadCount][];

            for (int i = 0; i < leadCount; i++)
            {
                leadPoint[i] = new int[8];

                PointF cornerOriginPt = new PointF();
                cornerOriginPt.X = (float)tabROIList[i].CornerOriginX;
                cornerOriginPt.Y = (float)tabROIList[i].CornerOriginY;

                PointF cornerXPt = new PointF();
                cornerXPt.X = (float)tabROIList[i].CornerXX;
                cornerXPt.Y = (float)tabROIList[i].CornerXY;

                PointF cornerOppositePt = new PointF();
                cornerOppositePt.X = (float)tabROIList[i].CornerOppositeX;
                cornerOppositePt.Y = (float)tabROIList[i].CornerOppositeY;

                PointF cornerYPt = new PointF();
                cornerYPt.X = (float)tabROIList[i].CornerYX;
                cornerYPt.Y = (float)tabROIList[i].CornerYY;

                var calcCornerOriginPt = MatHelper.RotationPoint(cornerOriginPt, centerPoint, offset, angle);
                var calcCornerXPt = MatHelper.RotationPoint(cornerXPt, centerPoint, offset, angle);
                var calcCornerOppositePt = MatHelper.RotationPoint(cornerOppositePt, centerPoint, offset, angle);
                var calcCornerYPt = MatHelper.RotationPoint(cornerYPt, centerPoint, offset, angle);

                leadPoint[i][0] = (int)calcCornerOriginPt.X;
                leadPoint[i][1] = (int)calcCornerOriginPt.Y;

                leadPoint[i][2] = (int)calcCornerXPt.X;
                leadPoint[i][3] = (int)calcCornerXPt.Y;

                leadPoint[i][4] = (int)calcCornerOppositePt.X;
                leadPoint[i][5] = (int)calcCornerOppositePt.Y;

                leadPoint[i][6] = (int)calcCornerYPt.X;
                leadPoint[i][7] = (int)calcCornerYPt.Y;
            }

            return leadPoint;
        }
    }
}
