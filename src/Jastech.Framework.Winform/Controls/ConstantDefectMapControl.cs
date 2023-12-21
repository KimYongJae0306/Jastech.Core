using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Jastech.Framework.Winform.Controls
{
    public partial class ConstantDefectMapControl : UserControl
    {

        #region 필드
        private RectangleF DisplayArea;
        #endregion

        #region 속성
        public readonly List<DefectPointControl> _defectPoints = new List<DefectPointControl>();

        public float LastPosition
        {
            get
            {
                if (_defectPoints.Count > 0)
                    return (float)_defectPoints.Max(df => df.Coord.Y);
                else
                    return 0;
            }
        }

        public double PixelResolution_um = 0.35;
        #endregion

        #region 이벤트
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
            DisplayArea = new RectangleF(new PointF(pnlMapArea.Left + 40, pnlMapArea.Top + 20), new SizeF(pnlMapArea.Width - 60, pnlMapArea.Height - 60));
        }

        //public void AddDefect(defectInfo defectInfo)
        //{
        //    //x , y , color, defectType, 
        //    // core -> defectInfo=> x, y, Color
        //    // app.core = appdefectinfo : defectinfo
        //    {
        //        // app.core, Defectype, 
        //    }

        //    // app.core 
        //    // defectInfo 2 
        //}

        public void Clear()
        {
            _defectPoints.Clear();
            pnlMapArea.Controls.Clear();
            Invalidate();
        }

        public void AddCoordinates(DefectPointControl[] defectPoints, float ws)
        {

            int pnlHeight = pnlMapArea.Height;


            pnlMapArea.SuspendLayout();

            for (int i = 0; i < defectPoints.Length; i++)
                defectPoints[i].Location = GetScaledLocation(defectPoints[i].Coord, pnlMapArea.Width, pnlMapArea.AutoScrollPosition.Y);
            //_defectPoints.AddRange(defectPoints);

            pnlMapArea.Controls.AddRange(defectPoints);
            pnlMapArea.VerticalScroll.Value = pnlMapArea.VerticalScroll.Maximum;
            pnlMapArea.ResumeLayout(true);
        }

        Pen testpen = new Pen(Color.White) { DashStyle = DashStyle.Dash, Width = 0.3f };
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.TranslateTransform(pnlMapArea.AutoScrollPosition.X, pnlMapArea.AutoScrollPosition.Y);
            for (int height = 0; height < pnlMapArea.DisplayRectangle.Height; height += 100)
            {
                int drawingHeight = height + (int)DisplayArea.Top;
                e.Graphics.DrawLine(testpen, new Point((int)DisplayArea.Left, drawingHeight), new Point((int)DisplayArea.Left + (int)DisplayArea.Width, drawingHeight));
                e.Graphics.DrawString($"{height}", Font, Brushes.White, new PointF(0, drawingHeight - Font.Size / 2));
            }

            var dispRect = new Rectangle((int)DisplayArea.Left, (int)DisplayArea.Top, (int)DisplayArea.Width, pnlMapArea.DisplayRectangle.Height);
            e.Graphics.DrawRectangle(Pens.White, dispRect);
        }

        private Point GetScaledLocation(PointF coordinates, float ImageMaxWidth /*추후 모델에서 가져올 것*/, int autoScrollY) => new Point
        {
            X = Convert.ToInt32(DisplayArea.Left + coordinates.X * ((DisplayArea.Width - 9f) / ImageMaxWidth) + 1f),
            Y = Convert.ToInt32(DisplayArea.Top + coordinates.Y + autoScrollY),
        };
        #endregion

        private void pnlMapArea_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(pnlMapArea.AutoScrollPosition.X, pnlMapArea.AutoScrollPosition.Y);
            for (int height = 0; height < pnlMapArea.DisplayRectangle.Height; height += 100)
            {
                int drawingHeight = height + (int)DisplayArea.Top;
                e.Graphics.DrawLine(testpen, new Point((int)DisplayArea.Left, drawingHeight), new Point((int)DisplayArea.Left + (int)DisplayArea.Width, drawingHeight));
                e.Graphics.DrawString($"{height}", Font, Brushes.White, new PointF(0, drawingHeight - Font.Size / 2));
            }

            var dispRect = new Rectangle((int)DisplayArea.Left, (int)DisplayArea.Top, (int)DisplayArea.Width, pnlMapArea.DisplayRectangle.Height);
            e.Graphics.DrawRectangle(Pens.White, dispRect);
            pnlMapArea.ResumeLayout(true);
        }
    }
}
