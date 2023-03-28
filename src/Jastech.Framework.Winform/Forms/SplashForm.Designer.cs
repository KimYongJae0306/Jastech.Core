namespace Jastech.Framework.Winform.Forms
{
    partial class SplashForm
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
            this.components = new System.ComponentModel.Container();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblProgressMessage = new System.Windows.Forms.Label();
            this.lblCopyrightText = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.companyLogo = new System.Windows.Forms.PictureBox();
            this.lblVersionText = new System.Windows.Forms.Label();
            this.SplashActionTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.companyLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(66, 263);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(344, 22);
            this.progressBar.TabIndex = 15;
            // 
            // lblProgressMessage
            // 
            this.lblProgressMessage.AutoSize = true;
            this.lblProgressMessage.ForeColor = System.Drawing.Color.Black;
            this.lblProgressMessage.Location = new System.Drawing.Point(64, 248);
            this.lblProgressMessage.Name = "lblProgressMessage";
            this.lblProgressMessage.Size = new System.Drawing.Size(74, 15);
            this.lblProgressMessage.TabIndex = 12;
            this.lblProgressMessage.Text = "Loading...";
            // 
            // lblCopyrightText
            // 
            this.lblCopyrightText.AutoSize = true;
            this.lblCopyrightText.ForeColor = System.Drawing.Color.Black;
            this.lblCopyrightText.Location = new System.Drawing.Point(64, 299);
            this.lblCopyrightText.Name = "lblCopyrightText";
            this.lblCopyrightText.Size = new System.Drawing.Size(296, 15);
            this.lblCopyrightText.TabIndex = 13;
            this.lblCopyrightText.Text = "©1987 Famecs Solutions. All right reserved.";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(54, 119);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(537, 89);
            this.lblTitle.TabIndex = 11;
            this.lblTitle.Text = "Jastech";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // companyLogo
            // 
            this.companyLogo.Image = global::Jastech.Framework.Winform.Properties.Resources.JastechLogo;
            this.companyLogo.Location = new System.Drawing.Point(12, 12);
            this.companyLogo.Name = "companyLogo";
            this.companyLogo.Size = new System.Drawing.Size(226, 87);
            this.companyLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.companyLogo.TabIndex = 14;
            this.companyLogo.TabStop = false;
            // 
            // lblVersionText
            // 
            this.lblVersionText.AutoSize = true;
            this.lblVersionText.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblVersionText.ForeColor = System.Drawing.Color.Black;
            this.lblVersionText.Location = new System.Drawing.Point(451, 265);
            this.lblVersionText.Name = "lblVersionText";
            this.lblVersionText.Size = new System.Drawing.Size(108, 20);
            this.lblVersionText.TabIndex = 16;
            this.lblVersionText.Text = "Version 1.0";
            // 
            // SplashActionTimer
            // 
            this.SplashActionTimer.Tick += new System.EventHandler(this.SplashActionTimer_Tick);
            // 
            // SplashForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(693, 355);
            this.Controls.Add(this.lblVersionText);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.companyLogo);
            this.Controls.Add(this.lblProgressMessage);
            this.Controls.Add(this.lblCopyrightText);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashForm";
            this.Load += new System.EventHandler(this.SplashForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.companyLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        public System.Windows.Forms.PictureBox companyLogo;
        public System.Windows.Forms.Label lblProgressMessage;
        public System.Windows.Forms.Label lblCopyrightText;
        public System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.Label lblVersionText;
        private System.Windows.Forms.Timer SplashActionTimer;
    }
}