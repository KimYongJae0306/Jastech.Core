﻿namespace Jastech.Framework.Winform.VisionPro.Controls
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
            this.nupdnMaxAngle = new System.Windows.Forms.NumericUpDown();
            this.nupdnMatchScore = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 375F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(665, 482);
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
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 312F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(367, 474);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // lblMasking
            // 
            this.lblMasking.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMasking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMasking.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMasking.Location = new System.Drawing.Point(4, 362);
            this.lblMasking.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMasking.Name = "lblMasking";
            this.lblMasking.Size = new System.Drawing.Size(359, 50);
            this.lblMasking.TabIndex = 21;
            this.lblMasking.Text = "Masking";
            this.lblMasking.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.cogPatternDisplay.Location = new System.Drawing.Point(4, 2);
            this.cogPatternDisplay.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cogPatternDisplay.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogPatternDisplay.MouseWheelSensitivity = 1D;
            this.cogPatternDisplay.Name = "cogPatternDisplay";
            this.cogPatternDisplay.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogPatternDisplay.OcxState")));
            this.cogPatternDisplay.Size = new System.Drawing.Size(359, 308);
            this.cogPatternDisplay.TabIndex = 1;
            // 
            // lblTrain
            // 
            this.lblTrain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTrain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrain.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTrain.Location = new System.Drawing.Point(4, 312);
            this.lblTrain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTrain.Name = "lblTrain";
            this.lblTrain.Size = new System.Drawing.Size(359, 50);
            this.lblTrain.TabIndex = 20;
            this.lblTrain.Text = "Train";
            this.lblTrain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTrain.Click += new System.EventHandler(this.lblAddPattern_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.nupdnMaxAngle);
            this.panel2.Controls.Add(this.nupdnMatchScore);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(379, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(282, 478);
            this.panel2.TabIndex = 0;
            // 
            // nupdnMaxAngle
            // 
            this.nupdnMaxAngle.Font = new System.Drawing.Font("돋움", 10.8F);
            this.nupdnMaxAngle.Location = new System.Drawing.Point(160, 79);
            this.nupdnMaxAngle.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
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
            this.nupdnMaxAngle.Size = new System.Drawing.Size(100, 28);
            this.nupdnMaxAngle.TabIndex = 19;
            this.nupdnMaxAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nupdnMatchScore
            // 
            this.nupdnMatchScore.Font = new System.Drawing.Font("돋움", 10.8F);
            this.nupdnMatchScore.Location = new System.Drawing.Point(160, 31);
            this.nupdnMatchScore.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.nupdnMatchScore.Name = "nupdnMatchScore";
            this.nupdnMatchScore.Size = new System.Drawing.Size(100, 28);
            this.nupdnMatchScore.TabIndex = 13;
            this.nupdnMatchScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(15, 71);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 39);
            this.label3.TabIndex = 3;
            this.label3.Text = "Angle Max";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(15, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 39);
            this.label2.TabIndex = 2;
            this.label2.Text = "Score [%]";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CogPatternMatchingParamControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "CogPatternMatchingParamControl";
            this.Size = new System.Drawing.Size(665, 482);
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
    }
}