namespace Jastech.Framework.Winform.Controls
{
    partial class MotionCommandControl
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
            this.tlpMotionCommand = new System.Windows.Forms.TableLayoutPanel();
            this.lblServoOnOff = new System.Windows.Forms.Label();
            this.lblCurrentToTarget = new System.Windows.Forms.Label();
            this.lblMoveToTarget = new System.Windows.Forms.Label();
            this.lblSensor = new System.Windows.Forms.Label();
            this.lblAxisStatus = new System.Windows.Forms.Label();
            this.lblCurrentPosition = new System.Windows.Forms.Label();
            this.lblOffsest = new System.Windows.Forms.Label();
            this.lblTargetPosition = new System.Windows.Forms.Label();
            this.lblAxisName = new System.Windows.Forms.Label();
            this.tlpMotionCommand.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMotionCommand
            // 
            this.tlpMotionCommand.ColumnCount = 1;
            this.tlpMotionCommand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMotionCommand.Controls.Add(this.lblServoOnOff, 0, 8);
            this.tlpMotionCommand.Controls.Add(this.lblCurrentToTarget, 0, 5);
            this.tlpMotionCommand.Controls.Add(this.lblMoveToTarget, 0, 3);
            this.tlpMotionCommand.Controls.Add(this.lblSensor, 0, 6);
            this.tlpMotionCommand.Controls.Add(this.lblAxisStatus, 0, 7);
            this.tlpMotionCommand.Controls.Add(this.lblCurrentPosition, 0, 4);
            this.tlpMotionCommand.Controls.Add(this.lblOffsest, 0, 2);
            this.tlpMotionCommand.Controls.Add(this.lblTargetPosition, 0, 1);
            this.tlpMotionCommand.Controls.Add(this.lblAxisName, 0, 0);
            this.tlpMotionCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMotionCommand.Location = new System.Drawing.Point(0, 0);
            this.tlpMotionCommand.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMotionCommand.Name = "tlpMotionCommand";
            this.tlpMotionCommand.RowCount = 9;
            this.tlpMotionCommand.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpMotionCommand.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpMotionCommand.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpMotionCommand.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpMotionCommand.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpMotionCommand.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpMotionCommand.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpMotionCommand.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpMotionCommand.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpMotionCommand.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMotionCommand.Size = new System.Drawing.Size(200, 400);
            this.tlpMotionCommand.TabIndex = 0;
            // 
            // lblServoOnOff
            // 
            this.lblServoOnOff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblServoOnOff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblServoOnOff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblServoOnOff.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblServoOnOff.ForeColor = System.Drawing.Color.White;
            this.lblServoOnOff.Location = new System.Drawing.Point(1, 353);
            this.lblServoOnOff.Margin = new System.Windows.Forms.Padding(1);
            this.lblServoOnOff.Name = "lblServoOnOff";
            this.lblServoOnOff.Size = new System.Drawing.Size(198, 46);
            this.lblServoOnOff.TabIndex = 24;
            this.lblServoOnOff.Text = "On";
            this.lblServoOnOff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblServoOnOff.Click += new System.EventHandler(this.lblServoOnOff_Click);
            // 
            // lblCurrentToTarget
            // 
            this.lblCurrentToTarget.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblCurrentToTarget.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCurrentToTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrentToTarget.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblCurrentToTarget.ForeColor = System.Drawing.Color.White;
            this.lblCurrentToTarget.Location = new System.Drawing.Point(1, 221);
            this.lblCurrentToTarget.Margin = new System.Windows.Forms.Padding(1);
            this.lblCurrentToTarget.Name = "lblCurrentToTarget";
            this.lblCurrentToTarget.Size = new System.Drawing.Size(198, 42);
            this.lblCurrentToTarget.TabIndex = 23;
            this.lblCurrentToTarget.Text = "Set";
            this.lblCurrentToTarget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMoveToTarget
            // 
            this.lblMoveToTarget.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblMoveToTarget.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMoveToTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMoveToTarget.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblMoveToTarget.ForeColor = System.Drawing.Color.White;
            this.lblMoveToTarget.Location = new System.Drawing.Point(1, 133);
            this.lblMoveToTarget.Margin = new System.Windows.Forms.Padding(1);
            this.lblMoveToTarget.Name = "lblMoveToTarget";
            this.lblMoveToTarget.Size = new System.Drawing.Size(198, 42);
            this.lblMoveToTarget.TabIndex = 22;
            this.lblMoveToTarget.Text = "Move To";
            this.lblMoveToTarget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSensor
            // 
            this.lblSensor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblSensor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSensor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSensor.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblSensor.ForeColor = System.Drawing.Color.White;
            this.lblSensor.Location = new System.Drawing.Point(1, 265);
            this.lblSensor.Margin = new System.Windows.Forms.Padding(1);
            this.lblSensor.Name = "lblSensor";
            this.lblSensor.Size = new System.Drawing.Size(198, 42);
            this.lblSensor.TabIndex = 8;
            this.lblSensor.Text = "Done";
            this.lblSensor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAxisStatus
            // 
            this.lblAxisStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblAxisStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAxisStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAxisStatus.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblAxisStatus.ForeColor = System.Drawing.Color.White;
            this.lblAxisStatus.Location = new System.Drawing.Point(1, 309);
            this.lblAxisStatus.Margin = new System.Windows.Forms.Padding(1);
            this.lblAxisStatus.Name = "lblAxisStatus";
            this.lblAxisStatus.Size = new System.Drawing.Size(198, 42);
            this.lblAxisStatus.TabIndex = 7;
            this.lblAxisStatus.Text = "Done";
            this.lblAxisStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrentPosition
            // 
            this.lblCurrentPosition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblCurrentPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCurrentPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrentPosition.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblCurrentPosition.ForeColor = System.Drawing.Color.White;
            this.lblCurrentPosition.Location = new System.Drawing.Point(1, 177);
            this.lblCurrentPosition.Margin = new System.Windows.Forms.Padding(1);
            this.lblCurrentPosition.Name = "lblCurrentPosition";
            this.lblCurrentPosition.Size = new System.Drawing.Size(198, 42);
            this.lblCurrentPosition.TabIndex = 6;
            this.lblCurrentPosition.Text = "0.0";
            this.lblCurrentPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOffsest
            // 
            this.lblOffsest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblOffsest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOffsest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOffsest.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblOffsest.ForeColor = System.Drawing.Color.White;
            this.lblOffsest.Location = new System.Drawing.Point(1, 89);
            this.lblOffsest.Margin = new System.Windows.Forms.Padding(1);
            this.lblOffsest.Name = "lblOffsest";
            this.lblOffsest.Size = new System.Drawing.Size(198, 42);
            this.lblOffsest.TabIndex = 5;
            this.lblOffsest.Text = "0.0";
            this.lblOffsest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblOffsest.Click += new System.EventHandler(this.lblOffsest_Click);
            // 
            // lblTargetPosition
            // 
            this.lblTargetPosition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblTargetPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTargetPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTargetPosition.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblTargetPosition.ForeColor = System.Drawing.Color.White;
            this.lblTargetPosition.Location = new System.Drawing.Point(1, 45);
            this.lblTargetPosition.Margin = new System.Windows.Forms.Padding(1);
            this.lblTargetPosition.Name = "lblTargetPosition";
            this.lblTargetPosition.Size = new System.Drawing.Size(198, 42);
            this.lblTargetPosition.TabIndex = 4;
            this.lblTargetPosition.Text = "0.0";
            this.lblTargetPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTargetPosition.Click += new System.EventHandler(this.lblTargetPosition_Click);
            // 
            // lblAxisName
            // 
            this.lblAxisName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblAxisName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAxisName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAxisName.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblAxisName.ForeColor = System.Drawing.Color.White;
            this.lblAxisName.Location = new System.Drawing.Point(1, 1);
            this.lblAxisName.Margin = new System.Windows.Forms.Padding(1);
            this.lblAxisName.Name = "lblAxisName";
            this.lblAxisName.Size = new System.Drawing.Size(198, 42);
            this.lblAxisName.TabIndex = 3;
            this.lblAxisName.Text = "X";
            this.lblAxisName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MotionCommandControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.Controls.Add(this.tlpMotionCommand);
            this.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.Name = "MotionCommandControl";
            this.Size = new System.Drawing.Size(200, 400);
            this.Load += new System.EventHandler(this.MotionCommandControl_Load);
            this.tlpMotionCommand.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMotionCommand;
        private System.Windows.Forms.Label lblSensor;
        private System.Windows.Forms.Label lblAxisStatus;
        private System.Windows.Forms.Label lblCurrentPosition;
        private System.Windows.Forms.Label lblOffsest;
        private System.Windows.Forms.Label lblTargetPosition;
        private System.Windows.Forms.Label lblAxisName;
        private System.Windows.Forms.Label lblCurrentToTarget;
        private System.Windows.Forms.Label lblMoveToTarget;
        private System.Windows.Forms.Label lblServoOnOff;
    }
}
