using Cognex.VisionPro;
using Cognex.VisionPro.Display;
using Jastech.Framework.Winform.VisionPro.Helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static Jastech.Framework.Winform.VisionPro.Controls.CogDisplayControl;

namespace Jastech.Framework.Winform.VisionPro.Controls
{
    public partial class CogInspDisplayControl : UserControl
    {
        #region 필드
        private bool _updateViewRect { get; set; } = false;

        private List<ToolStripItem> _contextMenuItems;
        #endregion

        #region 속성
        private CogThumbnailControl CogThumbnail { get; set; }
        #endregion

        #region 이벤트
        public event DrawViewRectDelegate DrawViewRectEventHandler;
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
            
            DrawViewRectEventHandler += CogThumbnail.DrawViewRect;
            CogThumbnail.UpdateRectEventHandler += UpdateViewRect;
        }

        private void AddControls()
        {
            CogThumbnail = new CogThumbnailControl();
            CogThumbnail.Dock = DockStyle.Fill;
            pnlThumbnail.Controls.Add(CogThumbnail);
        }

        public delegate void EnableDele(bool isEnable);

        public void Enable(bool isEnable)
        {
            if (this.InvokeRequired)
            {
                EnableDele callback = Enable;
                BeginInvoke(callback, isEnable);
                return;
            }

            cogDisplay.Enabled = isEnable;
            CogThumbnail.Enabled = isEnable;
        }

        public void SetImage(ICogImage image, List<CogRectangleAffine> cogRectangleAffines, bool isDeepCopy = true)
        {
            if (image == null)
                return;
            
            lock(image)
            {
                _updateViewRect = true;
                if (isDeepCopy)
                    cogDisplay.Image = image.CopyBase(CogImageCopyModeConstants.CopyPixels);
                else
                    cogDisplay.Image = image;

                CogThumbnail.SetThumbnailImage(image, cogRectangleAffines);
            }
        }

        public void SetImage(ICogImage image, bool isDeepCopy = true)
        {
            if (image == null)
                return;

            lock (image)
            {
                if (isDeepCopy)
                    cogDisplay.Image = image.CopyBase(CogImageCopyModeConstants.CopyPixels);
                else
                    cogDisplay.Image = image;
                CogThumbnail.SetThumbnailImage(image, null);
            }
        }

        public void UpdateViewRect(CogRectangle rect, double ratio)
        {
            _updateViewRect = true;

            if (cogDisplay.Image != null)
            {
                double panPointX = (double)cogDisplay.Image.Width * ratio;
                double calcPanPointX = (cogDisplay.Image.Width / 2) - panPointX;
                cogDisplay.PanX = calcPanPointX;

                CogThumbnail.PrevViewRectangle.X = panPointX - (CogThumbnail.PrevViewRectangle.Width / 2.0);

                UpdateViewRect();
            }
        }

        public void ClearImage()
        {
            cogDisplay.StaticGraphics.Clear();
            cogDisplay.InteractiveGraphics.Clear();
            CogDisplayHelper.DisposeDisplay(cogDisplay);
            cogDisplay.Image = null;

            CogThumbnail?.DisposeImage();
        }

        public void ClearGraphic()
        {
            cogDisplay.StaticGraphics.Clear();
            cogDisplay.InteractiveGraphics.Clear();
        }

        public void ClearThumbnail()
        {
            CogThumbnail?.DisposeImage();
        }

        private void cogDisplay_Changed(object sender, CogChangedEventArgs e)
        {
            if (sender is CogRecordDisplay display)
            {
                if (display.Image == null)
                    return;

                if (_updateViewRect)
                {
                    _updateViewRect = false;
                    return;
                }
                string flagNames = e.GetStateFlagNames(sender);
                if (flagNames.Contains("SfAutoFitWithGraphics"))
                    return;

                if (flagNames.Contains("SfZoom") || flagNames.Contains("SfMaintainImageRegion"))
                {
                    if (display.Zoom < 0.001)
                        display.Zoom = 0.001;

                    if (display.Zoom > 10)
                        display.Zoom = 10;
                }

                if (flagNames == "SfZoom" || flagNames == "SfPanX" || flagNames == "SfPanY")
                {
                    //if (DeleteResultGraphics())
                    //    DeleteEventHandler?.Invoke(sender, e);

                    //MoveImageEventHandler?.Invoke(display.PanX, display.PanY, display.Zoom);
                }

                UpdateViewRect();
            }
        }

        private void UpdateViewRect()
        {
            CogRectangle viewRect = GetViewRectangle();
            if (viewRect != null)
                DrawViewRectEventHandler?.Invoke(viewRect);
        }

        public void UseAllContextMenu(bool useAllItems)
        {
            ToolStripItem[] menuItems;

            if (_contextMenuItems == null)
                _contextMenuItems = cogDisplay.ContextMenuStrip.Items.Cast<ToolStripItem>().ToList();

            if (useAllItems)
                menuItems = _contextMenuItems.ToArray();
            else
            {
                int startIndex = (int)CogContextItemName.Pointer;
                int takeCount = (int)CogContextItemName.ContextSpliter4 - startIndex;
                menuItems = _contextMenuItems.Skip(startIndex).Take(takeCount).ToArray();
            }

            cogDisplay.ContextMenuStrip.Items.Clear();
            if (menuItems != null)
                cogDisplay.ContextMenuStrip.Items.AddRange(menuItems);
        }

        public CogRectangle GetViewRectangle()
        {
            CogRectangle rect = new CogRectangle();
            double calcX, calcY;

            cogDisplay.GetTransform("#", "*").MapPoint(0, 0, out calcX, out calcY);

            int calcWidth = (int)(cogDisplay.DisplayRectangle.Width / cogDisplay.Zoom);
            int calcHeight = (int)(cogDisplay.DisplayRectangle.Height / cogDisplay.Zoom);

            if (calcWidth == 0 || calcHeight == 0)
                return null;

            rect.X = calcX;
            rect.Y = calcY;
            rect.Width = calcWidth;
            rect.Height = calcHeight;

            return rect;
        }
        #endregion
    }

    public enum CogContextItemName
    {
        Pointer = 0,                          // Pointer
        Pan,                                  // Pan
        Zoom_In,                              // Zoom In
        Zoom_Out,                             // Zoom Out
        Touch,                                // Touch

        ContextSpliter1,
        Pixel_Grid,                           // Pixel Grid
        Subpixel_Grid,                        // Subpixel Grid
        Show_Tool_Tips,                       // Show Tool Tips
        Zoom_Wheel,                           // Zoom Wheel

        ContextSpliter2,
        Fit_Image,                            // Fit Image
        Fit_Image_And_Graphics,               // Fit Image & Graphics
        Zoom_100_Percent,                     // Zoom 100%

        ContextSpliter3,
        Auto_Fit_Image,                       // Auto Fit Image
        Auto_Fit_Image_With_Graphics,         // Auto Fit Image With Graphics
        Maintain_Image_Region,                // Maintain Image Region

        ContextSpliter4,
        Colormap,                        // Colormap...
        Save_Image_to_File,              // Save Image to File...
        Increase_Touch_Distance,         // Increase Touch Distance
        Decrease_Touch_Distance,         // Decrease Touch Distance
    }
}
