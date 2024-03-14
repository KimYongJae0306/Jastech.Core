using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.Controls
{
    public partial class PixelValueGraphControl : UserControl
    {
        #region 속성
        public DoubleBufferedPanel pnlDrawChart = null;

        public int DefaultMaxAxisX { get; set; } = 100;

        public int MinAxisY { get; set; } = 0;

        public int MaxAxisY { get; set; } = 255;

        public int NumAxisX { get; set; } = 4;

        public int NumAxisY { get; set; } = 4;

        private RectangleF _drawChartRect { get; set; }

        private float _axisXInterval = 120;//X축 offset

        private float _axisYInterval = 50;

        public Pen GridPen { get; set; } = new Pen(Color.White);

        public Pen DataPen { get; set; } = new Pen(Color.Blue);

        public int[] Data { get; set; } = null;
        #endregion

        #region 생성자
        public PixelValueGraphControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void PixelValueGraphControl_Load(object sender, EventArgs e)
        {
            pnlDrawChart = new DoubleBufferedPanel();
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
            DrawInfo(e.Graphics);
        }

        private void DrawInfo(Graphics g)
        {
            if (Data == null)
                return;
            if (Data.Count() > 0)
            {
                double maxValue = Data.Max();
                double minValue = Data.Min();

                string maxString = string.Format("Max Value : {0}", maxValue);
                string minString = string.Format("Min Value : {0}", minValue);

                Font font = GetFontStyle(10, FontStyle.Bold);
                g.DrawString(maxString, font, Brushes.White, new PointF(_drawChartRect.Right + 10, _drawChartRect.Top));
                g.DrawString(minString, font, Brushes.White, new PointF(_drawChartRect.Right + 10, _drawChartRect.Top + 20));
            }
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

            if (Data == null)
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
                g.DrawString(value.ToString(), font, Brushes.White, new PointF(x - textSize.Width / 2, y2));
            }
        }

        private void DrawBaseLineY(Graphics g)
        {
            Rectangle roundRect = Rectangle.Round(_drawChartRect);
            float intervalY = _drawChartRect.Height / NumAxisY;
            int[] valueRange = MinAxisY >= 0 ?
                Enumerable.Range(0, NumAxisY + 1).Select(value => value * byte.MaxValue / NumAxisY).ToArray() :
                Enumerable.Range(-NumAxisY / 2, NumAxisY + 1).Select(value => value * byte.MaxValue / NumAxisY).ToArray();

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

                int value = valueRange[i];
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
            float offsetY = 0;
            if ( MinAxisY < 0)
            {
                intervalY /= 2;
                offsetY = (float)_drawChartRect.Height / 2;
            }
            List<PointF> points = new List<PointF>();

            for (int i = 0; i < Data.Length; i++)
            {
                float x = _drawChartRect.Left + (intervalX * i);
                float y = _drawChartRect.Bottom - (intervalY * Data[i]) - offsetY;

                points.Add(new PointF(x, y));
            }
            g.DrawLines(DataPen, points.ToArray());
        }

        private Font GetFontStyle(int fontSize, FontStyle fontStyle)
        {
            Font font = new Font("맑은 고딕", fontSize, fontStyle);

            return font;
        }

        public void SetData(byte[] data)
        {
            MinAxisY = byte.MinValue;
            MaxAxisY = byte.MaxValue;
            Data = data.Select(value => (int)value).ToArray();
            pnlDrawChart.Refresh();
        }

        public void SetData(sbyte[] data)
        {
            MinAxisY = sbyte.MinValue;
            MaxAxisY = sbyte.MaxValue;
            Data = data.Select(value => (int)value).ToArray();
            pnlDrawChart.Refresh();
        }

        private void PixelValueGraphControl_SizeChanged(object sender, EventArgs e)
        {
            pnlDrawChart?.Invalidate();
        }
        #endregion
    }
}
