using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.Controls
{
    public partial class DataGraphControl : UserControl
    {
        #region 필드
        private RectangleF _drawChartRect { get; set; }

        private float _axisXInterval = 50;//X축 offset

        private float _axisYInterval = 50;

        private Pen _dashPen = new Pen(Color.White) { DashPattern = new float[] { 5, 5 } };

        private float _rightMargin = 0;

        private object _lock = new object();

        private Dictionary<string, (int index, Color color, List<float> values)> _dataCollection { get; set; }
        #endregion 필드

        #region 속성
        private DoubleBufferedPanel pnlDrawChart = null;

        private float AxisXMaxValue { get; set; } = 1000;

        private float AxisYMinValue { get; set; } = 0;

        private float AxisYMaxValue { get; set; } = 0;

        private float AxisYChartMax { get; set; } = 100;

        private float AxisYAvgValue => (AxisYMaxValue + AxisYMinValue) / 2;

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
        private void DoubleBuffering_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            UpdateMargin(e.Graphics);
            UpdateDataInfo();
            UpdateDrawInfo();
            DrawLegends(e.Graphics);
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

            var offset = new Point(10, -20);
            g.DrawString(maxString, Font, Brushes.White, new PointF(_drawChartRect.Right + offset.X, _drawChartRect.Bottom + (offset.Y * 2)));
            g.DrawString(minString, Font, Brushes.White, new PointF(_drawChartRect.Right + offset.X, _drawChartRect.Bottom + offset.Y));
        }

        private void UpdateDrawInfo()
        {
            float x = _axisXInterval;
            float y = _axisYInterval;

            float width = this.Width - x - _rightMargin;
            float height = this.Height - (y * 2.0f);
            _drawChartRect = new RectangleF(x, y, width, height);
        }

        private void UpdateDataInfo()
        {
            var counts = new List<int>();
            var yMaxValues = new List<float>();
            var yMinValues = new List<float>();
            lock(_lock)
            {
                foreach (var (_, _, values) in _dataCollection.Values)
                {
                    float[] copiedArray = values.ToArray();
                    if (copiedArray.Count() > 0)
                    {
                        counts.Add(copiedArray.Count());
                        yMinValues.Add(copiedArray.Min());
                        yMaxValues.Add(copiedArray.Max());
                    }
                }
            }

            if (counts.Count > 0)
                AxisXMaxValue = counts.Max();
            if (yMinValues.Count > 0)
                AxisYMinValue = yMinValues.Min();
            if (yMaxValues.Count > 0)
                AxisYMaxValue = yMaxValues.Max();
            AxisYChartMax = AxisYMinValue + AxisYMaxValue;
        }

        private void UpdateMargin(Graphics g)
        {
            var longestID = _dataCollection.Keys.OrderByDescending(id => id.Length).First();
            var captionStringSize = g.MeasureString(AxisYCaption, Font);
            _rightMargin = Math.Max(_rightMargin, g.MeasureString($"■ {longestID.ToUpper()}", Font).Width);
            _rightMargin = Math.Max(_rightMargin, captionStringSize.Width);
        }

        private void DrawLegends(Graphics g)
        {
            var dataOffset = new Point(10, 20);
            var stringOffset = 3;
            var ellipseOffset = 10;
            foreach (var data in _dataCollection)
            {
                var (index, color, _) = data.Value;
                var legendBrush = new SolidBrush(color);
                var ellipseArea = new RectangleF(_drawChartRect.Right + dataOffset.X, _drawChartRect.Top + (index * dataOffset.Y) + ellipseOffset, 5, 5);
                var stringLocation = new PointF(_drawChartRect.Right + dataOffset.X * 2, _drawChartRect.Top + (index * dataOffset.Y) + stringOffset);
                g.FillRectangle(legendBrush, ellipseArea);
                g.DrawString(data.Key, Font, legendBrush, stringLocation);
            }
        }

        private void DrawBaseLineX(Graphics g)
        {
            Rectangle roundRect = Rectangle.Round(_drawChartRect);

            Font font = GetFontStyle(10, FontStyle.Bold);
            PointF captionLocation = new PointF(roundRect.Right, roundRect.Bottom + 20);
            g.DrawString(AxisXCaption, font, Brushes.White, captionLocation);

            float gridCount = 5;
            float gridMargin = _drawChartRect.Width / gridCount;
            float intervalValue = (float)AxisXMaxValue / gridCount;
            for (int i = 0; i <= gridCount; i++)
            {
                int x = (int)(roundRect.Left + (gridMargin * i));
                int y1 = roundRect.Top;
                int y2 = roundRect.Bottom;

                g.DrawLine(_dashPen, new Point(x, y1), new Point(x, y2));

                string valueString = $"{intervalValue * i:F0}";
                var textSize = g.MeasureString(valueString, font);
                var textLocation = new PointF(x - textSize.Width / 2, y2);
                g.DrawString(valueString, font, Brushes.White, textLocation);
            }
        }

        private void DrawBaseLineY(Graphics g)
        {
            Rectangle roundRect = Rectangle.Round(_drawChartRect);
            Font font = GetFontStyle(10, FontStyle.Bold);
            var captionStringSize = g.MeasureString(AxisYCaption, font);
            var captionLocation = new PointF(roundRect.Left - captionStringSize.Width, roundRect.Top - captionStringSize.Height - 10);
            g.DrawString(AxisYCaption, font, Brushes.White, captionLocation);

            float gridCount = (int)(Math.Log(AxisYChartMax, 2) / Math.Sqrt(2));
            float gridMargin = (float)_drawChartRect.Height / gridCount;
            float intervalValue = (float)Math.Abs(AxisYChartMax) / gridCount;
            for (int i = 0; i <= gridCount; i++)
            {
                int x1 = roundRect.Left;
                int x2 = roundRect.Right;
                int y = (int)(roundRect.Bottom - (gridMargin * i));

                g.DrawLine(_dashPen, new Point(x1, y), new Point(x2, y));

                string valueString = $"{intervalValue * i:F0}";
                var textSize = g.MeasureString(valueString, font);
                var textLocation = new PointF(x1 - textSize.Width, y - textSize.Height / 2);
                g.DrawString(valueString, font, Brushes.White, textLocation);
            }
        }

        private void DrawData(Graphics g)
        {
            foreach(var data in _dataCollection)
            {
                var (_, color, values) = data.Value;
                List<float> copiedList = new List<float>(values);

                if (copiedList.Count <= 1)
                    continue;

                float marginX = (float)_drawChartRect.Width / copiedList.Count;
                float marginY = (float)_drawChartRect.Height / AxisYChartMax;
                List<PointF> points = new List<PointF>();

                if (marginX < 1)
                {
                    int chunkSize = (int)Math.Ceiling(copiedList.Count / _drawChartRect.Width);
                    for (int startPosition = 0; startPosition < copiedList.Count; startPosition += chunkSize)
                    {
                        var dataChunk = copiedList.Skip(startPosition).Take(chunkSize).ToList();
                        var dataAvg = dataChunk.Average();
                        var dataMax = dataChunk.Max();
                        var dataMin = dataChunk.Min();
                        var higher = Math.Abs(dataMax - dataAvg);
                        var lower = Math.Abs(dataAvg - dataMin);

                        if (higher > lower)
                            points.Add(new PointF
                            {
                                X = _drawChartRect.Left + (marginX * startPosition),
                                Y = _drawChartRect.Bottom - (marginY * dataMax),
                            });
                        else if (higher < lower)
                            points.Add(new PointF
                            {
                                X = _drawChartRect.Left + (marginX * startPosition),
                                Y = _drawChartRect.Bottom - (marginY * dataMin),
                            });
                        else
                            points.Add(new PointF
                            {
                                X = _drawChartRect.Left + (marginX * startPosition),
                                Y = _drawChartRect.Bottom - (marginY * dataAvg),
                            });
                    }
                }
                else
                {
                    points = copiedList.Select((value, index) => new PointF
                    {
                        X = _drawChartRect.Left + (marginX * index),
                        Y = _drawChartRect.Bottom - (marginY * value),
                    }).ToList();
                }

                g.DrawLines(new Pen(color), points.ToArray());
            }
        }

        private Font GetFontStyle(int fontSize, FontStyle fontStyle)
        {
            Font font = new Font("맑은 고딕", fontSize, fontStyle);

            return font;
        }

        public void Initialize()
        {
            pnlDrawChart = new DoubleBufferedPanel();
            pnlChart.Controls.Add(pnlDrawChart);
            pnlDrawChart.Dock = DockStyle.Fill;
            pnlDrawChart.Paint += DoubleBuffering_Paint;
            _dataCollection = new Dictionary<string, (int index, Color color, List<float> values)>();

            AxisXMaxValue = 1000;
            AxisYMinValue = 0;
            AxisYMaxValue = 0;
            AxisYChartMax = 100;
            _rightMargin = 0;
        }

        public void AddLegend(string name, int index, Color color)
        {
            _dataCollection[name] = (index, color, new List<float>());
        }

        public void AddData(string name, float data, bool requirInvalidate = false)
        {
            _dataCollection[name].values.Add(data);
            if (requirInvalidate)
                pnlDrawChart?.Invalidate();
        }

        public void AddData(int index, float data, bool requirInvalidate = false)
        {
            _dataCollection.ElementAt(index).Value.values.Add(data);
            if (requirInvalidate)
                pnlDrawChart?.Invalidate();
        }

        public void Clear(bool dataOnly = true)
        {
            if (dataOnly == false)
                _dataCollection.Clear();
            else
            {
                foreach (var (_, _, values) in _dataCollection.Values)
                    values.Clear();
            }
        }

        public void SetCaption(string captionAxisX, string captionAxisY)
        {
            AxisXCaption = $"[{captionAxisX}]";
            AxisYCaption = $"[{captionAxisY}]";
        }

        private void PixelValueGraphControl_SizeChanged(object sender, EventArgs e)
        {
            pnlDrawChart?.Invalidate();
        }
        #endregion
    }
}
