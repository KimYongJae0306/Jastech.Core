using Jastech.Framework.Device.LAFCtrl;
using Jastech.Framework.Util.Helper;
using System;
using System.Windows.Forms;
using System.Xml.Linq;
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

        public void SetSelectedLafCtrl(LAFCtrl lafctrl)
        {
            SelectedLafCtrl = lafctrl;
        }

        private void btnJogUpZ_Click(object sender, EventArgs e)
        {
            if (JogMode == JogMode.Increase)
                return;

            Logger.Write(LogType.GUI, $"Clicked Z Up - Device Name : {SelectedLafCtrl.Name}");
            MoveJog(Direction.CCW);
        }

        private void btnJogUpZ_MouseDown(object sender, MouseEventArgs e)
        {
            if (JogMode == JogMode.Jog)
                return;

            Logger.Write(LogType.GUI, $"Clicked Z Up - Device Name : {SelectedLafCtrl.Name}");
            SelectedLafCtrl?.SetMotionRelativeMove(Direction.CCW, MoveAmount);
        }

        private void btnJogUpZ_MouseUp(object sender, MouseEventArgs e)
        {
            if (JogMode == JogMode.Jog)
                return;

            SelectedLafCtrl?.SetMotionStop();
        }

        private void btnJogDownZ_Click(object sender, EventArgs e)
        {
            if (JogMode == JogMode.Increase)
                return;

            Logger.Write(LogType.GUI, $"Clicked Z Down - Device Name : {SelectedLafCtrl.Name}");
            MoveJog(Direction.CW);
        }

        private void btnJogDownZ_MouseDown(object sender, MouseEventArgs e)
        {
            if (JogMode == JogMode.Jog)
                return;

            Logger.Write(LogType.GUI, $"Clicked Z Down - Device Name : {SelectedLafCtrl.Name}");
            SelectedLafCtrl?.SetMotionRelativeMove(Direction.CW, MoveAmount);
        }

        private void btnJogDownZ_MouseUp(object sender, MouseEventArgs e)
        {
            if (JogMode == JogMode.Jog)
                return;

            SelectedLafCtrl?.SetMotionStop();
        }

        private void MoveJog(Direction direction)
        {
            double targetPosition = 0.0;
            var currentPosition = 0.0;

            if (SelectedLafCtrl is NuriOneLAFCtrl nuriOne)
                currentPosition = SelectedLafCtrl.Status.MPosPulse / nuriOne.ResolutionAxisZ;

            if (direction == Direction.CCW)
                targetPosition = currentPosition + MoveAmount;
            else if (direction == Direction.CW)
                targetPosition = currentPosition - MoveAmount;
            else { }

            SelectedLafCtrl?.SetMotionAbsoluteMove(targetPosition);
        }
    }
}
