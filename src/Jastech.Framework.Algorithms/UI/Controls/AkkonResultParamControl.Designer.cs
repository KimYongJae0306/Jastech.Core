﻿namespace Jastech.Framework.Algorithms.UI.Controls
{
    partial class AkkonResultParamControl
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
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ckbContainLeadROI = new System.Windows.Forms.CheckBox();
            this.ckbContainNG = new System.Windows.Forms.CheckBox();
            this.ckbContainLeadCount = new System.Windows.Forms.CheckBox();
            this.lblMinArea = new System.Windows.Forms.Label();
            this.lblMaxArea = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblAkkonCount = new System.Windows.Forms.Label();
            this.lblLeadLengthX = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblMinSize = new System.Windows.Forms.Label();
            this.lblMaxSize = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblStrength = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.lblGrouping = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.lblLeadStdDevText = new System.Windows.Forms.Label();
            this.lblLeadLengthY = new System.Windows.Forms.Label();
            this.lblLeadStdDev = new System.Windows.Forms.Label();
            this.ckbContainArea = new System.Windows.Forms.CheckBox();
            this.ckbContainStrength = new System.Windows.Forms.CheckBox();
            this.lblStrengthScaleText = new System.Windows.Forms.Label();
            this.lblStrengthScaleFactor = new System.Windows.Forms.Label();
            this.ckbContainSize = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(25, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 40);
            this.label2.TabIndex = 105;
            this.label2.Text = "SHAPE FILTER";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(21, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 28);
            this.label4.TabIndex = 106;
            this.label4.Text = "Min Area(um)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(21, 234);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(120, 28);
            this.label16.TabIndex = 107;
            this.label16.Text = "Max Area(um)";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(522, 14);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(224, 40);
            this.label5.TabIndex = 108;
            this.label5.Text = "DRAW OPTIONS";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ckbContainLeadROI
            // 
            this.ckbContainLeadROI.AutoSize = true;
            this.ckbContainLeadROI.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.ckbContainLeadROI.ForeColor = System.Drawing.Color.White;
            this.ckbContainLeadROI.Location = new System.Drawing.Point(522, 96);
            this.ckbContainLeadROI.Name = "ckbContainLeadROI";
            this.ckbContainLeadROI.Size = new System.Drawing.Size(147, 23);
            this.ckbContainLeadROI.TabIndex = 109;
            this.ckbContainLeadROI.Text = "Contain Lead ROI";
            this.ckbContainLeadROI.UseVisualStyleBackColor = true;
            this.ckbContainLeadROI.CheckedChanged += new System.EventHandler(this.ckbContainLeadROI_CheckedChanged);
            // 
            // ckbContainNG
            // 
            this.ckbContainNG.AutoSize = true;
            this.ckbContainNG.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.ckbContainNG.ForeColor = System.Drawing.Color.White;
            this.ckbContainNG.Location = new System.Drawing.Point(522, 125);
            this.ckbContainNG.Name = "ckbContainNG";
            this.ckbContainNG.Size = new System.Drawing.Size(107, 23);
            this.ckbContainNG.TabIndex = 110;
            this.ckbContainNG.Text = "Contain NG";
            this.ckbContainNG.UseVisualStyleBackColor = true;
            this.ckbContainNG.CheckedChanged += new System.EventHandler(this.ckbContainNG_CheckedChanged);
            // 
            // ckbContainLeadCount
            // 
            this.ckbContainLeadCount.AutoSize = true;
            this.ckbContainLeadCount.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.ckbContainLeadCount.ForeColor = System.Drawing.Color.White;
            this.ckbContainLeadCount.Location = new System.Drawing.Point(522, 67);
            this.ckbContainLeadCount.Name = "ckbContainLeadCount";
            this.ckbContainLeadCount.Size = new System.Drawing.Size(164, 23);
            this.ckbContainLeadCount.TabIndex = 111;
            this.ckbContainLeadCount.Text = "Contain Lead Count";
            this.ckbContainLeadCount.UseVisualStyleBackColor = true;
            this.ckbContainLeadCount.CheckedChanged += new System.EventHandler(this.ckbContainLeadCount_CheckedChanged);
            // 
            // lblMinArea
            // 
            this.lblMinArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblMinArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMinArea.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblMinArea.ForeColor = System.Drawing.Color.White;
            this.lblMinArea.Location = new System.Drawing.Point(160, 188);
            this.lblMinArea.Margin = new System.Windows.Forms.Padding(0);
            this.lblMinArea.Name = "lblMinArea";
            this.lblMinArea.Size = new System.Drawing.Size(100, 36);
            this.lblMinArea.TabIndex = 112;
            this.lblMinArea.Text = "0";
            this.lblMinArea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMinArea.Click += new System.EventHandler(this.lblMinArea_Click);
            // 
            // lblMaxArea
            // 
            this.lblMaxArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblMaxArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMaxArea.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblMaxArea.ForeColor = System.Drawing.Color.White;
            this.lblMaxArea.Location = new System.Drawing.Point(160, 230);
            this.lblMaxArea.Margin = new System.Windows.Forms.Padding(0);
            this.lblMaxArea.Name = "lblMaxArea";
            this.lblMaxArea.Size = new System.Drawing.Size(100, 36);
            this.lblMaxArea.TabIndex = 113;
            this.lblMaxArea.Text = "0";
            this.lblMaxArea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMaxArea.Click += new System.EventHandler(this.lblMaxArea_Click);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(279, 14);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(224, 40);
            this.label8.TabIndex = 114;
            this.label8.Text = "JUDGEMENT";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(287, 69);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 28);
            this.label13.TabIndex = 115;
            this.label13.Text = "Count";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(287, 108);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 28);
            this.label12.TabIndex = 116;
            this.label12.Text = "LengthX(um)";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAkkonCount
            // 
            this.lblAkkonCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblAkkonCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAkkonCount.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblAkkonCount.ForeColor = System.Drawing.Color.White;
            this.lblAkkonCount.Location = new System.Drawing.Point(403, 65);
            this.lblAkkonCount.Margin = new System.Windows.Forms.Padding(0);
            this.lblAkkonCount.Name = "lblAkkonCount";
            this.lblAkkonCount.Size = new System.Drawing.Size(100, 36);
            this.lblAkkonCount.TabIndex = 117;
            this.lblAkkonCount.Text = "0";
            this.lblAkkonCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAkkonCount.Click += new System.EventHandler(this.lblAkkonCount_Click);
            // 
            // lblLeadLengthX
            // 
            this.lblLeadLengthX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblLeadLengthX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLeadLengthX.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblLeadLengthX.ForeColor = System.Drawing.Color.White;
            this.lblLeadLengthX.Location = new System.Drawing.Point(403, 108);
            this.lblLeadLengthX.Margin = new System.Windows.Forms.Padding(0);
            this.lblLeadLengthX.Name = "lblLeadLengthX";
            this.lblLeadLengthX.Size = new System.Drawing.Size(100, 36);
            this.lblLeadLengthX.TabIndex = 118;
            this.lblLeadLengthX.Text = "0";
            this.lblLeadLengthX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLeadLengthX.Click += new System.EventHandler(this.lblLeadLengthX_Click);
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.Location = new System.Drawing.Point(21, 108);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(120, 28);
            this.label24.TabIndex = 119;
            this.label24.Text = "Min Size(um)";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(21, 151);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(136, 28);
            this.label23.TabIndex = 120;
            this.label23.Text = "Max Size(um)";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMinSize
            // 
            this.lblMinSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblMinSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMinSize.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblMinSize.ForeColor = System.Drawing.Color.White;
            this.lblMinSize.Location = new System.Drawing.Point(160, 104);
            this.lblMinSize.Margin = new System.Windows.Forms.Padding(0);
            this.lblMinSize.Name = "lblMinSize";
            this.lblMinSize.Size = new System.Drawing.Size(100, 36);
            this.lblMinSize.TabIndex = 121;
            this.lblMinSize.Text = "0";
            this.lblMinSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMinSize.Click += new System.EventHandler(this.lblMinSize_Click);
            // 
            // lblMaxSize
            // 
            this.lblMaxSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblMaxSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMaxSize.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblMaxSize.ForeColor = System.Drawing.Color.White;
            this.lblMaxSize.Location = new System.Drawing.Point(160, 147);
            this.lblMaxSize.Margin = new System.Windows.Forms.Padding(0);
            this.lblMaxSize.Name = "lblMaxSize";
            this.lblMaxSize.Size = new System.Drawing.Size(100, 36);
            this.lblMaxSize.TabIndex = 122;
            this.lblMaxSize.Text = "0";
            this.lblMaxSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMaxSize.Click += new System.EventHandler(this.lblMaxSize_Click);
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(21, 276);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(136, 28);
            this.label22.TabIndex = 123;
            this.label22.Text = "Min Strength(%)";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStrength
            // 
            this.lblStrength.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblStrength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStrength.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblStrength.ForeColor = System.Drawing.Color.White;
            this.lblStrength.Location = new System.Drawing.Point(160, 272);
            this.lblStrength.Margin = new System.Windows.Forms.Padding(0);
            this.lblStrength.Name = "lblStrength";
            this.lblStrength.Size = new System.Drawing.Size(100, 36);
            this.lblStrength.TabIndex = 124;
            this.lblStrength.Text = "0";
            this.lblStrength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStrength.Click += new System.EventHandler(this.lblStrength_Click);
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.label26.ForeColor = System.Drawing.Color.White;
            this.label26.Location = new System.Drawing.Point(21, 62);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(113, 28);
            this.label26.TabIndex = 125;
            this.label26.Text = "Grouping(px)";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGrouping
            // 
            this.lblGrouping.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblGrouping.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGrouping.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblGrouping.ForeColor = System.Drawing.Color.White;
            this.lblGrouping.Location = new System.Drawing.Point(160, 62);
            this.lblGrouping.Margin = new System.Windows.Forms.Padding(0);
            this.lblGrouping.Name = "lblGrouping";
            this.lblGrouping.Size = new System.Drawing.Size(100, 36);
            this.lblGrouping.TabIndex = 126;
            this.lblGrouping.Text = "0";
            this.lblGrouping.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblGrouping.Click += new System.EventHandler(this.lblGrouping_Click);
            // 
            // label30
            // 
            this.label30.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.label30.ForeColor = System.Drawing.Color.White;
            this.label30.Location = new System.Drawing.Point(287, 157);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(113, 28);
            this.label30.TabIndex = 127;
            this.label30.Text = "LengthY(um)";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLeadStdDevText
            // 
            this.lblLeadStdDevText.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.lblLeadStdDevText.ForeColor = System.Drawing.Color.White;
            this.lblLeadStdDevText.Location = new System.Drawing.Point(287, 196);
            this.lblLeadStdDevText.Name = "lblLeadStdDevText";
            this.lblLeadStdDevText.Size = new System.Drawing.Size(78, 28);
            this.lblLeadStdDevText.TabIndex = 128;
            this.lblLeadStdDevText.Text = "StdDev";
            this.lblLeadStdDevText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLeadLengthY
            // 
            this.lblLeadLengthY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblLeadLengthY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLeadLengthY.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblLeadLengthY.ForeColor = System.Drawing.Color.White;
            this.lblLeadLengthY.Location = new System.Drawing.Point(403, 153);
            this.lblLeadLengthY.Margin = new System.Windows.Forms.Padding(0);
            this.lblLeadLengthY.Name = "lblLeadLengthY";
            this.lblLeadLengthY.Size = new System.Drawing.Size(100, 36);
            this.lblLeadLengthY.TabIndex = 129;
            this.lblLeadLengthY.Text = "0";
            this.lblLeadLengthY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLeadLengthY.Click += new System.EventHandler(this.lblLeadLengthY_Click);
            // 
            // lblLeadStdDev
            // 
            this.lblLeadStdDev.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblLeadStdDev.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLeadStdDev.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblLeadStdDev.ForeColor = System.Drawing.Color.White;
            this.lblLeadStdDev.Location = new System.Drawing.Point(403, 196);
            this.lblLeadStdDev.Margin = new System.Windows.Forms.Padding(0);
            this.lblLeadStdDev.Name = "lblLeadStdDev";
            this.lblLeadStdDev.Size = new System.Drawing.Size(100, 36);
            this.lblLeadStdDev.TabIndex = 130;
            this.lblLeadStdDev.Text = "0";
            this.lblLeadStdDev.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLeadStdDev.Click += new System.EventHandler(this.lblLeadStdDev_Click);
            // 
            // ckbContainArea
            // 
            this.ckbContainArea.AutoSize = true;
            this.ckbContainArea.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.ckbContainArea.ForeColor = System.Drawing.Color.White;
            this.ckbContainArea.Location = new System.Drawing.Point(522, 182);
            this.ckbContainArea.Name = "ckbContainArea";
            this.ckbContainArea.Size = new System.Drawing.Size(161, 23);
            this.ckbContainArea.TabIndex = 131;
            this.ckbContainArea.Text = "Contain Area Value";
            this.ckbContainArea.UseVisualStyleBackColor = true;
            this.ckbContainArea.CheckedChanged += new System.EventHandler(this.ckbContainArea_CheckedChanged);
            // 
            // ckbContainStrength
            // 
            this.ckbContainStrength.AutoSize = true;
            this.ckbContainStrength.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.ckbContainStrength.ForeColor = System.Drawing.Color.White;
            this.ckbContainStrength.Location = new System.Drawing.Point(522, 211);
            this.ckbContainStrength.Name = "ckbContainStrength";
            this.ckbContainStrength.Size = new System.Drawing.Size(187, 23);
            this.ckbContainStrength.TabIndex = 132;
            this.ckbContainStrength.Text = "Contain Strength Value";
            this.ckbContainStrength.UseVisualStyleBackColor = true;
            this.ckbContainStrength.CheckedChanged += new System.EventHandler(this.ckbContainStrength_CheckedChanged);
            // 
            // lblStrengthScaleText
            // 
            this.lblStrengthScaleText.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.lblStrengthScaleText.ForeColor = System.Drawing.Color.White;
            this.lblStrengthScaleText.Location = new System.Drawing.Point(21, 316);
            this.lblStrengthScaleText.Name = "lblStrengthScaleText";
            this.lblStrengthScaleText.Size = new System.Drawing.Size(120, 28);
            this.lblStrengthScaleText.TabIndex = 133;
            this.lblStrengthScaleText.Text = "Strength Scale";
            this.lblStrengthScaleText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStrengthScaleFactor
            // 
            this.lblStrengthScaleFactor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblStrengthScaleFactor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStrengthScaleFactor.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblStrengthScaleFactor.ForeColor = System.Drawing.Color.White;
            this.lblStrengthScaleFactor.Location = new System.Drawing.Point(160, 312);
            this.lblStrengthScaleFactor.Margin = new System.Windows.Forms.Padding(0);
            this.lblStrengthScaleFactor.Name = "lblStrengthScaleFactor";
            this.lblStrengthScaleFactor.Size = new System.Drawing.Size(100, 36);
            this.lblStrengthScaleFactor.TabIndex = 134;
            this.lblStrengthScaleFactor.Text = "0";
            this.lblStrengthScaleFactor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStrengthScaleFactor.Click += new System.EventHandler(this.lblStrengthScaleFactor_Click);
            // 
            // ckbContainSize
            // 
            this.ckbContainSize.AutoSize = true;
            this.ckbContainSize.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.ckbContainSize.ForeColor = System.Drawing.Color.White;
            this.ckbContainSize.Location = new System.Drawing.Point(522, 153);
            this.ckbContainSize.Name = "ckbContainSize";
            this.ckbContainSize.Size = new System.Drawing.Size(156, 23);
            this.ckbContainSize.TabIndex = 135;
            this.ckbContainSize.Text = "Contain Size Value";
            this.ckbContainSize.UseVisualStyleBackColor = true;
            this.ckbContainSize.CheckedChanged += new System.EventHandler(this.ckbContainSize_CheckedChanged);
            // 
            // AkkonResultParamControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.Controls.Add(this.ckbContainSize);
            this.Controls.Add(this.lblStrengthScaleFactor);
            this.Controls.Add(this.lblStrengthScaleText);
            this.Controls.Add(this.ckbContainStrength);
            this.Controls.Add(this.ckbContainArea);
            this.Controls.Add(this.lblLeadStdDev);
            this.Controls.Add(this.lblLeadLengthY);
            this.Controls.Add(this.lblLeadStdDevText);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.lblGrouping);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.lblStrength);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.lblMaxSize);
            this.Controls.Add(this.lblMinSize);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.lblLeadLengthX);
            this.Controls.Add(this.lblAkkonCount);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblMaxArea);
            this.Controls.Add(this.lblMinArea);
            this.Controls.Add(this.ckbContainLeadCount);
            this.Controls.Add(this.ckbContainNG);
            this.Controls.Add(this.ckbContainLeadROI);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Name = "AkkonResultParamControl";
            this.Size = new System.Drawing.Size(781, 373);
            this.Load += new System.EventHandler(this.AkkonResultParamControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox ckbContainLeadROI;
        private System.Windows.Forms.CheckBox ckbContainNG;
        private System.Windows.Forms.CheckBox ckbContainLeadCount;
        private System.Windows.Forms.Label lblMinArea;
        private System.Windows.Forms.Label lblMaxArea;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblAkkonCount;
        private System.Windows.Forms.Label lblLeadLengthX;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblMinSize;
        private System.Windows.Forms.Label lblMaxSize;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblStrength;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label lblGrouping;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label lblLeadStdDevText;
        private System.Windows.Forms.Label lblLeadLengthY;
        private System.Windows.Forms.Label lblLeadStdDev;
        private System.Windows.Forms.CheckBox ckbContainArea;
        private System.Windows.Forms.CheckBox ckbContainStrength;
        private System.Windows.Forms.Label lblStrengthScaleText;
        private System.Windows.Forms.Label lblStrengthScaleFactor;
        private System.Windows.Forms.CheckBox ckbContainSize;
    }
}
