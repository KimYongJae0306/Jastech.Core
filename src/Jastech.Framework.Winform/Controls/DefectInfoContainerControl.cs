using Jastech.Framework.Structure.Defect;
using System.Drawing;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.Controls
{
    public partial class DefectInfoContainerControl : UserControl
    {
        #region 속성
        public bool isVertical = true;
        #endregion

        #region 이벤트
        public event SelectedIndexChangedEvent SelectedDefectChangedHandler;
        #endregion

        #region 델리게이트
        public delegate void SelectedIndexChangedEvent(int index);
        #endregion

        #region 생성자
        public DefectInfoContainerControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        public void AddDefectInfo(DefectInfo defectInfo)
        {
            DefectInfoControl defectInfoControl = new DefectInfoControl();
            defectInfoControl.SetDefectInfo(defectInfo);

            Point controlLocation = new Point();
            Size controlSize = new Size();
            if (isVertical)
            {
                int drawingCount = Width / defectInfoControl.Width;
                if (drawingCount == 0) drawingCount = 1;
                controlSize.Width = pnlContainer.Width / drawingCount - 20;
                controlSize.Height = defectInfoControl.Height;
                controlLocation.X = (pnlContainer.Controls.Count % drawingCount) * controlSize.Width;
                controlLocation.Y = (pnlContainer.Controls.Count / drawingCount) * controlSize.Height + pnlContainer.AutoScrollPosition.Y;
            }
            else
            {
                int drawingCount = Height / defectInfoControl.Height;
                if (drawingCount == 0) drawingCount = 1;
                controlSize.Width = defectInfoControl.Width;
                controlSize.Height = pnlContainer.Height / drawingCount - 20;
                controlLocation.X = (pnlContainer.Controls.Count / drawingCount) * (defectInfoControl.Width / drawingCount) + pnlContainer.AutoScrollPosition.X;
                controlLocation.Y = (pnlContainer.Controls.Count % drawingCount) * (defectInfoControl.Height / drawingCount);
            }
            defectInfoControl.Size = controlSize;
            defectInfoControl.Location = controlLocation;
            pnlContainer.Controls.Add(defectInfoControl);

            if (isVertical)
                pnlContainer.VerticalScroll.Value = pnlContainer.VerticalScroll.Maximum;
            else
                pnlContainer.HorizontalScroll.Value = pnlContainer.HorizontalScroll.Maximum;

            Invalidate();
        }

        public void ClearDefectInfo()
        {
            pnlContainer.Controls.Clear();
            pnlContainer.VerticalScroll.Value = 0;
        }

        public void SelectedControlIndexChanged(int index)
        {
            SelectedDefectChangedHandler?.Invoke(index);
        }
        #endregion
    }
}
