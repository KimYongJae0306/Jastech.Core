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
using Jastech.Framework.Winform.Helper;

namespace Jastech.Framework.Winform.Controls
{
    public partial class MotionParameterVariableControl : UserControl
    {
        #region 필드
        #endregion

        #region 속성
        private Axis SelectedAxis { get; set; } = null;

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
            MovingParam.Velocity = KeyPadHelper.SetLabelDoubleData((Label)sender);
        }

        private void lblAccelerationTimeValue_Click(object sender, EventArgs e)
        {
            MovingParam.Acceleration = KeyPadHelper.SetLabelDoubleData((Label)sender);
        }

        private void lblDecelerationTimeValue_Click(object sender, EventArgs e)
        {
            MovingParam.Deceleration = KeyPadHelper.SetLabelDoubleData((Label)sender);
        }

        private void lblMovingTimeOutValue_Click(object sender, EventArgs e)
        {
            MovingParam.MovingTimeOut = KeyPadHelper.SetLabelDoubleData((Label)sender);
        }

        private void lblAfterWaitTimeValue_Click(object sender, EventArgs e)
        {
            MovingParam.AfterWaitTime = KeyPadHelper.SetLabelIntegerData((Label)sender);
        }


        #endregion
    }
}
