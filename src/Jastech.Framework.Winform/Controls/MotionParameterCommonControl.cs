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

        public void SetAxis(Axis axis)
        {
            SelectedAxis = axis;
        }

        public void UpdateUI(Structure.TeachingPosition teachingPosition)
        {
            lblJogLowSpeedValue.Text = "0";
            lblJogHighSpeedValue.Text = "0";
            lblMoveToleranceValue.Text = "0";

            lblNegativeLimitValue.Text = "0";
            lblPositiveLimitValue.Text = "0";
            lblHomingTimeOutValue.Text = "0";
        }

        public void SetParameter()
        {
            double a = Convert.ToDouble(lblJogLowSpeedValue.Text);
            double b = Convert.ToDouble(lblJogHighSpeedValue.Text);
            double c = Convert.ToDouble(lblMoveToleranceValue.Text);

            double d = Convert.ToDouble(lblNegativeLimitValue.Text);
            double e = Convert.ToDouble(lblPositiveLimitValue.Text);
            double f = Convert.ToDouble(lblHomingTimeOutValue.Text);
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
