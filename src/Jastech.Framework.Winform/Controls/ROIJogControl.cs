using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jastech.Framework.Winform.Forms;

namespace Jastech.Framework.Winform.Controls
{
    public partial class ROIJogControl : Form
    {
        #region 필드
        private Color _selectedColor = new Color();
        private Color _nonSelectedColor = new Color();
        public int JogScale { get; private set; } = 1;
        #endregion

        #region 속성

        #endregion

        #region 이벤트
        public event SendClickEventDelegate SendEventHandler;
        #endregion

        #region 델리게이트
        public delegate void SendClickEventDelegate(string jogType, int JogScale);
        #endregion

        #region 생성자
        public ROIJogControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void ROIJogControl_Load(object sender, EventArgs e)
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.Location = new Point(1100, 360);
            _selectedColor = Color.FromArgb(104, 104, 104);
            _nonSelectedColor = Color.FromArgb(52, 52, 52);
            ShowMoveCommandPanel();
        }

        private int SetLabelIntegerData(object sender)
        {
            Label lbl = sender as Label;
            int prevData = Convert.ToInt32(lbl.Text);

            KeyPadForm keyPadForm = new KeyPadForm();
            keyPadForm.PreviousValue = (double)prevData;
            keyPadForm.ShowDialog();

            int inputData = Convert.ToInt16(keyPadForm.PadValue);

            Label label = (Label)sender;
            label.Text = inputData.ToString();

            return inputData;
        }

        private void ShowMoveCommandPanel()
        {
            lblMoveMode.BackColor = _selectedColor;
            lblSizeMode.BackColor = _nonSelectedColor;

            pnlMoveMode.Visible = true;
            pnlSizeMode.Visible = false;

            pnlSkew.Enabled = true;
        }

        private void ShowSizeCommandPanel()
        {
            lblMoveMode.BackColor = _nonSelectedColor;
            lblSizeMode.BackColor = _selectedColor;

            pnlMoveMode.Visible = false;
            pnlSizeMode.Visible = true;

            pnlSkew.Enabled = false;
        }

        private void lblMoveMode_Click(object sender, EventArgs e)
        {
            ShowMoveCommandPanel();
        }

        private void lblSizeMode_Click(object sender, EventArgs e)
        {
            ShowSizeCommandPanel();
        }

        private void lblJogScale_Click(object sender, EventArgs e)
        {
            JogScale = SetLabelIntegerData(sender);
        }
        #endregion





        private void lblSkewCCW_Click(object sender, EventArgs e)
        {
            SendEventHandler("SkewCCW", JogScale);
        }

        private void lblSkewZero_Click(object sender, EventArgs e)
        {
            SendEventHandler("SkewZero", JogScale);
        }

        private void lblSkewCW_Click(object sender, EventArgs e)
        {
            SendEventHandler("SkewCW", JogScale);
        }

        private void lblMoveLeft_Click(object sender, EventArgs e)
        {
            SendEventHandler("MoveLeft", JogScale);
        }

        private void lblMoveRight_Click(object sender, EventArgs e)
        {
            SendEventHandler("MoveRight", JogScale);
        }

        private void lblMoveDown_Click(object sender, EventArgs e)
        {
            SendEventHandler("MoveDown", JogScale);
        }

        private void lblMoveUp_Click(object sender, EventArgs e)
        {
            SendEventHandler("MoveUp", JogScale);
        }

        private void lblZoomOutHorizontal_Click(object sender, EventArgs e)
        {
            SendEventHandler("ZoomOutHorizontal", JogScale);
        }

        private void lblZoomInHorizontal_Click(object sender, EventArgs e)
        {
            SendEventHandler("ZoomInHorizontal", JogScale);
        }

        private void lblZoomOutVertical_Click(object sender, EventArgs e)
        {
            SendEventHandler("ZoomOutVertical", JogScale);
        }

        private void lblZoomInVertical_Click(object sender, EventArgs e)
        {
            SendEventHandler("ZoomInVertical", JogScale);
        }
    }
}
