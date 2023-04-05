namespace Jastech.Framework.Winform.Controls
{
    partial class MotionJogControl
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
            this.tlpJogControl = new System.Windows.Forms.TableLayoutPanel();
            this.tlpJog = new System.Windows.Forms.TableLayoutPanel();
            this.tlpJogOption = new System.Windows.Forms.TableLayoutPanel();
            this.pnlJogSpeedMode = new System.Windows.Forms.Panel();
            this.tlpJogSpeedMode = new System.Windows.Forms.TableLayoutPanel();
            this.rdoJogFastMode = new System.Windows.Forms.RadioButton();
            this.rdoJogSlowMode = new System.Windows.Forms.RadioButton();
            this.pnlJogMode = new System.Windows.Forms.Panel();
            this.tlpJogMode = new System.Windows.Forms.TableLayoutPanel();
            this.rdoIncreaseMode = new System.Windows.Forms.RadioButton();
            this.rdoJogMode = new System.Windows.Forms.RadioButton();
            this.pnlPitchXY = new System.Windows.Forms.Panel();
            this.tlpPitchXY = new System.Windows.Forms.TableLayoutPanel();
            this.lblPitchXY = new System.Windows.Forms.Label();
            this.lblPitchXYValue = new System.Windows.Forms.Label();
            this.pnlPitchZ = new System.Windows.Forms.Panel();
            this.tlpPitchZ = new System.Windows.Forms.TableLayoutPanel();
            this.lblPitchZ = new System.Windows.Forms.Label();
            this.lblPitchZValue = new System.Windows.Forms.Label();
            this.pnlJogOperation = new System.Windows.Forms.Panel();
            this.tlpJogOperation = new System.Windows.Forms.TableLayoutPanel();
            this.btnJogDownZ = new System.Windows.Forms.Button();
            this.btnJogDownY = new System.Windows.Forms.Button();
            this.btnJogLeftX = new System.Windows.Forms.Button();
            this.btnJogRightX = new System.Windows.Forms.Button();
            this.btnJogStop = new System.Windows.Forms.Button();
            this.btnJogUpY = new System.Windows.Forms.Button();
            this.btnJogUpZ = new System.Windows.Forms.Button();
            this.lblJog = new System.Windows.Forms.Label();
            this.tlpJogControl.SuspendLayout();
            this.tlpJog.SuspendLayout();
            this.tlpJogOption.SuspendLayout();
            this.pnlJogSpeedMode.SuspendLayout();
            this.tlpJogSpeedMode.SuspendLayout();
            this.pnlJogMode.SuspendLayout();
            this.tlpJogMode.SuspendLayout();
            this.pnlPitchXY.SuspendLayout();
            this.tlpPitchXY.SuspendLayout();
            this.pnlPitchZ.SuspendLayout();
            this.tlpPitchZ.SuspendLayout();
            this.pnlJogOperation.SuspendLayout();
            this.tlpJogOperation.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpJogControl
            // 
            this.tlpJogControl.ColumnCount = 2;
            this.tlpJogControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpJogControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tlpJogControl.Controls.Add(this.tlpJog, 1, 0);
            this.tlpJogControl.Controls.Add(this.lblJog, 0, 0);
            this.tlpJogControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpJogControl.Location = new System.Drawing.Point(0, 0);
            this.tlpJogControl.Margin = new System.Windows.Forms.Padding(0);
            this.tlpJogControl.Name = "tlpJogControl";
            this.tlpJogControl.RowCount = 1;
            this.tlpJogControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpJogControl.Size = new System.Drawing.Size(626, 386);
            this.tlpJogControl.TabIndex = 0;
            // 
            // tlpJog
            // 
            this.tlpJog.ColumnCount = 1;
            this.tlpJog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpJog.Controls.Add(this.tlpJogOption, 0, 0);
            this.tlpJog.Controls.Add(this.pnlJogOperation, 0, 1);
            this.tlpJog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpJog.Location = new System.Drawing.Point(156, 0);
            this.tlpJog.Margin = new System.Windows.Forms.Padding(0);
            this.tlpJog.Name = "tlpJog";
            this.tlpJog.RowCount = 2;
            this.tlpJog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpJog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpJog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpJog.Size = new System.Drawing.Size(470, 386);
            this.tlpJog.TabIndex = 23;
            // 
            // tlpJogOption
            // 
            this.tlpJogOption.ColumnCount = 2;
            this.tlpJogOption.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpJogOption.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpJogOption.Controls.Add(this.pnlJogSpeedMode, 0, 0);
            this.tlpJogOption.Controls.Add(this.pnlJogMode, 1, 0);
            this.tlpJogOption.Controls.Add(this.pnlPitchXY, 0, 1);
            this.tlpJogOption.Controls.Add(this.pnlPitchZ, 1, 1);
            this.tlpJogOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpJogOption.Location = new System.Drawing.Point(0, 0);
            this.tlpJogOption.Margin = new System.Windows.Forms.Padding(0);
            this.tlpJogOption.Name = "tlpJogOption";
            this.tlpJogOption.RowCount = 2;
            this.tlpJogOption.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpJogOption.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpJogOption.Size = new System.Drawing.Size(470, 154);
            this.tlpJogOption.TabIndex = 20;
            // 
            // pnlJogSpeedMode
            // 
            this.pnlJogSpeedMode.Controls.Add(this.tlpJogSpeedMode);
            this.pnlJogSpeedMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlJogSpeedMode.Location = new System.Drawing.Point(6, 6);
            this.pnlJogSpeedMode.Margin = new System.Windows.Forms.Padding(6);
            this.pnlJogSpeedMode.Name = "pnlJogSpeedMode";
            this.pnlJogSpeedMode.Size = new System.Drawing.Size(223, 65);
            this.pnlJogSpeedMode.TabIndex = 1;
            // 
            // tlpJogSpeedMode
            // 
            this.tlpJogSpeedMode.ColumnCount = 2;
            this.tlpJogSpeedMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpJogSpeedMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpJogSpeedMode.Controls.Add(this.rdoJogFastMode, 0, 0);
            this.tlpJogSpeedMode.Controls.Add(this.rdoJogSlowMode, 0, 0);
            this.tlpJogSpeedMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpJogSpeedMode.Location = new System.Drawing.Point(0, 0);
            this.tlpJogSpeedMode.Margin = new System.Windows.Forms.Padding(0);
            this.tlpJogSpeedMode.Name = "tlpJogSpeedMode";
            this.tlpJogSpeedMode.RowCount = 1;
            this.tlpJogSpeedMode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpJogSpeedMode.Size = new System.Drawing.Size(223, 65);
            this.tlpJogSpeedMode.TabIndex = 0;
            // 
            // rdoJogFastMode
            // 
            this.rdoJogFastMode.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoJogFastMode.BackColor = System.Drawing.Color.White;
            this.rdoJogFastMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoJogFastMode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rdoJogFastMode.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.rdoJogFastMode.ForeColor = System.Drawing.Color.Black;
            this.rdoJogFastMode.Location = new System.Drawing.Point(111, 0);
            this.rdoJogFastMode.Margin = new System.Windows.Forms.Padding(0);
            this.rdoJogFastMode.Name = "rdoJogFastMode";
            this.rdoJogFastMode.Size = new System.Drawing.Size(112, 65);
            this.rdoJogFastMode.TabIndex = 144;
            this.rdoJogFastMode.Tag = "0";
            this.rdoJogFastMode.Text = "FAST";
            this.rdoJogFastMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoJogFastMode.UseVisualStyleBackColor = false;
            this.rdoJogFastMode.CheckedChanged += new System.EventHandler(this.rdoJogFastMode_CheckedChanged);
            // 
            // rdoJogSlowMode
            // 
            this.rdoJogSlowMode.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoJogSlowMode.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.rdoJogSlowMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoJogSlowMode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rdoJogSlowMode.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.rdoJogSlowMode.ForeColor = System.Drawing.Color.Black;
            this.rdoJogSlowMode.Location = new System.Drawing.Point(0, 0);
            this.rdoJogSlowMode.Margin = new System.Windows.Forms.Padding(0);
            this.rdoJogSlowMode.Name = "rdoJogSlowMode";
            this.rdoJogSlowMode.Size = new System.Drawing.Size(111, 65);
            this.rdoJogSlowMode.TabIndex = 143;
            this.rdoJogSlowMode.Tag = "0";
            this.rdoJogSlowMode.Text = "SLOW";
            this.rdoJogSlowMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoJogSlowMode.UseVisualStyleBackColor = false;
            this.rdoJogSlowMode.CheckedChanged += new System.EventHandler(this.rdoJogSlowMode_CheckedChanged);
            // 
            // pnlJogMode
            // 
            this.pnlJogMode.Controls.Add(this.tlpJogMode);
            this.pnlJogMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlJogMode.Location = new System.Drawing.Point(241, 6);
            this.pnlJogMode.Margin = new System.Windows.Forms.Padding(6);
            this.pnlJogMode.Name = "pnlJogMode";
            this.pnlJogMode.Size = new System.Drawing.Size(223, 65);
            this.pnlJogMode.TabIndex = 2;
            // 
            // tlpJogMode
            // 
            this.tlpJogMode.ColumnCount = 2;
            this.tlpJogMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpJogMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpJogMode.Controls.Add(this.rdoIncreaseMode, 0, 0);
            this.tlpJogMode.Controls.Add(this.rdoJogMode, 0, 0);
            this.tlpJogMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpJogMode.Location = new System.Drawing.Point(0, 0);
            this.tlpJogMode.Margin = new System.Windows.Forms.Padding(0);
            this.tlpJogMode.Name = "tlpJogMode";
            this.tlpJogMode.RowCount = 1;
            this.tlpJogMode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpJogMode.Size = new System.Drawing.Size(223, 65);
            this.tlpJogMode.TabIndex = 0;
            // 
            // rdoIncreaseMode
            // 
            this.rdoIncreaseMode.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoIncreaseMode.BackColor = System.Drawing.Color.White;
            this.rdoIncreaseMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoIncreaseMode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rdoIncreaseMode.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.rdoIncreaseMode.ForeColor = System.Drawing.Color.Black;
            this.rdoIncreaseMode.Location = new System.Drawing.Point(111, 0);
            this.rdoIncreaseMode.Margin = new System.Windows.Forms.Padding(0);
            this.rdoIncreaseMode.Name = "rdoIncreaseMode";
            this.rdoIncreaseMode.Size = new System.Drawing.Size(112, 65);
            this.rdoIncreaseMode.TabIndex = 145;
            this.rdoIncreaseMode.Tag = "0";
            this.rdoIncreaseMode.Text = "INC MODE";
            this.rdoIncreaseMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoIncreaseMode.UseVisualStyleBackColor = false;
            this.rdoIncreaseMode.CheckedChanged += new System.EventHandler(this.rdoIncreaseMode_CheckedChanged);
            // 
            // rdoJogMode
            // 
            this.rdoJogMode.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoJogMode.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.rdoJogMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoJogMode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rdoJogMode.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.rdoJogMode.ForeColor = System.Drawing.Color.Black;
            this.rdoJogMode.Location = new System.Drawing.Point(0, 0);
            this.rdoJogMode.Margin = new System.Windows.Forms.Padding(0);
            this.rdoJogMode.Name = "rdoJogMode";
            this.rdoJogMode.Size = new System.Drawing.Size(111, 65);
            this.rdoJogMode.TabIndex = 144;
            this.rdoJogMode.Tag = "0";
            this.rdoJogMode.Text = "JOG MODE";
            this.rdoJogMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoJogMode.UseVisualStyleBackColor = false;
            this.rdoJogMode.CheckedChanged += new System.EventHandler(this.rdoJogMode_CheckedChanged);
            // 
            // pnlPitchXY
            // 
            this.pnlPitchXY.Controls.Add(this.tlpPitchXY);
            this.pnlPitchXY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPitchXY.Location = new System.Drawing.Point(6, 83);
            this.pnlPitchXY.Margin = new System.Windows.Forms.Padding(6);
            this.pnlPitchXY.Name = "pnlPitchXY";
            this.pnlPitchXY.Size = new System.Drawing.Size(223, 65);
            this.pnlPitchXY.TabIndex = 3;
            // 
            // tlpPitchXY
            // 
            this.tlpPitchXY.ColumnCount = 2;
            this.tlpPitchXY.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPitchXY.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPitchXY.Controls.Add(this.lblPitchXY, 0, 0);
            this.tlpPitchXY.Controls.Add(this.lblPitchXYValue, 1, 0);
            this.tlpPitchXY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPitchXY.Location = new System.Drawing.Point(0, 0);
            this.tlpPitchXY.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPitchXY.Name = "tlpPitchXY";
            this.tlpPitchXY.RowCount = 1;
            this.tlpPitchXY.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPitchXY.Size = new System.Drawing.Size(223, 65);
            this.tlpPitchXY.TabIndex = 0;
            // 
            // lblPitchXY
            // 
            this.lblPitchXY.BackColor = System.Drawing.Color.White;
            this.lblPitchXY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPitchXY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPitchXY.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblPitchXY.Location = new System.Drawing.Point(0, 0);
            this.lblPitchXY.Margin = new System.Windows.Forms.Padding(0);
            this.lblPitchXY.Name = "lblPitchXY";
            this.lblPitchXY.Size = new System.Drawing.Size(111, 65);
            this.lblPitchXY.TabIndex = 4;
            this.lblPitchXY.Text = "PITCH XY";
            this.lblPitchXY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPitchXYValue
            // 
            this.lblPitchXYValue.BackColor = System.Drawing.Color.White;
            this.lblPitchXYValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPitchXYValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPitchXYValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblPitchXYValue.Location = new System.Drawing.Point(111, 0);
            this.lblPitchXYValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblPitchXYValue.Name = "lblPitchXYValue";
            this.lblPitchXYValue.Size = new System.Drawing.Size(112, 65);
            this.lblPitchXYValue.TabIndex = 2;
            this.lblPitchXYValue.Text = "1.0";
            this.lblPitchXYValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPitchXYValue.Click += new System.EventHandler(this.lblPitchXYValue_Click);
            // 
            // pnlPitchZ
            // 
            this.pnlPitchZ.Controls.Add(this.tlpPitchZ);
            this.pnlPitchZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPitchZ.Location = new System.Drawing.Point(241, 83);
            this.pnlPitchZ.Margin = new System.Windows.Forms.Padding(6);
            this.pnlPitchZ.Name = "pnlPitchZ";
            this.pnlPitchZ.Size = new System.Drawing.Size(223, 65);
            this.pnlPitchZ.TabIndex = 4;
            // 
            // tlpPitchZ
            // 
            this.tlpPitchZ.ColumnCount = 2;
            this.tlpPitchZ.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPitchZ.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPitchZ.Controls.Add(this.lblPitchZ, 0, 0);
            this.tlpPitchZ.Controls.Add(this.lblPitchZValue, 1, 0);
            this.tlpPitchZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPitchZ.Location = new System.Drawing.Point(0, 0);
            this.tlpPitchZ.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPitchZ.Name = "tlpPitchZ";
            this.tlpPitchZ.RowCount = 1;
            this.tlpPitchZ.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPitchZ.Size = new System.Drawing.Size(223, 65);
            this.tlpPitchZ.TabIndex = 0;
            // 
            // lblPitchZ
            // 
            this.lblPitchZ.BackColor = System.Drawing.Color.White;
            this.lblPitchZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPitchZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPitchZ.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblPitchZ.Location = new System.Drawing.Point(0, 0);
            this.lblPitchZ.Margin = new System.Windows.Forms.Padding(0);
            this.lblPitchZ.Name = "lblPitchZ";
            this.lblPitchZ.Size = new System.Drawing.Size(111, 65);
            this.lblPitchZ.TabIndex = 4;
            this.lblPitchZ.Text = "PITCH Z";
            this.lblPitchZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPitchZValue
            // 
            this.lblPitchZValue.BackColor = System.Drawing.Color.White;
            this.lblPitchZValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPitchZValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPitchZValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblPitchZValue.Location = new System.Drawing.Point(111, 0);
            this.lblPitchZValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblPitchZValue.Name = "lblPitchZValue";
            this.lblPitchZValue.Size = new System.Drawing.Size(112, 65);
            this.lblPitchZValue.TabIndex = 2;
            this.lblPitchZValue.Text = "0.1";
            this.lblPitchZValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPitchZValue.Click += new System.EventHandler(this.lblPitchZValue_Click);
            // 
            // pnlJogOperation
            // 
            this.pnlJogOperation.Controls.Add(this.tlpJogOperation);
            this.pnlJogOperation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlJogOperation.Location = new System.Drawing.Point(6, 160);
            this.pnlJogOperation.Margin = new System.Windows.Forms.Padding(6);
            this.pnlJogOperation.Name = "pnlJogOperation";
            this.pnlJogOperation.Size = new System.Drawing.Size(458, 220);
            this.pnlJogOperation.TabIndex = 151;
            // 
            // tlpJogOperation
            // 
            this.tlpJogOperation.ColumnCount = 5;
            this.tlpJogOperation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpJogOperation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpJogOperation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpJogOperation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpJogOperation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpJogOperation.Controls.Add(this.btnJogDownZ, 4, 2);
            this.tlpJogOperation.Controls.Add(this.btnJogDownY, 1, 2);
            this.tlpJogOperation.Controls.Add(this.btnJogLeftX, 0, 1);
            this.tlpJogOperation.Controls.Add(this.btnJogRightX, 2, 1);
            this.tlpJogOperation.Controls.Add(this.btnJogStop, 1, 1);
            this.tlpJogOperation.Controls.Add(this.btnJogUpY, 1, 0);
            this.tlpJogOperation.Controls.Add(this.btnJogUpZ, 4, 0);
            this.tlpJogOperation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpJogOperation.Location = new System.Drawing.Point(0, 0);
            this.tlpJogOperation.Margin = new System.Windows.Forms.Padding(0);
            this.tlpJogOperation.Name = "tlpJogOperation";
            this.tlpJogOperation.RowCount = 3;
            this.tlpJogOperation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpJogOperation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpJogOperation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpJogOperation.Size = new System.Drawing.Size(458, 220);
            this.tlpJogOperation.TabIndex = 19;
            // 
            // btnJogDownZ
            // 
            this.btnJogDownZ.BackColor = System.Drawing.Color.White;
            this.btnJogDownZ.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnJogDownZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnJogDownZ.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.btnJogDownZ.Image = global::Jastech.Framework.Winform.Properties.Resources.Arrow_down;
            this.btnJogDownZ.Location = new System.Drawing.Point(347, 146);
            this.btnJogDownZ.Margin = new System.Windows.Forms.Padding(0);
            this.btnJogDownZ.Name = "btnJogDownZ";
            this.btnJogDownZ.Size = new System.Drawing.Size(111, 74);
            this.btnJogDownZ.TabIndex = 8;
            this.btnJogDownZ.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnJogDownZ.UseVisualStyleBackColor = false;
            // 
            // btnJogDownY
            // 
            this.btnJogDownY.BackColor = System.Drawing.Color.White;
            this.btnJogDownY.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnJogDownY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnJogDownY.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.btnJogDownY.Image = global::Jastech.Framework.Winform.Properties.Resources.Arrow_down;
            this.btnJogDownY.Location = new System.Drawing.Point(109, 146);
            this.btnJogDownY.Margin = new System.Windows.Forms.Padding(0);
            this.btnJogDownY.Name = "btnJogDownY";
            this.btnJogDownY.Size = new System.Drawing.Size(109, 74);
            this.btnJogDownY.TabIndex = 6;
            this.btnJogDownY.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnJogDownY.UseVisualStyleBackColor = false;
            this.btnJogDownY.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogDownY_MouseDown);
            this.btnJogDownY.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogDownY_MouseUp);
            // 
            // btnJogLeftX
            // 
            this.btnJogLeftX.BackColor = System.Drawing.Color.White;
            this.btnJogLeftX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnJogLeftX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnJogLeftX.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.btnJogLeftX.Image = global::Jastech.Framework.Winform.Properties.Resources.Arrow_left;
            this.btnJogLeftX.Location = new System.Drawing.Point(0, 73);
            this.btnJogLeftX.Margin = new System.Windows.Forms.Padding(0);
            this.btnJogLeftX.Name = "btnJogLeftX";
            this.btnJogLeftX.Size = new System.Drawing.Size(109, 73);
            this.btnJogLeftX.TabIndex = 1;
            this.btnJogLeftX.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnJogLeftX.UseVisualStyleBackColor = false;
            this.btnJogLeftX.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogLeftX_MouseDown);
            this.btnJogLeftX.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogLeftX_MouseUp);
            // 
            // btnJogRightX
            // 
            this.btnJogRightX.BackColor = System.Drawing.Color.White;
            this.btnJogRightX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnJogRightX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnJogRightX.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.btnJogRightX.Image = global::Jastech.Framework.Winform.Properties.Resources.Arrow_right;
            this.btnJogRightX.Location = new System.Drawing.Point(218, 73);
            this.btnJogRightX.Margin = new System.Windows.Forms.Padding(0);
            this.btnJogRightX.Name = "btnJogRightX";
            this.btnJogRightX.Size = new System.Drawing.Size(109, 73);
            this.btnJogRightX.TabIndex = 2;
            this.btnJogRightX.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnJogRightX.UseVisualStyleBackColor = false;
            this.btnJogRightX.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogRightX_MouseDown);
            this.btnJogRightX.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogRightX_MouseUp);
            // 
            // btnJogStop
            // 
            this.btnJogStop.BackColor = System.Drawing.Color.White;
            this.btnJogStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnJogStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnJogStop.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.btnJogStop.Image = global::Jastech.Framework.Winform.Properties.Resources.Stop_circle;
            this.btnJogStop.Location = new System.Drawing.Point(109, 73);
            this.btnJogStop.Margin = new System.Windows.Forms.Padding(0);
            this.btnJogStop.Name = "btnJogStop";
            this.btnJogStop.Size = new System.Drawing.Size(109, 73);
            this.btnJogStop.TabIndex = 4;
            this.btnJogStop.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnJogStop.UseVisualStyleBackColor = false;
            // 
            // btnJogUpY
            // 
            this.btnJogUpY.BackColor = System.Drawing.Color.White;
            this.btnJogUpY.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnJogUpY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnJogUpY.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.btnJogUpY.Image = global::Jastech.Framework.Winform.Properties.Resources.Arrow_up;
            this.btnJogUpY.Location = new System.Drawing.Point(109, 0);
            this.btnJogUpY.Margin = new System.Windows.Forms.Padding(0);
            this.btnJogUpY.Name = "btnJogUpY";
            this.btnJogUpY.Size = new System.Drawing.Size(109, 73);
            this.btnJogUpY.TabIndex = 5;
            this.btnJogUpY.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnJogUpY.UseVisualStyleBackColor = false;
            this.btnJogUpY.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogUpY_MouseDown);
            this.btnJogUpY.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogUpY_MouseUp);
            // 
            // btnJogUpZ
            // 
            this.btnJogUpZ.BackColor = System.Drawing.Color.White;
            this.btnJogUpZ.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnJogUpZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnJogUpZ.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.btnJogUpZ.Image = global::Jastech.Framework.Winform.Properties.Resources.Arrow_up;
            this.btnJogUpZ.Location = new System.Drawing.Point(347, 0);
            this.btnJogUpZ.Margin = new System.Windows.Forms.Padding(0);
            this.btnJogUpZ.Name = "btnJogUpZ";
            this.btnJogUpZ.Size = new System.Drawing.Size(111, 73);
            this.btnJogUpZ.TabIndex = 7;
            this.btnJogUpZ.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnJogUpZ.UseVisualStyleBackColor = false;
            // 
            // lblJog
            // 
            this.lblJog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblJog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblJog.Location = new System.Drawing.Point(0, 0);
            this.lblJog.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.lblJog.Name = "lblJog";
            this.lblJog.Size = new System.Drawing.Size(152, 386);
            this.lblJog.TabIndex = 0;
            this.lblJog.Text = "Jog";
            this.lblJog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MotionJogControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tlpJogControl);
            this.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.Name = "MotionJogControl";
            this.Size = new System.Drawing.Size(626, 386);
            this.Load += new System.EventHandler(this.MotionJogControl_Load);
            this.tlpJogControl.ResumeLayout(false);
            this.tlpJog.ResumeLayout(false);
            this.tlpJogOption.ResumeLayout(false);
            this.pnlJogSpeedMode.ResumeLayout(false);
            this.tlpJogSpeedMode.ResumeLayout(false);
            this.pnlJogMode.ResumeLayout(false);
            this.tlpJogMode.ResumeLayout(false);
            this.pnlPitchXY.ResumeLayout(false);
            this.tlpPitchXY.ResumeLayout(false);
            this.pnlPitchZ.ResumeLayout(false);
            this.tlpPitchZ.ResumeLayout(false);
            this.pnlJogOperation.ResumeLayout(false);
            this.tlpJogOperation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpJogControl;
        private System.Windows.Forms.TableLayoutPanel tlpJog;
        private System.Windows.Forms.TableLayoutPanel tlpJogOption;
        private System.Windows.Forms.Panel pnlJogSpeedMode;
        private System.Windows.Forms.TableLayoutPanel tlpJogSpeedMode;
        private System.Windows.Forms.RadioButton rdoJogFastMode;
        private System.Windows.Forms.RadioButton rdoJogSlowMode;
        private System.Windows.Forms.Panel pnlJogMode;
        private System.Windows.Forms.TableLayoutPanel tlpJogMode;
        private System.Windows.Forms.RadioButton rdoIncreaseMode;
        private System.Windows.Forms.RadioButton rdoJogMode;
        private System.Windows.Forms.Panel pnlPitchXY;
        private System.Windows.Forms.TableLayoutPanel tlpPitchXY;
        private System.Windows.Forms.Label lblPitchXY;
        private System.Windows.Forms.Label lblPitchXYValue;
        private System.Windows.Forms.Panel pnlPitchZ;
        private System.Windows.Forms.TableLayoutPanel tlpPitchZ;
        private System.Windows.Forms.Label lblPitchZ;
        private System.Windows.Forms.Label lblPitchZValue;
        private System.Windows.Forms.Panel pnlJogOperation;
        private System.Windows.Forms.TableLayoutPanel tlpJogOperation;
        private System.Windows.Forms.Button btnJogDownZ;
        private System.Windows.Forms.Button btnJogDownY;
        private System.Windows.Forms.Button btnJogLeftX;
        private System.Windows.Forms.Button btnJogRightX;
        private System.Windows.Forms.Button btnJogStop;
        private System.Windows.Forms.Button btnJogUpY;
        private System.Windows.Forms.Button btnJogUpZ;
        private System.Windows.Forms.Label lblJog;
    }
}
