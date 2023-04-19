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
using Jastech.Framework.Device.LAFCtrl;

namespace Jastech.Framework.Winform.Controls
{
    public partial class MotionJogControl : UserControl
    {
        #region 필드
        #endregion

        #region 속성
        private AxisHandler AxisHanlder { get; set; } = null;

        public JogSpeedMode JogSpeedMode { get; set; } = JogSpeedMode.Slow;

        public JogMode JogMode { get; set; } = JogMode.Jog;

        public double JogPitch { get; set; } = 1.0;
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
        public void SetAxisHanlder(AxisHandler axisHandler)
        {
            AxisHanlder = axisHandler;
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
            MoveJog(axis, Direction.CW);
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
            MoveJog(axis, Direction.CCW);
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

            if (JogMode == JogMode.Jog)
            {
                double currentPosition = axis.GetActualPosition();
                double targetPosition = 0.0;

                if (direction == Direction.CW)
                    targetPosition = currentPosition - JogPitch;
                else if (direction == Direction.CCW)
                    targetPosition = currentPosition + JogPitch;
                else { }

                axis.MoveTo(targetPosition);
            }
            else if (JogMode == JogMode.Increase)
                axis.JogMove(direction);
            else { }
        }
        #endregion
    }
}
