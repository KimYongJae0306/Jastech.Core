﻿using Jastech.Framework.Util.Helper;
using System;
using System.Drawing;

namespace Jastech.Framework.Util
{
    public class CoordinateTransform
    {
        public PointF OffsetPoint { get; private set; } = new PointF();

        public double DiffAngle { get; private set; } = 0.0;

        public double MarkDistanceRatio { get; private set; } = 0.0;

        CoordinateData ReferenceData = null;

        CoordinateData TargetData = null;

        public void SetReferenceData(PointF leftPoint, PointF rightPoint)
        {
            ReferenceData = new CoordinateData();
            ReferenceData.SetPoint(leftPoint, rightPoint);
        }

        public void SetTargetData(PointF leftPoint, PointF rightPoint)
        {
            TargetData = new CoordinateData();
            TargetData.SetPoint(leftPoint, rightPoint);
        }

        private void SetOffsetPoint()
        {
            if (ReferenceData == null || TargetData == null)
                return;

            var targetCenterPoint = TargetData.GetCenterPoint();
            var referenceCenterPoint = ReferenceData.GetCenterPoint();

            OffsetPoint =  MathHelper.GetOffset(referenceCenterPoint, targetCenterPoint);
        }

        private PointF GetOffsetPoint()
        {
            return OffsetPoint;
        }

        private void SetDiffAngle()
        {
            if (ReferenceData == null || TargetData == null)
                return;

            var referenceRadian = ReferenceData.GetRadian();
            var targetRadian = TargetData.GetRadian();

            var referenceDegree = MathHelper.RadToDeg(referenceRadian);
            //if (referenceDegree > 180.0)
            //    referenceDegree += 180.0;

            var targetDegree = MathHelper.RadToDeg(targetRadian);
            //if (targetDegree > 180.0)
            //    targetDegree += 180.0;

            DiffAngle = referenceDegree - targetDegree;
        }

        private double GetDiffAngle()
        {
            return DiffAngle;
        }

        private void SetMarkDistanceRatio()
        {
            MarkDistanceRatio = TargetData.GetMarkToMarkDistance() / ReferenceData.GetMarkToMarkDistance();
        }

        private double GetMarkDistanceRatio()
        {
            return MarkDistanceRatio;
        }

        public void ExecuteCoordinate()
        {
            SetOffsetPoint();
            SetDiffAngle();
            SetMarkDistanceRatio();
        }

        public PointF GetCoordinate(PointF inputPoint)
        {
            var diffAngle = GetDiffAngle();
            var offsetPoint = GetOffsetPoint();
            var markDistanceRatio = GetMarkDistanceRatio();

            // Test for ratio
            //markDistanceRatio = 1.0;

            if (diffAngle == 0.0 && offsetPoint == null)
                return inputPoint;

            var targetCenterPoint = TargetData.GetCenterPoint();
            var referenceCenterPoint = ReferenceData.GetCenterPoint();

            return MathHelper.GetCoordinate(targetCenterPoint, diffAngle, offsetPoint, inputPoint/*, markDistanceRatio*/);
        }
    }

    public class CoordinateData
    {
        public PointF LeftPoint { get; private set; }

        public PointF RightPoint { get; private set; }

        public double MarkToMarkDistance { get; private set; }

        public void SetPoint(PointF leftPoint, PointF rightPoint)
        {
            LeftPoint = leftPoint;
            RightPoint = rightPoint;
        }

        public PointF GetCenterPoint()
        {
            return MathHelper.GetCenterPoint(LeftPoint, RightPoint);
        }

        public double GetRadian()
        {
            return MathHelper.GetRadian(LeftPoint, RightPoint);
        }

        public double GetMarkToMarkDistance()
        {
            return MathHelper.GetDistance(LeftPoint, RightPoint);
        }

        //public CoordinateData DeepCopy()
        //{
        //    CoordinateData coordinateData = new CoordinateData();

        //    coordinateData.Point1 = Point1;
        //    coordinateData.Point2 = Point2;

        //    return coordinateData;
        //}

        //public void Dispose()
        //{
        //    this.Dispose();
        //}
    }
}
