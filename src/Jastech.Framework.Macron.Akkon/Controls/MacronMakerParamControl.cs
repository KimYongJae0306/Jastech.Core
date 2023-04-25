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
using AW;
using Jastech.Framework.Winform.Helper;

namespace Jastech.Framework.Macron.Akkon.Controls
{
    public partial class MacronMakerParamControl : UserControl
    {
        public MacronAkkonParam CurrentParam { get; private set; } = null;

        private bool _isLoading { get; set; } = false;
        
        public MacronMakerParamControl()
        {
            InitializeComponent();
        }

        private void MacronMakerParamControl_Load(object sender, EventArgs e)
        {
            _isLoading = true;

            InitalizeComboBox();

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

        private void InitalizeComboBox()
        {
            foreach (InspectionType inspectionType in Enum.GetValues(typeof(InspectionType)))
                cbxInspectionType.Items.Add(inspectionType.ToString().ToUpper());

            foreach (PanelType panelType in Enum.GetValues(typeof(PanelType)))
                cbxPanelType.Items.Add(panelType.ToString().ToUpper());

            foreach (TargetType targetType in Enum.GetValues(typeof(TargetType)))
                cbxTargetType.Items.Add(targetType.ToString().ToUpper());

            foreach (FilterType filterType in Enum.GetValues(typeof(FilterType)))
                cbxFilterType.Items.Add(filterType.ToString().ToUpper());

            foreach (FilterDirection filterDirection in Enum.GetValues(typeof(FilterDirection)))
                cbxFilterDirection.Items.Add(filterDirection.ToString().ToUpper());

            foreach (ShadowDirection shadowDirection in Enum.GetValues(typeof(ShadowDirection)))
                cbxShadowDirection.Items.Add(shadowDirection.ToString().ToUpper());

            foreach (PeakProperty peakProperty in Enum.GetValues(typeof(PeakProperty)))
                cbxPeakProperty.Items.Add(peakProperty.ToString().ToUpper());

            foreach (StrengthBase strengthBase in Enum.GetValues(typeof(StrengthBase)))
                cbxStrengthBase.Items.Add(strengthBase.ToString().ToUpper());

            foreach (ThresholdMode thresholdMode in Enum.GetValues(typeof(ThresholdMode)))
                cbxThresholdMode.Items.Add(thresholdMode.ToString().ToUpper());
        }

        private void UpdateParam()
        {
            cbxPanelType.SelectedIndex = (int)CurrentParam.InspParam.IsFlexible;
            cbxTargetType.SelectedIndex = (int)CurrentParam.InspParam.PanelInfo;
            cbxFilterType.SelectedIndex = (int)CurrentParam.InspParam.FilterType;
            cbxFilterDirection.SelectedIndex = (int)CurrentParam.InspParam.FilterDir;
            cbxShadowDirection.SelectedIndex = (int)CurrentParam.InspParam.ShadowDir;
            cbxPeakProperty.SelectedIndex = (int)CurrentParam.InspParam.PeakProp;

            cbxThresholdMode.SelectedIndex = (int)CurrentParam.InspParam.ThMode;
            lblThresholdWeightValue.Text = CurrentParam.InspParam.ThWeight.ToString("F2");
            lblPeakThresholdValue.Text = CurrentParam.InspParam.ThPeak.ToString();
            cbxStrengthBase.SelectedIndex = (int)CurrentParam.InspParam.StrengthBase;
            lblStrengthScaleFactorValue.Text = CurrentParam.InspParam.StrengthScaleFactor.ToString("F2");
            lblStandardDeviationValue.Text = CurrentParam.InspParam.StdDevLeadJudge.ToString();

            cbxInspectionType.SelectedIndex = CurrentParam.InspOption.InspType;
            chkLogTraceUseCheck.Checked = CurrentParam.InspOption.LogTrace;
            lblSliceOverlapValue.Text = CurrentParam.InspOption.Overlap.ToString("F2");
        }

        private void cbxPanelType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            int selectedIndex = cbxPanelType.SelectedIndex;
            CurrentParam.InspOption.InspType = (int)selectedIndex;
        }

        private void cbxTargetType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            int selectedIndex = cbxTargetType.SelectedIndex;
            CurrentParam.InspParam.PanelInfo = selectedIndex;
        }

        private void cbxFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            int selectedIndex = cbxFilterType.SelectedIndex;
            CurrentParam.InspParam.FilterType = (EN_MVFILTERTYPE_WRAP)selectedIndex;
        }

        private void cbxFilterDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            int selectedIndex = cbxFilterDirection.SelectedIndex;
            CurrentParam.InspParam.FilterDir = selectedIndex;
        }

        private void cbxShadowDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            int selectedIndex = cbxShadowDirection.SelectedIndex;
            CurrentParam.InspParam.ShadowDir = (EN_SHADOWDIR_WRAP)selectedIndex;
        }

        private void cbxPeakProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            int selectedIndex = cbxPeakProperty.SelectedIndex;
            CurrentParam.InspParam.PeakProp = (EN_PEAK_PROP_WRAP)selectedIndex;
        }

        private void cbxThresholdMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            int selectedIndex = cbxThresholdMode.SelectedIndex;
            CurrentParam.InspParam.ThMode = (EN_THMODE_WRAP)selectedIndex;
        }

        private void lblThresholdWeightValue_Click(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            double thresholdWeight = KeyPadHelper.SetLabelDoubleData((Label)sender);
            CurrentParam.InspParam.ThWeight = thresholdWeight;
        }

        private void lblPeakThresholdValue_Click(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            int thresholdPeak = KeyPadHelper.SetLabelIntegerData((Label)sender);
            CurrentParam.InspParam.ThPeak = thresholdPeak;
        }

        private void cbxStrengthBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            int selectedIndex = cbxStrengthBase.SelectedIndex;
            CurrentParam.InspParam.StrengthBase = (EN_STRENGTH_BASE_WRAP)selectedIndex;
        }

        private void lblStrengthScaleFactorValue_Click(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            double strengthScaleFactor = KeyPadHelper.SetLabelDoubleData((Label)sender);
            CurrentParam.InspParam.StrengthScaleFactor = (float)strengthScaleFactor;
        }

        private void lblStandardDeviationValue_Click(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            double stdDevLeadJudge = KeyPadHelper.SetLabelDoubleData((Label)sender);
            CurrentParam.InspParam.StdDevLeadJudge = (float)stdDevLeadJudge;
        }

        private void cbxInspectionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            int selectedIndex = cbxInspectionType.SelectedIndex;
            CurrentParam.InspOption.InspType = (int)selectedIndex;
        }

        private void chkLogTraceUseCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            CurrentParam.InspOption.LogTrace = chkLogTraceUseCheck.Checked;
        }

        private void cbx_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox cbx = sender as ComboBox;

            if (cbx != null)
            {
                e.DrawBackground();
                cbx.ItemHeight = lblInspectionType.Height - 7;

                if (e.Index >= 0)
                {
                    StringFormat sf = new StringFormat();
                    sf.LineAlignment = StringAlignment.Center;
                    sf.Alignment = StringAlignment.Center;

                    Brush brush = new SolidBrush(cbx.ForeColor);

                    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                        brush = SystemBrushes.HighlightText;

                    e.Graphics.DrawString(cbx.Items[e.Index].ToString(), cbx.Font, brush, e.Bounds, sf);
                }
            }
        }
    }
}
