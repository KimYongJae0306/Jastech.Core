namespace Jastech.Framework.Winform.Controls
{
    partial class CompactDefectMapControl
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
            this.pnlMapArea = new Jastech.Framework.Winform.Controls.DoubleBufferedPanel();
            this.SuspendLayout();
            // 
            // pnlMapArea
            // 
            this.pnlMapArea.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlMapArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMapArea.Location = new System.Drawing.Point(0, 0);
            this.pnlMapArea.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMapArea.Name = "pnlMapArea";
            this.pnlMapArea.Size = new System.Drawing.Size(206, 293);
            this.pnlMapArea.TabIndex = 2;
            this.pnlMapArea.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMapArea_Paint);
            this.pnlMapArea.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlMapArea_MouseClick);
            // 
            // CompactDefectMapControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.pnlMapArea);
            this.DoubleBuffered = true;
            this.Name = "CompactDefectMapControl";
            this.Size = new System.Drawing.Size(206, 293);
            this.Load += new System.EventHandler(this.CompactDefectMapControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DoubleBufferedPanel pnlMapArea;
    }
}
