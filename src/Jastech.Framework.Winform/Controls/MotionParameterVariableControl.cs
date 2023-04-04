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
    public partial class MotionParameterVariableControl : UserControl
    {
        #region 필드
        #endregion

        #region 속성
        private Axis SelectedAxis { get; set; } = null;
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

        private void InitializeUI()
        {
            grpAxisName.Text = SelectedAxis.Name.ToString() + " Axis Parameter";
        }

        public void SetAxis(Axis axis)
        {
            SelectedAxis = axis;
        }

        public void UpdateUI(Device.Motions.AxisMovingParam movingParam)
        {
            lblVelocityValue.Text = movingParam.Velocity.ToString();
            lblAccelerationTimeValue.Text = movingParam.Acceleration.ToString();
            lblDecelerationTimeValue.Text = movingParam.Deceleration.ToString();

            lblMovingTimeOutValue.Text = movingParam.MovingTimeOut.ToString();
            lblAfterWaitTimeValue.Text = movingParam.AferWaitTime.ToString();
        }

        public void SetParameter()
        {
            double a = Convert.ToDouble(lblVelocityValue.Text);
            double b = Convert.ToDouble(lblAccelerationTimeValue.Text);
            double c = Convert.ToDouble(lblDecelerationTimeValue.Text);

            double d = Convert.ToDouble(lblMovingTimeOutValue.Text);
            double e = Convert.ToDouble(lblAfterWaitTimeValue.Text);
        }

        private void Value_Changed(object sender, EventArgs e)
        {
            SetLabelDoubleData(sender);
        }

        private void SetLabelDoubleData(object sender)
        {
            KeyPadForm keyPadForm = new KeyPadForm();
            keyPadForm.ShowDialog();

            double inputData = keyPadForm.PadValue;

            Label label = (Label)sender;
            label.Text = inputData.ToString();
        }
        #endregion
    }
}
