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

namespace Jastech.Framework.Winform.Controls
{
    public partial class MotionParameterVariableControl : UserControl
    {
        #region 필드
        #endregion

        #region 속성
        public string AxisName { get; set; } = string.Empty;
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
        public void UpdateUI()
        {
            lblVelocityValue.Text = "0";
            lblAccelerationTimeValue.Text = "0";
            lblDecelerationTimeValue.Text = "0";

            lblMovingTimeOutValue.Text = "0";
            lblAfterWaitTimeValue.Text = "0";
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
