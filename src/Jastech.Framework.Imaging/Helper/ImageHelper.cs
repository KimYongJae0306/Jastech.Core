using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace Jastech.Framework.Imaging.Helper
{
    public static class ImageHelper
    {
        public static byte[] GetWidthDataArray(Bitmap bmp, int index)
        {
            if (bmp.PixelFormat != PixelFormat.Format8bppIndexed)
                return null;

            byte[] dataArray = new byte[bmp.Width];
            unsafe
            {
                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
                IntPtr ptrData = bmpData.Scan0;
                int stride = bmpData.Stride;
                byte* data = (byte*)(void*)ptrData;
                int startIndex = (index * stride);

                int count = 0;
                for (int i = startIndex; i < startIndex + bmp.Width; i++)
                {
                    dataArray[count] = data[i];
                    count++;
                }

                bmp.UnlockBits(bmpData);
            }
            return dataArray;
        }

        public static byte[] GetDataArray(Bitmap bmp, List<PointF> points)
        {
            if (bmp.PixelFormat != PixelFormat.Format8bppIndexed)
                return null;

            byte[] dataArray = new byte[points.Count()];

            unsafe
            {
                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
                IntPtr ptrData = bmpData.Scan0;
                int stride = bmpData.Stride;
                int imageBufferSize = stride * bmp.Height;
                byte* data = (byte*)(void*)ptrData;

                for (int i = 0; i < points.Count(); i++)
                {
                    int index = (int)((int)points[i].Y * stride + (int)points[i].X);

                    if (points[i].X < 0 || points[i].X > bmp.Width)
                        dataArray[i] = 0;
                    else if(points[i].Y < 0 || points[i].Y > bmp.Height)
                        dataArray[i] = 0;
                    else if(index < 0 || index > imageBufferSize)
                        dataArray[i] = 0;
                    else
                        dataArray[i] = data[index];
                }

                bmp.UnlockBits(bmpData);
            }

            return dataArray;
        }

        public static List<int> GetEdgePoint(byte[] dataArray, int edgeValue)
        {
            List<int> edgePointList = new List<int>();

            int prevValue = 0;
            bool findedStartEdge = false;
            for (int i = 0; i < dataArray.Length; i++)
            {
                int data = dataArray[i];
                if(findedStartEdge == false)
                {
                    if (data == edgeValue)
                    {
                        findedStartEdge = true;
                        edgePointList.Add(i);
                    }
                }
                else
                {
                    if(prevValue != data)
                    {
                        findedStartEdge = false;
                        edgePointList.Add(i);
                    }
                }

                prevValue = data;
            }
            return edgePointList;
        }

        public static void GetEdgePoint(byte[] topArray, byte[] bottomArray, int edgeValue, int leadPitch, ref List<int> topEdgeList, ref List<int> bottomEdgeList)
        {
            var prevValue = 0;
            int ignore = 0;
            bool enableIgnore = false;
            for (int i = 0; i < topArray.Length; i++)
            {
                var value = topArray[i];
                if (i == 0)
                    prevValue = value;

                if (prevValue != value)
                {
                    if(prevValue == 0 && value == edgeValue)
                    {
                        ignore++;
                        topEdgeList.Add(i);
                    }
                    else if(prevValue == edgeValue && value == 0)
                    {
                        topEdgeList.Add(i);
                        ignore++;
                    }
                    prevValue = value;

                    if(ignore > leadPitch)
                    {
                        ignore = 0;
                        enableIgnore = false;
                    }
                    if (ignore == 1)
                        enableIgnore = true;
                }
            }
            ignore = 0;
            enableIgnore = false;
            prevValue = 0;
            for (int i = 0; i < bottomArray.Length; i++)
            {
                var value = bottomArray[i];
                if (i == 0)
                    prevValue = value;
                if (prevValue != value)
                {
                    if (prevValue == 0 && value == edgeValue)
                    {
                        bottomEdgeList.Add(i);
                    }
                    else if (prevValue == edgeValue && value == 0)
                    {
                        bottomEdgeList.Add(i);
                    }
                    prevValue = value;

                    if (ignore > leadPitch)
                    {
                        ignore = 0;
                        enableIgnore = false;
                    }
                    if (ignore == 1)
                        enableIgnore = true;
                }
            }
        }
            //if (topArray.Length != bottomArray.Length)
            //    return;

            //List<int> edgePointList = new List<int>();

            //int prevTopValue = 0;
            //bool topFindedStartEdge = false;
            //int prevBottompValue = 0;
            //bool bottomFindedStartEdge = false;
            //for (int i = 0; i < topArray.Length; i++)
            //{
            //    int topData = topArray[i];
               
            //    if (topFindedStartEdge == false)
            //    {
            //        if (topData == edgeValue)
            //        {
            //            topFindedStartEdge = true;
            //            topEdgeList.Add(i);

            //        }
            //    }
            //    else
            //    {
            //        if (prevTopValue != topData)
            //        {
            //            int lastIndex = topEdgeList.Last();
            //            if(lastIndex + leadPitch < i)
            //            {
            //                topFindedStartEdge = false;
            //                topEdgeList.Add(i);
            //            }
            //        }
            //    }

            //    prevTopValue = topData;

            //    int bottomData = bottomArray[i];
            //    if (bottomFindedStartEdge == false)
            //    {
            //        if (bottomData == edgeValue)
            //        {
            //            bottomFindedStartEdge = true;
            //            bottomEdgeList.Add(i);
            //        }
            //    }
            //    else
            //    {
            //        if (prevBottompValue != bottomData)
            //        {
            //            int lastIndex = bottomEdgeList.Last();
            //            if (lastIndex + leadPitch < i)
            //            {
            //                bottomFindedStartEdge = false;
            //                bottomEdgeList.Add(i);
            //            }
            //        }
            //    }

            //    prevBottompValue = bottomData;
            //}
       // }
    }
}
