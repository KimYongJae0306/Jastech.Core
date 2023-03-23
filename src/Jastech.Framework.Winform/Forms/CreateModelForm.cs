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
    public partial class CreateModelForm : Form
    {
        #region 필드
        InspModelFileService _inspModelFileService = new InspModelFileService();
        #endregion

        #region 속성
        public string ModelPath { get; set; } = "";
        #endregion

        #region 생성자
        #endregion

        #region 메서드
        #endregion

        public CreateModelForm()
        {
            InitializeComponent();
        }

        private void lblOK_Click(object sender, EventArgs e)
        {
            string modelName = txtModelName.Text;
            string description = txtModelDescription.Text;
            DateTime time = DateTime.Now;

            if(modelName == "")
            {
                ShowMessageBox("모델 이름을 입력해 주시기 바랍니다.");
                return;
            }
           
            if (_inspModelFileService.IsExistModel(ModelPath, modelName))
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

            _inspModelFileService.CreateModel(ModelPath, model);
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
    }
}
