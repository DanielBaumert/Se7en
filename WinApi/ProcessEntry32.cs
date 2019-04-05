using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Se7en.WinApi
{
    /// <summary>
    /// Describes an entry from a list of the processes residing in the system address space when a snapshot was taken.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ProcessEntry32
    {
        /// <summary>
        /// The size of the structure, in bytes. 
        /// </summary>
        public uint dwSize;
        /// <summary>
        /// This member is no longer used and is always set to zero.
        /// </summary>
        public uint cntUsage;
        /// <summary>
        /// The process identifier.
        /// </summary>
        public uint th32ProcessID;
        /// <summary>
        /// This member is no longer used and is always set to zero.
        /// </summary>
        public IntPtr th32DefaultHeapID;
        /// <summary>
        /// This member is no longer used and is always set to zero.
        /// </summary>
        public uint th32ModuleID;
        /// <summary>
        /// The number of execution threads started by the process.
        /// </summary>
        public uint cntThreads;
        /// <summary>
        /// The identifier of the process that created this process (its parent process).
        /// </summary>
        public uint th32ParentProcessID;
        /// <summary>
        /// The base priority of any threads created by this process.
        /// </summary>
        public int pcPriClassBase;
        /// <summary>
        /// This member is no longer used, and is always set to zero.
        /// </summary>
        public uint dwFlags;
        /// <summary>
        /// The name of the executable file for the process. 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)] public string szExeFile;
    };
}
