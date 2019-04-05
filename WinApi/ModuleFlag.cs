using System;

namespace Se7en.WinApi
{
    [Flags]
    public enum GetModuleHandleExFlag
    {
        None = 0x0,
        /// <summary>
        /// The module stays loaded until the process is terminated, no matter how many times FreeLibrary is called. <para/>
        /// This option cannot be used with GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT.
        /// </summary>
        Pin = 0x00000001,
        /// <summary>
        /// The reference count for the module is not incremented. This option is equivalent to the behavior of GetModuleHandle. 
        /// Do not pass the retrieved module handle to the FreeLibrary function; doing so can cause the DLL to be unmapped prematurely.
        /// </summary>
        UnchangedRefcount = 0x00000002,
        /// <summary>
        /// The lpModuleName parameter is an address in the module.
        /// </summary>
        FromAddress = 0x00000004,
    }
}