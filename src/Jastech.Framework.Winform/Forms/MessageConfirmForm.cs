using System;
using System.Drawing;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.Forms
{
    public partial class MessageConfirmForm : Form
    {
        #region 필드
        private Point _mousePoint;
        #endregion

        #region 속성
        public string Message { get; set; } = "";
        #endregion

        public MessageConfirmForm()
        {
            InitializeComponent();
        }

        private void WarningMessageForm_Load(object sender, EventArgs e)
        {
            UpdateData();
            Focus();
        }

        private void lblConfirm_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        public delegate void UpdateDataDele();
        private void UpdateData()
        {
            if (this.InvokeRequired)
            {
                UpdateDataDele callBack = UpdateData;
                BeginInvoke(callBack);
                return;
            }

            lblMessage.Text = Message;
        }

        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            _mousePoint = new Point(e.X, e.Y);
        }

        private void pnlTop_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Location = new Point(this.Left - (_mousePoint.X - e.X), this.Top - (_mousePoint.Y - e.Y));
            }
        }
    }
}
