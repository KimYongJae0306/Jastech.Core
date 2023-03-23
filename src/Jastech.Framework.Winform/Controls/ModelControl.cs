using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jastech.Framework.Structure;
using Jastech.Framework.Winform.Forms;

namespace Jastech.Framework.Winform.Controls
{
    public partial class ModelControl : UserControl
    {
        private InspModelFileService InspModelFileService { get; set; } = new InspModelFileService();
        public string ModelPath { get; set; } = "";
        public ModelControl()
        {
            InitializeComponent();
        }

        private void ModelControl_Load(object sender, EventArgs e)
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

        private void ClearSelected()
        {
            gvModelList.ClearSelection();

            lblSelectedName.Text = "";
            lblSelectedCreateDate.Text = "";
            lblSelectedModifiedDate.Text = "";
            lblSelectedDescription.Text = "";
        }

        private void lblCreateModel_Click(object sender, EventArgs e)
        {
            if (ModelPath == "")
                return;

            CreateModelForm form = new CreateModelForm();

            form.ModelPath = ModelPath;
            if (form.ShowDialog() == DialogResult.OK)
            {
                UpdateModelList();
            }
        }

        private void lblEditModel_Click(object sender, EventArgs e)
        {
            if (ModelPath == "" || gvModelList.SelectedRows.Count <= 0)
                return;

            EditModelForm form = new EditModelForm();
            form.PrevModelName = lblSelectedName.Text;
            form.PrevDescription = lblSelectedDescription.Text;
            form.ModelPath = ModelPath;

            if (form.ShowDialog() == DialogResult.OK)
            {
                UpdateModelList();
            }
        }

        //private void EditModel(string newModelName, string newDescription)
        //{
        //    if (ModelPath == "")
        //        return;

        //    InspModelFileService.Edit(ModelPath, lblSelectedName.Text, newModelName, newDescription);
        //}

        private void lblDeleteModel_Click(object sender, EventArgs e)
        {
            if (ModelPath == "" || gvModelList.SelectedRows.Count <= 0)
                return;

            MessageYesNoForm form = new MessageYesNoForm();
            form.Message = "선택된 모델을 삭제하시겠습니까?";

            if (form.ShowDialog() == DialogResult.Yes)
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
            form.ModelPath = ModelPath;

            if (form.ShowDialog() == DialogResult.OK)
            {
                UpdateModelList();
            }
        }

        //private void CopyModel(string newModelName)
        //{
        //    InspModelFileService.Copy(ModelPath, lblSelectedName.Text, newModelName);
        //}

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
    }
}
