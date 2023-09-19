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

        private readonly Queue<(string name, Task behavior, StopLoopEventHandler stopLoop)> taskQueue = new Queue<(string, Task, StopLoopEventHandler)>();

        private int taskCount;
        #endregion

        #region 속성
        private Task TrackingTask { get; set; }

        private Task CheckingTask { get; set; }

        private string SubjectName { get; set; }

        private RunStatus Status { get; set; } = RunStatus.Ready;
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
        #endregion

        #region 메서드
        private void ProgressForm_Load(object sender, EventArgs e)
        {
        }

        public void StartTask()
        {
            btnConfirm.Text = "Cancel";
            pbxLoading.Image = Resources.loading_processing;    // Task, Thread에서 호출하지 말 것
            Status = RunStatus.Running;

            var currentTask = taskQueue.Dequeue();
            SubjectName = currentTask.name;
            TrackingTask = currentTask.behavior;
            StopInnerLoop = currentTask.stopLoop;

            SetRunCheckingTask();
            CheckingTask.Start();
            TrackingTask.Start();

            Logger.Write(LogType.System, $"Run task {SubjectName}.");
        }

        public async void StartAllTasks()
        {
            taskCount = taskQueue.Count;
            while (taskQueue.Count != 0 )
            {
                if (Status == RunStatus.Ready)
                    StartTask();
                await Task.Delay(200);
            }
        }

        private void ProgressForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            taskQueue.Clear();
            CheckAlert();
        }

        private void ProgressForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _cancellation.Dispose();
            _waitMessages.Dispose();
            TrackingTask?.Dispose();
            CheckingTask?.Dispose();
            ControlDisplayHelper.DisposeDisplay(pbxLoading);
            ControlDisplayHelper.DisposeChildControls(this);
        }

        public void Add(string subjectName, Action action, StopLoopEventHandler stopLoopEvent)
        {
            (string name, Task behavior, StopLoopEventHandler stopLoop) newTask;

            newTask.name = subjectName;
            newTask.behavior = new Task(() =>
            {
                action();
                Status = RunStatus.Complete;
            }, _cancellation.Token);
            newTask.stopLoop = stopLoopEvent;

            taskQueue.Enqueue(newTask);
        }

        public void Add(string subjectName, Func<bool> func, StopLoopEventHandler stopLoopEvent)
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

            taskQueue.Enqueue(newTask);
        }

        public void Add(string subjectName, AxisHomingEventHandler homingEvent, AxisName homingAxis, StopLoopEventHandler stopLoopEvent)
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

            taskQueue.Enqueue(newTask);
        }

        private void SetRunCheckingTask()
        {
            CheckingTask = new Task(async () =>
            {
                while (Status == RunStatus.Ready || Status == RunStatus.Running)
                {
                    if (_cancellation.IsCancellationRequested == true)
                        Status = RunStatus.Cancelled;
                    else if (Status == RunStatus.Running)
                        ShowWaitMessages();

                    await Task.Delay(200);
                }

                await ShowResult();
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
                lblTitleBar.Text = $" Sequence ({taskCount - taskQueue.Count} out of {taskCount})";
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
                lblProgress.Text = resultMessage;
                pbxLoading.Image = resultImage;
                lblWaitMessage.Text = string.Empty;
                btnConfirm.Text = "OK";
            }));
            Logger.Write(LogType.System, $"Task {resultMessage}");

            if (Status == RunStatus.Complete)
                Status = RunStatus.Ready;

            await Task.Delay(200);
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
            StopInnerLoop?.Invoke();

            CheckingTask?.Wait();
            TrackingTask?.Wait();
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
    }
}
