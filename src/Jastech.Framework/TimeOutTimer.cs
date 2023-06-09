using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Jastech.Framework
{
    public class TimeOutTimer
    {
        #region 필드
        private System.Timers.Timer _timer = null;
        #endregion

        #region 속성
        public bool IsTimeOut { get; set; } = false;
        #endregion

        #region 생성자
        public TimeOutTimer()
        {
            _timer = new System.Timers.Timer();
            _timer.Elapsed += Timer_Elapsed;
        }
        #endregion

        #region 메서드
        public void Start(int timeOutTime)
        {
            IsTimeOut = false;
            _timer.Interval = timeOutTime;

            _timer.Start();
        }

        public void Restart()
        {
            _timer.Stop();
            IsTimeOut = false;

            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        public void Reset()
        {
            _timer.Stop();
            IsTimeOut = false;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            IsTimeOut = true;
        }

        public void ThrowIfTimeOut()
        {
            if (IsTimeOut)
                throw new TimeoutException();
        }

        public static void Wait(int timeoutTime, ManualResetEvent eventHandler)
        {
            if (eventHandler.WaitOne(timeoutTime) == false)
            {
                throw new TimeoutException();
            }
        }

        public static void Sleep(float sleepTimeMs)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            while (stopWatch.ElapsedMilliseconds < sleepTimeMs)
            {
                Thread.Sleep(0);
            }
        }
        #endregion
    }
}
