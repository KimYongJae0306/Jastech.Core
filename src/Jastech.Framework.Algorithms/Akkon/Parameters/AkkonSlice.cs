using Emgu.CV;
using Jastech.Framework.Imaging.Result;
using Jastech.Framework.Imaging.VisionAlgorithms;
using System.Collections.Generic;
using System.Drawing;

namespace Jastech.Framework.Algorithms.Akkon.Parameters
{
    public class AkkonSlice
    {
        public int Id { get; set; }

        public Mat Image { get; set; }

        public Rectangle WorldRect { get; set; }

        public Point StartPoint { get; set; }

        public List<AkkonROI> CalcAkkonROIs { get; set; } = new List<AkkonROI>();

        public List<AkkonLeadResult> LeadResultList { get; set; } = new List<AkkonLeadResult>();
        
        // Debug 용 속성
        public Mat EnhanceMat { get; set; } = null;

        public Mat ProcessingMat { get; set; } = null;

        public Mat MaskingMat { get; set; } = null;

        public void Dispose()
        {
            Image?.Dispose();
            CalcAkkonROIs.Clear();
            LeadResultList.Clear();
        }
    }
    
    public class AkkonLeadResult
    {
        public int Index { get; set; }

        public AkkonROI Lead { get; set; }

        public LeadContainPos ContainPos { get; set; }

        public double OffsetToWorldX { get; set; }

        public double OffsetToWorldY { get; set; }

        public double OffsetX { get; set; }

        public double OffsetY { get; set; }

        public double Slope { get; set; }

        public double StdDev { get; set; }

        public double Mean { get; set; }

        public double LengthX_um { get; set; }

        public double LengthY_um { get; set; }

        public int DetectCount { get; set; }

        public Judgement CountJudgement { get; set; }

        public Judgement LengthJudgement { get; set; }

        public List<BlobPos> BlobList = new List<BlobPos>();
    }

    public enum LeadContainPos
    {
        Left,
        Right,
    }
}
