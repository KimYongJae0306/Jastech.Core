using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.Controls
{
    public partial class DataGraphControl : UserControl
    {
        #region 필드
        private RectangleF _drawChartRect { get; set; }

        private float _axisXInterval = 120;//X축 offset

        private float _axisYInterval = 50;


        private float[] _data { get; set; } = null;
        #endregion 필드

        #region 속성
        public DoubleBufferedPanel pnlDrawChart = null;

        public int DefaultMaxAxisX { get; set; } = 100;

        public int MaxAxisY { get; set; } = 255;

        public int NumAxisX { get; set; } = 4;

        public int NumAxisY { get; set; } = 4;

        public Pen DataPen { get; set; } = new Pen(Color.Blue);

        public float AxisXMinValue { get; set; } = 0;

        public float AxisXMaxValue { get; set; } = 255;

        public float AxisYMinValue { get; set; } = 0;

        public float AxisYMaxValue { get; set; } = 255;

        private string AxisXCaption = "[Pixel]";

        private string AxisYCaption = "[Value]";
        #endregion

        #region 생성자
        public DataGraphControl()
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

            UpdateDataInfo();
            UpdateDrawInfo();
            DrawBaseLineX(e.Graphics);
            DrawBaseLineY(e.Graphics);
            e.Graphics.DrawRectangle(new Pen(Color.White), Rectangle.Round(_drawChartRect));

            DrawData(e.Graphics);
            DrawInfo(e.Graphics);
        }

        private void DrawInfo(Graphics g)
        {
            string maxString = string.Format("Max : {0}", Math.Round(AxisYMaxValue, 2));
            string minString = string.Format("Min : {0}", Math.Round(AxisYMinValue, 2));

            Font font = GetFontStyle(10, FontStyle.Bold);
            g.DrawString(maxString, font, Brushes.White, new PointF(_drawChartRect.Right + 10, _drawChartRect.Top));
            g.DrawString(minString, font, Brushes.White, new PointF(_drawChartRect.Right + 10, _drawChartRect.Top + 20));
        }

        private void UpdateDrawInfo()
        {
            float x = _axisXInterval;
            float y = _axisYInterval;
            float width = this.Width - (x * 2.0f);
            float height = this.Height - (y * 2.0f);
            _drawChartRect = new RectangleF(x, y, width, height);
        }

        private void UpdateDataInfo()
        {
            if (_data == null)
                return;
            if (_data.Count() > 0)
            {
                AxisXMinValue = 0;
                AxisXMaxValue = _data.Count();
                AxisYMinValue = _data.Min();
                AxisYMaxValue = _data.Max();
            }
        }

        private void DrawBaseLineX(Graphics g)
        {
            Rectangle roundRect = Rectangle.Round(_drawChartRect);
            float intervalX = _drawChartRect.Width / NumAxisX;
            float intervalValue = 0;

            if (_data == null)
                intervalValue = ((float)DefaultMaxAxisX / NumAxisX);
            else
                intervalValue = ((float)_data.Length / NumAxisX);

            Font font = GetFontStyle(10, FontStyle.Bold);
            
            PointF pointX = new PointF(roundRect.Right, roundRect.Bottom + 20);
            g.DrawString(AxisXCaption, font, Brushes.White, pointX);

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
            NumAxisY = (int)(Math.Log(AxisYMaxValue, 2) / Math.Sqrt(2));

            Rectangle roundRect = Rectangle.Round(_drawChartRect);
            float intervalY = (float)_drawChartRect.Height / NumAxisY;
            float intervalValue = (float)(Math.Abs(AxisYMinValue) + Math.Abs(AxisYMaxValue)) / NumAxisY;

            Font font = GetFontStyle(10, FontStyle.Bold);
            SizeF axisXStringSize = g.MeasureString(AxisYCaption, font);
            PointF pointX = new PointF(roundRect.Left - axisXStringSize.Width, roundRect.Top - axisXStringSize.Height - 10);
            g.DrawString(AxisYCaption, font, Brushes.White, pointX);

            float[] dashValues = { 5, 5 };
            Pen dashPen = new Pen(Color.White);
            dashPen.DashPattern = dashValues;

            float gridInterval = AxisYMinValue;
            for (int i = 0; i <= NumAxisY; i++)
            {
                int x1 = roundRect.Left;
                int x2 = roundRect.Right;
                int y = (int)(roundRect.Bottom - (intervalY * i));

                g.DrawLine(dashPen, new Point(x1, y), new Point(x2, y));

                string valueString = $"{gridInterval:F0}";
                SizeF textSize = g.MeasureString(valueString, font);
                g.DrawString(valueString, font, Brushes.White, new PointF(x1 - textSize.Width, y - textSize.Height / 2));
                gridInterval += intervalValue;
            }
        }

        private void DrawData(Graphics g)
        {
            if (_data == null)
                return;

            if (_data.Length <= 1)
                return;

            float intervalX = (float)_drawChartRect.Width / _data.Length;
            float intervalY = (float)_drawChartRect.Height / AxisYMaxValue;
            List<PointF> points = new List<PointF>();

            for (int i = 0; i < _data.Length; i++)
            {
                float x = _drawChartRect.Left + (intervalX * i);
                float y = _drawChartRect.Bottom - (intervalY * _data[i]);

                points.Add(new PointF(x, y));
            }
            g.DrawLines(DataPen, points.ToArray());
        }

        private Font GetFontStyle(int fontSize, FontStyle fontStyle)
        {
            Font font = new Font("맑은 고딕", fontSize, fontStyle);

            return font;
        }

        public void SetData(float[] data)
        {
            _data = data;
            pnlDrawChart.Refresh();
        }

        public void SetCaption(string captionAxisX, string captionAxisY)
        {
            AxisXCaption = $"[{captionAxisX}]";
            AxisYCaption = $"[{captionAxisY}]";
        }

        public void SetPenColor(Color color)
        {
            DataPen.Color = color;
        }

        private void PixelValueGraphControl_SizeChanged(object sender, EventArgs e)
        {
            pnlDrawChart?.Invalidate();
        }
        #endregion
    }
}
