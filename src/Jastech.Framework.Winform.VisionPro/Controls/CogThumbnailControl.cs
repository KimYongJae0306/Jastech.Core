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
        private CogRectangle _prevViewRectangle { get; set; }

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

        public void DrawViewRect(CogRectangle rect)
        {
            if (Scale == 0)
                return;

            CogRectangle viewRect = CalcViewRect(rect);

            if (Equals(viewRect, _prevViewRectangle))
                return;

            cogThumbnailDisplay.StaticGraphics.Clear();
            cogThumbnailDisplay.InteractiveGraphics.Clear();
            AddGraphics("ViewRect", viewRect);

            _prevViewRectangle = viewRect;
        }

        private CogRectangle CalcViewRect(CogRectangle rect)
        {
            int x = (int)((double)rect.X * Scale);
            int y = (int)((double)rect.Y * Scale);
            int width = (int)((double)rect.Width * Scale);
            int height = (int)((double)rect.Width * Scale);

            CogRectangle viewRect = new CogRectangle
            {
                X = x,
                Y = y,
                Width = width,
                Height = height,
            };

            viewRect.Color = CogColorConstants.Yellow;
            viewRect.LineWidthInScreenPixels = 2;
            return viewRect;
        }

        public void AddGraphics(string groupName, ICogRegion cogRegion, bool checkForDuplicates = false)
        {
            if (cogThumbnailDisplay.Image == null || cogRegion == null)
                return;

            cogThumbnailDisplay.InteractiveGraphics.Add(cogRegion as ICogGraphicInteractive, groupName, false);
        }

        private bool Equals(CogRectangle rect1, CogRectangle rect2)
        {
            if (rect1 == null || rect2 == null)
                return false;
            if (rect1.X == rect2.X && rect1.Y == rect2.Y && rect1.Width == rect2.Width && rect1.Height == rect2.Height)
                return true;

            return false;
        }
    }
}
