using Jastech.Framework.Util.Helper;
using Newtonsoft.Json;
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
        [JsonProperty]
        public int LeadIndex { get; set; }

        [JsonProperty]
        public double LeftTopX { get; set; } // CornerOriginX

        [JsonProperty]
        public double LeftTopY { get; set; } // CornerOriginY

        [JsonProperty]
        public double RightTopX { get; set; } // CornerOppositeX

        [JsonProperty]
        public double RightTopY { get; set; } // CornerOppositeY

        [JsonProperty]
        public double LeftBottomX { get; set; } // CornerYX

        [JsonProperty]
        public double LeftBottomY { get; set; } // CornerYY

        [JsonProperty]
        public double RightBottomX { get; set; } // CornerOppositeX

        [JsonProperty]
        public double RightBottomY { get; set; } // CornerOppositeY

        public AkkonROI DeepCopy()
        {
            return JsonConvertHelper.DeepCopy(this) as AkkonROI;
        }

        public Rectangle GetBoundRect()
        {
            Rectangle rect = new Rectangle();

            rect.X = (int)GetMinX();
            rect.Y = (int)GetMinY();

            rect.Width = (int)Math.Abs(GetMaxX() - rect.X);
            rect.Height = (int)Math.Abs(GetMaxY() - rect.Y);

            return rect;
        }

        public RectangleF GetBoundRectF()
        {
            RectangleF rect = new RectangleF();

            rect.X = (float)GetMinX();
            rect.Y = (float)GetMinY();

            rect.Width = (float)Math.Abs(GetMaxX() - rect.X);
            rect.Height = (float)Math.Abs(GetMaxY() - rect.Y);

            return rect;
        }

        public double GetMinX()
        {
            double minX = double.MaxValue;
            if (LeftTopX <= minX)
                minX = LeftTopX;
            if (RightTopX <= minX)
                minX = RightTopX;
            if (LeftBottomX <= minX)
                minX = LeftBottomX;
            if (RightBottomX <= minX)
                minX = RightBottomX;

            return minX;
        }

        private double GetMaxX()
        {
            double maxX = double.MinValue;
            if (LeftTopX >= maxX)
                maxX = LeftTopX;
            if (RightTopX >= maxX)
                maxX = RightTopX;
            if (LeftBottomX >= maxX)
                maxX = LeftBottomX;
            if (RightBottomX >= maxX)
                maxX = RightBottomX;

            return maxX;
        }

        private double GetMinY()
        {
            double minY = double.MaxValue;
            if (LeftTopY <= minY)
                minY = LeftTopY;
            if (RightTopY <= minY)
                minY = RightTopY;
            if (LeftBottomY <= minY)
                minY = LeftBottomY;
            if (RightBottomY <= minY)
                minY = RightBottomY;

            return minY;
        }

        private double GetMaxY()
        {
            double maxY = double.MinValue;
            if (LeftTopY >= maxY)
                maxY = LeftTopY;
            if (RightTopY >= maxY)
                maxY = RightTopY;
            if (LeftBottomY >= maxY)
                maxY = LeftBottomY;
            if (RightBottomY >= maxY)
                maxY = RightBottomY;

            return maxY;
        }
    }
}
