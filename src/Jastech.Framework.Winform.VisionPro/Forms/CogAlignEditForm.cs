using Cognex.VisionPro.PMAlign;
using Jastech.Framework.Imaging.VisionPro.VisionAlgorithms;
using Jastech.Framework.Winform.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.VisionPro.Forms
{
    public partial class CogAlignEditForm : Form
    {
        public CogPMAlignTool PMTool { get; set; } = null;

        public CogPMAlignToolChangedDelegate CogPMAlignToolChanged { get; set; }

        public delegate void CogPMAlignToolChangedDelegate(CogPMAlignTool cogPMAlignTool);

        public CogAlignEditForm()
        {
            InitializeComponent();
        }

        private void CogAlignEditForm_Load(object sender, EventArgs e)
        {
            cogPMAlignEditV21.Subject = PMTool;
        }

        private void CogAlignEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageYesNoForm messageConfirm = new MessageYesNoForm();
            messageConfirm.Message = "Do you want to Save Tool?";

            if (messageConfirm.ShowDialog() == DialogResult.Yes)
            {
                CogPMAlignToolChanged?.Invoke(PMTool);
            }
            else
            {
                VisionProHelper.DisposeTool(PMTool);
            }
            cogPMAlignEditV21.Dispose();
        }
    }
}
