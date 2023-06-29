namespace Jastech.Framework.Winform.Forms
{
    partial class ROIJogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ROIJogForm));
            this.tlpTeachJog = new System.Windows.Forms.TableLayoutPanel();
            this.pnlMode = new System.Windows.Forms.Panel();
            this.pnlMoveMode = new System.Windows.Forms.Panel();
            this.tlpDirectionMove = new System.Windows.Forms.TableLayoutPanel();
            this.lblMove = new System.Windows.Forms.Label();
            this.lblMoveRight = new System.Windows.Forms.Label();
            this.lblMoveUp = new System.Windows.Forms.Label();
            this.lblMoveLeft = new System.Windows.Forms.Label();
            this.lblMoveDown = new System.Windows.Forms.Label();
            this.pnlSizeMode = new System.Windows.Forms.Panel();
            this.tlpDirectionSize = new System.Windows.Forms.TableLayoutPanel();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblZoomInVertical = new System.Windows.Forms.Label();
            this.lblZoomOutHorizontal = new System.Windows.Forms.Label();
            this.lblZoomInHorizontal = new System.Windows.Forms.Label();
            this.lblZoomOutVertical = new System.Windows.Forms.Label();
            this.pnlSelectJog = new System.Windows.Forms.Panel();
            this.tlpSelectJog = new System.Windows.Forms.TableLayoutPanel();
            this.tlpMovePixel = new System.Windows.Forms.TableLayoutPanel();
            this.lblJogScale = new System.Windows.Forms.Label();
            this.lblMovePixel = new System.Windows.Forms.Label();
            this.tlpMoveSize = new System.Windows.Forms.TableLayoutPanel();
            this.lblSizeMode = new System.Windows.Forms.Label();
            this.lblMoveMode = new System.Windows.Forms.Label();
            this.tlpROIType = new System.Windows.Forms.TableLayoutPanel();
            this.lblOriginMode = new System.Windows.Forms.Label();
            this.lblTrainMode = new System.Windows.Forms.Label();
            this.lblROIMode = new System.Windows.Forms.Label();
            this.pnlSkew = new System.Windows.Forms.Panel();
            this.tlpSkew = new System.Windows.Forms.TableLayoutPanel();
            this.lblSkewCW = new System.Windows.Forms.Label();
            this.lblSkewZero = new System.Windows.Forms.Label();
            this.lblSkewCCW = new System.Windows.Forms.Label();
            this.tlpTeachJog.SuspendLayout();
            this.pnlMode.SuspendLayout();
            this.pnlMoveMode.SuspendLayout();
            this.tlpDirectionMove.SuspendLayout();
            this.pnlSizeMode.SuspendLayout();
            this.tlpDirectionSize.SuspendLayout();
            this.pnlSelectJog.SuspendLayout();
            this.tlpSelectJog.SuspendLayout();
            this.tlpMovePixel.SuspendLayout();
            this.tlpMoveSize.SuspendLayout();
            this.tlpROIType.SuspendLayout();
            this.pnlSkew.SuspendLayout();
            this.tlpSkew.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpTeachJog
            // 
            this.tlpTeachJog.ColumnCount = 3;
            this.tlpTeachJog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpTeachJog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpTeachJog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpTeachJog.Controls.Add(this.pnlMode, 1, 0);
            this.tlpTeachJog.Controls.Add(this.pnlSelectJog, 2, 0);
            this.tlpTeachJog.Controls.Add(this.pnlSkew, 0, 0);
            this.tlpTeachJog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTeachJog.Location = new System.Drawing.Point(0, 0);
            this.tlpTeachJog.Name = "tlpTeachJog";
            this.tlpTeachJog.RowCount = 1;
            this.tlpTeachJog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTeachJog.Size = new System.Drawing.Size(544, 291);
            this.tlpTeachJog.TabIndex = 1;
            // 
            // pnlMode
            // 
            this.pnlMode.Controls.Add(this.pnlMoveMode);
            this.pnlMode.Controls.Add(this.pnlSizeMode);
            this.pnlMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMode.Location = new System.Drawing.Point(108, 0);
            this.pnlMode.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMode.Name = "pnlMode";
            this.pnlMode.Size = new System.Drawing.Size(326, 291);
            this.pnlMode.TabIndex = 11;
            // 
            // pnlMoveMode
            // 
            this.pnlMoveMode.Controls.Add(this.tlpDirectionMove);
            this.pnlMoveMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMoveMode.Location = new System.Drawing.Point(0, 0);
            this.pnlMoveMode.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMoveMode.Name = "pnlMoveMode";
            this.pnlMoveMode.Size = new System.Drawing.Size(326, 291);
            this.pnlMoveMode.TabIndex = 4;
            // 
            // tlpDirectionMove
            // 
            this.tlpDirectionMove.ColumnCount = 3;
            this.tlpDirectionMove.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpDirectionMove.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpDirectionMove.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpDirectionMove.Controls.Add(this.lblMove, 1, 1);
            this.tlpDirectionMove.Controls.Add(this.lblMoveRight, 2, 1);
            this.tlpDirectionMove.Controls.Add(this.lblMoveUp, 1, 0);
            this.tlpDirectionMove.Controls.Add(this.lblMoveLeft, 0, 1);
            this.tlpDirectionMove.Controls.Add(this.lblMoveDown, 1, 2);
            this.tlpDirectionMove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDirectionMove.Location = new System.Drawing.Point(0, 0);
            this.tlpDirectionMove.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDirectionMove.Name = "tlpDirectionMove";
            this.tlpDirectionMove.RowCount = 3;
            this.tlpDirectionMove.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpDirectionMove.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpDirectionMove.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpDirectionMove.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDirectionMove.Size = new System.Drawing.Size(326, 291);
            this.tlpDirectionMove.TabIndex = 0;
            // 
            // lblMove
            // 
            this.lblMove.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMove.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMove.Image = global::Jastech.Framework.Winform.Properties.Resources.ROIMoveMode_White;
            this.lblMove.Location = new System.Drawing.Point(108, 96);
            this.lblMove.Margin = new System.Windows.Forms.Padding(0);
            this.lblMove.Name = "lblMove";
            this.lblMove.Size = new System.Drawing.Size(108, 96);
            this.lblMove.TabIndex = 6;
            this.lblMove.Text = "MOVE";
            this.lblMove.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblMoveRight
            // 
            this.lblMoveRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMoveRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMoveRight.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMoveRight.Image = global::Jastech.Framework.Winform.Properties.Resources.Arrow_Right_White;
            this.lblMoveRight.Location = new System.Drawing.Point(216, 96);
            this.lblMoveRight.Margin = new System.Windows.Forms.Padding(0);
            this.lblMoveRight.Name = "lblMoveRight";
            this.lblMoveRight.Size = new System.Drawing.Size(110, 96);
            this.lblMoveRight.TabIndex = 10;
            this.lblMoveRight.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblMoveRight.Click += new System.EventHandler(this.lblMoveRight_Click);
            // 
            // lblMoveUp
            // 
            this.lblMoveUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMoveUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMoveUp.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMoveUp.Image = global::Jastech.Framework.Winform.Properties.Resources.Arrow_Up_White;
            this.lblMoveUp.Location = new System.Drawing.Point(108, 0);
            this.lblMoveUp.Margin = new System.Windows.Forms.Padding(0);
            this.lblMoveUp.Name = "lblMoveUp";
            this.lblMoveUp.Size = new System.Drawing.Size(108, 96);
            this.lblMoveUp.TabIndex = 10;
            this.lblMoveUp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblMoveUp.Click += new System.EventHandler(this.lblMoveUp_Click);
            // 
            // lblMoveLeft
            // 
            this.lblMoveLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMoveLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMoveLeft.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMoveLeft.Image = global::Jastech.Framework.Winform.Properties.Resources.Arrow_Left_White;
            this.lblMoveLeft.Location = new System.Drawing.Point(0, 96);
            this.lblMoveLeft.Margin = new System.Windows.Forms.Padding(0);
            this.lblMoveLeft.Name = "lblMoveLeft";
            this.lblMoveLeft.Size = new System.Drawing.Size(108, 96);
            this.lblMoveLeft.TabIndex = 10;
            this.lblMoveLeft.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblMoveLeft.Click += new System.EventHandler(this.lblMoveLeft_Click);
            // 
            // lblMoveDown
            // 
            this.lblMoveDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMoveDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMoveDown.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMoveDown.Image = global::Jastech.Framework.Winform.Properties.Resources.Arrow_Down_White;
            this.lblMoveDown.Location = new System.Drawing.Point(108, 192);
            this.lblMoveDown.Margin = new System.Windows.Forms.Padding(0);
            this.lblMoveDown.Name = "lblMoveDown";
            this.lblMoveDown.Size = new System.Drawing.Size(108, 99);
            this.lblMoveDown.TabIndex = 10;
            this.lblMoveDown.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblMoveDown.Click += new System.EventHandler(this.lblMoveDown_Click);
            // 
            // pnlSizeMode
            // 
            this.pnlSizeMode.Controls.Add(this.tlpDirectionSize);
            this.pnlSizeMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSizeMode.Location = new System.Drawing.Point(0, 0);
            this.pnlSizeMode.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSizeMode.Name = "pnlSizeMode";
            this.pnlSizeMode.Size = new System.Drawing.Size(326, 291);
            this.pnlSizeMode.TabIndex = 10;
            // 
            // tlpDirectionSize
            // 
            this.tlpDirectionSize.ColumnCount = 3;
            this.tlpDirectionSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpDirectionSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpDirectionSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpDirectionSize.Controls.Add(this.lblSize, 1, 1);
            this.tlpDirectionSize.Controls.Add(this.lblZoomInVertical, 1, 0);
            this.tlpDirectionSize.Controls.Add(this.lblZoomOutHorizontal, 0, 1);
            this.tlpDirectionSize.Controls.Add(this.lblZoomInHorizontal, 2, 1);
            this.tlpDirectionSize.Controls.Add(this.lblZoomOutVertical, 1, 2);
            this.tlpDirectionSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDirectionSize.Location = new System.Drawing.Point(0, 0);
            this.tlpDirectionSize.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDirectionSize.Name = "tlpDirectionSize";
            this.tlpDirectionSize.RowCount = 3;
            this.tlpDirectionSize.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpDirectionSize.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpDirectionSize.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpDirectionSize.Size = new System.Drawing.Size(326, 291);
            this.tlpDirectionSize.TabIndex = 0;
            // 
            // lblSize
            // 
            this.lblSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSize.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSize.Image = global::Jastech.Framework.Winform.Properties.Resources.ROISizeMode_White;
            this.lblSize.Location = new System.Drawing.Point(108, 96);
            this.lblSize.Margin = new System.Windows.Forms.Padding(0);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(108, 96);
            this.lblSize.TabIndex = 6;
            this.lblSize.Text = "SIZE";
            this.lblSize.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblZoomInVertical
            // 
            this.lblZoomInVertical.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblZoomInVertical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblZoomInVertical.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblZoomInVertical.Image = global::Jastech.Framework.Winform.Properties.Resources.Caret_Vertical_Expand_White;
            this.lblZoomInVertical.Location = new System.Drawing.Point(108, 0);
            this.lblZoomInVertical.Margin = new System.Windows.Forms.Padding(0);
            this.lblZoomInVertical.Name = "lblZoomInVertical";
            this.lblZoomInVertical.Size = new System.Drawing.Size(108, 96);
            this.lblZoomInVertical.TabIndex = 11;
            this.lblZoomInVertical.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblZoomInVertical.Click += new System.EventHandler(this.lblZoomInVertical_Click);
            // 
            // lblZoomOutHorizontal
            // 
            this.lblZoomOutHorizontal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblZoomOutHorizontal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblZoomOutHorizontal.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblZoomOutHorizontal.Image = global::Jastech.Framework.Winform.Properties.Resources.Caret_Horizontal_Focus_White;
            this.lblZoomOutHorizontal.Location = new System.Drawing.Point(0, 96);
            this.lblZoomOutHorizontal.Margin = new System.Windows.Forms.Padding(0);
            this.lblZoomOutHorizontal.Name = "lblZoomOutHorizontal";
            this.lblZoomOutHorizontal.Size = new System.Drawing.Size(108, 96);
            this.lblZoomOutHorizontal.TabIndex = 11;
            this.lblZoomOutHorizontal.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblZoomOutHorizontal.Click += new System.EventHandler(this.lblZoomOutHorizontal_Click);
            // 
            // lblZoomInHorizontal
            // 
            this.lblZoomInHorizontal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblZoomInHorizontal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblZoomInHorizontal.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblZoomInHorizontal.Image = global::Jastech.Framework.Winform.Properties.Resources.Caret_Horizontal_Expand_White;
            this.lblZoomInHorizontal.Location = new System.Drawing.Point(216, 96);
            this.lblZoomInHorizontal.Margin = new System.Windows.Forms.Padding(0);
            this.lblZoomInHorizontal.Name = "lblZoomInHorizontal";
            this.lblZoomInHorizontal.Size = new System.Drawing.Size(110, 96);
            this.lblZoomInHorizontal.TabIndex = 11;
            this.lblZoomInHorizontal.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblZoomInHorizontal.Click += new System.EventHandler(this.lblZoomInHorizontal_Click);
            // 
            // lblZoomOutVertical
            // 
            this.lblZoomOutVertical.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblZoomOutVertical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblZoomOutVertical.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblZoomOutVertical.Image = global::Jastech.Framework.Winform.Properties.Resources.Caret_Vertical_Focus_White;
            this.lblZoomOutVertical.Location = new System.Drawing.Point(108, 192);
            this.lblZoomOutVertical.Margin = new System.Windows.Forms.Padding(0);
            this.lblZoomOutVertical.Name = "lblZoomOutVertical";
            this.lblZoomOutVertical.Size = new System.Drawing.Size(108, 99);
            this.lblZoomOutVertical.TabIndex = 11;
            this.lblZoomOutVertical.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblZoomOutVertical.Click += new System.EventHandler(this.lblZoomOutVertical_Click);
            // 
            // pnlSelectJog
            // 
            this.pnlSelectJog.Controls.Add(this.tlpSelectJog);
            this.pnlSelectJog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSelectJog.Location = new System.Drawing.Point(434, 0);
            this.pnlSelectJog.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSelectJog.Name = "pnlSelectJog";
            this.pnlSelectJog.Size = new System.Drawing.Size(110, 291);
            this.pnlSelectJog.TabIndex = 9;
            // 
            // tlpSelectJog
            // 
            this.tlpSelectJog.ColumnCount = 1;
            this.tlpSelectJog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSelectJog.Controls.Add(this.tlpMovePixel, 0, 1);
            this.tlpSelectJog.Controls.Add(this.tlpMoveSize, 0, 0);
            this.tlpSelectJog.Controls.Add(this.tlpROIType, 0, 2);
            this.tlpSelectJog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSelectJog.Location = new System.Drawing.Point(0, 0);
            this.tlpSelectJog.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSelectJog.Name = "tlpSelectJog";
            this.tlpSelectJog.RowCount = 3;
            this.tlpSelectJog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSelectJog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSelectJog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSelectJog.Size = new System.Drawing.Size(110, 291);
            this.tlpSelectJog.TabIndex = 1;
            // 
            // tlpMovePixel
            // 
            this.tlpMovePixel.ColumnCount = 1;
            this.tlpMovePixel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMovePixel.Controls.Add(this.lblJogScale, 0, 1);
            this.tlpMovePixel.Controls.Add(this.lblMovePixel, 0, 0);
            this.tlpMovePixel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMovePixel.Location = new System.Drawing.Point(0, 96);
            this.tlpMovePixel.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMovePixel.Name = "tlpMovePixel";
            this.tlpMovePixel.RowCount = 2;
            this.tlpMovePixel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMovePixel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMovePixel.Size = new System.Drawing.Size(110, 96);
            this.tlpMovePixel.TabIndex = 8;
            // 
            // lblJogScale
            // 
            this.lblJogScale.AutoSize = true;
            this.lblJogScale.BackColor = System.Drawing.Color.White;
            this.lblJogScale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblJogScale.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblJogScale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblJogScale.Location = new System.Drawing.Point(9, 57);
            this.lblJogScale.Margin = new System.Windows.Forms.Padding(9);
            this.lblJogScale.Name = "lblJogScale";
            this.lblJogScale.Size = new System.Drawing.Size(92, 30);
            this.lblJogScale.TabIndex = 8;
            this.lblJogScale.Text = "1";
            this.lblJogScale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblJogScale.Click += new System.EventHandler(this.lblJogScale_Click);
            // 
            // lblMovePixel
            // 
            this.lblMovePixel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMovePixel.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMovePixel.Location = new System.Drawing.Point(0, 0);
            this.lblMovePixel.Margin = new System.Windows.Forms.Padding(0);
            this.lblMovePixel.Name = "lblMovePixel";
            this.lblMovePixel.Size = new System.Drawing.Size(110, 48);
            this.lblMovePixel.TabIndex = 7;
            this.lblMovePixel.Text = "Move Pixel";
            this.lblMovePixel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpMoveSize
            // 
            this.tlpMoveSize.ColumnCount = 1;
            this.tlpMoveSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMoveSize.Controls.Add(this.lblSizeMode, 0, 1);
            this.tlpMoveSize.Controls.Add(this.lblMoveMode, 0, 0);
            this.tlpMoveSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMoveSize.Location = new System.Drawing.Point(0, 0);
            this.tlpMoveSize.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMoveSize.Name = "tlpMoveSize";
            this.tlpMoveSize.RowCount = 2;
            this.tlpMoveSize.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMoveSize.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMoveSize.Size = new System.Drawing.Size(110, 96);
            this.tlpMoveSize.TabIndex = 6;
            // 
            // lblSizeMode
            // 
            this.lblSizeMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSizeMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSizeMode.Location = new System.Drawing.Point(0, 48);
            this.lblSizeMode.Margin = new System.Windows.Forms.Padding(0);
            this.lblSizeMode.Name = "lblSizeMode";
            this.lblSizeMode.Size = new System.Drawing.Size(110, 48);
            this.lblSizeMode.TabIndex = 6;
            this.lblSizeMode.Text = "Size";
            this.lblSizeMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSizeMode.Click += new System.EventHandler(this.lblSizeMode_Click);
            // 
            // lblMoveMode
            // 
            this.lblMoveMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMoveMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMoveMode.Location = new System.Drawing.Point(0, 0);
            this.lblMoveMode.Margin = new System.Windows.Forms.Padding(0);
            this.lblMoveMode.Name = "lblMoveMode";
            this.lblMoveMode.Size = new System.Drawing.Size(110, 48);
            this.lblMoveMode.TabIndex = 6;
            this.lblMoveMode.Text = "Move";
            this.lblMoveMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMoveMode.Click += new System.EventHandler(this.lblMoveMode_Click);
            // 
            // tlpROIType
            // 
            this.tlpROIType.ColumnCount = 1;
            this.tlpROIType.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpROIType.Controls.Add(this.lblOriginMode, 0, 2);
            this.tlpROIType.Controls.Add(this.lblTrainMode, 0, 1);
            this.tlpROIType.Controls.Add(this.lblROIMode, 0, 0);
            this.tlpROIType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpROIType.Location = new System.Drawing.Point(0, 192);
            this.tlpROIType.Margin = new System.Windows.Forms.Padding(0);
            this.tlpROIType.Name = "tlpROIType";
            this.tlpROIType.RowCount = 3;
            this.tlpROIType.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpROIType.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpROIType.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpROIType.Size = new System.Drawing.Size(110, 99);
            this.tlpROIType.TabIndex = 7;
            // 
            // lblOriginMode
            // 
            this.lblOriginMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOriginMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOriginMode.Location = new System.Drawing.Point(0, 66);
            this.lblOriginMode.Margin = new System.Windows.Forms.Padding(0);
            this.lblOriginMode.Name = "lblOriginMode";
            this.lblOriginMode.Size = new System.Drawing.Size(110, 33);
            this.lblOriginMode.TabIndex = 9;
            this.lblOriginMode.Text = "Origin";
            this.lblOriginMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblOriginMode.Click += new System.EventHandler(this.lblOriginMode_Click);
            // 
            // lblTrainMode
            // 
            this.lblTrainMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTrainMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrainMode.Location = new System.Drawing.Point(0, 33);
            this.lblTrainMode.Margin = new System.Windows.Forms.Padding(0);
            this.lblTrainMode.Name = "lblTrainMode";
            this.lblTrainMode.Size = new System.Drawing.Size(110, 33);
            this.lblTrainMode.TabIndex = 8;
            this.lblTrainMode.Text = "Train";
            this.lblTrainMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTrainMode.Click += new System.EventHandler(this.lblTrainMode_Click);
            // 
            // lblROIMode
            // 
            this.lblROIMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblROIMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblROIMode.Location = new System.Drawing.Point(0, 0);
            this.lblROIMode.Margin = new System.Windows.Forms.Padding(0);
            this.lblROIMode.Name = "lblROIMode";
            this.lblROIMode.Size = new System.Drawing.Size(110, 33);
            this.lblROIMode.TabIndex = 7;
            this.lblROIMode.Text = "ROI";
            this.lblROIMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblROIMode.Click += new System.EventHandler(this.lblROIMode_Click);
            // 
            // pnlSkew
            // 
            this.pnlSkew.Controls.Add(this.tlpSkew);
            this.pnlSkew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSkew.Location = new System.Drawing.Point(0, 0);
            this.pnlSkew.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSkew.Name = "pnlSkew";
            this.pnlSkew.Size = new System.Drawing.Size(108, 291);
            this.pnlSkew.TabIndex = 3;
            // 
            // tlpSkew
            // 
            this.tlpSkew.ColumnCount = 1;
            this.tlpSkew.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSkew.Controls.Add(this.lblSkewCW, 0, 2);
            this.tlpSkew.Controls.Add(this.lblSkewZero, 0, 1);
            this.tlpSkew.Controls.Add(this.lblSkewCCW, 0, 0);
            this.tlpSkew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSkew.Location = new System.Drawing.Point(0, 0);
            this.tlpSkew.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSkew.Name = "tlpSkew";
            this.tlpSkew.RowCount = 3;
            this.tlpSkew.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSkew.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSkew.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSkew.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSkew.Size = new System.Drawing.Size(108, 291);
            this.tlpSkew.TabIndex = 0;
            // 
            // lblSkewCW
            // 
            this.lblSkewCW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSkewCW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSkewCW.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSkewCW.Image = global::Jastech.Framework.Winform.Properties.Resources.Skew_CW;
            this.lblSkewCW.Location = new System.Drawing.Point(0, 192);
            this.lblSkewCW.Margin = new System.Windows.Forms.Padding(0);
            this.lblSkewCW.Name = "lblSkewCW";
            this.lblSkewCW.Size = new System.Drawing.Size(108, 99);
            this.lblSkewCW.TabIndex = 11;
            this.lblSkewCW.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblSkewCW.Click += new System.EventHandler(this.lblSkewCW_Click);
            // 
            // lblSkewZero
            // 
            this.lblSkewZero.AutoSize = true;
            this.lblSkewZero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSkewZero.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSkewZero.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSkewZero.Image = ((System.Drawing.Image)(resources.GetObject("lblSkewZero.Image")));
            this.lblSkewZero.Location = new System.Drawing.Point(0, 96);
            this.lblSkewZero.Margin = new System.Windows.Forms.Padding(0);
            this.lblSkewZero.Name = "lblSkewZero";
            this.lblSkewZero.Size = new System.Drawing.Size(108, 96);
            this.lblSkewZero.TabIndex = 10;
            this.lblSkewZero.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblSkewZero.Click += new System.EventHandler(this.lblSkewZero_Click);
            // 
            // lblSkewCCW
            // 
            this.lblSkewCCW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSkewCCW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSkewCCW.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSkewCCW.Image = global::Jastech.Framework.Winform.Properties.Resources.Skew_CCW;
            this.lblSkewCCW.Location = new System.Drawing.Point(0, 0);
            this.lblSkewCCW.Margin = new System.Windows.Forms.Padding(0);
            this.lblSkewCCW.Name = "lblSkewCCW";
            this.lblSkewCCW.Size = new System.Drawing.Size(108, 96);
            this.lblSkewCCW.TabIndex = 11;
            this.lblSkewCCW.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblSkewCCW.Click += new System.EventHandler(this.lblSkewCCW_Click);
            // 
            // ROIJogControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(544, 291);
            this.Controls.Add(this.tlpTeachJog);
            this.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ROIJogControl";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ROIJogControl_FormClosed);
            this.Load += new System.EventHandler(this.ROIJogControl_Load);
            this.tlpTeachJog.ResumeLayout(false);
            this.pnlMode.ResumeLayout(false);
            this.pnlMoveMode.ResumeLayout(false);
            this.tlpDirectionMove.ResumeLayout(false);
            this.pnlSizeMode.ResumeLayout(false);
            this.tlpDirectionSize.ResumeLayout(false);
            this.pnlSelectJog.ResumeLayout(false);
            this.tlpSelectJog.ResumeLayout(false);
            this.tlpMovePixel.ResumeLayout(false);
            this.tlpMovePixel.PerformLayout();
            this.tlpMoveSize.ResumeLayout(false);
            this.tlpROIType.ResumeLayout(false);
            this.pnlSkew.ResumeLayout(false);
            this.tlpSkew.ResumeLayout(false);
            this.tlpSkew.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpTeachJog;
        private System.Windows.Forms.Panel pnlMode;
        private System.Windows.Forms.Panel pnlMoveMode;
        private System.Windows.Forms.TableLayoutPanel tlpDirectionMove;
        private System.Windows.Forms.Label lblMove;
        private System.Windows.Forms.Panel pnlSizeMode;
        private System.Windows.Forms.TableLayoutPanel tlpDirectionSize;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Panel pnlSelectJog;
        private System.Windows.Forms.TableLayoutPanel tlpSelectJog;
        private System.Windows.Forms.TableLayoutPanel tlpMovePixel;
        public System.Windows.Forms.Label lblJogScale;
        private System.Windows.Forms.Label lblMovePixel;
        private System.Windows.Forms.TableLayoutPanel tlpMoveSize;
        public System.Windows.Forms.TableLayoutPanel tlpROIType;
        private System.Windows.Forms.Panel pnlSkew;
        public System.Windows.Forms.TableLayoutPanel tlpSkew;
        private System.Windows.Forms.Label lblMoveRight;
        private System.Windows.Forms.Label lblMoveUp;
        private System.Windows.Forms.Label lblMoveLeft;
        private System.Windows.Forms.Label lblMoveDown;
        private System.Windows.Forms.Label lblSizeMode;
        private System.Windows.Forms.Label lblMoveMode;
        private System.Windows.Forms.Label lblTrainMode;
        private System.Windows.Forms.Label lblROIMode;
        private System.Windows.Forms.Label lblSkewZero;
        private System.Windows.Forms.Label lblSkewCW;
        private System.Windows.Forms.Label lblSkewCCW;
        private System.Windows.Forms.Label lblZoomInHorizontal;
        private System.Windows.Forms.Label lblZoomInVertical;
        private System.Windows.Forms.Label lblZoomOutHorizontal;
        private System.Windows.Forms.Label lblZoomOutVertical;
        private System.Windows.Forms.Label lblOriginMode;
    }
}
