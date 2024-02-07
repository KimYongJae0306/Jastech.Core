namespace Jastech.Framework.Winform.Controls
{
    partial class ImagePreviewControl
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
            this.tlpImagePreview = new System.Windows.Forms.TableLayoutPanel();
            this.lblImageName = new System.Windows.Forms.Label();
            this.pnlImagePreview = new System.Windows.Forms.Panel();
            this.pbxDisplay = new System.Windows.Forms.PictureBox();
            this.tlpImagePreview.SuspendLayout();
            this.pnlImagePreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpImagePreview
            // 
            this.tlpImagePreview.ColumnCount = 1;
            this.tlpImagePreview.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpImagePreview.Controls.Add(this.lblImageName, 0, 1);
            this.tlpImagePreview.Controls.Add(this.pbxDisplay, 0, 0);
            this.tlpImagePreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpImagePreview.Location = new System.Drawing.Point(0, 0);
            this.tlpImagePreview.Name = "tlpImagePreview";
            this.tlpImagePreview.RowCount = 2;
            this.tlpImagePreview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpImagePreview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpImagePreview.Size = new System.Drawing.Size(250, 250);
            this.tlpImagePreview.TabIndex = 2;
            // 
            // lblImageName
            // 
            this.lblImageName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblImageName.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblImageName.ForeColor = System.Drawing.Color.Black;
            this.lblImageName.Location = new System.Drawing.Point(0, 220);
            this.lblImageName.Margin = new System.Windows.Forms.Padding(0);
            this.lblImageName.Name = "lblImageName";
            this.lblImageName.Size = new System.Drawing.Size(250, 30);
            this.lblImageName.TabIndex = 2;
            this.lblImageName.Text = "label1";
            this.lblImageName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlImagePreview
            // 
            this.pnlImagePreview.Controls.Add(this.tlpImagePreview);
            this.pnlImagePreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImagePreview.Location = new System.Drawing.Point(0, 0);
            this.pnlImagePreview.Margin = new System.Windows.Forms.Padding(0);
            this.pnlImagePreview.Name = "pnlImagePreview";
            this.pnlImagePreview.Size = new System.Drawing.Size(250, 250);
            this.pnlImagePreview.TabIndex = 3;
            this.pnlImagePreview.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlImagePreview_Paint);
            // 
            // pbxDisplay
            // 
            this.pbxDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxDisplay.Location = new System.Drawing.Point(0, 0);
            this.pbxDisplay.Margin = new System.Windows.Forms.Padding(0);
            this.pbxDisplay.Name = "pbxDisplay";
            this.pbxDisplay.Size = new System.Drawing.Size(250, 220);
            this.pbxDisplay.TabIndex = 3;
            this.pbxDisplay.TabStop = false;
            this.pbxDisplay.Click += new System.EventHandler(this.pbxDisplay_Click);
            this.pbxDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.pbxDisplay_Paint);
            // 
            // ImagePreviewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.Controls.Add(this.pnlImagePreview);
            this.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.Name = "ImagePreviewControl";
            this.Size = new System.Drawing.Size(250, 250);
            this.Load += new System.EventHandler(this.ImagePreviewControl_Load);
            this.tlpImagePreview.ResumeLayout(false);
            this.pnlImagePreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpImagePreview;
        private System.Windows.Forms.Label lblImageName;
        private System.Windows.Forms.Panel pnlImagePreview;
        private System.Windows.Forms.PictureBox pbxDisplay;
    }
}
