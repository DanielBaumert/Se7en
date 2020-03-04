#if Windows
using System.Runtime.InteropServices;

namespace Se7en.Windows.Api
{
    [StructLayout(LayoutKind.Explicit)]
    public struct ProcessorInfoUnion
    {
        [FieldOffset(0)]
        public uint dwOemId;
        [FieldOffset(0)]
        public ushort wProcessorArchitecture;
        [FieldOffset(2)]
        public ushort wReserved;
    }
}
#endif