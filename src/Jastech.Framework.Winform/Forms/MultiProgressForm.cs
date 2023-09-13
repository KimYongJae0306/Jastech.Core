using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Jastech.Framework.Winform.Controls;

namespace Jastech.Framework.Winform.Forms
{
    public partial class MultiProgressForm : Form
    {
        private readonly List<TaskProgressControl> taskProgressControls = new List<TaskProgressControl>();

        public MultiProgressForm()
        {
            InitializeComponent();
        }

        private void ProgressForm_Load(object sender, EventArgs e)
        {
            pnlTaskDisplayArea.Controls.AddRange(taskProgressControls.ToArray());
        }

        public void AddNewTask(string taskName, IEnumerator<string> sequence, int timeOut)
        {
            var taskproc = new TaskProgressControl { Dock = DockStyle.Bottom };
            taskproc.RecieveTaskProgressMessage += WriteTaskLog;
            taskproc.CreateTask(taskName, sequence, timeOut);
        }

        private void WriteTaskLog(string message)
        {
            BeginInvoke(new Action(() => lstLogMessage.Items.Add($"[{DateTime.Now:HH:mm:ss}] {message}")));
        }
    }
}
