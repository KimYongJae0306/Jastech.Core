namespace Jastech.Framework.Winform.VisionPro.Controls
{
    partial class CogInspAlignDisplayControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CogInspAlignDisplayControl));
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cogRightDisplay = new Cognex.VisionPro.CogRecordDisplay();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.btnRightResultImage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRightSourceImage = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnLeftResultImage = new System.Windows.Forms.Button();
            this.lblAlignViewer = new System.Windows.Forms.Label();
            this.btnLeftSourceImage = new System.Windows.Forms.Button();
            this.cogLeftDisplay = new Cognex.VisionPro.CogRecordDisplay();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.cogCenterDisplay = new Cognex.VisionPro.CogRecordDisplay();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogRightDisplay)).BeginInit();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogLeftDisplay)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogCenterDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1385, 507);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.cogRightDisplay, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(933, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(449, 501);
            this.tableLayoutPanel2.TabIndex = 3;
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
            this.cogRightDisplay.Location = new System.Drawing.Point(3, 42);
            this.cogRightDisplay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cogRightDisplay.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogRightDisplay.MouseWheelSensitivity = 1D;
            this.cogRightDisplay.Name = "cogRightDisplay";
            this.cogRightDisplay.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogRightDisplay.OcxState")));
            this.cogRightDisplay.Size = new System.Drawing.Size(443, 457);
            this.cogRightDisplay.TabIndex = 2;
            this.cogRightDisplay.Changed += new Cognex.VisionPro.CogChangedEventHandler(this.cogRightDisplay_Changed);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel6.Controls.Add(this.btnRightResultImage, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnRightSourceImage, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(449, 40);
            this.tableLayoutPanel6.TabIndex = 2;
            // 
            // btnRightResultImage
            // 
            this.btnRightResultImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRightResultImage.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRightResultImage.ForeColor = System.Drawing.Color.White;
            this.btnRightResultImage.Location = new System.Drawing.Point(379, 0);
            this.btnRightResultImage.Margin = new System.Windows.Forms.Padding(0);
            this.btnRightResultImage.Name = "btnRightResultImage";
            this.btnRightResultImage.Size = new System.Drawing.Size(70, 40);
            this.btnRightResultImage.TabIndex = 2;
            this.btnRightResultImage.Text = "R";
            this.btnRightResultImage.UseVisualStyleBackColor = false;
            this.btnRightResultImage.Click += new System.EventHandler(this.btnRightResultImage_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "RIGHT";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRightSourceImage
            // 
            this.btnRightSourceImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRightSourceImage.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRightSourceImage.ForeColor = System.Drawing.Color.White;
            this.btnRightSourceImage.Location = new System.Drawing.Point(309, 0);
            this.btnRightSourceImage.Margin = new System.Windows.Forms.Padding(0);
            this.btnRightSourceImage.Name = "btnRightSourceImage";
            this.btnRightSourceImage.Size = new System.Drawing.Size(70, 40);
            this.btnRightSourceImage.TabIndex = 1;
            this.btnRightSourceImage.Text = "S";
            this.btnRightSourceImage.UseVisualStyleBackColor = false;
            this.btnRightSourceImage.Click += new System.EventHandler(this.btnRightSourceImage_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cogLeftDisplay, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(449, 501);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel5.Controls.Add(this.btnLeftResultImage, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.lblAlignViewer, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnLeftSourceImage, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(449, 40);
            this.tableLayoutPanel5.TabIndex = 5;
            // 
            // btnLeftResultImage
            // 
            this.btnLeftResultImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLeftResultImage.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLeftResultImage.ForeColor = System.Drawing.Color.White;
            this.btnLeftResultImage.Location = new System.Drawing.Point(379, 0);
            this.btnLeftResultImage.Margin = new System.Windows.Forms.Padding(0);
            this.btnLeftResultImage.Name = "btnLeftResultImage";
            this.btnLeftResultImage.Size = new System.Drawing.Size(70, 40);
            this.btnLeftResultImage.TabIndex = 2;
            this.btnLeftResultImage.Text = "R";
            this.btnLeftResultImage.UseVisualStyleBackColor = false;
            this.btnLeftResultImage.Click += new System.EventHandler(this.btnLeftResultImage_Click);
            // 
            // lblAlignViewer
            // 
            this.lblAlignViewer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.lblAlignViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAlignViewer.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lblAlignViewer.ForeColor = System.Drawing.Color.White;
            this.lblAlignViewer.Location = new System.Drawing.Point(0, 0);
            this.lblAlignViewer.Margin = new System.Windows.Forms.Padding(0);
            this.lblAlignViewer.Name = "lblAlignViewer";
            this.lblAlignViewer.Size = new System.Drawing.Size(309, 40);
            this.lblAlignViewer.TabIndex = 2;
            this.lblAlignViewer.Text = "LEFT";
            this.lblAlignViewer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLeftSourceImage
            // 
            this.btnLeftSourceImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLeftSourceImage.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLeftSourceImage.ForeColor = System.Drawing.Color.White;
            this.btnLeftSourceImage.Location = new System.Drawing.Point(309, 0);
            this.btnLeftSourceImage.Margin = new System.Windows.Forms.Padding(0);
            this.btnLeftSourceImage.Name = "btnLeftSourceImage";
            this.btnLeftSourceImage.Size = new System.Drawing.Size(70, 40);
            this.btnLeftSourceImage.TabIndex = 1;
            this.btnLeftSourceImage.Text = "S";
            this.btnLeftSourceImage.UseVisualStyleBackColor = false;
            this.btnLeftSourceImage.Click += new System.EventHandler(this.btnLeftSourceImage_Click);
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
            this.cogLeftDisplay.Location = new System.Drawing.Point(3, 42);
            this.cogLeftDisplay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cogLeftDisplay.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogLeftDisplay.MouseWheelSensitivity = 1D;
            this.cogLeftDisplay.Name = "cogLeftDisplay";
            this.cogLeftDisplay.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogLeftDisplay.OcxState")));
            this.cogLeftDisplay.Size = new System.Drawing.Size(443, 457);
            this.cogLeftDisplay.TabIndex = 3;
            this.cogLeftDisplay.Changed += new Cognex.VisionPro.CogChangedEventHandler(this.cogLeftDisplay_Changed);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.cogCenterDisplay, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(468, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(449, 501);
            this.tableLayoutPanel4.TabIndex = 4;
            // 
            // cogCenterDisplay
            // 
            this.cogCenterDisplay.ColorMapLowerClipColor = System.Drawing.SystemColors.AppWorkspace;
            this.cogCenterDisplay.ColorMapLowerRoiLimit = 0D;
            this.cogCenterDisplay.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogCenterDisplay.ColorMapUpperClipColor = System.Drawing.SystemColors.AppWorkspace;
            this.cogCenterDisplay.ColorMapUpperRoiLimit = 1D;
            this.cogCenterDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogCenterDisplay.DoubleTapZoomCycleLength = 2;
            this.cogCenterDisplay.DoubleTapZoomSensitivity = 2.5D;
            this.cogCenterDisplay.Location = new System.Drawing.Point(3, 42);
            this.cogCenterDisplay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cogCenterDisplay.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogCenterDisplay.MouseWheelSensitivity = 1D;
            this.cogCenterDisplay.Name = "cogCenterDisplay";
            this.cogCenterDisplay.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogCenterDisplay.OcxState")));
            this.cogCenterDisplay.Size = new System.Drawing.Size(443, 457);
            this.cogCenterDisplay.TabIndex = 2;
            this.cogCenterDisplay.Changed += new Cognex.VisionPro.CogChangedEventHandler(this.cogCenterDisplay_Changed);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(449, 40);
            this.label2.TabIndex = 2;
            this.label2.Text = "Center";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CogInspAlignDisplayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel3);
            this.Name = "CogInspAlignDisplayControl";
            this.Size = new System.Drawing.Size(1385, 507);
            this.Load += new System.EventHandler(this.CogInspAlignDisplayControl_Load);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogRightDisplay)).EndInit();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogLeftDisplay)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogCenterDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private Cognex.VisionPro.CogRecordDisplay cogLeftDisplay;
        private Cognex.VisionPro.CogRecordDisplay cogRightDisplay;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private Cognex.VisionPro.CogRecordDisplay cogCenterDisplay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button btnLeftResultImage;
        private System.Windows.Forms.Button btnLeftSourceImage;
        private System.Windows.Forms.Label lblAlignViewer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button btnRightResultImage;
        private System.Windows.Forms.Button btnRightSourceImage;
    }
}
