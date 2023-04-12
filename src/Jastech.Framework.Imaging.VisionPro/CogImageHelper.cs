using Cognex.VisionPro;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.ImageProcessing;
using Cognex.VisionPro.PMAlign;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Imaging.VisionPro
{
    public static class CogImageHelper
    {
        public static ICogImage Load(string fileName)
        {
            CogImageFile cogImageFile = new CogImageFile();

            cogImageFile.Open(fileName, CogImageFileModeConstants.Read);

            ICogImage image = cogImageFile[0];
            cogImageFile.Close();

            return image;
        }

        public static void Save(ICogImage image, string fileName)
        {
            string extension = Path.GetExtension(fileName);
            if (extension == ".bmp")
            {
                CogImageFileBMP bmp = new CogImageFileBMP();
                bmp.Open(fileName, CogImageFileModeConstants.Write);
                bmp.Append(image);
                bmp.Close();
            }
            else if(extension == ".jpg" || extension == "jpeg")
            {
                CogImageFileJPEG jpg = new CogImageFileJPEG();
                jpg.Open(fileName, CogImageFileModeConstants.Write);
                jpg.Append(image);
                jpg.Close();
            }
            else if(extension == ".png")
            {
                CogImageFilePNG png = new CogImageFilePNG();
                png.Open(fileName, CogImageFileModeConstants.Write);
                png.Append(image);
                png.Close();
            }
        }

        public static CogImage8Grey Threshold(CogImage8Grey orgImage, int threshold, int maxValue, bool isInvert = false)
        {
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

        public static ICogImage CogCopyRegionTool(ICogImage destImage, ICogImage inputImage, CogRectangle rect, bool alignmentEnabled)
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

        public static ICogImage CovertImage(byte[] data, int width, int height, ColorFormat colorFormat)
        {
            if (colorFormat == ColorFormat.Gray)
            {
                var dataSize = width * height;
                var buffer = new SafeMalloc(dataSize);

                Marshal.Copy(data, 0, buffer, dataSize);

                CogImage8Root root = new CogImage8Root();

                root.Initialize(width, height, buffer, width, buffer);
                var cogImage = new CogImage8Grey();
                cogImage.SetRoot(root);
                return cogImage;
            }
            else if(colorFormat == ColorFormat.RGB24)
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

        public static List<CogRectangleAffine> DivideRegion(CogRectangleAffine orgRect, int leadCount)
        {
            if (leadCount <= 0)
                return null;

            int totalCount = leadCount * 2;
            List<CogRectangleAffine> divideRegionList = new List<CogRectangleAffine>();

            double interval = orgRect.SideXLength / totalCount;
            double centerX = orgRect.CenterX - (((orgRect.SideXLength / 2) - (interval / 2)) * Math.Cos(orgRect.Rotation));
            double centerY = orgRect.CenterY - (((orgRect.SideXLength / 2) - (interval / 2)) * Math.Sin(orgRect.Rotation));


            for (int index = 0; index < totalCount; index++)
            {
                CogRectangleAffine divideRegion = new CogRectangleAffine(orgRect);

                double dX = (interval * index) * System.Math.Cos(orgRect.Rotation);
                double dY = (interval* index) * System.Math.Sin(orgRect.Rotation);//orgRect.Rotation;

                //double dX = orgRect.SideXLength / leadCount * leadIndex * System.Math.Cos(orgRect.Rotation);
                //double dY = orgRect.SideXLength / leadCount * leadIndex * orgRect.Rotation;

                divideRegion.SideXLength = interval;
                divideRegion.CenterX = centerX + dX;
                divideRegion.CenterY = centerY + dY;

                //if (index % 2 == 0) //좌측부분 ROI
                //    divideRegion.Rotation = divideRegion.Rotation - 3.14;
                //divideRegion.CenterX = centerX + (interval * index);
                //divideRegion.CenterY = centerY;

                divideRegionList.Add(divideRegion);
            }

            //tool.Region.CornerXY
            //double dNewX = (orgRect.CenterX - orgRect.SideXLength / 2)/* + (orgRect.SideXLength / totalCount)*/;
            //double dNewY = orgRect.CenterY;

            //for (int leadIndex = 0; leadIndex < totalCount; leadIndex++)
            //{
            //    CogRectangleAffine divideRegion = new CogRectangleAffine(orgRect);

            //    double dX = (orgRect.SideXLength / totalCount) * leadIndex * System.Math.Cos(orgRect.Rotation);
            //    double dY = orgRect.SideXLength / totalCount * leadIndex * System.Math.Sin(orgRect.Rotation);//orgRect.Rotation;

            //    //double dX = orgRect.SideXLength / leadCount * leadIndex * System.Math.Cos(orgRect.Rotation);
            //    //double dY = orgRect.SideXLength / leadCount * leadIndex * orgRect.Rotation;

            //    divideRegion.SideXLength = divideRegion.SideXLength / totalCount;
            //    divideRegion.CenterX = dNewX + dX;
            //    divideRegion.CenterY = dNewY + dY;

            //    divideRegionList.Add(divideRegion);
            //}

            return divideRegionList;
        }
    }
}
