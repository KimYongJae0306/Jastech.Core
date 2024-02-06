using Jastech.Framework.Structure.Defect;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using static Jastech.Framework.Structure.Defect.DefectDefine;

namespace Jastech.Framework.Winform.Controls
{
    public partial class ConstantDefectMapControl : UserControl
    {
        #region 필드
        private RectangleF DisplayArea;
        #endregion

        #region 속성
        public readonly List<ElectrodeDefectInfo> _defectInfos = new List<ElectrodeDefectInfo>();

        public double PixelResolution_um = 43;
        #endregion

        #region 이벤트
        public SelectedDefectChangedHandler SelectedControlChanged;
        #endregion    

        #region 대리자
        public delegate void SelectedDefectChangedHandler(int index);
        #endregion

        #region 생성자
        public ConstantDefectMapControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void ConstantDefectMapControl_Load(object sender, EventArgs e)
        {
            DisplayArea = GetDisplayArea();
            pnlMapArea.MouseWheel += PnlMapArea_MouseWheel;
        }

        private void PnlMapArea_MouseWheel(object sender, MouseEventArgs e)
        {
            Invalidate();
        }

        public void Clear()
        {
            _defectInfos.Clear();
            pnlMapArea.Controls.Clear();
            Invalidate();
        }

        public void AddCoordinates(ElectrodeDefectInfo[] defectInfos)
        {
            pnlMapArea.SuspendLayout();
            _defectInfos.AddRange(defectInfos);     //test code
            var location = new Point(0, (int)defectInfos.Last().GetFeatureValue(FeatureTypes.Y) - 1);
            pnlMapArea.Controls.Add(new Control { Location = location });
        }

        private RectangleF GetDisplayArea() => new RectangleF(new PointF(pnlMapArea.Left + 40, pnlMapArea.Top + 20), new SizeF(pnlMapArea.DisplayRectangle.Width - 60, pnlMapArea.DisplayRectangle.Height - 70));

        private Point GetScaledLocation(PointF coordinates, float ImageMaxWidth /*추후 모델에서 가져올 것*/) => new Point
        {
            X = Convert.ToInt32(DisplayArea.Left + coordinates.X * ((DisplayArea.Width - 9f) / ImageMaxWidth) + 1f),
            Y = Convert.ToInt32(DisplayArea.Top + coordinates.Y + pnlMapArea.AutoScrollPosition.Y),
        };

        private void DrawDefectShape(Graphics g, ElectrodeDefectInfo defectInfo)
        {
            var width = defectInfo.GetFeatureValue(FeatureTypes.Width);
            var height = defectInfo.GetFeatureValue(FeatureTypes.Height);
            var X = defectInfo.GetFeatureValue(FeatureTypes.X);
            var Y = defectInfo.GetFeatureValue(FeatureTypes.Y);
            var coord = GetScaledLocation(new PointF(X, Y), 160000);

            if (width < 10 && height < 10)
            {
                var brush = new SolidBrush(Color.Red);
                var sizeLength = Math.Max(width, height);
                var area = new RectangleF(coord.X + width / 2, coord.Y + height / 2, sizeLength, sizeLength);
                g.FillEllipse(brush, area);
            }
            else if ((width < 10 || height < 10) && (Math.Max(width, height) / Math.Min(width, height) > 20))
            {
                var pen = new Pen(Color.Red, 3);
                if (width > height)
                    g.DrawLine(pen, new Point(coord.X, coord.Y), new Point(width, coord.Y));
                else
                    g.DrawLine(pen, new Point(coord.X, coord.Y), new Point(coord.X, height));
            }
            else
            {
                var pen = new Pen(Color.Red);
                var area = new RectangleF(coord.X, coord.Y, width - 1, height - 1);
                g.DrawRectangles(pen, new RectangleF[] { area });
            }
        }

        private void pnlMapArea_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(pnlMapArea.AutoScrollPosition.X, pnlMapArea.AutoScrollPosition.Y);

            foreach (var defectInfo in _defectInfos)
                DrawDefectShape(e.Graphics, defectInfo);
            
            // Drawing Grid and Length
            double maximumHeight = pnlMapArea.DisplayRectangle.Height - DisplayArea.Top;
            maximumHeight = Math.Ceiling(maximumHeight / 100) * 100;
            for (int height = 0; height <= maximumHeight; height += 100)
            {
                int drawingHeight = height + (int)DisplayArea.Top;
                var dashPen = new Pen(Color.White) { DashStyle = DashStyle.Dash, Width = 0.3f };
                e.Graphics.DrawLine(dashPen, new Point((int)DisplayArea.Left, drawingHeight), new Point((int)DisplayArea.Left + (int)DisplayArea.Width, drawingHeight));
                e.Graphics.DrawString($"{height}", Font, Brushes.White, new PointF(0, drawingHeight - Font.Size / 2));
            }

            var dispRect = new Rectangle((int)DisplayArea.Left, (int)DisplayArea.Top, (int)DisplayArea.Width, pnlMapArea.DisplayRectangle.Height);
            e.Graphics.DrawRectangle(Pens.White, dispRect);
            pnlMapArea.ResumeLayout(true);
        }

        private void OnSelectedDefectChanged(int selectedIndex)
        {
            SelectedControlChanged?.Invoke(selectedIndex);

            foreach(var control in pnlMapArea.Controls)
            {
                if (control is DefectShapeControl defectPointControl)
                    defectPointControl.IsSelected = defectPointControl.Index == selectedIndex;
            }
        }
        #endregion
    }
}