namespace Jastech.Framework.Winform.Controls
{
    partial class TaskProgressControl
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
            this.tplLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblStep = new System.Windows.Forms.Label();
            this.lblTaskName = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.pbxLoading = new System.Windows.Forms.PictureBox();
            this.tplLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // tplLayout
            // 
            this.tplLayout.ColumnCount = 2;
            this.tplLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tplLayout.Controls.Add(this.lblStep, 0, 3);
            this.tplLayout.Controls.Add(this.lblTaskName, 0, 0);
            this.tplLayout.Controls.Add(this.progressBar, 0, 2);
            this.tplLayout.Controls.Add(this.pbxLoading, 1, 1);
            this.tplLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tplLayout.Location = new System.Drawing.Point(0, 0);
            this.tplLayout.Name = "tplLayout";
            this.tplLayout.RowCount = 4;
            this.tplLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tplLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tplLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplLayout.Size = new System.Drawing.Size(540, 90);
            this.tplLayout.TabIndex = 1;
            // 
            // lblStep
            // 
            this.lblStep.AutoSize = true;
            this.tplLayout.SetColumnSpan(this.lblStep, 2);
            this.lblStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStep.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStep.ForeColor = System.Drawing.Color.White;
            this.lblStep.Location = new System.Drawing.Point(3, 75);
            this.lblStep.Name = "lblStep";
            this.lblStep.Size = new System.Drawing.Size(534, 15);
            this.lblStep.TabIndex = 5;
            this.lblStep.Text = "step";
            this.lblStep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTaskName
            // 
            this.lblTaskName.AutoSize = true;
            this.tplLayout.SetColumnSpan(this.lblTaskName, 2);
            this.lblTaskName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTaskName.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTaskName.ForeColor = System.Drawing.Color.White;
            this.lblTaskName.Location = new System.Drawing.Point(3, 0);
            this.lblTaskName.Name = "lblTaskName";
            this.lblTaskName.Size = new System.Drawing.Size(534, 40);
            this.lblTaskName.TabIndex = 3;
            this.lblTaskName.Text = "TaskName";
            this.lblTaskName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar
            // 
            this.tplLayout.SetColumnSpan(this.progressBar, 2);
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar.Location = new System.Drawing.Point(3, 63);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(534, 9);
            this.progressBar.Step = 1;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 1;
            // 
            // pbxLoading
            // 
            this.pbxLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxLoading.Image = global::Jastech.Framework.Winform.Properties.Resources.loading_processing;
            this.pbxLoading.InitialImage = null;
            this.pbxLoading.Location = new System.Drawing.Point(523, 43);
            this.pbxLoading.Name = "pbxLoading";
            this.pbxLoading.Size = new System.Drawing.Size(14, 14);
            this.pbxLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxLoading.TabIndex = 0;
            this.pbxLoading.TabStop = false;
            // 
            // TaskProgressControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.tplLayout);
            this.Name = "TaskProgressControl";
            this.Size = new System.Drawing.Size(540, 90);
            this.Load += new System.EventHandler(this.TaskProgressControl_Load);
            this.tplLayout.ResumeLayout(false);
            this.tplLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLoading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxLoading;
        private System.Windows.Forms.TableLayoutPanel tplLayout;
        private System.Windows.Forms.Label lblTaskName;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblStep;
    }
}
