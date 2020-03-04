using Se7en.OpenCl.Api.Enum;
using System;
using System.Runtime.InteropServices;

namespace Se7en.OpenCl.Api.Native
{
    public unsafe static partial class Cl
    {
        [DllImport(InternalLibLoader.OpenCL, EntryPoint = "clCreateBuffer")]
        public static extern IntPtr CreateBuffer(IntPtr context,
                                                  MemFlags flags,
                                                  long size, 
                                                  IntPtr hostPtr,
                                                  [Out] [MarshalAs(UnmanagedType.I4)] out ErrorCode errcodeRet);

        [DllImport(InternalLibLoader.OpenCL, EntryPoint = "clRetainMemObject")]
        public static extern ErrorCode RetainMemObject(IntPtr memObj);

        [DllImport(InternalLibLoader.OpenCL, EntryPoint = "clReleaseMemObject")]
        public static extern ErrorCode ReleaseMemObject(IntPtr memObj);



        [DllImport(InternalLibLoader.OpenCL, EntryPoint = "clEnqueueWriteBuffer")]
        public static extern ErrorCode EnqueueWriteBuffer(IntPtr commandQueue,
                                                             IntPtr buffer,
                                                             int blockingWrite,
                                                             IntPtr offsetInBytes,
                                                             int lengthInBytes,
                                                             IntPtr ptr,
                                                             uint numEventsInWaitList,
                                                             [In] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.SysUInt, SizeParamIndex = 6)] Event[] eventWaitList,
                                                             [Out] [MarshalAs(UnmanagedType.Struct)] out Event e);

        [DllImport(InternalLibLoader.OpenCL, EntryPoint = "clEnqueueReadBuffer")]
        public static extern ErrorCode EnqueueReadBuffer(IntPtr commandQueue,
                                                       IntPtr buffer,
                                                       int blockingRead,
                                                       int offsetInBytes,
                                                       int lengthInBytes,
                                                       void* ptr,
                                                       uint numEventsInWaitList,
                                                       [In] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.SysUInt, SizeParamIndex = 6)] Event[] eventWaitList,
                                                       [Out] [MarshalAs(UnmanagedType.Struct)] out Event e);


        [DllImport(InternalLibLoader.OpenCL, EntryPoint = "clGetMemObjectInfo")]
        public static extern ErrorCode GetMemObjectInfo(IntPtr memObj,
                                                          MemInfo paramName,
                                                          uint paramValueSize,
                                                          void* paramValue,
                                                          out uint paramValueSizeRet);


    }
}


/*
 * \[DllImport\(Library\)\]\s*\n\s+((?:[^\s]+\s){4})(cl([^(]+))
 * [DllImport(Library, EntryPoint = "$2")]\n$1$3
 */
