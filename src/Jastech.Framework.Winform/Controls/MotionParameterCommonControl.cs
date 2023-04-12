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

        private void InitializeUI()
        {
            grpAxisName.Text = SelectedAxis.Name.ToString() + " Axis Parameter";
        }

        public void UpdateData(AxisCommonParams axisCommonParams)
        {
            CommonParam = axisCommonParams;
            UpdateUI();
        }

        public void SetAxis(Axis axis)
        {
            SelectedAxis = axis;
        }

        public void UpdateUI()
        {
            if (CommonParam == null)
                return;

            lblJogLowSpeedValue.Text = CommonParam.JogLowSpeed.ToString();
            tempJogLowSpeed = CommonParam.JogLowSpeed;

            lblJogHighSpeedValue.Text = CommonParam.JogHighSpeed.ToString();
            tempJogHighSpeed = CommonParam.JogHighSpeed;

            lblMoveToleranceValue.Text = CommonParam.MoveTolerance.ToString();
            tempMoveTolerance = CommonParam.MoveTolerance;

            lblNegativeLimitValue.Text = CommonParam.NegativeLimit.ToString();
            tempNegativeLimit = CommonParam.NegativeLimit;

            lblPositiveLimitValue.Text = CommonParam.PositiveLimit.ToString();
            tempPositiveLimit = CommonParam.PositiveLimit;

            lblHomingTimeOutValue.Text = CommonParam.HommingTimeOut.ToString();
            tempHomingTimeOut = CommonParam.HommingTimeOut;
        }

        public AxisCommonParams GetCurrentData()
        {
            AxisCommonParams param = new AxisCommonParams();

            param.JogLowSpeed = tempJogLowSpeed;
            param.JogHighSpeed = tempJogHighSpeed;
            param.MoveTolerance = tempMoveTolerance;
            param.NegativeLimit = tempNegativeLimit;
            param.PositiveLimit = tempPositiveLimit;
            param.HommingTimeOut = tempHomingTimeOut;

            CommonParam = param.DeepCopy();

            return CommonParam;
        }

        private double tempJogLowSpeed = 0.0;
        private void lblJogLowSpeedValue_Click(object sender, EventArgs e)
        {
            tempJogLowSpeed = SetLabelDoubleData(sender);
        }

        private double tempJogHighSpeed = 0.0;
        private void lblJogHighSpeedValue_Click(object sender, EventArgs e)
        {
            tempJogHighSpeed = SetLabelDoubleData(sender);
        }

        private double tempMoveTolerance = 0.0;
        private void lblMoveToleranceValue_Click(object sender, EventArgs e)
        {
            tempMoveTolerance = SetLabelDoubleData(sender);
        }

        private double tempNegativeLimit = 0.0;
        private void lblNegativeLimitValue_Click(object sender, EventArgs e)
        {
            tempNegativeLimit = SetLabelDoubleData(sender);
        }

        private double tempPositiveLimit = 0.0;
        private void lblPositiveLimitValue_Click(object sender, EventArgs e)
        {
            tempPositiveLimit = SetLabelDoubleData(sender);
        }

        private double tempHomingTimeOut = 0.0;
        private void lblHomingTimeOutValue_Click(object sender, EventArgs e)
        {
            tempHomingTimeOut = SetLabelDoubleData(sender);
        }

        private double SetLabelDoubleData(object sender)
        {
            KeyPadForm keyPadForm = new KeyPadForm();
            keyPadForm.ShowDialog();

            double inputData = keyPadForm.PadValue;

            Label label = (Label)sender;
            label.Text = inputData.ToString();

            return inputData;
        }
        #endregion
    }
}
