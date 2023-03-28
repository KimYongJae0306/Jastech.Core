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

namespace Jastech.Framework.Winform.VisionPro.Controls
{
    public partial class CogThumbnailControl : UserControl
    {
        private ICogImage ThumbnailImage { get; set; } = null;

        private double Scale { get; set; }

        public CogThumbnailControl()
        {
            InitializeComponent();
        }

        public void SetThumbnailImage(ICogImage cogImage)
        {
            int newHeight = this.cogThumbnailDisplay.Height;
            Scale = (double)newHeight / cogImage.Height;
            int newWidth = (int)((double)cogImage.Width * Scale);

            ThumbnailImage = cogImage.ScaleImage(newWidth, newHeight);
            cogThumbnailDisplay.Image = ThumbnailImage;

        }

        //private Size GetCogDisplayHeight
    }
}
