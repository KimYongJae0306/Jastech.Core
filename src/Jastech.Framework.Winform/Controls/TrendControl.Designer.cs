namespace Jastech.Framework.Winform.Controls
{
    partial class TrendControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpTrend = new System.Windows.Forms.TableLayoutPanel();
            this.tlpHours = new System.Windows.Forms.TableLayoutPanel();
            this.dgvDays = new System.Windows.Forms.DataGridView();
            this.colDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMarkNG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlpHour = new System.Windows.Forms.TableLayoutPanel();
            this.lblHourClear = new System.Windows.Forms.Label();
            this.lblHour = new System.Windows.Forms.Label();
            this.lblUnitReport = new System.Windows.Forms.Label();
            this.tlpDays = new System.Windows.Forms.TableLayoutPanel();
            this.tlpDay = new System.Windows.Forms.TableLayoutPanel();
            this.lblDayClear = new System.Windows.Forms.Label();
            this.lblDaily = new System.Windows.Forms.Label();
            this.tlpTrend.SuspendLayout();
            this.tlpHours.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDays)).BeginInit();
            this.tlpHour.SuspendLayout();
            this.tlpDays.SuspendLayout();
            this.tlpDay.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpTrend
            // 
            this.tlpTrend.ColumnCount = 1;
            this.tlpTrend.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTrend.Controls.Add(this.tlpHours, 0, 2);
            this.tlpTrend.Controls.Add(this.lblUnitReport, 0, 0);
            this.tlpTrend.Controls.Add(this.tlpDays, 0, 1);
            this.tlpTrend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTrend.Location = new System.Drawing.Point(0, 0);
            this.tlpTrend.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTrend.Name = "tlpTrend";
            this.tlpTrend.RowCount = 3;
            this.tlpTrend.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpTrend.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpTrend.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tlpTrend.Size = new System.Drawing.Size(326, 633);
            this.tlpTrend.TabIndex = 0;
            // 
            // tlpHours
            // 
            this.tlpHours.ColumnCount = 1;
            this.tlpHours.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHours.Controls.Add(this.dgvDays, 0, 1);
            this.tlpHours.Controls.Add(this.tlpHour, 0, 0);
            this.tlpHours.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpHours.Location = new System.Drawing.Point(0, 158);
            this.tlpHours.Margin = new System.Windows.Forms.Padding(0);
            this.tlpHours.Name = "tlpHours";
            this.tlpHours.RowCount = 3;
            this.tlpHours.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpHours.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpHours.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpHours.Size = new System.Drawing.Size(326, 475);
            this.tlpHours.TabIndex = 3;
            // 
            // dgvDays
            // 
            this.dgvDays.AllowUserToAddRows = false;
            this.dgvDays.AllowUserToDeleteRows = false;
            this.dgvDays.AllowUserToResizeRows = false;
            this.dgvDays.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDays.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.dgvDays.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDays.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDays.ColumnHeadersHeight = 40;
            this.dgvDays.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDays.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDateTime,
            this.colReport,
            this.colTotal,
            this.colMarkNG});
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDays.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgvDays.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDays.EnableHeadersVisualStyles = false;
            this.dgvDays.Location = new System.Drawing.Point(0, 40);
            this.dgvDays.Margin = new System.Windows.Forms.Padding(0);
            this.dgvDays.MultiSelect = false;
            this.dgvDays.Name = "dgvDays";
            this.dgvDays.ReadOnly = true;
            this.dgvDays.RowHeadersVisible = false;
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
            this.dgvDays.RowsDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvDays.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvDays.RowTemplate.Height = 23;
            this.dgvDays.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDays.Size = new System.Drawing.Size(326, 304);
            this.dgvDays.TabIndex = 4;
            // 
            // colDateTime
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.colDateTime.DefaultCellStyle = dataGridViewCellStyle9;
            this.colDateTime.HeaderText = "DateTime";
            this.colDateTime.MinimumWidth = 100;
            this.colDateTime.Name = "colDateTime";
            this.colDateTime.ReadOnly = true;
            this.colDateTime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDateTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colReport
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colReport.DefaultCellStyle = dataGridViewCellStyle10;
            this.colReport.HeaderText = "Report";
            this.colReport.MinimumWidth = 100;
            this.colReport.Name = "colReport";
            this.colReport.ReadOnly = true;
            this.colReport.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colReport.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colTotal
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.colTotal.DefaultCellStyle = dataGridViewCellStyle11;
            this.colTotal.HeaderText = "Total";
            this.colTotal.MinimumWidth = 35;
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            this.colTotal.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colMarkNG
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.colMarkNG.DefaultCellStyle = dataGridViewCellStyle12;
            this.colMarkNG.HeaderText = "MarkNG";
            this.colMarkNG.MinimumWidth = 50;
            this.colMarkNG.Name = "colMarkNG";
            this.colMarkNG.ReadOnly = true;
            this.colMarkNG.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colMarkNG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tlpHour
            // 
            this.tlpHour.ColumnCount = 2;
            this.tlpHour.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpHour.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpHour.Controls.Add(this.lblHourClear, 1, 0);
            this.tlpHour.Controls.Add(this.lblHour, 0, 0);
            this.tlpHour.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpHour.Location = new System.Drawing.Point(0, 0);
            this.tlpHour.Margin = new System.Windows.Forms.Padding(0);
            this.tlpHour.Name = "tlpHour";
            this.tlpHour.RowCount = 1;
            this.tlpHour.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHour.Size = new System.Drawing.Size(326, 40);
            this.tlpHour.TabIndex = 4;
            // 
            // lblHourClear
            // 
            this.lblHourClear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHourClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHourClear.Location = new System.Drawing.Point(228, 0);
            this.lblHourClear.Margin = new System.Windows.Forms.Padding(0);
            this.lblHourClear.Name = "lblHourClear";
            this.lblHourClear.Size = new System.Drawing.Size(98, 40);
            this.lblHourClear.TabIndex = 4;
            this.lblHourClear.Text = "Clear";
            this.lblHourClear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHour
            // 
            this.lblHour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHour.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHour.Location = new System.Drawing.Point(0, 0);
            this.lblHour.Margin = new System.Windows.Forms.Padding(0);
            this.lblHour.Name = "lblHour";
            this.lblHour.Size = new System.Drawing.Size(228, 40);
            this.lblHour.TabIndex = 2;
            this.lblHour.Text = "■ Recently Report (24hr)";
            this.lblHour.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUnitReport
            // 
            this.lblUnitReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblUnitReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUnitReport.Location = new System.Drawing.Point(0, 0);
            this.lblUnitReport.Margin = new System.Windows.Forms.Padding(0);
            this.lblUnitReport.Name = "lblUnitReport";
            this.lblUnitReport.Size = new System.Drawing.Size(326, 40);
            this.lblUnitReport.TabIndex = 1;
            this.lblUnitReport.Text = "　Report";
            this.lblUnitReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpDays
            // 
            this.tlpDays.ColumnCount = 1;
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDays.Controls.Add(this.tlpDay, 0, 0);
            this.tlpDays.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDays.Location = new System.Drawing.Point(0, 40);
            this.tlpDays.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDays.Name = "tlpDays";
            this.tlpDays.RowCount = 2;
            this.tlpDays.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpDays.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDays.Size = new System.Drawing.Size(326, 118);
            this.tlpDays.TabIndex = 2;
            // 
            // tlpDay
            // 
            this.tlpDay.ColumnCount = 2;
            this.tlpDay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpDay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpDay.Controls.Add(this.lblDayClear, 1, 0);
            this.tlpDay.Controls.Add(this.lblDaily, 0, 0);
            this.tlpDay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDay.Location = new System.Drawing.Point(0, 0);
            this.tlpDay.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDay.Name = "tlpDay";
            this.tlpDay.RowCount = 1;
            this.tlpDay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDay.Size = new System.Drawing.Size(326, 40);
            this.tlpDay.TabIndex = 3;
            // 
            // lblDayClear
            // 
            this.lblDayClear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDayClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDayClear.Location = new System.Drawing.Point(228, 0);
            this.lblDayClear.Margin = new System.Windows.Forms.Padding(0);
            this.lblDayClear.Name = "lblDayClear";
            this.lblDayClear.Size = new System.Drawing.Size(98, 40);
            this.lblDayClear.TabIndex = 3;
            this.lblDayClear.Text = "Clear";
            this.lblDayClear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDaily
            // 
            this.lblDaily.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDaily.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDaily.Location = new System.Drawing.Point(0, 0);
            this.lblDaily.Margin = new System.Windows.Forms.Padding(0);
            this.lblDaily.Name = "lblDaily";
            this.lblDaily.Size = new System.Drawing.Size(228, 40);
            this.lblDaily.TabIndex = 2;
            this.lblDaily.Text = "■ Daily Report (30days)";
            this.lblDaily.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TrendControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.Controls.Add(this.tlpTrend);
            this.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "TrendControl";
            this.Size = new System.Drawing.Size(326, 633);
            this.tlpTrend.ResumeLayout(false);
            this.tlpHours.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDays)).EndInit();
            this.tlpHour.ResumeLayout(false);
            this.tlpDays.ResumeLayout(false);
            this.tlpDay.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpTrend;
        private System.Windows.Forms.TableLayoutPanel tlpHours;
        private System.Windows.Forms.Label lblHour;
        private System.Windows.Forms.Label lblUnitReport;
        private System.Windows.Forms.TableLayoutPanel tlpDays;
        private System.Windows.Forms.Label lblDaily;
        private System.Windows.Forms.TableLayoutPanel tlpDay;
        private System.Windows.Forms.TableLayoutPanel tlpHour;
        private System.Windows.Forms.Label lblHourClear;
        private System.Windows.Forms.Label lblDayClear;
        private System.Windows.Forms.DataGridView dgvDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMarkNG;
    }
}
