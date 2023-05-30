using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using Jastech.Framework.Imaging.Helper;
using Jastech.Framework.Imaging.VisionAlgorithms.Parameters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Jastech.Framework.Imaging.VisionAlgorithms
{
    public class OpencvContour
    {
        public List<BlobPos> Run(Mat image, RetrType retryType = RetrType.Ccomp, ChainApproxMethod chainApproxMethod = ChainApproxMethod.ChainApproxSimple)
        {
            List<BlobPos> blobList = new List<BlobPos>();

           var contours = new VectorOfVectorOfPoint();
            Mat hierarchy = new Mat();

            CvInvoke.FindContours(image, contours, hierarchy, RetrType.External, chainApproxMethod);
            
            if (contours.Size != 0)
            {
                float[]  hierarchyArray = MatHelper.MatToFloatArray(hierarchy);
                for (int idxContour = 0; idxContour < contours.Size; ++idxContour)
                { // hier-1 only
                        if (hierarchyArray[idxContour * 4 + 3] > -0.5)
                            continue;

                    var contour = contours[idxContour];

                    var hull = new VectorOfPoint();
                    CvInvoke.ConvexHull(contour, hull, true);

                    //Features
                    Moments moments = CvInvoke.Moments(contour);
                    Rectangle rect = CvInvoke.BoundingRectangle(contour);
                    
                    BlobPos blob = new BlobPos
                    {
                        Points = contour.ToArray().ToList(),
                        Area = CvInvoke.ContourArea(contour),
                        Avg = CvInvoke.Mean(contour).V0,
                        CenterX = moments.M10 / moments.M00,
                        CenterY = moments.M01 / moments.M00,
                        BoundingRect = rect,
                    };

                    blobList.Add(blob);
                }
            }

            return blobList;
        }
    }
}
