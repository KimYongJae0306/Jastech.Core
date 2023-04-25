using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jastech.Framework.Macron.Akkon.Parameters;
using Jastech.Framework.Winform.Forms;
using AW;

namespace Jastech.Framework.Macron.Akkon.Controls
{ 
    public partial class MacronAkkonParamControl : UserControl
    {
        #region 필드
        private MacronAkkonParam CurrentParam;

        private Color _selectedColor = new Color();

        private Color _nonSelectedColor = new Color();

        private bool _InitComboBox { get; set; } = false;
        #endregion

        #region 속성
        public MacronEngineerParamControl MacronEngineerParamControl { get; set; } = null;

        public MacronMakerParamControl MacronMakerParamControl { get; set; } = null;

        public MacronOptionParamControl MacronOptionParamControl { get; set; } = null;
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        public MacronAkkonParamControl()
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
            ComboBox cbx = sender as ComboBox;

            //if (cbx != null)
            //{
            //    e.DrawBackground();
            //    cbx.ItemHeight = lblInspectionType.Height - 7;

            //    if (e.Index >= 0)
            //    {
            //        StringFormat sf = new StringFormat();
            //        sf.LineAlignment = StringAlignment.Center;
            //        sf.Alignment = StringAlignment.Center;

            //        Brush brush = new SolidBrush(cbx.ForeColor);

            //        if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            //            brush = SystemBrushes.HighlightText;

            //        e.Graphics.DrawString(cbx.Items[e.Index].ToString(), cbx.Font, brush, e.Bounds, sf);
            //    }
            //}
        }

        private void InitializeUI()
        {
            _selectedColor = Color.FromArgb(104, 104, 104);
            _nonSelectedColor = Color.FromArgb(52, 52, 52);

            MacronEngineerParamControl = new MacronEngineerParamControl();
            MacronEngineerParamControl.Dock = DockStyle.Fill;
            MacronEngineerParamControl.SetParam(CurrentParam);

            MacronMakerParamControl = new MacronMakerParamControl();
            MacronMakerParamControl.Dock = DockStyle.Fill;
            MacronMakerParamControl.SetParam(CurrentParam);

            MacronOptionParamControl = new MacronOptionParamControl();
            MacronOptionParamControl.Dock = DockStyle.Fill;
            MacronOptionParamControl.SetParam(CurrentParam);
        }
        #endregion

        public void SetParam(MacronAkkonParam macronAkkonParam)
        {
            CurrentParam = macronAkkonParam;
        }

        public void UpdateData()
        {
            if (CurrentParam != null)
            {
                MacronEngineerParamControl?.SetParam(CurrentParam);
                MacronMakerParamControl?.SetParam(CurrentParam);
                MacronOptionParamControl?.SetParam(CurrentParam);
            }
        }

        #region Panel Open
        private void rdoEngineerParmeter_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoEngineerParmeter.Checked)
            {
                ShowEngineerParamter();
                rdoEngineerParmeter.BackColor = _selectedColor;
            }
            else
                rdoEngineerParmeter.BackColor = _nonSelectedColor;
        }

        private void ShowEngineerParamter()
        {
            pnlShowSelectParameter.Controls.Clear();
            pnlShowSelectParameter.Controls.Add(MacronEngineerParamControl);
        }

        private void rdoMakerParmeter_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoMakerParmeter.Checked)
            {
                ShowMakerParamter();
                rdoMakerParmeter.BackColor = _selectedColor;
            }
            else
                rdoMakerParmeter.BackColor = _nonSelectedColor;
        }

        private void ShowMakerParamter()
        {
            pnlShowSelectParameter.Controls.Clear();
            pnlShowSelectParameter.Controls.Add(MacronMakerParamControl);
        }

        private void rdoOption_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOption.Checked)
            {
                ShowOptionParameter();
                rdoOption.BackColor = _selectedColor;
            }
            else
                rdoOption.BackColor = _nonSelectedColor;
        }

        private void ShowOptionParameter()
        {
            pnlShowSelectParameter.Controls.Clear();
            pnlShowSelectParameter.Controls.Add(MacronOptionParamControl);
        }


        public MacronAkkonParam GetCurrentParam()
        {
            return CurrentParam;
        }
        #endregion
    }
}
