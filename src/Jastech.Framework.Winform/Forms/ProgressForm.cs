using Jastech.Framework.Util.Helper;
using Jastech.Framework.Winform.Helper;
using Jastech.Framework.Winform.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private readonly CancellationTokenSource _cancellation = new CancellationTokenSource();
        #endregion

        #region 속성
        private Task TrackingTask { get; set; }

        private Task RunCheckingTask { get; set; }

        private string SubjectName { get; set; }

        private bool RunSuccessfully { get; set; } = false;
        #endregion

        #region 이벤트
        public event StopLoopEventHandler StopInnerLoop;

        public delegate void StopLoopEventHandler();
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
            if (TrackingTask == null || RunCheckingTask == null)
                Close();

            TrackingTask.Start();
            RunCheckingTask.Start();
        }

        private void ProgressForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ControlDisplayHelper.DisposeDisplay(pbxLoading);
            ControlDisplayHelper.DisposeChildControls(this);
        }

        public void SetRunTask(string subjectName, Func<bool> func)
        {
            SubjectName = subjectName;
            TrackingTask = new Task(() =>
            {
                RunSuccessfully = func();
            }, _cancellation.Token);
            SetRunCheckingTask();

            Logger.Write(LogType.System, $"Run task {SubjectName}.");
        }

        public void SetRunTask(string subjectName, Action action)
        {
            SubjectName = subjectName;
            TrackingTask = new Task(() =>
            {
                action();
                RunSuccessfully = true;
            }, _cancellation.Token);
            SetRunCheckingTask();

            Logger.Write(LogType.System, $"Run task {SubjectName}.");
        }

        private void SetRunCheckingTask()
        {
            RunCheckingTask = new Task(async () =>
            {
                while (TrackingTask.Status == TaskStatus.WaitingToRun)
                    await Task.Delay(100);

                var loopString = GetWaitMessage();
                while (TrackingTask.Status == TaskStatus.Running && _cancellation.IsCancellationRequested == false)
                {
                    if(loopString.MoveNext() == false)
                    {
                        loopString = GetWaitMessage();
                        loopString.MoveNext();
                    }
                    BeginInvoke(new Action(() =>
                    {
                        lblProgress.Text = $"Now {SubjectName} in progress.";
                        lblWaitMessage.Text = loopString.Current;
                    }));
                    await Task.Delay(200);
                }

                BeginInvoke(new Action(() => lblWaitMessage.Text = string.Empty));
                if (_cancellation.IsCancellationRequested == true)
                {
                    BeginInvoke(new Action(() =>
                    {
                        lblProgress.Text = $"{SubjectName} cancelled.";
                        pbxLoading.Image = Resources.Warning;
                    }));
                    Logger.Write(LogType.System, $"Task {SubjectName} cencelled.");
                }
                else if (RunSuccessfully == false)
                {
                    BeginInvoke(new Action(() =>
                    {
                        lblProgress.Text = $"{SubjectName} failed.";
                        pbxLoading.Image = Resources.Warning;
                    }));
                    Logger.Write(LogType.System, $"Task {SubjectName} failed.");
                }
                else
                {
                    BeginInvoke(new Action(() =>
                    {
                        lblProgress.Text = $"{SubjectName} completed.";
                        pbxLoading.Image = Resources.loading_complete;
                        lblWaitMessage.Text = string.Empty;
                        btnConfirm.Text = "OK";
                    }));
                    Logger.Write(LogType.System, $"Task {SubjectName} completed.");
                }
            }, _cancellation.Token);
        }

        private async void btnCancel_Click(object sender, EventArgs e)
        {
            bool isRunCancelled = TrackingTask?.Status == TaskStatus.Running;

            _cancellation.Cancel();
            StopInnerLoop?.Invoke();

            RunCheckingTask?.Wait();
            TrackingTask?.Wait();

            if (isRunCancelled)
            {
                new MessageConfirmForm { Message = $"{SubjectName} cancelled." }.ShowDialog();
                Logger.Write(LogType.System, $"Task {SubjectName} cancelled by user.");
            }
        }

        private IEnumerator<string> GetWaitMessage()
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
    }
}
