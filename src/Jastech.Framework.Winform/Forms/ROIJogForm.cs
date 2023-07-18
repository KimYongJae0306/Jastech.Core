using Jastech.Framework.Winform.Helper;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.Forms
{
    public partial class ROIJogForm : Form
    {
        #region 필드
        private Color _selectedColor = new Color();

        private Color _nonSelectedColor = new Color();
        #endregion

        #region 속성
        public TeachingItem TeachingItem { get; set; } = TeachingItem.Mark;

        public ROIType ROIType { get; private set; } = ROIType.ROI;

        public int JogScale { get; private set; } = 1;
        #endregion

        #region 이벤트
        public event SendClickEventDelegate SendEventHandler;

        public Action CloseEventDelegate;
        #endregion

        #region 델리게이트
        public delegate void SendClickEventDelegate(string jogType, int JogScale, ROIType roiType = ROIType.ROI);
        #endregion

        #region 생성자
        public ROIJogForm()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void ROIJogControl_Load(object sender, EventArgs e)
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.Location = new Point(1100, 360);
            _selectedColor = Color.FromArgb(104, 104, 104);
            _nonSelectedColor = Color.FromArgb(52, 52, 52);

            pnlMoveMode.Dock = DockStyle.Fill;
            pnlSizeMode.Dock = DockStyle.Fill;

            ShowMoveCommandPanel();
            SetROIType(ROIType);
        }

        public void SetTeachingItem(TeachingItem teachingItem)
        {
            TeachingItem = teachingItem;

            foreach (Control control in tlpROIType.Controls)
                control.Enabled = false;

            switch (TeachingItem)
            {
                case TeachingItem.Mark:
                    lblROIMode.Enabled = true;
                    lblTrainMode.Enabled = true;
                    lblOriginMode.Enabled = true;
                    break;

                case TeachingItem.Align:
                    lblROIMode.Enabled = true;
                    break;

                case TeachingItem.Akkon:
                    lblROIMode.Enabled = true;
                    break;

                default:
                    break;
            }
        }

        private void ShowMoveCommandPanel()
        {
            lblMoveMode.BackColor = _selectedColor;
            lblSizeMode.BackColor = _nonSelectedColor;

            pnlMoveMode.Visible = true;
            pnlSizeMode.Visible = false;

            pnlSkew.Enabled = true;
        }

        private void ShowSizeCommandPanel()
        {
            lblMoveMode.BackColor = _nonSelectedColor;
            lblSizeMode.BackColor = _selectedColor;

            pnlMoveMode.Visible = false;
            pnlSizeMode.Visible = true;

            pnlSkew.Enabled = false;
        }

        private void lblMoveMode_Click(object sender, EventArgs e)
        {
            ShowMoveCommandPanel();
        }

        private void lblSizeMode_Click(object sender, EventArgs e)
        {
            ShowSizeCommandPanel();
        }

        private void lblJogScale_Click(object sender, EventArgs e)
        {
            JogScale = KeyPadHelper.SetLabelIntegerData((Label)sender);
        }

        private void lblROIMode_Click(object sender, EventArgs e)
        {
            SetROIType(ROIType.ROI);
        }

        private void lblTrainMode_Click(object sender, EventArgs e)
        {
            SetROIType(ROIType.Train);
        }

        private void lblOriginMode_Click(object sender, EventArgs e)
        {
            SetROIType(ROIType.Origin);
        }

        private void SetROIType(ROIType roiType)
        {
            ROIType = roiType;
            UpdateSelectedROIType();
        }

        private void UpdateSelectedROIType()
        {
            foreach (Control control in tlpROIType.Controls)
            {
                if (control is Label)
                    control.BackColor = _nonSelectedColor;
            }

            if (ROIType == ROIType.ROI)
                lblROIMode.BackColor = _selectedColor;
            else if (ROIType == ROIType.Train)
                lblTrainMode.BackColor = _selectedColor;
            else if (ROIType == ROIType.Origin)
                lblOriginMode.BackColor = _selectedColor;
            else { }
        }

        private void lblSkewCCW_Click(object sender, EventArgs e)
        {
            SendEventHandler("SkewCCW", JogScale, ROIType);
        }

        private void lblSkewZero_Click(object sender, EventArgs e)
        {
            SendEventHandler("SkewZero", JogScale, ROIType);
        }

        private void lblSkewCW_Click(object sender, EventArgs e)
        {
            SendEventHandler("SkewCW", JogScale, ROIType);
        }

        private void lblMoveLeft_Click(object sender, EventArgs e)
        {
            SendEventHandler("MoveLeft", JogScale, ROIType);
        }

        private void lblMoveRight_Click(object sender, EventArgs e)
        {
            SendEventHandler("MoveRight", JogScale, ROIType);
        }

        private void lblMoveDown_Click(object sender, EventArgs e)
        {
            SendEventHandler("MoveDown", JogScale, ROIType);
        }

        private void lblMoveUp_Click(object sender, EventArgs e)
        {
            SendEventHandler("MoveUp", JogScale, ROIType);
        }

        private void lblZoomOutHorizontal_Click(object sender, EventArgs e)
        {
            SendEventHandler("ZoomOutHorizontal", JogScale, ROIType);
        }

        private void lblZoomInHorizontal_Click(object sender, EventArgs e)
        {
            SendEventHandler("ZoomInHorizontal", JogScale, ROIType);
        }

        private void lblZoomOutVertical_Click(object sender, EventArgs e)
        {
            SendEventHandler("ZoomOutVertical", JogScale, ROIType);
        }

        private void lblZoomInVertical_Click(object sender, EventArgs e)
        {
            SendEventHandler("ZoomInVertical", JogScale, ROIType);
        }

        private void ROIJogControl_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CloseEventDelegate != null)
                CloseEventDelegate();
        }
        #endregion
    }

    public enum TeachingItem
    {
        Mark,
        Align,
        Akkon,
    }

    public enum ROIType
    {
        ROI,
        Train,
        Origin,
    }
}
