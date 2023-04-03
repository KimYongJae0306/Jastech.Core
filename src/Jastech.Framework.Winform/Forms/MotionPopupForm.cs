﻿using Jastech.Framework.Winform.Controls;
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
    public partial class MotionPopupForm : Form
    {
        #region 필드
        private MotionJogControl MotionJogControl { get; set; } = new MotionJogControl();
        //private MotionPopupParameterControl MotionPopupParameterControl { get; set; } = new MotionPopupParameterControl();
        #endregion

        #region 속성
        #endregion

        #region 이벤트
        public Action CloseEventDelegate;
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        #endregion

        #region 메서드
        public MotionPopupForm()
        {
            InitializeComponent();
        }

        private void MotionPopupForm_Load(object sender, EventArgs e)
        {
            AddControl();
            InitializeUI();
        }

        private void AddControl()
        {
            TableLayoutPanel tlp = new TableLayoutPanel();
            tlp.Dock = DockStyle.Fill;
            tlp.RowCount = 3;

            for (int rowIndex = 0; rowIndex < tlp.RowCount; rowIndex++)
                tlp.RowStyles.Add(new RowStyle(SizeType.Percent, (float)(100 / tlp.RowCount)));

            for (int i = 0; i < 3; i++)
            {
                MotionPopupParameterControl motionPopupParameterControl = new MotionPopupParameterControl();

                if (i == 0)
                {
                    motionPopupParameterControl.AxisName = "X";
                }
                if (i == 1)
                {
                    motionPopupParameterControl.AxisName = "Y";
                }
                else if (i == 2)
                {
                    motionPopupParameterControl.AxisName = "Z";
                }
                else { }

                motionPopupParameterControl.Dock = DockStyle.Fill;
                tlp.Controls.Add(motionPopupParameterControl);
            }

            pnlMotionParameter.Controls.Add(tlp);
            pnlMotionParameter.Dock = DockStyle.Fill;

            MotionJogControl.Dock = DockStyle.Fill;
            pnlJog.Controls.Add(MotionJogControl);
            pnlJog.Dock = DockStyle.Fill;
        }

        private void InitializeUI()
        {
            this.Location = new Point(1000, 40);
            this.Size = new Size(720, 800);

            ShowCommandPage();
        }

        private void MakeTeachingListControl()
        {

        }

        private void MotionPopupForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CloseEventDelegate != null)
                CloseEventDelegate();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCommand_Click(object sender, EventArgs e)
        {
            ShowCommandPage();
        }

        private void ShowCommandPage()
        {
            pnlJog.Visible = true;
            pnlMotionParameter.Visible = false;
        }

        private void btnParameter_Click(object sender, EventArgs e)
        {
            ShowParameterPage();
        }

        private void ShowParameterPage()
        {
            pnlJog.Visible = false;
            pnlMotionParameter.Visible = true;
        }
    }
    #endregion
}
