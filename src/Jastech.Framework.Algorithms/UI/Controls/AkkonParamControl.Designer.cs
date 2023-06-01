namespace Jastech.Framework.Algorithms.UI.Controls
{
    partial class AkkonParamControl
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
            this.tlpSetParameter = new System.Windows.Forms.TableLayoutPanel();
            this.pnlDisplay = new System.Windows.Forms.Panel();
            this.pnlSelectParameter = new System.Windows.Forms.Panel();
            this.tlpSelectParameter = new System.Windows.Forms.TableLayoutPanel();
            this.rdoImageParam = new System.Windows.Forms.RadioButton();
            this.rdoResultParam = new System.Windows.Forms.RadioButton();
            this.tlpSetParameter.SuspendLayout();
            this.pnlSelectParameter.SuspendLayout();
            this.tlpSelectParameter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpSetParameter
            // 
            this.tlpSetParameter.ColumnCount = 1;
            this.tlpSetParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSetParameter.Controls.Add(this.pnlDisplay, 0, 1);
            this.tlpSetParameter.Controls.Add(this.pnlSelectParameter, 0, 0);
            this.tlpSetParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSetParameter.Location = new System.Drawing.Point(0, 0);
            this.tlpSetParameter.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSetParameter.Name = "tlpSetParameter";
            this.tlpSetParameter.RowCount = 2;
            this.tlpSetParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpSetParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSetParameter.Size = new System.Drawing.Size(576, 328);
            this.tlpSetParameter.TabIndex = 2;
            // 
            // pnlDisplay
            // 
            this.pnlDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDisplay.Location = new System.Drawing.Point(0, 60);
            this.pnlDisplay.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDisplay.Name = "pnlDisplay";
            this.pnlDisplay.Size = new System.Drawing.Size(576, 268);
            this.pnlDisplay.TabIndex = 5;
            // 
            // pnlSelectParameter
            // 
            this.pnlSelectParameter.Controls.Add(this.tlpSelectParameter);
            this.pnlSelectParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSelectParameter.Location = new System.Drawing.Point(0, 0);
            this.pnlSelectParameter.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSelectParameter.Name = "pnlSelectParameter";
            this.pnlSelectParameter.Size = new System.Drawing.Size(576, 60);
            this.pnlSelectParameter.TabIndex = 2;
            // 
            // tlpSelectParameter
            // 
            this.tlpSelectParameter.ColumnCount = 3;
            this.tlpSelectParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSelectParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSelectParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSelectParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSelectParameter.Controls.Add(this.rdoImageParam, 1, 0);
            this.tlpSelectParameter.Controls.Add(this.rdoResultParam, 0, 0);
            this.tlpSelectParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSelectParameter.Location = new System.Drawing.Point(0, 0);
            this.tlpSelectParameter.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSelectParameter.Name = "tlpSelectParameter";
            this.tlpSelectParameter.RowCount = 1;
            this.tlpSelectParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSelectParameter.Size = new System.Drawing.Size(576, 60);
            this.tlpSelectParameter.TabIndex = 0;
            // 
            // rdoImageParam
            // 
            this.rdoImageParam.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoImageParam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.rdoImageParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoImageParam.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.rdoImageParam.ForeColor = System.Drawing.Color.White;
            this.rdoImageParam.Location = new System.Drawing.Point(192, 0);
            this.rdoImageParam.Margin = new System.Windows.Forms.Padding(0);
            this.rdoImageParam.Name = "rdoImageParam";
            this.rdoImageParam.Size = new System.Drawing.Size(192, 60);
            this.rdoImageParam.TabIndex = 1;
            this.rdoImageParam.TabStop = true;
            this.rdoImageParam.Text = "IMAGE PROCESSING";
            this.rdoImageParam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoImageParam.UseVisualStyleBackColor = false;
            this.rdoImageParam.CheckedChanged += new System.EventHandler(this.rdoImageParam_CheckedChanged);
            // 
            // rdoResultParam
            // 
            this.rdoResultParam.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoResultParam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.rdoResultParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoResultParam.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.rdoResultParam.ForeColor = System.Drawing.Color.White;
            this.rdoResultParam.Location = new System.Drawing.Point(0, 0);
            this.rdoResultParam.Margin = new System.Windows.Forms.Padding(0);
            this.rdoResultParam.Name = "rdoResultParam";
            this.rdoResultParam.Size = new System.Drawing.Size(192, 60);
            this.rdoResultParam.TabIndex = 2;
            this.rdoResultParam.TabStop = true;
            this.rdoResultParam.Text = "RESULT PARAMETER";
            this.rdoResultParam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoResultParam.UseVisualStyleBackColor = false;
            this.rdoResultParam.CheckedChanged += new System.EventHandler(this.rdoResultParam_CheckedChanged);
            // 
            // AkkonParamControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.Controls.Add(this.tlpSetParameter);
            this.Name = "AkkonParamControl";
            this.Size = new System.Drawing.Size(576, 328);
            this.Load += new System.EventHandler(this.AkkonParamControl_Load);
            this.tlpSetParameter.ResumeLayout(false);
            this.pnlSelectParameter.ResumeLayout(false);
            this.tlpSelectParameter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpSetParameter;
        private System.Windows.Forms.Panel pnlDisplay;
        private System.Windows.Forms.Panel pnlSelectParameter;
        private System.Windows.Forms.TableLayoutPanel tlpSelectParameter;
        private System.Windows.Forms.RadioButton rdoImageParam;
        private System.Windows.Forms.RadioButton rdoResultParam;
    }
}
