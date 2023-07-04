using Jastech.Framework.Modeller.Forms;
using Jastech.Framework.Structure;
using Jastech.Framework.Structure.Helper;
using Jastech.Framework.Util.Helper;
using Jastech.Framework.Winform.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Jastech.Framework.Modeller.Controls
{
    public partial class ModelControl : UserControl
    {
        #region 속성
        public string ModelPath { get; set; } = "";
        #endregion

        #region 이벤트
        public event ModelDelegate CreateModelEventHandler;

        public event EditModelDelegate EditModelEventHandler;

        public event CopyModelDelegate CopyModelEventHandler;

        public event ApplyModelDelegate ApplyModelEventHandler;

        public event EventHandler CloseEventHandler;
        #endregion

        #region 델리게이트
        public delegate void ModelDelegate(InspModel model);

        public delegate void EditModelDelegate(string prevModelName, InspModel inspModel);

        public delegate void CopyModelDelegate(string prevModelName, string newModelName);

        public delegate void ApplyModelDelegate(string modelName);
        #endregion

        #region 생성자
        public ModelControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void ModelControl_Load(object sender, EventArgs e)
        {
            UpdateModelList();
        }

        private void UpdateModelList()
        {
            if (ModelPath == "")
                return;

            List<InspModel> models = GetModelList(ModelPath);

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
            form.CreateModelEvent += CreateModelEventHandler;

            if (form.ShowDialog() == DialogResult.OK)
            {
                UpdateModelList();
            }
            form.CreateModelEvent -= CreateModelEventHandler;
        }

        private void lblEditModel_Click(object sender, EventArgs e)
        {
            if (ModelPath == "" || gvModelList.SelectedRows.Count <= 0)
                return;

            EditModelForm form = new EditModelForm();
            form.PrevModelName = lblSelectedName.Text;
            form.PrevDescription = lblSelectedDescription.Text;
            form.ModelPath = ModelPath;
            form.EditModelEvent += EditModelEventHandler;

            if (form.ShowDialog() == DialogResult.OK)
            {
                UpdateModelList();
            }
            form.EditModelEvent += EditModelEventHandler;
        }

        private void lblDeleteModel_Click(object sender, EventArgs e)
        {
            if (ModelPath == "" || gvModelList.SelectedRows.Count <= 0)
                return;

            MessageYesNoForm form = new MessageYesNoForm();
            form.Message = "Do you want to delete the selected model?";

            if (form.ShowDialog() == DialogResult.Yes)
            {
                ModelFileHelper.Delete(ModelPath, lblSelectedName.Text);
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
            form.CopyModelEvent += CopyModelEventHandler;

            if (form.ShowDialog() == DialogResult.OK)
            {
                UpdateModelList();
            }
        }

        private void gvModelList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
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

        private void lblApply_Click(object sender, EventArgs e)
        {
            ApplyModel();
        }

        private void ApplyModel()
        {
            if (lblSelectedName.Text == "")
                return;

            ApplyModelEventHandler?.Invoke(lblSelectedName.Text);
        }

        public List<InspModel> GetModelList(string modelPath)
        {
            if (!Directory.Exists(modelPath))
                Directory.CreateDirectory(modelPath);

            List<InspModel> modelList = new List<InspModel>();

            string[] dirs = Directory.GetDirectories(modelPath);
            for (int i = 0; i < dirs.Length; i++)
            {
                InspModel inspModel = new InspModel();
                string path = Path.Combine(dirs[i], InspModel.FileName);
                JsonConvertHelper.LoadToExistingTarget<InspModel>(path, inspModel);
                modelList.Add(inspModel);
            }

            return modelList;
        }
        #endregion

        private void gvModelList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0)
                return;

            UpdateSelectedModel(e.RowIndex);

            ApplyModel();
        }

        private void lblCancel_Click(object sender, EventArgs e)
        {
            CloseEventHandler?.Invoke(sender, e);
        }
    }
}
