using Cognex.VisionPro;
using Emgu.CV.Rapid;
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
            cogThumbnailDisplay.StaticGraphics.Clear();
            cogThumbnailDisplay.InteractiveGraphics.Clear();
            cogThumbnailDisplay.Image = null;

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
            cogThumbnailDisplay.StaticGraphics.Clear();
            cogThumbnailDisplay.InteractiveGraphics.Clear();
            CogDisplayHelper.DisposeDisplay(cogThumbnailDisplay);
            cogThumbnailDisplay.Image = null;
        }

        private void ViewRect_Changed(object sender, CogChangedEventArgs e)
        {
            var rect = sender as CogRectangle;

            Point mousePoint = new Point(MousePosition.X, MousePosition.Y);
            Point clientPoint = cogThumbnailDisplay.PointToClient(mousePoint);
            double ratio = clientPoint.X / (double)cogThumbnailDisplay.Width;

            UpdateRectEventHandler?.Invoke(rect, ratio);

            //DrawViewRect(rect);
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

        private bool _isThumbnailMove = false;

        private void cogThumbnailDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender.GetType() == cogThumbnailDisplay.GetType())
            {
                UpdateDisplayFromThumbnailEvent(sender);
                ViewRect_Changed(sender, null);
                _isThumbnailMove = true;
            }
        }

        private void cogThumbnailDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender.GetType() == cogThumbnailDisplay.GetType() && _isThumbnailMove)
            {
                UpdateDisplayFromThumbnailEvent(sender);
                ViewRect_Changed(sender, null);
            }
        }

        private void cogThumbnailDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            _isThumbnailMove = false;
        }

        void UpdateDisplayFromThumbnailEvent(object sender)
        {
            if (cogThumbnailDisplay.Image == null)
                return;

            CogRecordDisplay thumbnailDisplay = (CogRecordDisplay)sender;

            CogRectangle rect = new CogRectangle();
            rect.Width = _prevViewRectangle.Width;
            rect.Height = _prevViewRectangle.Height;

            int x = MousePosition.X;
            int y = MousePosition.Y;
            Point mousePos = new Point(x, y);
            Point mousePosPtoClient = thumbnailDisplay.PointToClient(mousePos);
            Point mousePosPtoScreen = thumbnailDisplay.PointToScreen(mousePos);
            double ratio = (double)mousePosPtoClient.X / (double)thumbnailDisplay.Width;
            double panPointX = (double)thumbnailDisplay.Image.Width * ratio;
            panPointX = (thumbnailDisplay.Image.Width / 2) - panPointX;
            //thumbnailDisplay.PanX = panPointX;

            var t = cogThumbnailDisplay.Zoom;

            int gg = 0;

            rect.X = MousePosition.X - (int)(_prevViewRectangle.Width * ratio / 2.0);
            rect.Y = MousePosition.Y - (int)(_prevViewRectangle.Height * ratio / 2.0);
            rect.Color = CogColorConstants.Yellow;
            rect.LineWidthInScreenPixels = 2;
            rect.Interactive = true;
            rect.GraphicDOFEnable = CogRectangleDOFConstants.Position;
            rect.Changed += ViewRect_Changed;

            cogThumbnailDisplay.StaticGraphics.Clear();
            cogThumbnailDisplay.InteractiveGraphics.Clear();
            AddGraphics("ViewRect", rect);

            //Point mousePos = new Point(x, y); //프로그램 내 좌표
            //Point mousePosPtoClient = thumbnailDisplay.PointToClient(mousePos);  //picbox 내 좌표, 해당 좌표 할당
            //Point mousePosPtoScreen = thumbnailDisplay.PointToScreen(mousePos);  //스크린 내 좌표 (좌우 스크린 합친듯?)

            //this.Text = x.ToString() + ", " + y.ToString() +
            //    "//, " + mousePosPtoClient.X.ToString() + ", " + mousePosPtoClient.Y.ToString() + "//width : " + thumbnailDisplay.Width.ToString();

            //double ratio = (double)mousePosPtoClient.X / (double)thumbnailDisplay.Width;

            //double panPointX = (double)_cogRecordDisplay.Image.Width * ratio;

            //if (_cogRecordDisplay.Zoom > 0 && _cogRecordDisplay.Zoom < 0.2)
            //    _cogRecordDisplay.Zoom = 0.5;

            //panPointX = (_cogRecordDisplay.Image.Width / 2) - panPointX;
            //_cogRecordDisplay.PanX = panPointX;
        }
    }
}
