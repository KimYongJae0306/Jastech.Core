using Jastech.Framework.Util.Helper;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Jastech.Framework.Winform.Forms
{
    public interface IReportProgress
    {
        void ReportProgress(int percentage, string messge);
    }

    public partial class SplashForm : Form, IReportProgress
    {
        #region 필드
        private Thread _workingThread = null;

        private bool _doConfigAction = false;
        #endregion

        #region 속성
        public string Title { get; set; } = "Jastech";

        public string Version { get; set; } = "";
        #endregion

        #region 이벤트
        public SplashActionDelegate ConfigActionEventHandler = null;

        public SplashActionDelegate SetupActionEventHandler = null;
        #endregion

        #region 델리게이트
        public delegate void ReportProgressDelegate(int percentage, string messge);

        public delegate bool SplashActionDelegate(SplashForm form);
        #endregion

        #region 생성자
        public SplashForm()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void SplashForm_Load(object sender, EventArgs e)
        {
            lblTitle.Text = Title;
            lblVersionText.Text = "Verion" + Version;

            SplashActionTimer.Start();
        }

        private void SplashActionTimer_Tick(object sender, EventArgs e)
        {
            if (_workingThread == null)
            {
                if (_doConfigAction == false)
                {
                    lblProgressMessage.Text = "Start Setup...";

                    _workingThread = new Thread(new ThreadStart(SpalashProc));
                    _workingThread.IsBackground = true;
                    _workingThread.Start();

                    SplashActionTimer.Interval = 500;
                }
            }
            else
            {
                if (_workingThread.IsAlive == false)
                    Close();
            }
        }

        private void SpalashProc()
        {
            Logger.Write(LogType.System, "Start SpalashProc.");

            if (SetupActionEventHandler != null && SetupActionEventHandler(this) == false)
            {
                DialogResult = DialogResult.Abort;
            }
        }

        public void ReportProgress(int progressPos, string progressMessage)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new ReportProgressDelegate(ReportProgress), progressPos, progressMessage);
                return;
            }

            this.progressBar.Value = progressPos;
            this.lblProgressMessage.Text = progressMessage;
        }
        #endregion
    }
}
