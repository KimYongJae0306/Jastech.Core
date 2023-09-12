using Cognex.VisionPro;
using Cognex.VisionPro.Caliper;
using Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Parameters;
using Jastech.Framework.Util.Helper;
using Jastech.Framework.Winform.Helper;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.VisionPro.Controls
{
    public partial class CogCaliperParamControl : UserControl
    {
        #region 필드
        private Color _selectedColor = new Color();

        private Color _nonSelectedColor = new Color();
        #endregion

        #region 속성
        private VisionProCaliperParam CurrentParam;
        #endregion

        #region 이벤트
        public GetOriginImageDelegate GetOriginImageHandler;

        public TestActionDelegate TestActionEvent;

        public event ParameterValueChangedEventHandler CaliperParamChanged;
        #endregion

        #region 델리게이트
        public delegate ICogImage GetOriginImageDelegate();

        public delegate void TestActionDelegate();

        public delegate void ParameterValueChangedEventHandler(string component, string parameter, double oldValue, double newValue);
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
            var old0Polarity = CurrentParam.CaliperTool.RunParams.Edge0Polarity;
            var new0Polarity = CogCaliperPolarityConstants.DarkToLight;

            if (old0Polarity != new0Polarity)
            {
                CurrentParam.CaliperTool.RunParams.Edge0Polarity = new0Polarity;
                ParamTrackingLogger.AddChangeHistory("Caliper Param", "Edge0Polarity", old0Polarity, new0Polarity);
            }

            lblDarkToLight.BackColor = _selectedColor;
            lblLightToDark.BackColor = _nonSelectedColor;
        }

        private void lblLightToDark_Click(object sender, EventArgs e)
        {
            var old0Polarity = CurrentParam.CaliperTool.RunParams.Edge0Polarity;
            var new0Polarity = CogCaliperPolarityConstants.LightToDark;

            if (old0Polarity != new0Polarity)
            {
                CurrentParam.CaliperTool.RunParams.Edge0Polarity = new0Polarity;
                ParamTrackingLogger.AddChangeHistory("Caliper Param", "Edge0Polarity", old0Polarity, new0Polarity);
            }

            lblDarkToLight.BackColor = _nonSelectedColor;
            lblLightToDark.BackColor = _selectedColor;
        }

        private void lblFilterSizeValue_Click(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                int oldFilterSize = Convert.ToInt32(label.Text);
                int newFilterSize = Math.Abs(KeyPadHelper.SetLabelIntegerData(label));

                CurrentParam.CaliperTool.RunParams.FilterHalfSizeInPixels = newFilterSize;
                CaliperParamChanged?.Invoke("Caliper Param", label.Name.Replace("lbl", ""), oldFilterSize, newFilterSize);
            }
        }

        private void lblEdgeThresholdValue_Click(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                int oldEdgeThreshold = Convert.ToInt32(label.Text);
                int newEdgeThreshold = Math.Abs(KeyPadHelper.SetLabelIntegerData(label));

                CurrentParam.CaliperTool.RunParams.ContrastThreshold = newEdgeThreshold;
                CaliperParamChanged?.Invoke("Caliper Param", label.Name.Replace("lbl",""), oldEdgeThreshold, newEdgeThreshold);
            }
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
