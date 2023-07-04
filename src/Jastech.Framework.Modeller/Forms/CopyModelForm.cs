﻿using Jastech.Framework.Structure.Helper;
using Jastech.Framework.Winform.Forms;
using System;
using System.Windows.Forms;
using static Jastech.Framework.Modeller.Controls.ModelControl;

namespace Jastech.Framework.Modeller.Forms
{
    public partial class CopyModelForm : Form
    {
        #region 필드
        #endregion

        #region 속성
        public string PrevModelName { get; set; }

        public string ModelPath { get; set; }
        #endregion

        #region 이벤트
        public event CopyModelDelegate CopyModelEvent;
        #endregion

        public CopyModelForm()
        {
            InitializeComponent();
        }

        private void CopyModelForm_Load(object sender, EventArgs e)
        {
            txtModelName.Text = PrevModelName;
        }

        private void lblOK_Click(object sender, EventArgs e)
        {
            if (PrevModelName != txtModelName.Text)
            {
                if (ModelFileHelper.IsExistModel(ModelPath, txtModelName.Text))
                {
                    MessageConfirmForm form = new MessageConfirmForm();
                    form.Message = "The same model exists.";
                    form.ShowDialog();
                    return;
                }

                DialogResult = DialogResult.OK;
                Close();
                CopyModelEvent?.Invoke(PrevModelName, txtModelName.Text);
            }
        }

        private void lblCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
