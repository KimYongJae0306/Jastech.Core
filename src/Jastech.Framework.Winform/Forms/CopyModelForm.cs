using Jastech.Framework.Structure;
using Jastech.Framework.Structure.Helper;
using Jastech.Framework.Structure.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Jastech.Framework.Winform.Controls.ModelControl;

namespace Jastech.Framework.Winform.Forms
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
                if (InspModelFileService.IsExistModel(ModelPath, txtModelName.Text))
                {
                    MessageConfirmForm form = new MessageConfirmForm();
                    form.Message = "동일한 모델이 존재 합니다.";
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
