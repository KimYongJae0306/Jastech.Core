using System.Drawing;

namespace Jastech.Framework.Imaging.VisionAlgorithms
{
    public class PatternMatchPos
    {
        #region 속성
        public PointF ReferencePos { get; set; }

        public float ReferenceWidth { get; set; }

        public float ReferenceHeight { get; set; }

        public PointF FoundPos { get; set; }

        public float Score { get; set; }

        public float Scale { get; set; }

        public double Angle { get; set; }
        #endregion

        #region 메서드
        public PointF TranslateOffset()
        {
            return new PointF(ReferencePos.X - FoundPos.X, ReferencePos.Y - FoundPos.Y);
        }

        public virtual void Dispose()
        {
           
        }

        public virtual PatternMatchPos DeepCopy()
        {
            PatternMatchPos matchPos = new PatternMatchPos();
            matchPos.ReferencePos = new PointF(ReferencePos.X, ReferencePos.Y);
            matchPos.ReferenceWidth = ReferenceWidth;
            matchPos.ReferenceHeight = ReferenceHeight;
            matchPos.FoundPos = new PointF(FoundPos.X, FoundPos.Y);
            matchPos.Score = Score;
            matchPos.Scale = Scale;
            matchPos.Angle = Angle;

            return matchPos;
        }
        #endregion
    }
}
