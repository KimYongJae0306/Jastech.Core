using Cognex.VisionPro;
using Cognex.VisionPro.Caliper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Parameters.VisionProCaliperParam;

namespace Jastech.Framework.Imaging.VisionPro
{
    public static class VisionProShapeHelper
    {
        public static CogPolygon GetBoundingPolygon(CogImage8Grey cogImage, CogFindCircleTool cogFindCircleTool)
        {
            CogPolygon boundingPolygon = new CogPolygon();

            var pointList = GetPolygonPoints(cogFindCircleTool);

            for (int pointIndex = 0; pointIndex < pointList.Count; pointIndex++)
                boundingPolygon.AddVertex(pointList[pointIndex].X, pointList[pointIndex].Y, pointIndex);

            return boundingPolygon;
        }

        private static List<PointF> GetPolygonPoints(CogFindCircleTool cogFindCircleTool)
        {
            List<PointF> points = new List<PointF>();

            double toolStartX = cogFindCircleTool.RunParams.ExpectedCircularArc.StartX;
            double toolStartY = cogFindCircleTool.RunParams.ExpectedCircularArc.StartY;
            double toolEndX = cogFindCircleTool.RunParams.ExpectedCircularArc.EndX;
            double toolEndY = cogFindCircleTool.RunParams.ExpectedCircularArc.EndY;

            double radius = cogFindCircleTool.RunParams.ExpectedCircularArc.Radius;
            double caliperLength = cogFindCircleTool.RunParams.CaliperSearchLength / 2;

            double angleStartTheta = cogFindCircleTool.RunParams.ExpectedCircularArc.AngleStart;
            double angleEndTheta = cogFindCircleTool.RunParams.ExpectedCircularArc.AngleStart + cogFindCircleTool.RunParams.ExpectedCircularArc.AngleSpan;

            double leftTopX = toolEndX + (radius + caliperLength) * Math.Cos(angleEndTheta);
            double leftTopY = toolEndY + (radius + caliperLength) * Math.Sin(angleEndTheta);
            PointF leftTop = new PointF(Convert.ToSingle(leftTopX), Convert.ToSingle(leftTopY));
            points.Add(leftTop);

            double leftBottomX = toolEndX - (radius - caliperLength) * Math.Cos(angleEndTheta);
            double leftBottomY = toolEndY - (radius - caliperLength) * Math.Sin(angleEndTheta);
            PointF leftBottom = new PointF(Convert.ToSingle(leftBottomX), Convert.ToSingle(leftBottomY));
            points.Add(leftBottom);

            double rightBottomX = toolStartX - (radius - caliperLength) * Math.Cos(angleStartTheta);
            double rightBottomY = toolStartY - (radius - caliperLength) * Math.Sin(angleStartTheta);
            PointF rightBottom = new PointF(Convert.ToSingle(rightBottomX), Convert.ToSingle(rightBottomY));
            points.Add(rightBottom);

            double rightTopX = toolStartX + (radius + caliperLength) * Math.Cos(angleStartTheta);
            double rightTopY = toolStartY + (radius + caliperLength) * Math.Sin(angleStartTheta);
            PointF rightTop = new PointF(Convert.ToSingle(rightTopX), Convert.ToSingle(rightTopY));
            points.Add(rightTop);

            return points;
        }

        public static CogRectangleAffine GetBoundingRectangle(CogFindLineTool cogFindLineTool)
        {
            CogRectangleAffine cogRectangleAffine = new CogRectangleAffine();

            cogRectangleAffine.CenterX = cogFindLineTool.RunParams.ExpectedLineSegment.MidpointX;
            cogRectangleAffine.CenterY = cogFindLineTool.RunParams.ExpectedLineSegment.MidpointY;
            cogRectangleAffine.Rotation = cogFindLineTool.RunParams.ExpectedLineSegment.Rotation; // + CogMisc.DegToRad(90);
            cogRectangleAffine.SideXLength = cogFindLineTool.RunParams.ExpectedLineSegment.Length;
            cogRectangleAffine.SideYLength = cogFindLineTool.RunParams.CaliperSearchLength;

            return cogRectangleAffine;
        }

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

        public static List<CogRectangleAffine> DivideRegion(CogRectangleAffine orgRect, int leadCount, CaliperSearchDirection searchDirection)
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
                double dY = (interval * index) * Math.Sin(orgRect.Rotation);

                divideRegion.SideXLength = interval;
                divideRegion.CenterX = centerX + dX;
                divideRegion.CenterY = centerY + dY;

                if (searchDirection == CaliperSearchDirection.InsideToOutside)
                {
                    if (index % 2 == 0) //좌측부분 ROI
                        divideRegion.Rotation = divideRegion.Rotation - 3.14;
                }
                else
                {
                    if (index % 2 == 1) //좌측부분 ROI
                        divideRegion.Rotation = divideRegion.Rotation - 3.14;
                }
                divideRegion.CenterX = centerX + (interval * index);
                divideRegion.CenterY = centerY;

                divideRegionList.Add(divideRegion);
            }
           
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

        public static CogRectangleAffine MoveOffsetY(CogRectangleAffine rect, double offsetY, double skew)
        {
            CogRectangleAffine newRoi = new CogRectangleAffine(rect);

            newRoi.CenterX = rect.CenterX - offsetY * skew;
            newRoi.CenterY = rect.CenterY + offsetY;

            return newRoi;
        }

        public static CogRectangleAffine MoveOffsetX(CogRectangleAffine rect, double offsetX, double skew)
        {
            CogRectangleAffine newRoi = new CogRectangleAffine(rect);

            newRoi.CenterX = rect.CenterX + offsetX;
            newRoi.CenterY = rect.CenterY - offsetX / skew;

            return newRoi;
        }

        public static PointF GetOffsetBetweenCenterPointOfAffineRectangles(CogRectangleAffine rect1, CogRectangleAffine rect2)
        {
            PointF offset = new PointF();

            offset.X = Convert.ToSingle(rect2.CenterX - rect1.CenterX);
            offset.Y = Convert.ToSingle(rect2.CenterY - rect1.CenterY);

            return offset;
        }

        public static Rectangle ConvertAffineRectToRect(CogRectangleAffine affineRect, double offsetX = 0.0, double offsetY = 0.0)
        {
            List<double> xPointList = new List<double>();

            xPointList.Add(affineRect.CornerOriginX + offsetX);
            xPointList.Add(affineRect.CornerXX + offsetX);
            xPointList.Add(affineRect.CornerYX + offsetX);
            xPointList.Add(affineRect.CornerOppositeX + offsetX);

            List<double> yPointList = new List<double>();
            yPointList.Add(affineRect.CornerOriginY + offsetY);
            yPointList.Add(affineRect.CornerXY + offsetY);
            yPointList.Add(affineRect.CornerYY + offsetY);
            yPointList.Add(affineRect.CornerOppositeY + offsetY);

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
