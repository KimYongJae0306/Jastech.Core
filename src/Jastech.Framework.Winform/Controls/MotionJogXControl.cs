using Jastech.Framework.Device.Motions;
using Jastech.Framework.Winform.Forms;
using System;
using System.Windows.Forms;
using static Jastech.Framework.Device.Motions.AxisMovingParam;

namespace Jastech.Framework.Winform.Controls
{
    public partial class MotionJogXControl : UserControl
    {
        #region 속성
        private AxisHandler AxisHanlder { get; set; } = null;

        public JogSpeedMode JogSpeedMode { get; set; } = JogSpeedMode.Slow;

        public JogMode JogMode { get; set; } = JogMode.Jog;

        public double JogPitch { get; set; } = 1.0;
        #endregion

        #region 생성자
        public MotionJogXControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        public void SetAxisHanlder(AxisHandler axisHandler)
        {
            AxisHanlder = axisHandler;
        }

        private void btnJogLeftX_MouseDown(object sender, MouseEventArgs e)
        {
            Axis axis = AxisHanlder.GetAxis(AxisName.X);
            MoveJog(axis, Direction.CW);
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
            MoveJog(axis, Direction.CCW);
        }

        private void btnJogRightX_MouseUp(object sender, MouseEventArgs e)
        {
            if (AxisHanlder == null)
                return;

            AxisHanlder.GetAxis(AxisName.X).StopMove();
        }

        private void btnJogStop_Click(object sender, EventArgs e)
        {
            Axis axisX = AxisHanlder.GetAxis(AxisName.X);
            axisX.StopMove();
        }

        private void MoveJog(Axis axis, Direction direction)
        {
            if (AxisHanlder == null)
                return;

            if (!axis.IsEnable())
            {
                MessageConfirmForm form = new MessageConfirmForm();
                form.Message = axis.Name + " Axis is ServoOff.";
                form.ShowDialog();
                return;
            }

            if (JogSpeedMode == JogSpeedMode.Slow)
            {
                double jogSlowVelocity = axis.AxisCommonParams.JogLowSpeed;
                double jogSlowAcceleration = jogSlowVelocity * 10;
                axis.SetDefaultParameter(jogSlowVelocity, jogSlowAcceleration);
            }
            else if (JogSpeedMode == JogSpeedMode.Fast)
            {
                double jogFastVelocity = axis.AxisCommonParams.JogHighSpeed;
                double jogFastAcceleration = jogFastVelocity * 10;
                axis.SetDefaultParameter(jogFastVelocity, jogFastAcceleration);
            }
            else { }

            if (JogMode == JogMode.Jog)
            {
                double currentPosition = axis.GetActualPosition();
                double targetPosition = 0.0;

                if (direction == Direction.CW)
                    targetPosition = currentPosition - JogPitch;
                else if (direction == Direction.CCW)
                    targetPosition = currentPosition + JogPitch;
                else { }

                axis.StartAbsoluteMove(targetPosition);
            }
            else if (JogMode == JogMode.Increase)
                axis.JogMove(direction);
            else { }
        }
        #endregion
    }
}
