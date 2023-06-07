using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.Data
{
    public class LineDirectionFigure : Figure
    {
        public RectangleF StartTrackRect { get; set; }

        public RectangleF EndTrackRect { get; set; }

        public List<PointF> DrawPoints { get; set; } = new List<PointF>();

        public PointF FixedPoint = new PointF();

        public PointF PrevMovePoint = new PointF();

        public bool IsFirstMove { get; set; } = false;

        public LineDirectionFigure()
        {
            FigureType = FigureType.ArrowLine;
        }

        public override void MouseDown(PointF point)
        {
            base.MouseDown(point);
            CurrentTrackPos = CheckTrackPos(point);
            FixedPoint = CalcFixedPoint(CurrentTrackPos);
            IsFirstMove = true;
        }

        private PointF CalcFixedPoint(TrackPosType trackPos)
        {
            PointF fixedPoint = new PointF();

            if (trackPos == TrackPosType.Start)
            {
                fixedPoint = DrawPoints.Last();
            }
            else if (trackPos == TrackPosType.End)
            {
                fixedPoint = DrawPoints.First();
            }
            else if (trackPos == TrackPosType.InSide)
            {
                fixedPoint = DrawPoints.First();
            }
            return fixedPoint;
        }

        public override void MouseMove(PointF point)
        {
            base.MouseMove(point);
            if (IsSelected == false)
            {
                DrawPoints = GetPointListOfLine(MouseDownPoint, MouseMovePoint);
                TrackRectangleList.Clear();
                TrackRectangleList.AddRange(GetTrackRectangles(MouseDownPoint, MouseMovePoint));
            }
            else
            {

                if (CurrentTrackPos == TrackPosType.Start)
                {
                    DrawPoints = GetPointListOfLine(MouseMovePoint, FixedPoint);
                }
                else if (CurrentTrackPos == TrackPosType.End)
                {
                    DrawPoints = GetPointListOfLine(FixedPoint, MouseMovePoint);
                }
                else if (CurrentTrackPos == TrackPosType.InSide)
                {
                    if(IsFirstMove)
                    {
                        IsFirstMove = false;
                        PrevMovePoint = MouseMovePoint;
                    }
                    float moveX = PrevMovePoint.X - MouseMovePoint.X;
                    float moveY = PrevMovePoint.Y - MouseMovePoint.Y;
                 
                    List<PointF> movePoints = new List<PointF>();
                    for (int i = 0; i < DrawPoints.Count(); i++)
                    {
                        var drawPoint = DrawPoints[i];
                        PointF newPoint = new PointF();
                        newPoint.X = drawPoint.X - moveX;
                        newPoint.Y = drawPoint.Y - moveY;

                        movePoints.Add(newPoint);
                    }
                    PrevMovePoint = MouseMovePoint;

                    DrawPoints.Clear();
                    DrawPoints = movePoints;
                }

                TrackRectangleList.Clear();

                if(DrawPoints.Count() > 0)
                {
                    var firstPoint = DrawPoints.First();
                    var endPoint = DrawPoints.Last();
                    TrackRectangleList.AddRange(GetTrackRectangles(firstPoint, endPoint));
                }
            }
        }

        public override void MouseUp(PointF endPoint)
        {
            base.MouseUp(endPoint);
        }

        public override void CheckPointInFigure(PointF point)
        {
            float interval = 30;
            foreach (var track in TrackRectangleList)
            {
                if (track.Contains(point))
                {
                    IsSelected = true;
                    CurrentTrackPos = CheckTrackPos(point);
                    return;
                }
            }

            foreach (var drawPt in DrawPoints)
            {
                if (drawPt.X - interval <= point.X && point.X <= drawPt.X + interval)
                {
                    if (drawPt.Y - interval <= point.Y && point.Y <= drawPt.Y + interval)
                    {
                        IsSelected = true;
                        CurrentTrackPos = TrackPosType.InSide;
                        return;
                    }
                }
            }

            
         
            IsSelected = false;
            CurrentTrackPos = TrackPosType.None;
        }

        public override TrackPosType CheckTrackPos(PointF pt)
        {
            if (IsSelected == false)
                return TrackPosType.None;


            if (StartTrackRect.Contains(pt))
                return TrackPosType.Start;

            if (EndTrackRect.Contains(pt))
                return TrackPosType.End;

            float interval = 30;
            foreach (var drawPt in DrawPoints)
            {
                if (drawPt.X - interval <= pt.X && pt.X <= drawPt.X + interval)
                {
                    if (drawPt.Y - interval <= pt.Y && pt.Y <= drawPt.Y + interval)
                    {
                        IsSelected = true;
                        return TrackPosType.InSide;
                    }
                }
            }

            return TrackPosType.None;
        }

        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.Yellow, FigureWidth);

            int arrayCapSize = (int)(FigureWidth * 1.5);
            AdjustableArrowCap bigArrow = new AdjustableArrowCap(arrayCapSize, arrayCapSize);
            pen.CustomEndCap = bigArrow;

            if(DrawPoints.Count > 1)
            {
                g.DrawLines(pen, DrawPoints.ToArray());
            }

            if (IsSelected)
            {
                if (TrackRectangleList.Count > 0)
                    g.FillRectangles(Brushes.White, CalcTrackRectangleList().ToArray());
            }
        }

        private List<RectangleF> CalcTrackRectangleList()
        {
            List<RectangleF> calcRectList = new List<RectangleF>();
            if (TrackRectangleList.Count > 0)
            {
                foreach (var rect in TrackRectangleList)
                {
                    float centerX = rect.X + rect.Width / 2;
                    float centerY = rect.Y + rect.Height / 2;

                    float newLeft = centerX - TrackRectSize / 2;
                    float newTop = centerY - TrackRectSize / 2;
                    calcRectList.Add(new RectangleF(newLeft, newTop, TrackRectSize, TrackRectSize));
                }
            }
            return calcRectList;
        }
        public override Cursor GetCursors(PointF point)
        {
            if (IsSelected)
            {
                var trackPosType = CheckTrackPos(point);

                if (trackPosType == TrackPosType.InSide)
                    return Cursors.SizeAll;
                else if (trackPosType == TrackPosType.Start || trackPosType == TrackPosType.End)
                    return Cursors.SizeNWSE;
            }

            return Cursors.Default;
        }

        public List<RectangleF> GetTrackRectangles(PointF startPoint, PointF endPoint)
        {
            List<RectangleF> trackRects = new List<RectangleF>();

            float half = TrackRectSize / 2.0f;
            StartTrackRect = new RectangleF(startPoint.X - half, startPoint.Y - half, TrackRectSize, TrackRectSize);
            EndTrackRect = new RectangleF(endPoint.X - half, endPoint.Y - half, TrackRectSize, TrackRectSize);

            trackRects.Add(StartTrackRect);
            trackRects.Add(EndTrackRect);

            return trackRects;
        }

        public List<PointF> GetPointListOfLine(PointF startPoint, PointF endPoint)
        {
            List<PointF> rstPoints = new List<PointF>();

            float x, y, dxD, dyD, step;
            int cnt = 0;

            dxD = (endPoint.X - startPoint.X);
            dyD = (endPoint.Y - startPoint.Y);

            if (Math.Abs(dxD) >= Math.Abs(dyD))
                step = Math.Abs(dxD);
            else
                step = Math.Abs(dyD);

            dxD = dxD / step;
            dyD = dyD / step;
            x = startPoint.X;
            y = startPoint.Y;

            while (cnt <= step)
            {
                Point point = new Point((int)Math.Round(x, 0), (int)Math.Round(y, 0));
                
                rstPoints.Add(point);

                x = x + dxD;
                y = y + dyD;

                cnt += 1;
            }
            return rstPoints;
        }
    }
}
