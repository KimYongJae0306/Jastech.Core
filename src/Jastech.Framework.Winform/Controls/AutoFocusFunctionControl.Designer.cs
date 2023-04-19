namespace Jastech.Framework.Winform.Controls
{
    partial class AutoFocusFunctionControl
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
            this.tlpAutoFocusFunction = new System.Windows.Forms.TableLayoutPanel();
            this.lblMoveTo = new System.Windows.Forms.Label();
            this.lblCurrentToTargetZ = new System.Windows.Forms.Label();
            this.lblAutoFocusOnOff = new System.Windows.Forms.Label();
            this.lblSensor = new System.Windows.Forms.Label();
            this.lblCurrentPosition = new System.Windows.Forms.Label();
            this.lblTargetPosition = new System.Windows.Forms.Label();
            this.lblAxisName = new System.Windows.Forms.Label();
            this.lblCurrentCenterOfGravity = new System.Windows.Forms.Label();
            this.lblTeachedCOG = new System.Windows.Forms.Label();
            this.lblCurrentToTargetCOG = new System.Windows.Forms.Label();
            this.tlpAutoFocusFunction.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpAutoFocusFunction
            // 
            this.tlpAutoFocusFunction.ColumnCount = 1;
            this.tlpAutoFocusFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAutoFocusFunction.Controls.Add(this.lblTargetPosition, 0, 1);
            this.tlpAutoFocusFunction.Controls.Add(this.lblAxisName, 0, 0);
            this.tlpAutoFocusFunction.Controls.Add(this.lblCurrentPosition, 0, 2);
            this.tlpAutoFocusFunction.Controls.Add(this.lblCurrentToTargetZ, 0, 3);
            this.tlpAutoFocusFunction.Controls.Add(this.lblCurrentCenterOfGravity, 0, 5);
            this.tlpAutoFocusFunction.Controls.Add(this.lblTeachedCOG, 0, 4);
            this.tlpAutoFocusFunction.Controls.Add(this.lblAutoFocusOnOff, 0, 9);
            this.tlpAutoFocusFunction.Controls.Add(this.lblSensor, 0, 8);
            this.tlpAutoFocusFunction.Controls.Add(this.lblMoveTo, 0, 7);
            this.tlpAutoFocusFunction.Controls.Add(this.lblCurrentToTargetCOG, 0, 6);
            this.tlpAutoFocusFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAutoFocusFunction.Location = new System.Drawing.Point(0, 0);
            this.tlpAutoFocusFunction.Margin = new System.Windows.Forms.Padding(0);
            this.tlpAutoFocusFunction.Name = "tlpAutoFocusFunction";
            this.tlpAutoFocusFunction.RowCount = 10;
            this.tlpAutoFocusFunction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpAutoFocusFunction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpAutoFocusFunction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpAutoFocusFunction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpAutoFocusFunction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpAutoFocusFunction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpAutoFocusFunction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpAutoFocusFunction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpAutoFocusFunction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpAutoFocusFunction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpAutoFocusFunction.Size = new System.Drawing.Size(200, 400);
            this.tlpAutoFocusFunction.TabIndex = 2;
            // 
            // lblMoveTo
            // 
            this.lblMoveTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMoveTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMoveTo.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblMoveTo.ForeColor = System.Drawing.Color.White;
            this.lblMoveTo.Location = new System.Drawing.Point(1, 281);
            this.lblMoveTo.Margin = new System.Windows.Forms.Padding(1);
            this.lblMoveTo.Name = "lblMoveTo";
            this.lblMoveTo.Size = new System.Drawing.Size(198, 38);
            this.lblMoveTo.TabIndex = 11;
            this.lblMoveTo.Text = "Move To Target";
            this.lblMoveTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrentToTargetZ
            // 
            this.lblCurrentToTargetZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCurrentToTargetZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrentToTargetZ.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblCurrentToTargetZ.ForeColor = System.Drawing.Color.White;
            this.lblCurrentToTargetZ.Location = new System.Drawing.Point(1, 121);
            this.lblCurrentToTargetZ.Margin = new System.Windows.Forms.Padding(1);
            this.lblCurrentToTargetZ.Name = "lblCurrentToTargetZ";
            this.lblCurrentToTargetZ.Size = new System.Drawing.Size(198, 38);
            this.lblCurrentToTargetZ.TabIndex = 10;
            this.lblCurrentToTargetZ.Text = "Set Current To Target";
            this.lblCurrentToTargetZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAutoFocusOnOff
            // 
            this.lblAutoFocusOnOff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAutoFocusOnOff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAutoFocusOnOff.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblAutoFocusOnOff.ForeColor = System.Drawing.Color.White;
            this.lblAutoFocusOnOff.Location = new System.Drawing.Point(1, 361);
            this.lblAutoFocusOnOff.Margin = new System.Windows.Forms.Padding(1);
            this.lblAutoFocusOnOff.Name = "lblAutoFocusOnOff";
            this.lblAutoFocusOnOff.Size = new System.Drawing.Size(198, 38);
            this.lblAutoFocusOnOff.TabIndex = 9;
            this.lblAutoFocusOnOff.Text = "Servo";
            this.lblAutoFocusOnOff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSensor
            // 
            this.lblSensor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSensor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSensor.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblSensor.ForeColor = System.Drawing.Color.White;
            this.lblSensor.Location = new System.Drawing.Point(1, 321);
            this.lblSensor.Margin = new System.Windows.Forms.Padding(1);
            this.lblSensor.Name = "lblSensor";
            this.lblSensor.Size = new System.Drawing.Size(198, 38);
            this.lblSensor.TabIndex = 8;
            this.lblSensor.Text = "Sensor";
            this.lblSensor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrentPosition
            // 
            this.lblCurrentPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCurrentPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrentPosition.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblCurrentPosition.ForeColor = System.Drawing.Color.White;
            this.lblCurrentPosition.Location = new System.Drawing.Point(1, 81);
            this.lblCurrentPosition.Margin = new System.Windows.Forms.Padding(1);
            this.lblCurrentPosition.Name = "lblCurrentPosition";
            this.lblCurrentPosition.Size = new System.Drawing.Size(198, 38);
            this.lblCurrentPosition.TabIndex = 6;
            this.lblCurrentPosition.Text = "Current Position";
            this.lblCurrentPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTargetPosition
            // 
            this.lblTargetPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTargetPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTargetPosition.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblTargetPosition.ForeColor = System.Drawing.Color.White;
            this.lblTargetPosition.Location = new System.Drawing.Point(1, 41);
            this.lblTargetPosition.Margin = new System.Windows.Forms.Padding(1);
            this.lblTargetPosition.Name = "lblTargetPosition";
            this.lblTargetPosition.Size = new System.Drawing.Size(198, 38);
            this.lblTargetPosition.TabIndex = 4;
            this.lblTargetPosition.Text = "Target Position";
            this.lblTargetPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAxisName
            // 
            this.lblAxisName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAxisName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAxisName.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblAxisName.ForeColor = System.Drawing.Color.White;
            this.lblAxisName.Location = new System.Drawing.Point(1, 1);
            this.lblAxisName.Margin = new System.Windows.Forms.Padding(1);
            this.lblAxisName.Name = "lblAxisName";
            this.lblAxisName.Size = new System.Drawing.Size(198, 38);
            this.lblAxisName.TabIndex = 3;
            this.lblAxisName.Text = "Axis";
            this.lblAxisName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrentCenterOfGravity
            // 
            this.lblCurrentCenterOfGravity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCurrentCenterOfGravity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrentCenterOfGravity.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblCurrentCenterOfGravity.ForeColor = System.Drawing.Color.White;
            this.lblCurrentCenterOfGravity.Location = new System.Drawing.Point(1, 201);
            this.lblCurrentCenterOfGravity.Margin = new System.Windows.Forms.Padding(1);
            this.lblCurrentCenterOfGravity.Name = "lblCurrentCenterOfGravity";
            this.lblCurrentCenterOfGravity.Size = new System.Drawing.Size(198, 38);
            this.lblCurrentCenterOfGravity.TabIndex = 6;
            this.lblCurrentCenterOfGravity.Text = "Current COG";
            this.lblCurrentCenterOfGravity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTeachedCOG
            // 
            this.lblTeachedCOG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTeachedCOG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTeachedCOG.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblTeachedCOG.ForeColor = System.Drawing.Color.White;
            this.lblTeachedCOG.Location = new System.Drawing.Point(1, 161);
            this.lblTeachedCOG.Margin = new System.Windows.Forms.Padding(1);
            this.lblTeachedCOG.Name = "lblTeachedCOG";
            this.lblTeachedCOG.Size = new System.Drawing.Size(198, 38);
            this.lblTeachedCOG.TabIndex = 6;
            this.lblTeachedCOG.Text = "Teached COG";
            this.lblTeachedCOG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrentToTargetCOG
            // 
            this.lblCurrentToTargetCOG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCurrentToTargetCOG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrentToTargetCOG.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblCurrentToTargetCOG.ForeColor = System.Drawing.Color.White;
            this.lblCurrentToTargetCOG.Location = new System.Drawing.Point(1, 241);
            this.lblCurrentToTargetCOG.Margin = new System.Windows.Forms.Padding(1);
            this.lblCurrentToTargetCOG.Name = "lblCurrentToTargetCOG";
            this.lblCurrentToTargetCOG.Size = new System.Drawing.Size(198, 38);
            this.lblCurrentToTargetCOG.TabIndex = 11;
            this.lblCurrentToTargetCOG.Text = "Set Current To COG";
            this.lblCurrentToTargetCOG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AutoFocusFunctionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.Controls.Add(this.tlpAutoFocusFunction);
            this.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "AutoFocusFunctionControl";
            this.Size = new System.Drawing.Size(200, 400);
            this.tlpAutoFocusFunction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpAutoFocusFunction;
        private System.Windows.Forms.Label lblMoveTo;
        private System.Windows.Forms.Label lblCurrentToTargetZ;
        private System.Windows.Forms.Label lblAutoFocusOnOff;
        private System.Windows.Forms.Label lblSensor;
        private System.Windows.Forms.Label lblCurrentPosition;
        private System.Windows.Forms.Label lblTargetPosition;
        private System.Windows.Forms.Label lblAxisName;
        private System.Windows.Forms.Label lblCurrentCenterOfGravity;
        private System.Windows.Forms.Label lblTeachedCOG;
        private System.Windows.Forms.Label lblCurrentToTargetCOG;
    }
}
