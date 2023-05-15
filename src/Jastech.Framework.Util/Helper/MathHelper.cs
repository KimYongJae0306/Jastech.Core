using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Util.Helper
{
    public static class MathHelper
    {
        public static PointF Rotate(PointF point, PointF centerPt, double angleDegree)
        {
            if (angleDegree == 0)
                return point;

            PointF tempPoint = new PointF(point.X, point.Y);

            tempPoint.X -= centerPt.X;
            tempPoint.Y -= centerPt.Y;

            tempPoint.Y *= -1;

            double angleRad = DegToRad(angleDegree);
            double X = (double)((tempPoint.X * Math.Cos(angleRad)) - (tempPoint.Y * Math.Sin(angleRad)));
            double Y = (double)((tempPoint.X * Math.Sin(angleRad)) + (tempPoint.Y * Math.Cos(angleRad)));

            tempPoint.X = (float)(X + centerPt.X);
            tempPoint.Y = (float)((Y * (-1)) + centerPt.Y);

            return tempPoint;
        }

        public static double DegToRad(double deg)
        {
            return deg / 180.0 * Math.PI;
        }

        public static double RadToDeg(double rad)
        {
            return rad * 180.0 / Math.PI;
        }

        public static PointF ThetaCoordinate(PointF referencePoint1, PointF referencePoint2, PointF inputPoint)
        {
            PointF result = new PointF();
            double theta = 0.0;

            if (referencePoint2.X > referencePoint1.X) 
                theta = Math.Atan2(referencePoint2.Y - referencePoint1.Y, referencePoint2.X - referencePoint1.X);
            else
                theta = Math.Atan2(referencePoint1.Y - referencePoint2.Y, referencePoint1.X - referencePoint2.X);

            double degree = RadToDeg(theta);

            result.X = (float)(Math.Cos(degree) * inputPoint.X);
            result.Y = (float)(Math.Sin(degree) * inputPoint.Y);

            return result;
        }

        public static double GetTheta(PointF referencePoint1, PointF referencePoint2)
        {
            double theta = 0.0;

            if (referencePoint2.X > referencePoint1.X)
                theta = Math.Atan2(referencePoint2.Y - referencePoint1.Y, referencePoint2.X - referencePoint1.X);
            else
                theta = Math.Atan2(referencePoint1.Y - referencePoint2.Y, referencePoint1.X - referencePoint2.X);

            double degree = RadToDeg(theta);

            return degree;
        }

        public static PointF GetCoordinate(PointF inputPoint, double degree)
        {
            PointF result = new PointF();

            result.X = (float)(Math.Cos(degree) * inputPoint.X);
            result.Y = (float)(Math.Sin(degree) * inputPoint.Y);

            return result;
        }
    }
}
