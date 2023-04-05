using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Imaging
{
    public class SafeMalloc : SafeBuffer
    {
        public SafeMalloc(int size)
            : base(true)
        {
            this.SetHandle(Marshal.AllocHGlobal(size));
            this.Initialize((ulong)size);
        }
        protected override bool ReleaseHandle()
        {
            Marshal.FreeHGlobal(this.handle);
            return true;
        }
        public static implicit operator IntPtr(SafeMalloc h)
        {
            return h.handle;
        }
    }
}
