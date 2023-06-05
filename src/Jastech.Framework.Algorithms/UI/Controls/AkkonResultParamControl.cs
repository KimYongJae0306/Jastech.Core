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
using Jastech.Framework.Winform.Helper;

namespace Jastech.Framework.Algorithms.UI.Controls
{
    public partial class AkkonResultParamControl : UserControl
    {
        private bool _isLoading = false;

        public bool UserMaker { get; set; } = false;

        public AkkonResultFilterParam ResultFilterParam { get; private set; } = null;

        public AkkonJudgementParam JudgementParam { get; private set; } = null;

        public DrawParam DrawOption { get; set; } = null;

        public AkkonResultParamControl()
        {
            InitializeComponent();
        }

        private void AkkonResultParamControl_Load(object sender, EventArgs e)
        {
            _isLoading = true;
            UpdateParams();

            if(UserMaker == false)
            {
                lblStrengthScaleText.Visible = false;
                lblStrengthScaleFactor.Visible = false;

                lblLeadStdDevText.Visible = false;
                lblLeadStdDev.Visible = false;
            }

            _isLoading = false;
        }

        public void SetParam(AkkonResultFilterParam resultParam, AkkonJudgementParam judgementParam, DrawParam drawOption)
        {
            ResultFilterParam = resultParam;
            JudgementParam = judgementParam;
            DrawOption = drawOption;
        }

        private void UpdateParams()
        {
            if (JudgementParam == null || DrawOption == null)
                return;

            // Result Filters
            lblGrouping.Text = ResultFilterParam.Grouping.ToString();
            lblMinArea.Text = ResultFilterParam.MinArea.ToString();
            lblMaxArea.Text = ResultFilterParam.MaxArea.ToString();
            lblMaxWidth.Text = ResultFilterParam.MaxWidth.ToString();
            lblMaxHeight.Text = ResultFilterParam.MaxHeight.ToString();
            lblStrength.Text = ResultFilterParam.AkkonStrength.ToString();
            lblStrengthScaleFactor.Text = ResultFilterParam.AkkonStrengthScaleFactor.ToString();

            // Judgement
            lblAkkonCount.Text = JudgementParam.AkkonCount.ToString();
            lblLeadLengthX.Text = JudgementParam.LengthX.ToString();
            lblLeadLengthY.Text = JudgementParam.LengthY.ToString();
            lblLeadStdDev.Text = JudgementParam.LeadStdDev.ToString();

            // Draw Options
            ckbContainLeadCount.Checked = DrawOption.ContainLeadCount;
            ckbContainLeadCount.Checked = DrawOption.ContainLeadROI;
            ckbContainNG.Checked = DrawOption.ContainNG;
            ckbContainArea.Checked = DrawOption.ContainArea;
            ckbContainStrength.Checked = DrawOption.ContainStrength;
        }

        private void lblGrouping_Click(object sender, EventArgs e)
        {
            int grouping = KeyPadHelper.SetLabelIntegerData((Label)sender);
            ResultFilterParam.Grouping = grouping;
        }

        private void lblMinArea_Click(object sender, EventArgs e)
        {
            double minArea = KeyPadHelper.SetLabelDoubleData((Label)sender);
            ResultFilterParam.MinArea = minArea;
        }

        private void lblMaxArea_Click(object sender, EventArgs e)
        {
            double maxArea = KeyPadHelper.SetLabelDoubleData((Label)sender);
            ResultFilterParam.MaxArea = maxArea;
        }

        private void lblMaxWidth_Click(object sender, EventArgs e)
        {
            double maxWidth = KeyPadHelper.SetLabelDoubleData((Label)sender);
            ResultFilterParam.MaxWidth = maxWidth;
        }

        private void lblMaxHeight_Click(object sender, EventArgs e)
        {
            double maxHeight = KeyPadHelper.SetLabelDoubleData((Label)sender);
            ResultFilterParam.MaxHeight = maxHeight;
        }

        private void lblStrength_Click(object sender, EventArgs e)
        {
            double strength = KeyPadHelper.SetLabelDoubleData((Label)sender);
            ResultFilterParam.AkkonStrength = strength;
        }

        private void lblStrengthScaleFactor_Click(object sender, EventArgs e)
        {
            double strengthScaleFactor = KeyPadHelper.SetLabelDoubleData((Label)sender);
            ResultFilterParam.AkkonStrengthScaleFactor = strengthScaleFactor;
        }

        private void lblAkkonCount_Click(object sender, EventArgs e)
        {
            int count = KeyPadHelper.SetLabelIntegerData((Label)sender);
            JudgementParam.AkkonCount = count;
        }

        private void lblLeadLengthX_Click(object sender, EventArgs e)
        {
            double lengthX = KeyPadHelper.SetLabelDoubleData((Label)sender);
            JudgementParam.LengthX = lengthX;
        }

        private void lblLeadLengthY_Click(object sender, EventArgs e)
        {
            double lengthY = KeyPadHelper.SetLabelDoubleData((Label)sender);
            JudgementParam.LengthX = lengthY;
        }

        private void lblLeadStdDev_Click(object sender, EventArgs e)
        {
            double stddev = KeyPadHelper.SetLabelDoubleData((Label)sender);
            JudgementParam.LeadStdDev = stddev;
        }

        private void ckbContainLeadCount_CheckedChanged(object sender, EventArgs e)
        {
            DrawOption.ContainLeadCount = ckbContainLeadCount.Checked;
        }

        private void ckbContainLeadROI_CheckedChanged(object sender, EventArgs e)
        {
            DrawOption.ContainLeadROI = ckbContainLeadROI.Checked;
        }

        private void ckbContainNG_CheckedChanged(object sender, EventArgs e)
        {
            DrawOption.ContainNG = ckbContainNG.Checked;
        }

        private void ckbContainArea_CheckedChanged(object sender, EventArgs e)
        {
            DrawOption.ContainArea = ckbContainArea.Checked;
        }

        private void ckbContainStrength_CheckedChanged(object sender, EventArgs e)
        {
            DrawOption.ContainStrength = ckbContainStrength.Checked;
        }

        public void UpdateData()
        {
            UpdateParams();
        }
    }
}
