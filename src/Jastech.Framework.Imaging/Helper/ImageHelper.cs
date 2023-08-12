﻿using System;
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
    }
}
