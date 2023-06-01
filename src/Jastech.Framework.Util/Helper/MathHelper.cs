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

        public static double GetTheta(PointF referencePoint1, PointF referencePoint2)
        {
            double theta = Math.Atan2(referencePoint2.Y - referencePoint1.Y, referencePoint2.X - referencePoint1.X);
            return RadToDeg(theta);
        }

        public static PointF GetCoordinate(PointF inputPoint, double degree, PointF centerPoint, PointF left, PointF right)
        {
            PointF result = new PointF();

            //PointF res = new PointF();
            //res.X = (float)(Math.Cos(degree) * inputPoint.X);
            //res.Y = (float)(Math.Sin(degree) * inputPoint.Y);

            //result.X = (float)(Math.Cos(degree) * inputPoint.X) - (float)(Math.Sin(degree) * inputPoint.Y);
            //result.Y = (float)(Math.Sin(degree) * inputPoint.X) + (float)(Math.Cos(degree) * inputPoint.Y);


            result.X = (float)(Math.Cos(degree) * inputPoint.X);
            result.Y = (float)(Math.Cos(degree) * inputPoint.Y);


            return result;
        }
        
        public static double GetDistance(Point point1, Point point2)
        {
            int dx = point2.X - point1.X;
            int dy = point2.Y - point1.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public static double GetSlope(PointF point1, PointF point2)
        {
            double deltaX = Math.Abs(point1.X - point2.X);
            double deltaY = Math.Abs(point1.Y - point2.Y);

            return deltaY / deltaX;
        }
    }
}
