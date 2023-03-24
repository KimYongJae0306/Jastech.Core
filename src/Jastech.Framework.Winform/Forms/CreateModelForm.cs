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
    public partial class CreateModelForm : Form
    {
        #region 필드
        #endregion

        #region 속성
        public string ModelPath { get; set; } = "";
        #endregion

        #region 이벤트
        public event ModelDelegate CreateModelEvent;
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        public CreateModelForm()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드

        private void lblOK_Click(object sender, EventArgs e)
        {
            string modelName = txtModelName.Text;
            string description = txtModelDescription.Text;
            DateTime time = DateTime.Now;

            if (modelName == "")
            {
                ShowMessageBox("모델 이름을 입력해 주시기 바랍니다.");
                return;
            }

            if (ModelFileHelper.IsExistModel(ModelPath, modelName))
            {
                ShowMessageBox("동일한 이름의 모델이 존재합니다.");
                return;
            }

            InspModel model = new InspModel
            {
                Name = modelName,
                Description = description,
                CreateDate = time,
                ModifiedDate = time,
            };

            DialogResult = DialogResult.OK;
            Close();

            CreateModelEvent?.Invoke(model);
        }

        private void lblCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ShowMessageBox(string message)
        {
            MessageConfirmForm form = new MessageConfirmForm();
            form.Message = message;
            form.ShowDialog();
        }
        #endregion
    }
}
