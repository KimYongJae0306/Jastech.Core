using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Imaging.Helper
{
    public static class MatHelper
    {
        public static Mat Rotate(Mat image, double angle)
        {
            Point2f center = new Point2f(image.Width / 2.0f, image.Height / 2.0f);

            Mat matrix = Cv2.GetRotationMatrix2D(center, angle, 1);

            Mat imageRotated = new Mat();
            Cv2.WarpAffine(image, imageRotated, matrix, new OpenCvSharp.Size(image.Width, image.Height));

            matrix.Dispose();

            return imageRotated;
        }

        public static Mat Transpose(Mat image)
        {
            OpenCvSharp.Size size = new OpenCvSharp.Size(image.Width, image.Height);

            Mat destMat = new Mat(size, image.Type());
            Cv2.Transpose(image, destMat);

            return destMat;
        }
    }
}
