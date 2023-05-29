using Cognex.VisionPro;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Imaging.VisionPro
{
    public static partial class VisionProMathHelper
    {
        public static CogDistanceResult GetDistance(PointF startPoint, PointF endPoint, double resolution = 1.0)
        {
            CogDistanceResult result = new CogDistanceResult();

            result.StartPoint = new PointF(startPoint.X, startPoint.Y);
            result.EndPoint = new PointF(endPoint.X, endPoint.Y);

            double centerX = (startPoint.X + endPoint.X) / 2.0;
            double centerY = (startPoint.Y + endPoint.Y) / 2.0;
            result.CenterPoint = new PointF((float)centerX, (float)centerY);
            result.DistanceX = Math.Abs(endPoint.X - startPoint.X) * resolution;
            result.DistanceY = Math.Abs(endPoint.Y - startPoint.Y) * resolution;
            result.Length = (Math.Sqrt(Math.Pow(result.DistanceX, 2) + Math.Pow(result.DistanceY, 2))) * resolution;
            result.Degree = CogMisc.RadToDeg(Math.Atan(result.DistanceY / result.DistanceX));

            return result;
        }
    }

    public static partial class VisionProMathHelper
    {
        public class CogDistanceResult
        {
            #region 속성
            public PointF StartPoint { get; set; }

            public PointF EndPoint { get; set; }

            public PointF CenterPoint { get; set; }

            public double DistanceX { get; set; }

            public double DistanceY { get; set; }

            public double Length { get; set; }

            public double Degree { get; set; }
            #endregion
        }
    }

}
