using Jastech.Framework.Device.LAFCtrl;
using System;
using System.Windows.Forms;
using static Jastech.Framework.Device.Motions.AxisMovingParam;

namespace Jastech.Framework.Winform.Controls
{
    public partial class LAFJogControl : UserControl
    {
        public LAFCtrl SelectedLafCtrl { get; private set; } = null;

        public JogMode JogMode { get; set; } = JogMode.Jog;
        public JogSpeedMode JogSpeedMode { get; set; } = JogSpeedMode.Slow;

        public double MoveAmount { get; set; } = 0.1;

        public LAFJogControl()
        {
            InitializeComponent();
        }

        private void LAFJogControl_Load(object sender, EventArgs e)
        {

        }

        public void SetSelectedLafCtrl(LAFCtrl lafctrl)
        {
            SelectedLafCtrl = lafctrl;
        }

        private void btnJogUpZ_Click(object sender, EventArgs e)
        {
            SelectedLafCtrl?.SetMotionRelativeMove(Direction.CW, MoveAmount);
        }

        private void btnJogDownZ_Click(object sender, EventArgs e)
        {
            SelectedLafCtrl?.SetMotionRelativeMove(Direction.CCW, MoveAmount);
        }
    }
}
