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
    public partial class ModelForm : Form
    {
        public ModelForm()
        {
            InitializeComponent();
        }

        private void lblCreateModel_Click(object sender, EventArgs e)
        {
            CreateModelForm form = new CreateModelForm();
            if(form.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void ModelForm_Load(object sender, EventArgs e)
        {
            gvModelList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(55, 174, 224);
        }

        private void lblEditModel_Click(object sender, EventArgs e)
        {
            EditModelForm form = new EditModelForm();
            if(form.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
