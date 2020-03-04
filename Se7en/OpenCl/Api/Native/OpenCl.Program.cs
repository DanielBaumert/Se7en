using Se7en.OpenCl.Api.Enum;
using System;
using System.Runtime.InteropServices;

namespace Se7en.OpenCl.Api.Native
{
    public unsafe static partial class Cl
    {
        [DllImport(InternalLibLoader.OpenCL, EntryPoint = "clCreateProgramWithSource")]
        public static extern IntPtr CreateProgramWithSource(Context context,
                                                           uint count,
                                                           [In] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr, SizeParamIndex = 1)] string[] strings,
                                                           [In] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.SysUInt, SizeParamIndex = 1)] IntPtr[] lengths,
                                                           out ErrorCode errcodeRet);


        [DllImport(InternalLibLoader.OpenCL, EntryPoint = "clBuildProgram")]
        public static extern ErrorCode BuildProgram(IntPtr program,
                                                       uint numDevices,
                                                       [In] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.SysUInt, SizeParamIndex = 1)] Device[] deviceList,
                                                       [In] [MarshalAs(UnmanagedType.LPStr)] string options,
                                                       ProgramNotify pfnNotify,
                                                       IntPtr userData);
        [DllImport(InternalLibLoader.OpenCL, EntryPoint = "clBuildProgram")]
        public static extern ErrorCode BuildProgram(IntPtr program,
                                                      uint numDevices,
                                                      [In] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.SysUInt, SizeParamIndex = 1)] Device* deviceList,
                                                      [In] [MarshalAs(UnmanagedType.LPStr)] string options,
                                                      ProgramNotify pfnNotify,
                                                      IntPtr userData);

        [DllImport(InternalLibLoader.OpenCL, EntryPoint = "clRetainProgram")]
        public static extern ErrorCode RetainProgram(IntPtr program);

        [DllImport(InternalLibLoader.OpenCL, EntryPoint = "clReleaseProgram")]
        public static extern ErrorCode ReleaseProgram(IntPtr program);

        [DllImport(InternalLibLoader.OpenCL, EntryPoint = "clGetProgramInfo")]
        public static extern ErrorCode GetProgramInfo(IntPtr program,
                                                        ProgramInfo paramName,
                                                        uint paramValueSize,
                                                        void* paramValue,
                                                        out uint paramValueSizeRet);

    }
}
/*
 * \[DllImport\(Library\)\]\s*\n\s+((?:[^\s]+\s){4})(cl([^(]+))
 * [DllImport(Library, EntryPoint = "$2")]\n$1$3
 */
