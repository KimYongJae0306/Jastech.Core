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
using Cognex.VisionPro;

namespace Jastech.Framework.Macron.Akkon.Controls
{ 
    public partial class MacronAkkonParamControl : UserControl
    {
        #region 필드
        private MacronAkkonParam CurrentParam;

        private Color _selectedColor = new Color();

        private Color _nonSelectedColor = new Color();
        #endregion

        #region 속성
        #endregion

        #region 이벤트
        public GetOriginImageDelegate GetOriginImageHandler;
        #endregion

        #region 델리게이트
        public delegate ICogImage GetOriginImageDelegate();
        #endregion

        #region 생성자
        public MacronAkkonParamControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void AkkonParamControl_Load(object sender, EventArgs e)
        {
            InitializeUI();
        }

        private void cmb_DrawItem(object sender, DrawItemEventArgs e)
        {
            DrawComboboxCenterAlign(sender, e);
        }

        private void DrawComboboxCenterAlign(object sender, DrawItemEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;

            if (cmb != null)
            {
                e.DrawBackground();
                cmb.ItemHeight = lblInspectionType.Height - 7;

                if (e.Index >= 0)
                {
                    StringFormat sf = new StringFormat();
                    sf.LineAlignment = StringAlignment.Center;
                    sf.Alignment = StringAlignment.Center;

                    Brush brush = new SolidBrush(cmb.ForeColor);

                    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                        brush = SystemBrushes.HighlightText;

                    e.Graphics.DrawString(cmb.Items[e.Index].ToString(), cmb.Font, brush, e.Bounds, sf);
                }
            }
        }

        private void InitializeUI()
        {
            _selectedColor = Color.FromArgb(104, 104, 104);
            _nonSelectedColor = Color.FromArgb(52, 52, 52);

            // Checked Radio Button
            rdoEngineerParmeter.Checked = true;

            // Authority
            //if (Main.Instance().Authority != eAuthority.Maker)
            //    rdoMakerParmeter.Enabled = false;
            //else
            //    rdoMakerParmeter.Enabled = true;

            // Parameter Panel Dock
            this.pnlEngineerParameter.Dock = DockStyle.Fill;
            this.pnlMakerParameter.Dock = DockStyle.Fill;
            this.pnlOptionParameter.Dock = DockStyle.Fill;
        }
        #endregion

        private void InitializeComboBox()
        {
            foreach (InspectionType inspectionType in Enum.GetValues(typeof(InspectionType)))
                cmbInspectionType.Items.Add(inspectionType.ToString().ToUpper());

            foreach (PanelType panelType in Enum.GetValues(typeof(PanelType)))
                cmbPanelType.Items.Add(panelType.ToString().ToUpper());

            foreach (TargetType targetType in Enum.GetValues(typeof(TargetType)))
                cmbTargetType.Items.Add(targetType.ToString().ToUpper());

            foreach (FilterType filterType in Enum.GetValues(typeof(FilterType)))
                cmbFilterType.Items.Add(filterType.ToString().ToUpper());

            foreach (FilterDirection filterDirection in Enum.GetValues(typeof(FilterDirection)))
                cmbFilterDirection.Items.Add(filterDirection.ToString().ToUpper());

            foreach (ShadowDirection shadowDirection in Enum.GetValues(typeof(ShadowDirection)))
                cmbShadowDirection.Items.Add(shadowDirection.ToString().ToUpper());

            foreach (PeakProperty peakProperty in Enum.GetValues(typeof(PeakProperty)))
                cmbPeakProperty.Items.Add(peakProperty.ToString().ToUpper());

            foreach (StrengthBase strengthBase in Enum.GetValues(typeof(StrengthBase)))
                cmbStrengthBase.Items.Add(strengthBase.ToString().ToUpper());

            foreach (ThresholdMode thresholdMode in Enum.GetValues(typeof(ThresholdMode)))
                cmbThresholdMode.Items.Add(thresholdMode.ToString().ToUpper());
        }

        public void UpdateData(MacronAkkonParam macronAkkonParam)
        {
            CurrentParam = macronAkkonParam;

            InitializeComboBox();
            // Group Param
            //lblGroupCountValue.Text = akkonParam.GroupCount.ToString();
            //if (akkonParam.GroupCount > 0)
            //    cmbGroupNumber.SelectedIndex = 0;
            //lblROIWidthValue.Text = akkonParam.LeadWidth.ToString();
            //lblROIHeightValue.Text = akkonParam.LeadHeight.ToString();
            //lblLeadCountValue.Text = akkonParam.LeadCount.ToString();
            //lblLeadPitchValue.Text = akkonParam.LeadPitch.ToString();

            ///Enginner Param
            lblJudgeCountValue.Text = macronAkkonParam.JudgeCount.ToString();
            lblJudgeLengthValue.Text = macronAkkonParam.JudgeLength.ToString("F2");
            lblMinSizeFilterValue.Text = macronAkkonParam.FilterMinSize.ToString("F2");
            lblMaxSizeFilterValue.Text = macronAkkonParam.FilterMaxSize.ToString("F2");
            lblGroupDistanceValue.Text = macronAkkonParam.GroupingDistance.ToString("F2");
            lblStrengthFilterValue.Text = macronAkkonParam.StrengthThreshold.ToString("F2");
            lblWidthCutValue.Text = macronAkkonParam.WidthCut.ToString();
            lblHeightCutValue.Text = macronAkkonParam.HeightCut.ToString();
            lblBWRatioValue.Text = macronAkkonParam.BWRatio.ToString("F2");
            lblExtraLeadDisplayValue.Text = macronAkkonParam.ExtraLead.ToString();

            // Maker Param
            cmbInspectionType.SelectedIndex = (int)macronAkkonParam.InspectionType;
            cmbPanelType.SelectedIndex = (int)macronAkkonParam.PanelType;
            cmbTargetType.SelectedIndex = (int)macronAkkonParam.TargetType;
            cmbFilterType.SelectedIndex = (int)macronAkkonParam.FilterType;
            cmbFilterDirection.SelectedIndex = (int)macronAkkonParam.FilterDirection;
            cmbShadowDirection.SelectedIndex = (int)macronAkkonParam.ShadowDirection;
            cmbPeakProperty.SelectedIndex = (int)macronAkkonParam.PeakProperty;
            cmbStrengthBase.SelectedIndex = (int)macronAkkonParam.StrengthBase;
            cmbThresholdMode.SelectedIndex = (int)macronAkkonParam.ThresholdMode;

            chkLogTraceUseCheck.Checked = macronAkkonParam.UseLogTrace;
            lblThresholdWeightValue.Text = macronAkkonParam.ThresholdWeight.ToString("F2");
            lblPeakThresholdValue.Text = macronAkkonParam.ThresholdPeak.ToString();
            lblStandardDeviationValue.Text = macronAkkonParam.StdDevLeadJudge.ToString();
            lblStrengthScaleFactorValue.Text = macronAkkonParam.StrengthScaleFactor.ToString("F2");
            lblSliceOverlapValue.Text = macronAkkonParam.Overlap.ToString("F2");

            // Option
            chkUseDimple.Checked = macronAkkonParam.UseDimple;
            lblDimpleNGCountValue.Text = macronAkkonParam.DimpleNGCount.ToString();
            lblDimpleThresholdValue.Text = macronAkkonParam.DimpleThreshold.ToString();

            chkUseAlarm.Checked = macronAkkonParam.UseAlarm;
            lblAlarmCapacityValue.Text = macronAkkonParam.AlarmCapacity.ToString();
            lblAlarmNGCountValue.Text = macronAkkonParam.AlarmNGCount.ToString();
        }

        //public void UpdateData(MacronAkkonParam macronAkkonParam)
        //{
            

        //    InitializeComboBox();
        //    UpdateData(macronAkkonParam);
        //}

        #region Panel Open
        private void rdoEngineerParmeter_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoEngineerParmeter.Checked)
            {
                ShowEngineerParamter();
                rdoEngineerParmeter.BackColor = _selectedColor;
            }
            else
                rdoEngineerParmeter.BackColor = _nonSelectedColor;
        }

        private void ShowEngineerParamter()
        {
            pnlEngineerParameter.Visible = true;
            pnlMakerParameter.Visible = false;
            pnlOptionParameter.Visible = false;
        }

        private void rdoMakerParmeter_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoMakerParmeter.Checked)
            {
                ShowMakerParamter();
                rdoMakerParmeter.BackColor = _selectedColor;
            }
            else
                rdoMakerParmeter.BackColor = _nonSelectedColor;
        }

        private void ShowMakerParamter()
        {
            pnlEngineerParameter.Visible = false;
            pnlMakerParameter.Visible = true;
            pnlOptionParameter.Visible = false;
        }

        private void rdoOption_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOption.Checked)
            {
                ShowOptionParameter();
                rdoOption.BackColor = _selectedColor;
            }
            else
                rdoOption.BackColor = _nonSelectedColor;
        }

        private void ShowOptionParameter()
        {
            pnlEngineerParameter.Visible = false;
            pnlMakerParameter.Visible = false;
            pnlOptionParameter.Visible = true;
        }


        public MacronAkkonParam GetCurrentParam()
        {
            return CurrentParam;
        }
        #endregion

        private void lblJudgeCountValue_Click(object sender, EventArgs e)
        {

        }

        private void lblJudgeLengthValue_Click(object sender, EventArgs e)
        {

        }

        private void lblMinSizeFilterValue_Click(object sender, EventArgs e)
        {

        }

        private void lblWidthCutValue_Click(object sender, EventArgs e)
        {

        }

        private void lblMaxSizeFilterValue_Click(object sender, EventArgs e)
        {

        }

        private void lblHeightCutValue_Click(object sender, EventArgs e)
        {

        }

        private void lblGroupDistanceValue_Click(object sender, EventArgs e)
        {

        }

        private void lblBWRatioValue_Click(object sender, EventArgs e)
        {

        }

        private void lblStrengthFilterValue_Click(object sender, EventArgs e)
        {

        }

        private void lblExtraLeadDisplayValue_Click(object sender, EventArgs e)
        {

        }
    }
}
