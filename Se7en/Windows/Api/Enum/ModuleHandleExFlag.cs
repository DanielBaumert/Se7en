#if Windows
using System;

namespace Se7en.Windows.Api.Enum
{
    [Flags]
    public enum ModuleHandleExFlag
    {
        /// <summary>
        /// The module stays loaded until the process is terminated, no matter how many times FreeLibrary is called.<para/>
        /// This option cannot be used with GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT.
        /// </summary>
        GetPin = (1 << 0),
        /// <summary>
        /// The reference count for the module is not incremented.<br/>
        /// This option is equivalent to the behavior of GetModuleHandle.<br/>
        /// Do not pass the retrieved module handle to the FreeLibrary function; doing so can cause the DLL to be unmapped prematurely.<br/>
        /// This option cannot be used with GET_MODULE_HANDLE_EX_FLAG_PIN.
        /// </summary>
        GetUnchangedRefCount = (1 << 1),
        /// <summary>
        /// The lpModuleName parameter is an address in the module.
        /// </summary>
        GetFromAddress = (1 << 2),

    }
}
#endif