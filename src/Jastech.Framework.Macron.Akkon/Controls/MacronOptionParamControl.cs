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
    public partial class MacronOptionParamControl : UserControl
    {
        public MacronAkkonParam CurrentParam { get; private set; } = null;

        private bool _isLoading { get; set; } = false;

        public MacronOptionParamControl()
        {
            InitializeComponent();
        }

        private void MacronOptionParamControl_Load(object sender, EventArgs e)
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
            lblDimpleNGCount.Text = CurrentParam.DimpleInspParam.NGCount.ToString();
            lblDimpleThresholdValue.Text = CurrentParam.DimpleInspParam.Threshold.ToString();
            lblAlarmCapacityValue.Text = CurrentParam.AlarmCapacity.ToString();
            lblAlarmNGCountValue.Text = CurrentParam.AlarmNGCount.ToString();

            chkUseAlarm.Checked = CurrentParam.DimpleInspParam.IsEnable;
            chkUseAlarm.Checked = CurrentParam.UseAlarm;
        }

        private void lblDimpleNGCountValue_Click(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            int dimpleNGCount = KeyPadHelper.SetLabelIntegerData((Label)sender);
            CurrentParam.DimpleInspParam.NGCount = dimpleNGCount;
        }

        private void lblDimpleThresholdValue_Click(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            int dimpleThreshold = KeyPadHelper.SetLabelIntegerData((Label)sender);
            CurrentParam.DimpleInspParam.Threshold = dimpleThreshold;
        }

        private void chkUseDimple_CheckedChanged(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            CurrentParam.DimpleInspParam.IsEnable = chkUseAlarm.Checked;
        }

        private void lblAlarmCapacityValue_Click(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            int alarmCapacity = KeyPadHelper.SetLabelIntegerData((Label)sender);
            CurrentParam.AlarmCapacity = alarmCapacity;
        }

        private void lblAlarmNGCountValue_Click(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            int alarmNGCount = KeyPadHelper.SetLabelIntegerData((Label)sender);
            CurrentParam.AlarmNGCount = alarmNGCount;
        }

        private void chkUseAlarm_CheckedChanged(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            CurrentParam.UseAlarm = chkUseAlarm.Checked;
        }
    }
}
