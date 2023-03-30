namespace Jastech.Framework.Winform.Controls
{
    partial class MotionParameterCommonControl
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
            this.tlpMotionCommonParameter = new System.Windows.Forms.TableLayoutPanel();
            this.lblNegativeLimitValue = new System.Windows.Forms.Label();
            this.lblNegativeLimit = new System.Windows.Forms.Label();
            this.lblJogLowSpeedValue = new System.Windows.Forms.Label();
            this.lblJogLowSpeed = new System.Windows.Forms.Label();
            this.lblJogHighSpeed = new System.Windows.Forms.Label();
            this.lblPositiveLimit = new System.Windows.Forms.Label();
            this.lblJogHighSpeedValue = new System.Windows.Forms.Label();
            this.lblPositiveLimitValue = new System.Windows.Forms.Label();
            this.lblMoveTolerance = new System.Windows.Forms.Label();
            this.lblMoveToleranceValue = new System.Windows.Forms.Label();
            this.lblHomingTimeOut = new System.Windows.Forms.Label();
            this.lblHomingTimeOutValue = new System.Windows.Forms.Label();
            this.tlpMotionCommonParameter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMotionCommonParameter
            // 
            this.tlpMotionCommonParameter.ColumnCount = 8;
            this.tlpMotionCommonParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMotionCommonParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMotionCommonParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpMotionCommonParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMotionCommonParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMotionCommonParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpMotionCommonParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMotionCommonParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMotionCommonParameter.Controls.Add(this.lblNegativeLimitValue, 1, 1);
            this.tlpMotionCommonParameter.Controls.Add(this.lblNegativeLimit, 0, 1);
            this.tlpMotionCommonParameter.Controls.Add(this.lblJogLowSpeedValue, 1, 0);
            this.tlpMotionCommonParameter.Controls.Add(this.lblJogLowSpeed, 0, 0);
            this.tlpMotionCommonParameter.Controls.Add(this.lblJogHighSpeed, 3, 0);
            this.tlpMotionCommonParameter.Controls.Add(this.lblPositiveLimit, 3, 1);
            this.tlpMotionCommonParameter.Controls.Add(this.lblJogHighSpeedValue, 4, 0);
            this.tlpMotionCommonParameter.Controls.Add(this.lblPositiveLimitValue, 4, 1);
            this.tlpMotionCommonParameter.Controls.Add(this.lblMoveTolerance, 6, 0);
            this.tlpMotionCommonParameter.Controls.Add(this.lblMoveToleranceValue, 7, 0);
            this.tlpMotionCommonParameter.Controls.Add(this.lblHomingTimeOut, 6, 1);
            this.tlpMotionCommonParameter.Controls.Add(this.lblHomingTimeOutValue, 7, 1);
            this.tlpMotionCommonParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMotionCommonParameter.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.tlpMotionCommonParameter.Location = new System.Drawing.Point(0, 0);
            this.tlpMotionCommonParameter.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMotionCommonParameter.Name = "tlpMotionCommonParameter";
            this.tlpMotionCommonParameter.RowCount = 2;
            this.tlpMotionCommonParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMotionCommonParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMotionCommonParameter.Size = new System.Drawing.Size(700, 160);
            this.tlpMotionCommonParameter.TabIndex = 1;
            // 
            // lblNegativeLimitValue
            // 
            this.lblNegativeLimitValue.BackColor = System.Drawing.Color.White;
            this.lblNegativeLimitValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNegativeLimitValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNegativeLimitValue.Location = new System.Drawing.Point(146, 83);
            this.lblNegativeLimitValue.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblNegativeLimitValue.Name = "lblNegativeLimitValue";
            this.lblNegativeLimitValue.Size = new System.Drawing.Size(58, 74);
            this.lblNegativeLimitValue.TabIndex = 7;
            this.lblNegativeLimitValue.Text = "0.0";
            this.lblNegativeLimitValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNegativeLimitValue.Click += new System.EventHandler(this.Value_Changed);
            // 
            // lblNegativeLimit
            // 
            this.lblNegativeLimit.BackColor = System.Drawing.Color.White;
            this.lblNegativeLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNegativeLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNegativeLimit.Location = new System.Drawing.Point(6, 83);
            this.lblNegativeLimit.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblNegativeLimit.Name = "lblNegativeLimit";
            this.lblNegativeLimit.Size = new System.Drawing.Size(128, 74);
            this.lblNegativeLimit.TabIndex = 6;
            this.lblNegativeLimit.Text = "NEGATIVE\r\nLIMIT (mm)";
            this.lblNegativeLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblJogLowSpeedValue
            // 
            this.lblJogLowSpeedValue.BackColor = System.Drawing.Color.White;
            this.lblJogLowSpeedValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblJogLowSpeedValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblJogLowSpeedValue.Location = new System.Drawing.Point(146, 3);
            this.lblJogLowSpeedValue.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblJogLowSpeedValue.Name = "lblJogLowSpeedValue";
            this.lblJogLowSpeedValue.Size = new System.Drawing.Size(58, 74);
            this.lblJogLowSpeedValue.TabIndex = 3;
            this.lblJogLowSpeedValue.Text = "0.0";
            this.lblJogLowSpeedValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblJogLowSpeedValue.Click += new System.EventHandler(this.Value_Changed);
            // 
            // lblJogLowSpeed
            // 
            this.lblJogLowSpeed.BackColor = System.Drawing.Color.White;
            this.lblJogLowSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblJogLowSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblJogLowSpeed.Location = new System.Drawing.Point(6, 3);
            this.lblJogLowSpeed.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblJogLowSpeed.Name = "lblJogLowSpeed";
            this.lblJogLowSpeed.Size = new System.Drawing.Size(128, 74);
            this.lblJogLowSpeed.TabIndex = 1;
            this.lblJogLowSpeed.Text = "JOG LOW SPEED\r\n(mm/sec)";
            this.lblJogLowSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblJogHighSpeed
            // 
            this.lblJogHighSpeed.BackColor = System.Drawing.Color.White;
            this.lblJogHighSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblJogHighSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblJogHighSpeed.Location = new System.Drawing.Point(251, 3);
            this.lblJogHighSpeed.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblJogHighSpeed.Name = "lblJogHighSpeed";
            this.lblJogHighSpeed.Size = new System.Drawing.Size(128, 74);
            this.lblJogHighSpeed.TabIndex = 8;
            this.lblJogHighSpeed.Text = "JOG HIGH SPEED\r\n(mm/sec)";
            this.lblJogHighSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPositiveLimit
            // 
            this.lblPositiveLimit.BackColor = System.Drawing.Color.White;
            this.lblPositiveLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPositiveLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPositiveLimit.Location = new System.Drawing.Point(251, 83);
            this.lblPositiveLimit.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblPositiveLimit.Name = "lblPositiveLimit";
            this.lblPositiveLimit.Size = new System.Drawing.Size(128, 74);
            this.lblPositiveLimit.TabIndex = 9;
            this.lblPositiveLimit.Text = "POSITIVE\r\nLIMIT (mm)";
            this.lblPositiveLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblJogHighSpeedValue
            // 
            this.lblJogHighSpeedValue.BackColor = System.Drawing.Color.White;
            this.lblJogHighSpeedValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblJogHighSpeedValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblJogHighSpeedValue.Location = new System.Drawing.Point(391, 3);
            this.lblJogHighSpeedValue.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblJogHighSpeedValue.Name = "lblJogHighSpeedValue";
            this.lblJogHighSpeedValue.Size = new System.Drawing.Size(58, 74);
            this.lblJogHighSpeedValue.TabIndex = 10;
            this.lblJogHighSpeedValue.Text = "0.0";
            this.lblJogHighSpeedValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblJogHighSpeedValue.Click += new System.EventHandler(this.Value_Changed);
            // 
            // lblPositiveLimitValue
            // 
            this.lblPositiveLimitValue.BackColor = System.Drawing.Color.White;
            this.lblPositiveLimitValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPositiveLimitValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPositiveLimitValue.Location = new System.Drawing.Point(391, 83);
            this.lblPositiveLimitValue.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblPositiveLimitValue.Name = "lblPositiveLimitValue";
            this.lblPositiveLimitValue.Size = new System.Drawing.Size(58, 74);
            this.lblPositiveLimitValue.TabIndex = 11;
            this.lblPositiveLimitValue.Text = "0.0";
            this.lblPositiveLimitValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPositiveLimitValue.Click += new System.EventHandler(this.Value_Changed);
            // 
            // lblMoveTolerance
            // 
            this.lblMoveTolerance.BackColor = System.Drawing.Color.White;
            this.lblMoveTolerance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMoveTolerance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMoveTolerance.Location = new System.Drawing.Point(496, 3);
            this.lblMoveTolerance.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblMoveTolerance.Name = "lblMoveTolerance";
            this.lblMoveTolerance.Size = new System.Drawing.Size(128, 74);
            this.lblMoveTolerance.TabIndex = 12;
            this.lblMoveTolerance.Text = "MOVE\r\nTOLERANCE (mm)";
            this.lblMoveTolerance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMoveToleranceValue
            // 
            this.lblMoveToleranceValue.BackColor = System.Drawing.Color.White;
            this.lblMoveToleranceValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMoveToleranceValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMoveToleranceValue.Location = new System.Drawing.Point(636, 3);
            this.lblMoveToleranceValue.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblMoveToleranceValue.Name = "lblMoveToleranceValue";
            this.lblMoveToleranceValue.Size = new System.Drawing.Size(58, 74);
            this.lblMoveToleranceValue.TabIndex = 13;
            this.lblMoveToleranceValue.Text = "0.0";
            this.lblMoveToleranceValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMoveToleranceValue.Click += new System.EventHandler(this.Value_Changed);
            // 
            // lblHomingTimeOut
            // 
            this.lblHomingTimeOut.BackColor = System.Drawing.Color.White;
            this.lblHomingTimeOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHomingTimeOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHomingTimeOut.Location = new System.Drawing.Point(496, 83);
            this.lblHomingTimeOut.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblHomingTimeOut.Name = "lblHomingTimeOut";
            this.lblHomingTimeOut.Size = new System.Drawing.Size(128, 74);
            this.lblHomingTimeOut.TabIndex = 14;
            this.lblHomingTimeOut.Text = "HOMING\r\nTIMEOUT (sec)";
            this.lblHomingTimeOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHomingTimeOutValue
            // 
            this.lblHomingTimeOutValue.BackColor = System.Drawing.Color.White;
            this.lblHomingTimeOutValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHomingTimeOutValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHomingTimeOutValue.Location = new System.Drawing.Point(636, 83);
            this.lblHomingTimeOutValue.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblHomingTimeOutValue.Name = "lblHomingTimeOutValue";
            this.lblHomingTimeOutValue.Size = new System.Drawing.Size(58, 74);
            this.lblHomingTimeOutValue.TabIndex = 15;
            this.lblHomingTimeOutValue.Text = "0.0";
            this.lblHomingTimeOutValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHomingTimeOutValue.Click += new System.EventHandler(this.Value_Changed);
            // 
            // MotionParameterCommonControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tlpMotionCommonParameter);
            this.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.Name = "MotionParameterCommonControl";
            this.Size = new System.Drawing.Size(700, 160);
            this.tlpMotionCommonParameter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMotionCommonParameter;
        private System.Windows.Forms.Label lblNegativeLimitValue;
        private System.Windows.Forms.Label lblNegativeLimit;
        private System.Windows.Forms.Label lblJogLowSpeedValue;
        private System.Windows.Forms.Label lblJogLowSpeed;
        private System.Windows.Forms.Label lblJogHighSpeed;
        private System.Windows.Forms.Label lblPositiveLimit;
        private System.Windows.Forms.Label lblJogHighSpeedValue;
        private System.Windows.Forms.Label lblPositiveLimitValue;
        private System.Windows.Forms.Label lblMoveTolerance;
        private System.Windows.Forms.Label lblMoveToleranceValue;
        private System.Windows.Forms.Label lblHomingTimeOut;
        private System.Windows.Forms.Label lblHomingTimeOutValue;
    }
}
