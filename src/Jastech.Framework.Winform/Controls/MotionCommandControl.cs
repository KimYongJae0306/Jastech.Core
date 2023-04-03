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

namespace Jastech.Framework.Winform.Controls
{
    public partial class MotionCommandControl : UserControl
    {
        #region 필드
        private System.Threading.Timer _controlTimer = null;
        #endregion

        #region 속성
        public string AxisName { get; set; } = string.Empty;
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
            lblAxisName.Text = AxisName;
        }

        private void UpdateUI(object obj)
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
            if (DeviceManager.Instance().GetMotion() == null)
                return;

            if (!DeviceManager.Instance().GetMotion().IsConnected())
                return;

            lblTargetPosition.Text = "0";
            lblOffsest.Text = "0";

            lblCurrentPosition.Text = DeviceManager.Instance().GetMotion().GetActualPosition(0).ToString("F3");

            if (DeviceManager.Instance().GetMotion().IsNegativeLimit(0))
            {
                lblSensor.Text = "-";
                lblSensor.BackColor = Color.Red;
            }
            else if (DeviceManager.Instance().GetMotion().IsPositiveLimit(0))
            {
                lblSensor.Text = "+";
                lblSensor.BackColor = Color.Red;
            }
            else
            {
                lblSensor.Text = "";
                lblSensor.BackColor = Color.White;
            }

            lblAxisStatus.Text = DeviceManager.Instance().GetMotion().GetCurrentMotionStatus(0);

            if (DeviceManager.Instance().GetMotion().IsEnable(0))
                chkServoOnOff.Checked = true;
            else
                chkServoOnOff.Checked = false;
        }

        private void chkServoOnOff_CheckedChanged(object sender, EventArgs e)
        {
            if (DeviceManager.Instance().GetMotion() == null)
                return;

            if (!DeviceManager.Instance().GetMotion().IsConnected())
                return;

            if (chkServoOnOff.Checked)
            {
                if (DeviceManager.Instance().GetMotion().IsEnable(0))
                    return;
                else
                    DeviceManager.Instance().GetMotion().TurnOnServo(0, true);
            }
            else
            {
                if (DeviceManager.Instance().GetMotion().IsEnable(0))
                    DeviceManager.Instance().GetMotion().TurnOnServo(0, false);
                else
                    return;
            }
        }
        #endregion
    }
}
