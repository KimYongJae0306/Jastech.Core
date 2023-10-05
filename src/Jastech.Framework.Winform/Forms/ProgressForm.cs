using Jastech.Framework.Device.Motions;
using Jastech.Framework.Util.Helper;
using Jastech.Framework.Winform.Helper;
using Jastech.Framework.Winform.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.Forms
{
    public partial class ProgressForm : Form
    {
        #region 필드
        private Point _mousePoint = Point.Empty;

        private IEnumerator<string> _waitMessages = GetWaitMessage();

        private readonly CancellationTokenSource _cancellation = new CancellationTokenSource();

        private readonly List<(string name, Task behavior, StopLoopEventHandler stopLoop)> taskList = new List<(string, Task, StopLoopEventHandler)>();
        #endregion

        #region 속성
        private Task CheckingTask { get; set; }

        private string SubjectName { get; set; }

        private RunStatus Status { get; set; } = RunStatus.Ready;

        private RunMode Mode { get; set; } = RunMode.Sequential;
        #endregion

        #region 이벤트
        public event StopLoopEventHandler StopInnerLoop;

        public delegate void StopLoopEventHandler();

        public delegate bool AxisHomingEventHandler(AxisName axisName);
        #endregion

        #region 생성자
        public ProgressForm()
        {
            InitializeComponent();
        }

        public ProgressForm(string subjectName, RunMode mode = RunMode.Sequential)
        {
            InitializeComponent();

            SubjectName = subjectName;
            Mode = mode;
        }
        #endregion

        #region 메서드
        private void ProgressForm_Load(object sender, EventArgs e)
        {
            StartAllTasks();
            Focus();
        }

        public void InitializeRunStatus()
        {
            BeginInvoke(new Action(() =>
            {
                btnConfirm.Text = "Cancel";
                pbxLoading.Image = Resources.loading_processing;
            }));
            Status = RunStatus.Running;

            SetRunCheckingTask();
            CheckingTask.Start();
        }

        private async void StartAllTasks()
        {
            if (Mode == RunMode.Sequential)
            {
                foreach(var task in taskList)
                {
                    while (Status != RunStatus.Ready)
                    {
                        if (_cancellation.IsCancellationRequested == true)
                            return;
                        await Task.Delay(100);
                    }

                    InitializeRunStatus();
                    Logger.Write(LogType.System, $"Run task {SubjectName = task.name}.");

                    task.behavior.Start();
                    await task.behavior;
                    await ShowResult();
                }
            }
            else if (Mode == RunMode.Batch)
            {
                InitializeRunStatus();
                Logger.Write(LogType.System, $"Run task {SubjectName}.");

                taskList.ForEach(task => task.behavior.Start());
                await Task.WhenAll(taskList.Select(task => task.behavior));
                await ShowResult();
            }

            if (pbxLoading.Image == Resources.loading_complete)
                btnConfirm.DialogResult = DialogResult.OK;
            else
                btnConfirm.DialogResult = DialogResult.Cancel;
        }

        private void ProgressForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CheckAlert();
        }

        private void ProgressForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _cancellation.Dispose();
            _waitMessages.Dispose();
            CheckingTask?.Dispose();
            ControlDisplayHelper.DisposeDisplay(pbxLoading);
            ControlDisplayHelper.DisposeChildControls(this);
        }

        public void Add(string subjectName, Action action, StopLoopEventHandler stopLoopEvent = null)
        {
            (string name, Task behavior, StopLoopEventHandler stopLoop) newTask;

            newTask.name = subjectName;
            newTask.behavior = new Task(() =>
            {
                action();
                Status = RunStatus.Complete;
            }, _cancellation.Token);
            newTask.stopLoop = stopLoopEvent;

            taskList.Add(newTask);
        }

        public void Add(string subjectName, Func<bool> func, StopLoopEventHandler stopLoopEvent = null)
        {
            (string name, Task behavior, StopLoopEventHandler stopLoop) newTask;

            newTask.name = subjectName;
            newTask.behavior = new Task(() =>
            {
                if (func() == true)
                    Status = RunStatus.Complete;
                else
                    Status = RunStatus.Failed;
            }, _cancellation.Token);
            newTask.stopLoop = stopLoopEvent;

            taskList.Add(newTask);
        }

        public void Add(string subjectName, AxisHomingEventHandler homingEvent, AxisName homingAxis, StopLoopEventHandler stopLoopEvent = null)
        {
            (string name, Task behavior, StopLoopEventHandler stopLoop) newTask;

            newTask.name = subjectName;
            newTask.behavior = new Task(() =>
            {
                if (homingEvent?.Invoke(homingAxis) == true)
                    Status = RunStatus.Complete;
                else
                    Status = RunStatus.Failed;
            }, _cancellation.Token);
            newTask.stopLoop = stopLoopEvent;

            taskList.Add(newTask);
        }

        private void SetRunCheckingTask()
        {
            CheckingTask = new Task(async () =>
            {
                if (Mode == RunMode.Sequential)
                {
                    while (Status == RunStatus.Ready || Status == RunStatus.Running)
                    {
                        if (_cancellation.IsCancellationRequested == true)
                            Status = RunStatus.Cancelled;
                        else if (Status == RunStatus.Running)
                            ShowWaitMessages();

                        await Task.Delay(100);
                    }
                }
                else if (Mode == RunMode.Batch)
                {
                    while (Status == RunStatus.Running || taskList.Count != taskList.Count(task => task.behavior.Status == TaskStatus.Running))
                    {
                        if (_cancellation.IsCancellationRequested == true)
                            Status = RunStatus.Cancelled;
                        else if (Status == RunStatus.Complete)
                            Status = RunStatus.Running;
                        else if (Status == RunStatus.Running)
                            ShowWaitMessages();

                        await Task.Delay(100);
                    }
                }
            }, _cancellation.Token);
        }

        private void ShowWaitMessages()
        {
            if (Visible == false)
                return;

            if (_waitMessages.MoveNext() == false)
            {
                _waitMessages = GetWaitMessage();
                _waitMessages.MoveNext();
            }

            BeginInvoke(new Action(() =>
            {
                lblTitleBar.Text = $" {Mode} ({taskList.Count(task => task.behavior.Status == TaskStatus.RanToCompletion)} out of {taskList.Count})";
                lblProgress.Text = $"Now {SubjectName} in progress";
                lblWaitMessage.Text = _waitMessages.Current;
            }));
        }

        private async Task ShowResult()
        {
            if (Visible == false)
                return;

            string resultMessage = $"{SubjectName} {Status}";
            Bitmap resultImage = Status == RunStatus.Complete ? Resources.loading_complete : Resources.Warning;
            BeginInvoke(new Action(() =>
            {
                lblTitleBar.Text = $" {Mode} ({taskList.Count(task => task.behavior.Status == TaskStatus.RanToCompletion)} out of {taskList.Count})";
                lblProgress.Text = resultMessage;
                pbxLoading.Image = resultImage;
                lblWaitMessage.Text = string.Empty;
                btnConfirm.Text = "OK";
            }));
            Logger.Write(LogType.System, $"Task {resultMessage}");

            if (Status == RunStatus.Complete)
                Status = RunStatus.Ready;

            await Task.Delay(500);
        }

        private void CheckAlert()
        {
            if (Status == RunStatus.Failed || Status == RunStatus.Cancelled)
            {
                string message = $"{SubjectName} {Status}";
                var alert = new MessageConfirmForm { Message = message };
                Logger.Write(LogType.System, message);

                alert.ShowDialog();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _cancellation.Cancel();
            CheckingTask?.Wait();

            taskList.ForEach(task => task.stopLoop?.Invoke());
            //taskList.Where(task => task.behavior.Status == TaskStatus.).ForEach(task => task.behavior?.Wait());
        }

        private static IEnumerator<string> GetWaitMessage()
        {
            yield return $"Please wait a moment.";
            yield return $"Please wait a moment..";
            yield return $"Please wait a moment...";
            yield return $"Please wait a moment....";
        }

        private void Topbar_MouseDown(object sender, MouseEventArgs e)
        {
            _mousePoint = new Point(e.X, e.Y);
        }

        private void Topbar_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
                Location = new Point(Left - (_mousePoint.X - e.X), Top - (_mousePoint.Y - e.Y));
        }
        #endregion

        private enum RunStatus
        {
            Ready,
            Running,
            Complete,
            Failed,
            Cancelled,
        }

        public enum RunMode
        {
            Sequential,
            Batch,
        }
    }
}
