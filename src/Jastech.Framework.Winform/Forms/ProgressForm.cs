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

        private bool AutoConfirm { get; set; } = false;

        public bool IsSuccess { get; set; } = false;
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

        public ProgressForm(string subjectName, RunMode mode = RunMode.Sequential, bool autoConfirm = false)
        {
            InitializeComponent();

            SubjectName = subjectName;
            Mode = mode;
            AutoConfirm = autoConfirm;
        }
        #endregion

        #region 메서드
        private void ProgressForm_Load(object sender, EventArgs e)
        {
            StartAllTasks();
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
                foreach (var task in taskList)
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

            Focus();
            if (IsSuccess && AutoConfirm)
                Close();
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
            ControlHelper.DisposeDisplay(pbxLoading);
            ControlHelper.DisposeChildControls(this);
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
                    while (Status == RunStatus.Running)
                    {
                        if (_cancellation.IsCancellationRequested == true)
                            Status = RunStatus.Cancelled;
                        else
                            ShowWaitMessages();

                        await Task.Delay(100);
                    }
                }
                else if (Mode == RunMode.Batch)
                {
                    while (taskList.Count != taskList.Count(task => task.behavior.Status == TaskStatus.RanToCompletion))
                    {
                        if (_cancellation.IsCancellationRequested == true)
                            Status = RunStatus.Cancelled;
                        else
                            ShowWaitMessages();

                        await Task.Delay(100);
                    }
                }
            }, _cancellation.Token);
        }

        private void ShowWaitMessages()
        {
            if (Created == false)
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
                Focus();
            }));
        }

        private async Task ShowResult()
        {
            if (Created == false)
                return;

            string resultMessage = $"{SubjectName} {Status}";
            IsSuccess = Status == RunStatus.Complete;
            Bitmap resultImage = IsSuccess ? Resources.loading_complete : Resources.Warning;
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

            Close();
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
