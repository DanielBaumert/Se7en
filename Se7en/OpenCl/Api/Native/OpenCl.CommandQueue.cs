using Se7en.OpenCl.Api.Enum;
using System;
using System.Runtime.InteropServices;

namespace Se7en.OpenCl.Api.Native
{
    public unsafe static partial class Cl
    {
        [DllImport(InternalLibLoader.OpenCL, EntryPoint = "clCreateCommandQueue")]
        public static extern IntPtr CreateCommandQueue(IntPtr context, IntPtr device,
                                                        [MarshalAs(UnmanagedType.U8)] CommandQueueProperties properties,
                                                        [Out] [MarshalAs(UnmanagedType.I4)] out ErrorCode error);

        [DllImport(InternalLibLoader.OpenCL, EntryPoint = "clGetCommandQueueInfo")]
        public static extern ErrorCode GetCommandQueueInfo(IntPtr commandQueue,
                                                             [MarshalAs(UnmanagedType.U4)] CommandQueueInfo paramName,
                                                             uint paramValueSize,
                                                             void* paramValue,
                                                             out uint paramValueSizeRet);


        [DllImport(InternalLibLoader.OpenCL, EntryPoint = "clRetainCommandQueue")]
        public static extern ErrorCode RetainCommandQueue(IntPtr commandQueue);

        [DllImport(InternalLibLoader.OpenCL, EntryPoint = "clReleaseCommandQueue")]
        public static extern ErrorCode ReleaseCommandQueue(IntPtr commandQueue);


        [DllImport(InternalLibLoader.OpenCL, EntryPoint = "clFinish")]
        public static extern ErrorCode Finish(IntPtr commandQueue);
    }
}


/*
 * \[DllImport\(Library\)\]\s*\n\s+((?:[^\s]+\s){4})(cl([^(]+))
 * [DllImport(Library, EntryPoint = "$2")]\n$1$3
 */
