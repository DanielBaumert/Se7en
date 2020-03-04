#if Windows
using System;
using System.Runtime.InteropServices;

namespace Se7en.Windows.Api
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct MonitorInfo2
    {
        private IntPtr pName;
        private IntPtr pEnvironment;
        private IntPtr pDLLName;

        public unsafe string Name => new string((sbyte*)pName);
        public unsafe string Environment => new string((sbyte*)pEnvironment);
        public unsafe string DLLName => new string((sbyte*)pDLLName);

    }
}
#endif