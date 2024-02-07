﻿using System;
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

        private float _axisXInterval = 120;//X축 offset

        private float _axisYInterval = 50;

        private Pen _dashPen = new Pen(Color.White) { DashPattern = new float[] { 5, 5 } };

        private Dictionary<string, List<float>> _data { get; set; }
        private Dictionary<string, (int index, Color color)> _legends { get; set; }
        #endregion 필드

        #region 속성
        private DoubleBufferedPanel pnlDrawChart = null;

        private float AxisXMinValue { get; set; } = 0;

        private float AxisXMaxValue { get; set; } = 1;

        private float AxisYMinValue { get; set; } = 0;

        private float AxisYMaxValue { get; set; } = 1;

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
        private void DataGraphControl_Load(object sender, EventArgs e)
        {
        }

        private void DoubleBuffering_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);

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

            Font font = GetFontStyle(10, FontStyle.Bold);
            g.DrawString(maxString, font, Brushes.White, new PointF(_drawChartRect.Right + 10, _drawChartRect.Top));
            g.DrawString(minString, font, Brushes.White, new PointF(_drawChartRect.Right + 10, _drawChartRect.Top + 20));
        }

        private void UpdateDrawInfo()
        {
            float x = _axisXInterval;
            float y = _axisYInterval;
            float width = this.Width - (x * 1.8f);
            float height = this.Height - (y * 2.0f);
            _drawChartRect = new RectangleF(x, y, width, height);
        }

        private void UpdateDataInfo()
        {
            var counts = new List<int>();
            var yMaxValues = new List<float>();
            var yMinValues = new List<float>();
            foreach (var datas in _data.Values)
            {
                if (datas.Count() > 0)
                {
                    counts.Add(datas.Count());
                    yMinValues.Add(datas.Min());
                    yMaxValues.Add(datas.Max());
                }
            }
            AxisXMinValue = 0;
            if (counts.Count > 0) AxisXMaxValue = counts.Max();
            if (yMinValues.Count > 0) AxisYMinValue = yMinValues.Min();
            if (yMaxValues.Count > 0) AxisYMaxValue = yMaxValues.Max();
        }

        private void DrawLegends(Graphics g)
        {
            Rectangle roundRect = Rectangle.Round(_drawChartRect);
            Point legendCoord = new Point(roundRect.Right - (roundRect.Width / 15), roundRect.Y + 5);
            Size legendSize = new Size(roundRect.Width / 10, roundRect.Height / 3);
            Rectangle legendRect = new Rectangle(legendCoord, legendSize);

            foreach(var data in _data)
            {
                var legendName = data.Key;
                var legendProperty = _legends[legendName];
                var legendBrush = new SolidBrush(legendProperty.color);
                g.FillRectangle(legendBrush, legendRect.X + 5, legendRect.Y + (legendProperty.index * 15) + 5, 5, 5);
                g.DrawString(legendName, Font, legendBrush, legendRect.X + 20, legendRect.Y + (legendProperty.index * 15));
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
                SizeF textSize = g.MeasureString(valueString, font);
                g.DrawString(valueString, font, Brushes.White, new PointF(x - textSize.Width / 2, y2));
            }
        }

        private void DrawBaseLineY(Graphics g)
        {
            Rectangle roundRect = Rectangle.Round(_drawChartRect);
            Font font = GetFontStyle(10, FontStyle.Bold);
            SizeF captionStringSize = g.MeasureString(AxisYCaption, font);
            PointF captionLocation = new PointF(roundRect.Left - captionStringSize.Width, roundRect.Top - captionStringSize.Height - 10);
            g.DrawString(AxisYCaption, font, Brushes.White, captionLocation);

            float gridCount = (int)(Math.Log(AxisYMaxValue, 2) / Math.Sqrt(2));
            float gridMargin = (float)_drawChartRect.Height / gridCount;
            float intervalValue = (float)Math.Abs(AxisYMaxValue) / gridCount;
            for (int i = 0; i <= gridCount; i++)
            {
                int x1 = roundRect.Left;
                int x2 = roundRect.Right;
                int y = (int)(roundRect.Bottom - (gridMargin * i));

                g.DrawLine(_dashPen, new Point(x1, y), new Point(x2, y));

                string valueString = $"{intervalValue * i:F0}";
                SizeF textSize = g.MeasureString(valueString, font);
                g.DrawString(valueString, font, Brushes.White, new PointF(x1 - textSize.Width, y - textSize.Height / 2));
            }
        }

        private void DrawData(Graphics g)
        {
            foreach(var dataPair in _data)
            {
                var datas = dataPair.Value;

                if (datas.Count <= 1)
                    continue;

                float marginX = (float)_drawChartRect.Width / datas.Count;
                float marginY = (float)_drawChartRect.Height / AxisYMaxValue;
                List<PointF> points = new List<PointF>();

                if (marginX < 1)
                {
                    int chunkSize = (int)Math.Ceiling(datas.Count / _drawChartRect.Width);
                    for (int startPosition = 0; startPosition < datas.Count; startPosition += chunkSize)
                    {
                        var dataChunk = datas.Skip(startPosition).Take(chunkSize).ToList();
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
                    points = datas.Select((value, index) => new PointF
                    {
                        X = _drawChartRect.Left + (marginX * index),
                        Y = _drawChartRect.Bottom - (marginY * value),
                    }).ToList();
                }

                g.DrawLines(GetLegendPen(dataPair.Key), points.ToArray());
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
            _data = new Dictionary<string, List<float>>();
            _legends = new Dictionary<string, (int index, Color color)>();

            AxisXMinValue = 0;
            AxisXMaxValue = 1000;
            AxisYMinValue = 0;
            AxisYMaxValue = 100;
        }

        public void AddLegend(string legend, int index, Color color)
        {
            _data[legend] = new List<float>();
            _legends[legend] = (index, color);
        }

        public Pen GetLegendPen(string key)
        {
            if (_legends.ContainsKey(key))
                return new Pen(_legends[key].color);
            else
                return new Pen(Color.Black);
        }

        public void AddData(string legend, float data, bool requirInvalidate = false)
        {
            _data[legend].Add(data);
            if (requirInvalidate)
                pnlDrawChart?.Invalidate();
        }

        public void Clear(bool dataOnly = true)
        {
            if (dataOnly != false)
            {
                foreach (var valueList in _data.Values)
                    valueList.Clear();
            }
            else
            {
                _legends.Clear();
                _data.Clear();
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
