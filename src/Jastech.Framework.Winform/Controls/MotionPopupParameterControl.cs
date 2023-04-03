using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.Controls
{
    public partial class MotionPopupParameterControl : UserControl
    {
        #region 필드
        private MotionParameterVariableControl motionParameterVariableControl = new MotionParameterVariableControl();
        #endregion

        #region 속성
        public string AxisName { get; set; } = string.Empty;
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
            motionParameterVariableControl.AxisName = AxisName;
            motionParameterVariableControl.Dock = DockStyle.Fill;
            grpAxisName.Controls.Add(motionParameterVariableControl);
        }

        private void InitializeUI()
        {
            grpAxisName.Text = AxisName + " Axis Parameter";
            Invalidate();
        }
        #endregion
    }
}
