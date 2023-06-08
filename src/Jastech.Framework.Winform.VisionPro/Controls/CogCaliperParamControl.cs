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
using Cognex.VisionPro;
using Jastech.Framework.Winform.Forms;

namespace Jastech.Framework.Winform.VisionPro.Controls
{
    public partial class CogCaliperParamControl : UserControl
    {
        #region 필드
        private VisionProCaliperParam CurrentParam;
        private Color _selectedColor = new Color();
        private Color _nonSelectedColor = new Color();
        #endregion

        #region 속성
        #endregion

        #region 이벤트
        public GetOriginImageDelegate GetOriginImageHandler;

        public TestActionDelegate TestActionEvent;
        #endregion

        #region 델리게이트
        public delegate ICogImage GetOriginImageDelegate();

        public delegate void TestActionDelegate();
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

        private void IntializeUI()
        {
            _selectedColor = Color.FromArgb(104, 104, 104);
            _nonSelectedColor = Color.FromArgb(52, 52, 52);
        }

        private void lblDarkToLight_Click(object sender, EventArgs e)
        {
            CurrentParam.CaliperTool.RunParams.Edge0Polarity = CogCaliperPolarityConstants.DarkToLight;

            lblDarkToLight.BackColor = _selectedColor;
            lblLightToDark.BackColor = _noneSelectedColor;
        }

        private void lblLightToDark_Click(object sender, EventArgs e)
        {
            CurrentParam.CaliperTool.RunParams.Edge0Polarity = CogCaliperPolarityConstants.LightToDark;

            lblDarkToLight.BackColor = _noneSelectedColor;
            lblLightToDark.BackColor = _selectedColor;
        }

        private void lblFilterSizeValue_Click(object sender, EventArgs e)
        {
            int filterSize = SetLabelIntegerData(sender);
            if(filterSize > 0)
                CurrentParam.CaliperTool.RunParams.FilterHalfSizeInPixels = filterSize;
        }

        private void lblEdgeThresholdValue_Click(object sender, EventArgs e)
        {
            int edgeThreshold = SetLabelIntegerData(sender);
            CurrentParam.CaliperTool.RunParams.ContrastThreshold = edgeThreshold;
        }

        private int SetLabelIntegerData(object sender)
        {
            Label lbl = sender as Label;
            int prevData = Convert.ToInt32(lbl.Text);

            KeyPadForm keyPadForm = new KeyPadForm();
            keyPadForm.PreviousValue = (double)prevData;
            keyPadForm.ShowDialog();

            int inputData = Convert.ToInt16(keyPadForm.PadValue);

            Label label = (Label)sender;
            label.Text = inputData.ToString();

            return inputData;
        }

        public void UpdateData(VisionProCaliperParam caliperParam)
        {
            CurrentParam = caliperParam;

            if (caliperParam.CaliperTool.RunParams.Edge0Polarity == CogCaliperPolarityConstants.DarkToLight)
            {
                lblDarkToLight.BackColor = _selectedColor;
                lblLightToDark.BackColor = _nonSelectedColor;
            }
            else if (caliperParam.CaliperTool.RunParams.Edge0Polarity == CogCaliperPolarityConstants.LightToDark)
            {
                lblDarkToLight.BackColor = _nonSelectedColor;
                lblLightToDark.BackColor = _selectedColor;
            }
            else if (caliperParam.CaliperTool.RunParams.Edge0Polarity == CogCaliperPolarityConstants.DontCare)
            {
                lblDarkToLight.BackColor = _nonSelectedColor;
                lblLightToDark.BackColor = _nonSelectedColor;
            }
            else { }

            lblFilterSizeValue.Text = caliperParam.CaliperTool.RunParams.FilterHalfSizeInPixels.ToString();
            lblEdgeThresholdValue.Text = caliperParam.CaliperTool.RunParams.ContrastThreshold.ToString();
        }

        public VisionProCaliperParam GetCurrentParam()
        {
            return CurrentParam;
        }

        private void lblTest_Click(object sender, EventArgs e)
        {
            TestActionEvent?.Invoke();
        }
        #endregion
    }
}
