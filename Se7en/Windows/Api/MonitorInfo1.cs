using System;
using System.Runtime.InteropServices;

namespace Se7en.Windows.Api
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct MonitorInfo1
    {
        private IntPtr pName;
        public unsafe string Name => new string((sbyte*)pName);
    }
}
