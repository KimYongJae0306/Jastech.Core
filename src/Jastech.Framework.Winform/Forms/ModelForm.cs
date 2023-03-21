using Jastech.Framework.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.Forms
{
    public partial class ModelForm : Form
    {
        private InspModelFileService InspModelFileService { get; set; } = new InspModelFileService();

        public string ModelPath { get; set; } = "";

        public ModelForm()
        {
            InitializeComponent();
        }

        private void ModelForm_Load(object sender, EventArgs e)
        {
            UpdateModelList();
        }

        private void UpdateModelList()
        {
            if (ModelPath == "")
                return;

            List<InspModel> models = InspModelFileService.GetModelList(ModelPath);

            gvModelList.Rows.Clear();

            foreach (var model in models)
            {
                string createDate = model.CreateDate.ToString("yyyy-MM-dd HH:mm:dd");
                string modifiedDate = model.ModifiedDate.ToString("yyyy-MM-dd HH:mm:dd");

                gvModelList.Rows.Add(model.Name, createDate, modifiedDate, model.Description);
            }
            ClearSelected();
        }

        private void lblCreateModel_Click(object sender, EventArgs e)
        {
            CreateModelForm form = new CreateModelForm();

            form.ModelPath = ModelPath;
            form.IsExistModelHandler = IsExistModel;
            form.CreateModelHandler = CreateModel;
            form.ShowDialog();
        }

        private void CreateModel(InspModel inspModel)
        {
            if (ModelPath == "")
                return;

            string folderPath = Path.Combine(ModelPath, inspModel.Name);

            if (Directory.Exists(folderPath) == false)
                Directory.CreateDirectory(folderPath);

            InspModelFileService.Save(ModelPath, inspModel);

            UpdateModelList();
        }

        private bool IsExistModel(string name)
        {
            if (ModelPath == "")
                return false;

            return InspModelFileService.IsExistModel(ModelPath, name);
        }

        private void lblEditModel_Click(object sender, EventArgs e)
        {
            if (ModelPath == "" || gvModelList.SelectedRows.Count <= 0)
                return;

            EditModelForm form = new EditModelForm();
            form.PrevModelName = lblSelectedName.Text;
            form.PrevDescription = lblSelectedDescription.Text;
            form.ModelPath = ModelPath;
            form.IsExistModelHandler = IsExistModel;
            form.EditModelHandler = EditModel;

            if (form.ShowDialog() == DialogResult.OK)
            {
                UpdateModelList();
            }
        }

        private void EditModel(string newModelName, string newDescription)
        {
            if (ModelPath == "")
                return;

            InspModelFileService.Edit(ModelPath, lblSelectedName.Text, newModelName, newDescription);
        }

        private void gvModelList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0)
                return;

            UpdateSelectedModel(e.RowIndex);
        }

        private void UpdateSelectedModel(int selectIndex)
        {
            if (ModelPath == "")
                return;

            lblSelectedName.Text = gvModelList.Rows[selectIndex].Cells[0].Value.ToString();
            lblSelectedCreateDate.Text = gvModelList.Rows[selectIndex].Cells[1].Value.ToString();
            lblSelectedModifiedDate.Text = gvModelList.Rows[selectIndex].Cells[2].Value.ToString();
            lblSelectedDescription.Text = gvModelList.Rows[selectIndex].Cells[3].Value.ToString();
        }

        private void ClearSelected()
        {
            gvModelList.ClearSelection();

            lblSelectedName.Text = "";
            lblSelectedCreateDate.Text = "";
            lblSelectedModifiedDate.Text = "";
            lblSelectedDescription.Text = "";
        }

        private void lblDeleteModel_Click(object sender, EventArgs e)
        {
            if (ModelPath == "" || gvModelList.SelectedRows.Count <= 0)
                return;

            MessageYesNoForm form = new MessageYesNoForm();
            form.Message = "선택된 모델을 삭제하시겠습니까?";

            if(form.ShowDialog() == DialogResult.Yes)
            {
                InspModelFileService.Delete(ModelPath, lblSelectedName.Text);
                UpdateModelList();
            }

        }

        private void lblCopyModel_Click(object sender, EventArgs e)
        {
            if (ModelPath == "" || gvModelList.SelectedRows.Count <= 0)
                return;

            CopyModelForm form = new CopyModelForm();
            form.PrevModelName = lblSelectedName.Text;
            form.IsExistModelHandler = IsExistModel;
            form.CopyModelHandler = CopyModel;

            if (form.ShowDialog() == DialogResult.OK)
            {
                UpdateModelList();
            }
        }

        private void CopyModel(string newModelName)
        {
            InspModelFileService.Copy(ModelPath, lblSelectedName.Text, newModelName);
        }
    }
}
