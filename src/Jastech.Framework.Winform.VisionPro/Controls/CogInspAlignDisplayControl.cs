using Cognex.VisionPro;
using Jastech.Framework.Imaging.VisionPro;
using Jastech.Framework.Winform.VisionPro.Helper;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.VisionPro.Controls
{
    public partial class CogInspAlignDisplayControl : UserControl
    {
        #region 생성자
        public CogInspAlignDisplayControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void CogInspAlignDisplayControl_Load(object sender, System.EventArgs e)
        {
            cogLeftDisplay.MouseMode = Cognex.VisionPro.Display.CogDisplayMouseModeConstants.Pan;
            cogCenterDisplay.MouseMode = Cognex.VisionPro.Display.CogDisplayMouseModeConstants.Pan;
            cogRightDisplay.MouseMode = Cognex.VisionPro.Display.CogDisplayMouseModeConstants.Pan;
        }

        public void UpdateLeftDisplay(ICogImage cogImage, List<CogCompositeShape> shape, PointF centerPoint)
        {
            //CogDisplayHelper.DisposeDisplay(cogLeftDisplay);
            cogLeftDisplay.Image = cogImage;
            cogLeftDisplay.StaticGraphics.Clear();
            cogLeftDisplay.InteractiveGraphics.Clear();

            CogGraphicInteractiveCollection collect = new CogGraphicInteractiveCollection();

            foreach (var item in shape)
            {
                if(item != null)
                    collect.Add(item);
            }

            if(centerPoint.X != 0 && centerPoint.Y != 0)
            {
                cogLeftDisplay.InteractiveGraphics.AddList(collect, "Result", false);
                var gg = cogLeftDisplay.Zoom;
                cogLeftDisplay.Zoom = 0.5;
                cogLeftDisplay.PanX = (cogImage.Width / 2) - centerPoint.X;
                cogLeftDisplay.PanY = (cogImage.Height / 2) - centerPoint.Y;
            }
        }

        public void UpdateRightDisplay(ICogImage cogImage, List<CogCompositeShape> shape, PointF centerPoint)
        {
            cogRightDisplay.Image = cogImage;
            cogRightDisplay.StaticGraphics.Clear();
            cogRightDisplay.InteractiveGraphics.Clear();

            if (shape == null)
                return;

            CogGraphicInteractiveCollection collect = new CogGraphicInteractiveCollection();

            foreach (var item in shape)
            {
                if (item != null)
                    collect.Add(item);
            }

            cogRightDisplay.InteractiveGraphics.AddList(collect, "Result", false);
            if (centerPoint.X != 0 && centerPoint.Y != 0)
            {
                cogRightDisplay.Zoom = 0.5;
                cogRightDisplay.InteractiveGraphics.AddList(collect, "Result", false);
                cogRightDisplay.PanX = (cogImage.Width / 2) - centerPoint.X;
                cogRightDisplay.PanY = (cogImage.Height / 2) - centerPoint.Y;
            }
        }

        public void UpdateCenterDisplay(ICogImage cogImage)
        {
            CogDisplayHelper.DisposeDisplay(cogCenterDisplay);

            if(cogImage == null)
            {
                cogCenterDisplay.Image = cogLeftDisplay.Image;
            }
            else
            {
                cogCenterDisplay.Image = cogImage;
                cogCenterDisplay.PanX = (cogImage.Width / 2) - cogCenterDisplay.Image.Width / 2;
                cogCenterDisplay.PanY = (cogImage.Height / 2) - cogCenterDisplay.Image.Height / 2;
            }
            
            cogCenterDisplay.StaticGraphics.Clear();
            cogCenterDisplay.InteractiveGraphics.Clear();
        }

        public void SetDisplayToCenter(CogRecordDisplay display, Point point)
        {
            if (display.Image == null)
                return;

            if (point != null)
            {
                if (point.X == 0 && point.Y == 0)
                    return;

                display.PanX = display.Image.Width / 2 - point.X;
                display.PanY = display.Image.Height / 2 - point.Y;
            }
        }

        public void ClearImage()
        {
            CogDisplayHelper.DisposeDisplay(cogLeftDisplay);
            cogLeftDisplay.InteractiveGraphics.Clear();
            cogLeftDisplay.Image = null;

            CogDisplayHelper.DisposeDisplay(cogRightDisplay);
            cogRightDisplay.InteractiveGraphics.Clear();
            cogRightDisplay.Image = null;
        }

        public void ClearGraphics()
        {
            cogLeftDisplay.InteractiveGraphics.Clear();
            cogRightDisplay.InteractiveGraphics.Clear();
        }
        #endregion
    }
}
