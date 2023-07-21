using System;
using System.Drawing;

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

        public static double GetRadian(PointF referencePoint1, PointF referencePoint2)
        {
            double deltaX = referencePoint2.X - referencePoint1.X;
            double deltaY = referencePoint2.Y - referencePoint2.Y;
            return Math.Atan2(deltaY, deltaX);
        }
        
        public static PointF GetCenterPoint(PointF point1, PointF point2)
        {
            PointF centerPoint = new PointF();

            double x = (point1.X + point2.X) / 2.0;
            double y = (point1.Y + point2.Y) / 2.0;

            centerPoint.X = Convert.ToSingle(x);
            centerPoint.Y = Convert.ToSingle(y);

            return centerPoint;
        }

        public static PointF GetOffset(PointF point1, PointF point2)
        {
            PointF offset = new PointF();

            offset.X = point2.X - point1.X;
            offset.Y = point2.Y - point1.Y;

            return offset;
        }

        public static PointF GetCoordinate(PointF centerPoint, double diffRadian, PointF offset, PointF inputPoint)
        {
            PointF outputPoint = new PointF();

            // 보정 전 좌표
            inputPoint.X += offset.X;
            inputPoint.Y += offset.Y;

            // 센터, 옵셋, 각도, 출력
            var coordinateX = Math.Round(centerPoint.X + ((Math.Cos(RadToDeg(diffRadian)) * (inputPoint.X - centerPoint.X)) - (Math.Sin(RadToDeg(diffRadian)) * (inputPoint.Y - centerPoint.Y))));
            var coordinateY = Math.Round(centerPoint.Y + ((Math.Sin(RadToDeg(diffRadian)) * (inputPoint.X - centerPoint.X)) + (Math.Cos(RadToDeg(diffRadian)) * (inputPoint.Y - centerPoint.Y))));

            outputPoint.X = (float)coordinateX;
            outputPoint.Y = (float)coordinateY;

            return outputPoint;
        }

        public static PointF GetCoordinate(PointF teachedLeftPoint, PointF teachedRightPoint, PointF searchedLeftPoint, PointF searchedRightPoint, PointF inputPoint)
        {
            //// 티칭한 각도
            //double teachedRadian = GetRadian(teachedLeftPoint, teachedRightPoint);
            //if (teachedRadian > 180.0)
            //    teachedRadian -= 360.0;

            //// 찾은 각도
            //double searchedRadian = GetRadian(searchedLeftPoint, searchedRightPoint);
            //if (searchedRadian > 180.0)
            //    searchedRadian -= 360.0;

            //// 각도 차이
            //double diffRadian = searchedRadian - teachedRadian;

            //// 티칭한 센터포인트
            //PointF teachedCenterPoint = GetCenterPoint(teachedLeftPoint, teachedRightPoint);

            //// 찾은 센터포인트
            //PointF searchedCenterPoint = GetCenterPoint(searchedLeftPoint, searchedRightPoint);

            //// 센터끼리 틀어진 오프셋 값
            //PointF offset = GetOffset(teachedCenterPoint, searchedCenterPoint);

            //// 보정 전 좌표
            //inputPoint.X += offset.X;
            //inputPoint.Y += offset.Y;

            //// 센터, 옵셋, 각도, 출력
            //var coordinateX = Math.Round(searchedCenterPoint.X + ((Math.Cos(RadToDeg(diffRadian)) * (inputPoint.X - searchedCenterPoint.X)) - (Math.Sin(RadToDeg(diffRadian)) * (inputPoint.Y - searchedCenterPoint.Y))));
            //var coordinateY = Math.Round(searchedCenterPoint.Y + ((Math.Sin(RadToDeg(diffRadian)) * (inputPoint.X - searchedCenterPoint.X)) + (Math.Cos(RadToDeg(diffRadian)) * (inputPoint.Y - searchedCenterPoint.Y))));

            //PointF outputPoint = new PointF();

            //outputPoint.X = (float)coordinateX;
            //outputPoint.Y = (float)coordinateY;

            //return GetCoordinate(searchedCenterPoint, diffRadian, offset, inputPoint);

            PointF nn = new PointF();
            return nn;
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
