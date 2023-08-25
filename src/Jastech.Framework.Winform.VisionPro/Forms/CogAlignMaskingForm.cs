using Cognex.VisionPro;
using Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Parameters;
using System;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.VisionPro.Forms
{
    public partial class CogAlignMaskingForm : Form
    {
        #region 필드
        #endregion

        #region 속성
        private ICogImage OriginImage { get; set; }

        private VisionProPatternMatchingParam OriginParam { get; set; }

        private VisionProPatternMatchingParam CurrentParam { get; set; }
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        public CogAlignMaskingForm()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void CogAlignMaskingForm_Load(object sender, EventArgs e)
        {
            //cogImageMaskEdit.Image = CurrentParam.GetTrainImage();
            Reset();
        }

        public void Initialize(VisionProPatternMatchingParam param)
        {
            OriginParam = param;
        }

        private void lblApply_Click(object sender, EventArgs e)
        {
            var image = (CogImage8Grey)cogImageMaskEdit.MaskImage.CopyBase(CogImageCopyModeConstants.SharePixels);
            CurrentParam.TrainImageMask(image);
            CurrentParam.GetTool().Pattern.Train();
            DialogResult = DialogResult.OK;
        }

        private void lblCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void lblReset_Click(object sender, EventArgs e)
        {
            if(CurrentParam != null)
                CurrentParam.Dispose();

            Initialize(OriginParam);

            Reset();
        }

        private void Reset()
        {
            cogImageMaskEdit.Image = CurrentParam.GetTrainedPatternImage();
            cogImageMaskEdit.MaskImage = CurrentParam.GetTrainImageMask();
        }

        public VisionProPatternMatchingParam GetCurrentParam()
        {
            return CurrentParam;
        }
        #endregion
    }
}
