using Jastech.Framework.Device.Motions;
using Jastech.Framework.Util.Helper;
using Jastech.Framework.Winform.Helper;
using System;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.Controls
{
    public partial class MotionParameterCommonControl : UserControl
    {
        #region 필드
        private readonly ParamTrackingLogger _paramLogger = new ParamTrackingLogger();
        #endregion

        #region 속성
        private Axis SelectedAxis { get; set; } = null;

        private AxisCommonParams CommonParam { get; set; } = null;
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

            CommonParam = axisCommonParams;
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
            double oldSpeed = CommonParam.JogLowSpeed;
            double newSpeed = KeyPadHelper.SetLabelDoubleData((Label)sender);
            
            CommonParam.JogLowSpeed = newSpeed;

            _paramLogger.AddChangeHistory($"{SelectedAxis.Name}", "JogLowSpeed", oldSpeed, newSpeed);
        }

        private void lblJogHighSpeedValue_Click(object sender, EventArgs e)
        {
            double oldSpeed = CommonParam.JogHighSpeed;
            double newSpeed = KeyPadHelper.SetLabelDoubleData((Label)sender);

            CommonParam.JogHighSpeed = newSpeed;

            _paramLogger.AddChangeHistory($"{SelectedAxis.Name}", "JogHighSpeed", oldSpeed, newSpeed);
        }

        private void lblMoveToleranceValue_Click(object sender, EventArgs e)
        {
            double oldTolerance = CommonParam.MoveTolerance;
            double newTolerance = KeyPadHelper.SetLabelDoubleData((Label)sender);

            CommonParam.MoveTolerance = newTolerance;

            _paramLogger.AddChangeHistory($"{SelectedAxis.Name}", "MoveTolerance", oldTolerance, newTolerance);
        }

        private void lblNegativeLimitValue_Click(object sender, EventArgs e)
        {
            double oldNegativeLimit = CommonParam.NegativeLimit;
            double newNegativeLimit = KeyPadHelper.SetLabelDoubleData((Label)sender);

            CommonParam.NegativeLimit = newNegativeLimit;

            _paramLogger.AddChangeHistory($"{SelectedAxis.Name}", "MoveTolerance", oldNegativeLimit, newNegativeLimit);
        }

        private void lblPositiveLimitValue_Click(object sender, EventArgs e)
        {
            double oldPositiveLimit = CommonParam.PositiveLimit;
            double newPositiveLimit = KeyPadHelper.SetLabelDoubleData((Label)sender);

            CommonParam.PositiveLimit = newPositiveLimit;

            _paramLogger.AddChangeHistory($"{SelectedAxis.Name}", "MoveTolerance", oldPositiveLimit, newPositiveLimit);
        }

        private void lblHomingTimeOutValue_Click(object sender, EventArgs e)
        {
            double oldHommingTimeOut = CommonParam.HommingTimeOut;
            double newHommingTimeOut = KeyPadHelper.SetLabelDoubleData((Label)sender);

            CommonParam.HommingTimeOut = newHommingTimeOut;

            _paramLogger.AddChangeHistory($"{SelectedAxis.Name}", "MoveTolerance", oldHommingTimeOut, newHommingTimeOut);
        }

        public void WriteChangeLog()
        {
            if (_paramLogger.IsEmpty == false)
            {
                _paramLogger.AddLog($"{SelectedAxis.Name} Motion Parameter changed.");
                _paramLogger.WriteLogToFile();
            }
        }
        #endregion
    }
}
