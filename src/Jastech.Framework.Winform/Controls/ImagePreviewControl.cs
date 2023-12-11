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
        public Bitmap OrgImage { get; set; } = null;

        public Color ViewColor { get; set; } = Color.FromArgb(52, 52, 52);
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
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
        }

        public void SetImage(Bitmap bmp)
        {
            lock (_lock)
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

        public void SetSelectImage()
        {

        }
        #endregion
    }
}
