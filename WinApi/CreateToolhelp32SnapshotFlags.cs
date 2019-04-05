using System;

namespace Se7en.WinApi
{
    /// <summary>
    /// The portions of the system to be included in the snapshot. This parameter can be one or more of the following values.
    /// </summary>
    [Flags]
    public enum CreateToolhelp32SnapshotFlags : uint
    {
        /// <summary>
        /// Indicates that the snapshot handle is to be inheritable.
        /// </summary>
        INHERIT = 0x80000000,
        /// <summary>
        ///  Includes all processes and threads in the system, plus the heaps and modules of the process specified in th32ProcessID. Equivalent to specifying the SnapHeapList, SnapModule, SnapProcess, and SnapThread values combined using an OR operation('|').
        /// </summary>
        SnapAll,
        /// <summary>
        /// Includes all heaps of the process specified in th32ProcessID in the snapshot.To enumerate the heaps, see Heap32ListFirst.
        /// </summary>
        SnapHeapList = 0x00000001,
        /// <summary>
        /// Includes all modules of the process specified in th32ProcessID in the snapshot. 
        /// To enumerate the modules, see Module32First. 
        /// If the function fails with ERROR_BAD_LENGTH, retry the function until it succeeds. <para/>
        /// 64-bit Windows:  Using this flag in a 32-bit process includes the 32-bit modules of the process specified in th32ProcessID, while using it in a 64-bit process includes the 64-bit modules.
        /// To include the 32-bit modules of the process specified in th32ProcessID from a 64-bit process, use the SnapModule32 flag.
        /// </summary>
        SnapModule = 0x00000008,
        /// <summary>
        /// Includes all 32-bit modules of the process specified in th32ProcessID in the snapshot when called from a 64-bit process. This flag can be combined with SnapModule or SnapAll.If the function fails with ERROR_BAD_LENGTH, retry the function until it succeeds.
        /// </summary>
        SnapModule32 = 0x00000010,
        /// <summary>
        /// Includes all processes in the system in the snapshot. To enumerate the processes, see Process32First.
        /// </summary>
        SnapProcess = 0x00000002,
        /// <summary>
        /// Includes all threads in the system in the snapshot. To enumerate the threads, see Thread32First.<para/>
        /// To identify the threads that belong to a specific process, compare its process identifier to the th32OwnerProcessID member of the ThreadENTRY32 structure when enumerating the threads.
        /// </summary>
        SnapThread = 0x00000004,

    }
}