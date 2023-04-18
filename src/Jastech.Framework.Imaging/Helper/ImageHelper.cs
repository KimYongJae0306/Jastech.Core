using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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
            if (topArray.Length != bottomArray.Length)
                return;

            List<int> edgePointList = new List<int>();

            int prevTopValue = 0;
            bool topFindedStartEdge = false;
            int prevBottompValue = 0;
            bool bottomFindedStartEdge = false;
            for (int i = 0; i < topArray.Length; i++)
            {
                int topData = topArray[i];
               
                if (topFindedStartEdge == false)
                {
                    if (topData == edgeValue)
                    {
                        topFindedStartEdge = true;
                        topEdgeList.Add(i);

                    }
                }
                else
                {
                    if (prevTopValue != topData)
                    {
                        int lastIndex = topEdgeList.Last();
                        if(lastIndex + leadPitch < i)
                        {
                            topFindedStartEdge = false;
                            topEdgeList.Add(i);
                        }
                    }
                }

                prevTopValue = topData;

                int bottomData = bottomArray[i];
                if (bottomFindedStartEdge == false)
                {
                    if (bottomData == edgeValue)
                    {
                        bottomFindedStartEdge = true;
                        bottomEdgeList.Add(i);
                    }
                }
                else
                {
                    if (prevBottompValue != bottomData)
                    {
                        int lastIndex = bottomEdgeList.Last();
                        if (lastIndex + leadPitch < i)
                        {
                            bottomFindedStartEdge = false;
                            bottomEdgeList.Add(i);
                        }
                    }
                }

                prevBottompValue = bottomData;
            }
        }
    }
}
