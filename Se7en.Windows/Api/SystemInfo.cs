using System;
using System.Runtime.InteropServices;

namespace Se7en.Windows.Api
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SystemInfo
    {
        public ProcessorInfoUnion uProcessorInfo;
        public int dwPageSize;
        public IntPtr lpMinimumApplicationAddress;
        public IntPtr lpMaximumApplicationAddress;
        public IntPtr dwActiveProcessorMask;
        public int dwNumberOfProcessors;
        public int dwProcessorType;
        public int dwAllocationGranularity;
        public short wProcessorLevel;
        public short wProcessorRevision;
    }
}
