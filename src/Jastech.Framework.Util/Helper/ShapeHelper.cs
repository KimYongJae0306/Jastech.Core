using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Util.Helper
{
    public static class ShapeHelper
    {
        public static Rectangle GetValidRectangle(Rectangle inputRect, int imageWidht, int imageHeight)
        {
            Rectangle rectangle = new Rectangle();

            if (inputRect != null)
            {
                if (inputRect.X < 0)
                    rectangle.X = 0;

                if (inputRect.Y < 0)
                    rectangle.Y = 0;

                if (inputRect.Right > imageWidht)
                    rectangle.Width = imageWidht - inputRect.X;

                if (inputRect.Bottom > imageHeight)
                    rectangle.Height = imageHeight - inputRect.Y;
            }

            return rectangle;
        }
    }
}
