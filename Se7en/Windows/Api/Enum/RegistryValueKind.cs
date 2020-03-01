using System;
using System.Collections.Generic;
using System.Text;

namespace Se7en.Windows.Api.Enum
{
    public enum RegistryValueKind
    {
        Unknown = 0,                          // REG_NONE is defined as zero but BCL
        String = 1,
        ExpandString = 2,
        Binary = 3,
        DWord = 4,
        MultiString = 7,
        QWord = 11,

        [System.Runtime.InteropServices.ComVisible(false)]
        None = unchecked((int)0xFFFFFFFF), //  mistakingly overrode this value.  
    }   // Now instead of using Win32Native.REG_NONE we use "-1" and play games internally.
}


