﻿using Cognex.VisionPro;
using Jastech.Framework.Imaging.VisionPro;
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
        public void UpdateLeftDisplay(ICogImage cogImage, List<CogCompositeShape> shapes)
        {
            lock(cogLeftDisplay)
            {
                CogDisplayHelper.DisposeDisplay(cogLeftDisplay);

                if (cogLeftDisplay.Image != null)
                    cogLeftDisplay.Image = null;

                cogLeftDisplay.Image = cogImage;
                cogLeftDisplay.StaticGraphics.Clear();
                cogLeftDisplay.InteractiveGraphics.Clear();

                if (shapes == null)
                    return;

                foreach (var item in shapes)
                {
                    if (item != null)
                        cogLeftDisplay.StaticGraphics.Add(item as ICogGraphic, "Result");
                }

                cogLeftDisplay.Fit();
            }
        }

        public void UpdateRightDisplay(ICogImage cogImage, List<CogCompositeShape> shapes)
        {
            lock(cogRightDisplay)
            {
                CogDisplayHelper.DisposeDisplay(cogRightDisplay);
                if (cogRightDisplay.Image != null)
                    cogRightDisplay.Image = null;

                cogRightDisplay.Image = cogImage;

                cogRightDisplay.StaticGraphics.Clear();
                cogRightDisplay.InteractiveGraphics.Clear();

                if (shapes == null)
                    return;

                foreach (var item in shapes)
                {
                    if (item != null)
                        cogRightDisplay.StaticGraphics.Add(item as ICogGraphic, "Result");
                }

                cogRightDisplay.Fit();
            }
        }

        public void ClearImage()
        {
            lock(cogLeftDisplay)
            {
                CogDisplayHelper.DisposeDisplay(cogLeftDisplay);
                cogLeftDisplay.InteractiveGraphics.Clear();
                cogLeftDisplay.Image = null;
            }

            lock (cogRightDisplay)
            {
                CogDisplayHelper.DisposeDisplay(cogRightDisplay);
                cogRightDisplay.InteractiveGraphics.Clear();
                cogRightDisplay.Image = null;
            }
        }
        #endregion
    }
}
