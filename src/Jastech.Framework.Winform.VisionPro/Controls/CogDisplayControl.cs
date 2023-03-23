using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cognex.VisionPro;
using Jastech.Framework.Imaging.VisionPro;

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
        }

        public enum StepPointToPoint
        {
            Start,
            End,
            Mesasure,
            Complete,
        }

        #region 필드
        private Color _noneSelectColor { get; set; } = SystemColors.Control;

        private Color _selectedColor { get; set; } = Color.DarkSeaGreen;

        private bool IsPanning { get; set; } = false;

        private DisplayMode _displayMode { get; set; } = DisplayMode.None;

        private StepPointToPoint _stepPointToPoint = StepPointToPoint.Start;

        private Point StartPoint { get; set; }

        private Point EndPoint { get; set; }

        private double Distance { get; set; }
        #endregion

        #region 속성
        public double PixelResolution { get; set; } = 1.0;
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
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
            cogDisplay.Image = cogImage;
        }

        public ICogImage GetImage()
        {
            return cogDisplay.Image;
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
                ICogImage cogImage = CogImageHelper.Load(dialog.FileName);

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
                cogDisplay.MouseMode = Cognex.VisionPro.Display.CogDisplayMouseModeConstants.Pan;
                btnPanning.BackColor = _selectedColor;
            }
            else
            {
                cogDisplay.MouseMode = Cognex.VisionPro.Display.CogDisplayMouseModeConstants.Pointer;
                btnPanning.BackColor = _noneSelectColor;
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

                btnCrossLine.BackColor = _noneSelectColor;
            }
            else
            {
                _displayMode = DisplayMode.CrossLine;
                DrawCrossLine();

                btnCrossLine.BackColor = _selectedColor;
            }
        }

        public void ClearGraphic()
        {
            cogDisplay.StaticGraphics.Clear();
            cogDisplay.InteractiveGraphics.Clear();
        }

        public PointF GetPan()
        {
            return new PointF((float)cogDisplay.PanX, (float)cogDisplay.PanY);
        }

        public void AddGraphics(string groupName, ICogRegion cogRegion, bool checkForDuplicates = false)
        {
            if (cogDisplay.Image == null)
                return;
            
            cogDisplay.InteractiveGraphics.Add(cogRegion as ICogGraphicInteractive, groupName, false);
        }
        #endregion

        private void btnCustomCrossLine_Click(object sender, EventArgs e)
        {
            if (cogDisplay.Image == null)
                return;

            string groupName = DisplayMode.CustomCrossLine.ToString();

            if (btnCustomCrossLine.BackColor == _selectedColor)
            {
                btnCustomCrossLine.BackColor = _noneSelectColor;
                _displayMode = DisplayMode.None;

                if(IsContainGroupNameInStaticGraphics(groupName))
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

            if (btnPointToPoint.BackColor == _selectedColor)
            {
                DeleteStaticGraphics("Tracking");
                btnPointToPoint.BackColor = _noneSelectColor;
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

            if(_displayMode == DisplayMode.CustomCrossLine)
            {
                DrawCustomCrossLine(e.X, e.Y);
            }
            else if(_displayMode == DisplayMode.PointToPoint)
            {
                if(_stepPointToPoint == StepPointToPoint.Start)
                {
                    StartPoint = new Point(e.X, e.Y);
                    _stepPointToPoint = StepPointToPoint.End;
                }
                else if(_stepPointToPoint == StepPointToPoint.End)
                {
                    EndPoint = new Point(e.X, e.Y);
                    Distance = CogMathHelper.GetDistance(StartPoint, EndPoint, PixelResolution).Length;
                    _stepPointToPoint = StepPointToPoint.Mesasure;
                }
                else if(_stepPointToPoint == StepPointToPoint.Mesasure)
                {
                    DrawText(e.X, e.Y, Distance.ToString("00.00"));
                    _stepPointToPoint = StepPointToPoint.Start;
                    //DrawText(e.X, e.Y, Distance.ToString("00.00"));
                }
                else if(_stepPointToPoint == StepPointToPoint.Complete)
                {
                    
                    
                }
            }
        }

        private void cogDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            if (cogDisplay.Image == null)
                return;
            if(_displayMode == DisplayMode.CustomCrossLine)
            {
            }
            else if (_displayMode == DisplayMode.PointToPoint)
            {
                double cursorSizeY = 20;
                string groupName = _stepPointToPoint.ToString();

                if(_stepPointToPoint == StepPointToPoint.Mesasure)
                {
                    //DrawTrackingText(e.X, e.Y, 0, Distance.ToString("00.00"), CogGraphicLabelAlignmentConstants.BaselineCenter);
                }
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

        public void DrawText(double x, double y, string message)
        {
            string  groupName = "Text";

            double calcX, calcY;
            cogDisplay.GetTransform("#", "*").MapPoint(x, y, out calcX, out calcY);

            CogGraphicLabel cogLabel = new CogGraphicLabel();
            cogLabel.BackgroundColor = CogColorConstants.Black;
            cogLabel.Color = CogColorConstants.Green;
            cogLabel.Alignment = CogGraphicLabelAlignmentConstants.BaselineCenter;
            cogLabel.Font = new Font("굴림", 10);
            cogLabel.SetXYText(calcX, calcY, message);

            cogDisplay.StaticGraphics.Add(cogLabel, groupName);

            cogLabel.Dispose();
        }

        public void DeleteStaticGraphics(string groupName)
        {
            if (IsContainGroupNameInStaticGraphics(groupName))
                cogDisplay.StaticGraphics.Remove(groupName);
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
    }
}
