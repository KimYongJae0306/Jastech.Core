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
using Jastech.Framework.Structure;

namespace Jastech.Framework.Winform.Controls
{
    public partial class MotionParameterVariableControl : UserControl
    {
        #region 필드
        #endregion

        #region 속성
        private Axis SelectedAxis { get; set; } = null;
        public string Name { get; set; } = "";

        public AxisMovingParam MovingParam { get; set; } = null;
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
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
            MovingParam = movingParam.DeepCopy();
            UpdateUI();
        }

        private void InitializeUI()
        {
            grpAxisName.Text = SelectedAxis.Name.ToString() + " Axis Parameter";
        }

        private void UpdateUI()
        {
            lblVelocityValue.Text = MovingParam.Velocity.ToString();
            tempVelocity = MovingParam.Velocity;

            lblAccelerationTimeValue.Text = MovingParam.Acceleration.ToString();
            tempAcceleration = MovingParam.Acceleration;

            lblDecelerationTimeValue.Text = MovingParam.Deceleration.ToString();
            tempDeceleration = MovingParam.Deceleration;

            lblMovingTimeOutValue.Text = MovingParam.MovingTimeOut.ToString();
            tempMovingTimeOut = MovingParam.MovingTimeOut;

            lblAfterWaitTimeValue.Text = MovingParam.AfterWaitTime.ToString();
            tempAferWaitTime = MovingParam.AfterWaitTime;
        }

        public void SetAxis(Axis axis)
        {
            SelectedAxis = axis;
        }

        private double tempVelocity = 0.0;
        private void lblVelocityValue_Click(object sender, EventArgs e)
        {
            tempVelocity = SetLabelDoubleData(sender);
        }

        private double tempAcceleration = 0.0;
        private void lblAccelerationTimeValue_Click(object sender, EventArgs e)
        {
            tempAcceleration = SetLabelDoubleData(sender);
        }

        private double tempDeceleration = 0.0;
        private void lblDecelerationTimeValue_Click(object sender, EventArgs e)
        {
            tempDeceleration = SetLabelDoubleData(sender);
        }

        private double tempMovingTimeOut = 0.0;
        private void lblMovingTimeOutValue_Click(object sender, EventArgs e)
        {
            tempMovingTimeOut = SetLabelDoubleData(sender);
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

        private int tempAferWaitTime = 0;
        private void lblAfterWaitTimeValue_Click(object sender, EventArgs e)
        {
            tempAferWaitTime = SetLabelIntegerData(sender);
        }

        private int SetLabelIntegerData(object sender)
        {
            KeyPadForm keyPadForm = new KeyPadForm();
            keyPadForm.ShowDialog();

            int inputData = Convert.ToInt32(keyPadForm.PadValue);

            Label label = (Label)sender;
            label.Text = inputData.ToString();

            return inputData;
        }

        public AxisMovingParam GetCurrentData()
        {
            AxisMovingParam param = new AxisMovingParam();

            param.Velocity = tempVelocity;
            param.Acceleration = tempAcceleration;
            param.Deceleration = tempDeceleration;

            param.MovingTimeOut = tempMovingTimeOut;
            param.AfterWaitTime = tempAferWaitTime;

            MovingParam = param.DeepCopy();

            return MovingParam;
        }
        #endregion
    }
}
