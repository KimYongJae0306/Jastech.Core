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

        private ImagePreviewControl ImagePreviewControl { get; set; } = null;
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
        public void AddControl()
        {
            DrawBoxControl = new DrawBoxControl();
            DrawBoxControl.Dock = DockStyle.Fill;
            DrawBoxControl.ViewColor = Color.Black;
            DrawBoxControl.DisplayMode = DisplayMode.Panning;
            DrawBoxControl.UseGrayLevel = true;
            pnlView.Controls.Add(DrawBoxControl);

            ImagePreviewControl = new ImagePreviewControl();
            ImagePreviewControl.Dock = DockStyle.Fill;
            pnlPreview.Controls.Add(ImagePreviewControl);
        }
        #endregion
    }
}
