using Jastech.Framework.Structure;
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
    public partial class EditModelForm : Form
    {
        #region 속성
        public string PrevModelName { get; set; }

        public string ModelPath { get; set; }

        public string PrevDescription { get; set; }
        #endregion

        #region 이벤트
        public EditModelEventHandler EditModelHandler;

        public IsExistModelEventHandler IsExistModelHandler;
        #endregion

        #region 델리게이트
        public delegate void EditModelEventHandler(string modelName, string description);

        public delegate bool IsExistModelEventHandler(string modelName);
        #endregion

        #region 생성자
        public EditModelForm()
        {
            InitializeComponent();
        }

        private void EditModelForm_Load(object sender, EventArgs e)
        {
            txtModelName.Text = PrevModelName;
            txtDescription.Text = PrevDescription;
        }
        #endregion

        #region 메서드
        private void lblOK_Click(object sender, EventArgs e)
        {
            if (IsExistModelHandler != null)
            {
                if (PrevModelName != txtModelName.Text)
                {
                    if (IsExistModelHandler.Invoke(txtModelName.Text))
                    {
                        MessageConfirmForm form = new MessageConfirmForm();
                        form.Message = "동일한 모델이 존재 합니다.";
                        form.ShowDialog();
                        return;
                    }
                }
            }

            EditModelHandler?.Invoke(txtModelName.Text, txtDescription.Text);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void lblCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion
    }
}
