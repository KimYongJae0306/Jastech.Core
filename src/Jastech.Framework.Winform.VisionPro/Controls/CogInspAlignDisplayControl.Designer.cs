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
            this.cogLeftDisplay = new Cognex.VisionPro.CogRecordDisplay();
            this.cogRightDisplay = new Cognex.VisionPro.CogRecordDisplay();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogLeftDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogRightDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.cogLeftDisplay, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.cogRightDisplay, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(895, 402);
            this.tableLayoutPanel3.TabIndex = 1;
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
            this.cogLeftDisplay.Location = new System.Drawing.Point(3, 2);
            this.cogLeftDisplay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cogLeftDisplay.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogLeftDisplay.MouseWheelSensitivity = 1D;
            this.cogLeftDisplay.Name = "cogLeftDisplay";
            this.cogLeftDisplay.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogLeftDisplay.OcxState")));
            this.cogLeftDisplay.Size = new System.Drawing.Size(436, 398);
            this.cogLeftDisplay.TabIndex = 3;
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
            this.cogRightDisplay.Location = new System.Drawing.Point(455, 2);
            this.cogRightDisplay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cogRightDisplay.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogRightDisplay.MouseWheelSensitivity = 1D;
            this.cogRightDisplay.Name = "cogRightDisplay";
            this.cogRightDisplay.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogRightDisplay.OcxState")));
            this.cogRightDisplay.Size = new System.Drawing.Size(437, 398);
            this.cogRightDisplay.TabIndex = 2;
            // 
            // CogInspAlignDisplayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel3);
            this.Name = "CogInspAlignDisplayControl";
            this.Size = new System.Drawing.Size(895, 402);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogLeftDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogRightDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Cognex.VisionPro.CogRecordDisplay cogLeftDisplay;
        private Cognex.VisionPro.CogRecordDisplay cogRightDisplay;
    }
}
