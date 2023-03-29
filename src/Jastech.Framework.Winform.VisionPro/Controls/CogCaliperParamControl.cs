using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cognex.VisionPro.Caliper;
using Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Parameters;

namespace Jastech.Framework.Winform.VisionPro.Controls
{
    public partial class CogCaliperParamControl : UserControl
    {
        #region 필드
        private CogCaliperTool CaliperTool = null;
        #endregion

        #region 속성
        #endregion

        #region 이벤트
        private void CogCaliperParamControl_Load(object sender, EventArgs e)
        {
            IntializeUI();
        }

        private void rdoDarkToLight_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDarkToLight.Checked)
            {
                SetEdgePolarity(CogCaliperPolarityConstants.DarkToLight);
                rdoDarkToLight.BackColor = Color.DarkCyan;
            }
            else
                rdoDarkToLight.BackColor = Color.PaleTurquoise;
        }

        private void rdoLightToDark_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoLightToDark.Checked)
            {
                SetEdgePolarity(CogCaliperPolarityConstants.LightToDark);
                rdoLightToDark.BackColor = Color.DarkCyan;
            }
            else
                rdoLightToDark.BackColor = Color.PaleTurquoise;
        }
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        public CogCaliperParamControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void IntializeUI()
        {
            rdoDarkToLight.Checked = true;
        }
        
        private void SetEdgePolarity(CogCaliperPolarityConstants caliperPolarity)
        {
            if (CaliperTool == null)
                return;

            CaliperTool.RunParams.Edge0Polarity = caliperPolarity;
        }

        public void UpdateData(CogCaliperParam caliperParam)
        {
            if (caliperParam.CaliperTool.RunParams.Edge0Polarity == CogCaliperPolarityConstants.DarkToLight)
                rdoDarkToLight.Checked = true;
            else if (caliperParam.CaliperTool.RunParams.Edge0Polarity == CogCaliperPolarityConstants.LightToDark)
                rdoLightToDark.Checked = true;
            else { }

            lblFilterSizeValue.Text = caliperParam.CaliperTool.RunParams.FilterHalfSizeInPixels.ToString();
            lblEdgeThresholdValue.Text = caliperParam.CaliperTool.RunParams.ContrastThreshold.ToString();
        }
        #endregion
    }
}
