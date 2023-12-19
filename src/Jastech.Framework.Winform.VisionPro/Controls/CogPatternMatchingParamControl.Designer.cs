namespace Jastech.Framework.Winform.VisionPro.Controls
{
    partial class CogPatternMatchingParamControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CogPatternMatchingParamControl));
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMasking = new System.Windows.Forms.Label();
            this.cogPatternDisplay = new Cognex.VisionPro.Display.CogDisplay();
            this.lblTrain = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblClear = new System.Windows.Forms.Label();
            this.lblTest = new System.Windows.Forms.Label();
            this.nupdnMaxAngle = new System.Windows.Forms.NumericUpDown();
            this.nupdnMatchScore = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblEditMark = new System.Windows.Forms.Label();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogPatternDisplay)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupdnMaxAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupdnMatchScore)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(532, 386);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.lblMasking, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.cogPatternDisplay, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblTrain, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(294, 380);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // lblMasking
            // 
            this.lblMasking.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMasking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMasking.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMasking.ForeColor = System.Drawing.Color.White;
            this.lblMasking.Location = new System.Drawing.Point(3, 290);
            this.lblMasking.Name = "lblMasking";
            this.lblMasking.Size = new System.Drawing.Size(288, 40);
            this.lblMasking.TabIndex = 21;
            this.lblMasking.Text = "Masking";
            this.lblMasking.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMasking.Click += new System.EventHandler(this.lblMasking_Click);
            // 
            // cogPatternDisplay
            // 
            this.cogPatternDisplay.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogPatternDisplay.ColorMapLowerRoiLimit = 0D;
            this.cogPatternDisplay.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogPatternDisplay.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogPatternDisplay.ColorMapUpperRoiLimit = 1D;
            this.cogPatternDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogPatternDisplay.DoubleTapZoomCycleLength = 2;
            this.cogPatternDisplay.DoubleTapZoomSensitivity = 2.5D;
            this.cogPatternDisplay.Location = new System.Drawing.Point(3, 2);
            this.cogPatternDisplay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cogPatternDisplay.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogPatternDisplay.MouseWheelSensitivity = 1D;
            this.cogPatternDisplay.Name = "cogPatternDisplay";
            this.cogPatternDisplay.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogPatternDisplay.OcxState")));
            this.cogPatternDisplay.Size = new System.Drawing.Size(288, 246);
            this.cogPatternDisplay.TabIndex = 1;
            // 
            // lblTrain
            // 
            this.lblTrain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTrain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrain.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTrain.ForeColor = System.Drawing.Color.White;
            this.lblTrain.Location = new System.Drawing.Point(3, 250);
            this.lblTrain.Name = "lblTrain";
            this.lblTrain.Size = new System.Drawing.Size(288, 40);
            this.lblTrain.TabIndex = 20;
            this.lblTrain.Text = "Train";
            this.lblTrain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTrain.Click += new System.EventHandler(this.lblAddPattern_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblEditMark);
            this.panel2.Controls.Add(this.lblClear);
            this.panel2.Controls.Add(this.lblTest);
            this.panel2.Controls.Add(this.nupdnMaxAngle);
            this.panel2.Controls.Add(this.nupdnMatchScore);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(303, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(226, 382);
            this.panel2.TabIndex = 0;
            // 
            // lblClear
            // 
            this.lblClear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblClear.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblClear.ForeColor = System.Drawing.Color.White;
            this.lblClear.Location = new System.Drawing.Point(16, 331);
            this.lblClear.Name = "lblClear";
            this.lblClear.Size = new System.Drawing.Size(192, 40);
            this.lblClear.TabIndex = 22;
            this.lblClear.Text = "Clear";
            this.lblClear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblClear.Click += new System.EventHandler(this.lblClear_Click);
            // 
            // lblTest
            // 
            this.lblTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTest.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTest.ForeColor = System.Drawing.Color.White;
            this.lblTest.Location = new System.Drawing.Point(16, 279);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(192, 40);
            this.lblTest.TabIndex = 21;
            this.lblTest.Text = "Test";
            this.lblTest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTest.Click += new System.EventHandler(this.lblTest_Click);
            // 
            // nupdnMaxAngle
            // 
            this.nupdnMaxAngle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.nupdnMaxAngle.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nupdnMaxAngle.ForeColor = System.Drawing.Color.White;
            this.nupdnMaxAngle.Location = new System.Drawing.Point(128, 60);
            this.nupdnMaxAngle.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.nupdnMaxAngle.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nupdnMaxAngle.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.nupdnMaxAngle.Name = "nupdnMaxAngle";
            this.nupdnMaxAngle.Size = new System.Drawing.Size(80, 27);
            this.nupdnMaxAngle.TabIndex = 19;
            this.nupdnMaxAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nupdnMaxAngle.Leave += new System.EventHandler(this.nupdnMaxAngle_Leave);
            // 
            // nupdnMatchScore
            // 
            this.nupdnMatchScore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.nupdnMatchScore.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nupdnMatchScore.ForeColor = System.Drawing.Color.White;
            this.nupdnMatchScore.Location = new System.Drawing.Point(128, 21);
            this.nupdnMatchScore.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.nupdnMatchScore.Name = "nupdnMatchScore";
            this.nupdnMatchScore.ReadOnly = true;
            this.nupdnMatchScore.Size = new System.Drawing.Size(80, 27);
            this.nupdnMatchScore.TabIndex = 13;
            this.nupdnMatchScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nupdnMatchScore.Click += new System.EventHandler(this.nupdnMatchScore_Click);
            this.nupdnMatchScore.Leave += new System.EventHandler(this.nupdnMatchScore_Leave);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 31);
            this.label3.TabIndex = 3;
            this.label3.Text = "Angle Max";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 31);
            this.label2.TabIndex = 2;
            this.label2.Text = "Score [%]";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEditMark
            // 
            this.lblEditMark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEditMark.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblEditMark.ForeColor = System.Drawing.Color.White;
            this.lblEditMark.Location = new System.Drawing.Point(16, 103);
            this.lblEditMark.Name = "lblEditMark";
            this.lblEditMark.Size = new System.Drawing.Size(192, 40);
            this.lblEditMark.TabIndex = 23;
            this.lblEditMark.Text = "Edit";
            this.lblEditMark.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEditMark.Click += new System.EventHandler(this.lblEditMark_Click);
            // 
            // CogPatternMatchingParamControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.Controls.Add(this.tableLayoutPanel2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CogPatternMatchingParamControl";
            this.Size = new System.Drawing.Size(532, 386);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogPatternDisplay)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nupdnMaxAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupdnMatchScore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblMasking;
        private Cognex.VisionPro.Display.CogDisplay cogPatternDisplay;
        private System.Windows.Forms.Label lblTrain;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown nupdnMaxAngle;
        private System.Windows.Forms.NumericUpDown nupdnMatchScore;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTest;
        private System.Windows.Forms.Label lblClear;
        private System.Windows.Forms.Label lblEditMark;
    }
}
