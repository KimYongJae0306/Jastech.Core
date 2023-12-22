namespace Jastech.Framework.Winform.VisionPro.Forms
{
    partial class CogAlignEditForm
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
            this.cogPMAlignEditV21 = new Cognex.VisionPro.PMAlign.CogPMAlignEditV2();
            ((System.ComponentModel.ISupportInitialize)(this.cogPMAlignEditV21)).BeginInit();
            this.SuspendLayout();
            // 
            // cogPMAlignEditV21
            // 
            this.cogPMAlignEditV21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogPMAlignEditV21.Location = new System.Drawing.Point(0, 0);
            this.cogPMAlignEditV21.MinimumSize = new System.Drawing.Size(489, 0);
            this.cogPMAlignEditV21.Name = "cogPMAlignEditV21";
            this.cogPMAlignEditV21.Size = new System.Drawing.Size(1161, 748);
            this.cogPMAlignEditV21.SuspendElectricRuns = false;
            this.cogPMAlignEditV21.TabIndex = 0;
            // 
            // CogAlignEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 748);
            this.Controls.Add(this.cogPMAlignEditV21);
            this.Name = "CogAlignEditForm";
            this.Text = "CogAlignEditForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CogAlignEditForm_FormClosing);
            this.Load += new System.EventHandler(this.CogAlignEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cogPMAlignEditV21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Cognex.VisionPro.PMAlign.CogPMAlignEditV2 cogPMAlignEditV21;
    }
}