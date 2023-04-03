using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Jastech.Framework.Device.Motions.MovingParam;
using Jastech.Framework.Device.Motions;
using Jastech.Framework.Winform.Forms;

namespace Jastech.Framework.Winform.Controls
{
    public partial class MotionJogControl : UserControl
    {
        #region 필드
        private JogSpeedMode _jogSpeedMode = JogSpeedMode.Slow;
        private JogMode _jogMode = JogMode.Jog;
        #endregion

        #region 속성
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        public MotionJogControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void MotionJogControl_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void Initialize()
        {
            rdoJogSlowMode.Checked = true;
            rdoJogMode.Checked = true;
        }

        private void SetSelectJogSpeedMode(JogSpeedMode jogSpeedMode)
        {
            _jogSpeedMode = jogSpeedMode;
        }

        private void SetSelectJogMode(JogMode jogMode)
        {
            _jogMode = jogMode;
        }

        private void rdoJogSlowMode_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoJogSlowMode.Checked)
            {
                SetSelectJogSpeedMode(JogSpeedMode.Slow);
                rdoJogSlowMode.BackColor = Color.DarkCyan;
            }
            else
                rdoJogSlowMode.BackColor = Color.PaleTurquoise;
        }

        private void rdoJogFastMode_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoJogFastMode.Checked)
            {
                SetSelectJogSpeedMode(JogSpeedMode.Fast);
                rdoJogFastMode.BackColor = Color.DarkCyan;
            }
            else
                rdoJogFastMode.BackColor = Color.PaleTurquoise;
        }

        private void rdoJogMode_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoJogMode.Checked)
            {
                SetSelectJogMode(JogMode.Jog);
                rdoJogMode.BackColor = Color.DarkCyan;
            }
            else
                rdoJogMode.BackColor = Color.PaleTurquoise;
        }

        private void rdoIncreaseMode_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoIncreaseMode.Checked)
            {
                SetSelectJogMode(JogMode.Increase);
                rdoIncreaseMode.BackColor = Color.DarkCyan;
            }
            else
                rdoIncreaseMode.BackColor = Color.PaleTurquoise;
        }

        private void lblPitchXYValue_Click(object sender, EventArgs e)
        {
            SetLabelDoubleData(sender);
        }

        private void lblPitchZValue_Click(object sender, EventArgs e)
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

        private void btnJogLeftX_MouseDown(object sender, MouseEventArgs e)
        {
            MoveJog(0, Direction.CCW);
        }

        private void btnJogLeftX_MouseUp(object sender, MouseEventArgs e)
        {
            MoveStop(0);
        }

        private void btnJogRightX_MouseDown(object sender, MouseEventArgs e)
        {
            MoveJog(0, Direction.CW);
        }

        private void btnJogRightX_MouseUp(object sender, MouseEventArgs e)
        {

            MoveStop(0);
        }

        private void btnJogDownY_MouseDown(object sender, MouseEventArgs e)
        {
            MoveJog(1, Direction.CCW);
        }

        private void btnJogDownY_MouseUp(object sender, MouseEventArgs e)
        {
            MoveStop(1);
        }

        private void btnJogUpY_MouseDown(object sender, MouseEventArgs e)
        {
            MoveJog(1, Direction.CW);
        }

        private void btnJogUpY_MouseUp(object sender, MouseEventArgs e)
        {
            MoveStop(1);
        }

        private void MoveJog(int axisNumber, Direction direction)
        {
            if (rdoJogMode.Checked)
            {
                double currentPosition = DeviceManager.Instance().GetMotion().GetActualPosition(axisNumber);
                double targetPosition = 0.0;

                if (direction == Direction.CW)
                    targetPosition = currentPosition - Convert.ToDouble(lblPitchXYValue.Text);
                else if (direction == Direction.CCW)
                    targetPosition = currentPosition + Convert.ToDouble(lblPitchXYValue.Text);

                DeviceManager.Instance().GetMotion().MoveTo(axisNumber, targetPosition, 10, 10);
            }
            else if (rdoIncreaseMode.Checked)
            {
                DeviceManager.Instance().GetMotion().JogMove(axisNumber, direction);
            }
            else { }
        }

        private void MoveStop(int axisNumber)
        {
            DeviceManager.Instance().GetMotion().StopMove(axisNumber);
        }
        #endregion
    }
}
