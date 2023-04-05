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
    public partial class AkkonParamControl : UserControl
    {
        #region 필드
        private AkkonParamter.ParameterType _parameterType = AkkonParamter.ParameterType.GROUP;
        #endregion

        #region 속성
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        public AkkonParamControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void AkkonParamControl_Load(object sender, EventArgs e)
        {
            InitializeUI();
        }

        private void cmb_DrawItem(object sender, DrawItemEventArgs e)
        {
            DrawComboboxCenterAlign(sender, e);
        }

        private void DrawComboboxCenterAlign(object sender, DrawItemEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;

            if (cmb != null)
            {
                e.DrawBackground();
                cmb.ItemHeight = lblGroupNumber.Height - 7;

                if (e.Index >= 0)
                {
                    StringFormat sf = new StringFormat();
                    sf.LineAlignment = StringAlignment.Center;
                    sf.Alignment = StringAlignment.Center;

                    Brush brush = new SolidBrush(cmb.ForeColor);

                    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                        brush = SystemBrushes.HighlightText;

                    e.Graphics.DrawString(cmb.Items[e.Index].ToString(), cmb.Font, brush, e.Bounds, sf);
                }
            }
        }

        private void InitializeUI()
        {
            // Checked Radio Button
            rdoGroup.Checked = true;

            // Authority
            //if (Main.Instance().Authority != eAuthority.Maker)
            //    rdoMakerParmeter.Enabled = false;
            //else
            //    rdoMakerParmeter.Enabled = true;

            // Parameter Panel Dock
            this.pnlGroupParameter.Dock = DockStyle.Fill;
            this.pnlEngineerParameter.Dock = DockStyle.Fill;
            this.pnlMakerParameter.Dock = DockStyle.Fill;
            this.pnlOptionParameter.Dock = DockStyle.Fill;

            // Inspection Type
            foreach (AkkonParamter.MakerParameter.eInspectionType item in Enum.GetValues(typeof(AkkonParamter.MakerParameter.eInspectionType)))
                cmbInspectionType.Items.Add(item.ToString().ToUpper());

            // Panel Type
            foreach (AkkonParamter.MakerParameter.ePanelType item in Enum.GetValues(typeof(AkkonParamter.MakerParameter.ePanelType)))
                cmbPanelType.Items.Add(item.ToString().ToUpper());

            // Target Type
            foreach (AkkonParamter.MakerParameter.eTargetType item in Enum.GetValues(typeof(AkkonParamter.MakerParameter.eTargetType)))
                cmbTargetType.Items.Add(item.ToString().ToUpper());

            // Filter Type
            foreach (AkkonParamter.MakerParameter.eFilterType item in Enum.GetValues(typeof(AkkonParamter.MakerParameter.eFilterType)))
                cmbFilterType.Items.Add(item.ToString().ToUpper());

            // Filter Direction
            foreach (AkkonParamter.MakerParameter.eFilterDirection item in Enum.GetValues(typeof(AkkonParamter.MakerParameter.eFilterDirection)))
                cmbFilterDirection.Items.Add(item.ToString().ToUpper());

            // Shadow Direction
            foreach (AkkonParamter.MakerParameter.eShadowDirection item in Enum.GetValues(typeof(AkkonParamter.MakerParameter.eShadowDirection)))
                cmbShadowDirection.Items.Add(item.ToString().ToUpper());

            // Peak Property
            foreach (AkkonParamter.MakerParameter.ePeakProperty item in Enum.GetValues(typeof(AkkonParamter.MakerParameter.ePeakProperty)))
                cmbPeakProperty.Items.Add(item.ToString().ToUpper());

            // Strength Base
            foreach (AkkonParamter.MakerParameter.eStrengthBase item in Enum.GetValues(typeof(AkkonParamter.MakerParameter.eStrengthBase)))
                cmbStrengthBase.Items.Add(item.ToString().ToUpper());

            // Threshold Mode
            foreach (AkkonParamter.MakerParameter.eThresholdMode item in Enum.GetValues(typeof(AkkonParamter.MakerParameter.eThresholdMode)))
                cmbThresholdMode.Items.Add(item.ToString().ToUpper());
        }
        #endregion

        private void rdoGroup_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoGroup.Checked)
            {
                ShowGroupParamter();
                rdoGroup.BackColor = Color.DeepSkyBlue;
            }
            else
                rdoGroup.BackColor = Color.White;
        }

        private void ShowGroupParamter()
        {
            pnlGroupParameter.Visible = true;
            pnlEngineerParameter.Visible = false;
            pnlMakerParameter.Visible = false;
            pnlOptionParameter.Visible = false;

            lblGroupCountValue.Enabled = true;
            cmbGroupNumber.Enabled = true;
        }

        private void rdoBump_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBump.Checked)
            {
                ShowBumpParamter();
                rdoBump.BackColor = Color.DeepSkyBlue;
            }
            else
                rdoBump.BackColor = Color.White;
        }

        private void ShowBumpParamter()
        {
            pnlGroupParameter.Visible = true;
            pnlEngineerParameter.Visible = false;
            pnlMakerParameter.Visible = false;
            pnlOptionParameter.Visible = false;

            lblGroupCountValue.Enabled = false;
            cmbGroupNumber.Enabled = false;
        }

        private void rdoEngineerParmeter_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoEngineerParmeter.Checked)
            {
                ShowEngineerParamter();
                rdoEngineerParmeter.BackColor = Color.DeepSkyBlue;
            }
            else
                rdoEngineerParmeter.BackColor = Color.White;
        }

        private void ShowEngineerParamter()
        {
            pnlGroupParameter.Visible = false;
            pnlEngineerParameter.Visible = true;
            pnlMakerParameter.Visible = false;
            pnlOptionParameter.Visible = false;
        }

        private void rdoMakerParmeter_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoMakerParmeter.Checked)
            {
                ShowMakerParamter();
                rdoMakerParmeter.BackColor = Color.DeepSkyBlue;
            }
            else
                rdoMakerParmeter.BackColor = Color.White;
        }

        private void ShowMakerParamter()
        {
            pnlGroupParameter.Visible = false;
            pnlEngineerParameter.Visible = false;
            pnlMakerParameter.Visible = true;
            pnlOptionParameter.Visible = false;
        }

        private void rdoOption_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOption.Checked)
            {
                ShowOptionParameter();
                rdoOption.BackColor = Color.DeepSkyBlue;
            }
            else
                rdoOption.BackColor = Color.White;
        }

        private void ShowOptionParameter()
        {
            pnlGroupParameter.Visible = false;
            pnlEngineerParameter.Visible = false;
            pnlMakerParameter.Visible = false;
            pnlOptionParameter.Visible = true;
        }
    }

    public class AkkonParamter
    {
        public enum ParameterType
        {
            GROUP,
            BUMP,
            ENGINEER_PARAMETER,
            MAKER_PARAMETER,
            OPTION,
        }

        public class GroupParameter
        {
            public int GroupCount { get; set; } = 0;
            public int ROIWidth { get; set; } = 0;
            public int ROIHeight { get; set; } = 0;
            public int LeadCount { get; set; } = 0;
            public int LeadPitch { get; set; } = 0;
        }

        public class EngineerParameter
        {
            public int Count { get; set; } = 0;
            public int MinimumFilterSize { get; set; } = 0;
            public int MaximumFilterSize { get; set; } = 0;
            public int GroupDistance { get; set; } = 0;
            public int StrengthFilter { get; set; } = 0;
            public int Length { get; set; } = 0;
            public int WidthCut { get; set; } = 0;
            public int HeightCut { get; set; } = 0;
            public int BandWidthRatio { get; set; } = 0;
            public int ExtraLeadDisplay { get; set; } = 0;
        }

        public class MakerParameter
        {
            public enum eInspectionType
            {
                THRESHOLD,
                DL_MODE_0,
                DL_MODE_1,
                DL_MODE_2,
            }

            public enum ePanelType
            {
                RIGID,
                FLEXIBLE,
            }

            public enum eTargetType
            {
                COF,
                COG,
                FOG,
            }

            public enum eFilterType
            {
                NORMAL,
                SMALL,
                FILTER_2,
                FILTER_3,
                FILTER_4,
                BIG,
            }

            public enum eFilterDirection
            {
                HORIZONTAL,
                VERTICAL,
            }

            public int ThresholdWeight { get; set; } = 0;
            public int PeakThreshold { get; set; } = 0;
            public int StandardDeviation { get; set; } = 0;


            public enum eShadowDirection
            {
                UP,
                DOWN,
                LEFT,
                RIGHT,
            }

            public enum ePeakProperty
            {
                NORMAL,
                NEAR,
            }

            public enum eStrengthBase
            {
                ENH,
                RAW,
            }

            public bool UseLogTrace { get; set; } = false;

            public enum eThresholdMode
            {
                AUTO,
                WHITE,
                BLACK,
            }

            public int StrengthScaleFactor { get; set; } = 0;
            public int SliceOverlap { get; set; } = 0;
        }

        public class OptionParameter
        {
            public int DimpleNGCount { get; set; } = 0;
            public int DimpleThreshold { get; set; } = 0;
            public int AlarmCapacity { get; set; } = 0;
            public int AlarmNGCount { get; set; } = 0;
        }
    }
    
}
