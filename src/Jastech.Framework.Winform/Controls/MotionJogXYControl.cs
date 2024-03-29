﻿using Jastech.Framework.Device.Motions;
using Jastech.Framework.Winform.Forms;
using System;
using System.Windows.Forms;
using static Jastech.Framework.Device.Motions.AxisMovingParam;

namespace Jastech.Framework.Winform.Controls
{
    public partial class MotionJogXYControl : UserControl
    {
        #region 속성
        private AxisHandler AxisHandler { get; set; } = null;

        public JogSpeedMode JogSpeedMode { get; set; } = JogSpeedMode.Slow;

        public JogMode JogMode { get; set; } = JogMode.Jog;

        public double JogPitch { get; set; } = 1.0;
        #endregion

        #region 생성자
        public MotionJogXYControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        public void SetAxisHandler(AxisHandler axisHandler)
        {
            AxisHandler = axisHandler;
        }

        private void btnJogLeftX_Click(object sender, EventArgs e)
        {
            if (JogMode == JogMode.Increase)
                return;

            Axis axis = AxisHandler.GetAxis(AxisName.X);
            MoveJog(axis, Direction.CW);
        }

        private void btnJogLeftX_MouseDown(object sender, MouseEventArgs e)
        {
            if (JogMode == JogMode.Jog)
                return;

            Axis axis = AxisHandler.GetAxis(AxisName.X);
            MoveJog(axis, Direction.CW);
        }

        private void btnJogLeftX_MouseUp(object sender, MouseEventArgs e)
        {
            if (JogMode == JogMode.Jog)
                return;

            AxisHandler.GetAxis(AxisName.X).StopMove();
        }

        private void btnJogRightX_Click(object sender, EventArgs e)
        {
            if (JogMode == JogMode.Increase)
                return;

            Axis axis = AxisHandler.GetAxis(AxisName.X);
            MoveJog(axis, Direction.CCW);
        }

        private void btnJogRightX_MouseDown(object sender, MouseEventArgs e)
        {
            if (JogMode == JogMode.Jog)
                return;

            Axis axis = AxisHandler.GetAxis(AxisName.X);
            MoveJog(axis, Direction.CCW);
        }

        private void btnJogRightX_MouseUp(object sender, MouseEventArgs e)
        {
            if (JogMode == JogMode.Jog)
                return;

            AxisHandler.GetAxis(AxisName.X).StopMove();
        }

        private void btnJogDownY_Click(object sender, EventArgs e)
        {
            if (JogMode == JogMode.Increase)
                return;

            Axis axis = AxisHandler.GetAxis(AxisName.Y);
            MoveJog(axis, Direction.CW);
        }

        private void btnJogDownY_MouseDown(object sender, MouseEventArgs e)
        {
            if (JogMode == JogMode.Jog)
                return;

            Axis axis = AxisHandler.GetAxis(AxisName.Y);
            MoveJog(axis, Direction.CW);
        }

        private void btnJogDownY_MouseUp(object sender, MouseEventArgs e)
        {
            if (JogMode == JogMode.Jog)
                return;

            AxisHandler.GetAxis(AxisName.Y).StopMove();
        }

        private void btnJogUpY_Click(object sender, EventArgs e)
        {
            if (JogMode == JogMode.Increase)
                return;

            Axis axis = AxisHandler.GetAxis(AxisName.Y);
            MoveJog(axis, Direction.CCW);
        }

        private void btnJogUpY_MouseDown(object sender, MouseEventArgs e)
        {
            if (JogMode == JogMode.Jog)
                return;

            Axis axis = AxisHandler.GetAxis(AxisName.Y);
            MoveJog(axis, Direction.CCW);
        }

        private void btnJogUpY_MouseUp(object sender, MouseEventArgs e)
        {
            if (JogMode == JogMode.Jog)
                return;

            AxisHandler.GetAxis(AxisName.Y).StopMove();
        }

        private void btnJogStop_Click(object sender, EventArgs e)
        {
            Axis axisX = AxisHandler.GetAxis(AxisName.X);
            axisX.StopMove();

            Axis axisY = AxisHandler.GetAxis(AxisName.Y);
            axisY.StopMove();
        }

        private void MoveJog(Axis axis, Direction direction)
        {
            if (AxisHandler == null)
                return;
            if (axis == null)
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
