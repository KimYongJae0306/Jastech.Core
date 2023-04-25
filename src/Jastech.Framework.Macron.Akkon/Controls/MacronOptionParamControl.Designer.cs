namespace Jastech.Framework.Macron.Akkon.Controls
{
    partial class MacronOptionParamControl
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
            this.lblDimpleNGCount = new System.Windows.Forms.Label();
            this.lblDimpleNGCountValue = new System.Windows.Forms.Label();
            this.lblDimpleThreshold = new System.Windows.Forms.Label();
            this.lblDimpleThresholdValue = new System.Windows.Forms.Label();
            this.chkUseDimple = new System.Windows.Forms.CheckBox();
            this.lblAlarmNGCount = new System.Windows.Forms.Label();
            this.lblAlarmCapacity = new System.Windows.Forms.Label();
            this.lblAlarmNGCountValue = new System.Windows.Forms.Label();
            this.lblAlarmCapacityValue = new System.Windows.Forms.Label();
            this.chkUseAlarm = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tlpEngineerParameter = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel8.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tlpEngineerParameter.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDimpleNGCount
            // 
            this.lblDimpleNGCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblDimpleNGCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDimpleNGCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDimpleNGCount.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblDimpleNGCount.ForeColor = System.Drawing.Color.White;
            this.lblDimpleNGCount.Location = new System.Drawing.Point(0, 0);
            this.lblDimpleNGCount.Margin = new System.Windows.Forms.Padding(0);
            this.lblDimpleNGCount.Name = "lblDimpleNGCount";
            this.lblDimpleNGCount.Size = new System.Drawing.Size(97, 54);
            this.lblDimpleNGCount.TabIndex = 18;
            this.lblDimpleNGCount.Text = "NG COUNT";
            this.lblDimpleNGCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDimpleNGCountValue
            // 
            this.lblDimpleNGCountValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblDimpleNGCountValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDimpleNGCountValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDimpleNGCountValue.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblDimpleNGCountValue.ForeColor = System.Drawing.Color.White;
            this.lblDimpleNGCountValue.Location = new System.Drawing.Point(97, 0);
            this.lblDimpleNGCountValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblDimpleNGCountValue.Name = "lblDimpleNGCountValue";
            this.lblDimpleNGCountValue.Size = new System.Drawing.Size(97, 54);
            this.lblDimpleNGCountValue.TabIndex = 27;
            this.lblDimpleNGCountValue.Text = "0";
            this.lblDimpleNGCountValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDimpleNGCountValue.Click += new System.EventHandler(this.lblDimpleNGCountValue_Click);
            // 
            // lblDimpleThreshold
            // 
            this.lblDimpleThreshold.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblDimpleThreshold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDimpleThreshold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDimpleThreshold.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblDimpleThreshold.ForeColor = System.Drawing.Color.White;
            this.lblDimpleThreshold.Location = new System.Drawing.Point(0, 54);
            this.lblDimpleThreshold.Margin = new System.Windows.Forms.Padding(0);
            this.lblDimpleThreshold.Name = "lblDimpleThreshold";
            this.lblDimpleThreshold.Size = new System.Drawing.Size(97, 54);
            this.lblDimpleThreshold.TabIndex = 18;
            this.lblDimpleThreshold.Text = "THRESHOLD";
            this.lblDimpleThreshold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDimpleThresholdValue
            // 
            this.lblDimpleThresholdValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblDimpleThresholdValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDimpleThresholdValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDimpleThresholdValue.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblDimpleThresholdValue.ForeColor = System.Drawing.Color.White;
            this.lblDimpleThresholdValue.Location = new System.Drawing.Point(97, 54);
            this.lblDimpleThresholdValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblDimpleThresholdValue.Name = "lblDimpleThresholdValue";
            this.lblDimpleThresholdValue.Size = new System.Drawing.Size(97, 54);
            this.lblDimpleThresholdValue.TabIndex = 27;
            this.lblDimpleThresholdValue.Text = "0";
            this.lblDimpleThresholdValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDimpleThresholdValue.Click += new System.EventHandler(this.lblDimpleThresholdValue_Click);
            // 
            // chkUseDimple
            // 
            this.chkUseDimple.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkUseDimple.AutoSize = true;
            this.chkUseDimple.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.chkUseDimple.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkUseDimple.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.chkUseDimple.ForeColor = System.Drawing.Color.White;
            this.chkUseDimple.Location = new System.Drawing.Point(97, 108);
            this.chkUseDimple.Margin = new System.Windows.Forms.Padding(0);
            this.chkUseDimple.Name = "chkUseDimple";
            this.chkUseDimple.Size = new System.Drawing.Size(97, 54);
            this.chkUseDimple.TabIndex = 47;
            this.chkUseDimple.Text = "On";
            this.chkUseDimple.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkUseDimple.UseVisualStyleBackColor = false;
            this.chkUseDimple.CheckedChanged += new System.EventHandler(this.chkUseDimple_CheckedChanged);
            // 
            // lblAlarmNGCount
            // 
            this.lblAlarmNGCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblAlarmNGCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAlarmNGCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAlarmNGCount.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblAlarmNGCount.ForeColor = System.Drawing.Color.White;
            this.lblAlarmNGCount.Location = new System.Drawing.Point(0, 54);
            this.lblAlarmNGCount.Margin = new System.Windows.Forms.Padding(0);
            this.lblAlarmNGCount.Name = "lblAlarmNGCount";
            this.lblAlarmNGCount.Size = new System.Drawing.Size(97, 54);
            this.lblAlarmNGCount.TabIndex = 18;
            this.lblAlarmNGCount.Text = "NG COUNT";
            this.lblAlarmNGCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAlarmCapacity
            // 
            this.lblAlarmCapacity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblAlarmCapacity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAlarmCapacity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAlarmCapacity.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblAlarmCapacity.ForeColor = System.Drawing.Color.White;
            this.lblAlarmCapacity.Location = new System.Drawing.Point(0, 0);
            this.lblAlarmCapacity.Margin = new System.Windows.Forms.Padding(0);
            this.lblAlarmCapacity.Name = "lblAlarmCapacity";
            this.lblAlarmCapacity.Size = new System.Drawing.Size(97, 54);
            this.lblAlarmCapacity.TabIndex = 18;
            this.lblAlarmCapacity.Text = "NG CAPACITY";
            this.lblAlarmCapacity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAlarmNGCountValue
            // 
            this.lblAlarmNGCountValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblAlarmNGCountValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAlarmNGCountValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAlarmNGCountValue.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblAlarmNGCountValue.ForeColor = System.Drawing.Color.White;
            this.lblAlarmNGCountValue.Location = new System.Drawing.Point(97, 54);
            this.lblAlarmNGCountValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblAlarmNGCountValue.Name = "lblAlarmNGCountValue";
            this.lblAlarmNGCountValue.Size = new System.Drawing.Size(97, 54);
            this.lblAlarmNGCountValue.TabIndex = 27;
            this.lblAlarmNGCountValue.Text = "0";
            this.lblAlarmNGCountValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAlarmNGCountValue.Click += new System.EventHandler(this.lblAlarmNGCountValue_Click);
            // 
            // lblAlarmCapacityValue
            // 
            this.lblAlarmCapacityValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblAlarmCapacityValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAlarmCapacityValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAlarmCapacityValue.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblAlarmCapacityValue.ForeColor = System.Drawing.Color.White;
            this.lblAlarmCapacityValue.Location = new System.Drawing.Point(97, 0);
            this.lblAlarmCapacityValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblAlarmCapacityValue.Name = "lblAlarmCapacityValue";
            this.lblAlarmCapacityValue.Size = new System.Drawing.Size(97, 54);
            this.lblAlarmCapacityValue.TabIndex = 27;
            this.lblAlarmCapacityValue.Text = "0";
            this.lblAlarmCapacityValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAlarmCapacityValue.Click += new System.EventHandler(this.lblAlarmCapacityValue_Click);
            // 
            // chkUseAlarm
            // 
            this.chkUseAlarm.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkUseAlarm.AutoSize = true;
            this.chkUseAlarm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.chkUseAlarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkUseAlarm.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.chkUseAlarm.ForeColor = System.Drawing.Color.White;
            this.chkUseAlarm.Location = new System.Drawing.Point(97, 108);
            this.chkUseAlarm.Margin = new System.Windows.Forms.Padding(0);
            this.chkUseAlarm.Name = "chkUseAlarm";
            this.chkUseAlarm.Size = new System.Drawing.Size(97, 54);
            this.chkUseAlarm.TabIndex = 47;
            this.chkUseAlarm.Text = "On";
            this.chkUseAlarm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkUseAlarm.UseVisualStyleBackColor = false;
            this.chkUseAlarm.CheckedChanged += new System.EventHandler(this.chkUseAlarm_CheckedChanged);
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 4;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel8.Controls.Add(this.panel5, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.panel1, 3, 0);
            this.tableLayoutPanel8.Controls.Add(this.panel3, 2, 0);
            this.tableLayoutPanel8.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(776, 365);
            this.tableLayoutPanel8.TabIndex = 32;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tlpEngineerParameter);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(194, 365);
            this.panel5.TabIndex = 4;
            // 
            // tlpEngineerParameter
            // 
            this.tlpEngineerParameter.ColumnCount = 1;
            this.tlpEngineerParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpEngineerParameter.Controls.Add(this.label1, 0, 0);
            this.tlpEngineerParameter.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tlpEngineerParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpEngineerParameter.Location = new System.Drawing.Point(0, 0);
            this.tlpEngineerParameter.Margin = new System.Windows.Forms.Padding(0);
            this.tlpEngineerParameter.Name = "tlpEngineerParameter";
            this.tlpEngineerParameter.RowCount = 2;
            this.tlpEngineerParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpEngineerParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpEngineerParameter.Size = new System.Drawing.Size(194, 365);
            this.tlpEngineerParameter.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 40);
            this.label1.TabIndex = 15;
            this.label1.Text = "DIMPLE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblDimpleNGCount, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkUseDimple, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblDimpleThresholdValue, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDimpleThreshold, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDimpleNGCountValue, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 40);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(194, 325);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(582, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(194, 365);
            this.panel1.TabIndex = 28;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(194, 365);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tableLayoutPanel6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(388, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(194, 365);
            this.panel3.TabIndex = 30;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(194, 365);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(194, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(194, 365);
            this.panel2.TabIndex = 29;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(194, 365);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.lblAlarmCapacity, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.chkUseAlarm, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.lblAlarmNGCount, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.lblAlarmNGCountValue, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.lblAlarmCapacityValue, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 40);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 6;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(194, 325);
            this.tableLayoutPanel5.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 40);
            this.label2.TabIndex = 16;
            this.label2.Text = "ALARM";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 108);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 54);
            this.label3.TabIndex = 48;
            this.label3.Text = "Enable";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 108);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 54);
            this.label4.TabIndex = 49;
            this.label4.Text = "Enable";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MacronOptionParamControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.Controls.Add(this.tableLayoutPanel8);
            this.Name = "MacronOptionParamControl";
            this.Size = new System.Drawing.Size(776, 365);
            this.Load += new System.EventHandler(this.MacronOptionParamControl_Load);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.tlpEngineerParameter.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblDimpleNGCount;
        private System.Windows.Forms.Label lblDimpleNGCountValue;
        private System.Windows.Forms.Label lblDimpleThreshold;
        private System.Windows.Forms.Label lblDimpleThresholdValue;
        private System.Windows.Forms.CheckBox chkUseDimple;
        private System.Windows.Forms.Label lblAlarmNGCount;
        private System.Windows.Forms.Label lblAlarmCapacity;
        private System.Windows.Forms.Label lblAlarmNGCountValue;
        private System.Windows.Forms.Label lblAlarmCapacityValue;
        private System.Windows.Forms.CheckBox chkUseAlarm;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TableLayoutPanel tlpEngineerParameter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
