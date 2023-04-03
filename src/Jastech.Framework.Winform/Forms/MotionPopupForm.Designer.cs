﻿namespace Jastech.Framework.Winform.Forms
{
    partial class MotionPopupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MotionPopupForm));
            this.tlpMotionPopup = new System.Windows.Forms.TableLayoutPanel();
            this.tlpFormFunction = new System.Windows.Forms.TableLayoutPanel();
            this.btnMoveTeachingPosition = new System.Windows.Forms.Button();
            this.btnStopTeachingPosition = new System.Windows.Forms.Button();
            this.btnCommand = new System.Windows.Forms.Button();
            this.btnParameter = new System.Windows.Forms.Button();
            this.pnlFunction = new System.Windows.Forms.Panel();
            this.tlpMotionParameter = new System.Windows.Forms.TableLayoutPanel();
            this.tlpTeachingList = new System.Windows.Forms.TableLayoutPanel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tlpMotionPopup.SuspendLayout();
            this.tlpFormFunction.SuspendLayout();
            this.pnlFunction.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMotionPopup
            // 
            this.tlpMotionPopup.ColumnCount = 1;
            this.tlpMotionPopup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMotionPopup.Controls.Add(this.tlpFormFunction, 0, 2);
            this.tlpMotionPopup.Controls.Add(this.pnlFunction, 0, 1);
            this.tlpMotionPopup.Controls.Add(this.tlpTeachingList, 0, 0);
            this.tlpMotionPopup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMotionPopup.Location = new System.Drawing.Point(0, 0);
            this.tlpMotionPopup.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMotionPopup.Name = "tlpMotionPopup";
            this.tlpMotionPopup.RowCount = 3;
            this.tlpMotionPopup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMotionPopup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tlpMotionPopup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpMotionPopup.Size = new System.Drawing.Size(784, 861);
            this.tlpMotionPopup.TabIndex = 2;
            // 
            // tlpFormFunction
            // 
            this.tlpFormFunction.ColumnCount = 8;
            this.tlpFormFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpFormFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpFormFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFormFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpFormFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpFormFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFormFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpFormFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpFormFunction.Controls.Add(this.btnMoveTeachingPosition, 3, 0);
            this.tlpFormFunction.Controls.Add(this.btnExit, 7, 0);
            this.tlpFormFunction.Controls.Add(this.btnStopTeachingPosition, 4, 0);
            this.tlpFormFunction.Controls.Add(this.btnSave, 6, 0);
            this.tlpFormFunction.Controls.Add(this.btnCommand, 0, 0);
            this.tlpFormFunction.Controls.Add(this.btnParameter, 1, 0);
            this.tlpFormFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFormFunction.Location = new System.Drawing.Point(0, 760);
            this.tlpFormFunction.Margin = new System.Windows.Forms.Padding(0);
            this.tlpFormFunction.Name = "tlpFormFunction";
            this.tlpFormFunction.RowCount = 1;
            this.tlpFormFunction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFormFunction.Size = new System.Drawing.Size(784, 101);
            this.tlpFormFunction.TabIndex = 1;
            // 
            // btnMoveTeachingPosition
            // 
            this.btnMoveTeachingPosition.BackColor = System.Drawing.Color.White;
            this.btnMoveTeachingPosition.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMoveTeachingPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMoveTeachingPosition.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnMoveTeachingPosition.Location = new System.Drawing.Point(295, 3);
            this.btnMoveTeachingPosition.Name = "btnMoveTeachingPosition";
            this.btnMoveTeachingPosition.Size = new System.Drawing.Size(94, 95);
            this.btnMoveTeachingPosition.TabIndex = 199;
            this.btnMoveTeachingPosition.Text = "MOVE TARGET";
            this.btnMoveTeachingPosition.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMoveTeachingPosition.UseVisualStyleBackColor = false;
            // 
            // btnStopTeachingPosition
            // 
            this.btnStopTeachingPosition.BackColor = System.Drawing.Color.White;
            this.btnStopTeachingPosition.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnStopTeachingPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStopTeachingPosition.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnStopTeachingPosition.Location = new System.Drawing.Point(395, 3);
            this.btnStopTeachingPosition.Name = "btnStopTeachingPosition";
            this.btnStopTeachingPosition.Size = new System.Drawing.Size(94, 95);
            this.btnStopTeachingPosition.TabIndex = 200;
            this.btnStopTeachingPosition.Text = "SET";
            this.btnStopTeachingPosition.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStopTeachingPosition.UseVisualStyleBackColor = false;
            // 
            // btnCommand
            // 
            this.btnCommand.BackColor = System.Drawing.Color.White;
            this.btnCommand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCommand.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnCommand.Location = new System.Drawing.Point(3, 3);
            this.btnCommand.Name = "btnCommand";
            this.btnCommand.Size = new System.Drawing.Size(94, 95);
            this.btnCommand.TabIndex = 292;
            this.btnCommand.Text = "PREV PAGE";
            this.btnCommand.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCommand.UseVisualStyleBackColor = false;
            // 
            // btnParameter
            // 
            this.btnParameter.BackColor = System.Drawing.Color.White;
            this.btnParameter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnParameter.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnParameter.Location = new System.Drawing.Point(103, 3);
            this.btnParameter.Name = "btnParameter";
            this.btnParameter.Size = new System.Drawing.Size(94, 95);
            this.btnParameter.TabIndex = 292;
            this.btnParameter.Text = "NEXT PAGE";
            this.btnParameter.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnParameter.UseVisualStyleBackColor = false;
            // 
            // pnlFunction
            // 
            this.pnlFunction.Controls.Add(this.tlpMotionParameter);
            this.pnlFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFunction.Location = new System.Drawing.Point(0, 76);
            this.pnlFunction.Margin = new System.Windows.Forms.Padding(0);
            this.pnlFunction.Name = "pnlFunction";
            this.pnlFunction.Size = new System.Drawing.Size(784, 684);
            this.pnlFunction.TabIndex = 2;
            // 
            // tlpMotionParameter
            // 
            this.tlpMotionParameter.ColumnCount = 1;
            this.tlpMotionParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMotionParameter.Location = new System.Drawing.Point(538, 19);
            this.tlpMotionParameter.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMotionParameter.Name = "tlpMotionParameter";
            this.tlpMotionParameter.RowCount = 5;
            this.tlpMotionParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpMotionParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpMotionParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpMotionParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpMotionParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpMotionParameter.Size = new System.Drawing.Size(205, 475);
            this.tlpMotionParameter.TabIndex = 4;
            // 
            // tlpTeachingList
            // 
            this.tlpTeachingList.ColumnCount = 1;
            this.tlpTeachingList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTeachingList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTeachingList.Location = new System.Drawing.Point(0, 0);
            this.tlpTeachingList.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTeachingList.Name = "tlpTeachingList";
            this.tlpTeachingList.RowCount = 1;
            this.tlpTeachingList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTeachingList.Size = new System.Drawing.Size(784, 76);
            this.tlpTeachingList.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExit.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnExit.Location = new System.Drawing.Point(687, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(94, 95);
            this.btnExit.TabIndex = 293;
            this.btnExit.Text = "EXIT";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSave.BackgroundImage")));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(587, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 95);
            this.btnSave.TabIndex = 292;
            this.btnSave.Text = "SAVE";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // MotionPopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 861);
            this.ControlBox = false;
            this.Controls.Add(this.tlpMotionPopup);
            this.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "MotionPopupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = " ";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MotionPopupForm_Load);
            this.tlpMotionPopup.ResumeLayout(false);
            this.tlpFormFunction.ResumeLayout(false);
            this.pnlFunction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMotionPopup;
        private System.Windows.Forms.TableLayoutPanel tlpFormFunction;
        private System.Windows.Forms.Button btnMoveTeachingPosition;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnStopTeachingPosition;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCommand;
        private System.Windows.Forms.Button btnParameter;
        private System.Windows.Forms.Panel pnlFunction;
        private System.Windows.Forms.TableLayoutPanel tlpMotionParameter;
        private System.Windows.Forms.TableLayoutPanel tlpTeachingList;
    }
}