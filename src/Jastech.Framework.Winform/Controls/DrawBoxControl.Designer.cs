namespace Jastech.Framework.Winform.Controls
{
    partial class DrawBoxControl
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
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlDisplay = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDrawROI = new System.Windows.Forms.Button();
            this.btnPanning = new System.Windows.Forms.Button();
            this.btnCrossLine = new System.Windows.Forms.Button();
            this.pbxDisplay = new System.Windows.Forms.PictureBox();
            this.btnDrawNone = new System.Windows.Forms.Button();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.pnlDisplay.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(695, 484);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnlDisplay, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(40, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(655, 484);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 500F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 454);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(655, 30);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(158, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(494, 26);
            this.panel2.TabIndex = 2;
            // 
            // pnlDisplay
            // 
            this.pnlDisplay.Controls.Add(this.pbxDisplay);
            this.pnlDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDisplay.Location = new System.Drawing.Point(0, 0);
            this.pnlDisplay.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDisplay.Name = "pnlDisplay";
            this.pnlDisplay.Size = new System.Drawing.Size(655, 454);
            this.pnlDisplay.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.btnDrawNone, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnDrawROI, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.btnPanning, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.btnCrossLine, 0, 3);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 6;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(40, 484);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // btnDrawROI
            // 
            this.btnDrawROI.BackgroundImage = global::Jastech.Framework.Winform.Properties.Resources.Roi;
            this.btnDrawROI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDrawROI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDrawROI.Location = new System.Drawing.Point(0, 40);
            this.btnDrawROI.Margin = new System.Windows.Forms.Padding(0);
            this.btnDrawROI.Name = "btnDrawROI";
            this.btnDrawROI.Size = new System.Drawing.Size(40, 40);
            this.btnDrawROI.TabIndex = 2;
            this.btnDrawROI.UseVisualStyleBackColor = true;
            this.btnDrawROI.Click += new System.EventHandler(this.btnDrawROI_Click);
            // 
            // btnPanning
            // 
            this.btnPanning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPanning.Location = new System.Drawing.Point(0, 80);
            this.btnPanning.Margin = new System.Windows.Forms.Padding(0);
            this.btnPanning.Name = "btnPanning";
            this.btnPanning.Size = new System.Drawing.Size(40, 40);
            this.btnPanning.TabIndex = 3;
            this.btnPanning.UseVisualStyleBackColor = false;
            this.btnPanning.Click += new System.EventHandler(this.btnPanning_Click);
            // 
            // btnCrossLine
            // 
            this.btnCrossLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCrossLine.Location = new System.Drawing.Point(0, 120);
            this.btnCrossLine.Margin = new System.Windows.Forms.Padding(0);
            this.btnCrossLine.Name = "btnCrossLine";
            this.btnCrossLine.Size = new System.Drawing.Size(40, 40);
            this.btnCrossLine.TabIndex = 3;
            this.btnCrossLine.UseVisualStyleBackColor = true;
            // 
            // pbxDisplay
            // 
            this.pbxDisplay.Location = new System.Drawing.Point(184, 62);
            this.pbxDisplay.Name = "pbxDisplay";
            this.pbxDisplay.Size = new System.Drawing.Size(326, 268);
            this.pbxDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxDisplay.TabIndex = 0;
            this.pbxDisplay.TabStop = false;
            this.pbxDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.pbxDisplay_Paint);
            this.pbxDisplay.DoubleClick += new System.EventHandler(this.pbxDisplay_DoubleClick);
            this.pbxDisplay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbxDisplay_MouseDown);
            this.pbxDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbxDisplay_MouseMove);
            this.pbxDisplay.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbxDisplay_MouseUp);
            // 
            // btnDrawNone
            // 
            this.btnDrawNone.BackgroundImage = global::Jastech.Framework.Winform.Properties.Resources.None;
            this.btnDrawNone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDrawNone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDrawNone.Location = new System.Drawing.Point(0, 0);
            this.btnDrawNone.Margin = new System.Windows.Forms.Padding(0);
            this.btnDrawNone.Name = "btnDrawNone";
            this.btnDrawNone.Size = new System.Drawing.Size(40, 40);
            this.btnDrawNone.TabIndex = 1;
            this.btnDrawNone.UseVisualStyleBackColor = true;
            this.btnDrawNone.Click += new System.EventHandler(this.btnDrawNone_Click);
            // 
            // DrawBoxControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.Controls.Add(this.tableLayoutPanel3);
            this.Name = "DrawBoxControl";
            this.Size = new System.Drawing.Size(695, 484);
            this.Load += new System.EventHandler(this.DrawBoxControl_Load);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.pnlDisplay.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlDisplay;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button btnDrawNone;
        private System.Windows.Forms.Button btnDrawROI;
        private System.Windows.Forms.Button btnPanning;
        private System.Windows.Forms.Button btnCrossLine;
        private System.Windows.Forms.PictureBox pbxDisplay;
    }
}
