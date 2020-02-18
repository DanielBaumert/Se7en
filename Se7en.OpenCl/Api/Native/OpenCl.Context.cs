using Se7en.OpenCl.Api.Enum;
using System;
using System.Runtime.InteropServices;

namespace Se7en.OpenCl.Api.Native
{
    public unsafe static partial class Cl
    {

        [DllImport(Library, EntryPoint = "clCreateContext")]
        public static extern IntPtr CreateContext([In] [MarshalAs(UnmanagedType.LPArray)] ContextProperty[] properties,
                                                     uint numDevices,
                                                     [In] [MarshalAs(UnmanagedType.LPArray)] Device[] devices,
                                                     ContextNotify pfnNotify,
                                                     IntPtr userData,
                                                     out ErrorCode errcodeRet);

        [DllImport(Library, EntryPoint = "clCreateContext")]
        public static extern IntPtr CreateContext([In] [MarshalAs(UnmanagedType.LPArray)] ContextProperty[] properties,
                                                    uint numDevices,
                                                    [In] [MarshalAs(UnmanagedType.LPArray)] void* devices,
                                                    ContextNotify pfnNotify,
                                                    IntPtr userData,
                                                    [Out] [MarshalAs(UnmanagedType.I4)] out ErrorCode errcodeRet);

        [DllImport(Library, EntryPoint = "clCreateContextFromType")]
        public static extern IntPtr CreateContextFromType([In] [MarshalAs(UnmanagedType.LPArray)] ContextProperty[] properties,
                                                             DeviceType deviceType,
                                                             ContextNotify pfnNotify,
                                                             IntPtr userData,
                                                             [Out] [MarshalAs(UnmanagedType.I4)] out ErrorCode errcodeRet);

        [DllImport(Library, EntryPoint = "clGetContextInfo")]
        public static extern ErrorCode GetContextInfo(IntPtr context,
                                                        ContextInfo paramName,
                                                        uint paramValueSize,
                                                        void* paramValue,
                                                        out uint paramValueSizeRet);


        [DllImport(Library, EntryPoint = "clRetainContext")]
        public static extern ErrorCode RetainContext(IntPtr context);

        [DllImport(Library, EntryPoint = "clReleaseContext")]
        public static extern ErrorCode ReleaseContext(IntPtr context);

    }
}