﻿using Cognex.VisionPro;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.ImageProcessing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace Jastech.Framework.Imaging.VisionPro
{
    public static class VisionProImageHelper
    {
        public static void Dispose(ref ICogImage cogImage)
        {
            if (cogImage is CogImage8Grey grey)
            {
                grey.Dispose();
                grey = null;
            }
            if (cogImage is CogImage24PlanarColor color)
            {
                color.Dispose();
                color = null;
            }
        }

        public static ICogImage Load(string fileName)
        {
            ICogImage image;

            if (fileName.ToLower().Contains(".jpeg") == false)
            {
                CogImageFile cogImageFile = new CogImageFile();
                cogImageFile.Open(fileName, CogImageFileModeConstants.Read);
                image = cogImageFile[0];
                cogImageFile.Close();
            }
            else
            {
                CogImageFileJPEG cogImageFileJPEG = new CogImageFileJPEG();
                cogImageFileJPEG.Open(fileName, CogImageFileModeConstants.Read);
                image = cogImageFileJPEG[0];
                cogImageFileJPEG.Close();
            }

            return image;
        }

        public static void Save(ICogImage image, string fileName)
        {
            if (image == null)
                return;

            lock(image)
            {
                string extension = Path.GetExtension(fileName);
                if (extension == ".bmp")
                {
                    CogImageFileBMP bmp = new CogImageFileBMP();
                    bmp.Open(fileName, CogImageFileModeConstants.Write);
                    bmp.Append(image);
                    bmp.Close();
                }
                else if (extension == ".jpg" || extension == ".jpeg")
                {
                    CogImageFileJPEG jpg = new CogImageFileJPEG();
                    jpg.Open(fileName, CogImageFileModeConstants.Write);
                    jpg.Append(image);
                    jpg.Close();
                }
                else if (extension == ".png")
                {
                    CogImageFilePNG png = new CogImageFilePNG();
                    png.Open(fileName, CogImageFileModeConstants.Write);
                    png.Append(image);
                    png.Close();
                }
            }
        }

        public static byte[] GetWidthDataArray(CogImage8Grey image, int index)
        {
            if (image == null)
                return null;

            byte[] dataArray = new byte[image.Width];
            unsafe
            {
                var cogPixelData = image.Get8GreyPixelMemory(CogImageDataModeConstants.Read, 0, 0, image.Width, image.Height);

                IntPtr ptrData = cogPixelData.Scan0;
                int startIndex = cogPixelData.Stride * index;

                byte* data = (byte*)(void*)ptrData;
                int count = 0;
                for (int i = startIndex; i < startIndex + image.Width; i++)
                {
                    dataArray[count] = data[i];
                    count++;
                }
            }
            return dataArray;
        }

        public static byte[] GetByteArray(CogImage8Grey image)
        {
            if (image == null)
                return null;

            unsafe
            {
                var cogPixelData = image.Get8GreyPixelMemory(CogImageDataModeConstants.Read, 0, 0, image.Width, image.Height);
                int length = cogPixelData.Stride * cogPixelData.Height;

                IntPtr ptrData = cogPixelData.Scan0;

                byte[] dataByteArary = new byte[length];
                Marshal.Copy(ptrData,  dataByteArary, 0, length);

                return dataByteArary;
            }
        }

        public static IntPtr GetIntptr(CogImage8Grey image, out int stride)
        {
            unsafe
            {
                var cogPixelData = image.Get8GreyPixelMemory(CogImageDataModeConstants.Read, 0, 0, image.Width, image.Height);
                IntPtr ptrData = cogPixelData.Scan0;
                stride = cogPixelData.Stride;

                return ptrData;
            }
        }

        public static CogImage8Grey Threshold(CogImage8Grey orgImage, int threshold, int maxValue, bool isInvert = false)
        {
            if (orgImage == null)
                return null;

            CogIPOneImageTool imageTool = new CogIPOneImageTool();
            byte[] mapArray = new byte[256];

            for (int i = 0; i < mapArray.Length; i++)
            {
                byte data = mapArray[i];
                if (i >= threshold)
                    mapArray[i] = isInvert ? (byte)0 : (byte)maxValue;
                else
                    mapArray[i] = isInvert ? (byte)maxValue : (byte)0;
            }

            CogRectangle rect = new CogRectangle
            {
                X = 0,
                Y = 0,
                Width = orgImage.Width,
                Height = orgImage.Height,
            };

            CogIPOneImagePixelMap pixelMap = new CogIPOneImagePixelMap();
            pixelMap.SetMap(mapArray);

            imageTool.Operators.Add(pixelMap);
            pixelMap.Dispose();

            imageTool.InputImage = orgImage;
            imageTool.Run();

            CogImage8Grey outputImage = new CogImage8Grey((CogImage8Grey)imageTool.OutputImage);
            imageTool.Dispose();

            return outputImage;
        }

        public static CogImage8Grey Threshold(CogImage8Grey orgImage, int minThreshold, int maxThreshold, int maxValue, bool isInvert = false)
        {
            if (orgImage == null)
                return null;

            CogIPOneImageTool imageTool = new CogIPOneImageTool();
            byte[] mapArray = new byte[256];

            for (int i = 0; i < mapArray.Length; i++)
            {
                byte data = mapArray[i];
                if (i >= minThreshold && i <= maxThreshold)
                    mapArray[i] = isInvert ? (byte)0 : (byte)maxValue;
                else
                    mapArray[i] = isInvert ? (byte)maxValue : (byte)0;
            }

            CogRectangle rect = new CogRectangle
            {
                X = 0,
                Y = 0,
                Width = orgImage.Width,
                Height = orgImage.Height,
            };

            CogIPOneImagePixelMap pixelMap = new CogIPOneImagePixelMap();
            pixelMap.SetMap(mapArray);

            imageTool.Operators.Add(pixelMap);
            pixelMap.Dispose();

            imageTool.InputImage = orgImage;
            imageTool.Run();

            CogImage8Grey outputImage = new CogImage8Grey((CogImage8Grey)imageTool.OutputImage);
            imageTool.Dispose();

            return outputImage;
        }

        public static ICogImage CogCopyRegionTool(ICogImage destImage, ICogImage inputImage, ICogRegion rect, bool alignmentEnabled)
        {
            CogCopyRegionTool regionTool = new CogCopyRegionTool();

            regionTool.DestinationImage = destImage;
            regionTool.InputImage = inputImage;
            regionTool.Region = rect;

            regionTool.RunParams.ImageAlignmentEnabled = alignmentEnabled;
            regionTool.Run();

            ICogImage cogImage = regionTool.OutputImage.CopyBase(CogImageCopyModeConstants.CopyPixels);

            regionTool.Dispose();

            return cogImage;
        }

        public static ICogImage CropImage(ICogImage sourceImage, CogRectangle rect)
        {
            CogCopyRegionTool regionTool = new CogCopyRegionTool();
            regionTool.InputImage = sourceImage;
            regionTool.Region = rect;
            regionTool.Run();
            return regionTool.OutputImage;
        }

        public static ICogImage CropImage(ICogImage sourceImage, CogPolygon polygon)
        {
            CogCopyRegionTool regionTool = new CogCopyRegionTool();
            regionTool.InputImage = sourceImage;
            regionTool.Region = polygon;
            regionTool.Run();
            return regionTool.OutputImage;
        }

        public static ICogImage CropImage(ICogImage sourceImage, CogRectangleAffine rect)
        {
            CogCopyRegionTool regionTool = new CogCopyRegionTool();
            regionTool.InputImage = sourceImage;
            regionTool.Region = rect;
            regionTool.Run();
            return regionTool.OutputImage;
        }

        public static CogRectangle CreateRectangle(double centerX, double centerY, double width, double height, bool interactive = true, CogRectangleDOFConstants constants = CogRectangleDOFConstants.All)
        {
            CogRectangle roi = new CogRectangle();

            roi.SetCenterWidthHeight(centerX, centerY, width, height);
            roi.Interactive = interactive;
            roi.GraphicDOFEnable = constants;

            return roi;
        }

        public static CogRectangleAffine CreateRectangleAffine(double centerX, double centerY, double sideXLength, double sideYLength, double rotation = 0, double skew = 0, bool interactive = true, CogRectangleAffineDOFConstants constants = CogRectangleAffineDOFConstants.All)
        {
            CogRectangleAffine roi = new CogRectangleAffine();

            roi.SetCenterLengthsRotationSkew(centerX, centerY, sideXLength, sideYLength, rotation, skew);
            roi.Interactive = interactive;
            roi.XDirectionAdornment = CogRectangleAffineDirectionAdornmentConstants.SolidArrow;
            roi.YDirectionAdornment = CogRectangleAffineDirectionAdornmentConstants.Arrow;
            roi.GraphicDOFEnable = constants;

            return roi;
        }
    
        public static List<CogRectangleAffine> CreateRectangleAffine(List<PointF> topEdgePointList, List<PointF> bottomEdgePointList)
        {
            
            if (topEdgePointList.Count % 2 != 0 || bottomEdgePointList.Count % 2 != 0)
            {
                // Top, Bottom List 모두 짝수여야함
                return null;
            }

            int indexMax = topEdgePointList.Count;
            if (topEdgePointList.Count != bottomEdgePointList.Count)
            {
                // Top, Bottom List 수가 같아야함
                //return null;

                indexMax = topEdgePointList.Count > bottomEdgePointList.Count ? bottomEdgePointList.Count : topEdgePointList.Count;
            }

            List<CogRectangleAffine> roiList = new List<CogRectangleAffine>();

            for (int i = 0; i < topEdgePointList.Count; i+= 2)
            {
                if (i + 1 >= indexMax)
                    break;
                CogRectangleAffine roi = new CogRectangleAffine();
                double originX = topEdgePointList[i].X;
                double originY = topEdgePointList[i].Y;
                double cornerXX = topEdgePointList[i + 1].X;
                double cornerXY = topEdgePointList[i + 1].Y;
                double cornerYX = bottomEdgePointList[i].X;
                double cornerYY = bottomEdgePointList[i].Y;

                roi.SetOriginCornerXCornerY(originX, originY, cornerXX, cornerXY, cornerYX, cornerYY);
                roiList.Add(roi);
            }
            return roiList; 
        }

        public static ICogImage ConvertImage(byte[] data, int width, int height, ColorFormat colorFormat)
        {
            if (colorFormat == ColorFormat.Gray)
            {
                CogImage8Root root = new CogImage8Root();
                TestClass test = new TestClass();
                unsafe
                {
                    fixed(byte* dataPtr = data)
                    {

                        root.Initialize(width, height, (IntPtr)dataPtr, width, test);
                        var cogImage = new CogImage8Grey();
                        cogImage.SetRoot(root);
                        
                        return cogImage;
                    }
                }
            }
            else if (colorFormat == ColorFormat.RGB24)
            {
                var dataSize = width * height;

                var bufferB = new SafeMalloc(dataSize);
                Marshal.Copy(data, 0, bufferB, dataSize);

                var bufferG = new SafeMalloc(dataSize);
                Marshal.Copy(data, dataSize, bufferG, dataSize);

                var bufferR = new SafeMalloc(dataSize);
                Marshal.Copy(data, dataSize * 2, bufferR, dataSize);

                var cogRootR = new CogImage8Root();
                cogRootR.Initialize(width, height, bufferR, width, bufferR);

                var cogRootG = new CogImage8Root();
                cogRootG.Initialize(width, height, bufferG, width, bufferG);

                var cogRootB = new CogImage8Root();
                cogRootB.Initialize(width, height, bufferB, width, bufferB);

                var cogImage = new CogImage24PlanarColor();
                cogImage.SetRoots(cogRootR, cogRootG, cogRootB);

                return cogImage;
            }
            return null;
        }

        public static ICogImage CovertImage(IntPtr ptr, int width, int height, int stride, ColorFormat colorFormat)
        {
            if (colorFormat == ColorFormat.Gray)
            {
                CogImage8Root root = new CogImage8Root();

                //byte[] buffer = new byte[stride * height];
                //Marshal.Copy(ptr, buffer, 0, stride * height);

                //IntPtr copyPtr = Marshal.AllocHGlobal(stride * height);
                //Marshal.Copy(buffer, 0, copyPtr, stride * height);
        


                root.Initialize(width, height, ptr, stride, null);
                var cogImage = new CogImage8Grey();
                cogImage.SetRoot(root);

                return cogImage;
            }
            return null;
        }

        public static ICogImage CovertImage(byte[] dataR, byte[] dataG, byte[] dataB, int width, int height)
        {
            var dataSize = width * height;

            var bufferB = new SafeMalloc(dataSize);
            Marshal.Copy(dataB, 0, bufferB, dataSize);

            var bufferG = new SafeMalloc(dataSize);
            Marshal.Copy(dataG, 0, bufferG, dataSize);

            var bufferR = new SafeMalloc(dataSize);
            Marshal.Copy(dataR, 0, bufferR, dataSize);


            var cogRootR = new CogImage8Root();
            cogRootR.Initialize(width, height, bufferR, width, bufferR);

            var cogRootG = new CogImage8Root();
            cogRootG.Initialize(width, height, bufferG, width, bufferG);

            var cogRootB = new CogImage8Root();
            cogRootB.Initialize(width, height, bufferB, width, bufferB);

            var cogImage = new CogImage24PlanarColor();
            cogImage.SetRoots(cogRootR, cogRootG, cogRootB);

            return cogImage;
        }

        

        public static CogImage8Grey Convert24PlanarColorToGrey(CogImage24PlanarColor colorImage)
        {
            CogImageConvertTool imageConvertTool = new CogImageConvertTool();
            imageConvertTool.InputImage = colorImage;
            imageConvertTool.Run();

            CogImage8Grey outputImage = imageConvertTool.OutputImage as CogImage8Grey;
            return outputImage;
        }
    }

    public class TestClass : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Dispose");
        }
    }
}
