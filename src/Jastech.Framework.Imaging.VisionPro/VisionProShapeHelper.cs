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

            PointF inputPoint = new PointF();
            inputPoint.X = (float)roi.CenterX;
            inputPoint.Y = (float)roi.CenterY;

            PointF newPoint = new PointF();
            newPoint.X = inputPoint.X + offset.X;
            newPoint.Y = inputPoint.Y + offset.Y;

            roi.CenterX = newPoint.X;
            roi.CenterY = newPoint.Y;

            return roi;
        }
    }
}
