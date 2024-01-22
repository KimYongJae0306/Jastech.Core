using Jastech.Framework.Config;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.Forms
{
    public partial class MessageYesNoForm : Form
    {
        #region 필드
        private Point _mousePoint;
        #endregion

        #region 속성
        public string Message { get; set; } = "";
        #endregion

        #region 델리게이트
        public delegate void UpdateDataDele();
        #endregion

        #region 생성자
        public MessageYesNoForm()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void MessageYesNoForm_Load(object sender, EventArgs e)
        {
            UpdateData();
            Focus();
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

        private void lblConfirm_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void lblNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Keys key = keyData & ~(Keys.Shift | Keys.Control);

            switch (key)
            {
                case Keys.Enter:
                case Keys.Space:
                    if ((keyData) != 0)
                    {
                        DialogResult = DialogResult.Yes;
                        Close();
                        return true;
                    }
                    break;

                case Keys.Escape:
                    if ((keyData) != 0)
                    {
                        DialogResult = DialogResult.No;
                        Close();
                        return true;
                    }
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
    }
}
