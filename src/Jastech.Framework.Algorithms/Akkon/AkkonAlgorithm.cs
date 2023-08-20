using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Jastech.Framework.Algorithms.Akkon.Parameters;
using Jastech.Framework.Imaging.Helper;
using Jastech.Framework.Imaging.Ipp;
using Jastech.Framework.Imaging.Result;
using Jastech.Framework.Imaging.VisionAlgorithms;
using Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Results;
using Jastech.Framework.Util.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Jastech.Framework.Algorithms.Akkon
{
    public partial class AkkonAlgorithm
    {
        private object _lock = new object();

        private OpencvContour OpencvContour { get; set; } = new OpencvContour();

        public Mat ResizeMat { get; set; } = null;

        public List<AkkonLeadResult> Run(Mat mat, List<AkkonROI> roiList, AkkonAlgoritmParam parameters, float resolution_um, ref Judgement tabJudgement)
        {
            roiList =  roiList.OrderBy(x => x.LeftTopX).ToList();

            bool isTabNG = false;
            Stopwatch sw = new Stopwatch();
            sw.Restart();

            List<AkkonLeadResult> leadResultList = new List<AkkonLeadResult>();
            var AkkonSliceList = PrepareInspect(mat, roiList, 2048, parameters.ImageFilterParam.ResizeRatio);
            float calcReslution_um = resolution_um / parameters.ImageFilterParam.ResizeRatio;

            int max = 4;// Environment.ProcessorCount / 4;
            ParallelOptions options = new ParallelOptions
            {
                MaxDegreeOfParallelism = max,
            };
            //Parallel.For(0, AkkonSliceList.Count(), options, i =>
            Parallel.For(0, AkkonSliceList.Count(), i =>
            //for (int i = 0; i < AkkonSliceList.Count(); i++)
            {
                var slice = AkkonSliceList[i];
                slice.Id = i;

                Mat enhanceMat = null;
                var currentImageFilter = parameters.ImageFilterParam.GetCurrentFilter();

                if (parameters.ImageFilterParam.FilterDir == AkkonFilterDir.Vertical)
                    enhanceMat = EnhanceY(slice.Image, currentImageFilter);
                else
                    enhanceMat = EnhanceX(slice.Image, currentImageFilter);

                Mat maskMat = MakeMaskImage(slice.Image, slice.CalcAkkonROIs);

                int lowThres = 0;
                int highThres = 255;
                CalcThreadholdLowHigh(enhanceMat, maskMat, parameters.ImageFilterParam, out lowThres, out highThres);
                Mat thresMat = Threshold(enhanceMat, maskMat, lowThres, highThres);

                foreach (var roi in slice.CalcAkkonROIs)
                {
                    Rectangle boundRect = roi.GetBoundRect();

                    Mat roiThresMat = new Mat(thresMat, boundRect);
                    Mat oneLeadMask = MakeMaskImage(new Size(boundRect.Width, boundRect.Height), roi, boundRect.X, boundRect.Y);
                    Mat oneLeadMat = new Mat();

                    CvInvoke.BitwiseAnd(oneLeadMask, roiThresMat, oneLeadMat);

                    AkkonLeadResult leadResult = new AkkonLeadResult();
                    leadResult.Roi = roi.DeepCopy();
                    leadResult.Offset.ToWorldX = slice.StartPoint.X + slice.WorldRect.X;
                    leadResult.Offset.ToWorldY = slice.StartPoint.Y + slice.WorldRect.Y;
                    leadResult.Offset.X = boundRect.X;
                    leadResult.Offset.Y = boundRect.Y;
                    leadResult.Slope = MathHelper.GetSlope(roi.GetRightTopPoint(), roi.GetRightBottomPoint());

                    double calcHalfWidth = (mat.Width * parameters.ImageFilterParam.ResizeRatio) / 2.0;
                    if (leadResult.Offset.ToWorldX < calcHalfWidth)
                        leadResult.ContainPos = LeadContainPos.Left;
                    else
                        leadResult.ContainPos = LeadContainPos.Right;

                    Mat enhanceCropMat = MatHelper.CropRoi(enhanceMat, boundRect);

                    var blobList = OpencvContour.Run(oneLeadMat);
                    FindShadowPoint(enhanceCropMat, oneLeadMat, ref blobList, boundRect);

                    leadResult.BlobList.AddRange(blobList);
                    ClacJudgement(enhanceCropMat, oneLeadMask, ref leadResult, parameters, calcReslution_um);
                 
                    lock (_lock)
                    {
                        if (leadResult.Judgement != Judgement.OK)
                            isTabNG = true;

                        leadResultList.Add(leadResult);
                    }

                    enhanceCropMat.Dispose();
                    roiThresMat.Dispose();
                    oneLeadMask.Dispose();
                    oneLeadMat.Dispose();
                }
                enhanceMat?.Dispose();
                maskMat?.Dispose();
                thresMat?.Dispose();
            //}
            });

            if (isTabNG)
                tabJudgement = Judgement.NG;
            else
                tabJudgement = Judgement.OK;

            sw.Stop();
            Console.WriteLine("Akkon Inspection : " + sw.ElapsedMilliseconds.ToString());
            return leadResultList.OrderBy(x => x.Id).ToList();
        }

        public List<AkkonLeadResult> RunForDebug(ref AkkonSlice slice, AkkonAlgoritmParam parameters, float resolution_um)
        {
            List<AkkonLeadResult> leadResultList = new List<AkkonLeadResult>();

            Mat enhanceMat = null;
            float calcReslution_um = resolution_um / parameters.ImageFilterParam.ResizeRatio;
            var currentImageFilter = parameters.ImageFilterParam.GetCurrentFilter();

            if (parameters.ImageFilterParam.FilterDir == AkkonFilterDir.Vertical)
                enhanceMat = EnhanceY(slice.Image, currentImageFilter);
            else
                enhanceMat = EnhanceX(slice.Image, currentImageFilter);

            slice.EnhanceMat = enhanceMat.Clone();

            Mat maskMat = MakeMaskImage(slice.Image, slice.CalcAkkonROIs);

            int lowThres = 0;
            int highThres = 255;
            CalcThreadholdLowHigh(enhanceMat, maskMat, parameters.ImageFilterParam, out lowThres, out highThres);

            Mat thresMat = Threshold(enhanceMat, maskMat, lowThres, highThres);
            slice.ProcessingMat = thresMat.Clone();

            Mat maskingImage = new Mat();
            CvInvoke.BitwiseAnd(thresMat, enhanceMat, maskingImage);

            slice.MaskingMat = maskingImage.Clone();
          
            foreach (var roi in slice.CalcAkkonROIs)
            {
                Rectangle boundRect = roi.GetBoundRect();

                Mat roiThresMat = new Mat(thresMat, boundRect);

                Mat oneLeadMask = MakeMaskImage(new Size(boundRect.Width, boundRect.Height), roi, boundRect.X, boundRect.Y);
                Mat oneLeadMat = new Mat();
                CvInvoke.BitwiseAnd(oneLeadMask, roiThresMat, oneLeadMat);

                AkkonLeadResult leadResult = new AkkonLeadResult();
                leadResult.Roi = roi.DeepCopy();
                leadResult.Offset.ToWorldX = slice.StartPoint.X + slice.WorldRect.X;
                leadResult.Offset.ToWorldY = slice.StartPoint.Y + slice.WorldRect.Y;
                leadResult.Offset.X = boundRect.X;
                leadResult.Offset.Y = boundRect.Y;
                leadResult.Slope = MathHelper.GetSlope(roi.GetRightTopPoint(), roi.GetRightBottomPoint());

                Mat enhanceCropMat = MatHelper.CropRoi(enhanceMat, boundRect);

                var blobList = OpencvContour.Run(oneLeadMat);
                FindShadowPoint(enhanceCropMat, oneLeadMat,ref blobList, boundRect);

                leadResult.BlobList.AddRange(blobList);
                ClacJudgement(enhanceCropMat, oneLeadMask, ref leadResult, parameters, calcReslution_um);

                leadResultList.Add(leadResult);

                roiThresMat.Dispose();
                oneLeadMask.Dispose();
                maskingImage.Dispose();
            }
            enhanceMat.Dispose();
            maskMat.Dispose();
            thresMat.Dispose();

            return leadResultList;
        }

        public void GetMaxValue(ref PixelInfo minPixelInfo, ref PixelInfo maxPixelInfo, Mat mat, List<Point> points)
        {
            unsafe
            {
                minPixelInfo.Value = int.MaxValue;
                maxPixelInfo.Value = int.MinValue;

                byte* dataPoint = (byte*)mat.DataPointer;
                foreach (Point point in points)
                {
                    // 좌표가 이미지 범위를 벗어나는지 확인
                    if (point.X < 0 || point.X >= mat.Width || point.Y < 0 || point.Y >= mat.Height)
                        continue;

                    int index = point.X + (mat.Step * point.Y);
                    // 해당 좌표의 픽셀 값 가져오기
                    int pixelValue = dataPoint[index];
                    Console.WriteLine(pixelValue);
                    // 최소값 업데이트
                    if (pixelValue < minPixelInfo.Value)
                    {
                        minPixelInfo.Value = pixelValue;
                        minPixelInfo.ValueX = point.X;
                        minPixelInfo.ValueY = point.Y;
                    }

                    // 최대값 업데이트
                    if (pixelValue > maxPixelInfo.Value)
                    {
                        maxPixelInfo.Value = pixelValue;
                        maxPixelInfo.ValueX = point.X;
                        maxPixelInfo.ValueY = point.Y;
                    }
                }
            }
        }

        public void GetMaxValue(ref PixelInfo minPixelInfo, ref PixelInfo maxPixelInfo, Mat mat, Rectangle rect)
        {
            unsafe
            {
                minPixelInfo.Value = int.MaxValue;
                maxPixelInfo.Value = int.MinValue;

                byte* dataPoint = (byte*)mat.DataPointer;

                for (int h = rect.Y; h < rect.Y + rect.Height; h++)
                {
                    for (int w = rect.X; w < rect.X + rect.Width; w++)
                    {
                        int index = w + (mat.Step * h);
                        if (index < 0)
                            continue;
                        if (mat.Step * mat.Height < index)
                            continue;
                        // 해당 좌표의 픽셀 값 가져오기
                        int pixelValue = dataPoint[index];
                        // 최소값 업데이트
                        if (pixelValue < minPixelInfo.Value)
                        {
                            minPixelInfo.Value = pixelValue;
                            minPixelInfo.ValueX = w;
                            minPixelInfo.ValueY = h;
                        }

                        // 최대값 업데이트
                        if (pixelValue > maxPixelInfo.Value)
                        {
                            maxPixelInfo.Value = pixelValue;
                            maxPixelInfo.ValueX = w;
                            maxPixelInfo.ValueY = h;
                        }
                    }
                }
            }
        }

        public void ClacJudgement(Mat dataMat, Mat maskMat, ref AkkonLeadResult leadResult, AkkonAlgoritmParam param, float resolution_um)
        {
            PixelInfo minYInfo = new PixelInfo();
            PixelInfo maxYInfo = new PixelInfo();
            minYInfo.Value = int.MaxValue;
            maxYInfo.Value = int.MinValue;

            MCvScalar meanScalar = new MCvScalar();
            MCvScalar stddevScalar = new MCvScalar();

            CvInvoke.MeanStdDev(dataMat, ref meanScalar, ref stddevScalar, maskMat);

            float scaleFactor = param.ShapeFilterParam.AkkonStrengthScaleFactor;

            int akkonCount = 0;

            int totalLengthX = (int)Math.Abs(leadResult.Roi.LeftTopX - leadResult.Roi.RightTopX);
            List<double> lengthXList = new List<double>();

            foreach (var blob in leadResult.BlobList)
            {
                blob.Strength = GetStrength(blob, dataMat, scaleFactor);
                blob.IsAkkonShape = CheckShapeFilter(blob, param.ShapeFilterParam, resolution_um);

                if (blob.IsAkkonShape)
                {
                    double calcLengthX = GetCalcLengthX(blob, leadResult);
                    lengthXList.Add(calcLengthX); // LengthX

                    // LengthY
                    if (minYInfo.Value > blob.CenterY)
                    {
                        minYInfo.Value = (int)blob.CenterY;
                        minYInfo.ValueX = (int)blob.CenterX;
                        minYInfo.ValueY = (int)blob.CenterY;
                    }
                    if (maxYInfo.Value < blob.CenterY)
                    {
                        maxYInfo.Value = (int)blob.CenterY;
                        maxYInfo.ValueX = (int)blob.CenterX;
                        maxYInfo.ValueY = (int)blob.CenterY;
                    }
                    akkonCount++;
                }
            }

            leadResult.AkkonCount = akkonCount;
            leadResult.Mean = meanScalar.V0;
            leadResult.StdDev = stddevScalar.V0;

            if (lengthXList.Count > 0)
                leadResult.LengthX_um = Math.Abs(lengthXList.Max() - lengthXList.Min()) * resolution_um;

            Point p1 = new Point(minYInfo.ValueX, minYInfo.ValueY);
            Point p2 = new Point(maxYInfo.ValueX, maxYInfo.ValueY);
            leadResult.LengthY_um = MathHelper.GetDistance(p1, p2) * resolution_um;

            bool isNg = false;
            if (leadResult.AkkonCount < param.JudgementParam.AkkonCount)
                isNg |= true;

            if (leadResult.LengthY_um < param.JudgementParam.LengthY_um)
                isNg |= true;

            leadResult.Judgement = isNg ? Judgement.NG : Judgement.OK;
        }

        private void GetBlobAreaPixelMinMax(BlobPos blob, Mat mat, out PixelInfo minPixelInfo, out PixelInfo maxPixelInfo)
        {
            minPixelInfo = new PixelInfo();
            maxPixelInfo = new PixelInfo();

            double expandWidth = blob.BoundingRect.Width;
            double expandHeight = blob.BoundingRect.Height * 2.0;
            double expandX = blob.CenterX - (expandWidth / 2.0);
            double expandY = blob.CenterY - (expandHeight / 2.0);
            Rectangle expandROI = new Rectangle((int)expandX, (int)expandY, (int)expandWidth, (int)expandHeight);

            GetMaxValue(ref minPixelInfo, ref maxPixelInfo, mat, expandROI);
        }

        private double GetCalcLengthX(BlobPos blob, AkkonLeadResult leadResult)
        {
            // LengthX, y = ax + b
            double orgRightBottomY = leadResult.Roi.RightBottomY - leadResult.Offset.Y;
            double orgLeftBottomX = leadResult.Roi.LeftBottomX - leadResult.Offset.X;
            double x = blob.CenterX;
            double y = blob.CenterY;
            double a = leadResult.Slope;
            double b = y - (a * x);
            double newX = (orgRightBottomY - b) / a - orgLeftBottomX;

            return newX;
        }

        private double GetStrength(BlobPos blob, Mat mat, float scaleFactor)
        {
            double strength = 0;

            GetBlobAreaPixelMinMax(blob, mat, out PixelInfo minInfo, out PixelInfo maxInfo);

            blob.MaxPixelInfo = maxInfo;

            if (blob.ShadowFound)
                strength = Math.Abs(((double)blob.ShadowPeak - maxInfo.Value) / (255 * scaleFactor)) * 100;
            else
                strength = Math.Abs(((double)minInfo.Value - maxInfo.Value) / (255 * scaleFactor)) * 100;

            return strength;
        }

        private bool CheckShapeFilter(BlobPos blob, AkkonShapeFilterParam filterParam, float resolution_um)
        {
            bool isAkkon = true;

            double area_um = blob.Area * resolution_um;
            double pixelSize = (blob.BoundingRect.Width + blob.BoundingRect.Height) / 2.0;
            double size_um = pixelSize * resolution_um;

            if (size_um < filterParam.MinSize_um)
                isAkkon &= false;

            if (size_um > filterParam.MaxSize_um)
                isAkkon &= false;

            if (area_um < filterParam.MinArea_um)
                isAkkon &= false;

            if (area_um > filterParam.MaxArea_um)
                isAkkon &= false;

            if (blob.Strength < filterParam.MinAkkonStrength)
                isAkkon &= false;

            return isAkkon;
        }

        public List<Point[]> MergeContours(List<Point[]> contours)
        {
            List<Point[]> mergedContours = new List<Point[]>();
            List<int> hullIndices = new List<int>();

            using (VectorOfVectorOfPoint contourVector = new VectorOfVectorOfPoint())
            {
                foreach (var contour in contours)
                {
                    contourVector.Push(new VectorOfPoint(contour));
                }

                using (VectorOfPoint hull = new VectorOfPoint())
                {
                    CvInvoke.ConvexHull(contourVector, hull);

                    for (int i = 0; i < hull.Size; i++)
                    {
                        int hullIndex = hull[i].X;
                        if (!hullIndices.Contains(hullIndex))
                        {
                            hullIndices.Add(hullIndex);
                            mergedContours.Add(contours[hullIndex]);
                        }
                    }
                }
            }

            return mergedContours;
        }

        public List<Mat> GetSliceImageList(Mat mat, List<AkkonROI> roiList, AkkonAlgoritmParam parameters)
        {
            List<Mat> sliceImageList = new List<Mat>();

            var AkkonInspecterList = PrepareInspect(mat, roiList, 2048, parameters.ImageFilterParam.ResizeRatio);

            foreach (var inspector in AkkonInspecterList)
            {
                sliceImageList.Add(inspector.Image);
            }
            return sliceImageList;
        }

        private Mat Threshold(Mat srcMat, Mat maskMat, int lowThres, int highThres)
        {
            Mat highThresMat = new Mat();
            Mat lowThresMat = new Mat();
            CvInvoke.Threshold(srcMat, highThresMat, (double)highThres, 255, ThresholdType.Binary);
            CvInvoke.Threshold(srcMat, lowThresMat, (double)lowThres, 128, ThresholdType.BinaryInv);

            Mat binMat = new Mat();
            CvInvoke.BitwiseOr(highThresMat, lowThresMat, binMat);
           
            CvInvoke.BitwiseAnd(maskMat, binMat, binMat);

            highThresMat.Dispose();
            lowThresMat.Dispose();

            return binMat;
        }

        private Mat MakeMaskImage(Mat mat, List<AkkonROI> roiList)
        {
            Mat maskImage = new Mat(new Size(mat.Width, mat.Height), DepthType.Cv8U, 1);
            byte[] tempArray = new byte[mat.Step * mat.Height];
            Marshal.Copy(tempArray, 0, maskImage.DataPointer, mat.Step * mat.Height);

            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            foreach (var roi in roiList)
            {
                VectorOfPoint contour = new VectorOfPoint( new[]
                {
                    new Point((int)roi.LeftTopX, (int)roi.LeftTopY),
                    new Point((int)roi.RightTopX, (int)roi.RightTopY),
                    new Point((int)roi.RightBottomX, (int)roi.RightBottomY- 10),
                    new Point((int)roi.LeftBottomX, (int)roi.LeftBottomY - 10),
                });
                contours.Push(contour);
            }
          
            CvInvoke.DrawContours(maskImage, contours, -1, new MCvScalar(255), -1);

            return maskImage;
        }

        private Mat MakeMaskImage(Size size, AkkonROI roi, int offsetX, int offsetY)
        {
            Mat maskImage = new Mat(size, DepthType.Cv8U, 1);
            byte[] dataArray = new byte[maskImage.Step * maskImage.Height];
            Marshal.Copy(dataArray, 0, maskImage.DataPointer, maskImage.Step * maskImage.Height);
       
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            VectorOfPoint contour = new VectorOfPoint(new[]
            {
                new Point((int)roi.LeftTopX - offsetX, (int)roi.LeftTopY - offsetY),
                new Point((int)roi.RightTopX - offsetX, (int)roi.RightTopY - offsetY),
                new Point((int)roi.RightBottomX - offsetX, (int)roi.RightBottomY - offsetY),
                new Point((int)roi.LeftBottomX - offsetX, (int)roi.LeftBottomY - offsetY),
            });
            contours.Push(contour);
            CvInvoke.DrawContours(maskImage, contours, -1, new MCvScalar(255), -1);
            return maskImage;
        }

        public List<AkkonSlice> PrepareInspect(Mat orgMat, List<AkkonROI> roiList, int sliceWidth, double resizeRatio)
        {
            if (roiList.Count <= 0)
                return new List<AkkonSlice>();

            var resizeRoiList = GetResizeROI(roiList, resizeRatio);
            ResizeMat = GetResizeMat(orgMat, resizeRatio);

            Rectangle worldRect = GetBoundRect(resizeRoiList);

            Mat cropWorldMat = null;

            if(resizeRatio == 1.0)
            {
                cropWorldMat = MatHelper.CropRoi(orgMat, worldRect);
                ResizeMat = orgMat;
            }
            else
            {
                cropWorldMat = MatHelper.CropRoi(ResizeMat, worldRect);
            }

            int roiIndex = 0;
            int maxSliceCount = (int)((cropWorldMat.Width / sliceWidth) * 1.5);
            if (maxSliceCount < 1)
                maxSliceCount = 1;

            List<AkkonSlice> sliceList = new List<AkkonSlice>();
            int startX = 0;
            int leadIndex = 0;
            bool lastCrop = false;
            for (int i = 0; i < maxSliceCount; i++)
            {
                if(lastCrop)
                    break;

                if (cropWorldMat.Width < startX + sliceWidth)
                {
                    lastCrop = true;
                    startX = cropWorldMat.Width - sliceWidth;
                }

                Rectangle cropRect = new Rectangle
                {
                    X = startX,
                    Y = 0,
                    Width = sliceWidth,
                    Height = cropWorldMat.Height,
                };

                Rectangle cropToworldRect = new Rectangle
                {
                    X = cropRect.X + worldRect.X,
                    Y = cropRect.Y + worldRect.Y,
                    Width = cropRect.Width,
                    Height = cropWorldMat.Height,
                };

                Point sliceStartPoint = new Point(cropToworldRect.X, cropToworldRect.Y);

                AkkonSlice slice = new AkkonSlice();
                slice.WorldRect = worldRect;
                slice.StartPoint = new Point(cropRect.X, cropRect.Y);

                for (int k = roiIndex; k < resizeRoiList.Count(); k++)
                {
                    var roi = resizeRoiList[k];
         
                    if (IsAllContain(roi, cropToworldRect))
                    {
                        AkkonROI calcRoiFromSlicePoint = new AkkonROI();

                        calcRoiFromSlicePoint.Index = leadIndex;
                        calcRoiFromSlicePoint.LeftTopX = roi.LeftTopX - sliceStartPoint.X;
                        calcRoiFromSlicePoint.LeftTopY = roi.LeftTopY - sliceStartPoint.Y;

                        calcRoiFromSlicePoint.LeftBottomX = roi.LeftBottomX - sliceStartPoint.X;
                        calcRoiFromSlicePoint.LeftBottomY = roi.LeftBottomY - sliceStartPoint.Y;

                        calcRoiFromSlicePoint.RightTopX = roi.RightTopX - sliceStartPoint.X;
                        calcRoiFromSlicePoint.RightTopY = roi.RightTopY - sliceStartPoint.Y;

                        calcRoiFromSlicePoint.RightBottomX = roi.RightBottomX - sliceStartPoint.X;
                        calcRoiFromSlicePoint.RightBottomY = roi.RightBottomY - sliceStartPoint.Y;

                        // Slice 이미지 기준으로 변경
                        slice.CalcAkkonROIs.Add(calcRoiFromSlicePoint);

                        leadIndex++;
                        roiIndex++;

                        if (resizeRoiList.Count() == roiIndex)
                        {
                            slice.Image = MatHelper.CropRoi(cropWorldMat, cropRect);
                            sliceList.Add(slice);
                            startX = roi.GetBoundRect().X - worldRect.X;
                            break;
                        }
                        
                    }
                    else
                    {
                        slice.Image = MatHelper.CropRoi(cropWorldMat, cropRect);
                        sliceList.Add(slice);
                        startX = roi.GetBoundRect().X - worldRect.X;
                        break;
                    }
                }
            }
            cropWorldMat.Dispose();

            return sliceList;
        }

        private void TempDrawLead(ref Mat mat, AkkonROI roi, Point StartPoint)
        {
            Point leftTop = new Point((int)roi.LeftTopX + StartPoint.X, (int)roi.LeftTopY + StartPoint.Y);
            Point leftBottom = new Point((int)roi.LeftBottomX + StartPoint.X, (int)roi.LeftBottomY + StartPoint.Y);
            Point rightTop = new Point((int)roi.RightTopX + StartPoint.X, (int)roi.RightTopY + StartPoint.Y);
            Point rightBottom = new Point((int)roi.RightBottomX+ StartPoint.X, (int)roi.RightBottomY + StartPoint.Y);

            CvInvoke.Line(mat, leftTop, leftBottom, new MCvScalar(255), 1);
            CvInvoke.Line(mat, leftTop, rightTop, new MCvScalar(255), 1);
            CvInvoke.Line(mat, rightTop, rightBottom, new MCvScalar(255), 1);
            CvInvoke.Line(mat, rightBottom, leftBottom, new MCvScalar(255), 1);
        }

        private bool IsAllContain(AkkonROI roi, Rectangle target)
        {
            bool isAllContain = true;
            if (target.Contains(new Point((int)roi.LeftTopX, (int)roi.LeftTopY)) == false)
                isAllContain &= false;

            if (target.Contains(new Point((int)roi.LeftBottomX, (int)roi.LeftBottomY)) == false)
                isAllContain &= false;

            if (target.Contains(new Point((int)roi.RightTopX, (int)roi.RightTopY)) == false)
                isAllContain &= false;

            if (target.Contains(new Point((int)roi.RightBottomX, (int)roi.RightBottomY)) == false)
                isAllContain &= false;

            return isAllContain;
        }

        private Mat GetResizeMat(Mat orgMat, double resizeRatio)
        {
            if (resizeRatio == 1.0)
                return orgMat;
            else
            {
                Mat resizeMat = new Mat();
                Size newSize = new Size((int)(orgMat.Width * resizeRatio), (int)(orgMat.Height * resizeRatio));
                CvInvoke.Resize(orgMat, resizeMat, newSize);

                return resizeMat;
            }
        }

        private List<AkkonROI> GetResizeROI(List<AkkonROI> orgRoiList, double resizeRatio)
        {

            if(resizeRatio == 1.0)
            {
                return orgRoiList.Select(x => x.DeepCopy()).ToList();
            }
            else
            {
                List<AkkonROI> calcRoiList = new List<AkkonROI>();

                foreach (var roi in orgRoiList)
                {
                    AkkonROI calcRoi = new AkkonROI();
                    calcRoi.LeftTopX = roi.LeftTopX * resizeRatio;
                    calcRoi.LeftTopY = roi.LeftTopY * resizeRatio;

                    calcRoi.LeftBottomX = roi.LeftBottomX * resizeRatio;
                    calcRoi.LeftBottomY = roi.LeftBottomY * resizeRatio;

                    calcRoi.RightTopX = roi.RightTopX * resizeRatio;
                    calcRoi.RightTopY = roi.RightTopY * resizeRatio;

                    calcRoi.RightBottomX = roi.RightBottomX * resizeRatio;
                    calcRoi.RightBottomY = roi.RightBottomY * resizeRatio;

                    calcRoiList.Add(calcRoi);
                }

                return calcRoiList;
            }
        }

        private Rectangle GetBoundRect(List<AkkonROI> roiList)
        {
            double minX = double.MaxValue;
            double minY = double.MaxValue;
            double maxX = double.MinValue;
            double maxY = double.MinValue;

            List<AkkonROI> calcRoiList = new List<AkkonROI>();
            foreach (var roi in roiList)
            {
                minX = minX > roi.LeftTopX ? roi.LeftTopX : minX;
                minX = minX > roi.LeftBottomX ? roi.LeftBottomX : minX;
                minX = minX > roi.RightTopX ? roi.RightTopX : minX;
                minX = minX > roi.RightBottomX ? roi.RightBottomX : minX;

                minY = minY > roi.LeftTopY ? roi.LeftTopY : minY;
                minY = minY > roi.LeftBottomY ? roi.LeftBottomY : minY;
                minY = minY > roi.RightTopY ? roi.RightTopY : minY;
                minY = minY > roi.RightBottomY ? roi.RightBottomY : minY;

                maxX = maxX < roi.LeftTopX ? roi.LeftTopX : maxX;
                maxX = maxX < roi.LeftBottomX ? roi.LeftBottomX : maxX;
                maxX = maxX < roi.RightTopX ? roi.RightTopX : maxX;
                maxX = maxX < roi.RightBottomX ? roi.RightBottomX : maxX;

                maxY = maxY < roi.LeftTopY ? roi.LeftTopY : maxY;
                maxY = maxY < roi.LeftBottomY ? roi.LeftBottomY : maxY;
                maxY = maxY < roi.RightTopY ? roi.RightTopY : maxY;
                maxY = maxY < roi.RightBottomY ? roi.RightBottomY : maxY;
            }

            int tempValue = 30; // 너무 타이트하게 잡으면 영상처리 데이터가 부족할까봐 조금 크게 영역 지정
            Rectangle boundRect = new Rectangle();
            boundRect.X = (int)(minX - tempValue);
            boundRect.Y = (int)(minY - tempValue);
            boundRect.Width = (int)(Math.Abs(maxX - minX) + tempValue * 2);
            boundRect.Height = (int)(Math.Abs(maxY - minY) + tempValue * 2);

            return boundRect;
        }

        public void CalcThreadholdLowHigh(Mat srcMat, Mat maskMat, AkkonImagingParam imagingParam,  out int lowThres, out int highThres)
        {
            lowThres = 0;
            highThres = 255;

            MCvScalar meanScalar = new MCvScalar();
            MCvScalar sigmaScalar = new MCvScalar();
            CvInvoke.MeanStdDev(srcMat, ref meanScalar, ref sigmaScalar, maskMat);

            AkkonThMode mode = imagingParam.Mode;
            if (mode == AkkonThMode.Auto)
            {
                var result = AutoCalcThreshold(srcMat, maskMat, imagingParam.Weight, meanScalar.V0, sigmaScalar.V0);
                lowThres = result.Item1;
                highThres = result.Item2;
            }
            else if(mode == AkkonThMode.White)
            {
                highThres = (int)(meanScalar.V0 + sigmaScalar.V0 * imagingParam.Weight);
                lowThres = 0;
            }
            else
            {
                highThres = 255;
                lowThres = (int)(meanScalar.V0 - sigmaScalar.V0 * imagingParam.Weight);
            }
        }

        private Tuple<int,int> AutoCalcThreshold(Mat srcMat, Mat maskMat, double thresWeight, double meanScalar, double sigmaScalar)
        {
            double maxVal = 0.0;
            double minVal = 0.0;
            Point maxValPoint = new Point();
            Point minValPoint = new Point();
            CvInvoke.MinMaxLoc(srcMat, ref minVal, ref maxVal, ref minValPoint, ref maxValPoint, maskMat);

            double[] histogram = GetHistogram(srcMat, maskMat);
            double[] chist = new double[histogram.Length];
            double[] cxhist = new double[histogram.Length];

            chist[0] = histogram[0];
            cxhist[0] = 0;
            for (int i = 1; i < 256; i++)
                cxhist[i] = cxhist[i - 1] + (double)i * histogram[i];

            double m = cxhist[255];

            double sum = 0;
            double subCount = 0;
            int bgHalf = 20;
            for (int i = 128 - bgHalf; i <= 128 + bgHalf; i++)
            {
                var data = histogram[i];
                float binVal = Convert.ToSingle(data);
                sum += (i - m) * (i - m) * binVal;

                subCount += binVal;
            }

            double sigma = Math.Sqrt(sum / subCount);

            int lowDist = (int)minVal;
            int highDist = (int)(255 - maxVal);

            double firstWeight = 2; // 이게 하드 코딩 되어있었음..

            int finalDist = 0;
            if (lowDist < highDist)
                finalDist = (int)(lowDist + sigma * firstWeight);
            else
                finalDist = 255 - (int)(maxVal - sigma * firstWeight);

            double lowOutlierSum = 0;
            double highOutlierSum = 0;

            for (int i = 0; i < finalDist; i++)
            {
                double binVal = histogram[i];
                lowOutlierSum += binVal;
            }

            if (lowOutlierSum == 0)
            {
                lowOutlierSum = histogram[(int)minVal];
                finalDist = (int)minVal;
            }

            for (int i = 255 - finalDist; i <= 255; i++)
            {
                double binVal = histogram[i];
                highOutlierSum += binVal;
            }

            if (highOutlierSum == 0)
            {
                highOutlierSum = histogram[(int)maxVal];
                finalDist = (int)(255 - maxVal);

                lowOutlierSum = 0;
                for (int i = 0; i < finalDist; i++)
                {
                    double binVal = histogram[i];
                    lowOutlierSum += binVal;
                }
            }

            double ratio = Math.Min(lowOutlierSum, highOutlierSum) / Math.Max(lowOutlierSum, highOutlierSum);

            int highThres = 255;
            int lowThres = 0;

            if (ratio < 0.8)
            {
                if (lowOutlierSum > highOutlierSum)
                {
                    highThres = 255;
                    lowThres = (int)(meanScalar - sigmaScalar * thresWeight);
                }
                else
                {
                    highThres = (int)(meanScalar + sigmaScalar * thresWeight);
                    lowThres = 0;
                }
            }
            else
            {
                // 확실하지 않으면 white 결함 검출로 보낸다..

                highThres = (int)(meanScalar + sigmaScalar* thresWeight);
                lowThres = 0;
            }

            return new Tuple<int, int>(lowThres, highThres);
        }

        public double[] GetHistogram(Mat srcMat, Mat maskMat)
        {
            int hbins = 256;
            int[] histSize = { hbins };
            float[] ranges = { 0, 256 };
            Mat hist = new Mat();
            int[] channels = { 0 };

            using (var vector = new VectorOfMat(srcMat))
                CvInvoke.CalcHist(vector, channels, maskMat, hist, histSize, ranges, false);

            var datas = hist.GetData();
            double[] histo = new double[256];

            int ntot = CvInvoke.CountNonZero(maskMat);
            if (ntot == 0)
                return null;

            for (int i = 0; i < datas.Length; i++)
            {
                var data = datas.GetValue(i, 0);
                histo[i] = Convert.ToDouble(data) / ntot;
            }

            return histo;
        }

        public Mat EnhanceX(Mat mat, AkkonImageFilterParam filterParam)
        {
            if (mat == null)
                return null;

            if (mat.NumberOfChannels != 1)
                return null;

            IntPtr src8Ptr = mat.DataPointer;
            int width = mat.Width;
            int height = mat.Height;

            var calcKernel = GenerateFilter(filterParam);
            unsafe
            {
                IntPtr src16Ptr = IPPWrapper.ippiMalloc_16s_C1(width, height, out int src16step); // 16비트 메모리 할당
                IntPtr dst16Ptr = IPPWrapper.ippiMalloc_16s_C1(width, height, out int dst16step); // 16비트 메모리 할당

                int result = IPPWrapper.ippiScale_8u16s_C1R(src8Ptr, width, src16Ptr, src16step, new IppiSize(width, height));
                IPPWrapper.ippiAddC_16s_C1IRSfs(-128, src16Ptr, src16step, new IppiSize(width, height), 0);

                short* pSrcBuffer = (short*)src16Ptr;
                short* pDstBuffer = (short*)dst16Ptr;

                SepConv16s_colfirst(pSrcBuffer, pDstBuffer, new IppiSize(width, height), calcKernel);

                IPPWrapper.ippiAddC_16s_C1IRSfs(128, dst16Ptr, dst16step, new IppiSize(width, height), 0);

                IntPtr dst8Ptr = IPPWrapper.ippsMalloc_8u(width * height);
                IPPWrapper.ippiScale_16s8u_C1R(dst16Ptr, dst16step, dst8Ptr, width, new IppiSize(width, height));

                Mat dstMat = MatHelper.IntPtrToMat(dst8Ptr, width, height, 1);

                IPPWrapper.ippiFree(src16Ptr);
                IPPWrapper.ippiFree(dst16Ptr);
                IPPWrapper.ippiFree(dst8Ptr);

                return dstMat;
            }
        }

        public Mat EnhanceY(Mat mat, AkkonImageFilterParam filterParam)
        {
            if (mat == null)
                return null;

            if (mat.NumberOfChannels != 1)
                return null;

            IntPtr src8Ptr = mat.DataPointer;
            int width = mat.Width;
            int height = mat.Height;

            var calcKernel = GenerateFilter(filterParam);
            unsafe
            {
                IntPtr src16Ptr = IPPWrapper.ippiMalloc_16s_C1(width, height, out int src16step); // 16비트 메모리 할당
                IntPtr dst16Ptr = IPPWrapper.ippiMalloc_16s_C1(width, height, out int dst16step); // 16비트 메모리 할당

                int result = IPPWrapper.ippiScale_8u16s_C1R(src8Ptr, width, src16Ptr, src16step, new IppiSize(width, height));
                IPPWrapper.ippiAddC_16s_C1IRSfs(-128, src16Ptr, src16step, new IppiSize(width, height), 0);

                short* pSrcBuffer = (short*)src16Ptr;
                short* pDstBuffer = (short*)dst16Ptr;

                SepConv16s_rowfirst(pSrcBuffer, pDstBuffer, new IppiSize(width, height), calcKernel);

                IPPWrapper.ippiAddC_16s_C1IRSfs(128, dst16Ptr, dst16step, new IppiSize(width, height), 0);

                IntPtr dst8Ptr = IPPWrapper.ippsMalloc_8u(width * height);
                IPPWrapper.ippiScale_16s8u_C1R(dst16Ptr, dst16step, dst8Ptr, width, new IppiSize(width, height));
                
                Mat dstMat = MatHelper.IntPtrToMat(dst8Ptr, width, height, 1);

                IPPWrapper.ippiFree(src16Ptr);
                IPPWrapper.ippiFree(dst16Ptr);
                IPPWrapper.ippiFree(dst8Ptr);

                return dstMat;
            }
        }

        private unsafe void SepConv16s_colfirst(short* pSrcBuffer, short* pDstBuffer, IppiSize size, AkkonImageKernel kernel)
        {
            short** ppDst;
            short** ppSrc;

            short* pTmp;

            byte* pBufferCol;
            byte* pBufferRow;

            int nc = kernel.GusSize;
            int nr = kernel.LogSize;

            // compute the kernel semisizes
            int ncss = nc >> 1;
            int nrss = nr >> 1;

            // compute the kernel offsets (0 -> odd, 1 -> even)
            int co = 1 - (nc % 2);
            int ro = 1 - (nr % 2);

            IppiSize tmpSize;
            tmpSize.Width = size.Width;
            tmpSize.Height = size.Height + nc + 1;

            pTmp = (short*)IPPWrapper.ippiMalloc_16s_C1(tmpSize.Width, tmpSize.Height, out int tmpStep);
            ppSrc = (short**)IPPWrapper.ippsMalloc_8u((size.Height + nc + 1) * sizeof(short*));
            ppDst = (short**)IPPWrapper.ippsMalloc_8u(size.Height * sizeof(short*));

            int status = IPPWrapper.ippiFilterRowBorderPipelineGetBufferSize_16s_C1R(size, nr, out int sizerow);
            status = IPPWrapper.ippiFilterColumnPipelineGetBufferSize_16s_C1R(size, nc, out int sizecol);

            pBufferCol = (byte*)IPPWrapper.ippsMalloc_8u(sizecol);
            pBufferRow = (byte*)IPPWrapper.ippsMalloc_8u(sizerow);

            nrss -= ro;
            ncss -= co;

            //	organize dst buffer
            for (int ii = 0, jj = ncss; ii < size.Height; ++ii, ++jj)
            {
                ppSrc[jj] = pSrcBuffer + ii * size.Width;
                ppDst[ii] = pDstBuffer + ii * size.Width;
            }

            // for border replicate
            for (int ii = 0, jj = size.Height + ncss; ii < ncss; ii++, jj++)
            {
                ppSrc[ii] = ppSrc[ncss];
                ppSrc[jj] = ppSrc[size.Height + ncss - 1];
            }

            if (co > 0)
            {
                ppSrc[size.Height + (ncss * 2)] = ppSrc[size.Height + ncss - 1];
            }

            IntPtr xkernel = Marshal.AllocHGlobal(kernel.GusKernel.Length * sizeof(short));
            Marshal.Copy(kernel.GusKernel, 0, xkernel, kernel.GusKernel.Length);
            short* pXkernel = (short*)xkernel;

            int xKernelSize = kernel.GusSize;
            int xDivisor = (int)kernel.GusDivisor;
            
          
            status = IPPWrapper.ippiFilterColumnPipeline_16s_C1R(ppSrc, pTmp, size.Width * sizeof(short), size, pXkernel, xKernelSize, xDivisor, pBufferCol);

            IntPtr yKernel = Marshal.AllocHGlobal(kernel.LogKernel.Length * sizeof(short));
            Marshal.Copy(kernel.LogKernel, 0, yKernel, kernel.LogKernel.Length);
            short* pYkernel = (short*)yKernel;

            int yKernelSize = kernel.LogSize;
            int yDivisor = (int)kernel.LogDivisor;

            status = IPPWrapper.ippiFilterRowBorderPipeline_16s_C1R(pTmp, size.Width * sizeof(short), ppDst, size, pYkernel, yKernelSize, nrss, 1, 0, yDivisor, pBufferRow);

            IPPWrapper.ippiFree((IntPtr)pTmp);
            IPPWrapper.ippiFree((IntPtr)ppSrc);
            IPPWrapper.ippiFree((IntPtr)ppDst);
            IPPWrapper.ippiFree((IntPtr)pBufferRow);
            IPPWrapper.ippiFree((IntPtr)pBufferCol);
            Marshal.FreeHGlobal(xkernel);
            Marshal.FreeHGlobal(yKernel);

        }

        private unsafe void SepConv16s_rowfirst(short* pSrcBuffer, short* pDstBuffer, IppiSize size, AkkonImageKernel kernel)
        {
            short** ppDst;
            short** ppSrc;

            short* pTmp;

            byte* pBufferCol;
            byte* pBufferRow;

            int nc = kernel.LogSize;
            int nr = kernel.GusSize;

            // compute the kernel semisizes
            int ncss = nc >> 1;
            int nrss = nr >> 1;

            // compute the kernel offsets (0 -> odd, 1 -> even)
            int co = 1 - (nc % 2);
            int ro = 1 - (nr % 2);

            IppiSize tmpSize;
            tmpSize.Width = size.Width;
            tmpSize.Height = size.Height + nc + 1;

            pTmp = (short*)IPPWrapper.ippiMalloc_16s_C1(tmpSize.Width, tmpSize.Height, out int tmpStep);
            ppSrc = (short**)IPPWrapper.ippsMalloc_8u((size.Height + nc + 1) * sizeof(short*));
            ppDst = (short**)IPPWrapper.ippsMalloc_8u(size.Height * sizeof(short*));

            int status = IPPWrapper.ippiFilterRowBorderPipelineGetBufferSize_16s_C1R(size, nr, out int sizerow);
            status = IPPWrapper.ippiFilterColumnPipelineGetBufferSize_16s_C1R(size, nc, out int sizecol);

            pBufferCol = (byte*)IPPWrapper.ippsMalloc_8u(sizecol);
            pBufferRow = (byte*)IPPWrapper.ippsMalloc_8u(sizerow);

            nrss -= ro;
            ncss -= co;

            //	organize dst buffer
            for (int ii = 0, jj = ncss; ii < size.Height; ++ii, ++jj)
            {
                ppDst[ii] = pTmp + jj * size.Width;
                ppSrc[jj] = pTmp + jj * size.Width;
            }

            for (int ii = 0, jj = size.Height + ncss; ii < ncss; ii++, jj++)
            {
                ppSrc[ii] = ppSrc[ncss];
                ppSrc[jj] = ppSrc[size.Height + ncss - 1];
            }

            if (co > 0)
            {
                ppSrc[size.Height + (ncss * 2)] = ppSrc[size.Height + ncss - 1];
            }

            IntPtr xkernel = Marshal.AllocHGlobal(kernel.GusKernel.Length * sizeof(short));
            Marshal.Copy(kernel.GusKernel, 0, xkernel, kernel.GusKernel.Length);
            short* pXkernel = (short*)xkernel;

            int xkernelSize = kernel.GusSize;
            int xDivisor = (int)kernel.GusDivisor;
            status = IPPWrapper.ippiFilterRowBorderPipeline_16s_C1R(pSrcBuffer, size.Width * sizeof(short), ppDst, size, pXkernel, xkernelSize, nrss, 1, 0, xDivisor, pBufferRow);


            IntPtr yKernel = Marshal.AllocHGlobal(kernel.LogKernel.Length * sizeof(short));
            Marshal.Copy(kernel.LogKernel, 0, yKernel, kernel.LogKernel.Length);
            short* pYkernel = (short*)yKernel;

            int yKernelSize = kernel.LogSize;
            int yDivisor = (int)kernel.LogDivisor;

            status = IPPWrapper.ippiFilterColumnPipeline_16s_C1R(ppSrc, pDstBuffer, size.Width * sizeof(short), size, pYkernel, yKernelSize, yDivisor, pBufferCol);

            IPPWrapper.ippiFree((IntPtr)pTmp);
            IPPWrapper.ippiFree((IntPtr)ppSrc);
            IPPWrapper.ippiFree((IntPtr)ppDst);
            IPPWrapper.ippiFree((IntPtr)pBufferRow);
            IPPWrapper.ippiFree((IntPtr)pBufferCol);

            Marshal.FreeHGlobal(xkernel);
            Marshal.FreeHGlobal(yKernel);
        }

        private AkkonImageKernel GenerateFilter(AkkonImageFilterParam filterParam)
        {
            double s_lfGusFltPeak = 71; // 메크론 71
            double s_lfLOGFltPeak = 50; // 메크론 50

            int gusAnc = filterParam.GusWidth / 2;

            short[] gusKernel = new short[filterParam.GusWidth];
            short[] pGUS = new short[filterParam.GusWidth];

            double scale = Math.Abs(s_lfGusFltPeak / Gaussian(0.0, filterParam.Sigma));
            double gusSum = 0;

            for (int i = 0; i < filterParam.GusWidth; i++)
            {
                int x = i - gusAnc;
                double val = Gaussian(x, filterParam.Sigma) * scale;
                pGUS[i] = (short)(val + (val >= 0 ? 0.5 : -0.5));
                gusSum += pGUS[i];
            }

            // flip
            for (int i = 0; i < filterParam.GusWidth; i++)
            {
                gusKernel[i] = pGUS[filterParam.GusWidth - i - 1];
            }

            // Log
            scale = Math.Abs(s_lfLOGFltPeak / LOG(0.0, filterParam.Sigma));
          
            int logAnc = filterParam.LogWidth / 2;

            short[] pLOG = new short[filterParam.LogWidth];
            short[] logKernel = new short[filterParam.LogWidth];

            double logSum = 0;
            for (int i = 0; i < filterParam.LogWidth; i++)
            {
                int x = i - logAnc;
                double val = -1.0 * LOG(x, filterParam.Sigma) * scale * filterParam.ScaleFactor;
                pLOG[i] = (short)(val + (val >= 0 ? 0.5 : -0.5));
                logSum += pLOG[i];
            }
            // flip
            for (int i = 0; i < filterParam.LogWidth; i++)
            {
                logKernel[i] = pLOG[filterParam.LogWidth - i - 1];
            }

            if (logSum > 0)
            {
                if ((filterParam.LogWidth % 2) == 0)
                    logAnc--;  // because of 'flip'

                double ancValue = logKernel[logAnc];
                logKernel[filterParam.LogWidth - 1] = (short)(logKernel[filterParam.LogWidth - 1] - logSum);
            }

            AkkonImageKernel kernel = new AkkonImageKernel();
            kernel.GusSize = filterParam.GusWidth;
            kernel.GusDivisor = gusSum;
            kernel.GusKernel = gusKernel;

            kernel.LogSize = filterParam.LogWidth;
            kernel.LogDivisor = 32;
            kernel.LogKernel = logKernel;

            return kernel;
        }

        private double Gaussian(double x, double sigma)
        {
            return (1.0 / (Math.Sqrt(Math.PI * 2) * sigma) * Math.Exp(-x * x / (2.0 * sigma * sigma)));
        }

        double LOG(double x, double sigma)
        {
            double t;

            t = x * x / (sigma * sigma);
            return (1.0 / (Math.Sqrt(Math.PI * 2) * sigma * sigma * sigma) * (t - 1.0) * Math.Exp(t / -2.0));
        }

        private unsafe void FindShadowPoint(Mat enhMat, Mat binMat,ref List<BlobPos> blobList, Rectangle rcOneLead)
        {
            int nSearchOffset = 4;

            int defectType = 0;
            for (int i = 0; i < blobList.Count(); i++)
            {
                BlobPos blob = blobList[i];
                Rectangle rcBlob = blob.BoundingRect;
                Point ptCom = new Point((int)blob.CenterX, (int)blob.CenterY);
                Point ptCenter = new Point(ptCom.X, ptCom.Y);

                int bottom = rcBlob.Y + rcBlob.Height;
                for (int y = ptCom.Y; y < rcBlob.Y + rcBlob.Height; y++)
                {
                    byte* pEnhLine = (byte*)(enhMat.DataPointer + (y + enhMat.Step));
                    if (defectType == 0)
                    {
                        if(pEnhLine[ptCom.X] > 130)
                        {
                            bottom = y;
                            break;
                        }
                    }
                    else if(defectType == 1)
                    {
                        if (pEnhLine[ptCom.X] < 126)
                        {
                            bottom = y;
                            break;
                        }
                    }
                }
                int nHeight = (int)Math.Min(10, rcBlob.Height * 1.5);
                nHeight = Math.Max(5, nHeight);
                int nLimit = Math.Min(bottom + nHeight, rcOneLead.Y + rcOneLead.Height);
                int nShadowMin = 255;
                int nShadowMax = 0;

                int nSearchStart = Math.Max(ptCom.X - nSearchOffset, rcOneLead.X);
                int nSearchEnd = Math.Min(ptCom.X + nSearchOffset, rcOneLead.X + rcOneLead.Width);

                int nSearchStartY = bottom;
                int nSearchEndY = nLimit;

                int nSearchStartX = nSearchStart;
                int nSearchEndX = nSearchEnd;

                int scanpos = 0;
                bool bShadowFound = false;
                Point ptShadowMin = new Point();
                for (int y = bottom; y < nLimit; y++)
                {
                    scanpos = y;
                    byte* pMaskLine = (byte*)(binMat.DataPointer + (y + binMat.Step));
                    byte* pEnhLine = (byte*)(enhMat.DataPointer + (y + enhMat.Step));

                    for (int x = nSearchStart; x <= nSearchEnd; x++)
                    {
                        int shadowval = pEnhLine[x];

                        if (!bShadowFound && pMaskLine[x] == 0)
                        {
                            // 이조건의 의미를 파악해 보자 .. 2018.04.11
                            if (y - bottom > 1)
                                bShadowFound = false;
                            else if (y - bottom <= 1)
                            {
                                bShadowFound = true;
                                ptCenter.Y = y;
                            }
                        }

                        if (pMaskLine[x] == 0)
                        {
                            if (shadowval > nShadowMax)
                            {
                                nShadowMax = shadowval;
                            }

                            if (shadowval < nShadowMin)
                            {
                                nShadowMin = shadowval;

                                ptShadowMin.Y = y;
                                ptShadowMin.X = x;
                            }
                        }
                    }
                }
                blob.ShadowFound = bShadowFound;
                blob.ShadowPeak = nShadowMin;
            }
        }
    }

    public enum AkkonThMode
    {
        Auto,
        White,
        Black,
    }

    public enum AkkonAlgoritmType
    {
        OpenCV,
        Cognex,
    }

    public enum ShadowDir
    {
        TOP,
        DN,
        UP,
        LEFT,
        RIGHT,
    }
}
