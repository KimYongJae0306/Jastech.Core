using Jastech.Framework.Winform.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.Forms
{
    public partial class HistoryForm : Form
    {
        #region 속성
        // Page Control
        private UPHControl UPHControl { get; set; } = new UPHControl();
        #endregion

        private List<UserControl> PageControlList = null;
        private List<Button> PageButtonList = null;

        public HistoryForm()
        {
            InitializeComponent();
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            AddControls();
            InitializeUI();
        }

        private void AddControls()
        {
            // Page Control List
            PageControlList = new List<UserControl>();
            PageControlList.Add(UPHControl);

            // Button List
            PageButtonList = new List<Button>();
            PageButtonList.Add(btnUPH);
        }

        private void InitializeUI()
        {
            SetSelectButton(btnUPH);
            SetHistoryPage(selectedControl: UPHControl);
        }

        private void btnUPH_Click(object sender, EventArgs e)
        {
            SetSelectButton(sender);
            SetHistoryPage(selectedControl: UPHControl);
        }

        private void SetSelectButton(object sender)
        {
            foreach (Button button in PageButtonList)
                button.ForeColor = Color.Black;

            Button currentButton = sender as Button;
            currentButton.ForeColor = Color.Blue;
        }

        private void SetHistoryPage(UserControl selectedControl)
        {
            foreach (UserControl control in PageControlList)
                control.Visible = false;

            selectedControl.Visible = true;
            selectedControl.Dock = DockStyle.Fill;
            pnlPage.Controls.Add(selectedControl);
        }

        private void cdrMonthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (UPHControl != null)
                UPHControl.DayChanged(sender);
        }
    }
}
