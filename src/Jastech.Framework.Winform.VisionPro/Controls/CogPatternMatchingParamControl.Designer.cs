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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.nupdnMaxAngle = new System.Windows.Forms.NumericUpDown();
            this.nupdnMatchScore = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTrain = new System.Windows.Forms.Label();
            this.cogPatternDisplay = new Cognex.VisionPro.Display.CogDisplay();
            this.lblMasking = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblInspection = new System.Windows.Forms.Label();
            this.gvResult = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnGlassID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnImagePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUpdated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupdnMaxAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupdnMatchScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogPatternDisplay)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvResult)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblInspection);
            this.panel2.Controls.Add(this.nupdnMaxAngle);
            this.panel2.Controls.Add(this.nupdnMatchScore);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(303, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(762, 396);
            this.panel2.TabIndex = 0;
            // 
            // nupdnMaxAngle
            // 
            this.nupdnMaxAngle.Font = new System.Drawing.Font("돋움", 10.8F);
            this.nupdnMaxAngle.Location = new System.Drawing.Point(128, 63);
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
            this.nupdnMaxAngle.Size = new System.Drawing.Size(80, 24);
            this.nupdnMaxAngle.TabIndex = 19;
            this.nupdnMaxAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nupdnMatchScore
            // 
            this.nupdnMatchScore.Font = new System.Drawing.Font("돋움", 10.8F);
            this.nupdnMatchScore.Location = new System.Drawing.Point(128, 25);
            this.nupdnMatchScore.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.nupdnMatchScore.Name = "nupdnMatchScore";
            this.nupdnMatchScore.Size = new System.Drawing.Size(80, 24);
            this.nupdnMatchScore.TabIndex = 13;
            this.nupdnMatchScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 31);
            this.label2.TabIndex = 2;
            this.label2.Text = "Score [%]";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTrain
            // 
            this.lblTrain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTrain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrain.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTrain.Location = new System.Drawing.Point(3, 250);
            this.lblTrain.Name = "lblTrain";
            this.lblTrain.Size = new System.Drawing.Size(288, 40);
            this.lblTrain.TabIndex = 20;
            this.lblTrain.Text = "Train";
            this.lblTrain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTrain.Click += new System.EventHandler(this.lblAddPattern_Click);
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
            // lblMasking
            // 
            this.lblMasking.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMasking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMasking.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMasking.Location = new System.Drawing.Point(3, 290);
            this.lblMasking.Name = "lblMasking";
            this.lblMasking.Size = new System.Drawing.Size(288, 40);
            this.lblMasking.TabIndex = 21;
            this.lblMasking.Text = "Masking";
            this.lblMasking.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(294, 394);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // lblInspection
            // 
            this.lblInspection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInspection.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblInspection.Location = new System.Drawing.Point(16, 106);
            this.lblInspection.Name = "lblInspection";
            this.lblInspection.Size = new System.Drawing.Size(192, 40);
            this.lblInspection.TabIndex = 21;
            this.lblInspection.Text = "Inspect";
            this.lblInspection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gvResult
            // 
            this.gvResult.AllowUserToAddRows = false;
            this.gvResult.AllowUserToDeleteRows = false;
            this.gvResult.AllowUserToResizeRows = false;
            this.gvResult.BackgroundColor = System.Drawing.Color.White;
            this.gvResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvResult.ColumnHeadersHeight = 35;
            this.gvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gvResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.ColumnGlassID,
            this.ColumnResult,
            this.ColumnImagePath,
            this.ColumnUpdated,
            this.Column1});
            this.gvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvResult.Location = new System.Drawing.Point(3, 404);
            this.gvResult.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gvResult.MultiSelect = false;
            this.gvResult.Name = "gvResult";
            this.gvResult.ReadOnly = true;
            this.gvResult.RowHeadersVisible = false;
            this.gvResult.RowTemplate.Height = 23;
            this.gvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvResult.Size = new System.Drawing.Size(1062, 154);
            this.gvResult.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gvResult, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1068, 562);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1068, 400);
            this.panel1.TabIndex = 6;
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1068, 400);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "No";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 50;
            // 
            // ColumnGlassID
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnGlassID.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnGlassID.HeaderText = "Score";
            this.ColumnGlassID.MinimumWidth = 90;
            this.ColumnGlassID.Name = "ColumnGlassID";
            this.ColumnGlassID.ReadOnly = true;
            this.ColumnGlassID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnGlassID.Width = 90;
            // 
            // ColumnResult
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnResult.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnResult.HeaderText = "X";
            this.ColumnResult.MinimumWidth = 90;
            this.ColumnResult.Name = "ColumnResult";
            this.ColumnResult.ReadOnly = true;
            this.ColumnResult.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnResult.Width = 90;
            // 
            // ColumnImagePath
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnImagePath.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnImagePath.HeaderText = "Y";
            this.ColumnImagePath.MinimumWidth = 90;
            this.ColumnImagePath.Name = "ColumnImagePath";
            this.ColumnImagePath.ReadOnly = true;
            this.ColumnImagePath.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnImagePath.Width = 90;
            // 
            // ColumnUpdated
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnUpdated.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnUpdated.HeaderText = "Angle";
            this.ColumnUpdated.MinimumWidth = 80;
            this.ColumnUpdated.Name = "ColumnUpdated";
            this.ColumnUpdated.ReadOnly = true;
            this.ColumnUpdated.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnUpdated.Width = 80;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CogPatternMatchingParamControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CogPatternMatchingParamControl";
            this.Size = new System.Drawing.Size(1068, 562);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nupdnMaxAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupdnMatchScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogPatternDisplay)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvResult)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private Cognex.VisionPro.Display.CogDisplay cogPatternDisplay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nupdnMaxAngle;
        private System.Windows.Forms.NumericUpDown nupdnMatchScore;
        private System.Windows.Forms.Label lblTrain;
        private System.Windows.Forms.Label lblMasking;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblInspection;
        private System.Windows.Forms.DataGridView gvResult;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnGlassID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnImagePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUpdated;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}
