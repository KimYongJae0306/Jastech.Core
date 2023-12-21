using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Jastech.Framework.Imaging.Helper
{
    public static class MatHelper
    {
        public static object lock1 =  new object();
        // Stride와 Width가 동일할 경우 사용
        public static Mat ByteArrayToMat(byte[] data, int width, int height, int channel)
        {
            Mat mat = new Mat(new Size(width, height), DepthType.Cv8U, channel);
            Marshal.Copy(data, 0, mat.DataPointer, mat.Step * mat.Height);
            return mat;
        }

        // stride 개념 적용할 경우 사용
        public static Mat IntPtrToMat(IntPtr intPtr, int width, int height, int numberOfChannels)
        {
            if(numberOfChannels == 1)
            {
                byte[] byteArray = new byte[width * height];
                Marshal.Copy(intPtr, byteArray, 0, byteArray.Length);
                return MatHelper.ByteArrayToMat(byteArray, width, height, numberOfChannels);
            }

            // 작성 요망
            return new Mat();
        }

        public static float[] MatToFloatArray(Mat mat)
        {
            float[] floatArray = new float[mat.Width * mat.Height * mat.NumberOfChannels];
            Marshal.Copy(mat.DataPointer, floatArray, 0, floatArray.Length);
            return floatArray;
        }

        public static Mat DeepCopy(Mat mat)
        {
            byte[] data = MatHelper.MatToByteArray(mat);
            return MatHelper.ByteArrayToMat(data, mat.Width, mat.Height, mat.NumberOfChannels);
        }

        public static Mat CropRoi(Mat mat, Rectangle roi)
        {
            int padLeft = 0 - roi.X;
            int padTop = 0 - roi.Y;
            int padRight = (roi.X + roi.Width) - mat.Width;
            int padBottom = (roi.Y + roi.Height) - mat.Height;
            Rectangle nonPadRect = new Rectangle(
                roi.X + (padLeft > 0 ? padLeft : 0),
                roi.Y + (padTop > 0 ? padTop : 0),
                roi.Width - (padRight > 0 ? padRight : 0) - (padLeft > 0 ? padLeft : 0),
                roi.Height - (padBottom > 0 ? padBottom : 0) - (padTop > 0 ? padTop : 0));

            Rectangle matRect = new Rectangle(0, 0, mat.Width, mat.Height);
            matRect.Intersect(nonPadRect);
            if (matRect.IsEmpty)
                return Mat.Zeros(roi.Height, roi.Width, DepthType.Cv8U, mat.NumberOfChannels);

            Mat boundMatOrigin = new Mat(mat, nonPadRect).Clone();
            if (padLeft > 0 || padTop > 0 || padRight > 0 || padBottom > 0)
            {
                CvInvoke.CopyMakeBorder(boundMatOrigin, boundMatOrigin,
                    padTop > 0 ? padTop : 0,
                    padBottom > 0 ? padBottom : 0,
                    padLeft > 0 ? padLeft : 0,
                    padRight > 0 ? padRight : 0,
                    BorderType.Constant, new MCvScalar(0));
            }
            return boundMatOrigin;
        }

        public static Mat CropRoi(Mat mat, RotatedRect roi, bool interpolation = true)
        {
            // TODO: 조준형: 회전이 거의 없는 검사객체는 아래 주석을 해제하여 성능을 올릴 수 있음.
            //if (Math.Abs(roi.Angle) < 0.25)
            //    return CvRoi(image, roi.MinAreaRect());

            Rectangle boundRect = roi.MinAreaRect();
            int padLeft = 0 - boundRect.X;
            int padTop = 0 - boundRect.Y;
            int padRight = (boundRect.X + boundRect.Width) - mat.Width;
            int padBottom = (boundRect.Y + boundRect.Height) - mat.Height;
            Rectangle nonPadRect = new Rectangle(
                boundRect.X + (padLeft > 0 ? padLeft : 0),
                boundRect.Y + (padTop > 0 ? padTop : 0),
                boundRect.Width - (padRight > 0 ? padRight : 0) - (padLeft > 0 ? padLeft : 0),
                boundRect.Height - (padBottom > 0 ? padBottom : 0) - (padTop > 0 ? padTop : 0));

            Mat boundMatOrigin = new Mat(mat, nonPadRect);
            if (padLeft > 0 || padTop > 0 || padRight > 0 || padBottom > 0)
            {
                CvInvoke.CopyMakeBorder(boundMatOrigin, boundMatOrigin,
                    padTop > 0 ? padTop : 0,
                    padBottom > 0 ? padBottom : 0,
                    padLeft > 0 ? padLeft : 0,
                    padRight > 0 ? padRight : 0,
                    BorderType.Constant, new MCvScalar(0));
            }
            //if (boundRect.X < 0 || boundRect.Y < 0 || boundRect.X >= image.Width || boundRect.Y >= image.Height ||
            //    boundRect.X + boundRect.Width >= image.Width || boundRect.Y + boundRect.Height >= image.Height)
            //{
            //    return new Mat(image, new Rectangle(0, 0, 1, 1));
            //}

            Mat boundMat = new Mat();
            boundMatOrigin.CopyTo(boundMat);
            boundMatOrigin.Dispose();
            roi.Center.X -= boundRect.X;
            roi.Center.Y -= boundRect.Y;

            Mat trMat = new Mat(), rotatedMat = new Mat(), croppedMat = new Mat();
            float angle = roi.Angle;
            Size roiSize = Size.Round(roi.Size);
            CvInvoke.GetRotationMatrix2D(roi.Center, angle, 1, trMat);
            CvInvoke.WarpAffine(boundMat, rotatedMat, trMat, boundMat.Size, interpolation ? Inter.Linear : Inter.Nearest);
            boundMat.Dispose();

            // TODO: 조준형: 회전 중심이 이게 맞을지 모르겠다.
            CvInvoke.GetRectSubPix(rotatedMat, roiSize, new PointF(roi.Center.X - 0.5f, roi.Center.Y - 0.5f), croppedMat);
            rotatedMat.Dispose();

            return croppedMat;
        }

        public static Mat Resize(Mat sourceMat, double resizeRatio)
        {
            Mat resizeMat = new Mat();
            Size newSize = new Size((int)(sourceMat.Width * resizeRatio), (int)(sourceMat.Height * resizeRatio));
            CvInvoke.Resize(sourceMat, resizeMat, newSize);

            return resizeMat;
        }

        public static byte[] MatToByteArray(Mat mat)
        {
            byte[] output = new byte[mat.Width * mat.Height * mat.NumberOfChannels];
            Marshal.Copy(mat.DataPointer, output, 0, output.Length);
            return output;
        }

        public static Mat Rotate(Mat image, double angle)
        {
            PointF center = new PointF((float)(image.Width / 2.0f), (float)(image.Height / 2.0f));
            Matrix<double> trMat = new Matrix<double>(2, 3);
            CvInvoke.GetRotationMatrix2D(center, -angle, 1, trMat);
            Mat imageRotated = new Mat();
            CvInvoke.WarpAffine(image, imageRotated, trMat, new Size(image.Width, image.Height), Inter.Linear, Warp.Default, BorderType.Constant, new MCvScalar(0));
            return imageRotated;
        }

        public static Mat Transpose(Mat image)
        {
           Size size = new Size(image.Width, image.Height);

            Mat destMat = new Mat(size, image.Depth, image.NumberOfChannels);
            CvInvoke.Transpose(image, destMat);

            return destMat;
        }
        
        public static void RotationTransform(PointF apntCenter, PointF apntOffset, double adAngle, ref System.Drawing.Point[] apntTarget)
        {
            PointF pntTempPos;

            for (int i = 0; i < 4; i++)
            {
                pntTempPos = apntTarget[i];
                pntTempPos.X = pntTempPos.X + apntOffset.X;
                pntTempPos.Y = pntTempPos.Y + apntOffset.Y;
                apntTarget[i].X = (int)(Math.Round(apntCenter.X + (((Math.Cos(DegreeToRadian(adAngle)) * (pntTempPos.X - apntCenter.X)) - (Math.Sin(DegreeToRadian(adAngle)) * (pntTempPos.Y - apntCenter.Y))))));
                apntTarget[i].Y = (int)(Math.Round(apntCenter.Y + (((Math.Sin(DegreeToRadian(adAngle)) * (pntTempPos.X - apntCenter.X)) + (Math.Cos(DegreeToRadian(adAngle)) * (pntTempPos.Y - apntCenter.Y))))));
            }
        }

        public static PointF RotationPoint(PointF targetPoint, PointF centerPoint, PointF offset, double angle)
        {
            PointF tempPoint = new PointF();
            tempPoint.X = targetPoint.X + offset.X;
            tempPoint.Y = targetPoint.Y + offset.Y;

            double cos = Math.Cos(DegreeToRadian(angle));
            double sin = Math.Sin(DegreeToRadian(angle));

            double deltaCosX = cos * (tempPoint.X - centerPoint.X);
            double deltaSinY = sin * (tempPoint.Y - centerPoint.Y);

            double deltaSinX = sin * (tempPoint.X - centerPoint.X);
            double deltaCosY = cos * (tempPoint.Y - centerPoint.Y);

            var calcX =  centerPoint.X + deltaCosX - deltaSinY;
            var calcY = centerPoint.Y + deltaSinX + deltaCosY;

            return new PointF((float)calcX, (float)calcY);
        }
        
        public static double DegreeToRadian(double adAngle)
        {
            return adAngle * Math.PI / 180.0;
        }

        public static Mat ColorChannelSeperate(Mat mat, ColorChannel colorChannel)
        {
            if (mat == null)
                return null;
                     
            int idx = (int)colorChannel;
            Mat rtMat;

            if (mat.Depth == DepthType.Cv8U && mat.NumberOfChannels == 3)
            {
                using (VectorOfMat vctMat = new VectorOfMat())
                {
                    rtMat = new Mat();
                    CvInvoke.Split(mat, vctMat);

                    vctMat[idx].CopyTo(rtMat);
                }

                return rtMat;
            }
            return null;
        }

        public static float[] GetHistogram(Mat srcMat, Mat maskMat)
        {
            DenseHistogram hist = new DenseHistogram(256, new RangeF(0, 256));

            var grayImages = new Image<Gray, byte>[] { srcMat.ToImage<Gray, byte>() };
            var maskImage = maskMat?.ToImage<Gray, byte>();
            hist.Calculate(grayImages, false, maskImage);

            return hist.GetBinValues();
        }

        public enum ColorChannel
        {
            B, G, R
        }
    }
}
