using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.Controls
{
    public partial class LiveViewPanel : UserControl
    {
        #region 필드
        private Bitmap _originBitmap = null;

        private Point _mouseUpPoint = new Point();

        private Point _mouseDownPoint = new Point();
        #endregion

        #region 속성
        public DoubleBufferPanel DoubleBufferPanel { get; set; } = null;

        public byte[] ImageSource { get; set; } = null;
        #endregion

        #region 생성자
        public LiveViewPanel()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void LiveViewPanel_Load(object sender, EventArgs e)
        {
            DoubleBufferPanel = new DoubleBufferPanel() { Dock = DockStyle.Fill };
            pnlLiveView.Controls.Add(DoubleBufferPanel);

            DoubleBufferPanel.Paint += DoubleBufferPanel_Paint;
            DoubleBufferPanel.MouseWheel += DoubleBufferPanel_MouseWheel;
            DoubleBufferPanel.MouseDown += DoubleBufferPanel_MouseDown;
            DoubleBufferPanel.MouseUp += DoubleBufferPanel_MouseUp;
        }

        private void DoubleBufferPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                _mouseUpPoint = e.Location;

            DrawRect();
        }

        private void DrawRect()
        {
            int width = _mouseUpPoint.X - _mouseDownPoint.X;
            int height = _mouseUpPoint.Y - _mouseDownPoint.Y;
            Rectangle rect = new Rectangle(_mouseDownPoint.X, _mouseDownPoint.Y, width, height);

            using (Graphics g = Graphics.FromImage(_originBitmap))
            {
                g.DrawRectangle(new Pen(Color.Yellow, 2), rect);
            }
        }

        private void DoubleBufferPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                _mouseDownPoint = e.Location;
        }


        private void DoubleBufferPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            if (ModifierKeys != Keys.Control)
                return;

            double ratio = 1;
            double oldRatio = ratio;
            int lines = e.Delta * SystemInformation.MouseWheelScrollLines / 120;

            if (lines > 0)
            {
                ratio *= 1.1;
            }
            else if (lines < 0)
            {
                ratio *= 0.9;
            }

            int width = Convert.ToInt32(pnlLiveView.Width * ratio);
            int height = Convert.ToInt32(pnlLiveView.Height * ratio);

            pnlLiveView.Width = width;
            pnlLiveView.Height = height;

            int x = e.X - pnlLiveView.Location.X;
            int y = e.Y - pnlLiveView.Location.Y;
            int oldImageX = (int)(x / oldRatio);
            int oldImageY = (int)(y / oldRatio);
            int newImageX = (int)(x / ratio);
            int newImageY = (int)(y / ratio);
            int newPointX = newImageX - oldImageX + pnlLiveView.Location.X;
            int newPointY = newImageY - oldImageY + pnlLiveView.Location.Y;

            System.Drawing.Point newImgPoint = new System.Drawing.Point(newPointX, newPointY);
            pnlLiveView.Location = newImgPoint;

            if (DoubleBufferPanel != null)
                DoubleBufferPanel.Invalidate();
        }

        private void DoubleBufferPanel_Paint(object sender, PaintEventArgs e)
        {
            Display(e.Graphics);
        }

        private void Display(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
        }

        private void DrawImage(Graphics g)
        {
            Bitmap newBmp = new Bitmap(pnlLiveView.Width, pnlLiveView.Height);
            Rectangle drawRect = new Rectangle(0, 0, newBmp.Width, newBmp.Height);

            string path = @"D:\lena_gray.bmp";
            _originBitmap = new Bitmap(path);

            g.DrawImage(_originBitmap, drawRect);

            if (newBmp != null)
            {
                newBmp.Dispose();
                newBmp = null;
            }
        }
        #endregion
    }
}
