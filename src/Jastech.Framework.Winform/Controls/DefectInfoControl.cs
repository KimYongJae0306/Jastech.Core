using Jastech.Framework.Structure.Defect;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static Jastech.Framework.Structure.Defect.DefectDefine;

namespace Jastech.Framework.Winform.Controls
{
    public partial class DefectInfoControl : UserControl
    {
        #region 속성
        ElectrodeDefectInfo DefectInfo { get; set; }
        #endregion

        #region 이벤트
        public event ControlClickedEvent ControlClickedHandler;
        #endregion

        #region 델리게이트
        public delegate void ControlClickedEvent(int index);
        #endregion

        #region 생성자
        public DefectInfoControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        public void SetDefectInfo(ElectrodeDefectInfo defectInfo)
        {
            DefectInfo = defectInfo;
            lblCamDirection.Text = $"{DefectInfo.CamDirection}Cam";
            lblDefectType.Text = $"{DefectInfo.DefectType}";
            lblDefectType.ForeColor = Colors[DefectInfo.DefectType];
            lblDefectInfo.Text = $"{DefectInfo.GetCoord()}\r\n{DefectInfo.GetSize()}";

            string imagePath = DefectInfo.GetFeatureValue(FeatureTypes.LocalImagePath);
            if (imagePath != null)
                pbxCropImage.Image = new Bitmap(imagePath);
        }

        private void ClickControlEvent(object sender, EventArgs e)
        {
            ControlClickedHandler?.Invoke(DefectInfo.Index);
        }
        #endregion
    }
}
