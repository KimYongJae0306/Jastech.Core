using Cognex.VisionPro;
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
            cogRightDisplay.MouseMode = Cognex.VisionPro.Display.CogDisplayMouseModeConstants.Pan;
        }

        public void UpdateLeftDisplay(ICogImage cogImage, List<CogCompositeShape> shape)
        {
            //CogDisplayHelper.DisposeDisplay(cogLeftDisplay);
            cogLeftDisplay.Image = cogImage;
            cogLeftDisplay.StaticGraphics.Clear();
            cogLeftDisplay.InteractiveGraphics.Clear();

            CogGraphicInteractiveCollection collect = new CogGraphicInteractiveCollection();

            foreach (var item in shape)
                collect.Add(item);

            cogLeftDisplay.InteractiveGraphics.AddList(collect, "Result", false);
        }

        public void UpdateRightDisplay(ICogImage cogImage, List<CogCompositeShape> shape)
        {
            cogRightDisplay.Image = cogImage;
            cogRightDisplay.StaticGraphics.Clear();
            cogRightDisplay.InteractiveGraphics.Clear();

            if (shape == null)
                return;

            CogGraphicInteractiveCollection collect = new CogGraphicInteractiveCollection();

            foreach (var item in shape)
                collect.Add(item);

            cogRightDisplay.InteractiveGraphics.AddList(collect, "Result", false);
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
