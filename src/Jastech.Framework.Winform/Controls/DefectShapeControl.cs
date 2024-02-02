using System;
using System.Drawing;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.Controls
{
    public partial class DefectShapeControl : UserControl
    {
        #region 속성
        public int Index { get; set; }
        public PointF Coord { get; set; }
        public Color SelectedColor { get; set; } = Color.Transparent;
        public Color DisplayColor { get; set; } = Color.Transparent;

        private bool _selected = false;
        public bool IsSelected
        {
            get => _selected;
            set
            {
                _selected = value;
                Invalidate();
            }
        }
        #endregion

        #region 이벤트
        public event SelectedIndexChangedHandler SelectedIndexChanged;
        #endregion

        #region 델리게이트
        public delegate void SelectedIndexChangedHandler(int index);
        #endregion

        #region 생성자
        public DefectShapeControl()
        {
            InitializeComponent();
            base.CreateParams.ExStyle |= 0x20;
            SetStyle(ControlStyles.UserPaint, true);
            //SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
        }
        #endregion

        #region 메서드

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (Width < 10 && Height < 10)
            {
                var brush = new SolidBrush(IsSelected ? SelectedColor : DisplayColor);
                var area = new RectangleF(0.5f, 0.5f, Width - 1, Height - 1);
                e.Graphics.FillEllipse(brush, area);
            }
            else if ((Width < 10 || Height < 10) && (Math.Max(Width, Height) / Math.Min(Width, Height) > 20))
            {
                var pen = new Pen(IsSelected ? SelectedColor : DisplayColor, 3);
                if (Width > Height)
                    e.Graphics.DrawLine(pen, new Point(Location.X, Location.Y), new Point(Width, Location.Y));
                else
                    e.Graphics.DrawLine(pen, new Point(Location.X, Location.Y), new Point(Location.X, Height));
            }
            else
            {
                var pen = new Pen(IsSelected ? SelectedColor : DisplayColor);
                var area = new Rectangle(0, 0, Width - 1, Height - 1);
                e.Graphics.DrawRectangle(pen, area);
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Width = Width < 6 ? 6 : Width;
            Height = Height < 6 ? 6 : Height;
        }

        private void DefectPoint_Click(object sender, EventArgs e)
        {
            SelectedIndexChanged?.Invoke(Index);

            IsSelected = true;
            Invalidate();
        }
        #endregion
    }
}
