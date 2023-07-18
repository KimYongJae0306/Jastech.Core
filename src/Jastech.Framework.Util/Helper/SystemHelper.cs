using Jastech.Framework.Util.Native;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Jastech.Framework.Util.Helper
{
    public static class SystemHelper
    {
        public static void StartChecker(string path)
        {
            Task.Run(() =>
            {
                while (true)
                {
                    using (Process process = Process.GetCurrentProcess())
                    {
                        using (var file = File.AppendText(path))
                        {
                            file.WriteLine(process.WorkingSet64);
                        }
                    }
                    Thread.Sleep(1000);
                }
            });
        }

        public static void SetSystemTime(DateTime dateTime)
        {
            // Visual Studio 관리자 권한일 때만 적용 됨
            SystemTime systemTime = new SystemTime();
            systemTime.Year = (ushort)dateTime.Year;
            systemTime.Month = (ushort)dateTime.Month;
            systemTime.DayOfWeek = (ushort)dateTime.DayOfWeek;
            systemTime.Day = (ushort)dateTime.Day;
            systemTime.Hour = (ushort)dateTime.Hour;
            systemTime.Minute = (ushort)dateTime.Minute;
            systemTime.Second = (ushort)dateTime.Second;
            systemTime.Milliseconds = (ushort)dateTime.Millisecond;

            Win32APIWrapper.SetSystemTime(ref systemTime);
        }

    }
}
