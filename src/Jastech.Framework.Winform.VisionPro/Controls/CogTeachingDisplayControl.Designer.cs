namespace Jastech.Framework.Winform.VisionPro.Controls
{
    partial class CogTeachingDisplayControl
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
            this.tfpnlContainer = new System.Windows.Forms.TableLayoutPanel();
            this.pnlThumbnail = new System.Windows.Forms.Panel();
            this.pnlDisplay = new System.Windows.Forms.Panel();
            this.tfpnlContainer.SuspendLayout();
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
            this.tfpnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tfpnlContainer.Size = new System.Drawing.Size(927, 390);
            this.tfpnlContainer.TabIndex = 5;
            // 
            // pnlThumbnail
            // 
            this.pnlThumbnail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlThumbnail.Location = new System.Drawing.Point(3, 292);
            this.pnlThumbnail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlThumbnail.Name = "pnlThumbnail";
            this.pnlThumbnail.Size = new System.Drawing.Size(921, 96);
            this.pnlThumbnail.TabIndex = 3;
            // 
            // pnlDisplay
            // 
            this.pnlDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDisplay.Location = new System.Drawing.Point(3, 2);
            this.pnlDisplay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlDisplay.Name = "pnlDisplay";
            this.pnlDisplay.Size = new System.Drawing.Size(921, 286);
            this.pnlDisplay.TabIndex = 0;
            // 
            // CogTeachingDisplayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.Controls.Add(this.tfpnlContainer);
            this.Name = "CogTeachingDisplayControl";
            this.Size = new System.Drawing.Size(927, 390);
            this.Load += new System.EventHandler(this.CogTeachingDisplayControl_Load);
            this.tfpnlContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tfpnlContainer;
        private System.Windows.Forms.Panel pnlThumbnail;
        private System.Windows.Forms.Panel pnlDisplay;
    }
}
