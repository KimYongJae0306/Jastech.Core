namespace Jastech.Framework.Winform.Controls
{
    partial class LiveViewPanel
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
            this.pnlLiveView = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlLiveView
            // 
            this.pnlLiveView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLiveView.Location = new System.Drawing.Point(0, 0);
            this.pnlLiveView.Margin = new System.Windows.Forms.Padding(0);
            this.pnlLiveView.Name = "pnlLiveView";
            this.pnlLiveView.Size = new System.Drawing.Size(679, 427);
            this.pnlLiveView.TabIndex = 0;
            // 
            // LiveViewPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.Controls.Add(this.pnlLiveView);
            this.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LiveViewPanel";
            this.Size = new System.Drawing.Size(679, 427);
            this.Load += new System.EventHandler(this.LiveViewPanel_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLiveView;
    }
}
