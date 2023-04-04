namespace Jastech.Framework.Winform.Controls
{
    partial class MotionParameterVariableControl
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
            this.tlpMotionVariableParameter = new System.Windows.Forms.TableLayoutPanel();
            this.lblMovingTimeOutValue = new System.Windows.Forms.Label();
            this.lblMovingTimeOut = new System.Windows.Forms.Label();
            this.lblVelocityValue = new System.Windows.Forms.Label();
            this.lblVelocity = new System.Windows.Forms.Label();
            this.lblAccelerationTime = new System.Windows.Forms.Label();
            this.lblAfterWaitTime = new System.Windows.Forms.Label();
            this.lblAccelerationTimeValue = new System.Windows.Forms.Label();
            this.lblAfterWaitTimeValue = new System.Windows.Forms.Label();
            this.lblDecelerationTime = new System.Windows.Forms.Label();
            this.lblDecelerationTimeValue = new System.Windows.Forms.Label();
            this.grpAxisName = new System.Windows.Forms.GroupBox();
            this.tlpMotionVariableParameter.SuspendLayout();
            this.grpAxisName.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMotionVariableParameter
            // 
            this.tlpMotionVariableParameter.ColumnCount = 8;
            this.tlpMotionVariableParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMotionVariableParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMotionVariableParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpMotionVariableParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMotionVariableParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMotionVariableParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpMotionVariableParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMotionVariableParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMotionVariableParameter.Controls.Add(this.lblMovingTimeOutValue, 1, 1);
            this.tlpMotionVariableParameter.Controls.Add(this.lblMovingTimeOut, 0, 1);
            this.tlpMotionVariableParameter.Controls.Add(this.lblVelocityValue, 1, 0);
            this.tlpMotionVariableParameter.Controls.Add(this.lblVelocity, 0, 0);
            this.tlpMotionVariableParameter.Controls.Add(this.lblAccelerationTime, 3, 0);
            this.tlpMotionVariableParameter.Controls.Add(this.lblAfterWaitTime, 3, 1);
            this.tlpMotionVariableParameter.Controls.Add(this.lblAccelerationTimeValue, 4, 0);
            this.tlpMotionVariableParameter.Controls.Add(this.lblAfterWaitTimeValue, 4, 1);
            this.tlpMotionVariableParameter.Controls.Add(this.lblDecelerationTime, 6, 0);
            this.tlpMotionVariableParameter.Controls.Add(this.lblDecelerationTimeValue, 7, 0);
            this.tlpMotionVariableParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMotionVariableParameter.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.tlpMotionVariableParameter.Location = new System.Drawing.Point(3, 23);
            this.tlpMotionVariableParameter.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMotionVariableParameter.Name = "tlpMotionVariableParameter";
            this.tlpMotionVariableParameter.RowCount = 2;
            this.tlpMotionVariableParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMotionVariableParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMotionVariableParameter.Size = new System.Drawing.Size(694, 134);
            this.tlpMotionVariableParameter.TabIndex = 1;
            // 
            // lblMovingTimeOutValue
            // 
            this.lblMovingTimeOutValue.BackColor = System.Drawing.Color.White;
            this.lblMovingTimeOutValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMovingTimeOutValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMovingTimeOutValue.Location = new System.Drawing.Point(144, 70);
            this.lblMovingTimeOutValue.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblMovingTimeOutValue.Name = "lblMovingTimeOutValue";
            this.lblMovingTimeOutValue.Size = new System.Drawing.Size(57, 61);
            this.lblMovingTimeOutValue.TabIndex = 5;
            this.lblMovingTimeOutValue.Text = "0.0";
            this.lblMovingTimeOutValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMovingTimeOutValue.Click += new System.EventHandler(this.Value_Changed);
            // 
            // lblMovingTimeOut
            // 
            this.lblMovingTimeOut.BackColor = System.Drawing.Color.White;
            this.lblMovingTimeOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMovingTimeOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMovingTimeOut.Location = new System.Drawing.Point(6, 70);
            this.lblMovingTimeOut.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblMovingTimeOut.Name = "lblMovingTimeOut";
            this.lblMovingTimeOut.Size = new System.Drawing.Size(126, 61);
            this.lblMovingTimeOut.TabIndex = 4;
            this.lblMovingTimeOut.Text = "MOVING\r\nTIMEOUT (sec)";
            this.lblMovingTimeOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVelocityValue
            // 
            this.lblVelocityValue.BackColor = System.Drawing.Color.White;
            this.lblVelocityValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblVelocityValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVelocityValue.Location = new System.Drawing.Point(144, 3);
            this.lblVelocityValue.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblVelocityValue.Name = "lblVelocityValue";
            this.lblVelocityValue.Size = new System.Drawing.Size(57, 61);
            this.lblVelocityValue.TabIndex = 3;
            this.lblVelocityValue.Text = "0.0";
            this.lblVelocityValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblVelocityValue.Click += new System.EventHandler(this.Value_Changed);
            // 
            // lblVelocity
            // 
            this.lblVelocity.BackColor = System.Drawing.Color.White;
            this.lblVelocity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblVelocity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVelocity.Location = new System.Drawing.Point(6, 3);
            this.lblVelocity.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblVelocity.Name = "lblVelocity";
            this.lblVelocity.Size = new System.Drawing.Size(126, 61);
            this.lblVelocity.TabIndex = 1;
            this.lblVelocity.Text = "VELOCITY\r\n(mm/sec)";
            this.lblVelocity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAccelerationTime
            // 
            this.lblAccelerationTime.BackColor = System.Drawing.Color.White;
            this.lblAccelerationTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAccelerationTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAccelerationTime.Location = new System.Drawing.Point(247, 3);
            this.lblAccelerationTime.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblAccelerationTime.Name = "lblAccelerationTime";
            this.lblAccelerationTime.Size = new System.Drawing.Size(126, 61);
            this.lblAccelerationTime.TabIndex = 6;
            this.lblAccelerationTime.Text = "ACCELERATION\r\nTIME (ms)";
            this.lblAccelerationTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAfterWaitTime
            // 
            this.lblAfterWaitTime.BackColor = System.Drawing.Color.White;
            this.lblAfterWaitTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAfterWaitTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAfterWaitTime.Location = new System.Drawing.Point(247, 70);
            this.lblAfterWaitTime.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblAfterWaitTime.Name = "lblAfterWaitTime";
            this.lblAfterWaitTime.Size = new System.Drawing.Size(126, 61);
            this.lblAfterWaitTime.TabIndex = 7;
            this.lblAfterWaitTime.Text = "AFTER\r\nWAIT TIME (sec)";
            this.lblAfterWaitTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAccelerationTimeValue
            // 
            this.lblAccelerationTimeValue.BackColor = System.Drawing.Color.White;
            this.lblAccelerationTimeValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAccelerationTimeValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAccelerationTimeValue.Location = new System.Drawing.Point(385, 3);
            this.lblAccelerationTimeValue.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblAccelerationTimeValue.Name = "lblAccelerationTimeValue";
            this.lblAccelerationTimeValue.Size = new System.Drawing.Size(57, 61);
            this.lblAccelerationTimeValue.TabIndex = 8;
            this.lblAccelerationTimeValue.Text = "0.0";
            this.lblAccelerationTimeValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAccelerationTimeValue.Click += new System.EventHandler(this.Value_Changed);
            // 
            // lblAfterWaitTimeValue
            // 
            this.lblAfterWaitTimeValue.BackColor = System.Drawing.Color.White;
            this.lblAfterWaitTimeValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAfterWaitTimeValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAfterWaitTimeValue.Location = new System.Drawing.Point(385, 70);
            this.lblAfterWaitTimeValue.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblAfterWaitTimeValue.Name = "lblAfterWaitTimeValue";
            this.lblAfterWaitTimeValue.Size = new System.Drawing.Size(57, 61);
            this.lblAfterWaitTimeValue.TabIndex = 9;
            this.lblAfterWaitTimeValue.Text = "0.0";
            this.lblAfterWaitTimeValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAfterWaitTimeValue.Click += new System.EventHandler(this.Value_Changed);
            // 
            // lblDecelerationTime
            // 
            this.lblDecelerationTime.BackColor = System.Drawing.Color.White;
            this.lblDecelerationTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDecelerationTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDecelerationTime.Location = new System.Drawing.Point(488, 3);
            this.lblDecelerationTime.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblDecelerationTime.Name = "lblDecelerationTime";
            this.lblDecelerationTime.Size = new System.Drawing.Size(126, 61);
            this.lblDecelerationTime.TabIndex = 10;
            this.lblDecelerationTime.Text = "DECELERATION\r\nTIME (ms)";
            this.lblDecelerationTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDecelerationTimeValue
            // 
            this.lblDecelerationTimeValue.BackColor = System.Drawing.Color.White;
            this.lblDecelerationTimeValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDecelerationTimeValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDecelerationTimeValue.Location = new System.Drawing.Point(626, 3);
            this.lblDecelerationTimeValue.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblDecelerationTimeValue.Name = "lblDecelerationTimeValue";
            this.lblDecelerationTimeValue.Size = new System.Drawing.Size(62, 61);
            this.lblDecelerationTimeValue.TabIndex = 11;
            this.lblDecelerationTimeValue.Text = "0.0";
            this.lblDecelerationTimeValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDecelerationTimeValue.Click += new System.EventHandler(this.Value_Changed);
            // 
            // grpAxisName
            // 
            this.grpAxisName.Controls.Add(this.tlpMotionVariableParameter);
            this.grpAxisName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAxisName.Location = new System.Drawing.Point(0, 0);
            this.grpAxisName.Name = "grpAxisName";
            this.grpAxisName.Size = new System.Drawing.Size(700, 160);
            this.grpAxisName.TabIndex = 2;
            this.grpAxisName.TabStop = false;
            this.grpAxisName.Text = "Axis Name";
            // 
            // MotionParameterVariableControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.grpAxisName);
            this.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.Name = "MotionParameterVariableControl";
            this.Size = new System.Drawing.Size(700, 160);
            this.Load += new System.EventHandler(this.MotionParameterVariableControl_Load);
            this.tlpMotionVariableParameter.ResumeLayout(false);
            this.grpAxisName.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMotionVariableParameter;
        private System.Windows.Forms.Label lblMovingTimeOutValue;
        private System.Windows.Forms.Label lblMovingTimeOut;
        private System.Windows.Forms.Label lblVelocityValue;
        private System.Windows.Forms.Label lblVelocity;
        private System.Windows.Forms.Label lblAccelerationTime;
        private System.Windows.Forms.Label lblAfterWaitTime;
        private System.Windows.Forms.Label lblAccelerationTimeValue;
        private System.Windows.Forms.Label lblAfterWaitTimeValue;
        private System.Windows.Forms.Label lblDecelerationTime;
        private System.Windows.Forms.Label lblDecelerationTimeValue;
        private System.Windows.Forms.GroupBox grpAxisName;
    }
}
