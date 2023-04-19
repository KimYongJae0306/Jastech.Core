namespace Jastech.Framework.Winform.Controls
{
    partial class MotionJogControl
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
            this.btnJogDownY = new System.Windows.Forms.Button();
            this.btnJogLeftX = new System.Windows.Forms.Button();
            this.btnJogRightX = new System.Windows.Forms.Button();
            this.btnJogStop = new System.Windows.Forms.Button();
            this.btnJogUpY = new System.Windows.Forms.Button();
            this.tlpJogOperation.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpJogOperation
            // 
            this.tlpJogOperation.ColumnCount = 3;
            this.tlpJogOperation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpJogOperation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpJogOperation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpJogOperation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpJogOperation.Controls.Add(this.btnJogDownY, 1, 2);
            this.tlpJogOperation.Controls.Add(this.btnJogLeftX, 0, 1);
            this.tlpJogOperation.Controls.Add(this.btnJogRightX, 2, 1);
            this.tlpJogOperation.Controls.Add(this.btnJogStop, 1, 1);
            this.tlpJogOperation.Controls.Add(this.btnJogUpY, 1, 0);
            this.tlpJogOperation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpJogOperation.Location = new System.Drawing.Point(0, 0);
            this.tlpJogOperation.Margin = new System.Windows.Forms.Padding(0);
            this.tlpJogOperation.Name = "tlpJogOperation";
            this.tlpJogOperation.RowCount = 3;
            this.tlpJogOperation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpJogOperation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpJogOperation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpJogOperation.Size = new System.Drawing.Size(300, 300);
            this.tlpJogOperation.TabIndex = 19;
            // 
            // btnJogDownY
            // 
            this.btnJogDownY.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnJogDownY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnJogDownY.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.btnJogDownY.Image = global::Jastech.Framework.Winform.Properties.Resources.Arrow_Down_White;
            this.btnJogDownY.Location = new System.Drawing.Point(99, 198);
            this.btnJogDownY.Margin = new System.Windows.Forms.Padding(0);
            this.btnJogDownY.Name = "btnJogDownY";
            this.btnJogDownY.Size = new System.Drawing.Size(100, 102);
            this.btnJogDownY.TabIndex = 6;
            this.btnJogDownY.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnJogDownY.UseVisualStyleBackColor = false;
            this.btnJogDownY.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogDownY_MouseDown);
            this.btnJogDownY.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogDownY_MouseUp);
            // 
            // btnJogLeftX
            // 
            this.btnJogLeftX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnJogLeftX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnJogLeftX.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.btnJogLeftX.Image = global::Jastech.Framework.Winform.Properties.Resources.Arrow_Left_White;
            this.btnJogLeftX.Location = new System.Drawing.Point(0, 99);
            this.btnJogLeftX.Margin = new System.Windows.Forms.Padding(0);
            this.btnJogLeftX.Name = "btnJogLeftX";
            this.btnJogLeftX.Size = new System.Drawing.Size(99, 99);
            this.btnJogLeftX.TabIndex = 1;
            this.btnJogLeftX.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnJogLeftX.UseVisualStyleBackColor = false;
            this.btnJogLeftX.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogLeftX_MouseDown);
            this.btnJogLeftX.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogLeftX_MouseUp);
            // 
            // btnJogRightX
            // 
            this.btnJogRightX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnJogRightX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnJogRightX.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.btnJogRightX.Image = global::Jastech.Framework.Winform.Properties.Resources.Arrow_Right_White;
            this.btnJogRightX.Location = new System.Drawing.Point(199, 99);
            this.btnJogRightX.Margin = new System.Windows.Forms.Padding(0);
            this.btnJogRightX.Name = "btnJogRightX";
            this.btnJogRightX.Size = new System.Drawing.Size(101, 99);
            this.btnJogRightX.TabIndex = 2;
            this.btnJogRightX.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnJogRightX.UseVisualStyleBackColor = false;
            this.btnJogRightX.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogRightX_MouseDown);
            this.btnJogRightX.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogRightX_MouseUp);
            // 
            // btnJogStop
            // 
            this.btnJogStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnJogStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnJogStop.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.btnJogStop.Image = global::Jastech.Framework.Winform.Properties.Resources.Stop_Circle_White;
            this.btnJogStop.Location = new System.Drawing.Point(99, 99);
            this.btnJogStop.Margin = new System.Windows.Forms.Padding(0);
            this.btnJogStop.Name = "btnJogStop";
            this.btnJogStop.Size = new System.Drawing.Size(100, 99);
            this.btnJogStop.TabIndex = 4;
            this.btnJogStop.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnJogStop.UseVisualStyleBackColor = false;
            // 
            // btnJogUpY
            // 
            this.btnJogUpY.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnJogUpY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnJogUpY.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.btnJogUpY.Image = global::Jastech.Framework.Winform.Properties.Resources.Arrow_Up_White;
            this.btnJogUpY.Location = new System.Drawing.Point(99, 0);
            this.btnJogUpY.Margin = new System.Windows.Forms.Padding(0);
            this.btnJogUpY.Name = "btnJogUpY";
            this.btnJogUpY.Size = new System.Drawing.Size(100, 99);
            this.btnJogUpY.TabIndex = 5;
            this.btnJogUpY.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnJogUpY.UseVisualStyleBackColor = false;
            this.btnJogUpY.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogUpY_MouseDown);
            this.btnJogUpY.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogUpY_MouseUp);
            // 
            // MotionJogControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.Controls.Add(this.tlpJogOperation);
            this.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.Name = "MotionJogControl";
            this.Size = new System.Drawing.Size(300, 300);
            this.tlpJogOperation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpJogOperation;
        private System.Windows.Forms.Button btnJogDownY;
        private System.Windows.Forms.Button btnJogLeftX;
        private System.Windows.Forms.Button btnJogRightX;
        private System.Windows.Forms.Button btnJogStop;
        private System.Windows.Forms.Button btnJogUpY;
    }
}
