using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jastech.Framework.Device.Motions;

namespace Jastech.Framework.Winform.Controls
{
    public partial class MotionParameterControl : UserControl
    {
        #region 필드
        private MotionParameterCommonControl motionParameterCommonControl = new MotionParameterCommonControl();
        private MotionParameterVariableControl motionParameterVariableControl = new MotionParameterVariableControl();
        #endregion

        #region 속성
        private Axis SelectedAxis { get; set; } = null;
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        public MotionParameterControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void MotionParameterControl_Load(object sender, EventArgs e)
        {
            AddControl();
            IntializeUI();
        }

        private void AddControl()
        {
            motionParameterCommonControl.AxisName = SelectedAxis.Name;
            motionParameterCommonControl.Dock = DockStyle.Fill;
            tlpMotionParameter.Controls.Add(motionParameterCommonControl);
            
            motionParameterVariableControl.AxisName = SelectedAxis.Name;
            motionParameterVariableControl.Dock = DockStyle.Fill;
            tlpMotionParameter.Controls.Add(motionParameterVariableControl);
        }

        private void IntializeUI()
        {
            grpAxisName.Text = SelectedAxis.Name.ToString() + " Axis Parameter";
            Invalidate();
        }

        public void SetAxis(Axis axis)
        {
            SelectedAxis = axis;
        }

        public void UpdateUI()
        {
            motionParameterCommonControl.UpdateUI();
            motionParameterVariableControl.UpdateUI();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Size textSize = TextRenderer.MeasureText(Text, Font);

            Rectangle clientRectangle = e.ClipRectangle;

            clientRectangle.Y += textSize.Height / 2;

            clientRectangle.Height -= textSize.Height / 2;

            ControlPaint.DrawBorder(e.Graphics, clientRectangle, Color.Black, ButtonBorderStyle.Solid);

            Rectangle textRectangle = e.ClipRectangle;

            textRectangle.X += 6;

            textRectangle.Width = textSize.Width + 1;
            textRectangle.Height = textSize.Height;

            e.Graphics.FillRectangle(new SolidBrush(BackColor), textRectangle);

            e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), textRectangle);

            //base.OnPaint(e);
        }
        #endregion
    }
}
