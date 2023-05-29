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

namespace Jastech.Framework.Algorithms.UI.Controls
{
    public partial class AkkonParamControl : UserControl
    {
        private bool _isLoading = false;

        public AkkonAlgoritmParam CurrentParam { get; set; } = null;

        public AkkonParamControl()
        {
            InitializeComponent();
        }

        private void AkkonParamControl_Load(object sender, EventArgs e)
        {
            _isLoading = true;
            InitializeComboBox();
            UpdateParams();
            _isLoading = false;
        }

        public void SetParam(AkkonAlgoritmParam param)
        {
            CurrentParam = param;
        }

        private void InitializeComboBox()
        {
            //if (CurrentParam == null)
            //    return;
            //var filterList = SystemManager.Instance().AkkonParameters.GetImageFilter();

            //foreach (var filter in CurrentParam.GetImageFilter())
            //    cbxFilterType.Items.Add(filter.Name);

            foreach (AkkonFilterDir type in Enum.GetValues(typeof(AkkonFilterDir)))
                cbxFilterDirection.Items.Add(type.ToString());

            foreach (AkkonThMode type in Enum.GetValues(typeof(AkkonThMode)))
                cbxThresholdMode.Items.Add(type.ToString());
        }

        private void UpdateParams()
        {
            if (CurrentParam == null)
                return;

            // Filter
            var filter = CurrentParam.GetCurrentFilter();
            cbxFilterType.Items.Clear();
            foreach (var filterName in CurrentParam.GetImageFilter())
                cbxFilterType.Items.Add(filterName.Name);

            if (filter == null)
            {
                cbxFilterType.SelectedIndex = 0;
                string currentFilterName = cbxFilterType.SelectedItem as string;
                CurrentParam.CurrentFilterName = currentFilterName;

                var curFilter = CurrentParam.GetCurrentFilter();
                lblSigma.Text = curFilter.Sigma.ToString();
                lblScaleFactor.Text = curFilter.ScaleFactor.ToString();
                lblGusWidth.Text = curFilter.GusWidth.ToString();
                lblLogWidth.Text = curFilter.LogWidth.ToString();
            }
            else
            {
                int index = -1;
                foreach (var item in cbxFilterType.Items)
                {
                    index++;
                    string value = item as string;
                    if(value == filter.Name)
                    {
                        lblSigma.Text = filter.Sigma.ToString();
                        lblScaleFactor.Text = filter.ScaleFactor.ToString();
                        lblGusWidth.Text = filter.GusWidth.ToString();
                        lblLogWidth.Text = filter.LogWidth.ToString();
                        break;
                    }
                    
                }
                cbxFilterType.SelectedIndex = index;

            }
            // Image Processing
            lblResizeRatio.Text = CurrentParam.ResizeRatio.ToString();
            cbxFilterDirection.SelectedIndex = (int)CurrentParam.FilterDir;
            cbxThresholdMode.SelectedIndex = (int)CurrentParam.ThresParam.Mode;
            lblThresholdWeight.Text = CurrentParam.ThresParam.Weight.ToString();

            // Filters
            lblMinSize.Text = CurrentParam.ResultFilter.MinSize.ToString();
            lblMaxSize.Text = CurrentParam.ResultFilter.MaxSize.ToString();

            // Draw Options
            ckbContainLeadCount.Checked = CurrentParam.DrawOption.ContainLeadCount;
            ckbContainLeadCount.Checked = CurrentParam.DrawOption.ContainLeadROI;
            ckbContainNG.Checked = CurrentParam.DrawOption.ContainNG;
        }

        public AkkonAlgoritmParam GetCurrentParam()
        {
            return CurrentParam;
        }

        public void UpdateData()
        {
            UpdateParams();
        }

        private void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            DrawComboboxCenterAlign(sender, e);
        }

        private void DrawComboboxCenterAlign(object sender, DrawItemEventArgs e)
        {
            try
            {
                ComboBox cmb = sender as ComboBox;

                if (cmb != null)
                {
                    e.DrawBackground();
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
            catch (Exception err)
            {
                throw;
            }

        }

        private void cbxFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbxFilterType.SelectedIndex;
            if (index < 0 || CurrentParam == null)
                return;

            string filterName = cbxFilterType.SelectedItem as string;
            UpdateFilterUI(filterName);

            lblSigma.Text = CurrentParam.GetCurrentFilter().Sigma.ToString();
            lblScaleFactor.Text = CurrentParam.GetCurrentFilter().ScaleFactor.ToString();
            lblGusWidth.Text = CurrentParam.GetCurrentFilter().GusWidth.ToString();
            lblLogWidth.Text = CurrentParam.GetCurrentFilter().LogWidth.ToString();
        }

        private void UpdateFilterUI(string filterName)
        {
            if (filterName == "Filter2_M" || filterName == "Filter4_M")
            {
                lblSigma.Enabled = false;
                lblScaleFactor.Enabled = false;
                lblGusWidth.Enabled = false;
                lblLogWidth.Enabled = false;
            }
            else
            {
                lblSigma.Enabled = true;
                lblScaleFactor.Enabled = true;
                lblGusWidth.Enabled = true;
                lblLogWidth.Enabled = true;
            }
        }

        private void lblSigma_Click(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            double sigma = KeyPadHelper.SetLabelDoubleData((Label)sender);
            CurrentParam.GetCurrentFilter().Sigma = sigma;
        }

        private void lblScaleFactor_Click(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            double scaleFactor = KeyPadHelper.SetLabelDoubleData((Label)sender);
            CurrentParam.GetCurrentFilter().ScaleFactor = scaleFactor;
        }

        private void lblGusWidth_Click(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            int gusWidth = KeyPadHelper.SetLabelIntegerData((Label)sender);
            CurrentParam.GetCurrentFilter().GusWidth = gusWidth;
        }

        private void lblLogWidth_Click(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            int logWidth = KeyPadHelper.SetLabelIntegerData((Label)sender);
            CurrentParam.GetCurrentFilter().LogWidth = logWidth;
        }

        private void lblResizeRatio_Click(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            double resizeRatio = KeyPadHelper.SetLabelDoubleData((Label)sender);
            CurrentParam.ResizeRatio = resizeRatio;
        }

        private void cbxFilterDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbxFilterDirection.SelectedIndex;
            if (index < 0 || _isLoading)
                return;


            CurrentParam.FilterDir = (AkkonFilterDir)index;
        }

        private void cbxThresholdMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbxThresholdMode.SelectedIndex;
            if (index < 0 || _isLoading)
                return;

            CurrentParam.ThresParam.Mode = (AkkonThMode)index;
        }

        private void lblThresholdWeight_Click(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            double weight = KeyPadHelper.SetLabelDoubleData((Label)sender);
            CurrentParam.ThresParam.Weight = weight;
        }

        private void lblMinSize_Click(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            double minSize = KeyPadHelper.SetLabelDoubleData((Label)sender);
            CurrentParam.ResultFilter.MinSize = minSize;
        }

        private void lblMaxSize_Click(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            double maxSize = KeyPadHelper.SetLabelDoubleData((Label)sender);
            CurrentParam.ResultFilter.MaxSize = maxSize;
        }

        private void ckbContainLeadCount_CheckedChanged(object sender, EventArgs e)
        {
            CurrentParam.DrawOption.ContainLeadCount = ckbContainLeadCount.Checked;
        }

        private void ckbContainLeadROI_CheckedChanged(object sender, EventArgs e)
        {
            CurrentParam.DrawOption.ContainLeadROI = ckbContainLeadROI.Checked;
        }

        private void ckbContainNG_CheckedChanged(object sender, EventArgs e)
        {
            CurrentParam.DrawOption.ContainNG = ckbContainNG.Checked;
        }
    }
}
