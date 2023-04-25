using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jastech.Framework.Macron.Akkon.Parameters;
using Jastech.Framework.Winform.Helper;

namespace Jastech.Framework.Macron.Akkon.Controls
{
    public partial class MacronEngineerParamControl : UserControl
    {
        public MacronAkkonParam CurrentParam { get; private set; } = null;

        private bool _isLoading { get; set; } = false;

        public MacronEngineerParamControl()
        {
            InitializeComponent();
        }

        private void MacronEngineerParamControl_Load(object sender, EventArgs e)
        {
            _isLoading = true;

            if (CurrentParam != null)
            {
                UpdateParam();
            }

            _isLoading = false;
        }

        public void SetParam(MacronAkkonParam param)
        {
            CurrentParam = param;
        }

        private void UpdateParam()
        {
            lblJudgeCountValue.Text = CurrentParam.JudgeCount.ToString();
            lblJudgeLengthValue.Text = CurrentParam.JudgeLength.ToString("F2");
            lblMinSizeFilterValue.Text = CurrentParam.FilterParam.MinSize.ToString("F2");
            lblMaxSizeFilterValue.Text = CurrentParam.FilterParam.MaxSize.ToString("F2");
            lblGroupDistanceValue.Text = CurrentParam.FilterParam.GroupingDistance.ToString("F2");
            lblStrengthFilterValue.Text = CurrentParam.InspParam.StrengthThreshold.ToString("F2");
            lblWidthCutValue.Text = CurrentParam.FilterParam.WidthCut.ToString();
            lblHeightCutValue.Text = CurrentParam.FilterParam.HeightCut.ToString();
            lblBWRatioValue.Text = CurrentParam.FilterParam.BWRatio.ToString("F2");
            lblExtraLeadDisplayValue.Text = CurrentParam.InspParam.ExtraLead.ToString();
        }

        private void lblJudgeCountValue_Click(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            int judgeCount = KeyPadHelper.SetLabelIntegerData((Label)sender);
            CurrentParam.JudgeCount = judgeCount;
        }

        private void lblJudgeLengthValue_Click(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            double judgeLength = KeyPadHelper.SetLabelDoubleData((Label)sender);
            CurrentParam.JudgeLength = judgeLength;
        }

        private void lblStrengthFilterValue_Click(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            double strengthFilter = KeyPadHelper.SetLabelDoubleData((Label)sender);
            CurrentParam.InspParam.StrengthThreshold = (float)strengthFilter;
        }

        private void lblMinSizeFilterValue_Click(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            double filterMinSize = KeyPadHelper.SetLabelDoubleData((Label)sender);
            CurrentParam.FilterParam.MinSize = (float)filterMinSize;
        }

        private void lblMaxSizeFilterValue_Click(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            double finterMaxSize = KeyPadHelper.SetLabelDoubleData((Label)sender);
            CurrentParam.FilterParam.MaxSize = (float)finterMaxSize;
        }

        private void lblGroupDistanceValue_Click(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            double groupDistance = KeyPadHelper.SetLabelDoubleData((Label)sender);
            CurrentParam.FilterParam.GroupingDistance = groupDistance;
        }

        private void lblWidthCutValue_Click(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            int widthCut = KeyPadHelper.SetLabelIntegerData((Label)sender);
            CurrentParam.FilterParam.WidthCut = widthCut;
        }

        private void lblHeightCutValue_Click(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            int heightCut = KeyPadHelper.SetLabelIntegerData((Label)sender);
            CurrentParam.FilterParam.HeightCut = heightCut;
        }

        private void lblBWRatioValue_Click(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            double bwRatio = KeyPadHelper.SetLabelDoubleData((Label)sender);
            CurrentParam.FilterParam.BWRatio = (float)bwRatio;
        }

        private void lblExtraLeadDisplayValue_Click(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            int extraLead = KeyPadHelper.SetLabelIntegerData((Label)sender);
            CurrentParam.InspParam.ExtraLead = extraLead;
        }
    }
}
