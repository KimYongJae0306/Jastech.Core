namespace Jastech.Framework.Winform.Forms
{
    partial class HistoryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpHistoryItems = new System.Windows.Forms.TableLayoutPanel();
            this.btnUPH = new System.Windows.Forms.Button();
            this.pnlPage = new System.Windows.Forms.Panel();
            this.tlpHistory = new System.Windows.Forms.TableLayoutPanel();
            this.cdrMonthCalendar = new System.Windows.Forms.MonthCalendar();
            this.tlpHistoryItems.SuspendLayout();
            this.tlpHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpHistoryItems
            // 
            this.tlpHistoryItems.ColumnCount = 1;
            this.tlpHistoryItems.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHistoryItems.Controls.Add(this.cdrMonthCalendar, 0, 0);
            this.tlpHistoryItems.Controls.Add(this.btnUPH, 0, 1);
            this.tlpHistoryItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpHistoryItems.Location = new System.Drawing.Point(809, 0);
            this.tlpHistoryItems.Margin = new System.Windows.Forms.Padding(0);
            this.tlpHistoryItems.Name = "tlpHistoryItems";
            this.tlpHistoryItems.RowCount = 4;
            this.tlpHistoryItems.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 162F));
            this.tlpHistoryItems.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpHistoryItems.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpHistoryItems.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHistoryItems.Size = new System.Drawing.Size(220, 750);
            this.tlpHistoryItems.TabIndex = 0;
            // 
            // btnUPH
            // 
            this.btnUPH.BackColor = System.Drawing.Color.White;
            this.btnUPH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUPH.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold);
            this.btnUPH.ForeColor = System.Drawing.Color.Black;
            this.btnUPH.Location = new System.Drawing.Point(3, 165);
            this.btnUPH.Name = "btnUPH";
            this.btnUPH.Size = new System.Drawing.Size(214, 114);
            this.btnUPH.TabIndex = 12;
            this.btnUPH.Text = "UPH";
            this.btnUPH.UseVisualStyleBackColor = false;
            this.btnUPH.Click += new System.EventHandler(this.btnUPH_Click);
            // 
            // pnlPage
            // 
            this.pnlPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPage.Location = new System.Drawing.Point(0, 0);
            this.pnlPage.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPage.Name = "pnlPage";
            this.pnlPage.Size = new System.Drawing.Size(809, 750);
            this.pnlPage.TabIndex = 1;
            // 
            // tlpHistory
            // 
            this.tlpHistory.ColumnCount = 2;
            this.tlpHistory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHistory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.tlpHistory.Controls.Add(this.pnlPage, 0, 0);
            this.tlpHistory.Controls.Add(this.tlpHistoryItems, 1, 0);
            this.tlpHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpHistory.Location = new System.Drawing.Point(0, 0);
            this.tlpHistory.Margin = new System.Windows.Forms.Padding(0);
            this.tlpHistory.Name = "tlpHistory";
            this.tlpHistory.RowCount = 1;
            this.tlpHistory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHistory.Size = new System.Drawing.Size(1029, 750);
            this.tlpHistory.TabIndex = 14;
            // 
            // cdrMonthCalendar
            // 
            this.cdrMonthCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cdrMonthCalendar.Location = new System.Drawing.Point(0, 0);
            this.cdrMonthCalendar.Margin = new System.Windows.Forms.Padding(0);
            this.cdrMonthCalendar.Name = "cdrMonthCalendar";
            this.cdrMonthCalendar.TabIndex = 6;
            this.cdrMonthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.cdrMonthCalendar_DateChanged);
            // 
            // HistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1029, 750);
            this.Controls.Add(this.tlpHistory);
            this.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "HistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.HistoryForm_Load);
            this.tlpHistoryItems.ResumeLayout(false);
            this.tlpHistory.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpHistoryItems;
        private System.Windows.Forms.Button btnUPH;
        private System.Windows.Forms.Panel pnlPage;
        private System.Windows.Forms.TableLayoutPanel tlpHistory;
        private System.Windows.Forms.MonthCalendar cdrMonthCalendar;
    }
}