using Jastech.Framework.Winform.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.Controls
{
    public partial class TaskProgressControl : UserControl
    {
        private string TaskName { get; set; }
        private int TimeOut { get; set; }

        private Task _task;
        private CancellationTokenSource _cancellation = new CancellationTokenSource();
        private Stopwatch _stopwatch;

        public event RecieveProgressMessageEventHandler RecieveTaskProgressMessage;
        public delegate void RecieveProgressMessageEventHandler(string message);

        public TaskProgressControl()
        {
            InitializeComponent();
        }

        private void TaskProgressControl_Load(object sender, EventArgs e)
        {
            RunTask();
        }

        public void CreateTask(string taskName, IEnumerator<string> steps, int timeOut)
        {
            lblTaskName.Text = taskName;
            TimeOut = timeOut;

            _task = new Task(() =>
            {
                while (steps.MoveNext())
                {
                    RecieveTaskProgressMessage?.Invoke($"{taskName} : {steps.Current}");
                    BeginInvoke(new Action(() => lblStep.Text = steps.Current));
                }
            }, _cancellation.Token);
        }
        
        private void RunTask()
        {
            _task?.Start();
            _stopwatch = Stopwatch.StartNew();

            Task.Run(() =>
            {
                while(_task.Status == TaskStatus.Running && _stopwatch.ElapsedMilliseconds <= TimeOut)
                {
                    int newValue = (int)((double)_stopwatch.ElapsedMilliseconds / TimeOut * progressBar.Maximum) % progressBar.Maximum;
                    if (progressBar.Value != newValue)
                        BeginInvoke(new Action(() => progressBar.Value = newValue));
                }

                if(_task.Status == TaskStatus.RanToCompletion)
                {
                    RecieveTaskProgressMessage?.Invoke($"Task {TaskName} complete. time elapsed : {_stopwatch.ElapsedMilliseconds:F2}ms");
                    BeginInvoke(new Action(() =>
                    {
                        pbxLoading.Image = Resources.loading_complete;
                        progressBar.Value = progressBar.Maximum;
                    }));
                }
                else if (_task.Status == TaskStatus.Faulted)
                {
                    RecieveTaskProgressMessage?.Invoke($"Task {TaskName} error occurred. time elapsed : {_stopwatch.ElapsedMilliseconds:F2}ms");
                    BeginInvoke(new Action(() => pbxLoading.Image = Resources.Warning));
                }
                else if (_task.Status == TaskStatus.Canceled)
                {
                    RecieveTaskProgressMessage?.Invoke($"Task {TaskName} canceled. time elapsed : {_stopwatch.ElapsedMilliseconds:F2}ms");
                    BeginInvoke(new Action(() => pbxLoading.Image = Resources.Warning));
                }
                else if (_stopwatch.ElapsedMilliseconds > TimeOut)
                { 
                    RecieveTaskProgressMessage?.Invoke($"Task {TaskName} timed out. time elapsed : {_stopwatch.ElapsedMilliseconds:F2}ms");
                    BeginInvoke(new Action(() => pbxLoading.Image = Resources.Warning));
                }
                else
                {
                    RecieveTaskProgressMessage?.Invoke($"Task {TaskName} {_task.Status} unhandled. time elapsed : {_stopwatch.ElapsedMilliseconds:F2}ms");
                    BeginInvoke(new Action(() => pbxLoading.Image = Resources.Warning));
                }
            }, _cancellation.Token);
        }
    }
}
