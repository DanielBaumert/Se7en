using Se7en.OpenCl.Api.Enum;
using System;
using System.Runtime.InteropServices;

namespace Se7en.OpenCl.Api.Native
{
    public unsafe static partial class Cl
    {
        [DllImport(InternalLibLoader.OpenCL, EntryPoint = "clCreateKernel")]
        public static extern IntPtr CreateKernel(IntPtr program,
                                                   [In] [MarshalAs(UnmanagedType.LPStr)] string kernelName,
                                                   [Out] [MarshalAs(UnmanagedType.I4)] out ErrorCode errcodeRet);

        [DllImport(InternalLibLoader.OpenCL, EntryPoint = "clCreateKernelsInProgram")]
        public static extern ErrorCode CreateKernelsInProgram(IntPtr program,
                                                               uint numKernels,
                                                               [Out] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.SysUInt, SizeParamIndex = 1)] Kernel[] kernels,
                                                               out uint numKernelsRet);

        [DllImport(InternalLibLoader.OpenCL, EntryPoint = "clRetainKernel")]
        public static extern ErrorCode RetainKernel(IntPtr kernel);
        [DllImport(InternalLibLoader.OpenCL, EntryPoint = "clReleaseKernel")]
        public static extern ErrorCode ReleaseKernel(IntPtr kernel);

        [DllImport(InternalLibLoader.OpenCL, EntryPoint = "clSetKernelArg")]
        public static extern ErrorCode SetKernelArg(IntPtr kernel, uint argIndex, int argSize, IntPtr argValue);
        [DllImport(InternalLibLoader.OpenCL, EntryPoint = "clGetKernelInfo")]
        public static extern ErrorCode GetKernelInfo(IntPtr kernel,
                                                        KernelInfo paramName,
                                                        uint paramValueSize,
                                                        void* paramValue,
                                                        out uint paramValueSizeRet);

        [DllImport(InternalLibLoader.OpenCL, EntryPoint = "clEnqueueNDRangeKernel")]
        public static extern ErrorCode EnqueueNDRangeKernel(IntPtr commandQueue,
                                                               IntPtr kernel,
                                                               uint workDim,
                                                               [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] IntPtr[] globalWorkOffset,
                                                               [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] IntPtr[] globalWorkSize,
                                                               [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] IntPtr[] localWorkSize,
                                                               uint numEventsInWaitList,
                                                               [In] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.SysUInt, SizeParamIndex = 6)] Event[] eventWaitList,
                                                               [Out] [MarshalAs(UnmanagedType.Struct)] out Event e);
    }
}


/*
 * \[DllImport\(Library\)\]\s*\n\s+((?:[^\s]+\s){4})(cl([^(]+))
 * [DllImport(Library, EntryPoint = "$2")]\n$1$3
 */
