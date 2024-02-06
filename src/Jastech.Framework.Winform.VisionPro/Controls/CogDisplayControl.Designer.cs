namespace Jastech.Framework.Winform.VisionPro.Controls
{
    partial class CogDisplayControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CogDisplayControl));
            this.cogDisplay = new Cognex.VisionPro.CogRecordDisplay();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cogDisplayStatusBar = new Cognex.VisionPro.CogDisplayStatusBarV2();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tlpFunctionButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnFileOpen = new System.Windows.Forms.Button();
            this.btnFitZoom = new System.Windows.Forms.Button();
            this.btnPanning = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnCrossLine = new System.Windows.Forms.Button();
            this.btnCustomCrossLine = new System.Windows.Forms.Button();
            this.btnPointToPoint = new System.Windows.Forms.Button();
            this.btnPointToLine = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tlpFunctionButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // cogDisplay
            // 
            this.cogDisplay.ColorMapLowerClipColor = System.Drawing.SystemColors.AppWorkspace;
            this.cogDisplay.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay.ColorMapUpperClipColor = System.Drawing.SystemColors.AppWorkspace;
            this.cogDisplay.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisplay.DoubleTapZoomCycleLength = 2;
            this.cogDisplay.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay.Location = new System.Drawing.Point(0, 0);
            this.cogDisplay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cogDisplay.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay.MouseWheelSensitivity = 1D;
            this.cogDisplay.Name = "cogDisplay";
            this.cogDisplay.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay.OcxState")));
            this.cogDisplay.Size = new System.Drawing.Size(741, 692);
            this.cogDisplay.TabIndex = 0;
            this.cogDisplay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cogDisplay_MouseDown);
            this.cogDisplay.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cogDisplay_MouseUp);
            this.cogDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cogDisplay_MouseMove);
            this.cogDisplay.Changed += new Cognex.VisionPro.CogChangedEventHandler(this.cogDisplay_Changed);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(40, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(741, 722);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 500F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 692);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(741, 30);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cogDisplayStatusBar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(244, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(494, 26);
            this.panel2.TabIndex = 2;
            // 
            // cogDisplayStatusBar
            // 
            this.cogDisplayStatusBar.CoordinateSpaceName = "*\\#";
            this.cogDisplayStatusBar.CoordinateSpaceName3D = "*\\#";
            this.cogDisplayStatusBar.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cogDisplayStatusBar.ForeColor = System.Drawing.Color.White;
            this.cogDisplayStatusBar.Location = new System.Drawing.Point(68, 0);
            this.cogDisplayStatusBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cogDisplayStatusBar.Name = "cogDisplayStatusBar";
            this.cogDisplayStatusBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cogDisplayStatusBar.Size = new System.Drawing.Size(429, 26);
            this.cogDisplayStatusBar.TabIndex = 1;
            this.cogDisplayStatusBar.Use3DCoordinateSpaceTree = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cogDisplay);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(741, 692);
            this.panel1.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.tlpFunctionButtons, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(781, 722);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // tlpFunctionButtons
            // 
            this.tlpFunctionButtons.ColumnCount = 1;
            this.tlpFunctionButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFunctionButtons.Controls.Add(this.btnFileOpen, 0, 0);
            this.tlpFunctionButtons.Controls.Add(this.btnFitZoom, 0, 1);
            this.tlpFunctionButtons.Controls.Add(this.btnPanning, 0, 2);
            this.tlpFunctionButtons.Controls.Add(this.btnClearAll, 0, 3);
            this.tlpFunctionButtons.Controls.Add(this.btnCrossLine, 0, 4);
            this.tlpFunctionButtons.Controls.Add(this.btnCustomCrossLine, 0, 5);
            this.tlpFunctionButtons.Controls.Add(this.btnPointToPoint, 0, 6);
            this.tlpFunctionButtons.Controls.Add(this.btnPointToLine, 0, 7);
            this.tlpFunctionButtons.Controls.Add(this.button2, 0, 8);
            this.tlpFunctionButtons.Controls.Add(this.button3, 0, 9);
            this.tlpFunctionButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFunctionButtons.Location = new System.Drawing.Point(0, 0);
            this.tlpFunctionButtons.Margin = new System.Windows.Forms.Padding(0);
            this.tlpFunctionButtons.Name = "tlpFunctionButtons";
            this.tlpFunctionButtons.RowCount = 13;
            this.tlpFunctionButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpFunctionButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpFunctionButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpFunctionButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpFunctionButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpFunctionButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpFunctionButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpFunctionButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpFunctionButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpFunctionButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpFunctionButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpFunctionButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpFunctionButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFunctionButtons.Size = new System.Drawing.Size(40, 722);
            this.tlpFunctionButtons.TabIndex = 1;
            // 
            // btnFileOpen
            // 
            this.btnFileOpen.BackgroundImage = global::Jastech.Framework.Winform.VisionPro.Properties.Resources.PictureFolder2_White;
            this.btnFileOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFileOpen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFileOpen.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnFileOpen.FlatAppearance.BorderSize = 2;
            this.btnFileOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFileOpen.Location = new System.Drawing.Point(0, 0);
            this.btnFileOpen.Margin = new System.Windows.Forms.Padding(0);
            this.btnFileOpen.Name = "btnFileOpen";
            this.btnFileOpen.Size = new System.Drawing.Size(40, 40);
            this.btnFileOpen.TabIndex = 1;
            this.btnFileOpen.UseVisualStyleBackColor = true;
            this.btnFileOpen.Click += new System.EventHandler(this.btnFileOpen_Click);
            // 
            // btnFitZoom
            // 
            this.btnFitZoom.BackgroundImage = global::Jastech.Framework.Winform.VisionPro.Properties.Resources.Fit_White;
            this.btnFitZoom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFitZoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFitZoom.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnFitZoom.FlatAppearance.BorderSize = 2;
            this.btnFitZoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFitZoom.Location = new System.Drawing.Point(0, 40);
            this.btnFitZoom.Margin = new System.Windows.Forms.Padding(0);
            this.btnFitZoom.Name = "btnFitZoom";
            this.btnFitZoom.Size = new System.Drawing.Size(40, 40);
            this.btnFitZoom.TabIndex = 2;
            this.btnFitZoom.UseVisualStyleBackColor = true;
            this.btnFitZoom.Click += new System.EventHandler(this.btnFitZoom_Click);
            // 
            // btnPanning
            // 
            this.btnPanning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.btnPanning.BackgroundImage = global::Jastech.Framework.Winform.VisionPro.Properties.Resources.Panning_White;
            this.btnPanning.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPanning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPanning.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPanning.FlatAppearance.BorderSize = 2;
            this.btnPanning.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPanning.Location = new System.Drawing.Point(0, 80);
            this.btnPanning.Margin = new System.Windows.Forms.Padding(0);
            this.btnPanning.Name = "btnPanning";
            this.btnPanning.Size = new System.Drawing.Size(40, 40);
            this.btnPanning.TabIndex = 3;
            this.btnPanning.UseVisualStyleBackColor = false;
            this.btnPanning.Click += new System.EventHandler(this.btnPanning_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.BackgroundImage = global::Jastech.Framework.Winform.VisionPro.Properties.Resources.Delete_White;
            this.btnClearAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClearAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClearAll.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClearAll.FlatAppearance.BorderSize = 2;
            this.btnClearAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearAll.Location = new System.Drawing.Point(0, 120);
            this.btnClearAll.Margin = new System.Windows.Forms.Padding(0);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(40, 40);
            this.btnClearAll.TabIndex = 9;
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // btnCrossLine
            // 
            this.btnCrossLine.BackgroundImage = global::Jastech.Framework.Winform.VisionPro.Properties.Resources.CenterCrossFixed_White;
            this.btnCrossLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCrossLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCrossLine.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCrossLine.FlatAppearance.BorderSize = 2;
            this.btnCrossLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrossLine.Location = new System.Drawing.Point(0, 160);
            this.btnCrossLine.Margin = new System.Windows.Forms.Padding(0);
            this.btnCrossLine.Name = "btnCrossLine";
            this.btnCrossLine.Size = new System.Drawing.Size(40, 40);
            this.btnCrossLine.TabIndex = 3;
            this.btnCrossLine.UseVisualStyleBackColor = true;
            this.btnCrossLine.Click += new System.EventHandler(this.btnCrossLine_Click);
            // 
            // btnCustomCrossLine
            // 
            this.btnCustomCrossLine.BackgroundImage = global::Jastech.Framework.Winform.VisionPro.Properties.Resources.CenterCross_White;
            this.btnCustomCrossLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCustomCrossLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCustomCrossLine.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCustomCrossLine.FlatAppearance.BorderSize = 2;
            this.btnCustomCrossLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomCrossLine.Location = new System.Drawing.Point(0, 200);
            this.btnCustomCrossLine.Margin = new System.Windows.Forms.Padding(0);
            this.btnCustomCrossLine.Name = "btnCustomCrossLine";
            this.btnCustomCrossLine.Size = new System.Drawing.Size(40, 40);
            this.btnCustomCrossLine.TabIndex = 4;
            this.btnCustomCrossLine.UseVisualStyleBackColor = true;
            this.btnCustomCrossLine.Click += new System.EventHandler(this.btnCustomCrossLine_Click);
            // 
            // btnPointToPoint
            // 
            this.btnPointToPoint.BackgroundImage = global::Jastech.Framework.Winform.VisionPro.Properties.Resources.Measure_White;
            this.btnPointToPoint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPointToPoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPointToPoint.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPointToPoint.FlatAppearance.BorderSize = 2;
            this.btnPointToPoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPointToPoint.Location = new System.Drawing.Point(0, 240);
            this.btnPointToPoint.Margin = new System.Windows.Forms.Padding(0);
            this.btnPointToPoint.Name = "btnPointToPoint";
            this.btnPointToPoint.Size = new System.Drawing.Size(40, 40);
            this.btnPointToPoint.TabIndex = 5;
            this.btnPointToPoint.UseVisualStyleBackColor = true;
            this.btnPointToPoint.Click += new System.EventHandler(this.btnPointToPoint_Click);
            // 
            // btnPointToLine
            // 
            this.btnPointToLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPointToLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPointToLine.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPointToLine.FlatAppearance.BorderSize = 2;
            this.btnPointToLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPointToLine.Image = global::Jastech.Framework.Winform.VisionPro.Properties.Resources.Arrows;
            this.btnPointToLine.Location = new System.Drawing.Point(0, 280);
            this.btnPointToLine.Margin = new System.Windows.Forms.Padding(0);
            this.btnPointToLine.Name = "btnPointToLine";
            this.btnPointToLine.Size = new System.Drawing.Size(40, 40);
            this.btnPointToLine.TabIndex = 6;
            this.btnPointToLine.UseVisualStyleBackColor = true;
            this.btnPointToLine.Click += new System.EventHandler(this.btnPointToLine_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(0, 320);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 40);
            this.button2.TabIndex = 7;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button3.FlatAppearance.BorderSize = 2;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(0, 360);
            this.button3.Margin = new System.Windows.Forms.Padding(0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(40, 40);
            this.button3.TabIndex = 8;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // CogDisplayControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.Controls.Add(this.tableLayoutPanel3);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CogDisplayControl";
            this.Size = new System.Drawing.Size(781, 722);
            this.Load += new System.EventHandler(this.CogDisplayControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tlpFunctionButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Cognex.VisionPro.CogRecordDisplay cogDisplay;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private Cognex.VisionPro.CogDisplayStatusBarV2 cogDisplayStatusBar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tlpFunctionButtons;
        private System.Windows.Forms.Button btnFitZoom;
        private System.Windows.Forms.Button btnPanning;
        private System.Windows.Forms.Button btnCrossLine;
        private System.Windows.Forms.Button btnCustomCrossLine;
        private System.Windows.Forms.Button btnPointToPoint;
        private System.Windows.Forms.Button btnPointToLine;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnFileOpen;
        private System.Windows.Forms.Button btnClearAll;
    }
}
