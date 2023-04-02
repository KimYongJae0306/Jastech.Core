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

namespace Jastech.Framework.Winform.Controls
{
    public partial class JogControl : UserControl
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
        public JogControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
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

        }

        private void lblPitchZValue_Click(object sender, EventArgs e)
        {

        }

        private void btnJogLeftX_MouseDown(object sender, MouseEventArgs e)
        {
            //MoveJog(eAxis.Axis_X, Direction.CCW);
        }

        private void btnJogLeftX_MouseUp(object sender, MouseEventArgs e)
        {
            //MoveStop(eAxis.Axis_X);
        }

        private void btnJogRightX_MouseDown(object sender, MouseEventArgs e)
        {
            //MoveJog(eAxis.Axis_X, Direction.CW);
        }

        private void btnJogRightX_MouseUp(object sender, MouseEventArgs e)
        {
            
            //MoveStop(eAxis.Axis_X);
        }

        private void btnJogDownY_MouseDown(object sender, MouseEventArgs e)
        {
            //MoveJog(eAxis.Axis_Y, Direction.CCW);
        }

        private void btnJogDownY_MouseUp(object sender, MouseEventArgs e)
        {
            //MoveStop(eAxis.Axis_Y);
        }

        private void btnJogUpY_MouseDown(object sender, MouseEventArgs e)
        {
            //MoveJog(eAxis.Axis_Y, Direction.CW);
        }

        private void btnJogUpY_MouseUp(object sender, MouseEventArgs e)
        {
            //MoveStop(eAxis.Axis_Y);
        }

        //private void MoveJog(eAxis axis, Direction direction)
        //{

        //}

        //private void MoveStop(eAxis axis)
        //{

        //}
        #endregion
    }
}
