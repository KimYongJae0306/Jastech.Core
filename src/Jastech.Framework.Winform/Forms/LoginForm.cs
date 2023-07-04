using Jastech.Framework.Users;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.Forms
{
    public partial class LoginForm : Form
    {
        #region 속성
        public User CurrentUser { get; set; }

        public UserHanlder UserHandler { get; set; }
        #endregion

        #region 이벤트
        public event StopProgramDelegate StopProgramEvent;
        #endregion

        #region 델리게이트
        public delegate void StopProgramDelegate();
        #endregion

        #region 생성자
        public LoginForm()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (CurrentUser != null)
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
            else if (type == AuthorityType.Engineer)
            {
                lblEngineer.ForeColor = Color.Blue;
                txtPasword.Enabled = true;
            }
            else if (type == AuthorityType.Maker)
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
                if (CheckPassword(curType, password))
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
            else
            {
                CurrentUser = UserHandler.GetUser(AuthorityType.None);
            }
            MessageConfirmForm form2 = new MessageConfirmForm();
            form2.Message = "Chaged User.";
            form2.ShowDialog();

            this.Close();
        }

        private bool CheckPassword(AuthorityType type, string password)
        {
            if (UserHandler != null)
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

        private void pbxExit_Click(object sender, EventArgs e)
        {
            MessageYesNoForm form = new MessageYesNoForm();
            form.Message = "Do you want to Program Exit?";

            if (form.ShowDialog() == DialogResult.Yes)
            {
                StopProgramEvent?.Invoke();
            }
        }
        #endregion
    }
}
