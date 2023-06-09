﻿using Cognex.VisionPro;
using Jastech.Framework.Winform.VisionPro.Helper;
using System;
using System.Windows.Forms;
using static Jastech.Framework.Winform.VisionPro.Controls.CogDisplayControl;

namespace Jastech.Framework.Winform.VisionPro.Controls
{
    public partial class CogInspDisplayControl : UserControl
    {
        #region 필드
        private bool _updateViewRect { get; set; } = false;
        #endregion

        #region 속성
        private CogThumbnailControl CogThumbnail { get; set; }
        #endregion

        #region 이벤트
        public event DrawViewRectDelegate DrawViewRectEventHandler;
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        public CogInspDisplayControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void CogInspDisplayControl_Load(object sender, EventArgs e)
        {
            cogDisplay.MouseMode = Cognex.VisionPro.Display.CogDisplayMouseModeConstants.Pan;

            AddControls();

            // 이벤트 등록(중요)
            CogThumbnail.UpdateRectEventHandler += UpdateViewRect;
            DrawViewRectEventHandler += CogThumbnail.DrawViewRect;

            //// TestCode
            //string path = @"D:\Tab1.bmp";
            //if(File.Exists(path))
            //{
            //    ICogImage cogImage = CogImageHelper.Load(path);
            //    SetImage(cogImage);
            //}
        }

        private void AddControls()
        {
            CogThumbnail = new CogThumbnailControl();
            CogThumbnail.Dock = DockStyle.Fill;
            pnlThumbnail.Controls.Add(CogThumbnail);
        }

        public void SetImage(ICogImage image)
        {
            if (image == null)
                return;
            CogDisplayHelper.DisposeDisplay(cogDisplay);
            cogDisplay.Image = image;
            CogThumbnail.SetThumbnailImage(image);
        }

        public void UpdateViewRect(CogRectangle rect, double ratio)
        {
            _updateViewRect = true;

            double panPointX = (double)cogDisplay.Image.Width * ratio;
            panPointX = (cogDisplay.Image.Width / 2) - panPointX;
            cogDisplay.PanX = panPointX;
        }

        public void Clear()
        {
            cogDisplay.StaticGraphics.Clear();
            cogDisplay.InteractiveGraphics.Clear();
            cogDisplay.Image = null;
        }

        private void cogDisplay_Changed(object sender, CogChangedEventArgs e)
        {
            if (sender is CogRecordDisplay display)
            {
                if (display.Image == null)
                    return;

                if (display.Zoom < 0.2)
                    display.Zoom = 0.2;

                if (display.Zoom > 10)
                    display.Zoom = 10;

                if (_updateViewRect)
                {
                    _updateViewRect = false;
                    return;
                }

                UpdateViewRect();
            }
        }

        private void UpdateViewRect()
        {
            CogRectangle viewRect = GetViewRectangle();
            DrawViewRectEventHandler?.Invoke(viewRect);
        }

        public CogRectangle GetViewRectangle()
        {
            CogRectangle rect = new CogRectangle();
            double calcX, calcY;

            cogDisplay.GetTransform("#", "*").MapPoint(0, 0, out calcX, out calcY);

            int calcWidth = (int)(cogDisplay.DisplayRectangle.Width / cogDisplay.Zoom);
            int calcHeight = (int)(cogDisplay.DisplayRectangle.Height / cogDisplay.Zoom);

            rect.X = calcX;
            rect.Y = calcY;
            rect.Width = calcWidth;
            rect.Height = calcHeight;

            return rect;
        }
        #endregion
    }
}
