using Cognex.VisionPro;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.VisionPro.Controls
{
    public partial class CogTeachingDisplayControl : UserControl
    {
        #region 속성
        private CogDisplayControl CogDisplay { get; set; }

        private CogThumbnailControl CogThumbnail { get; set; }
        #endregion

        #region 이벤트
        public event EventHandler DeleteEventHandler;
        #endregion

        #region 생성자
        public CogTeachingDisplayControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void CogTeachingDisplayControl_Load(object sender, EventArgs e)
        {
            AddControls();

            // 이벤트 등록(중요)
            CogDisplay.DrawViewRectEventHandler += CogThumbnail.DrawViewRect;
            CogDisplay.ImageChanged += SetThumbnailImage;
            CogThumbnail.UpdateRectEventHandler += CogDisplay.UpdateViewRect;

            CogDisplay.DeleteEventHandler += DeleteEventHandler;
        }

        private void AddControls()
        {
            CogDisplay = new CogDisplayControl();
            CogDisplay.Dock = DockStyle.Fill;
            pnlDisplay.Controls.Add(CogDisplay);

            CogThumbnail = new CogThumbnailControl();
            CogThumbnail.Dock = DockStyle.Fill;
            pnlThumbnail.Controls.Add(CogThumbnail);
        }

        public void SetImage(ICogImage image)
        {
            CogDisplay.SetImage(image);
            //CogThumbnail.SetThumbnailImage(image, null);
        }

        public void SetThumbnailImage(ICogImage image)
        {
            CogThumbnail.SetThumbnailImage(image);
        }

        public void SetThumbnailImage(ICogImage image, List<CogRectangleAffine> cogRectangleAffines)
        {
            CogDisplay.SetImage(image);
            CogThumbnail.SetThumbnailImage(image, cogRectangleAffines);
        }

        public CogDisplayControl GetDisplay()
        {
            return CogDisplay;
        }

        public void DisposeImage()
        {
            CogDisplay.DisposeImage();
            CogThumbnail.DisposeImage();
        }
        #endregion
    }
}
