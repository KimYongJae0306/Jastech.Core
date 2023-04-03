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
    public partial class MotionPopupParameterControl : UserControl
    {
        #region 필드
        private MotionParameterVariableControl motionParameterVariableControl = new MotionParameterVariableControl();
        #endregion

        #region 속성
        private Axis selectedAxis { get; set; } = null;
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        public MotionPopupParameterControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void MotionPopupParameterControl_Load(object sender, EventArgs e)
        {
            AddControl();
            InitializeUI();
        }

        private void AddControl()
        {
            motionParameterVariableControl.AxisName = selectedAxis.Name;
            motionParameterVariableControl.Dock = DockStyle.Fill;
            grpAxisName.Controls.Add(motionParameterVariableControl);
        }

        private void InitializeUI()
        {
            grpAxisName.Text = selectedAxis.Name + " Axis Parameter";
            Invalidate();
        }

        public void SetAxis(Axis axis)
        {
            selectedAxis = axis;
        }
        #endregion
    }
}
