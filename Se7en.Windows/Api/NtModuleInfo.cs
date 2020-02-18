using System;
using System.Runtime.InteropServices;

namespace Se7en.Windows.Api
{
    /// <summary>
    /// Contains the module load address, size, and entry point.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NtModuleInfo
    {
        /// <summary>
        /// The load address of the module.
        /// </summary>
        public IntPtr BaseOfDll;
        /// <summary>
        /// The size of the linear space that the module occupies, in bytes.
        /// </summary>
        public int SizeOfImage;
        /// <summary>
        /// The entry point of the module.
        /// </summary>
        public IntPtr EntryPoint;
    }
}
