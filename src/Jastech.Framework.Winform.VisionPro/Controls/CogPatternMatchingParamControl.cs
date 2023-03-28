using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cognex.VisionPro;
using Cognex.VisionPro.PMAlign;
using Jastech.Framework.Imaging.VisionPro.VisionAlgorithms;
using Jastech.Framework.Imaging.VisionPro.VisionAlgorithms.Parameters;

namespace Jastech.Framework.Winform.VisionPro.Controls
{
    public partial class CogPatternMatchingParamControl : UserControl
    {

        #region 필드
        private CogPatternMatchingParam MatchingParam;
        #endregion

        #region 속성
        #endregion

        #region 이벤트
        public SetTrainDelegate SetTrainEventHandler;
        #endregion

        #region 델리게이트
        public delegate void SetTrainDelegate();
        #endregion

        #region 생성자
        #endregion

        #region 메서드
        #endregion

        public ICogImage TargetImage { get; set; } = null;

        public CogPatternMatchingParamControl()
        {
            InitializeComponent();
        }

        private void lblAddPattern_Click(object sender, EventArgs e)
        {
            SetTrainEventHandler?.Invoke();


        }

        public void UpdateData(CogPatternMatchingParam matchingParam)
        {
            nupdnMatchScore.Value = (decimal)matchingParam.Score;
            nupdnMaxAngle.Value = (decimal)matchingParam.MaxAngle;

            cogPatternDisplay.Image = matchingParam.MatchingTool.Pattern.TrainImage;
        }

        private void lblInspection_Click(object sender, EventArgs e)
        {
            
        }
    }
}
