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

        public static Mat ColorChannelSprate(Mat mat, ColorChannel colorChannel)
        {
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

        public enum ColorChannel
        {
            B, G, R
        }
    }
}
