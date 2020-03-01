using Se7en.OpenCl.Api.Enum;
using System;
using System.Runtime.InteropServices;

namespace Se7en.OpenCl.Api.Native
{
    public unsafe static partial class Cl
    {

        [DllImport(InternalLibLoader.OpenCL, EntryPoint = "clCreateContext")]
        public static extern IntPtr CreateContext([In] [MarshalAs(UnmanagedType.LPArray)] ContextProperty[] properties,
                                                     uint numDevices,
                                                     [In] [MarshalAs(UnmanagedType.LPArray)] Device[] devices,
                                                     ContextNotify pfnNotify,
                                                     IntPtr userData,
                                                     out ErrorCode errcodeRet);

        [DllImport(InternalLibLoader.OpenCL, EntryPoint = "clCreateContext")]
        public static extern IntPtr CreateContext([In] [MarshalAs(UnmanagedType.LPArray)] ContextProperty[] properties,
                                                    uint numDevices,
                                                    [In] [MarshalAs(UnmanagedType.LPArray)] void* devices,
                                                    ContextNotify pfnNotify,
                                                    IntPtr userData,
                                                    [Out] [MarshalAs(UnmanagedType.I4)] out ErrorCode errcodeRet);

        [DllImport(InternalLibLoader.OpenCL, EntryPoint = "clCreateContextFromType")]
        public static extern IntPtr CreateContextFromType([In] [MarshalAs(UnmanagedType.LPArray)] ContextProperty[] properties,
                                                             DeviceType deviceType,
                                                             ContextNotify pfnNotify,
                                                             IntPtr userData,
                                                             [Out] [MarshalAs(UnmanagedType.I4)] out ErrorCode errcodeRet);

        [DllImport(InternalLibLoader.OpenCL, EntryPoint = "clGetContextInfo")]
        public static extern ErrorCode GetContextInfo(IntPtr context,
                                                        ContextInfo paramName,
                                                        uint paramValueSize,
                                                        void* paramValue,
                                                        out uint paramValueSizeRet);


        [DllImport(InternalLibLoader.OpenCL, EntryPoint = "clRetainContext")]
        public static extern ErrorCode RetainContext(IntPtr context);

        [DllImport(InternalLibLoader.OpenCL, EntryPoint = "clReleaseContext")]
        public static extern ErrorCode ReleaseContext(IntPtr context);

    }
}