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
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cogLeftDisplay = new Cognex.VisionPro.CogRecordDisplay();
            this.lblAlignViewer = new System.Windows.Forms.Label();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogRightDisplay)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogLeftDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(895, 402);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.cogRightDisplay, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(455, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(437, 396);
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
            this.cogRightDisplay.Size = new System.Drawing.Size(431, 352);
            this.cogRightDisplay.TabIndex = 2;
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
            this.label1.Size = new System.Drawing.Size(437, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "RIGHT";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.cogLeftDisplay, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblAlignViewer, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(436, 396);
            this.tableLayoutPanel1.TabIndex = 2;
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
            this.cogLeftDisplay.Size = new System.Drawing.Size(430, 352);
            this.cogLeftDisplay.TabIndex = 3;
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
            this.lblAlignViewer.Size = new System.Drawing.Size(436, 40);
            this.lblAlignViewer.TabIndex = 2;
            this.lblAlignViewer.Text = "LEFT";
            this.lblAlignViewer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CogInspAlignDisplayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel3);
            this.Name = "CogInspAlignDisplayControl";
            this.Size = new System.Drawing.Size(895, 402);
            this.Load += new System.EventHandler(this.CogInspAlignDisplayControl_Load);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogRightDisplay)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogLeftDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblAlignViewer;
        private System.Windows.Forms.Label label1;
        private Cognex.VisionPro.CogRecordDisplay cogLeftDisplay;
        private Cognex.VisionPro.CogRecordDisplay cogRightDisplay;
    }
}
