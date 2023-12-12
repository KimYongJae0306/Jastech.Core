namespace Jastech.Framework.Winform.Controls
{
    partial class ImageViewerControl
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
            this.tlpImageViewer = new System.Windows.Forms.TableLayoutPanel();
            this.pnlPreview = new System.Windows.Forms.Panel();
            this.pnlView = new System.Windows.Forms.Panel();
            this.tlpImageViewer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpImageViewer
            // 
            this.tlpImageViewer.ColumnCount = 1;
            this.tlpImageViewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpImageViewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpImageViewer.Controls.Add(this.pnlPreview, 0, 1);
            this.tlpImageViewer.Controls.Add(this.pnlView, 0, 0);
            this.tlpImageViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpImageViewer.Location = new System.Drawing.Point(0, 0);
            this.tlpImageViewer.Margin = new System.Windows.Forms.Padding(0);
            this.tlpImageViewer.Name = "tlpImageViewer";
            this.tlpImageViewer.RowCount = 2;
            this.tlpImageViewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tlpImageViewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpImageViewer.Size = new System.Drawing.Size(500, 500);
            this.tlpImageViewer.TabIndex = 0;
            // 
            // pnlPreview
            // 
            this.pnlPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPreview.Location = new System.Drawing.Point(0, 400);
            this.pnlPreview.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPreview.Name = "pnlPreview";
            this.pnlPreview.Size = new System.Drawing.Size(500, 100);
            this.pnlPreview.TabIndex = 1;
            // 
            // pnlView
            // 
            this.pnlView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlView.Location = new System.Drawing.Point(0, 0);
            this.pnlView.Margin = new System.Windows.Forms.Padding(0);
            this.pnlView.Name = "pnlView";
            this.pnlView.Size = new System.Drawing.Size(500, 400);
            this.pnlView.TabIndex = 0;
            // 
            // ImageViewerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.Controls.Add(this.tlpImageViewer);
            this.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.Name = "ImageViewerControl";
            this.Size = new System.Drawing.Size(500, 500);
            this.Load += new System.EventHandler(this.ImageViewerControl_Load);
            this.tlpImageViewer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpImageViewer;
        private System.Windows.Forms.Panel pnlPreview;
        private System.Windows.Forms.Panel pnlView;
    }
}
