using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.Controls
{
    public partial class ImagePreviewControl : UserControl
    {
        #region 필드
        public object _lock = new object();
        #endregion

        #region 속성
        //public Bitmap OrgImage { get; set; } = null;

        public ImageInfo ImageInfo { get; set; } = null;

        public Color ViewColor { get; set; } = Color.FromArgb(52, 52, 52);
        #endregion

        #region 이벤트
        public event SelectedImageDelegate SelectedImageEventHandler;
        #endregion

        #region 델리게이트
        public delegate void SelectedImageDelegate(ImageInfo imageInfo);
        #endregion

        #region 생성자
        public ImagePreviewControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void ImagePreviewControl_Load(object sender, EventArgs e)
        {
            pbxDisplay.BackColor = ViewColor;
            pbxDisplay.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void SetImage(ImageInfo imageInfo)
        {
            lock (_lock)
            {
                if (ImageInfo != null)
                    ImageInfo.Dispose();

                ImageInfo = new ImageInfo();
                ImageInfo = imageInfo;
            }

            pbxDisplay.Invalidate();
            lblImageName.Text = imageInfo.ImageName;
        }

        public void SetSelectImage()
        {
            SelectedImageEventHandler?.Invoke(ImageInfo);
            SetSelectedColor();
        }

        private void pbxDisplay_Click(object sender, EventArgs e)
        {
            SetSelectImage();
        }

        public void ClearSelectedColor()
        {
            pnlImagePreview.BackColor = Color.Transparent;
        }

        private void SetSelectedColor()
        {
            pnlImagePreview.BackColor = Color.White;
        }

        private void pbxDisplay_Paint(object sender, PaintEventArgs e)
        {
            lock (_lock)
            {
                if (ImageInfo == null)
                    return;

                Graphics g = e.Graphics;
                Color color = Color.FromArgb(52, 52, 52);
                g.Clear(color);

                Bitmap bmp = ImageInfo.OriginBitmap;
                Rectangle rect = new Rectangle(0, 0, pbxDisplay.Width, pbxDisplay.Height);
                g.DrawImage(bmp, rect);
            }
        }

        private void pnlImagePreview_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, pnlImagePreview.DisplayRectangle, pnlImagePreview.BackColor, 1, ButtonBorderStyle.Solid,
                                                                    pnlImagePreview.BackColor, 1, ButtonBorderStyle.Solid,
                                                                    pnlImagePreview.BackColor, 1, ButtonBorderStyle.Solid,
                                                                    pnlImagePreview.BackColor, 1, ButtonBorderStyle.Solid);
        }
        #endregion
    }

    public class ImageInfo
    {
        public Bitmap OriginBitmap { get; set; } = null;

        public string ImagePath { get; set; } = string.Empty;

        public string ImageName { get; set; } = string.Empty;

        public void Dispose()
        {
            OriginBitmap?.Dispose();
            OriginBitmap = null;
            ImagePath = string.Empty;
        }
    }
}
