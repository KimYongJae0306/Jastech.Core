using Jastech.Framework.Device.Motions;
using Jastech.Framework.Util.Helper;
using Jastech.Framework.Winform.Helper;
using System;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.Controls
{
    public partial class MotionParameterVariableControl : UserControl
    {
        #region 속성
        private Axis SelectedAxis { get; set; } = null;

        public AxisMovingParam MovingParam { get; set; } = null;
        #endregion

        #region 생성자
        public MotionParameterVariableControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void MotionParameterVariableControl_Load(object sender, EventArgs e)
        {
            InitializeUI();
        }

        public void UpdateData(AxisMovingParam movingParam)
        {
            if (movingParam == null)
                return;

            MovingParam = movingParam;
            UpdateUI();
        }

        private void InitializeUI()
        {
            grpAxisName.Text = SelectedAxis.Name.ToString() + " Axis Parameter";
        }

        private void UpdateUI()
        {
            lblVelocityValue.Text = MovingParam.Velocity.ToString();
            lblAccelerationTimeValue.Text = MovingParam.Acceleration.ToString();
            lblDecelerationTimeValue.Text = MovingParam.Deceleration.ToString();
            lblMovingTimeOutValue.Text = MovingParam.MovingTimeOut.ToString();
            lblAfterWaitTimeValue.Text = MovingParam.AfterWaitTime.ToString();
        }

        public void SetAxis(Axis axis)
        {
            SelectedAxis = axis;
        }

        public AxisMovingParam GetCurrentData()
        {
            AxisMovingParam param = new AxisMovingParam();

            param.Velocity = MovingParam.Velocity;
            param.Acceleration = MovingParam.Acceleration;
            param.Deceleration = MovingParam.Deceleration;

            param.MovingTimeOut = MovingParam.MovingTimeOut;
            param.AfterWaitTime = MovingParam.AfterWaitTime;

            return param.DeepCopy();
        }

        private void lblVelocityValue_Click(object sender, EventArgs e)
        {
            double oldVelocity = MovingParam.Velocity;
            double newVelocity = KeyPadHelper.SetLabelDoubleData((Label)sender);

            MovingParam.Velocity = newVelocity;

            ParamTrackingLogger.AddChangeHistory($"{SelectedAxis.Name}", "Velocity", oldVelocity, newVelocity);
        }

        private void lblAccelerationTimeValue_Click(object sender, EventArgs e)
        {
            double oldAcceleration = MovingParam.Acceleration;
            double newAcceleration = KeyPadHelper.SetLabelDoubleData((Label)sender);

            MovingParam.Acceleration = newAcceleration;

            ParamTrackingLogger.AddChangeHistory($"{SelectedAxis.Name}", "Acceleration", oldAcceleration, newAcceleration);
        }

        private void lblDecelerationTimeValue_Click(object sender, EventArgs e)
        {
            double oldDeceleration = MovingParam.Deceleration;
            double newDeceleration = KeyPadHelper.SetLabelDoubleData((Label)sender);

            MovingParam.Deceleration = newDeceleration;

            ParamTrackingLogger.AddChangeHistory($"{SelectedAxis.Name}", "Acceleration", oldDeceleration, newDeceleration);
        }

        private void lblMovingTimeOutValue_Click(object sender, EventArgs e)
        {
            double oldMovingTimeOut = MovingParam.MovingTimeOut;
            double newMovingTimeOut = KeyPadHelper.SetLabelDoubleData((Label)sender);

            MovingParam.MovingTimeOut = newMovingTimeOut;

            ParamTrackingLogger.AddChangeHistory($"{SelectedAxis.Name}", "MovingTimeOut", oldMovingTimeOut, newMovingTimeOut);
        }

        private void lblAfterWaitTimeValue_Click(object sender, EventArgs e)
        {
            int oldAfterWaitTime = MovingParam.AfterWaitTime;
            int newAfterWaitTime = KeyPadHelper.SetLabelIntegerData((Label)sender);

            MovingParam.AfterWaitTime = newAfterWaitTime;

            ParamTrackingLogger.AddChangeHistory($"{SelectedAxis.Name}", "MovingTimeOut", oldAfterWaitTime, newAfterWaitTime);
        }

        public void WriteChangeLog()
        {
            if (ParamTrackingLogger.IsEmpty == false)
            {
                ParamTrackingLogger.AddLog($"{SelectedAxis.Name} Motion Variable changed.");
                ParamTrackingLogger.WriteLogToFile();
            }
        }
        #endregion
    }
}
