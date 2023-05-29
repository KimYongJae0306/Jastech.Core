using Emgu.CV;
using Jastech.Framework.Imaging.VisionAlgorithms;
using Jastech.Framework.Imaging.VisionAlgorithms.Parameters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Algorithms.Akkon.Parameters
{
    public class AkkonSlice
    {
        public Mat Image { get; set; }

        public Rectangle WorldRect { get; set; }

        public Point StartPoint { get; set; }

        public List<AkkonROI> CalcAkkonROIs { get; set; } = new List<AkkonROI>();

        public List<AkkonBlob> ResultList { get; set; } = new List<AkkonBlob>();

        // Debug 용 속성
        public Mat EnhanceMat { get; set; } = null;

        public Mat ProcessingMat { get; set; } = null;

        public Mat MaskingMat { get; set; } = null;

        public void Dispose()
        {
            Image?.Dispose();
            CalcAkkonROIs.Clear();
            ResultList.Clear();
        }
    }
    
    public class AkkonBlob
    {
        public int LeadIndex { get; set; }

        public AkkonROI Lead { get; set; }

        public double OffsetToWorldX { get; set; }

        public double OffsetToWorldY { get; set; }

        public double LeadOffsetX { get; set; }

        public double LeadOffsetY { get; set; }

        public List<BlobPos> BlobList = new List<BlobPos>();

    }
}
