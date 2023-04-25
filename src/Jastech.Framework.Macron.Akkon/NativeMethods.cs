using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Macron.Akkon
{
    public delegate void CALLBACKFUNC(int nStageNo, int nTapNo, bool bSliceInsp, int nError);
    internal static class NativeMethods
    {
//#if DEBUG
//        [DllImport("mv_akkonInspd.dll")]
//#else
        [DllImport("mv_akkonInsp.dll")]
//#endif
        internal static extern void CallBackRegistry(CALLBACKFUNC cb);
    }
}
