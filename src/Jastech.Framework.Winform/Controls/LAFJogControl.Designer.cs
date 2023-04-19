namespace Jastech.Framework.Winform.Controls
{
    partial class LAFJogControl
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
            this.tlpJogOperation = new System.Windows.Forms.TableLayoutPanel();
            this.btnJogDownZ = new System.Windows.Forms.Button();
            this.btnJogUpZ = new System.Windows.Forms.Button();
            this.tlpJogOperation.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpJogOperation
            // 
            this.tlpJogOperation.ColumnCount = 1;
            this.tlpJogOperation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpJogOperation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpJogOperation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpJogOperation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpJogOperation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpJogOperation.Controls.Add(this.btnJogDownZ, 0, 2);
            this.tlpJogOperation.Controls.Add(this.btnJogUpZ, 0, 0);
            this.tlpJogOperation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpJogOperation.Location = new System.Drawing.Point(0, 0);
            this.tlpJogOperation.Margin = new System.Windows.Forms.Padding(0);
            this.tlpJogOperation.Name = "tlpJogOperation";
            this.tlpJogOperation.RowCount = 3;
            this.tlpJogOperation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpJogOperation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpJogOperation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpJogOperation.Size = new System.Drawing.Size(100, 300);
            this.tlpJogOperation.TabIndex = 19;
            // 
            // btnJogDownZ
            // 
            this.btnJogDownZ.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnJogDownZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnJogDownZ.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.btnJogDownZ.Image = global::Jastech.Framework.Winform.Properties.Resources.Arrow_Down_White;
            this.btnJogDownZ.Location = new System.Drawing.Point(0, 198);
            this.btnJogDownZ.Margin = new System.Windows.Forms.Padding(0);
            this.btnJogDownZ.Name = "btnJogDownZ";
            this.btnJogDownZ.Size = new System.Drawing.Size(100, 102);
            this.btnJogDownZ.TabIndex = 8;
            this.btnJogDownZ.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnJogDownZ.UseVisualStyleBackColor = false;
            this.btnJogDownZ.Click += new System.EventHandler(this.btnJogDownZ_Click);
            // 
            // btnJogUpZ
            // 
            this.btnJogUpZ.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnJogUpZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnJogUpZ.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.btnJogUpZ.Image = global::Jastech.Framework.Winform.Properties.Resources.Arrow_Up_White;
            this.btnJogUpZ.Location = new System.Drawing.Point(0, 0);
            this.btnJogUpZ.Margin = new System.Windows.Forms.Padding(0);
            this.btnJogUpZ.Name = "btnJogUpZ";
            this.btnJogUpZ.Size = new System.Drawing.Size(100, 99);
            this.btnJogUpZ.TabIndex = 7;
            this.btnJogUpZ.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnJogUpZ.UseVisualStyleBackColor = false;
            this.btnJogUpZ.Click += new System.EventHandler(this.btnJogUpZ_Click);
            // 
            // LAFJogControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.Controls.Add(this.tlpJogOperation);
            this.Name = "LAFJogControl";
            this.Size = new System.Drawing.Size(100, 300);
            this.Load += new System.EventHandler(this.LAFJogControl_Load);
            this.tlpJogOperation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpJogOperation;
        private System.Windows.Forms.Button btnJogDownZ;
        private System.Windows.Forms.Button btnJogUpZ;
    }
}
