namespace Jastech.Framework.Winform.VisionPro.Controls
{
    partial class CogInspDisplayControl
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CogInspDisplayControl));
            this.tfpnlContainer = new System.Windows.Forms.TableLayoutPanel();
            this.pnlThumbnail = new System.Windows.Forms.Panel();
            this.pnlDisplay = new System.Windows.Forms.Panel();
            this.cogDisplay = new Cognex.VisionPro.CogRecordDisplay();
            this.tfpnlContainer.SuspendLayout();
            this.pnlDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // tfpnlContainer
            // 
            this.tfpnlContainer.ColumnCount = 1;
            this.tfpnlContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tfpnlContainer.Controls.Add(this.pnlThumbnail, 0, 1);
            this.tfpnlContainer.Controls.Add(this.pnlDisplay, 0, 0);
            this.tfpnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tfpnlContainer.Location = new System.Drawing.Point(0, 0);
            this.tfpnlContainer.Name = "tfpnlContainer";
            this.tfpnlContainer.RowCount = 2;
            this.tfpnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tfpnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tfpnlContainer.Size = new System.Drawing.Size(820, 381);
            this.tfpnlContainer.TabIndex = 6;
            // 
            // pnlThumbnail
            // 
            this.pnlThumbnail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.pnlThumbnail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlThumbnail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlThumbnail.Location = new System.Drawing.Point(0, 331);
            this.pnlThumbnail.Margin = new System.Windows.Forms.Padding(0);
            this.pnlThumbnail.Name = "pnlThumbnail";
            this.pnlThumbnail.Size = new System.Drawing.Size(820, 50);
            this.pnlThumbnail.TabIndex = 3;
            // 
            // pnlDisplay
            // 
            this.pnlDisplay.Controls.Add(this.cogDisplay);
            this.pnlDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDisplay.Location = new System.Drawing.Point(3, 2);
            this.pnlDisplay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlDisplay.Name = "pnlDisplay";
            this.pnlDisplay.Size = new System.Drawing.Size(814, 327);
            this.pnlDisplay.TabIndex = 0;
            // 
            // cogDisplay
            // 
            this.cogDisplay.ColorMapLowerClipColor = System.Drawing.SystemColors.AppWorkspace;
            this.cogDisplay.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay.ColorMapUpperClipColor = System.Drawing.SystemColors.AppWorkspace;
            this.cogDisplay.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisplay.DoubleTapZoomCycleLength = 2;
            this.cogDisplay.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay.Location = new System.Drawing.Point(0, 0);
            this.cogDisplay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cogDisplay.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay.MouseWheelSensitivity = 1D;
            this.cogDisplay.Name = "cogDisplay";
            this.cogDisplay.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay.OcxState")));
            this.cogDisplay.Size = new System.Drawing.Size(814, 327);
            this.cogDisplay.TabIndex = 1;
            this.cogDisplay.Changed += new Cognex.VisionPro.CogChangedEventHandler(this.cogDisplay_Changed);
            // 
            // CogInspDisplayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tfpnlContainer);
            this.Name = "CogInspDisplayControl";
            this.Size = new System.Drawing.Size(820, 381);
            this.Load += new System.EventHandler(this.CogInspDisplayControl_Load);
            this.tfpnlContainer.ResumeLayout(false);
            this.pnlDisplay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tfpnlContainer;
        private System.Windows.Forms.Panel pnlThumbnail;
        private System.Windows.Forms.Panel pnlDisplay;
        private Cognex.VisionPro.CogRecordDisplay cogDisplay;
    }
}
