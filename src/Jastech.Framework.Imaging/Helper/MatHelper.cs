using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Imaging.Helper
{
    public static class MatHelper
    {
        public static Mat Rotate(Mat image, double angle)
        {
            Point2f center = new Point2f(image.Width / 2.0f, image.Height / 2.0f);

            Mat matrix = Cv2.GetRotationMatrix2D(center, angle, 1);

            Mat imageRotated = new Mat(new Size(image.Width, image.Height), image.Type());
            Cv2.WarpAffine(image, imageRotated, matrix, new Size(image.Width, image.Height));

            matrix.Dispose();

            return imageRotated;
        }

        public static Mat Transpose(Mat image)
        {
            Size size = new Size(image.Width, image.Height);

            Mat destMat = new Mat(size, image.Type());
            Cv2.Transpose(image, destMat);

            return destMat;
        }

        public static void RotationTransform(Point2d apntCenter, Point2d apntOffset, double adAngle, ref Point[] apntTarget)
        {
            Point2d pntTempPos;

            for (int i = 0; i < 4; i++)
            {
                pntTempPos = (OpenCvSharp.Point2d)apntTarget[i];
                pntTempPos.X = pntTempPos.X + apntOffset.X;
                pntTempPos.Y = pntTempPos.Y + apntOffset.Y;
                apntTarget[i].X = (int)(Math.Round(apntCenter.X + (((Math.Cos(DegreeToRadian(adAngle)) * (pntTempPos.X - apntCenter.X)) - (Math.Sin(DegreeToRadian(adAngle)) * (pntTempPos.Y - apntCenter.Y))))));
                apntTarget[i].Y = (int)(Math.Round(apntCenter.Y + (((Math.Sin(DegreeToRadian(adAngle)) * (pntTempPos.X - apntCenter.X)) + (Math.Cos(DegreeToRadian(adAngle)) * (pntTempPos.Y - apntCenter.Y))))));
            }
        }

        public static Point2d RotationPoint(Point2d targetPoint, Point2d centerPoint, Point2d offset, double angle)
        {
            Point2d tempPoint = new Point2d();
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

            return new Point2d(calcX, calcY);
        }


        public static double DegreeToRadian(double adAngle)
        {
            return adAngle * OpenCvSharp.Cv2.PI / 180.0;
        }
    }
}
