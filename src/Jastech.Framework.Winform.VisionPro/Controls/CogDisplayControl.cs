﻿using Cognex.VisionPro;
using Cognex.VisionPro.Dimensioning;
using Cognex.VisionPro.Display;
using Cognex.VisionPro.Implementation;
using Jastech.Framework.Imaging.Result;
using Jastech.Framework.Imaging.VisionPro;
using Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Results;
using Jastech.Framework.Winform.VisionPro.Helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.VisionPro.Controls
{
    public partial class CogDisplayControl : UserControl
    {
        public enum DisplayMode
        {
            None,
            CrossLine,
            CustomCrossLine,
            PointToPoint,
            PointToLine,
        }

        public enum StepPointToPoint
        {
            Start,
            End,
            Measure,
            Complete,
        }

        #region 필드
        private bool _updateViewRect { get; set; } = false;

        private Color _nonSelectedColor { get; set; } = SystemColors.Control;

        private Color _selectedColor { get; set; } = Color.DarkSeaGreen;

        private bool IsPanning { get; set; } = false;

        private DisplayMode _displayMode { get; set; } = DisplayMode.None;

        private StepPointToPoint _stepPointToPoint = StepPointToPoint.Start;

        private Point StartPoint { get; set; }

        private Point EndPoint { get; set; }

        private double Distance { get; set; }
        #endregion

        #region 이벤트
        public event DrawViewRectDelegate DrawViewRectEventHandler;

        public event EventHandler DeleteEventHandler;

        public event MoveImageDelegate MoveImageEventHandler;
        #endregion

        #region 델리게이트
        public delegate void DrawViewRectDelegate(CogRectangle viewRect);

        public delegate void MoveImageDelegate(double panX, double panY, double zoom);
        #endregion

        #region 속성
        public double PixelResolution { get; set; } = 1.0;

        private CogDistancePointPointTool TrackingCogDistanceTool = new CogDistancePointPointTool();

        private List<CogToolBase> DrawToolList = new List<CogToolBase>();

        public FontFamily TextFontFamily { get; set; } = new FontFamily("Malgun Gothic"); // Malgun Gothic : 맑은 고딕

        public float TextFontSize { get; set; } = 35.0f; //화면을 이거를 기준으로 등분함.. 값이 작을수록 글자가 커진다
        #endregion

        #region 생성자
        public CogDisplayControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void CogDisplayControl_Load(object sender, EventArgs e)
        {
            cogDisplayStatusBar.Display = cogDisplay;
        }

        public void SetImage(ICogImage cogImage)
        {
            CogDisplayHelper.DisposeDisplay(cogDisplay);
            if (cogImage == null)
                cogDisplay.Image = null;
            else//ASDF
                cogDisplay.Image = cogImage.CopyBase(CogImageCopyModeConstants.CopyPixels);
            //UpdateViewRect();
        }

        public void DisposeImage()
        {
            CogDisplayHelper.DisposeDisplay(cogDisplay);
            cogDisplay.Image = null;
        }

        public void SetImagePosition(double panX, double panY, double zoom)
        {
            cogDisplay.Zoom = zoom;
            cogDisplay.PanX = panX;
            cogDisplay.PanY = panY;
        }

        public ICogImage GetImage()
        {
            return cogDisplay.Image;
        }

        public void ClearImage()
        {
            CogDisplayHelper.DisposeDisplay(cogDisplay);
            cogDisplay.Image = null;
        }
        
        public int ImageWidth()
        {
            if (cogDisplay.Image != null)
                return cogDisplay.Image.Width;

            return 0;
        }

        public int ImageHeight()
        {
            if (cogDisplay.Image != null)
                return cogDisplay.Image.Height;

            return 0;
        }

        public double GetZoomValue()
        {
            return cogDisplay.Zoom;
        }

        public CogRectangle GetViewRectangle()
        {
            CogRectangle rect = new CogRectangle();
            double calcX, calcY;
            
            cogDisplay.GetTransform("#", "*").MapPoint(0, 0, out calcX, out calcY);

            int calcWidth = (int)(cogDisplay.DisplayRectangle.Width / cogDisplay.Zoom);
            int calcHeight = (int)(cogDisplay.DisplayRectangle.Height / cogDisplay.Zoom);

            if (calcWidth == 0 || calcHeight == 0)
                return null;

            rect.X = calcX;
            rect.Y = calcY;
            rect.Width = calcWidth;
            rect.Height = calcHeight;

            return rect;
        }

        private void btnFileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "이미지 파일(*.jpeg,*.jpg,*.png,*.bmp) |*.jpeg;*.jpg;*.png;*.bmp;|"
                  + "jpeg 파일(*.jpeg)|*.jpeg; |"
                  + "jpg 파일(*.jpg)|*.jpg; |"
                  + "png 파일(*.png) | *.png; |"
                  + "bmp 파일(*.bmp) | *.bmp; |"
                  + "모든 파일(*.*) | *.*;";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ICogImage cogImage = VisionProImageHelper.Load(dialog.FileName);

                CogImage8Grey cog = (CogImage8Grey)cogImage;
                ICogImage8PixelMemory memory= cog.Get8GreyPixelMemory(CogImageDataModeConstants.Read, 0, 0, cogImage.Width, cogImage.Height);

                IntPtr ptrData = memory.Scan0;
                byte[] data = new byte[memory.Stride * memory.Height];

                System.Runtime.InteropServices.Marshal.Copy((IntPtr)ptrData, data, 0, memory.Stride * memory.Height);
                int stride = memory.Stride;

                for (int h = 0; h < cogImage.Height; h++)
                {
                    for (int w = 0; w < cogImage.Width; w++)
                    {
                        int index = h * stride + w;
                        int value = Convert.ToInt32(data[index]);
                        if (value >= 40)
                        {
                            data[index] = 0;
                            break;
                        }
                        else
                        {
                            data[index] = 255;
                            break;
                        }
                    }
                }

                _displayMode = DisplayMode.None;
            }
        }

        private void btnFitZoom_Click(object sender, EventArgs e)
        {
            cogDisplay.Fit(true);
        }

        private void btnPanning_Click(object sender, EventArgs e)
        {
            if (cogDisplay.Image == null)
                return;
            
            IsPanning = !IsPanning;

            if (IsPanning)
            {
                cogDisplay.MouseMode = CogDisplayMouseModeConstants.Pan;
                btnPanning.BackColor = _selectedColor;
            }
            else
            {
                cogDisplay.MouseMode = CogDisplayMouseModeConstants.Pointer;
                btnPanning.BackColor = _nonSelectedColor;
            }
        }

        private void btnCrossLine_Click(object sender, EventArgs e)
        {
            if (cogDisplay.Image == null)
                return;

            string groupName = DisplayMode.CrossLine.ToString();

            if (IsContainGroupNameInStaticGraphics(groupName))
            {
                _displayMode = DisplayMode.None;
                cogDisplay.StaticGraphics.Remove(groupName);

                btnCrossLine.BackColor = _nonSelectedColor;
            }
            else
            {
                _displayMode = DisplayMode.CrossLine;
                DrawCrossLine();

                btnCrossLine.BackColor = _selectedColor;
            }
        }

        public void Clear()
        {
            ClearGraphic();
            CogDisplayHelper.DisposeDisplay(cogDisplay);
            cogDisplay.Image = null;
        }

        public void ClearGraphic()
        {
            //cogDisplay.StaticGraphics.Dispose();
            cogDisplay.StaticGraphics.Clear();
            //cogDisplay.InteractiveGraphics.Dispose();
            cogDisplay.InteractiveGraphics.Clear();

            //GC.Collect();
        }

        public void ClearGraphic(string groupName)
        {
            DeleteStaticGraphics(groupName);
        }

        public PointF GetPan()
        {
            return new PointF((float)cogDisplay.PanX, (float)cogDisplay.PanY);
        }

        public void AddGraphics(string groupName, ICogRegion cogRegion, bool checkForDuplicates = false)
        {
            if (cogDisplay.Image == null || cogRegion == null)
                return;
            
            cogDisplay.InteractiveGraphics.Add(cogRegion as ICogGraphicInteractive, groupName, false);
        }

        public void SetDisplayToCenter(Point point)
        {
            if (cogDisplay.Image == null)
                return;

            cogDisplay.PanX = cogDisplay.Image.Width / 2 - point.X;
            cogDisplay.PanY = cogDisplay.Image.Height / 2 - point.Y;
        }

        private void btnCustomCrossLine_Click(object sender, EventArgs e)
        {
            if (cogDisplay.Image == null)
                return;

            string groupName = DisplayMode.CustomCrossLine.ToString();

            if (btnCustomCrossLine.BackColor == _selectedColor)
            {
                btnCustomCrossLine.BackColor = _nonSelectedColor;
                _displayMode = DisplayMode.None;

                if (IsContainGroupNameInStaticGraphics(groupName))
                    cogDisplay.StaticGraphics.Remove(groupName);
            }
            else
            {
                _displayMode = DisplayMode.CustomCrossLine;
                btnCustomCrossLine.BackColor = _selectedColor;
            }
        }

        private void btnPointToPoint_Click(object sender, EventArgs e)
        {
            if (cogDisplay.Image == null)
                return;

            ClearSelect();

            if (btnPointToPoint.BackColor == _selectedColor)
            {
                DeleteStaticGraphics("Tracking");
                btnPointToPoint.BackColor = _nonSelectedColor;
                _stepPointToPoint = StepPointToPoint.Start;
                _displayMode = DisplayMode.None;
            }
            else
            {
                btnPointToPoint.BackColor = _selectedColor;
                _stepPointToPoint = StepPointToPoint.Start;
                _displayMode = DisplayMode.PointToPoint;
            }
        }

        private void cogDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            if (cogDisplay.Image == null)
                return;

            if (_displayMode == DisplayMode.CustomCrossLine)
            {
                DrawCustomCrossLine(e.X, e.Y);
            }
            else if (_displayMode == DisplayMode.PointToPoint)
            {
                PointF mappingPoint = MappingPoint(e.X, e.Y);

                if (_stepPointToPoint == StepPointToPoint.Start)
                {
                    TrackingCogDistanceTool.InputImage = cogDisplay.Image;

                    StartPoint = new Point((int)mappingPoint.X, (int)mappingPoint.Y);

                    _stepPointToPoint = StepPointToPoint.End;
                }
                else if (_stepPointToPoint == StepPointToPoint.End)
                {
                    EndPoint = new Point((int)mappingPoint.X, (int)mappingPoint.Y);

                    Distance = VisionProMathHelper.GetDistance(StartPoint, EndPoint, PixelResolution).Length;
                    _stepPointToPoint = StepPointToPoint.Measure;
                }
                else if (_stepPointToPoint == StepPointToPoint.Measure)
                {
                    DeleteStaticGraphics("Tracking");

                    DrawToolList.Add(TrackingCogDistanceTool);
                    SetStaticGraphics(DrawToolList.Count.ToString(), TrackingCogDistanceTool.CreateLastRunRecord());

                    Distance = VisionProMathHelper.GetDistance(StartPoint, mappingPoint, PixelResolution).Length;
                    DrawText(DrawToolList.Count.ToString(), mappingPoint.X, mappingPoint.Y - 10, Distance.ToString("00.00"));

                    _stepPointToPoint = StepPointToPoint.Start;
                }
                else if (_stepPointToPoint == StepPointToPoint.Complete)
                {


                }
            }
        }

        private void cogDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            if (cogDisplay.Image == null)
                return;

            if (_displayMode == DisplayMode.PointToPoint)
            {
                if (_stepPointToPoint == StepPointToPoint.End || _stepPointToPoint == StepPointToPoint.Measure)
                {
                    PointF mappingPoint = MappingPoint(e.X, e.Y);

                    TrackingCogDistanceTool.StartX = StartPoint.X;
                    TrackingCogDistanceTool.StartY = StartPoint.Y;

                    if (_stepPointToPoint == StepPointToPoint.End)
                    {
                        TrackingCogDistanceTool.EndX = mappingPoint.X;
                        TrackingCogDistanceTool.EndY = mappingPoint.Y;
                    }
                    else if (_stepPointToPoint == StepPointToPoint.Measure)
                    {
                        TrackingCogDistanceTool.EndX = EndPoint.X;
                        TrackingCogDistanceTool.EndY = EndPoint.Y;
                    }
                    TrackingCogDistanceTool.Run();

                    string groupName = "Tracking";
                    if (IsContainGroupNameInStaticGraphics(groupName))
                        cogDisplay.StaticGraphics.Remove(groupName);

                    SetStaticGraphics(groupName, TrackingCogDistanceTool.CreateLastRunRecord());

                    Distance = VisionProMathHelper.GetDistance(StartPoint, mappingPoint, PixelResolution).Length;
                    DrawText(groupName, mappingPoint.X, mappingPoint.Y - 10, Distance.ToString("00.00"));
                }
                else if (_stepPointToPoint == StepPointToPoint.Measure)
                {

                }
            }

            if(cogDisplay.MouseMode == CogDisplayMouseModeConstants.Pan && e.Button == MouseButtons.Left)
            {
                MoveImageEventHandler?.Invoke(cogDisplay.PanX, cogDisplay.PanY, cogDisplay.Zoom);
            }
        }

        private void cogDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            if (cogDisplay.MouseMode == CogDisplayMouseModeConstants.Pan && e.Button == MouseButtons.Left)
            {
                MoveImageEventHandler?.Invoke(cogDisplay.PanX, cogDisplay.PanY, cogDisplay.Zoom);
            }
        }

        private void DrawCrossLine()
        {
            string groupName = _displayMode.ToString();

            CogLineSegment cogSegment = new CogLineSegment();
            cogSegment.Interactive = true;
            cogSegment.GraphicDOFEnable = CogLineSegmentDOFConstants.All;
            cogSegment.Color = CogColorConstants.Green;

            //가로
            cogSegment.SetStartEnd(0, cogDisplay.Image.Height / 2, cogDisplay.Image.Width, cogDisplay.Image.Height / 2);
            cogDisplay.StaticGraphics.Add(cogSegment, groupName);

            //세로
            cogSegment.SetStartEnd(cogDisplay.Image.Width / 2, 0, cogDisplay.Image.Width / 2, cogDisplay.Image.Height);
            cogDisplay.StaticGraphics.Add(cogSegment, groupName);

            cogSegment.Dispose();
        }

        public void SetMouseMode(CogDisplayMouseModeConstants mode)
        {
            cogDisplay.MouseMode = mode;
        }

        private void DrawCustomCrossLine(double x, double y)
        {
            string groupName = _displayMode.ToString();

            if (IsContainGroupNameInStaticGraphics(groupName))
                cogDisplay.StaticGraphics.Remove(groupName);

            double calcX, calcY;
            cogDisplay.GetTransform("#", "*").MapPoint(x, y, out calcX, out calcY);

            CogLineSegment cogSegment = new CogLineSegment();
            cogSegment.Interactive = true;
            cogSegment.GraphicDOFEnable = CogLineSegmentDOFConstants.All;
            cogSegment.Color = CogColorConstants.Magenta;

            cogSegment.SetStartEnd(0, calcY, cogDisplay.Image.Width, calcY);
            cogDisplay.StaticGraphics.Add(cogSegment, groupName);

            cogSegment.SetStartEnd(calcX, 0, calcX, cogDisplay.Image.Height);
            cogDisplay.StaticGraphics.Add(cogSegment, groupName);

            cogSegment.Dispose();
        }

        public void DrawText(string groupName, double calcX, double calcY, string message)
        {
            CogGraphicLabel cogLabel = new CogGraphicLabel();
            cogLabel.BackgroundColor = CogColorConstants.Black;
            cogLabel.Color = CogColorConstants.Green;
            cogLabel.Alignment = CogGraphicLabelAlignmentConstants.BaselineCenter;
            cogLabel.Font = new Font("맑은 고딕", 10);
            cogLabel.SetXYText(calcX, calcY, message);

            cogDisplay.StaticGraphics.Add(cogLabel, groupName);

            cogLabel.Dispose();
        }

        public void DeleteStaticGraphics(string groupName)
        {
            if (IsContainGroupNameInStaticGraphics(groupName))
                cogDisplay.StaticGraphics.Remove(groupName);
        }

        public void DeleteInInteractiveGraphics(string groupName)
        {
            if (IsContainGroupNameInInteractiveGraphics(groupName))
                cogDisplay.InteractiveGraphics.Remove(groupName);
        }

        public bool DeleteResultGraphics()
        {
            bool isDelete = false;
            string groupName = "Result";
            if (IsContainGroupNameInInteractiveGraphics(groupName))
            {
                cogDisplay.InteractiveGraphics.Remove(groupName);
                isDelete = true;
            }

            if (IsContainGroupNameInStaticGraphics(groupName))
            {
                cogDisplay.StaticGraphics.Remove(groupName);
                isDelete = true;
            }
            return isDelete;
        }


        private bool IsContainGroupNameInStaticGraphics(string groupName)
        {
            foreach (var value in cogDisplay.StaticGraphics.ZOrderGroups)
            {
                if (groupName == (string)value)
                    return true;
            }
            return false;
        }

        private bool IsContainGroupNameInInteractiveGraphics(string groupName)
        {
            foreach (var value in cogDisplay.InteractiveGraphics.ZOrderGroups)
            {
                if (groupName == (string)value)
                    return true;
            }
            return false;
        }

        private PointF MappingPoint(double x, double y)
        {
            double calcX, calcY;

            cogDisplay.GetTransform("#", "*").MapPoint(x, y, out calcX, out calcY);

            return new PointF((float)calcX, (float)calcY);
        }

        public void SetStaticGraphics(string groupName, ICogRecord record)
        {
            foreach (CogRecord subRecord in record.SubRecords)
            {
                if (typeof(ICogGraphic).IsAssignableFrom(subRecord.ContentType))
                {
                    if (subRecord.Content != null)
                        cogDisplay.StaticGraphics.Add(subRecord.Content as ICogGraphicInteractive, groupName);
                }
                else if (typeof(CogGraphicCollection).IsAssignableFrom(subRecord.ContentType))
                {
                    if (subRecord.Content != null)
                    {
                        CogGraphicCollection graphics = subRecord.Content as CogGraphicCollection;
                        foreach (ICogGraphic graphic in graphics)
                        {
                            cogDisplay.StaticGraphics.Add(graphic as ICogGraphicInteractive, groupName);
                        }
                    }
                }
                else if (typeof(CogGraphicInteractiveCollection).IsAssignableFrom(subRecord.ContentType))
                {
                    if (subRecord.Content != null)
                    {
                        cogDisplay.StaticGraphics.AddList(subRecord.Content as CogGraphicCollection, groupName);
                    }
                }
                SetStaticGraphics(groupName, subRecord);
            }
        }

        public void SetStaticGraphics(string groupName, ICogGraphic cogGraphic)
        {
            cogDisplay.StaticGraphics.Add(cogGraphic, groupName);
        }

        public void SetInteractiveGraphics(string groupName, CogGraphicInteractiveCollection collection)
        {
            //if(collection is ICogGraphicInteractive cogGraphic)
                cogDisplay.InteractiveGraphics.AddList(collection, groupName, false);
        }

        public void SetInteractiveGraphics(string groupName, ICogRecord record)
        {
            if (record == null)
                return;
            foreach (CogRecord subRecord in record.SubRecords)
            {
                if (typeof(ICogGraphic).IsAssignableFrom(subRecord.ContentType))
                {
                    if (subRecord.Content != null)
                        cogDisplay.InteractiveGraphics.Add(subRecord.Content as ICogGraphicInteractive, groupName, false);
                }
                else if (typeof(CogGraphicCollection).IsAssignableFrom(subRecord.ContentType))
                {
                    if (subRecord.Content != null)
                    {
                        CogGraphicCollection graphics = subRecord.Content as CogGraphicCollection;
                        foreach (ICogGraphic graphic in graphics)
                        {
                            cogDisplay.InteractiveGraphics.Add(graphic as ICogGraphicInteractive, groupName, false);
                        }
                    }
                }
                else if (typeof(CogGraphicInteractiveCollection).IsAssignableFrom(subRecord.ContentType))
                {
                    if (subRecord.Content != null)
                    {
                        cogDisplay.InteractiveGraphics.AddList(subRecord.Content as CogGraphicInteractiveCollection, groupName, false);
                    }
                }
                SetInteractiveGraphics(groupName, subRecord);
            }
        }

        private void btnPointToLine_Click(object sender, EventArgs e)
        {
            if (cogDisplay.Image == null)
                return;
            ClearSelect();

            if (btnPointToLine.BackColor == _selectedColor)
            {
                DeleteStaticGraphics("Tracking");
                btnPointToLine.BackColor = _nonSelectedColor;
                _stepPointToPoint = StepPointToPoint.Start;
                _displayMode = DisplayMode.None;
            }
            else
            {
                btnPointToLine.BackColor = _selectedColor;
                _stepPointToPoint = StepPointToPoint.Start;
                _displayMode = DisplayMode.PointToLine;
            }
        }

        private void ClearSelect()
        {
            btnPointToPoint.BackColor = _nonSelectedColor;
            btnPointToLine.BackColor = _nonSelectedColor;
        }

        private void cogDisplay_Changed(object sender, CogChangedEventArgs e)
        {
            if (sender is CogRecordDisplay display)
            {
                if (display.Image == null)
                    return;

                if (_updateViewRect)
                {
                    _updateViewRect = false;
                    return;
                }
                string flagNames = e.GetStateFlagNames(sender);
                if (flagNames.Contains("SfAutoFitWithGraphics"))
                    return;

                if (flagNames.Contains("SfZoom") || flagNames.Contains("SfMaintainImageRegion"))
                {
                    //if (display.Zoom < 0.2)
                    //    display.Zoom = 0.2;

                    if (display.Zoom > 10)
                        display.Zoom = 10;
                }

                if (flagNames == "SfZoom" || flagNames == "SfPanX" || flagNames == "SfPanY")
                {
                    if (DeleteResultGraphics())
                        DeleteEventHandler?.Invoke(sender, e);

                    MoveImageEventHandler?.Invoke(display.PanX, display.PanY, display.Zoom);
                }

                UpdateViewRect();
            }
        }

        private void UpdateViewRect()
        {
            CogRectangle viewRect = GetViewRectangle();
            if(viewRect != null)
                DrawViewRectEventHandler?.Invoke(viewRect);
        }

        public void UpdateViewRect(CogRectangle rect, double ratio)
        {
            _updateViewRect = true;

            double panPointX = (double)cogDisplay.Image.Width * ratio;
            panPointX = (cogDisplay.Image.Width / 2) - panPointX;
            cogDisplay.PanX = panPointX;
        }

        public void UpdateResult(VisionProPatternMatchingResult matchingResult)
        {
            CogGraphicInteractiveCollection resultGraphic = new CogGraphicInteractiveCollection();

            string groupName = "Result";
            var matchingResultData = matchingResult.MaxMatchPos as VisionProPatternMatchPos;
            if (matchingResultData.ResultGraphics == null)
                return;

            resultGraphic.Add(matchingResultData.ResultGraphics);
            SetInteractiveGraphics(groupName, resultGraphic);

            var result = matchingResult.Judgement;

            DrawResultLabel("Result :" + result.ToString(), 0);
            if (result != Judgement.FAIL)
            {
                DrawResultLabel("Score :" + (matchingResult.MaxScore * 100).ToString("0.000"), 1);
                DrawResultLabel("Y :" + matchingResult.MaxMatchPos.FoundPos.X.ToString("0.000"), 2);
                DrawResultLabel("X :" + matchingResult.MaxMatchPos.FoundPos.Y.ToString("0.000"), 3);
                DrawResultLabel("Angle :" + matchingResult.MaxMatchPos.Angle.ToString("0.000"), 4);
            }
        }

        public void UpdateResult(VisionProAlignCaliperResult alignResult)
        {
            if (alignResult == null)
                return;

            CogGraphicInteractiveCollection resultGraphic = new CogGraphicInteractiveCollection();

            string groupName = "Result";

            foreach (var item in alignResult.CogAlignResult)
            {
                resultGraphic.Add(item.MaxCaliperMatch.ResultGraphics);
            }
            
            SetInteractiveGraphics(groupName, resultGraphic);

            DrawResultLabel("Result :" + alignResult.Judgement.ToString(), 0);
            //if (alignResult.Judgement != Result.Fail)
            //{
            //    DrawResultLabel("Y :" + alignResult.MaxCaliperMatch.FoundPos.X.ToString("0.000"), 2);
            //    DrawResultLabel("X :" + alignResult.MaxCaliperMatch.FoundPos.Y.ToString("0.000"), 3);
            //}
        }

        private void DrawResultLabel(string text, int index = 0)
        {
            CogGraphicLabel cogLabel = new CogGraphicLabel();
            int intervalY = 20;
            double scaleX = ((double)cogDisplay.Width / cogDisplay.Image.Width);
            float fontSize = (float)((cogDisplay.Image.Width / TextFontSize) * scaleX);
            double fontPitch = (fontSize / cogDisplay.Zoom);

            cogLabel.Text = text;
            cogLabel.Color = CogColorConstants.Cyan;
            cogLabel.Font = new Font(TextFontFamily, fontSize);
            cogLabel.Alignment = CogGraphicLabelAlignmentConstants.TopLeft;

            PointF drawPoint = MappingPoint(0, 0);
            cogLabel.X = drawPoint.X;
            cogLabel.Y = drawPoint.Y + (index * fontPitch) + (index * intervalY);

            cogDisplay.StaticGraphics.Add(cogLabel as ICogGraphic, "Result");
        }

     
        #endregion
    }
}
