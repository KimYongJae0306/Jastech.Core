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
        private CogCaliperParam CurrentParam;
        private Color _selectedColor = new Color();
        private Color _nonSelectedColor = new Color();
        #endregion

        #region 속성
        #endregion

        #region 이벤트
        
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
        private void CogCaliperParamControl_Load(object sender, EventArgs e)
        {
            IntializeUI();
        }

        private void rdoDarkToLight_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDarkToLight.Checked)
            {
                SetEdgePolarity(CogCaliperPolarityConstants.DarkToLight);
                rdoDarkToLight.BackColor = _selectedColor;
            }
            else
                rdoDarkToLight.BackColor = _nonSelectedColor;
        }

        private void rdoLightToDark_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoLightToDark.Checked)
            {
                SetEdgePolarity(CogCaliperPolarityConstants.LightToDark);
                rdoLightToDark.BackColor = _selectedColor;
            }
            else
                rdoLightToDark.BackColor = _nonSelectedColor;
        }

        private void IntializeUI()
        {
            _selectedColor = Color.FromArgb(104, 104, 104);
            _nonSelectedColor = Color.FromArgb(52, 52, 52);
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

            CurrentParam = caliperParam;
        }

        public CogCaliperParam GetCurrentParam()
        {
            return CurrentParam;
        }
        #endregion
    }
}
