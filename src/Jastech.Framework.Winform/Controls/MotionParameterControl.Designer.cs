namespace Jastech.Framework.Winform.Controls
{
    partial class MotionParameterControl
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
            this.grpAxisName = new System.Windows.Forms.GroupBox();
            this.tlpMotionParameter = new System.Windows.Forms.TableLayoutPanel();
            this.grpAxisName.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpAxisName
            // 
            this.grpAxisName.Controls.Add(this.tlpMotionParameter);
            this.grpAxisName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAxisName.Location = new System.Drawing.Point(0, 0);
            this.grpAxisName.Name = "grpAxisName";
            this.grpAxisName.Size = new System.Drawing.Size(700, 360);
            this.grpAxisName.TabIndex = 0;
            this.grpAxisName.TabStop = false;
            this.grpAxisName.Text = "Axis Name";
            // 
            // tlpMotionParameter
            // 
            this.tlpMotionParameter.ColumnCount = 1;
            this.tlpMotionParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMotionParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMotionParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMotionParameter.Location = new System.Drawing.Point(3, 23);
            this.tlpMotionParameter.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMotionParameter.Name = "tlpMotionParameter";
            this.tlpMotionParameter.RowCount = 2;
            this.tlpMotionParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMotionParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMotionParameter.Size = new System.Drawing.Size(694, 334);
            this.tlpMotionParameter.TabIndex = 0;
            // 
            // MotionParameterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.grpAxisName);
            this.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.Name = "MotionParameterControl";
            this.Size = new System.Drawing.Size(700, 360);
            this.Load += new System.EventHandler(this.MotionParameterControl_Load);
            this.grpAxisName.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAxisName;
        private System.Windows.Forms.TableLayoutPanel tlpMotionParameter;
    }
}
