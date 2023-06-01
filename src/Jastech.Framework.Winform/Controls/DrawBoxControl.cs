using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Jastech.Framework.Winform.Data;
using System.Drawing.Imaging;
using Jastech.Framework.Imaging.Helper;
using System.Diagnostics;
using Jastech.Framework.Winform.Forms;

namespace Jastech.Framework.Winform.Controls
{
    public partial class DrawBoxControl : UserControl
    {
        #region 필드
        private Matrix _transform = new Matrix();

        private Color _selectedColor = new Color();

        private Color _noneSelectedColor = new Color();

        public object _lock = new object();
        #endregion

        #region 속성
        private double ZoomScale { get; set; } = 1.0;

        private double OffsetX { get; set; } = 0.0;

        private double OffsetY { get; set; } = 0.0;

        public DisplayMode DisplayMode { get; private set; } = DisplayMode.None;

        public Bitmap OrgImage { get; set; } = null;

        private FigureManager FigureManager { get; set; } = new FigureManager();

        private Figure TempFigure { get; set; }

        private Figure SelectedFigure { get; set; } = null;

        private PointF PanningStartPoint { get; set; }
        #endregion

        #region 이벤트
        public event FigureDataDelegate FigureDataDelegateEventHanlder;
        #endregion

        #region 델리게이트
        public delegate void FigureDataDelegate(byte[] data);
        #endregion

        #region 생성자
        public DrawBoxControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void DrawBoxControl_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
            this.UpdateStyles();
            
            _selectedColor = Color.FromArgb(104, 104, 104);
            _noneSelectedColor = Color.FromArgb(52, 52, 52);

            DisplayMode = DisplayMode.None;
            UpdateDisplayModeUI(DisplayMode);
            pbxDisplay.MouseWheel += PbxDisplay_MouseWheel;
        }

        public void SetImage(Bitmap bmp)
        {
            lock(_lock)
            {
                if (OrgImage != null)
                {
                    OrgImage.Dispose();
                    OrgImage = null;
                }
                OrgImage = bmp;
            }
            
            pbxDisplay.Invalidate();
        }

        private void FitZoom()
        {
            if (OrgImage != null)
            {
                if (pbxDisplay.Width < pbxDisplay.Height)
                    ZoomScale = (double)pbxDisplay.Width / OrgImage.Width;
                else
                    ZoomScale = (double)pbxDisplay.Height / OrgImage.Height;

                double calcWidth = OrgImage.Width * ZoomScale;
                double valueX = (pbxDisplay.Width / 2.0) - (calcWidth / 2.0);

                double calcHeight = OrgImage.Height * ZoomScale;
                double valueY = (pbxDisplay.Height / 2.0) - (calcHeight / 2.0);

                OffsetX = (valueX / ZoomScale);
                OffsetY = (valueY / ZoomScale);

                pbxDisplay.Invalidate();
            }
        }

        private void PbxDisplay_MouseWheel(object sender, MouseEventArgs e)
        {
            double imageX = e.X / ZoomScale - OffsetX;
            double imageY = e.Y / ZoomScale - OffsetY;

            ZoomScale += (e.Delta / 1000.0);
            if (ZoomScale > 10)
                ZoomScale = 10;
            if (ZoomScale < 0.05)
                ZoomScale = 0.05;

            OffsetX = (e.X / ZoomScale) - imageX;
            OffsetY = (e.Y / ZoomScale) - imageY;

            pbxDisplay.Invalidate();
        }

        private void pbxDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            double calcX = (e.X / ZoomScale) - OffsetX;
            double calcY = (e.Y / ZoomScale) - OffsetY;
            PointF calcPoint = new PointF((float)calcX, (float)calcY);
            PanningStartPoint = calcPoint;

            if (DisplayMode == DisplayMode.None)
            {
                FigureManager.CheckPointInFigure(calcPoint);

                if (FigureManager.IsSelected())
                {
                    SelectedFigure = FigureManager.GetSelectedFigure();
                    SelectedFigure.MouseDown(calcPoint);
                }
                else
                    SelectedFigure = null;

                pbxDisplay.Invalidate();
            }
            else if (DisplayMode == DisplayMode.Drawing)
            {
                if (TempFigure == null)
                    TempFigure = new LineDirectionFigure();

                FigureManager.ClearFigureSelected();

                TempFigure.MouseDown(calcPoint);
            }
        }

        private void pbxDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            double calcX = (e.X / ZoomScale) - OffsetX;
            double calcY = (e.Y / ZoomScale) - OffsetY;
            PointF calcPoint = new PointF((float)calcX, (float)calcY);

            if (e.Button == MouseButtons.Left)
            {
                if (DisplayMode == DisplayMode.Drawing)
                {
                    if (TempFigure != null)
                        TempFigure.MouseMove(calcPoint);
                }
                else if (DisplayMode == DisplayMode.None)
                {
                    if (FigureManager.GetSelectedFigure() is Figure figure)
                    {
                        figure.MouseMove(calcPoint);
                    }
                }
                else if (DisplayMode == DisplayMode.Panning)
                {
                    OffsetX = (e.X / ZoomScale) - PanningStartPoint.X;
                    OffsetY = (e.Y / ZoomScale) - PanningStartPoint.Y;
                }
                pbxDisplay.Invalidate();
            }
        }

        private void pbxDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            double calcX = (e.X / ZoomScale) - OffsetX;
            double calcY = (e.Y / ZoomScale) - OffsetY;

            if (DisplayMode == DisplayMode.Drawing)
            {
                if (TempFigure != null)
                {
                    TempFigure.IsSelected = true;
                    TempFigure.MouseUp(new PointF((float)calcX, (float)calcY));
                    FigureManager.AddFigure(TempFigure);

                    DisplayMode = DisplayMode.None;
                    UpdateDisplayModeUI(DisplayMode);
                    TempFigure = null;

                    pbxDisplay.Invalidate();
                }
            }
        }

        private void pbxDisplay_Paint(object sender, PaintEventArgs e)
        {
            lock (_lock)
            {
                if (OrgImage == null)
                    return;

                Graphics g = e.Graphics;
                g.Clear(Color.White);

                Matrix matrix = new Matrix();
                matrix.Translate((float)OffsetX, (float)OffsetY);
                matrix.Scale((float)ZoomScale, (float)ZoomScale, MatrixOrder.Append);
                g.Transform = matrix;

                //g.DrawImage(pbxDisplay.Image, new Rectangle(0, 0, OrgImage.Width, OrgImage.Height));
                //OrgImage.
                g.DrawImage(OrgImage, new Rectangle(0, 0, OrgImage.Width, OrgImage.Height));

                int trackResize = (int)(6.0 / ZoomScale);
                if (trackResize > 50)
                    trackResize = 50;
                if (trackResize < 3)
                    trackResize = 3;

                FigureManager.SetTrackRectSize(trackResize);
                FigureManager.Draw(g);

                if (TempFigure != null)
                {
                    // TempFigure.TrackRectWidth = 
                    TempFigure.TrackRectSize =trackResize;
                    TempFigure.Draw(g);
                }

                if (FigureManager.IsSelected())
                {
                    if (FigureDataDelegateEventHanlder != null)
                    {
                        byte[] dataArray = GetDataArray(OrgImage as Bitmap, FigureManager.GetSelectedFigure());

                        if (dataArray != null)
                            FigureDataDelegateEventHanlder(dataArray);
                    }
                }
            }
               
        }

        private void btnDrawNone_Click(object sender, EventArgs e)
        {
            DisplayMode = DisplayMode.None;
            UpdateDisplayModeUI(DisplayMode);
        }

        private void btnDrawLine_Click(object sender, EventArgs e)
        {
            DisplayMode = DisplayMode.Drawing;
            UpdateDisplayModeUI(DisplayMode);
        }

        private void pbxDisplay_DoubleClick(object sender, EventArgs e)
        {
            DisplayMode = DisplayMode.None;
            UpdateDisplayModeUI(DisplayMode);
            TempFigure = null;
            FigureManager.ClearFigureSelected();

            Refresh();
        }

        private void btnPanning_Click(object sender, EventArgs e)
        {
            DisplayMode = DisplayMode.Panning;
            UpdateDisplayModeUI(DisplayMode);
        }

        private void btnFitZoom_Click(object sender, EventArgs e)
        {
            FitZoom();
        }

        private void ctxDisplayMode_Opening(object sender, CancelEventArgs e)
        {
            MenuStripSelectedNone();
            if (DisplayMode == DisplayMode.None)
            {
                menuPointerMode.Checked = true;
            }
            else if (DisplayMode == DisplayMode.Panning)
            {
                menuPanningMode.Checked = true;
            }
            else if (DisplayMode == DisplayMode.Drawing)
            {
                menuROIMode.Checked = true;
            }
        }

        private void MenuStripSelectedNone()
        {
            menuPointerMode.Checked = false;
            menuPanningMode.Checked = false;
            menuROIMode.Checked = false;
        }

        private void menuPointerMode_Click(object sender, EventArgs e)
        {
            MenuStripSelectedNone();
            DisplayMode = DisplayMode.None;
            UpdateDisplayModeUI(DisplayMode);
        }

        private void menuPanningMode_Click(object sender, EventArgs e)
        {
            MenuStripSelectedNone();
            DisplayMode = DisplayMode.Panning;
            UpdateDisplayModeUI(DisplayMode);
        }

        private void menuROIMode_Click(object sender, EventArgs e)
        {
            MenuStripSelectedNone();
            DisplayMode = DisplayMode.Drawing;
            UpdateDisplayModeUI(DisplayMode);
        }

        private void menuFitZoom_Click(object sender, EventArgs e)
        {
            FitZoom();
        }

        private byte[] GetDataArray(Bitmap image, Figure figure)
        {
            if(figure is LineDirectionFigure lineFigure)
            {
                byte[] data = ImageHelper.GetDataArray(image, lineFigure.DrawPoints.ToList());
                return data;
            }
            return null;
        }

        private void btnDeleteFigure_Click(object sender, EventArgs e)
        {
            if (FigureManager.GetSelectedFigure() is Figure figure)
            {
                MessageYesNoForm form = new MessageYesNoForm();
                form.Message = "Do you want to Delete Selected Figure?";

                if (form.ShowDialog() == DialogResult.Yes)
                {
                    FigureManager.DeleteSelectedFigure();
                    pbxDisplay.Invalidate();
                }
            }
        }

        private void UpdateDisplayModeUI(DisplayMode mode)
        {
            btnDrawNone.BackColor = _noneSelectedColor;
            btnPanning.BackColor = _noneSelectedColor;
            btnDrawLine.BackColor = _noneSelectedColor;

            if (mode == DisplayMode.None)
                btnDrawNone.BackColor = _selectedColor;
            else if (mode == DisplayMode.Panning)
                btnPanning.BackColor = _selectedColor;
            else if (mode == DisplayMode.Drawing)
                btnDrawLine.BackColor = _selectedColor;
        }

        public void DisposeImage()
        {
           if(pbxDisplay.Image != null)
            {
                pbxDisplay.Image.Dispose();
                pbxDisplay.Image = null;
            }
        }
        #endregion
    }

    public enum DisplayMode
    {
        None,
        Drawing,
        Panning,
    }
}
