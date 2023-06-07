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

        public static PointF GetCoordinate(PointF inputPoint, double degree)
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
        
        public static PointF GetCoordi(PointF teachedLeftPoint, PointF teachedRightPoint, PointF searchedLeftPoint, PointF searchedRightPoint, PointF inputPoint)
        {
            // 티칭한 각도
            double teachedTheta = Math.Atan2((teachedRightPoint.Y - teachedLeftPoint.Y), (teachedRightPoint.X - teachedLeftPoint.X));
            if (teachedTheta > 180.0)
                teachedTheta -= 360.0;

            // 찾은 각도
            double searchedTheta = Math.Atan2((searchedRightPoint.Y - searchedLeftPoint.Y), (searchedRightPoint.X - searchedLeftPoint.X));
            if (searchedTheta > 180.0)
                searchedTheta -= 360.0;

            double diffTheta = searchedTheta - teachedTheta;


            // 찾은 센터포인트
            PointF searchedCenterPoint = new PointF();
            searchedCenterPoint.X = (searchedLeftPoint.X + searchedRightPoint.X) / 2;
            searchedCenterPoint.Y = (searchedLeftPoint.Y + searchedRightPoint.Y) / 2;

            // 티칭한 센터포인트
            PointF teachedCenterPoint = new PointF();
            teachedCenterPoint.X = (teachedLeftPoint.X + teachedRightPoint.X) / 2;
            teachedCenterPoint.Y = (teachedLeftPoint.Y + teachedRightPoint.Y) / 2;

            // 센터끼리 틀어진 오프셋 값
            double offsetX = searchedCenterPoint.X - teachedCenterPoint.X;
            double offsetY = searchedCenterPoint.Y - teachedCenterPoint.Y;
            PointF offset = new PointF((float)offsetX, (float)offsetY);


            // 보정 전 좌표
            inputPoint.X += offset.X;
            inputPoint.Y += offset.Y;

            // 센터, 옵셋, 각도, 출력
            var xx = Math.Round(searchedCenterPoint.X + ((Math.Cos(diffTheta * (Math.PI / 180.0)) * (inputPoint.X - searchedCenterPoint.X)) - (Math.Sin(diffTheta * (Math.PI / 180.0)) * (inputPoint.Y - searchedCenterPoint.Y))));
            var yy = Math.Round(searchedCenterPoint.Y + ((Math.Sin(diffTheta * (Math.PI / 180.0)) * (inputPoint.X - searchedCenterPoint.X)) + (Math.Cos(diffTheta * (Math.PI / 180.0)) * (inputPoint.Y - searchedCenterPoint.Y))));

            PointF outputPoint = new PointF();
            outputPoint.X = (float)xx;
            outputPoint.Y = (float)yy;

            return outputPoint;
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
