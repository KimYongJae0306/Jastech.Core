using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jastech.Framework.Util.Helper;

namespace Jastech.Framework.Winform.Controls
{
    public partial class LogControl : UserControl
    {
        public LogControl()
        {
            InitializeComponent();
        }

        private delegate void AddLogDelegate(string message);

        public void AddLog(string message)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    AddLogDelegate callBack = AddLog;
                    BeginInvoke(callBack, message);
                    return;
                }

                if (lstLogMessage.Items.Count >= 2000)
                    lstLogMessage.Items.Clear();

                string content = "[ " + LogHelper.GetTimeString(DateTime.Now) + " ] ";
                content += message;

                lstLogMessage.Items.Add(content);
                lstLogMessage.SelectedIndex = lstLogMessage.Items.Count - 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " : " + ex.Message);
            }
        }

        public void ClearLog()
        {
            lstLogMessage.Items.Clear();
        }
    }
}
