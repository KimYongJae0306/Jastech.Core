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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblAddPattern = new System.Windows.Forms.Label();
            this.nupdnMaxAngle = new System.Windows.Forms.NumericUpDown();
            this.nupdnMatchScore = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cogPatternDisplay = new Cognex.VisionPro.Display.CogDisplay();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupdnMaxAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupdnMatchScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogPatternDisplay)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 262);
            this.panel1.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 260F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(627, 260);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblAddPattern);
            this.panel2.Controls.Add(this.nupdnMaxAngle);
            this.panel2.Controls.Add(this.nupdnMatchScore);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(370, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(254, 254);
            this.panel2.TabIndex = 0;
            // 
            // lblAddPattern
            // 
            this.lblAddPattern.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAddPattern.Font = new System.Drawing.Font("돋움", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAddPattern.Location = new System.Drawing.Point(18, 186);
            this.lblAddPattern.Name = "lblAddPattern";
            this.lblAddPattern.Size = new System.Drawing.Size(219, 54);
            this.lblAddPattern.TabIndex = 20;
            this.lblAddPattern.Text = "패턴 등록";
            this.lblAddPattern.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAddPattern.Click += new System.EventHandler(this.lblAddPattern_Click);
            // 
            // nupdnMaxAngle
            // 
            this.nupdnMaxAngle.Font = new System.Drawing.Font("돋움", 10.8F);
            this.nupdnMaxAngle.Location = new System.Drawing.Point(146, 79);
            this.nupdnMaxAngle.Margin = new System.Windows.Forms.Padding(4);
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
            this.nupdnMaxAngle.Size = new System.Drawing.Size(91, 28);
            this.nupdnMaxAngle.TabIndex = 19;
            this.nupdnMaxAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nupdnMatchScore
            // 
            this.nupdnMatchScore.Font = new System.Drawing.Font("돋움", 10.8F);
            this.nupdnMatchScore.Location = new System.Drawing.Point(146, 31);
            this.nupdnMatchScore.Margin = new System.Windows.Forms.Padding(4);
            this.nupdnMatchScore.Name = "nupdnMatchScore";
            this.nupdnMatchScore.Size = new System.Drawing.Size(91, 28);
            this.nupdnMatchScore.TabIndex = 13;
            this.nupdnMatchScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("돋움", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(14, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 39);
            this.label3.TabIndex = 3;
            this.label3.Text = "Angle Max";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("돋움", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(14, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 39);
            this.label2.TabIndex = 2;
            this.label2.Text = "Score [%]";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cogPatternDisplay
            // 
            this.cogPatternDisplay.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogPatternDisplay.ColorMapLowerRoiLimit = 0D;
            this.cogPatternDisplay.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogPatternDisplay.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogPatternDisplay.ColorMapUpperRoiLimit = 1D;
            this.cogPatternDisplay.Dock = System.Windows.Forms.DockStyle.Top;
            this.cogPatternDisplay.DoubleTapZoomCycleLength = 2;
            this.cogPatternDisplay.DoubleTapZoomSensitivity = 2.5D;
            this.cogPatternDisplay.Location = new System.Drawing.Point(0, 0);
            this.cogPatternDisplay.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogPatternDisplay.MouseWheelSensitivity = 1D;
            this.cogPatternDisplay.Name = "cogPatternDisplay";
            this.cogPatternDisplay.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogPatternDisplay.OcxState")));
            this.cogPatternDisplay.Size = new System.Drawing.Size(361, 251);
            this.cogPatternDisplay.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cogPatternDisplay);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(361, 254);
            this.panel3.TabIndex = 1;
            // 
            // CogPatternMatchingParamControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "CogPatternMatchingParamControl";
            this.Size = new System.Drawing.Size(629, 262);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nupdnMaxAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupdnMatchScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogPatternDisplay)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private Cognex.VisionPro.Display.CogDisplay cogPatternDisplay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nupdnMaxAngle;
        private System.Windows.Forms.NumericUpDown nupdnMatchScore;
        private System.Windows.Forms.Label lblAddPattern;
        private System.Windows.Forms.Panel panel3;
    }
}
