﻿using Cognex.VisionPro;
using System;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.VisionPro.Controls
{
    public partial class CogTeachingDisplayControl : UserControl
    {
        private CogDisplayControl CogDisplay { get; set; }

        private CogThumbnailControl CogThumbnail { get; set; }

        public event EventHandler DeleteEventHandler;

        public CogTeachingDisplayControl()
        {
            InitializeComponent();
        }

        private void CogTeachingDisplayControl_Load(object sender, EventArgs e)
        {
            AddControls();

            // 이벤트 등록(중요)
            CogDisplay.DrawViewRectEventHandler += CogThumbnail.DrawViewRect;
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
            CogThumbnail.SetThumbnailImage(image);
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
    }
}
