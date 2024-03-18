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
        public static bool CheckValidRectangle(Rectangle inputRect, int width, int height)
        {
            if (inputRect == null)
                return false;

            if (inputRect.Left < 0 || inputRect.Right - inputRect.Left > width)
                return false;

            if (inputRect.Top < 0 || inputRect.Bottom - inputRect.Top > height)
                return false;

            return true;
        }

        public static Rectangle GetValidRectangle(Rectangle inputRect, int imageWidth, int imageHeight)
        {
            Rectangle validRect = inputRect;

            if (validRect.X < 0)
                validRect.X = 0;

            if (validRect.Y < 0)
                validRect.Y = 0;

            if (validRect.Right > imageWidth)
                validRect.Width = imageWidth - validRect.X;

            if (validRect.Bottom > imageHeight)
                validRect.Height = imageHeight - validRect.Y;

            return validRect;
        }

        public static Point RotateCW45(Point inputPoint)
        {
            Point resultPoint = new Point();

            if (inputPoint != null)
            {
                if (inputPoint.X == -1 && inputPoint.Y == -1)
                {
                    resultPoint.X = 0;
                    resultPoint.Y = -1;
                }
                else if (inputPoint.X == 0 && inputPoint.Y == -1)
                {
                    resultPoint.X = 1;
                    resultPoint.Y = -1;
                }
                else if (inputPoint.X == 1 && inputPoint.Y == -1)
                {
                    resultPoint.X = 1;
                    resultPoint.Y = 0;
                }
                else if (inputPoint.X == 1 && inputPoint.Y == 0)
                {
                    resultPoint.X = 1;
                    resultPoint.Y = 1;
                }
                else if (inputPoint.X == 1 && inputPoint.Y == 1)
                {
                    resultPoint.X = 0;
                    resultPoint.Y = 1;
                }
                else if (inputPoint.X == 0 && inputPoint.Y == 1)
                {
                    resultPoint.X = -1;
                    resultPoint.Y = 1;
                }
                else if (inputPoint.X == -1 && inputPoint.Y == 1)
                {
                    resultPoint.X = -1;
                    resultPoint.Y = 0;
                }
                else if (inputPoint.X == -1 && inputPoint.Y == 0)
                {
                    resultPoint.X = -1;
                    resultPoint.Y = -1;
                }
            }

            return resultPoint;
        }

        public static Point RotateCW90(Point inputPoint)
        {
            Point resultPoint = new Point();

            if (inputPoint != null)
            {
                if (inputPoint.X == -1 && inputPoint.Y == -1)
                {
                    resultPoint.X = 1;
                    resultPoint.Y = -1;
                }
                else if (inputPoint.X == 0 && inputPoint.Y == -1)
                {
                    resultPoint.X = 1;
                    resultPoint.Y = 0;
                }
                else if (inputPoint.X == 1 && inputPoint.Y == -1)
                {
                    resultPoint.X = 1;
                    resultPoint.Y = 1;
                }
                else if (inputPoint.X == 1 && inputPoint.Y == 0)
                {
                    resultPoint.X = 0;
                    resultPoint.Y = 1;
                }
                else if (inputPoint.X == 1 && inputPoint.Y == 1)
                {
                    resultPoint.X = -1;
                    resultPoint.Y = 1;
                }
                else if (inputPoint.X == 0 && inputPoint.Y == 1)
                {
                    resultPoint.X = -1;
                    resultPoint.Y = 0;
                }
                else if (inputPoint.X == -1 && inputPoint.Y == 1)
                {
                    resultPoint.X = -1;
                    resultPoint.Y = -1;
                }
                else if (inputPoint.X == -1 && inputPoint.Y == 0)
                {
                    resultPoint.X = 0;
                    resultPoint.Y = -1;
                }
            }

            return resultPoint;
        }

        public static Point RotateCCW45(Point inputPoint)
        {
            Point resultPoint = new Point();

            if (inputPoint != null)
            {
                if (inputPoint.X == -1 && inputPoint.Y == -1)
                {
                    resultPoint.X = -1;
                    resultPoint.Y = 0;
                }
                else if (inputPoint.X == -1 && inputPoint.Y == 0)
                {
                    resultPoint.X = -1;
                    resultPoint.Y = 1;
                }
                else if (inputPoint.X == -1 && inputPoint.Y == 1)
                {
                    resultPoint.X = 0;
                    resultPoint.Y = 1;
                }
                else if (inputPoint.X == 0 && inputPoint.Y == 1)
                {
                    resultPoint.X = 1;
                    resultPoint.Y = 1;
                }
                else if (inputPoint.X == 1 && inputPoint.Y == 1)
                {
                    resultPoint.X = 1;
                    resultPoint.Y = 0;
                }
                else if (inputPoint.X == 1 && inputPoint.Y == 0)
                {
                    resultPoint.X = 1;
                    resultPoint.Y = -1;
                }
                else if (inputPoint.X == 1 && inputPoint.Y == -1)
                {
                    resultPoint.X = 0;
                    resultPoint.Y = -1;
                }
                else if (inputPoint.X == 0 && inputPoint.Y == -1)
                {
                    resultPoint.X = -1;
                    resultPoint.Y = -1;
                }
            }

            return resultPoint;
        }

        public static Point RotateCCW90(Point inputPoint)
        {
            Point resultPoint = new Point();

            if (inputPoint != null)
            {
                if (inputPoint.X == -1 && inputPoint.Y == -1)
                {
                    resultPoint.X = -1;
                    resultPoint.Y = 1;
                }
                else if (inputPoint.X == -1 && inputPoint.Y == 0)
                {
                    resultPoint.X = 0;
                    resultPoint.Y = 1;
                }
                else if (inputPoint.X == -1 && inputPoint.Y == 1)
                {
                    resultPoint.X = 1;
                    resultPoint.Y = 1;
                }
                else if (inputPoint.X == 0 && inputPoint.Y == 1)
                {
                    resultPoint.X = 1;
                    resultPoint.Y = 0;
                }
                else if (inputPoint.X == 1 && inputPoint.Y == 1)
                {
                    resultPoint.X = 1;
                    resultPoint.Y = -1;
                }
                else if (inputPoint.X == 1 && inputPoint.Y == 0)
                {
                    resultPoint.X = 0;
                    resultPoint.Y = -1;
                }
                else if (inputPoint.X == 1 && inputPoint.Y == -1)
                {
                    resultPoint.X = -1;
                    resultPoint.Y = -1;
                }
                else if (inputPoint.X == 0 && inputPoint.Y == -1)
                {
                    resultPoint.X = -1;
                    resultPoint.Y = 0;
                }
            }

            return resultPoint;
        }

        public static byte[] FillBound(byte[] imageData, int width, int height, int value)
        {
            byte[] resultImageData = new byte[imageData.Length];

            for (int x = 0; x < width; x++)
            {
                imageData[0 * width + x] = (byte)value;
                imageData[(height - 1) * width + x] = (byte)value;
            }

            for (int y = 0; y < height; y++)
            {
                imageData[y * width] = (byte)value;
                imageData[y * width + (width - 1)] = (byte)value;
            }

            return resultImageData;
        }

        public static Point GetThresholdPoint(byte[] imageData, int width, int height, Point startPoint, int lowThreshold, int highThreshold)
        {
            Point resultPoint = new Point();

            var x = startPoint.X;
            var y = startPoint.Y;

            for (y = 0; y < height; y++)
            {
                for (x = 0; x < width; x++)
                {
                    int value = imageData[y * width + x];

                    if (value >= lowThreshold && value <= highThreshold)
                    {
                        resultPoint.X = x;
                        resultPoint.Y = y;
                    }
                }
            }

            return resultPoint;
        }

        public static List<Point> GetPointListBetweenThresholdRange(byte[] imageData, int width, int height, Point startPoint, int lowThreshold, int highThreshold)
        {
            List<Point> resultPointList = new List<Point>();
            
            for (int y = startPoint.Y; y < height; y++)
            {
                for (int x = startPoint.X; x < width; x++)
                {
                    int value = imageData[y * width + x];

                    if (value >= lowThreshold && value <= highThreshold)
                        resultPointList.Add(new Point(x, y));
                }
            }

            return resultPointList;
        }

        public static Rectangle DetectEdge(byte[] imageData, int width, int height, Point startPos, int lowThreshold, int highThreshold)
        {
            Rectangle resultRect = new Rectangle(width, height, -width, -height);
            int rotationCount = 0;

            Point startVector = new Point(1, 0);
            Point nextVector = RotateCCW90(startVector);
            Point currentPoint = startPos;

            while (true)
            {
                int x = startPos.X + nextVector.X;
                int y = startPos.Y + nextVector.Y;

                if (x < 0 || y < 0)
                    return resultRect;

                int value = imageData[y * width + x];

                if (value >= lowThreshold && value <= highThreshold)
                {
                    currentPoint.X += nextVector.X;
                    currentPoint.Y += nextVector.Y;

                    if (currentPoint.X < resultRect.X)
                    {
                        resultRect.X = currentPoint.X;
                        resultRect.Width = resultRect.Right - resultRect.X;
                    }

                    if (currentPoint.X > resultRect.Right)
                        resultRect.Width = currentPoint.X - resultRect.X;

                    if (currentPoint.Y < resultRect.Y)
                    {
                        resultRect.Y = currentPoint.Y;
                        resultRect.Height = resultRect.Bottom - resultRect.Y;
                    }

                    if (currentPoint.Y > resultRect.Bottom)
                        resultRect.Height = currentPoint.Y - resultRect.Y;

                    if (currentPoint.X == startPos.X && currentPoint.Y == startPos.Y)
                        return resultRect;

                    nextVector = RotateCCW90(nextVector);
                    rotationCount = 0;
                }
                else
                {
                    nextVector = RotateCW45(nextVector);
                    rotationCount++;

                    if (rotationCount >= 7)
                    {
                        imageData[currentPoint.Y * width + currentPoint.X] = 0;
                        resultRect.X = currentPoint.X;
                        resultRect.Y = currentPoint.Y;
                        resultRect.Width = 0;
                        resultRect.Height = 0;

                        return resultRect;
                    }
                }
            }
        }

        public static byte[] FillValueWithCount(byte[] imageData, int width, int height, int fillValue, int lowThreshold, int highThreshold, out int fillCount)
        {
            fillCount = 0;

            byte[] returnData = new byte[width * height];

            for (int vertical = 0; vertical < height; vertical++)
            {
                for (int horizontal = 0; horizontal < width; horizontal++)
                {
                    int value = imageData[vertical * width + horizontal];

                    if (value >= lowThreshold && value <= highThreshold)
                    {
                        fillCount++;
                        imageData[vertical * width + horizontal] = (byte)fillValue;
                    }
                }
            }

            return returnData;
        }

        public static byte[] FillValueWithCount(byte[] imageData, Rectangle inputRect, int fillValue, int lowThreshold, int highThreshold, out int fillCount)
        {
            fillCount = 0;

            byte[] returnData = new byte[inputRect.Width * inputRect.Height];

            for (int vertical = inputRect.Top; vertical < inputRect.Bottom; vertical++)
            {
                for (int horizontal = inputRect.Left; horizontal < inputRect.Right; horizontal++)
                {
                    int value = imageData[vertical * inputRect.Width + horizontal];

                    if (value >= lowThreshold && value <= highThreshold)
                    {
                        fillCount++;
                        imageData[vertical * inputRect.Width + horizontal] = (byte)fillValue;
                    }
                }
            }

            return returnData;
        }
    }
}
