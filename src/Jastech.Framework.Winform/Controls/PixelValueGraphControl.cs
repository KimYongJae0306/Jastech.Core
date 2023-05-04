using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.Controls
{
    public partial class PixelValueGraphControl : UserControl
    {
        public DoubleBufferPanel pnlDrawChart = null;

        public int DefaultMaxAxisX { get; set; } = 100;

        public int MaxAxisY { get; set; } = 255;

        public int NumAxisX { get; set; } = 4;

        public int NumAxisY { get; set; } = 4;

        private RectangleF _drawChartRect { get; set; }

        private float _axisXInterval = 120;//X축 offset

        private float _axisYInterval = 50;

        public Pen GridPen { get; set; } = new Pen(Color.White);

        public byte[] Data { get; set; } = null;

        public PixelValueGraphControl()
        {
            InitializeComponent();
        }

        private void PixelValueGraphControl_Load(object sender, EventArgs e)
        {
            pnlDrawChart = new DoubleBufferPanel();
            pnlChart.Controls.Add(pnlDrawChart);
            pnlDrawChart.Dock = DockStyle.Fill;
            pnlDrawChart.Paint += DoubleBuffering_Paint;
        }
        private void DoubleBuffering_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);

            UpdateDrawInfo();
            DrawBaseLineX(e.Graphics);
            DrawBaseLineY(e.Graphics);
            e.Graphics.DrawRectangle(new Pen(Color.White), Rectangle.Round(_drawChartRect));

            DrawData(e.Graphics);
        }

        private void UpdateDrawInfo()
        {
            float x = _axisXInterval;
            float y = _axisYInterval;
            float width = this.Width - (x * 2.0f);
            float height = this.Height - (y * 2.0f);
            _drawChartRect = new RectangleF(x, y, width, height);
        }

        private void DrawBaseLineX(Graphics g)
        {
            Rectangle roundRect = Rectangle.Round(_drawChartRect);
            float intervalX = _drawChartRect.Width / NumAxisX;

            float intervalValue = 0;

            if(Data == null)
                intervalValue = ((float)DefaultMaxAxisX / NumAxisX);
            else
                intervalValue = ((float)Data.Length / NumAxisX);

            Font font = GetFontStyle(10, FontStyle.Bold);
            string axisXString = "[Pixel]";
            PointF pointX = new PointF(roundRect.Right, roundRect.Bottom + 20);
            g.DrawString(axisXString, font, Brushes.White, pointX);

            float[] dashValues = { 5, 5 };
            Pen dashPen = new Pen(Color.White);
            dashPen.DashPattern = dashValues;

            for (int i = 0; i <= NumAxisX; i++)
            {
                int x = (int)(roundRect.Left + (intervalX * i));
                int y1 = roundRect.Top;
                int y2 = roundRect.Bottom;

                g.DrawLine(dashPen, new Point(x, y1), new Point(x, y2));

                int value = (int)(intervalValue * i);
                string valueString = value.ToString();
                SizeF textSize = g.MeasureString(valueString, font);
                g.DrawString(value.ToString(), font, Brushes.White, new PointF(x - textSize.Width /2, y2));
            }
        }

        private void DrawBaseLineY(Graphics g)
        {
            Rectangle roundRect = Rectangle.Round(_drawChartRect);
            float intervalY = _drawChartRect.Height / NumAxisY;
            float intervalValue = ((float)MaxAxisY / NumAxisY);

            Font font = GetFontStyle(10, FontStyle.Bold);
            string axisXString = "[Value]";
            SizeF axisXStringSize = g.MeasureString(axisXString, font);
            PointF pointX = new PointF(roundRect.Left - axisXStringSize.Width, roundRect.Top - axisXStringSize.Height - 10);
            g.DrawString(axisXString, font, Brushes.White, pointX);

            float[] dashValues = { 5, 5 };
            Pen dashPen = new Pen(Color.White);
            dashPen.DashPattern = dashValues;

            for (int i = 0; i <= NumAxisY; i++)
            {
                int x1 = roundRect.Left;
                int x2 = roundRect.Right;
                int y = (int)(roundRect.Bottom - (intervalY * i));

                g.DrawLine(dashPen, new Point(x1, y), new Point(x2, y));

                int value = (int)(intervalValue * i);
                string valueString = value.ToString();
                SizeF textSize = g.MeasureString(valueString, font);
                g.DrawString(value.ToString(), font, Brushes.White, new PointF(x1 - textSize.Width, y - textSize.Height / 2));
            }
        }

        private void DrawData(Graphics g)
        {
            if (Data == null)
                return;

            if (Data.Length <= 1)
                return;

            float intervalX = ((float)_drawChartRect.Width / Data.Length);
            float intervalY = ((float)_drawChartRect.Height / MaxAxisY);
            List<PointF> points = new List<PointF>();

            for (int i = 0; i < Data.Length; i++)
            {
                float x = _drawChartRect.Left + (intervalX * i);
                float y = _drawChartRect.Bottom - (intervalY * Data[i]);

                points.Add(new PointF(x, y));
            }
            Pen pen = new Pen(Color.Blue);
            g.DrawLines(pen, points.ToArray());
        }

        private Font GetFontStyle(int fontSize, FontStyle fontStyle)
        {
            Font font = new Font("맑은 고딕", fontSize, fontStyle);

            return font;
        }

        public void SetData(byte[] data)
        {
            Data = data;
            pnlDrawChart.Refresh();
        }

        private void PixelValueGraphControl_SizeChanged(object sender, EventArgs e)
        {
            pnlDrawChart?.Invalidate();
        }
    }
}
