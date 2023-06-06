using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jastech.Framework.Algorithms.Akkon.Parameters;
using Jastech.Framework.Algorithms.Akkon;
using Jastech.Framework.Winform.Helper;
using System.Diagnostics;
using System.IO;

namespace Jastech.Framework.Algorithms.UI.Controls
{
    public partial class AkkonParamControl : UserControl
    {
        #region 필드
        private Color _selectedColor = new Color();

        private Color _nonSelectedColor = new Color();
        #endregion

        #region 속성
        public bool UserMaker { get; set; } = false;

        public string ViewerPath { get; set; } = "";

        public AkkonAlgoritmParam CurrentParam { get; set; } = null;

        private AkkonProcessingParamControl ProcessingParamControl { get; set; } = null;

        private AkkonResultParamControl ResultParamControl { get; set; } = null;
        #endregion

        #region 생성자
        public AkkonParamControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void AkkonParamControl_Load(object sender, EventArgs e)
        {
            InitializeUI();
            ShowResultParamControl();

            if (UserMaker == false)
            {
                rdoImageParam.Visible = false;
            }
        }

        private void InitializeUI()
        {
            _selectedColor = Color.FromArgb(104, 104, 104);
            _nonSelectedColor = Color.FromArgb(52, 52, 52);

            ProcessingParamControl = new AkkonProcessingParamControl();
            ProcessingParamControl.Dock = DockStyle.Fill;
            ProcessingParamControl.OpenViewerDelegateEvent += OpenViewerDelegateEventFunction;
            ProcessingParamControl.SetParam(CurrentParam?.ImageFilterParam);
            pnlDisplay.Controls.Add(ProcessingParamControl);

            ResultParamControl = new AkkonResultParamControl();
            ResultParamControl.Dock = DockStyle.Fill;
            ResultParamControl.SetParam(CurrentParam?.ResultFilterParam, CurrentParam?.JudgementParam, CurrentParam?.DrawOption);
            ResultParamControl.UserMaker = UserMaker;
            pnlDisplay.Controls.Add(ResultParamControl);
        }

        private void OpenViewerDelegateEventFunction()
        {
            string filePath = Path.Combine(ViewerPath, "AkkonTester.exe");
            if (File.Exists(filePath))
            {
                Process.Start(filePath);
            }
        }

        public void SetParam(AkkonAlgoritmParam param)
        {
            CurrentParam = param;
            ProcessingParamControl?.SetParam(CurrentParam.ImageFilterParam);
            ResultParamControl?.SetParam(CurrentParam.ResultFilterParam, CurrentParam.JudgementParam, CurrentParam?.DrawOption);
        }

        public void UpdateData()
        {
            ProcessingParamControl.UpdateData();
            ResultParamControl.UpdateData();
        }

        public AkkonAlgoritmParam GetCurrentParam()
        {
            if (CurrentParam != null)
            {
                CurrentParam.ImageFilterParam = ProcessingParamControl.CurrentParam;
                CurrentParam.ResultFilterParam = ResultParamControl.ResultFilterParam;
                CurrentParam.JudgementParam = ResultParamControl.JudgementParam;
                CurrentParam.DrawOption = ResultParamControl.DrawOption;
            }

            return CurrentParam;
        }

        public void ShowResultParamControl()
        {
            rdoResultParam.BackColor = _selectedColor;
            rdoImageParam.BackColor = _nonSelectedColor;

            pnlDisplay.Controls.Clear();
            pnlDisplay.Controls.Add(ResultParamControl);
        }

        public void ShowImageParamControl()
        {
            rdoResultParam.BackColor = _nonSelectedColor;
            rdoImageParam.BackColor = _selectedColor;
            pnlDisplay.Controls.Clear();
            pnlDisplay.Controls.Add(ProcessingParamControl);
        }

        private void rdoResultParam_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoResultParam.Checked)
                ShowResultParamControl();
        }

        private void rdoImageParam_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoImageParam.Checked)
                ShowImageParamControl();
        }
        #endregion
    }
}
