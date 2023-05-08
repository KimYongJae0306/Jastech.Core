using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
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
    }
}
