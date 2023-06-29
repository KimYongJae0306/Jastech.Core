﻿using System;
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
    public partial class KeyPadForm : Form
    {
        #region 필드
        #endregion

        #region 속성
        public double PadValue { get; set; }

        public double PreviousValue { get; set; }
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
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

            if (lblTextMessage.Text == "")
            {
                //if (button.Text == "0" || button.Text == ".")
                //    return;
            }
            lblTextMessage.Text += button.Text;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            string message = lblTextMessage.Text;
            if (message == "")
                return;

            lblTextMessage.Text = "-" + message;
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            string message = lblTextMessage.Text;
            if (message == "")
                return;
            lblTextMessage.Text = message.Substring(0, message.Length - 1);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblTextMessage.Text = "";
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (lblTextMessage.Text == "")
                lblTextMessage.Text = "0";

            PadValue = Convert.ToDouble(lblTextMessage.Text);

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
        #endregion
    }
}
