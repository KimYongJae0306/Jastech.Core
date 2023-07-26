using Cognex.VisionPro;
using Jastech.Framework.Winform.VisionPro.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shapes;

namespace Jastech.Framework.Winform.VisionPro.Controls
{
    public partial class CogPreAlignDisplayControl : UserControl
    {
        #region 필드
        #endregion

        #region 속성
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        public CogPreAlignDisplayControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        public void UpdateLeftDisplay(ICogImage cogImage, List<CogCompositeShape> shape)
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
            cogLeftDisplay.Fit();
        }

        public void UpdateRightDisplay(ICogImage cogImage, List<CogCompositeShape> shape)
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
            cogRightDisplay.Fit();
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
        #endregion
    }
}
