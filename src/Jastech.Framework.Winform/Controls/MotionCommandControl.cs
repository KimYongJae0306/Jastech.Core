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
    public partial class MotionCommandControl : UserControl
    {
        #region 필드
        #endregion

        #region 속성
        public string AxisName { get; set; } = string.Empty;
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        public MotionCommandControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void MotionCommandControl_Load(object sender, EventArgs e)
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            lblAxisName.Text = AxisName;
        }
        #endregion

        
    }
}
