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
    public partial class ImageViewerControl : UserControl
    {
        #region 필드
        #endregion

        #region 속성
        private DrawBoxControl DrawBoxControl { get; set; } = null;

        public List<ImagePreviewControl> ImagePreviewControlList { get; private set; } = new List<ImagePreviewControl>();

        private List<ImageInfo> ImageInfoList { get; set; } = null;
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        public ImageViewerControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void ImageViewerControl_Load(object sender, EventArgs e)
        {
            AddControl();
        }

        public void SetImageInfo(List<ImageInfo> imageInfoList)
        {
            ClearImageInfoList();

            ImageInfoList = imageInfoList;

            InitializeUI();
        }

        public void AddControl()
        {
            DrawBoxControl = new DrawBoxControl();
            DrawBoxControl.Dock = DockStyle.Fill;
            DrawBoxControl.ViewColor = Color.Black;
            DrawBoxControl.DisplayMode = DisplayMode.Panning;
            DrawBoxControl.UseGrayLevel = true;
            pnlView.Controls.Add(DrawBoxControl);
        }

        private void InitializeUI()
        {
            int controlWidth = 100;
            int interval = 10;
            Point point = new Point(0, 0);

            foreach (ImageInfo imageInfo in ImageInfoList)
            {
                ImagePreviewControl imagePreviewControl = new ImagePreviewControl();
                //imagePreviewControl.Dock = DockStyle.Fill;
                imagePreviewControl.SelectedImageEventHandler += ImagePreviewControl_SelectedImageEventHandler;
                imagePreviewControl.Size = new Size(controlWidth, (int)(pnlPreview.Height));
                imagePreviewControl.Location = point;
                imagePreviewControl.SetImage(imageInfo);

                pnlPreview.Controls.Add(imagePreviewControl);
                point.X += controlWidth + interval;

                ImagePreviewControlList.Add(imagePreviewControl);
            }
        }

        private void ImagePreviewControl_SelectedImageEventHandler(ImageInfo imageInfo)
        {
            ImagePreviewControlList.ForEach(x => x.ClearSelectedColor());

            Bitmap cloneBitmap = new Bitmap(imageInfo.OriginBitmap);
            DrawBoxControl?.SetImage(cloneBitmap);
        }

        private void ClearImageInfoList()
        {
            foreach (var item in ImagePreviewControlList)
                item.SelectedImageEventHandler -= ImagePreviewControl_SelectedImageEventHandler;

            ImagePreviewControlList.Clear();
            pnlPreview.Controls.Clear();
        }
        #endregion
    }
}
