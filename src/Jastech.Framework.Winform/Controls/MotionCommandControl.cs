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
using Jastech.Framework.Structure;

namespace Jastech.Framework.Winform.Controls
{
    public partial class MotionCommandControl : UserControl
    {
        #region 필드
        #endregion

        #region 속성
        private Axis SelectedAxis { get; set; } = null;
        public TeachingAxisInfo AxisInfo { get; set; } = null;
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
        private delegate void UpdateMotionStatusDelegate();
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
            InitializeUI();
        }

        public void Intialize(TeachingAxisInfo axisInfo)
        {
            AxisInfo = axisInfo.DeepCopy();
            UpdateUI();
        }

        private void InitializeUI()
        {
            lblAxisName.Text = SelectedAxis.Name;
        }

        public void SetAxis(Axis selectedAxis)
        {
            SelectedAxis = selectedAxis;
        }

        public void UpdateUI()
        {
            lblTargetPosition.Text = AxisInfo.TargetPosition.ToString();
            lblOffsest.Text = AxisInfo.Offset.ToString();
        }

        public void UpdateAxisStatus()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateMotionStatusDelegate callback = UpdateAxisStatus;
                    BeginInvoke(callback);
                    return;
                }

                UpdateStatus();
            }
            catch (Exception ex)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + ex.Message);
            }
        }

        private void UpdateStatus()
        {
            if (!SelectedAxis.IsConnected())
                return;

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

        public TeachingAxisInfo GetCurrentData()
        {
            return AxisInfo;
        }
        #endregion
    }
}
