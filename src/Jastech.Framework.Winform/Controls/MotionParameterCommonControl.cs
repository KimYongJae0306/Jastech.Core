using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jastech.Framework.Winform.Forms;
using Jastech.Framework.Device.Motions;
using Jastech.Framework.Winform.Helper;

namespace Jastech.Framework.Winform.Controls
{
    public partial class MotionParameterCommonControl : UserControl
    {
        #region 필드
        #endregion

        #region 속성
        private Axis SelectedAxis { get; set; } = null;

        private AxisCommonParams CommonParam { get; set; } = null;
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        public MotionParameterCommonControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void MotionParameterCommonControl_Load(object sender, EventArgs e)
        {
            InitializeUI();
        }

        public void UpdateData(AxisCommonParams axisCommonParams)
        {
            if (axisCommonParams == null)
                return;

            CommonParam = axisCommonParams/*.DeepCopy()*/;
            UpdateUI();
        }

        private void InitializeUI()
        {
            grpAxisName.Text = SelectedAxis.Name.ToString() + " Axis Parameter";
        }

        public void UpdateUI()
        {
            lblJogLowSpeedValue.Text = CommonParam.JogLowSpeed.ToString();
            lblJogHighSpeedValue.Text = CommonParam.JogHighSpeed.ToString();
            lblMoveToleranceValue.Text = CommonParam.MoveTolerance.ToString();
            lblNegativeLimitValue.Text = CommonParam.NegativeLimit.ToString();
            lblPositiveLimitValue.Text = CommonParam.PositiveLimit.ToString();
            lblHomingTimeOutValue.Text = CommonParam.HommingTimeOut.ToString();
        }

        public void SetAxis(Axis axis)
        {
            SelectedAxis = axis;
        }

        public AxisCommonParams GetCurrentData()
        {
            AxisCommonParams param = new AxisCommonParams();

            param.JogLowSpeed = CommonParam.JogLowSpeed;
            param.JogHighSpeed = CommonParam.JogHighSpeed;
            param.MoveTolerance = CommonParam.MoveTolerance;
            param.NegativeLimit = CommonParam.NegativeLimit;
            param.PositiveLimit = CommonParam.PositiveLimit;
            param.HommingTimeOut = CommonParam.HommingTimeOut;

            return param.DeepCopy();
        }

        private void lblJogLowSpeedValue_Click(object sender, EventArgs e)
        {
            CommonParam.JogLowSpeed = KeyPadHelper.SetLabelDoubleData((Label)sender);
        }

        private void lblJogHighSpeedValue_Click(object sender, EventArgs e)
        {
            CommonParam.JogHighSpeed = KeyPadHelper.SetLabelDoubleData((Label)sender);
        }

        private void lblMoveToleranceValue_Click(object sender, EventArgs e)
        {
            CommonParam.MoveTolerance = KeyPadHelper.SetLabelDoubleData((Label)sender);
        }

        private void lblNegativeLimitValue_Click(object sender, EventArgs e)
        {
            CommonParam.NegativeLimit = KeyPadHelper.SetLabelDoubleData((Label)sender);
        }

        private void lblPositiveLimitValue_Click(object sender, EventArgs e)
        {
            CommonParam.PositiveLimit = KeyPadHelper.SetLabelDoubleData((Label)sender);
        }

        private void lblHomingTimeOutValue_Click(object sender, EventArgs e)
        {
            CommonParam.HommingTimeOut = KeyPadHelper.SetLabelDoubleData((Label)sender);
        }
        #endregion
    }
}
