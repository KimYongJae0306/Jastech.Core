using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.Data
{
    public class RectangleFigure : Figure
    {
        public RectangleF LeftTopTrackRect { get; set; }

        public RectangleF LeftBottomTrackRect { get; set; }

        public RectangleF RightTopTrackRect { get; set; }

        public RectangleF RightBottomTrackRect { get; set; }

        public RectangleF ViewRect { get; set; }

        public PointF FixedPoint = new PointF();

        public RectangleFigure()
        {
            FigureType = FigureType.Rectangle;
        }
      
        public override void MouseDown(PointF point)
        {
            base.MouseDown(point);
            CurrentTrackPos = CheckTrackPos(point);
            FixedPoint = CalcFixedPoint(CurrentTrackPos);
        }

        private PointF CalcFixedPoint(TrackPosType trackPos)
        {
            PointF fixedPoint = new PointF();

            if (trackPos == TrackPosType.LeftTop)
            {
                fixedPoint.X = ViewRect.X + ViewRect.Width;
                fixedPoint.Y = ViewRect.Y + ViewRect.Height;
            }
            else if (trackPos == TrackPosType.RightBottom)
            {
                fixedPoint.X = ViewRect.X;
                fixedPoint.Y = ViewRect.Y;
            }
            else if (trackPos == TrackPosType.LeftBottom)
            {
                fixedPoint.X = ViewRect.X + ViewRect.Width;
                fixedPoint.Y = ViewRect.Y;
            }
            else if (trackPos == TrackPosType.RightTop)
            {
                fixedPoint.X = ViewRect.X;
                fixedPoint.Y = ViewRect.Y + ViewRect.Height;
            }
            else if (trackPos == TrackPosType.InSide)
            {
                fixedPoint.X = ViewRect.X;
                fixedPoint.Y = ViewRect.Y;
            }

            return fixedPoint;
        }

        public override void MouseMove(PointF point)
        {
            base.MouseMove(point);
            if (IsSelected  == false)
            {
                ViewRect = CalcPointToRectangle(MouseDownPoint, MouseMovePoint);

                TrackRectangleList.Clear();
                TrackRectangleList.AddRange(GetTrackRectangles(ViewRect));
            }
            else
            {
                
                if (CurrentTrackPos == TrackPosType.LeftTop || CurrentTrackPos == TrackPosType.LeftBottom
                            || CurrentTrackPos == TrackPosType.RightTop || CurrentTrackPos == TrackPosType.RightBottom)
                {
                    ViewRect = CalcPointToRectangle(FixedPoint, MouseMovePoint);
                }
                else if (CurrentTrackPos == TrackPosType.InSide)
                {
                    float moveX = MouseDownPoint.X - MouseMovePoint.X;
                    float moveY = MouseDownPoint.Y - MouseMovePoint.Y;

                    RectangleF panningRect = new RectangleF();
                    panningRect.X = FixedPoint.X - moveX;
                    panningRect.Y = FixedPoint.Y - moveY;
                    panningRect.Width = ViewRect.Width;
                    panningRect.Height = ViewRect.Height;

                    ViewRect = panningRect;
                }

                TrackRectangleList.Clear();
                TrackRectangleList.AddRange(GetTrackRectangles(ViewRect));
            }
        }

        public override void MouseUp(PointF endPoint)
        {
            base.MouseUp(endPoint);
        }

        public override void Draw(Graphics g)
        {
            g.DrawRectangle(new Pen(Color.Yellow, 2), Rectangle.Round(ViewRect));

            if (IsSelected)
            {
                if (TrackRectangleList.Count > 0)
                    g.FillRectangles(Brushes.White, TrackRectangleList.ToArray());
            }
        }

        public override void CheckPointInFigure(PointF point)
        {
            if (ViewRect.Contains(new Point((int)point.X, (int)point.Y)))
            {
                IsSelected = true;
                CurrentTrackPos = TrackPosType.InSide;
                return;
            }

            foreach (var track in TrackRectangleList)
            {
                if (track.Contains(point))
                {
                    IsSelected = true;
                    CurrentTrackPos = CheckTrackPos(point);
                    return;
                }
            }

            IsSelected = false;
            CurrentTrackPos = TrackPosType.None;
        }

        public override TrackPosType CheckTrackPos(PointF pt)
        {
            if (IsSelected == false)
                return TrackPosType.None;

            if (LeftTopTrackRect.Contains(pt))
                return TrackPosType.LeftTop;

            if (LeftBottomTrackRect.Contains(pt))
                return TrackPosType.LeftBottom;

            if (RightTopTrackRect.Contains(pt))
                return TrackPosType.RightTop;

            if (RightBottomTrackRect.Contains(pt))
                return TrackPosType.RightBottom;

            if (ViewRect.Contains(pt))
                return TrackPosType.InSide;

            return TrackPosType.None;
        }

        public List<RectangleF> GetTrackRectangles(RectangleF drawRect)
        {
            List<RectangleF> trackRects = new List<RectangleF>();

            LeftTopTrackRect = GetRectangle(new PointF(drawRect.Left, drawRect.Top), TrackRectSize);
            LeftBottomTrackRect = GetRectangle(new PointF(drawRect.Left, drawRect.Bottom), TrackRectSize);

            RightTopTrackRect = GetRectangle(new PointF(drawRect.Right, drawRect.Top), TrackRectSize);
            RightBottomTrackRect = GetRectangle(new PointF(drawRect.Right, drawRect.Bottom), TrackRectSize);

            trackRects.Add(LeftTopTrackRect);
            trackRects.Add(LeftBottomTrackRect);
            trackRects.Add(RightTopTrackRect);
            trackRects.Add(RightBottomTrackRect);

            return trackRects;
        }

        public override Cursor GetCursors(PointF point)
        {
            if (IsSelected)
            {
                var trackPosType = CheckTrackPos(point);

                if (trackPosType == TrackPosType.InSide)
                    return Cursors.SizeAll;
                else if (trackPosType == TrackPosType.LeftTop || trackPosType == TrackPosType.RightBottom)
                    return Cursors.SizeNWSE;
                else if (trackPosType == TrackPosType.LeftBottom || trackPosType == TrackPosType.RightTop)
                    return Cursors.SizeNESW;
            }

            return Cursors.Default;
        }

        private Rectangle GetRectangle(PointF point, int rectSize)
        {
            float centerX = point.X - (rectSize / 2.0f);
            float centerY = point.Y - (rectSize / 2.0f);

            return new Rectangle((int)centerX, (int)centerY, rectSize, rectSize);
        }

        public Rectangle CalcPointToRectangle(PointF p1, PointF p2)
        {
            float width = Math.Abs(p1.X - p2.X);
            float height = Math.Abs(p1.Y - p2.Y);

            RectangleF rect = new RectangleF();

            if (p1.X > p2.X)
            {
                if (p1.Y > p2.Y)
                {
                    rect.X = p2.X;
                    rect.Y = p2.Y;
                }
                else
                {
                    rect.X = p1.X - width;
                    rect.Y = p1.Y;
                }
            }
            else
            {
                if (p1.Y < p2.Y)
                {
                    rect.X = p1.X;
                    rect.Y = p1.Y;
                }
                else
                {
                    rect.X = p2.X - width;
                    rect.Y = p2.Y;
                }
            }
            rect.Width = width;
            rect.Height = height;
            return Rectangle.Round(rect);
        }
    }
}
