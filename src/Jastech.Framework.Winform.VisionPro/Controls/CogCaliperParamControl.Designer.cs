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
            this.tlpEdgePolarity = new System.Windows.Forms.TableLayoutPanel();
            this.rdoDarkToLight = new System.Windows.Forms.RadioButton();
            this.rdoLightToDark = new System.Windows.Forms.RadioButton();
            this.lblEdgePolarity = new System.Windows.Forms.Label();
            this.lblFilterSize = new System.Windows.Forms.Label();
            this.lblEdgeThreshold = new System.Windows.Forms.Label();
            this.tlpCaliperParam.SuspendLayout();
            this.tlpEdgePolarity.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFilterSizeValue
            // 
            this.lblFilterSizeValue.AutoSize = true;
            this.lblFilterSizeValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFilterSizeValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFilterSizeValue.Location = new System.Drawing.Point(214, 136);
            this.lblFilterSizeValue.Name = "lblFilterSizeValue";
            this.lblFilterSizeValue.Size = new System.Drawing.Size(205, 68);
            this.lblFilterSizeValue.TabIndex = 0;
            this.lblFilterSizeValue.Text = "2";
            this.lblFilterSizeValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEdgeThresholdValue
            // 
            this.lblEdgeThresholdValue.AutoSize = true;
            this.lblEdgeThresholdValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEdgeThresholdValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEdgeThresholdValue.Location = new System.Drawing.Point(214, 204);
            this.lblEdgeThresholdValue.Name = "lblEdgeThresholdValue";
            this.lblEdgeThresholdValue.Size = new System.Drawing.Size(205, 69);
            this.lblEdgeThresholdValue.TabIndex = 0;
            this.lblEdgeThresholdValue.Text = "5";
            this.lblEdgeThresholdValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpCaliperParam
            // 
            this.tlpCaliperParam.ColumnCount = 2;
            this.tlpCaliperParam.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCaliperParam.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCaliperParam.Controls.Add(this.lblEdgeThresholdValue, 1, 2);
            this.tlpCaliperParam.Controls.Add(this.lblFilterSizeValue, 1, 1);
            this.tlpCaliperParam.Controls.Add(this.tlpEdgePolarity, 1, 0);
            this.tlpCaliperParam.Controls.Add(this.lblEdgePolarity, 0, 0);
            this.tlpCaliperParam.Controls.Add(this.lblFilterSize, 0, 1);
            this.tlpCaliperParam.Controls.Add(this.lblEdgeThreshold, 0, 2);
            this.tlpCaliperParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCaliperParam.Location = new System.Drawing.Point(0, 0);
            this.tlpCaliperParam.Margin = new System.Windows.Forms.Padding(0);
            this.tlpCaliperParam.Name = "tlpCaliperParam";
            this.tlpCaliperParam.RowCount = 3;
            this.tlpCaliperParam.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCaliperParam.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCaliperParam.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCaliperParam.Size = new System.Drawing.Size(422, 273);
            this.tlpCaliperParam.TabIndex = 2;
            // 
            // tlpEdgePolarity
            // 
            this.tlpEdgePolarity.ColumnCount = 1;
            this.tlpEdgePolarity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEdgePolarity.Controls.Add(this.rdoDarkToLight, 0, 0);
            this.tlpEdgePolarity.Controls.Add(this.rdoLightToDark, 0, 1);
            this.tlpEdgePolarity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpEdgePolarity.Location = new System.Drawing.Point(211, 0);
            this.tlpEdgePolarity.Margin = new System.Windows.Forms.Padding(0);
            this.tlpEdgePolarity.Name = "tlpEdgePolarity";
            this.tlpEdgePolarity.RowCount = 2;
            this.tlpEdgePolarity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEdgePolarity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEdgePolarity.Size = new System.Drawing.Size(211, 136);
            this.tlpEdgePolarity.TabIndex = 1;
            // 
            // rdoDarkToLight
            // 
            this.rdoDarkToLight.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoDarkToLight.AutoSize = true;
            this.rdoDarkToLight.BackColor = System.Drawing.Color.White;
            this.rdoDarkToLight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoDarkToLight.Location = new System.Drawing.Point(0, 0);
            this.rdoDarkToLight.Margin = new System.Windows.Forms.Padding(0);
            this.rdoDarkToLight.Name = "rdoDarkToLight";
            this.rdoDarkToLight.Size = new System.Drawing.Size(211, 68);
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
            this.rdoLightToDark.BackColor = System.Drawing.Color.White;
            this.rdoLightToDark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoLightToDark.Location = new System.Drawing.Point(0, 68);
            this.rdoLightToDark.Margin = new System.Windows.Forms.Padding(0);
            this.rdoLightToDark.Name = "rdoLightToDark";
            this.rdoLightToDark.Size = new System.Drawing.Size(211, 68);
            this.rdoLightToDark.TabIndex = 0;
            this.rdoLightToDark.TabStop = true;
            this.rdoLightToDark.Text = "LIGHT ▶ DARK";
            this.rdoLightToDark.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoLightToDark.UseVisualStyleBackColor = false;
            this.rdoLightToDark.CheckedChanged += new System.EventHandler(this.rdoLightToDark_CheckedChanged);
            // 
            // lblEdgePolarity
            // 
            this.lblEdgePolarity.AutoSize = true;
            this.lblEdgePolarity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEdgePolarity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEdgePolarity.Location = new System.Drawing.Point(3, 0);
            this.lblEdgePolarity.Name = "lblEdgePolarity";
            this.lblEdgePolarity.Size = new System.Drawing.Size(205, 136);
            this.lblEdgePolarity.TabIndex = 0;
            this.lblEdgePolarity.Text = "EDGE POLARITY";
            this.lblEdgePolarity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFilterSize
            // 
            this.lblFilterSize.AutoSize = true;
            this.lblFilterSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFilterSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFilterSize.Location = new System.Drawing.Point(3, 136);
            this.lblFilterSize.Name = "lblFilterSize";
            this.lblFilterSize.Size = new System.Drawing.Size(205, 68);
            this.lblFilterSize.TabIndex = 0;
            this.lblFilterSize.Text = "FILTER SIZE";
            this.lblFilterSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEdgeThreshold
            // 
            this.lblEdgeThreshold.AutoSize = true;
            this.lblEdgeThreshold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEdgeThreshold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEdgeThreshold.Location = new System.Drawing.Point(3, 204);
            this.lblEdgeThreshold.Name = "lblEdgeThreshold";
            this.lblEdgeThreshold.Size = new System.Drawing.Size(205, 69);
            this.lblEdgeThreshold.TabIndex = 0;
            this.lblEdgeThreshold.Text = "EDGE THRESHOLD";
            this.lblEdgeThreshold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CogCaliperParamControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tlpCaliperParam);
            this.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CogCaliperParamControl";
            this.Size = new System.Drawing.Size(422, 273);
            this.Load += new System.EventHandler(this.CogCaliperParamControl_Load);
            this.tlpCaliperParam.ResumeLayout(false);
            this.tlpCaliperParam.PerformLayout();
            this.tlpEdgePolarity.ResumeLayout(false);
            this.tlpEdgePolarity.PerformLayout();
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
    }
}
