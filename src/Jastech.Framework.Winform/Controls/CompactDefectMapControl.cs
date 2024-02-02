using Jastech.Framework.Structure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using static Jastech.Framework.Structure.DefectDefine;

namespace Jastech.Framework.Winform.Controls
{
    public partial class CompactDefectMapControl : UserControl
    {
        #region 필드
        private RectangleF DisplayArea;
        #endregion

        #region 속성
        private float maximumY { get; set; } = 50;

        public readonly List<DefectInfo> _defectInfos = new List<DefectInfo>();

        public double PixelResolution = 20;
        #endregion

        #region 이벤트
        public SelectedDefectChangedHandler SelectedDefectChanged;
        #endregion

        #region 대리자
        public delegate void SelectedDefectChangedHandler(int index);
        #endregion

        #region 생성자
        public CompactDefectMapControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void CompactDefectMapControl_Load(object sender, EventArgs e)
        {
            DisplayArea = GetDisplayArea();
        }

        public void Clear()
        {
            _defectInfos.Clear();
            pnlMapArea.CreateGraphics().Clear(Color.FromArgb(52, 52, 52));
            Invalidate();
        }

        private RectangleF GetDisplayArea() => new RectangleF(new PointF(pnlMapArea.Left + 80, pnlMapArea.Top + 20), new SizeF(pnlMapArea.DisplayRectangle.Width - 100, pnlMapArea.DisplayRectangle.Height - 60));

        private void DrawDefectShape(Graphics g, DefectInfo defectInfo)
        {
            var width = defectInfo.GetFeatureValue(FeatureTypes.Width);
            var height = defectInfo.GetFeatureValue(FeatureTypes.Height);
            var X = defectInfo.GetFeatureValue(FeatureTypes.X);
            var Y = defectInfo.GetFeatureValue(FeatureTypes.Y);
            var coord = GetScaledLocation(new PointF(X, Y), 160000);

            var brush = new SolidBrush(Color.Red);
            var area = new RectangleF(coord.X, coord.Y, 1.5f, 1.5f);
            g.FillEllipse(brush, area);

            //if (width < 10 && height < 10)
            //{
            //    var brush = new SolidBrush(Color.Red);
            //    var sizeLength = Math.Max(width, height) - 1;
            //    var area = new RectangleF(coord.X, coord.Y, sizeLength, sizeLength);
            //    g.FillEllipse(brush, area);
            //}
            //else if ((width < 10 || height < 10) && (Math.Max(width, height) / Math.Min(width, height) > 20))
            //{
            //    var pen = new Pen(Color.Red, 3);
            //    pen.MiterLimit = 100;
            //    if (width > height)
            //        g.DrawLine(pen, new Point(coord.X, coord.Y), new Point(width, coord.Y));
            //    else
            //        g.DrawLine(pen, new Point(coord.X, coord.Y), new Point(coord.X, height));
            //}
            //else
            //{
            //    var pen = new Pen(Color.Red, 1.3f);
            //    var area = new Rectangle(coord.X, coord.Y, width - 1, height - 1);
            //    g.DrawRectangle(pen, area);
            //}
        }

        public void AddCoordinates(DefectInfo[] defectInfos)
        {
            pnlMapArea.SuspendLayout();

            _defectInfos.AddRange(defectInfos);     //test code
            foreach (DefectInfo defectInfo in defectInfos)
            {
                var defectCoord = defectInfo.GetCoord();
                var defectSize = defectInfo.GetSize();
                if (defectCoord.Y + defectSize.Height > maximumY)
                    maximumY = defectCoord.Y + defectSize.Height;
            }
        }

        private PointF GetScaledLocation(PointF coordinates, float ImageMaxWidth /*추후 모델에서 가져올 것*/) => new PointF
        {
            X = Convert.ToSingle(DisplayArea.Left + coordinates.X * ((DisplayArea.Width - 9f) / ImageMaxWidth) + 1f),
            Y = Convert.ToSingle(DisplayArea.Top + DisplayArea.Height - (coordinates.Y * DisplayArea.Height / maximumY)),
        };

        private Size GetScaledSize(Size size, float ImageMaxWidth /*추후 모델에서 가져올 것*/) => new Size
        {
            Width = Convert.ToInt32(size.Width * ((DisplayArea.Width - 9f) / ImageMaxWidth) + 1f),
            Height = Convert.ToInt32(size.Height * (DisplayArea.Height / maximumY)),
        };
        
        private void pnlMapArea_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.Clear(Color.FromArgb(52, 52, 52));
            e.Graphics.TranslateTransform(pnlMapArea.AutoScrollPosition.X, pnlMapArea.AutoScrollPosition.Y);
            DisplayArea = GetDisplayArea();

            foreach (var defectInfo in _defectInfos)
                DrawDefectShape(e.Graphics, defectInfo);

            // Drawing Grid and Length
            double maximumHeight = maximumY / 1000;;
            double gridMargin = maximumHeight / 10;
            for (int count = 0; count <= 10; count++)
            {
                int drawingHeight = (int)(count * (DisplayArea.Height / 10)) + (int)DisplayArea.Top;
                var dashPen = new Pen(Color.White) { DashStyle = DashStyle.Dash, Width = 0.3f };
                e.Graphics.DrawLine(dashPen, new Point((int)DisplayArea.Left, drawingHeight), new Point((int)DisplayArea.Left + (int)DisplayArea.Width, drawingHeight));
                e.Graphics.DrawString($"{(maximumHeight - (count * gridMargin)) * PixelResolution:N3}mm", Font, Brushes.White, new PointF(0, drawingHeight - Font.Size / 2));
            }

            var dispRect = new Rectangle((int)DisplayArea.Left, (int)DisplayArea.Top, (int)DisplayArea.Width, (int)DisplayArea.Height);
            e.Graphics.DrawRectangle(Pens.White, dispRect);

            if (_defectInfos.Count > 0)
            {
                var lastDfsCoord = _defectInfos.Last().GetCoord();
                e.Graphics.DrawString($"{lastDfsCoord.X}, {lastDfsCoord.Y}", Font, Brushes.Red, GetScaledLocation(lastDfsCoord, 160000));
            }

            pnlMapArea.ResumeLayout(true);
        }

        private void OnSelectedDefectChanged(int selectedIndex)
        {
            SelectedDefectChanged?.Invoke(selectedIndex);

            foreach (var control in pnlMapArea.Controls)
            {
                if (control is DefectShapeControl defectPointControl)
                    defectPointControl.IsSelected = defectPointControl.Index == selectedIndex;
            }
        }
        #endregion

        private void pnlMapArea_MouseClick(object sender, MouseEventArgs e)
        {
        }
    }
}
