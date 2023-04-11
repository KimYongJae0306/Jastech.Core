namespace Jastech.Framework.Winform.VisionPro.Controls
{
    partial class CogCaliperParamControl
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
            this.lblFilterSizeValue = new System.Windows.Forms.Label();
            this.lblEdgeThresholdValue = new System.Windows.Forms.Label();
            this.tlpCaliperParam = new System.Windows.Forms.TableLayoutPanel();
            this.lblEdgePolarity = new System.Windows.Forms.Label();
            this.tlpEdgePolarity = new System.Windows.Forms.TableLayoutPanel();
            this.rdoDarkToLight = new System.Windows.Forms.RadioButton();
            this.rdoLightToDark = new System.Windows.Forms.RadioButton();
            this.lblFilterSize = new System.Windows.Forms.Label();
            this.lblEdgeThreshold = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tlpCaliperParam.SuspendLayout();
            this.tlpEdgePolarity.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFilterSizeValue
            // 
            this.lblFilterSizeValue.AutoSize = true;
            this.lblFilterSizeValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFilterSizeValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFilterSizeValue.Location = new System.Drawing.Point(212, 80);
            this.lblFilterSizeValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblFilterSizeValue.Name = "lblFilterSizeValue";
            this.lblFilterSizeValue.Size = new System.Drawing.Size(212, 40);
            this.lblFilterSizeValue.TabIndex = 0;
            this.lblFilterSizeValue.Text = "2";
            this.lblFilterSizeValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFilterSizeValue.Click += new System.EventHandler(this.lblFilterSizeValue_Click);
            // 
            // lblEdgeThresholdValue
            // 
            this.lblEdgeThresholdValue.AutoSize = true;
            this.lblEdgeThresholdValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEdgeThresholdValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEdgeThresholdValue.Location = new System.Drawing.Point(212, 120);
            this.lblEdgeThresholdValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblEdgeThresholdValue.Name = "lblEdgeThresholdValue";
            this.lblEdgeThresholdValue.Size = new System.Drawing.Size(212, 40);
            this.lblEdgeThresholdValue.TabIndex = 0;
            this.lblEdgeThresholdValue.Text = "5";
            this.lblEdgeThresholdValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEdgeThresholdValue.Click += new System.EventHandler(this.lblEdgeThresholdValue_Click);
            // 
            // tlpCaliperParam
            // 
            this.tlpCaliperParam.ColumnCount = 3;
            this.tlpCaliperParam.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpCaliperParam.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tlpCaliperParam.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 212F));
            this.tlpCaliperParam.Controls.Add(this.lblEdgeThresholdValue, 2, 2);
            this.tlpCaliperParam.Controls.Add(this.lblEdgePolarity, 0, 0);
            this.tlpCaliperParam.Controls.Add(this.lblFilterSizeValue, 2, 1);
            this.tlpCaliperParam.Controls.Add(this.tlpEdgePolarity, 2, 0);
            this.tlpCaliperParam.Controls.Add(this.lblFilterSize, 0, 1);
            this.tlpCaliperParam.Controls.Add(this.lblEdgeThreshold, 0, 2);
            this.tlpCaliperParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCaliperParam.Location = new System.Drawing.Point(0, 0);
            this.tlpCaliperParam.Margin = new System.Windows.Forms.Padding(0);
            this.tlpCaliperParam.Name = "tlpCaliperParam";
            this.tlpCaliperParam.RowCount = 3;
            this.tlpCaliperParam.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpCaliperParam.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpCaliperParam.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpCaliperParam.Size = new System.Drawing.Size(424, 160);
            this.tlpCaliperParam.TabIndex = 2;
            // 
            // lblEdgePolarity
            // 
            this.lblEdgePolarity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEdgePolarity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEdgePolarity.Location = new System.Drawing.Point(0, 0);
            this.lblEdgePolarity.Margin = new System.Windows.Forms.Padding(0);
            this.lblEdgePolarity.Name = "lblEdgePolarity";
            this.lblEdgePolarity.Size = new System.Drawing.Size(200, 80);
            this.lblEdgePolarity.TabIndex = 0;
            this.lblEdgePolarity.Text = "EDGE POLARITY";
            this.lblEdgePolarity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpEdgePolarity
            // 
            this.tlpEdgePolarity.ColumnCount = 1;
            this.tlpEdgePolarity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEdgePolarity.Controls.Add(this.rdoDarkToLight, 0, 0);
            this.tlpEdgePolarity.Controls.Add(this.rdoLightToDark, 0, 1);
            this.tlpEdgePolarity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpEdgePolarity.Location = new System.Drawing.Point(212, 0);
            this.tlpEdgePolarity.Margin = new System.Windows.Forms.Padding(0);
            this.tlpEdgePolarity.Name = "tlpEdgePolarity";
            this.tlpEdgePolarity.RowCount = 2;
            this.tlpEdgePolarity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEdgePolarity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEdgePolarity.Size = new System.Drawing.Size(212, 80);
            this.tlpEdgePolarity.TabIndex = 1;
            // 
            // rdoDarkToLight
            // 
            this.rdoDarkToLight.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoDarkToLight.AutoSize = true;
            this.rdoDarkToLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.rdoDarkToLight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoDarkToLight.Location = new System.Drawing.Point(0, 0);
            this.rdoDarkToLight.Margin = new System.Windows.Forms.Padding(0);
            this.rdoDarkToLight.Name = "rdoDarkToLight";
            this.rdoDarkToLight.Size = new System.Drawing.Size(212, 40);
            this.rdoDarkToLight.TabIndex = 0;
            this.rdoDarkToLight.TabStop = true;
            this.rdoDarkToLight.Text = "DARK ▶ LIGHT";
            this.rdoDarkToLight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoDarkToLight.UseVisualStyleBackColor = false;
            this.rdoDarkToLight.CheckedChanged += new System.EventHandler(this.rdoDarkToLight_CheckedChanged);
            // 
            // rdoLightToDark
            // 
            this.rdoLightToDark.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoLightToDark.AutoSize = true;
            this.rdoLightToDark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.rdoLightToDark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoLightToDark.Location = new System.Drawing.Point(0, 40);
            this.rdoLightToDark.Margin = new System.Windows.Forms.Padding(0);
            this.rdoLightToDark.Name = "rdoLightToDark";
            this.rdoLightToDark.Size = new System.Drawing.Size(212, 40);
            this.rdoLightToDark.TabIndex = 0;
            this.rdoLightToDark.TabStop = true;
            this.rdoLightToDark.Text = "LIGHT ▶ DARK";
            this.rdoLightToDark.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoLightToDark.UseVisualStyleBackColor = false;
            this.rdoLightToDark.CheckedChanged += new System.EventHandler(this.rdoLightToDark_CheckedChanged);
            // 
            // lblFilterSize
            // 
            this.lblFilterSize.AutoSize = true;
            this.lblFilterSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFilterSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFilterSize.Location = new System.Drawing.Point(0, 80);
            this.lblFilterSize.Margin = new System.Windows.Forms.Padding(0);
            this.lblFilterSize.Name = "lblFilterSize";
            this.lblFilterSize.Size = new System.Drawing.Size(200, 40);
            this.lblFilterSize.TabIndex = 0;
            this.lblFilterSize.Text = "FILTER SIZE";
            this.lblFilterSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEdgeThreshold
            // 
            this.lblEdgeThreshold.AutoSize = true;
            this.lblEdgeThreshold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEdgeThreshold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEdgeThreshold.Location = new System.Drawing.Point(0, 120);
            this.lblEdgeThreshold.Margin = new System.Windows.Forms.Padding(0);
            this.lblEdgeThreshold.Name = "lblEdgeThreshold";
            this.lblEdgeThreshold.Size = new System.Drawing.Size(200, 40);
            this.lblEdgeThreshold.TabIndex = 0;
            this.lblEdgeThreshold.Text = "EDGE THRESHOLD";
            this.lblEdgeThreshold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 424F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tlpCaliperParam, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(506, 192);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // CogCaliperParamControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "CogCaliperParamControl";
            this.Size = new System.Drawing.Size(506, 192);
            this.Load += new System.EventHandler(this.CogCaliperParamControl_Load);
            this.tlpCaliperParam.ResumeLayout(false);
            this.tlpCaliperParam.PerformLayout();
            this.tlpEdgePolarity.ResumeLayout(false);
            this.tlpEdgePolarity.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblFilterSizeValue;
        private System.Windows.Forms.Label lblEdgeThresholdValue;
        private System.Windows.Forms.TableLayoutPanel tlpCaliperParam;
        private System.Windows.Forms.RadioButton rdoDarkToLight;
        private System.Windows.Forms.RadioButton rdoLightToDark;
        private System.Windows.Forms.TableLayoutPanel tlpEdgePolarity;
        private System.Windows.Forms.Label lblEdgePolarity;
        private System.Windows.Forms.Label lblFilterSize;
        private System.Windows.Forms.Label lblEdgeThreshold;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
