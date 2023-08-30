using Cognex.VisionPro;
using Emgu.CV.Rapid;
using Jastech.Framework.Imaging.VisionPro;
using Jastech.Framework.Winform.VisionPro.Helper;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.VisionPro.Controls
{
    public partial class CogThumbnailControl : UserControl
    {
        #region 필드
        private double _scale { get; set; } = 0.0;

        private bool _isThumbnailMove = false;
        #endregion

        #region 속성
        private ICogImage ThumbnailImage { get; set; } = null;

        public CogRectangle PrevViewRectangle { get; set; }

        public bool isUpdate { get; set; } = false;
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

        private void CogThumbnailControl_Load(object sender, System.EventArgs e)
        {
            cogThumbnailDisplay.ContextMenuStrip.Items.Clear();
        }

        public void SetThumbnailImage(ICogImage cogImage)
        {
            isUpdate = true;
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

        public void SetThumbnailImage(ICogImage cogImage, List<CogRectangleAffine> cogRectangleAffines)
        {
            isUpdate = true;
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

            if (cogRectangleAffines != null)
            {
                CogGraphicCollection collect = new CogGraphicCollection();
                foreach (var affine in cogRectangleAffines)
                {
                    CogRectangleAffine calcAffine = new CogRectangleAffine();
                    PointF leftTop = new PointF((float)affine.CornerOriginX, (float)affine.CornerOriginY);
                    PointF rightTop = new PointF((float)affine.CornerXX, (float)affine.CornerXY);
                    PointF leftBottom = new PointF((float)affine.CornerYX, (float)affine.CornerYY);

                    var newAffine = VisionProShapeHelper.ConvertToCogRectAffine(leftTop, rightTop, leftBottom);
                    newAffine.LineWidthInScreenPixels = 1;
                    newAffine.Color = CogColorConstants.Red;

                    collect.Add(newAffine);
                }
                if (collect.Count > 0)
                    cogThumbnailDisplay.StaticGraphics.AddList(collect, "NG");
            }
            
            DrawViewRect(PrevViewRectangle);
        }

        public void DrawViewRect(CogRectangle rect)
        {
            if (rect == null)
                return;
            
            //if(rect != null)
            //{
            //    if (Equals(rect, _prevViewRectangle))
            //        return;
            //}
 
            rect.Color = CogColorConstants.Yellow;
            rect.LineWidthInScreenPixels = 2;
            rect.Interactive = true;
            rect.GraphicDOFEnable = CogRectangleDOFConstants.Position;
            rect.Changed += ViewRect_Changed;

            //cogThumbnailDisplay.StaticGraphics.Clear();
            //cogThumbnailDisplay.InteractiveGraphics.Clear();

            string groupName = "ViewRect";
            if(IsContainGroupNameInInteractiveGraphics(groupName))
                cogThumbnailDisplay.InteractiveGraphics.Remove(groupName);

            AddGraphics(groupName, rect);
            PrevViewRectangle = rect;
        }


        private bool IsContainGroupNameInInteractiveGraphics(string groupName)
        {
            foreach (var value in cogThumbnailDisplay.InteractiveGraphics.ZOrderGroups)
            {
                if (groupName == (string)value)
                    return true;
            }
            return false;
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
            if (isUpdate == false)
                return;

            isUpdate = false;
            var rect = sender as CogRectangle;

            Point mousePoint = new Point(MousePosition.X, MousePosition.Y);
            Point clientPoint = cogThumbnailDisplay.PointToClient(mousePoint);
            double ratio = clientPoint.X / (double)(cogThumbnailDisplay.Width);

            UpdateRectEventHandler?.Invoke(rect, ratio);

            isUpdate = true;
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

        private void cogThumbnailDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender.GetType() == cogThumbnailDisplay.GetType())
            {
                ViewRect_Changed(sender, null);
                _isThumbnailMove = true;
            }
        }

        private void cogThumbnailDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender.GetType() == cogThumbnailDisplay.GetType() && _isThumbnailMove)
            {
                ViewRect_Changed(sender, null);
            }
        }

        private void cogThumbnailDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            _isThumbnailMove = false;
        }
        #endregion
    }
}
