namespace Jastech.Framework.Winform.VisionPro.Controls
{
    partial class CogPreAlignDisplayControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CogPreAlignDisplayControl));
            this.tlpCogPreAlignDisplay = new System.Windows.Forms.TableLayoutPanel();
            this.tlpRight = new System.Windows.Forms.TableLayoutPanel();
            this.cogRightDisplay = new Cognex.VisionPro.CogRecordDisplay();
            this.lblRight = new System.Windows.Forms.Label();
            this.tlpLeft = new System.Windows.Forms.TableLayoutPanel();
            this.cogLeftDisplay = new Cognex.VisionPro.CogRecordDisplay();
            this.lblLeft = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.tlpCogPreAlignDisplay.SuspendLayout();
            this.tlpRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogRightDisplay)).BeginInit();
            this.tlpLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogLeftDisplay)).BeginInit();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpCogPreAlignDisplay
            // 
            this.tlpCogPreAlignDisplay.ColumnCount = 2;
            this.tlpCogPreAlignDisplay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCogPreAlignDisplay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCogPreAlignDisplay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCogPreAlignDisplay.Controls.Add(this.tlpRight, 1, 0);
            this.tlpCogPreAlignDisplay.Controls.Add(this.tlpLeft, 0, 0);
            this.tlpCogPreAlignDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCogPreAlignDisplay.Location = new System.Drawing.Point(0, 0);
            this.tlpCogPreAlignDisplay.Name = "tlpCogPreAlignDisplay";
            this.tlpCogPreAlignDisplay.RowCount = 1;
            this.tlpCogPreAlignDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCogPreAlignDisplay.Size = new System.Drawing.Size(405, 200);
            this.tlpCogPreAlignDisplay.TabIndex = 2;
            // 
            // tlpRight
            // 
            this.tlpRight.ColumnCount = 1;
            this.tlpRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRight.Controls.Add(this.lblRight, 0, 0);
            this.tlpRight.Controls.Add(this.pnlRight, 0, 1);
            this.tlpRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRight.Location = new System.Drawing.Point(202, 0);
            this.tlpRight.Margin = new System.Windows.Forms.Padding(0);
            this.tlpRight.Name = "tlpRight";
            this.tlpRight.RowCount = 2;
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRight.Size = new System.Drawing.Size(203, 200);
            this.tlpRight.TabIndex = 3;
            // 
            // cogRightDisplay
            // 
            this.cogRightDisplay.ColorMapLowerClipColor = System.Drawing.SystemColors.AppWorkspace;
            this.cogRightDisplay.ColorMapLowerRoiLimit = 0D;
            this.cogRightDisplay.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogRightDisplay.ColorMapUpperClipColor = System.Drawing.SystemColors.AppWorkspace;
            this.cogRightDisplay.ColorMapUpperRoiLimit = 1D;
            this.cogRightDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogRightDisplay.DoubleTapZoomCycleLength = 2;
            this.cogRightDisplay.DoubleTapZoomSensitivity = 2.5D;
            this.cogRightDisplay.Location = new System.Drawing.Point(0, 0);
            this.cogRightDisplay.Margin = new System.Windows.Forms.Padding(0);
            this.cogRightDisplay.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogRightDisplay.MouseWheelSensitivity = 1D;
            this.cogRightDisplay.Name = "cogRightDisplay";
            this.cogRightDisplay.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogRightDisplay.OcxState")));
            this.cogRightDisplay.Size = new System.Drawing.Size(201, 158);
            this.cogRightDisplay.TabIndex = 2;
            // 
            // lblRight
            // 
            this.lblRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.lblRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRight.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lblRight.ForeColor = System.Drawing.Color.White;
            this.lblRight.Location = new System.Drawing.Point(0, 0);
            this.lblRight.Margin = new System.Windows.Forms.Padding(0);
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(203, 40);
            this.lblRight.TabIndex = 2;
            this.lblRight.Text = "RIGHT";
            this.lblRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpLeft
            // 
            this.tlpLeft.ColumnCount = 1;
            this.tlpLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLeft.Controls.Add(this.lblLeft, 0, 0);
            this.tlpLeft.Controls.Add(this.pnlLeft, 0, 1);
            this.tlpLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLeft.Location = new System.Drawing.Point(0, 0);
            this.tlpLeft.Margin = new System.Windows.Forms.Padding(0);
            this.tlpLeft.Name = "tlpLeft";
            this.tlpLeft.RowCount = 2;
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLeft.Size = new System.Drawing.Size(202, 200);
            this.tlpLeft.TabIndex = 2;
            // 
            // cogLeftDisplay
            // 
            this.cogLeftDisplay.ColorMapLowerClipColor = System.Drawing.SystemColors.AppWorkspace;
            this.cogLeftDisplay.ColorMapLowerRoiLimit = 0D;
            this.cogLeftDisplay.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogLeftDisplay.ColorMapUpperClipColor = System.Drawing.SystemColors.AppWorkspace;
            this.cogLeftDisplay.ColorMapUpperRoiLimit = 1D;
            this.cogLeftDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogLeftDisplay.DoubleTapZoomCycleLength = 2;
            this.cogLeftDisplay.DoubleTapZoomSensitivity = 2.5D;
            this.cogLeftDisplay.Location = new System.Drawing.Point(0, 0);
            this.cogLeftDisplay.Margin = new System.Windows.Forms.Padding(0);
            this.cogLeftDisplay.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogLeftDisplay.MouseWheelSensitivity = 1D;
            this.cogLeftDisplay.Name = "cogLeftDisplay";
            this.cogLeftDisplay.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogLeftDisplay.OcxState")));
            this.cogLeftDisplay.Size = new System.Drawing.Size(200, 158);
            this.cogLeftDisplay.TabIndex = 3;
            // 
            // lblLeft
            // 
            this.lblLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.lblLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLeft.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lblLeft.ForeColor = System.Drawing.Color.White;
            this.lblLeft.Location = new System.Drawing.Point(0, 0);
            this.lblLeft.Margin = new System.Windows.Forms.Padding(0);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(202, 40);
            this.lblLeft.TabIndex = 2;
            this.lblLeft.Text = "LEFT";
            this.lblLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLeft.Controls.Add(this.cogLeftDisplay);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(0, 40);
            this.pnlLeft.Margin = new System.Windows.Forms.Padding(0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(202, 160);
            this.pnlLeft.TabIndex = 4;
            // 
            // pnlRight
            // 
            this.pnlRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRight.Controls.Add(this.cogRightDisplay);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(0, 40);
            this.pnlRight.Margin = new System.Windows.Forms.Padding(0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(203, 160);
            this.pnlRight.TabIndex = 4;
            // 
            // CogPreAlignDisplayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.Controls.Add(this.tlpCogPreAlignDisplay);
            this.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "CogPreAlignDisplayControl";
            this.Size = new System.Drawing.Size(405, 200);
            this.tlpCogPreAlignDisplay.ResumeLayout(false);
            this.tlpRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogRightDisplay)).EndInit();
            this.tlpLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogLeftDisplay)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpCogPreAlignDisplay;
        private System.Windows.Forms.TableLayoutPanel tlpRight;
        private Cognex.VisionPro.CogRecordDisplay cogRightDisplay;
        private System.Windows.Forms.Label lblRight;
        private System.Windows.Forms.TableLayoutPanel tlpLeft;
        private Cognex.VisionPro.CogRecordDisplay cogLeftDisplay;
        private System.Windows.Forms.Label lblLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlLeft;
    }
}
