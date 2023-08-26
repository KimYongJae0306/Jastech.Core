using Cognex.VisionPro;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Imaging.VisionPro
{
    public static class VisionProShapeHelper
    {
        public static CogRectangleAffine ConvertToCogRectAffine(PointF leftTop, PointF rightTop, PointF leftBottom)
        {
            CogRectangleAffine cogRectAffine = new CogRectangleAffine();

            cogRectAffine.SetOriginCornerXCornerY(leftTop.X, leftTop.Y, rightTop.X, rightTop.Y, leftBottom.X, leftBottom.Y);
            return cogRectAffine;
        }

        public static CogRectangleAffine AddOffsetToCogRectAffine(CogRectangleAffine originRegion, PointF offset)
        {
            CogRectangleAffine roi = new CogRectangleAffine(originRegion);

            roi.CenterX += offset.X;
            roi.CenterY += offset.Y;

            return roi;
        }

        public static List<CogRectangleAffine> DivideRegion(CogRectangleAffine orgRect, int leadCount)
        {
            if (leadCount <= 0)
                return null;

            int totalCount = leadCount * 2;
            List<CogRectangleAffine> divideRegionList = new List<CogRectangleAffine>();

            double interval = orgRect.SideXLength / totalCount;
            double centerX = orgRect.CenterX - (((orgRect.SideXLength / 2) - (interval / 2)) * Math.Cos(orgRect.Rotation));
            double centerY = orgRect.CenterY - (((orgRect.SideXLength / 2) - (interval / 2)) * Math.Sin(orgRect.Rotation));


            for (int index = 0; index < totalCount; index++)
            {
                CogRectangleAffine divideRegion = new CogRectangleAffine(orgRect);

                double dX = (interval * index) * Math.Cos(orgRect.Rotation);
                double dY = (interval * index) * Math.Sin(orgRect.Rotation);//orgRect.Rotation;

                //double dX = orgRect.SideXLength / leadCount * leadIndex * System.Math.Cos(orgRect.Rotation);
                //double dY = orgRect.SideXLength / leadCount * leadIndex * orgRect.Rotation;

                divideRegion.SideXLength = interval;
                divideRegion.CenterX = centerX + dX;
                divideRegion.CenterY = centerY + dY;

                if (index % 2 == 0) //좌측부분 ROI
                    divideRegion.Rotation = divideRegion.Rotation - 3.14;
                divideRegion.CenterX = centerX + (interval * index);
                divideRegion.CenterY = centerY;

                divideRegionList.Add(divideRegion);
            }

            //tool.Region.CornerXY
            //double dNewX = (orgRect.CenterX - orgRect.SideXLength / 2)/* + (orgRect.SideXLength / totalCount)*/;
            //double dNewY = orgRect.CenterY;

            //for (int leadIndex = 0; leadIndex < totalCount; leadIndex++)
            //{
            //    CogRectangleAffine divideRegion = new CogRectangleAffine(orgRect);

            //    double dX = (orgRect.SideXLength / totalCount) * leadIndex * System.Math.Cos(orgRect.Rotation);
            //    double dY = orgRect.SideXLength / totalCount * leadIndex * System.Math.Sin(orgRect.Rotation);//orgRect.Rotation;

            //    //double dX = orgRect.SideXLength / leadCount * leadIndex * System.Math.Cos(orgRect.Rotation);
            //    //double dY = orgRect.SideXLength / leadCount * leadIndex * orgRect.Rotation;

            //    divideRegion.SideXLength = divideRegion.SideXLength / totalCount;
            //    divideRegion.CenterX = dNewX + dX;
            //    divideRegion.CenterY = dNewY + dY;

            //    divideRegionList.Add(divideRegion);
            //}

            return divideRegionList;
        }

        public static CogRectangleAffine MoveTranslationY(CogRectangleAffine rect, double offsetY)
        {
            CogRectangleAffine newRoi = new CogRectangleAffine(rect);

            newRoi.CenterX = rect.CenterX - offsetY * rect.Skew;
            newRoi.CenterY = rect.CenterY + offsetY;

            return newRoi;
        }

        public static CogRectangleAffine MoveTranslationX(CogRectangleAffine rect, double offsetX)
        {
            CogRectangleAffine newRoi = new CogRectangleAffine(rect);

            newRoi.CenterX = rect.CenterX + offsetX;
            newRoi.CenterY = rect.CenterY - offsetX / rect.Skew;

            return newRoi;
        }

        public static Rectangle ConvertAffineRectToRect(CogRectangleAffine affineRect)
        {
            List<double> xPointList = new List<double>();

            xPointList.Add(affineRect.CornerOriginX);
            xPointList.Add(affineRect.CornerXX);
            xPointList.Add(affineRect.CornerYX);
            xPointList.Add(affineRect.CornerOppositeX);

            List<double> yPointList = new List<double>();
            yPointList.Add(affineRect.CornerOriginY);
            yPointList.Add(affineRect.CornerXY);
            yPointList.Add(affineRect.CornerYY);
            yPointList.Add(affineRect.CornerOppositeY);

            double minimumX = xPointList.Min();
            double minimumY = yPointList.Min();
            double maximumX = xPointList.Max();
            double maximumY = yPointList.Max();

            double width = maximumX - minimumX;
            double height = maximumY - minimumY;

            Rectangle rect = new Rectangle();
            rect.X = (int)minimumX;
            rect.Y = (int)minimumY;
            rect.Width = (int)width;
            rect.Height = (int)height;

            return rect;
        }
    }
}
