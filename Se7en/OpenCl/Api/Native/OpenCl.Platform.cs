using Se7en.OpenCl.Api.Enum;
using System;
using System.Runtime.InteropServices;

namespace Se7en.OpenCl.Api.Native
{
    public unsafe static partial class Cl
    {

        [DllImport(InternalLibLoader.OpenCL, EntryPoint = "clGetPlatformIDs")]
        public static extern ErrorCode GetPlatformIDs(uint numEntries,
                                                         [Out] [MarshalAs(UnmanagedType.LPArray)] Platform[] platforms,
                                                         out uint numPlatforms);
        [DllImport(InternalLibLoader.OpenCL, EntryPoint = "clGetPlatformInfo")]
        public static extern ErrorCode GetPlatformInfo(IntPtr platform,
                                                PlatformInfo paramName,
                                                uint paramValueSize,
                                                void* paramValue,
                                                out uint paramValueSizeRet);
    }
}


/*
 * \[DllImport\(Library\)\]\s*\n\s+((?:[^\s]+\s){4})(cl([^(]+))
 * [DllImport(Library, EntryPoint = "$2")]\n$1$3
 */
