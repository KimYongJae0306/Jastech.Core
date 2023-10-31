using System;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.Forms
{
    public partial class KeyPadForm : Form
    {
        #region 속성
        public double PadValue { get; set; }

        public double PreviousValue { get; set; }
        #endregion

        #region 생성자
        public KeyPadForm()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void btnNumber_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            lblTextMessage.Text += button.Text;
            btnEnter.Focus();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            string message = lblTextMessage.Text;
            if (message == "")
                return;

            lblTextMessage.Text = "-" + message;

            btnEnter.Focus();
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            string message = lblTextMessage.Text;
            if (message == "")
                return;
            lblTextMessage.Text = message.Substring(0, message.Length - 1);

            btnEnter.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblTextMessage.Text = "";

            btnEnter.Focus();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (lblTextMessage.Text == "")
                lblTextMessage.Text = "0";

            if (double.TryParse(lblTextMessage.Text, out double value) == false)
            {
                MessageConfirmForm confirmForm = new MessageConfirmForm();
                confirmForm.Message = "Please check input data format.";
                confirmForm.ShowDialog();
                return;
            }
            else
                PadValue = value;

            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCanel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want cancel?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                PadValue = PreviousValue;
                this.DialogResult = DialogResult.No;
                Close();
            }
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            lblTextMessage.Text += btnDot.Text;
        }
        
        private void KeyPadForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            string message = lblTextMessage.Text;
            btnEnter.Focus();

            if (e.KeyChar == Convert.ToChar(Keys.Back))
            {
                if (message == "")
                    return;

                lblTextMessage.Text = message.Substring(0, message.Length - 1);
                return;
            }

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                PadValue = Convert.ToDouble(lblTextMessage.Text);

                this.DialogResult = DialogResult.OK;
                Close();
            }

            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                if (MessageBox.Show("Do you want cancel?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    PadValue = PreviousValue;
                    this.DialogResult = DialogResult.No;
                    Close();
                }
            }

            if (char.IsDigit(e.KeyChar) || e.KeyChar == '.')
            {
                lblTextMessage.Text += e.KeyChar.ToString();
            }

            if (e.KeyChar == '-')
            {
                if (message.Contains("-") == false)
                    lblTextMessage.Text = message.Insert(0, e.KeyChar.ToString());
                else
                    lblTextMessage.Text = message.Remove(0, 1);
            }
        }
        #endregion
    }
}
