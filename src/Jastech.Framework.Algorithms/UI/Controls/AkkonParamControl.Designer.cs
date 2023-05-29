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
            this.label10 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.cbxFilterType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cbxThresholdMode = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbxFilterDirection = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ckbContainLeadCount = new System.Windows.Forms.CheckBox();
            this.ckbContainNG = new System.Windows.Forms.CheckBox();
            this.ckbContainLeadROI = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblScaleFactor = new System.Windows.Forms.Label();
            this.lblLogWidth = new System.Windows.Forms.Label();
            this.lblResizeRatio = new System.Windows.Forms.Label();
            this.lblThresholdWeight = new System.Windows.Forms.Label();
            this.lblGusWidth = new System.Windows.Forms.Label();
            this.lblSigma = new System.Windows.Forms.Label();
            this.lblMaxSize = new System.Windows.Forms.Label();
            this.lblMinSize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(15, 17);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(453, 40);
            this.label10.TabIndex = 17;
            this.label10.Text = "FILTERS";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(234, 147);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(100, 28);
            this.label21.TabIndex = 57;
            this.label21.Text = "LogWidth";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(234, 104);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(100, 28);
            this.label20.TabIndex = 55;
            this.label20.Text = "Scale Factor";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(21, 147);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(77, 28);
            this.label19.TabIndex = 53;
            this.label19.Text = "GusWidth";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(21, 104);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(77, 28);
            this.label18.TabIndex = 51;
            this.label18.Text = "Sigma";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxFilterType
            // 
            this.cbxFilterType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFilterType.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.cbxFilterType.FormattingEnabled = true;
            this.cbxFilterType.Location = new System.Drawing.Point(121, 65);
            this.cbxFilterType.Margin = new System.Windows.Forms.Padding(0);
            this.cbxFilterType.Name = "cbxFilterType";
            this.cbxFilterType.Size = new System.Drawing.Size(100, 28);
            this.cbxFilterType.TabIndex = 49;
            this.cbxFilterType.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ComboBox_DrawItem);
            this.cbxFilterType.SelectedIndexChanged += new System.EventHandler(this.cbxFilterType_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(21, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 28);
            this.label6.TabIndex = 48;
            this.label6.Text = "FilterType";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 187);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(453, 40);
            this.label1.TabIndex = 58;
            this.label1.Text = "IMAGE PROCESSING";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(234, 272);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(136, 28);
            this.label15.TabIndex = 64;
            this.label15.Text = "Threshold Weight";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxThresholdMode
            // 
            this.cbxThresholdMode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxThresholdMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxThresholdMode.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.cbxThresholdMode.FormattingEnabled = true;
            this.cbxThresholdMode.Location = new System.Drawing.Point(368, 231);
            this.cbxThresholdMode.Margin = new System.Windows.Forms.Padding(0);
            this.cbxThresholdMode.Name = "cbxThresholdMode";
            this.cbxThresholdMode.Size = new System.Drawing.Size(100, 28);
            this.cbxThresholdMode.TabIndex = 63;
            this.cbxThresholdMode.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ComboBox_DrawItem);
            this.cbxThresholdMode.SelectedIndexChanged += new System.EventHandler(this.cbxThresholdMode_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(234, 230);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(122, 28);
            this.label14.TabIndex = 62;
            this.label14.Text = "Threshold Mode";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxFilterDirection
            // 
            this.cbxFilterDirection.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxFilterDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFilterDirection.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.cbxFilterDirection.FormattingEnabled = true;
            this.cbxFilterDirection.Location = new System.Drawing.Point(121, 272);
            this.cbxFilterDirection.Margin = new System.Windows.Forms.Padding(0);
            this.cbxFilterDirection.Name = "cbxFilterDirection";
            this.cbxFilterDirection.Size = new System.Drawing.Size(100, 28);
            this.cbxFilterDirection.TabIndex = 61;
            this.cbxFilterDirection.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ComboBox_DrawItem);
            this.cbxFilterDirection.SelectedIndexChanged += new System.EventHandler(this.cbxFilterDirection_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(21, 272);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 28);
            this.label3.TabIndex = 60;
            this.label3.Text = "Direction";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(482, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 40);
            this.label2.TabIndex = 65;
            this.label2.Text = "JUDGEMENT";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(490, 104);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(78, 28);
            this.label16.TabIndex = 69;
            this.label16.Text = "Max Size";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(490, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 28);
            this.label4.TabIndex = 67;
            this.label4.Text = "Min Size";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(482, 187);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(224, 40);
            this.label5.TabIndex = 70;
            this.label5.Text = "DRAW OPTIONS";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ckbContainLeadCount
            // 
            this.ckbContainLeadCount.AutoSize = true;
            this.ckbContainLeadCount.Checked = true;
            this.ckbContainLeadCount.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbContainLeadCount.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.ckbContainLeadCount.ForeColor = System.Drawing.Color.White;
            this.ckbContainLeadCount.Location = new System.Drawing.Point(482, 240);
            this.ckbContainLeadCount.Name = "ckbContainLeadCount";
            this.ckbContainLeadCount.Size = new System.Drawing.Size(164, 23);
            this.ckbContainLeadCount.TabIndex = 73;
            this.ckbContainLeadCount.Text = "Contain Lead Count";
            this.ckbContainLeadCount.UseVisualStyleBackColor = true;
            this.ckbContainLeadCount.CheckedChanged += new System.EventHandler(this.ckbContainLeadCount_CheckedChanged);
            // 
            // ckbContainNG
            // 
            this.ckbContainNG.AutoSize = true;
            this.ckbContainNG.Checked = true;
            this.ckbContainNG.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbContainNG.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.ckbContainNG.ForeColor = System.Drawing.Color.White;
            this.ckbContainNG.Location = new System.Drawing.Point(482, 298);
            this.ckbContainNG.Name = "ckbContainNG";
            this.ckbContainNG.Size = new System.Drawing.Size(107, 23);
            this.ckbContainNG.TabIndex = 72;
            this.ckbContainNG.Text = "Contain NG";
            this.ckbContainNG.UseVisualStyleBackColor = true;
            this.ckbContainNG.CheckedChanged += new System.EventHandler(this.ckbContainNG_CheckedChanged);
            // 
            // ckbContainLeadROI
            // 
            this.ckbContainLeadROI.AutoSize = true;
            this.ckbContainLeadROI.Checked = true;
            this.ckbContainLeadROI.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbContainLeadROI.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.ckbContainLeadROI.ForeColor = System.Drawing.Color.White;
            this.ckbContainLeadROI.Location = new System.Drawing.Point(482, 269);
            this.ckbContainLeadROI.Name = "ckbContainLeadROI";
            this.ckbContainLeadROI.Size = new System.Drawing.Size(147, 23);
            this.ckbContainLeadROI.TabIndex = 71;
            this.ckbContainLeadROI.Text = "Contain Lead ROI";
            this.ckbContainLeadROI.UseVisualStyleBackColor = true;
            this.ckbContainLeadROI.CheckedChanged += new System.EventHandler(this.ckbContainLeadROI_CheckedChanged);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(21, 230);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 28);
            this.label7.TabIndex = 75;
            this.label7.Text = "Resize Ratio";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblScaleFactor
            // 
            this.lblScaleFactor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblScaleFactor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblScaleFactor.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblScaleFactor.ForeColor = System.Drawing.Color.White;
            this.lblScaleFactor.Location = new System.Drawing.Point(368, 100);
            this.lblScaleFactor.Margin = new System.Windows.Forms.Padding(0);
            this.lblScaleFactor.Name = "lblScaleFactor";
            this.lblScaleFactor.Size = new System.Drawing.Size(100, 36);
            this.lblScaleFactor.TabIndex = 78;
            this.lblScaleFactor.Text = "0";
            this.lblScaleFactor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblScaleFactor.Click += new System.EventHandler(this.lblScaleFactor_Click);
            // 
            // lblLogWidth
            // 
            this.lblLogWidth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblLogWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLogWidth.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblLogWidth.ForeColor = System.Drawing.Color.White;
            this.lblLogWidth.Location = new System.Drawing.Point(368, 143);
            this.lblLogWidth.Margin = new System.Windows.Forms.Padding(0);
            this.lblLogWidth.Name = "lblLogWidth";
            this.lblLogWidth.Size = new System.Drawing.Size(100, 36);
            this.lblLogWidth.TabIndex = 79;
            this.lblLogWidth.Text = "0";
            this.lblLogWidth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLogWidth.Click += new System.EventHandler(this.lblLogWidth_Click);
            // 
            // lblResizeRatio
            // 
            this.lblResizeRatio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblResizeRatio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblResizeRatio.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblResizeRatio.ForeColor = System.Drawing.Color.White;
            this.lblResizeRatio.Location = new System.Drawing.Point(121, 230);
            this.lblResizeRatio.Margin = new System.Windows.Forms.Padding(0);
            this.lblResizeRatio.Name = "lblResizeRatio";
            this.lblResizeRatio.Size = new System.Drawing.Size(100, 36);
            this.lblResizeRatio.TabIndex = 80;
            this.lblResizeRatio.Text = "0";
            this.lblResizeRatio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblResizeRatio.Click += new System.EventHandler(this.lblResizeRatio_Click);
            // 
            // lblThresholdWeight
            // 
            this.lblThresholdWeight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblThresholdWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblThresholdWeight.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblThresholdWeight.ForeColor = System.Drawing.Color.White;
            this.lblThresholdWeight.Location = new System.Drawing.Point(368, 268);
            this.lblThresholdWeight.Margin = new System.Windows.Forms.Padding(0);
            this.lblThresholdWeight.Name = "lblThresholdWeight";
            this.lblThresholdWeight.Size = new System.Drawing.Size(100, 36);
            this.lblThresholdWeight.TabIndex = 81;
            this.lblThresholdWeight.Text = "0";
            this.lblThresholdWeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblThresholdWeight.Click += new System.EventHandler(this.lblThresholdWeight_Click);
            // 
            // lblGusWidth
            // 
            this.lblGusWidth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblGusWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGusWidth.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblGusWidth.ForeColor = System.Drawing.Color.White;
            this.lblGusWidth.Location = new System.Drawing.Point(121, 143);
            this.lblGusWidth.Margin = new System.Windows.Forms.Padding(0);
            this.lblGusWidth.Name = "lblGusWidth";
            this.lblGusWidth.Size = new System.Drawing.Size(100, 36);
            this.lblGusWidth.TabIndex = 83;
            this.lblGusWidth.Text = "0";
            this.lblGusWidth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblGusWidth.Click += new System.EventHandler(this.lblGusWidth_Click);
            // 
            // lblSigma
            // 
            this.lblSigma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblSigma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSigma.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblSigma.ForeColor = System.Drawing.Color.White;
            this.lblSigma.Location = new System.Drawing.Point(121, 100);
            this.lblSigma.Margin = new System.Windows.Forms.Padding(0);
            this.lblSigma.Name = "lblSigma";
            this.lblSigma.Size = new System.Drawing.Size(100, 36);
            this.lblSigma.TabIndex = 82;
            this.lblSigma.Text = "0";
            this.lblSigma.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSigma.Click += new System.EventHandler(this.lblSigma_Click);
            // 
            // lblMaxSize
            // 
            this.lblMaxSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblMaxSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMaxSize.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblMaxSize.ForeColor = System.Drawing.Color.White;
            this.lblMaxSize.Location = new System.Drawing.Point(606, 104);
            this.lblMaxSize.Margin = new System.Windows.Forms.Padding(0);
            this.lblMaxSize.Name = "lblMaxSize";
            this.lblMaxSize.Size = new System.Drawing.Size(100, 36);
            this.lblMaxSize.TabIndex = 85;
            this.lblMaxSize.Text = "0";
            this.lblMaxSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMaxSize.Click += new System.EventHandler(this.lblMaxSize_Click);
            // 
            // lblMinSize
            // 
            this.lblMinSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblMinSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMinSize.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblMinSize.ForeColor = System.Drawing.Color.White;
            this.lblMinSize.Location = new System.Drawing.Point(606, 61);
            this.lblMinSize.Margin = new System.Windows.Forms.Padding(0);
            this.lblMinSize.Name = "lblMinSize";
            this.lblMinSize.Size = new System.Drawing.Size(100, 36);
            this.lblMinSize.TabIndex = 84;
            this.lblMinSize.Text = "0";
            this.lblMinSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMinSize.Click += new System.EventHandler(this.lblMinSize_Click);
            // 
            // AkkonParamControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.Controls.Add(this.lblMaxSize);
            this.Controls.Add(this.lblMinSize);
            this.Controls.Add(this.lblGusWidth);
            this.Controls.Add(this.lblSigma);
            this.Controls.Add(this.lblThresholdWeight);
            this.Controls.Add(this.lblResizeRatio);
            this.Controls.Add(this.lblLogWidth);
            this.Controls.Add(this.lblScaleFactor);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ckbContainLeadCount);
            this.Controls.Add(this.ckbContainNG);
            this.Controls.Add(this.ckbContainLeadROI);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cbxThresholdMode);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cbxFilterDirection);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.cbxFilterType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label10);
            this.Name = "AkkonParamControl";
            this.Size = new System.Drawing.Size(722, 337);
            this.Load += new System.EventHandler(this.AkkonParamControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbxFilterType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbxThresholdMode;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbxFilterDirection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox ckbContainLeadCount;
        private System.Windows.Forms.CheckBox ckbContainNG;
        private System.Windows.Forms.CheckBox ckbContainLeadROI;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblScaleFactor;
        private System.Windows.Forms.Label lblLogWidth;
        private System.Windows.Forms.Label lblResizeRatio;
        private System.Windows.Forms.Label lblThresholdWeight;
        private System.Windows.Forms.Label lblGusWidth;
        private System.Windows.Forms.Label lblSigma;
        private System.Windows.Forms.Label lblMaxSize;
        private System.Windows.Forms.Label lblMinSize;
    }
}
