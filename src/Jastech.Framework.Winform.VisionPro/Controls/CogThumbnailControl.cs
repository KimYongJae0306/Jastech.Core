﻿using Cognex.VisionPro;
using Jastech.Framework.Imaging.VisionPro;
using Jastech.Framework.Winform.VisionPro.Helper;
using System.Drawing;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.VisionPro.Controls
{
    public partial class CogThumbnailControl : UserControl
    {
        #region 필드
        private CogRectangle _prevViewRectangle { get; set; }
        #endregion

        #region 속성
        private ICogImage ThumbnailImage { get; set; } = null;

        private double _scale { get; set; } = 0.0;
        #endregion

        #region 이벤트
        public event UpdateRectDelegate UpdateRectEventHandler;
        #endregion

        #region 델리게이트
        public delegate void UpdateRectDelegate(CogRectangle rect, double ratio);
        #endregion

        #region 생성자
        public CogThumbnailControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        public void SetThumbnailImage(ICogImage cogImage)
        {
            //if (cogImage == null)
            //    return;

            //Cognex.VisionPro.ImageProcessing.CogImageConvertTool tlqkf = new Cognex.VisionPro.ImageProcessing.CogImageConvertTool();
            //tlqkf.InputImage = cogImage;
            //tlqkf.Run();

            //CogImage8Grey c8 = tlqkf.OutputImage as CogImage8Grey;


            if (cogImage == null)
                return;

            CogImage8Grey cogImage8Grey = new CogImage8Grey();

            if (cogImage is CogImage24PlanarColor)
                cogImage8Grey = VisionProImageHelper.Convert24PlanarColorToGrey(cogImage as CogImage24PlanarColor);
            else if (cogImage is CogImage8Grey)
                cogImage8Grey = cogImage as CogImage8Grey;

            int newHeight = this.cogThumbnailDisplay.Height;
            _scale = (double)newHeight / cogImage8Grey.Height;
            int newWidth = (int)((double)cogImage8Grey.Width * _scale);

            CogDisplayHelper.DisposeDisplay(cogThumbnailDisplay);
            ThumbnailImage = cogImage8Grey.ScaleImage(newWidth, newHeight);
            cogThumbnailDisplay.Image = ThumbnailImage;
            cogThumbnailDisplay.Fit();
        }

        public void DrawViewRect(CogRectangle rect)
        {
            if (_scale == 0)
                return;

            if (Equals(rect, _prevViewRectangle))
                return;
 
            rect.Color = CogColorConstants.Yellow;
            rect.LineWidthInScreenPixels = 2;
            rect.Interactive = true;
            rect.GraphicDOFEnable = CogRectangleDOFConstants.Position;
            rect.Changed += ViewRect_Changed;

            cogThumbnailDisplay.StaticGraphics.Clear();
            cogThumbnailDisplay.InteractiveGraphics.Clear();
            AddGraphics("ViewRect", rect);
            _prevViewRectangle = rect;
        }

        public void DisposeImage()
        {
            CogDisplayHelper.DisposeDisplay(cogThumbnailDisplay);
        }

        private void ViewRect_Changed(object sender, CogChangedEventArgs e)
        {
            var rect = sender as CogRectangle;

            Point mousePoint = new Point(MousePosition.X, MousePosition.Y);
            Point clientPoint = cogThumbnailDisplay.PointToClient(mousePoint);
            double ratio = clientPoint.X / (double)cogThumbnailDisplay.Width;

            UpdateRectEventHandler?.Invoke(rect, ratio);
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
        #endregion
    }
}
