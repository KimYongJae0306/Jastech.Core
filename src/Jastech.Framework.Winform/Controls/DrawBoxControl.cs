using Jastech.Framework.Imaging.Helper;
using Jastech.Framework.Winform.Data;
using Jastech.Framework.Winform.Forms;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.Controls
{
    public partial class DrawBoxControl : UserControl
    {
        #region 필드
        private Matrix _transform = new Matrix();

        private Color _selectedColor = new Color();

        private Color _nonSelectedColor = new Color();

        public object _lock = new object();

        private bool _isInteractive = true;

        private HatchBrush _backGroundBrush = new HatchBrush(HatchStyle.DiagonalCross, Color.FromArgb(27, 27, 27));
        #endregion

        #region 속성
        private double ZoomScale { get; set; } = 1.0;

        private double OffsetX { get; set; } = 0.0;

        private double OffsetY { get; set; } = 0.0;

        public DisplayMode DisplayMode { get; set; } = DisplayMode.None;

        public bool UseGrayLevel { get; set; } = false;

        public Bitmap OrgImage { get; set; } = null;

        private int ImageWidth { get; set; } = 0;

        private int ImageHeight { get; set; } = 0;

        private TextureBrush BitmapBrush { get; set; } = null;

        private FigureManager FigureManager { get; set; } = new FigureManager();

        private Figure TempFigure { get; set; }

        private Figure SelectedFigure { get; set; } = null;

        private PointF PanningStartPoint { get; set; }

        public Color ViewColor { get; set; } = Color.FromArgb(52, 52, 52);

        private DoubleBufferedPicturebox pbxDisplay { get; set; } = null;
        #endregion

        #region 이벤트
        public event FigureDataDelegate FigureDataDelegateEventHandler;
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

            pbxDisplay = new DoubleBufferedPicturebox();
            pbxDisplay.BackColor = ViewColor;
            pbxDisplay.MouseWheel += PbxDisplay_MouseWheel;
            pbxDisplay.Paint += pbxDisplay_Paint;
            pbxDisplay.DoubleClick += pbxDisplay_DoubleClick;
            pbxDisplay.MouseDown += pbxDisplay_MouseDown;
            pbxDisplay.MouseMove += pbxDisplay_MouseMove;
            pbxDisplay.MouseUp += pbxDisplay_MouseUp;
            pbxDisplay.Dock = DockStyle.Fill;
            pnlDisplay.Controls.Add(pbxDisplay);

            _selectedColor = Color.FromArgb(104, 104, 104);
            _nonSelectedColor = Color.FromArgb(52, 52, 52);

            pnlText.Visible = UseGrayLevel;

            UpdateDisplayModeUI(DisplayMode);
        }

        public void SetImage(Bitmap bmp)
        {
            lock(_lock)
            {
                if (bmp == null)
                {
                    ImageWidth = 0;
                    ImageHeight = 0;
                    return;
                }
                if (OrgImage != null)
                {
                    OrgImage.Dispose();
                    OrgImage = null;
                }

                OrgImage = bmp;
                ImageWidth = bmp.Width;
                ImageHeight = bmp.Height;

                if (_isInteractive)
                {
                    if (BitmapBrush != null)
                    {
                        BitmapBrush.Dispose();
                        BitmapBrush = null;
                    }

                    BitmapBrush = new TextureBrush(OrgImage);
                }
            }
            
            pbxDisplay.Invalidate();
            pbxDisplay.Image = OrgImage;
        }

        public void EnableBitmapBrush(bool enable)
        {
            _isInteractive = enable;   // 연속되는 SetImage 시 비활성화 필요
            if (enable == true)
                BitmapBrush = new TextureBrush(OrgImage);

            Invalidate();
        }

        public void DisableFunctionButtons()
        {
            tableLayoutPanel3.Controls.Remove(tableLayoutPanel4);
            tableLayoutPanel3.ColumnStyles.RemoveAt(0);
            tableLayoutPanel3.ColumnCount--;

            tableLayoutPanel1.Controls.Remove(pnlText);
            tableLayoutPanel1.RowStyles.RemoveAt(1);
            tableLayoutPanel1.RowCount--;
        }

        public void FitZoom()
        {
            if (_isInteractive == false)
                return;

            if (OrgImage != null)
            {
                if (pbxDisplay.Width > pbxDisplay.Height)
                    ZoomScale = (double)pbxDisplay.Width / ImageWidth;
                else
                    ZoomScale = (double)pbxDisplay.Height / ImageHeight;

                double calcWidth = ImageWidth * ZoomScale;
                double valueX = (pbxDisplay.Width / 2.0) - (calcWidth / 2.0);

                double calcHeight = ImageHeight * ZoomScale;
                double valueY = (pbxDisplay.Height / 2.0) - (calcHeight / 2.0);

                OffsetX = (valueX / ZoomScale);
                OffsetY = (valueY / ZoomScale);

                pbxDisplay.Invalidate();
            }
        }

        private void PbxDisplay_MouseWheel(object sender, MouseEventArgs e)
        {
            if (_isInteractive == false)
                return;

            double imageX = e.X / ZoomScale - OffsetX;
            double imageY = e.Y / ZoomScale - OffsetY;

            if (ZoomScale > Math.Abs(e.Delta / 500.0))
                ZoomScale += e.Delta / 1000.0;
            else if (ZoomScale > Math.Abs(e.Delta / 1000.0))
                ZoomScale += e.Delta / 10000.0;
            else
                ZoomScale += e.Delta / 20000.0;

            if (ZoomScale > 10)
                ZoomScale = 10;
            if (ZoomScale < 0.01)
                ZoomScale = 0.01;

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

            if (UseGrayLevel)
            {
                if (OrgImage != null)
                {
                    var value = ImageHelper.GetGrayLevel(OrgImage, calcPoint);
                    lblGrayPoint.Text = string.Format("({0},{1})", (int)calcX, (int)calcY);
                    lblGrayLevel.Text = value.ToString();
                }
            }

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
            else
            {
                if (FigureManager.GetSelectedFigure() is Figure figure)
                {
                    this.Cursor= figure.GetCursors(calcPoint);
                }
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
                Color color = Color.FromArgb(52, 52, 52);
                g.Clear(color);
                g.FillRectangle(_backGroundBrush, 0, 0, Width, Height);

                Matrix matrix = new Matrix();
                matrix.Translate((float)OffsetX, (float)OffsetY);
                matrix.Scale((float)ZoomScale, (float)ZoomScale, MatrixOrder.Append);
                g.Transform = matrix;

                if (_isInteractive)
                    g.FillRectangle(BitmapBrush, new Rectangle(0, 0, ImageWidth, ImageHeight));

                int trackResize = (int)(6.0 / ZoomScale);
                if (trackResize > 50)
                    trackResize = 50;
                if (trackResize < 3)
                    trackResize = 3;

                FigureManager.SetTrackRectSize(trackResize);
                FigureManager.Draw(g);

                if (TempFigure != null)
                {
                    TempFigure.TrackRectSize =trackResize;
                    TempFigure.Draw(g);
                }

                if (FigureManager.IsSelected())
                {
                    if (FigureDataDelegateEventHandler != null)
                    {
                        byte[] dataArray = GetDataArray(OrgImage as Bitmap, FigureManager.GetSelectedFigure());

                        if (dataArray != null)
                            FigureDataDelegateEventHandler(dataArray);
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
            this.Cursor = Cursors.Default;
            UpdateDisplayModeUI(DisplayMode);
        }

        private void menuPanningMode_Click(object sender, EventArgs e)
        {
            MenuStripSelectedNone();
            DisplayMode = DisplayMode.Panning;
            this.Cursor = Cursors.Hand;
            UpdateDisplayModeUI(DisplayMode);
        }

        private void menuROIMode_Click(object sender, EventArgs e)
        {
            MenuStripSelectedNone();
            DisplayMode = DisplayMode.Drawing;
            this.Cursor = Cursors.Default;
            UpdateDisplayModeUI(DisplayMode);
        }

        private void menuFitZoom_Click(object sender, EventArgs e)
        {
            FitZoom();
        }

        private byte[] GetDataArray(Bitmap image, Figure figure)
        {
            if (figure is LineDirectionFigure lineFigure)
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
            btnDrawNone.BackColor = _nonSelectedColor;
            btnPanning.BackColor = _nonSelectedColor;
            btnDrawLine.BackColor = _nonSelectedColor;

            if (mode == DisplayMode.None)
            {
                btnDrawNone.BackColor = _selectedColor;
                this.Cursor = Cursors.Default;
            }
            else if (mode == DisplayMode.Panning)
            {
                btnPanning.BackColor = _selectedColor;
                this.Cursor = Cursors.Hand;
            }
            else if (mode == DisplayMode.Drawing)
            {
                btnDrawLine.BackColor = _selectedColor;
                this.Cursor = Cursors.Default;
            }
        }

        public void DisposeImage()
        {
           if (pbxDisplay?.Image != null)
            {
                pbxDisplay.Image.Dispose();
                pbxDisplay.Image = null;
           }
        }

        private void menuSaveImage_Click(object sender, EventArgs e)
        {
            if (OrgImage == null)
                return;

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "BMP File(*.bmp)|*.bmp;";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                OrgImage.Save(dialog.FileName);
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
