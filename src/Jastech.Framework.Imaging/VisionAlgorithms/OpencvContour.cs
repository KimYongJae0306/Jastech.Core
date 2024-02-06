using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using Jastech.Framework.Imaging.Helper;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Jastech.Framework.Imaging.VisionAlgorithms
{
    public class OpencvContour
    {
        public unsafe List<BlobPos> Run(Mat image, RetrType retryType = RetrType.External, ChainApproxMethod chainApproxMethod = ChainApproxMethod.ChainApproxSimple)
        {
            List<BlobPos> blobList = new List<BlobPos>();

            var contours = new VectorOfVectorOfPoint();
            Mat hierarchy = new Mat();
            CvInvoke.FindContours(image, contours, hierarchy, retryType, chainApproxMethod);

            if (contours.Size != 0)
            {
                float[]  hierarchyArray = MatHelper.MatToFloatArray(hierarchy);
                for (int idxContour = 0; idxContour < contours.Size; ++idxContour)
                { // hier-1 only
                    if (hierarchyArray[idxContour * 4 + 3] > -0.5)
                        continue;
                    var contour = contours[idxContour];

                    //var hull = new VectorOfPoint();
                    //CvInvoke.ConvexHull(contour, hull, true);

                    //Features
                    double area = CvInvoke.ContourArea(contour);
                    if (area > 0)
                    {
                        Moments moments = CvInvoke.Moments(contour);
                        Rectangle rect = CvInvoke.BoundingRectangle(contour);
                        BlobPos blob = new BlobPos
                        {
                            Points = contour.ToArray().ToList(),
                            Area = area,
                            Avg = CvInvoke.Mean(contour).V0,
                            CenterX = moments.M10 / moments.M00,
                            CenterY = moments.M01 / moments.M00,
                            BoundingRect = rect,
                        };

                        blobList.Add(blob);
                    }
                }
            }
            return blobList;
        }
    }
}
