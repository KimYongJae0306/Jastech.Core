using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Jastech.Framework.Device.Motions.AxisMovingParam;
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
        private AxisHandler AxisHanlder { get; set; } = null;
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

        public void SetAxisHanlder(AxisHandler axisHandler)
        {
            AxisHanlder = axisHandler;
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
                rdoJogSlowMode.BackColor = Color.DeepSkyBlue;
            }
            else
                rdoJogSlowMode.BackColor = Color.White;
        }

        private void rdoJogFastMode_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoJogFastMode.Checked)
            {
                SetSelectJogSpeedMode(JogSpeedMode.Fast);
                rdoJogFastMode.BackColor = Color.DeepSkyBlue;
            }
            else
                rdoJogFastMode.BackColor = Color.White;
        }

        private void rdoJogMode_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoJogMode.Checked)
            {
                SetSelectJogMode(JogMode.Jog);
                rdoJogMode.BackColor = Color.DeepSkyBlue;
            }
            else
                rdoJogMode.BackColor = Color.White;
        }

        private void rdoIncreaseMode_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoIncreaseMode.Checked)
            {
                SetSelectJogMode(JogMode.Increase);
                rdoIncreaseMode.BackColor = Color.DeepSkyBlue;
            }
            else
                rdoIncreaseMode.BackColor = Color.White;
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
            Axis axis = AxisHanlder.GetAxis(AxisName.X);
            MoveJog(axis, Direction.CCW);
        }

        private void btnJogLeftX_MouseUp(object sender, MouseEventArgs e)
        {
            if (AxisHanlder == null)
                return;

            AxisHanlder.GetAxis(AxisName.X).StopMove();
        }

        private void btnJogRightX_MouseDown(object sender, MouseEventArgs e)
        {
            Axis axis = AxisHanlder.GetAxis(AxisName.X);
            MoveJog(axis, Direction.CW);
        }

        private void btnJogRightX_MouseUp(object sender, MouseEventArgs e)
        {
            if (AxisHanlder == null)
                return;

            AxisHanlder.GetAxis(AxisName.X).StopMove();
        }

        private void btnJogDownY_MouseDown(object sender, MouseEventArgs e)
        {
            Axis axis = AxisHanlder.GetAxis(AxisName.Y);
            MoveJog(axis, Direction.CCW);
        }

        private void btnJogDownY_MouseUp(object sender, MouseEventArgs e)
        {
            if (AxisHanlder == null)
                return;

            AxisHanlder.GetAxis(AxisName.Y).StopMove();
        }

        private void btnJogUpY_MouseDown(object sender, MouseEventArgs e)
        {
            Axis axis = AxisHanlder.GetAxis(AxisName.Y);
            MoveJog(axis, Direction.CW);
        }

        private void btnJogUpY_MouseUp(object sender, MouseEventArgs e)
        {
            if (AxisHanlder == null)
                return;

            AxisHanlder.GetAxis(AxisName.Y).StopMove();
        }

        private void MoveJog(Axis axis, Direction direction)
        {
            if (AxisHanlder == null)
                return;

            if(rdoJogMode.Checked)
            {
                double currentPosition = axis.GetActualPosition();
                double targetPosition = 0.0;
                if (direction == Direction.CW)
                    targetPosition = currentPosition - Convert.ToDouble(lblPitchXYValue.Text);
                else if (direction == Direction.CCW)
                    targetPosition = currentPosition + Convert.ToDouble(lblPitchXYValue.Text);

                axis.MoveTo(targetPosition);
            }
            else if(rdoIncreaseMode.Checked)
            {
                axis.JogMove(direction);
            }
        }
        #endregion
    }
}
