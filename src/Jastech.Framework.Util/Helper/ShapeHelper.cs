﻿using System;
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

        public static Rectangle DetectEdge(byte[] imageData, int width, int height, Point startPos, int threshold1, int threshold2)
        {
            Rectangle resultRect = new Rectangle();

            Point StartVector = new Point(1, 0);
            Point NextVector = new Point();

            return resultRect;
        }
    }
}