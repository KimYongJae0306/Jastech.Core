using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Algorithms.Akkon.Parameters
{
    public class AkkonROI
    {
        public int LeadIndex { get; set; }

        public Point LeftTop { get; set; }

        public Point RightTop { get; set; }

        public Point LeftBottom { get; set; }

        public Point RightBottom { get; set; }

        public AkkonROI DeepCopy()
        {
            AkkonROI roi = new AkkonROI();

            roi.LeadIndex = LeadIndex;
            roi.LeftTop = new Point(LeftTop.X, LeftTop.Y);
            roi.RightTop = new Point(RightTop.X, RightTop.Y);
            roi.LeftBottom = new Point(LeftBottom.X, LeftBottom.Y);
            roi.RightBottom = new Point(RightBottom.X, RightBottom.Y);

            return roi;
        }

        public Rectangle GetBoundRect()
        {
            Rectangle rect = new Rectangle();

            rect.X = GetMinX();
            rect.Y = GetMinY();
            int g = GetMaxX();

            rect.Width = Math.Abs(GetMaxX() - rect.X);
            rect.Height = Math.Abs(GetMaxY() - rect.Y);

            return rect;
        }

        public int GetMinX()
        {
            int minX = int.MaxValue;
            if (LeftTop.X <= minX)
                minX = LeftTop.X;
            if (RightTop.X <= minX)
                minX = RightTop.X;
            if (LeftBottom.X <= minX)
                minX = LeftBottom.X;
            if (RightBottom.X <= minX)
                minX = RightBottom.X;

            return minX;
        }

        private int GetMaxX()
        {
            int maxX = int.MinValue;
            if (LeftTop.X >= maxX)
                maxX = LeftTop.X;
            if (RightTop.X >= maxX)
                maxX = RightTop.X;
            if (LeftBottom.X >= maxX)
                maxX = LeftBottom.X;
            if (RightBottom.X >= maxX)
                maxX = RightBottom.X;

            return maxX;
        }

        private int GetMinY()
        {
            int minY = int.MaxValue;
            if (LeftTop.Y <= minY)
                minY = LeftTop.Y;
            if (RightTop.Y <= minY)
                minY = RightTop.Y;
            if (LeftBottom.Y <= minY)
                minY = LeftBottom.Y;
            if (RightBottom.Y <= minY)
                minY = RightBottom.Y;

            return minY;
        }

        private int GetMaxY()
        {
            int maxY = int.MinValue;
            if (LeftTop.Y >= maxY)
                maxY = LeftTop.Y;
            if (RightTop.Y >= maxY)
                maxY = RightTop.Y;
            if (LeftBottom.Y >= maxY)
                maxY = LeftBottom.Y;
            if (RightBottom.Y >= maxY)
                maxY = RightBottom.Y;

            return maxY;
        }
    }
}
