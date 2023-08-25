﻿using Cognex.VisionPro;
using Jastech.Framework.Imaging.VisionPro;
using Jastech.Framework.Winform.VisionPro.Helper;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.VisionPro.Controls
{
    public partial class CogInspAlignDisplayControl : UserControl
    {
        #region 속성
        public FontFamily TextFontFamily { get; set; } = new FontFamily("Malgun Gothic"); // Malgun Gothic : 맑은 고딕

        public float TextFontSize { get; set; } = 35.0f; //화면을 이거를 기준으로 등분함.. 값이 작을수록 글자가 커진다
        #endregion

        #region 생성자
        public CogInspAlignDisplayControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void CogInspAlignDisplayControl_Load(object sender, System.EventArgs e)
        {
            cogLeftDisplay.MouseMode = Cognex.VisionPro.Display.CogDisplayMouseModeConstants.Pan;
            cogCenterDisplay.MouseMode = Cognex.VisionPro.Display.CogDisplayMouseModeConstants.Pan;
            cogRightDisplay.MouseMode = Cognex.VisionPro.Display.CogDisplayMouseModeConstants.Pan;
        }

        public void UpdateLeftDisplay(ICogImage cogImage, List<CogCompositeShape> shapeList, List<CogLineSegment> lineSegmentList, PointF centerPoint)
        {
            if (cogImage == null)
                return;
            //CogDisplayHelper.DisposeDisplay(cogLeftDisplay);
            cogLeftDisplay.Image = cogImage;//.CopyBase(CogImageCopyModeConstants.CopyPixels);
            cogLeftDisplay.StaticGraphics.Clear();
            cogLeftDisplay.InteractiveGraphics.Clear();

            CogGraphicInteractiveCollection collect = new CogGraphicInteractiveCollection();

            foreach (var shape in shapeList)
            {
                if (shape != null)
                {
                    shape.CompositionMode = CogCompositeShapeCompositionModeConstants.Uniform;
                    collect.Add(shape);
                }
            }

            foreach (var lineSegment in lineSegmentList)
            {
                if(lineSegment != null)
                    DrawLineLeftDisplay(lineSegment);
            }

            if(centerPoint.X != 0 && centerPoint.Y != 0)
            {
                cogLeftDisplay.InteractiveGraphics.AddList(collect, "Result", false);
                var gg = cogLeftDisplay.Zoom;
                cogLeftDisplay.Zoom = 0.25;
                cogLeftDisplay.PanX = (cogImage.Width / 2) - centerPoint.X;
                cogLeftDisplay.PanY = (cogImage.Height / 2) - centerPoint.Y;
            }
        }

        public void DrawLeftResult(string text, int index = 0, CogColorConstants color = CogColorConstants.Cyan)
        {
            if (cogLeftDisplay.Image == null)
                return;

            CogGraphicLabel cogLabel = new CogGraphicLabel();
            int intervalY = 20;
            double scaleX = ((double)cogLeftDisplay.Width / cogLeftDisplay.Image.Width);
            float fontSize = (float)((cogLeftDisplay.Image.Width / TextFontSize) * scaleX);
            double fontPitch = (fontSize / cogLeftDisplay.Zoom);

            cogLabel.Text = text;
            cogLabel.Color = CogColorConstants.Cyan;
            cogLabel.Font = new Font(TextFontFamily, fontSize);
            cogLabel.Alignment = CogGraphicLabelAlignmentConstants.TopLeft;

            PointF drawPoint = LeftMappingPoint(0, 0);
            cogLabel.X = drawPoint.X;
            cogLabel.Y = drawPoint.Y + (index * fontPitch) + (index * intervalY);

            cogLeftDisplay.StaticGraphics.Add(cogLabel as ICogGraphic, "Result");
        }

        private PointF LeftMappingPoint(double x, double y)
        {
            double calcX, calcY;

            cogLeftDisplay.GetTransform("#", "*").MapPoint(x, y, out calcX, out calcY);

            return new PointF((float)calcX, (float)calcY);
        }


        public void DrawRightResult(string text, int index = 0, CogColorConstants color = CogColorConstants.Cyan)
        {
            if (cogRightDisplay.Image == null)
                return;

            CogGraphicLabel cogLabel = new CogGraphicLabel();
            int intervalY = 20;
            double scaleX = ((double)cogRightDisplay.Width / cogRightDisplay.Image.Width);
            float fontSize = (float)((cogRightDisplay.Image.Width / TextFontSize) * scaleX);
            double fontPitch = (fontSize / cogRightDisplay.Zoom);

            cogLabel.Text = text;
            cogLabel.Color = CogColorConstants.Cyan;
            cogLabel.Font = new Font(TextFontFamily, fontSize);
            cogLabel.Alignment = CogGraphicLabelAlignmentConstants.TopLeft;

            PointF drawPoint = RightMappingPoint(0, 0);
            cogLabel.X = drawPoint.X;
            cogLabel.Y = drawPoint.Y + (index * fontPitch) + (index * intervalY);

            cogRightDisplay.StaticGraphics.Add(cogLabel as ICogGraphic, "Result");
        }

        private PointF RightMappingPoint(double x, double y)
        {
            double calcX, calcY;

            cogRightDisplay.GetTransform("#", "*").MapPoint(x, y, out calcX, out calcY);

            return new PointF((float)calcX, (float)calcY);
        }

        public void UpdateRightDisplay(ICogImage cogImage, List<CogCompositeShape> shapeList, List<CogLineSegment> lineSegmentList, PointF centerPoint)
        {
            if (cogImage == null)
                return;

            cogRightDisplay.Image = cogImage;//.CopyBase(CogImageCopyModeConstants.CopyPixels);
            cogRightDisplay.StaticGraphics.Clear();
            cogRightDisplay.InteractiveGraphics.Clear();

            CogGraphicInteractiveCollection collect = new CogGraphicInteractiveCollection();

            foreach (var shape in shapeList)
            {
                if (shape != null)
                {
                    shape.CompositionMode = CogCompositeShapeCompositionModeConstants.Uniform;
                    collect.Add(shape);
                }
            }

            foreach (var lineSegment in lineSegmentList)
            {
                if (lineSegment != null)
                    DrawLineRightDisplay(lineSegment);
            }

            cogRightDisplay.InteractiveGraphics.AddList(collect, "Result", false);
            if (centerPoint.X != 0 && centerPoint.Y != 0)
            {
                cogRightDisplay.Zoom = 0.25;
                cogRightDisplay.InteractiveGraphics.AddList(collect, "Result", false);
                cogRightDisplay.PanX = (cogImage.Width / 2) - centerPoint.X;
                cogRightDisplay.PanY = (cogImage.Height / 2) - centerPoint.Y;
            }
        }

        public void DrawLineLeftDisplay(CogLineSegment cogLine)
        {
            cogLeftDisplay.StaticGraphics.Add(cogLine, "line");
        }

        public void DrawLineRightDisplay(CogLineSegment cogLine)
        {
            cogRightDisplay.StaticGraphics.Add(cogLine, "line");
        }
        public void DrawLine(CogLine cogLine)
        {
            cogLeftDisplay.StaticGraphics.Add(cogLine, "line");
        }

        public void UpdateCenterDisplay(ICogImage cogImage)
        {
            if (cogImage == null)
                return;
            //CogDisplayHelper.DisposeDisplay(cogCenterDisplay);

            if (cogImage == null)
            {
                cogCenterDisplay.Image = cogLeftDisplay.Image;
            }
            else
            {
                cogCenterDisplay.Zoom = 0.5;
                cogCenterDisplay.Image = cogImage.CopyBase(CogImageCopyModeConstants.CopyPixels); ;
                cogCenterDisplay.PanX = (cogImage.Width / 2) - cogCenterDisplay.Image.Width / 2;
                cogCenterDisplay.PanY = (cogImage.Height / 2) - cogCenterDisplay.Image.Height / 2;
            }
            
            cogCenterDisplay.StaticGraphics.Clear();
            cogCenterDisplay.InteractiveGraphics.Clear();
        }

        public void SetDisplayToCenter(CogRecordDisplay display, Point point)
        {
            if (display.Image == null)
                return;

            if (point != null)
            {
                if (point.X == 0 && point.Y == 0)
                    return;

                display.PanX = display.Image.Width / 2 - point.X;
                display.PanY = display.Image.Height / 2 - point.Y;
            }
        }

        public void ClearImage()
        {
            //CogDisplayHelper.DisposeDisplay(cogLeftDisplay);
            //cogLeftDisplay.InteractiveGraphics.Clear();
            //cogLeftDisplay.Image = null;

            //CogDisplayHelper.DisposeDisplay(cogRightDisplay);
            //cogRightDisplay.InteractiveGraphics.Clear();
            //cogRightDisplay.Image = null;
        }

        public void ClearGraphics()
        {
            cogLeftDisplay.InteractiveGraphics.Clear();
            cogRightDisplay.InteractiveGraphics.Clear();
        }
        #endregion

        private void cogLeftDisplay_Changed(object sender, CogChangedEventArgs e)
        {
            if (sender is CogRecordDisplay display)
            {
                if (display.Image == null)
                    return;

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
                    //if (DeleteResultGraphics())
                    //    DeleteEventHandler?.Invoke(sender, e);

                    //MoveImageEventHandler?.Invoke(display.PanX, display.PanY, display.Zoom);
                }
            }
        }

        private void cogCenterDisplay_Changed(object sender, CogChangedEventArgs e)
        {
            if (sender is CogRecordDisplay display)
            {
                if (display.Image == null)
                    return;

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
            }
        }

        private void cogRightDisplay_Changed(object sender, CogChangedEventArgs e)
        {
            if (sender is CogRecordDisplay display)
            {
                if (display.Image == null)
                    return;

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
            }
        }
    }
}
