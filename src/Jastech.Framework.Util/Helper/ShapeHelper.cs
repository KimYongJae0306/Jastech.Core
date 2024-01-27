using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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

        public static Point GetRotate45(Point inputTensor)
        {
            Point resultTesnor = new Point();

            if (inputTensor.X == -1 && inputTensor.Y == -1)
            {
                resultTesnor.X = 0;
                resultTesnor.Y = -1;
            }
            else if (inputTensor.X == 0 && inputTensor.Y == -1)
            {
                resultTesnor.X = 1;
                resultTesnor.Y = -1;
            }
            else if (inputTensor.X == 1 && inputTensor.Y == -1)
            {
                resultTesnor.X = 1;
                resultTesnor.Y = 0;
            }
            else if (inputTensor.X == 1 && inputTensor.Y == 0)
            {
                resultTesnor.X = 1;
                resultTesnor.Y = 1;
            }
            else if (inputTensor.X == 1 && inputTensor.Y == 1)
            {
                resultTesnor.X = 0;
                resultTesnor.Y = 1;
            }
            else if (inputTensor.X == 0 && inputTensor.Y == 1)
            {
                resultTesnor.X = -1;
                resultTesnor.Y = 1;
            }
            else if (inputTensor.X == -1 && inputTensor.Y == 1)
            {
                resultTesnor.X = -1;
                resultTesnor.Y = 0;
            }
            else if (inputTensor.X == -1 && inputTensor.Y == 0)
            {
                resultTesnor.X = -1;
                resultTesnor.Y = -1;
            }
            
            return resultTesnor;
        }
    }
}
