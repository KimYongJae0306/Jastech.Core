namespace Jastech.Framework.Macron.Akkon.Controls
{
    partial class MacronAkkonParamControl
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
            this.pnlShowSelectParameter = new System.Windows.Forms.Panel();
            this.pnlSelectParameter = new System.Windows.Forms.Panel();
            this.tlpSelectParameter = new System.Windows.Forms.TableLayoutPanel();
            this.rdoMakerParmeter = new System.Windows.Forms.RadioButton();
            this.rdoEngineerParmeter = new System.Windows.Forms.RadioButton();
            this.rdoOption = new System.Windows.Forms.RadioButton();
            this.tlpSetParameter.SuspendLayout();
            this.pnlSelectParameter.SuspendLayout();
            this.tlpSelectParameter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpSetParameter
            // 
            this.tlpSetParameter.ColumnCount = 1;
            this.tlpSetParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSetParameter.Controls.Add(this.pnlShowSelectParameter, 0, 1);
            this.tlpSetParameter.Controls.Add(this.pnlSelectParameter, 0, 0);
            this.tlpSetParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSetParameter.Location = new System.Drawing.Point(0, 0);
            this.tlpSetParameter.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSetParameter.Name = "tlpSetParameter";
            this.tlpSetParameter.RowCount = 2;
            this.tlpSetParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpSetParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSetParameter.Size = new System.Drawing.Size(813, 548);
            this.tlpSetParameter.TabIndex = 1;
            // 
            // pnlShowSelectParameter
            // 
            this.pnlShowSelectParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlShowSelectParameter.Location = new System.Drawing.Point(3, 63);
            this.pnlShowSelectParameter.Name = "pnlShowSelectParameter";
            this.pnlShowSelectParameter.Size = new System.Drawing.Size(807, 482);
            this.pnlShowSelectParameter.TabIndex = 5;
            // 
            // pnlSelectParameter
            // 
            this.pnlSelectParameter.Controls.Add(this.tlpSelectParameter);
            this.pnlSelectParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSelectParameter.Location = new System.Drawing.Point(0, 0);
            this.pnlSelectParameter.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSelectParameter.Name = "pnlSelectParameter";
            this.pnlSelectParameter.Size = new System.Drawing.Size(813, 60);
            this.pnlSelectParameter.TabIndex = 2;
            // 
            // tlpSelectParameter
            // 
            this.tlpSelectParameter.ColumnCount = 3;
            this.tlpSelectParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSelectParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSelectParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSelectParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSelectParameter.Controls.Add(this.rdoMakerParmeter, 1, 0);
            this.tlpSelectParameter.Controls.Add(this.rdoEngineerParmeter, 0, 0);
            this.tlpSelectParameter.Controls.Add(this.rdoOption, 2, 0);
            this.tlpSelectParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSelectParameter.Location = new System.Drawing.Point(0, 0);
            this.tlpSelectParameter.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSelectParameter.Name = "tlpSelectParameter";
            this.tlpSelectParameter.RowCount = 1;
            this.tlpSelectParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSelectParameter.Size = new System.Drawing.Size(813, 60);
            this.tlpSelectParameter.TabIndex = 0;
            // 
            // rdoMakerParmeter
            // 
            this.rdoMakerParmeter.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoMakerParmeter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.rdoMakerParmeter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoMakerParmeter.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.rdoMakerParmeter.Location = new System.Drawing.Point(271, 0);
            this.rdoMakerParmeter.Margin = new System.Windows.Forms.Padding(0);
            this.rdoMakerParmeter.Name = "rdoMakerParmeter";
            this.rdoMakerParmeter.Size = new System.Drawing.Size(271, 60);
            this.rdoMakerParmeter.TabIndex = 1;
            this.rdoMakerParmeter.TabStop = true;
            this.rdoMakerParmeter.Text = "MAKER\r\nPARAMETER";
            this.rdoMakerParmeter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoMakerParmeter.UseVisualStyleBackColor = false;
            this.rdoMakerParmeter.CheckedChanged += new System.EventHandler(this.rdoMakerParmeter_CheckedChanged);
            // 
            // rdoEngineerParmeter
            // 
            this.rdoEngineerParmeter.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoEngineerParmeter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.rdoEngineerParmeter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoEngineerParmeter.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.rdoEngineerParmeter.Location = new System.Drawing.Point(0, 0);
            this.rdoEngineerParmeter.Margin = new System.Windows.Forms.Padding(0);
            this.rdoEngineerParmeter.Name = "rdoEngineerParmeter";
            this.rdoEngineerParmeter.Size = new System.Drawing.Size(271, 60);
            this.rdoEngineerParmeter.TabIndex = 2;
            this.rdoEngineerParmeter.TabStop = true;
            this.rdoEngineerParmeter.Text = "ENGINEER\r\nPARAMETER";
            this.rdoEngineerParmeter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoEngineerParmeter.UseVisualStyleBackColor = false;
            this.rdoEngineerParmeter.CheckedChanged += new System.EventHandler(this.rdoEngineerParmeter_CheckedChanged);
            // 
            // rdoOption
            // 
            this.rdoOption.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoOption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.rdoOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoOption.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.rdoOption.Location = new System.Drawing.Point(542, 0);
            this.rdoOption.Margin = new System.Windows.Forms.Padding(0);
            this.rdoOption.Name = "rdoOption";
            this.rdoOption.Size = new System.Drawing.Size(271, 60);
            this.rdoOption.TabIndex = 1;
            this.rdoOption.TabStop = true;
            this.rdoOption.Text = "OPTION";
            this.rdoOption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoOption.UseVisualStyleBackColor = false;
            this.rdoOption.CheckedChanged += new System.EventHandler(this.rdoOption_CheckedChanged);
            // 
            // MacronAkkonParamControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.Controls.Add(this.tlpSetParameter);
            this.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "MacronAkkonParamControl";
            this.Size = new System.Drawing.Size(813, 548);
            this.Load += new System.EventHandler(this.AkkonParamControl_Load);
            this.tlpSetParameter.ResumeLayout(false);
            this.pnlSelectParameter.ResumeLayout(false);
            this.tlpSelectParameter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpSetParameter;
        private System.Windows.Forms.Panel pnlShowSelectParameter;
        private System.Windows.Forms.Panel pnlSelectParameter;
        private System.Windows.Forms.TableLayoutPanel tlpSelectParameter;
        private System.Windows.Forms.RadioButton rdoMakerParmeter;
        private System.Windows.Forms.RadioButton rdoEngineerParmeter;
        private System.Windows.Forms.RadioButton rdoOption;
    }
}
