using Jastech.Framework.Algorithms.Akkon.Parameters;
using Jastech.Framework.Winform.Helper;
using System;
using System.Windows.Forms;

namespace Jastech.Framework.Algorithms.UI.Controls
{
    public partial class AkkonResultParamControl : UserControl
    {
        #region 필드
        private bool _isLoading = false;
        #endregion

        #region 속성
        public bool UserMaker { get; set; } = false;

        public AkkonShapeFilterParam ShapeFilterParam { get; private set; } = null;

        public AkkonJudgementParam JudgementParam { get; private set; } = null;

        public DrawParam DrawOption { get; set; } = null;
        #endregion

        #region 생성자
        public AkkonResultParamControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void AkkonResultParamControl_Load(object sender, EventArgs e)
        {
            _isLoading = true;
            UpdateParams();

            if (UserMaker == false)
            {
                lblStrengthScaleText.Visible = false;
                lblStrengthScaleFactor.Visible = false;

                lblLeadStdDevText.Visible = false;
                lblLeadStdDev.Visible = false;
            }

            _isLoading = false;
        }

        public void SetParam(AkkonShapeFilterParam shapeParam, AkkonJudgementParam judgementParam, DrawParam drawOption)
        {
            ShapeFilterParam = shapeParam;
            JudgementParam = judgementParam;
            DrawOption = drawOption;
        }

        private void UpdateParams()
        {
            if (JudgementParam == null || DrawOption == null)
                return;

            // Shape
            lblGrouping.Text = ShapeFilterParam.Grouping.ToString();
            lblMinArea.Text = ShapeFilterParam.MinArea_um.ToString();
            lblMaxArea.Text = ShapeFilterParam.MaxArea_um.ToString();
            lblMinSize.Text = ShapeFilterParam.MinSize_um.ToString();
            lblMaxSize.Text = ShapeFilterParam.MaxSize_um.ToString();
            lblStrength.Text = ShapeFilterParam.MinAkkonStrength.ToString();
            lblStrengthScaleFactor.Text = ShapeFilterParam.AkkonStrengthScaleFactor.ToString();

            // Judgement
            lblAkkonCount.Text = JudgementParam.AkkonCount.ToString();
            lblLeadLengthX.Text = JudgementParam.LengthX_um.ToString();
            lblLeadLengthY.Text = JudgementParam.LengthY_um.ToString();
            lblLeadStdDev.Text = JudgementParam.LeadStdDev.ToString();

            // Draw Options
            ckbContainLeadCount.Checked = DrawOption.ContainLeadCount;
            ckbContainLeadROI.Checked = DrawOption.ContainLeadROI;
            ckbContainNG.Checked = DrawOption.ContainNG;

            //ckbContainSize
            ckbContainSize.Checked = DrawOption.ContainSize;
            ckbContainArea.Checked = DrawOption.ContainArea;
            ckbContainStrength.Checked = DrawOption.ContainStrength;
        }

        private void lblGrouping_Click(object sender, EventArgs e)
        {
            int grouping = KeyPadHelper.SetLabelIntegerData((Label)sender);
            ShapeFilterParam.Grouping = grouping;
        }

        private void lblMinArea_Click(object sender, EventArgs e)
        {
            float minArea = KeyPadHelper.SetLabelFloatData((Label)sender);
            ShapeFilterParam.MinArea_um = minArea;
        }

        private void lblMaxArea_Click(object sender, EventArgs e)
        {
            float maxArea = KeyPadHelper.SetLabelFloatData((Label)sender);
            ShapeFilterParam.MaxArea_um = maxArea;
        }

        private void lblMinSize_Click(object sender, EventArgs e)
        {
            float minSize = KeyPadHelper.SetLabelFloatData((Label)sender);
            ShapeFilterParam.MinSize_um = minSize;
        }

        private void lblMaxSize_Click(object sender, EventArgs e)
        {
            float maxSize = KeyPadHelper.SetLabelFloatData((Label)sender);
            ShapeFilterParam.MaxSize_um = maxSize;
        }

        private void lblStrength_Click(object sender, EventArgs e)
        {
            float strength = KeyPadHelper.SetLabelFloatData((Label)sender);
            ShapeFilterParam.MinAkkonStrength = strength;
        }

        private void lblStrengthScaleFactor_Click(object sender, EventArgs e)
        {
            float strengthScaleFactor = KeyPadHelper.SetLabelFloatData((Label)sender);
            ShapeFilterParam.AkkonStrengthScaleFactor = strengthScaleFactor;
        }

        private void lblAkkonCount_Click(object sender, EventArgs e)
        {
            int count = KeyPadHelper.SetLabelIntegerData((Label)sender);
            JudgementParam.AkkonCount = count;
        }

        private void lblLeadLengthX_Click(object sender, EventArgs e)
        {
            float lengthX = KeyPadHelper.SetLabelFloatData((Label)sender);
            JudgementParam.LengthX_um = lengthX;
        }

        private void lblLeadLengthY_Click(object sender, EventArgs e)
        {
            float lengthY = KeyPadHelper.SetLabelFloatData((Label)sender);
            JudgementParam.LengthY_um = lengthY;
        }

        private void lblLeadStdDev_Click(object sender, EventArgs e)
        {
            float stddev = KeyPadHelper.SetLabelFloatData((Label)sender);
            JudgementParam.LeadStdDev = stddev;
        }

        private void ckbContainLeadCount_CheckedChanged(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            DrawOption.ContainLeadCount = ckbContainLeadCount.Checked;
        }

        private void ckbContainLeadROI_CheckedChanged(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            DrawOption.ContainLeadROI = ckbContainLeadROI.Checked;
        }

        private void ckbContainNG_CheckedChanged(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            DrawOption.ContainNG = ckbContainNG.Checked;
        }

        private void ckbContainArea_CheckedChanged(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            DrawOption.ContainArea = ckbContainArea.Checked;
        }

        private void ckbContainStrength_CheckedChanged(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            DrawOption.ContainStrength = ckbContainStrength.Checked;
        }

        private void ckbContainSize_CheckedChanged(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            DrawOption.ContainSize = ckbContainSize.Checked;
        }

        public void UpdateData()
        {
            UpdateParams();
        }
        #endregion
    }
}
