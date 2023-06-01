using Jastech.Framework.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.Forms
{
    public partial class LoginForm : Form
    {
        public User CurrentUser { get; set; }

        public UserHanlder UserHandler { get; set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if(CurrentUser != null)
            {
                UpdateUI(CurrentUser.Type);
            }
        }

        private void UpdateUI(AuthorityType type)
        {
            lblOperator.ForeColor = Color.White;
            lblEngineer.ForeColor = Color.White;
            lblMaker.ForeColor = Color.White;

            if (type == AuthorityType.None)
            {
                lblOperator.ForeColor = Color.Blue;
                txtPasword.Enabled = false;
            }
            else if(type == AuthorityType.Engineer)
            {
                lblEngineer.ForeColor = Color.Blue;
                txtPasword.Enabled = true;
            }
            else if(type == AuthorityType.Maker)
            {
                lblMaker.ForeColor = Color.Blue;
                txtPasword.Enabled = true;
            }
        }

        private void txtPasword_Click(object sender, EventArgs e)
        {
            KeyBoardForm form = new KeyBoardForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                var textBox = (TextBox)sender;
                textBox.Text = form.KeyValue;
            }
        }

        private void lblOperator_Click(object sender, EventArgs e)
        {
            UpdateUI(AuthorityType.None);
        }

        private void lblEngineer_Click(object sender, EventArgs e)
        {
            UpdateUI(AuthorityType.Engineer);
        }

        private void lblMaker_Click(object sender, EventArgs e)
        {
            UpdateUI(AuthorityType.Maker);
        }

        private void lblApply_Click(object sender, EventArgs e)
        {
            var curType = GetSelectedUserType();
            if (curType != AuthorityType.None)
            {
                string password = txtPasword.Text;
                if(CheckPassword(curType, password))
                {
                    CurrentUser = UserHandler.GetUser(curType);
                }
                else
                {
                    MessageConfirmForm form1 = new MessageConfirmForm();
                    form1.Message = "Passwords do not match.";
                    form1.ShowDialog();
                    return;
                }
            }
            MessageConfirmForm form2 = new MessageConfirmForm();
            form2.Message = "Chaged User.";
            form2.ShowDialog();
        }

        private bool CheckPassword(AuthorityType type , string password)
        {
            if(UserHandler != null)
            {
                var user = UserHandler.GetUser(type);
                if (user.Password == password)
                    return true;
                else
                    return false;
            }
            return false;
        }

        private AuthorityType GetSelectedUserType()
        {
            if (lblOperator.ForeColor == Color.Blue)
                return AuthorityType.None;
            if (lblEngineer.ForeColor == Color.Blue)
                return AuthorityType.Engineer;
            if (lblMaker.ForeColor == Color.Blue)
                return AuthorityType.Maker;

            return AuthorityType.None;
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void lblCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }
    }
}
