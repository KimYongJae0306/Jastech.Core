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
using Jastech.Framework.Winform.VisionPro.Helper;

namespace Jastech.Framework.Winform.VisionPro.Controls
{
    public partial class CogInspAlignDisplayControl : UserControl
    {
        public CogInspAlignDisplayControl()
        {
            InitializeComponent();
        }

        public void UpdateLeftDisplay(ICogImage cogImage, List<CogCompositeShape> shape, Point viewPoint)
        {
            CogDisplayHelper.DisposeDisplay(cogLeftDisplay);

            if (cogLeftDisplay.Image != null)
                cogLeftDisplay.Image = null;

            cogLeftDisplay.Image = cogImage;
            cogLeftDisplay.StaticGraphics.Clear();
            cogLeftDisplay.InteractiveGraphics.Clear();

            CogGraphicInteractiveCollection collect = new CogGraphicInteractiveCollection();

            foreach (var item in shape)
                collect.Add(item);

            cogLeftDisplay.InteractiveGraphics.AddList(collect, "Result", false);

            SetDisplayToCenter(cogLeftDisplay, viewPoint);
        }

        public void UpdateRightDisplay(ICogImage cogImage, List<CogCompositeShape> shape, Point viewPoint)
        {
            CogDisplayHelper.DisposeDisplay(cogRightDisplay);
            if (cogRightDisplay.Image != null)
                cogRightDisplay.Image = null;

            cogRightDisplay.Image = cogImage;

            cogRightDisplay.StaticGraphics.Clear();
            cogRightDisplay.InteractiveGraphics.Clear();

            if (shape == null)
                return;

            CogGraphicInteractiveCollection collect = new CogGraphicInteractiveCollection();

            foreach (var item in shape)
                collect.Add(item);

            cogRightDisplay.InteractiveGraphics.AddList(collect, "Result", false);
            SetDisplayToCenter(cogRightDisplay, viewPoint);
        }

        public void SetDisplayToCenter(CogRecordDisplay display, Point point)
        {
            if (display.Image == null)
                return;

            if(point != null)
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
    }
}
