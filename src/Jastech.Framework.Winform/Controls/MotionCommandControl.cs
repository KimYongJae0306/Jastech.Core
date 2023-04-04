using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Jastech.Framework.Device.Motions;

namespace Jastech.Framework.Winform.Controls
{
    public partial class MotionCommandControl : UserControl
    {
        #region 필드
        private System.Threading.Timer _controlTimer = null;
        #endregion

        #region 속성
        private Axis SelectedAxis { get; set; } = null;
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
        private delegate void UpdateUIDelegate(object obj);
        #endregion

        #region 생성자
        public MotionCommandControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void MotionCommandControl_Load(object sender, EventArgs e)
        {
            StartTimer();
            InitializeUI();
        }

        private void StartTimer()
        {
            _controlTimer = new System.Threading.Timer(UpdateUI, null, 1000, 1000);
        }

        private void InitializeUI()
        {
            lblAxisName.Text = SelectedAxis.Name;
        }

        public void SetAxis(Axis selectedAxis)
        {
            SelectedAxis = selectedAxis;
        }

        public void UpdateUI(object obj)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateUIDelegate callback = UpdateUI;
                    BeginInvoke(callback, obj);
                    return;
                }

                UpdateMotionStatus();
            }
            catch (Exception ex)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + ex.Message);
            }
        }

        private void UpdateMotionStatus()
        {
            if (SelectedAxis.IsConnected() == false)
                return;

            lblTargetPosition.Text = "0";
            lblOffsest.Text = "0";

            lblCurrentPosition.Text = SelectedAxis.GetActualPosition().ToString("F3");

            if (SelectedAxis.IsNegativeLimit())
            {
                lblSensor.Text = "-";
                lblSensor.BackColor = Color.Red;
            }
            else if (SelectedAxis.IsPositiveLimit())
            {
                lblSensor.Text = "+";
                lblSensor.BackColor = Color.Red;
            }
            else
            {
                lblSensor.Text = "";
                lblSensor.BackColor = Color.White;
            }

            lblAxisStatus.Text = SelectedAxis.GetCurrentMotionStatus();

            if (SelectedAxis.IsEnable())
                chkServoOnOff.Checked = true;
            else
                chkServoOnOff.Checked = false;
        }

        private void chkServoOnOff_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectedAxis.IsConnected() == false)
                return;

            if (chkServoOnOff.Checked)
            {
                if (SelectedAxis.IsEnable())
                    return;
                else
                    SelectedAxis.TurnOnServo();
            }
            else
            {
                if (SelectedAxis.IsEnable())
                    SelectedAxis.TurnOffServo();
                else
                    return;
            }
        }
        #endregion
    }
}
