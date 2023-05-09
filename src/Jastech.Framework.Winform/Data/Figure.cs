using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.Data
{
    public abstract class Figure
    {
        public bool IsSelected { get; set; } = false;

        public PointF MouseDownPoint { get; set; } = new PointF();

        public PointF MouseMovePoint { get; set; } = new PointF();

        public PointF MouseUpPoint { get; set; } = new PointF();

        public FigureType FigureType { get; set; }

        public MouseType MouseType { get; set; } = MouseType.None;

        public TrackPosType CurrentTrackPos { get; set; } = TrackPosType.None;

        public int TrackRectSize { get; set; } = 6;

        public int FigureWidth { get; set; } = 2;

        public double Scale { get; set; } = 1.0;

        public List<RectangleF> TrackRectangleList = new List<RectangleF>();

        public virtual void MouseDown(PointF point)
        {
            MouseType = MouseType.Down;
            MouseDownPoint = point;
        }

        public virtual void MouseMove(PointF point)
        {
            MouseType = MouseType.Move;
            MouseMovePoint = point;
        }

        public virtual void MouseUp(PointF point)
        {
            MouseType = MouseType.Up;
            MouseUpPoint = point;
        }

        public virtual void SetScale(double scale)
        {
            Scale = scale;
        }
        public abstract void Draw(Graphics g);

        public abstract void CheckPointInFigure(PointF point);

        public abstract TrackPosType CheckTrackPos(PointF pt);

        public abstract Cursor GetCursors(PointF point);
    }

    public enum FigureType
    {
        ArrowLine,
        Rectangle,

    }

    public enum MouseType
    {
        None,
        Down,
        Move,
        Up,
    }

    public enum FigureMode
    {
        None,
        Edit,
    }

    public enum TrackPosType
    {
        None,
        InSide,
        Left,
        Right,
        Top,
        Bottom,
        LeftTop,
        LeftBottom,
        RightTop,
        RightBottom,

        Start,
        End,

    }
        
}
