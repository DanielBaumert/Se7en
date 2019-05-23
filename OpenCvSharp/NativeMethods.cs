using System;
using System.Runtime.InteropServices;

namespace Se7en.OpenCvSharp
{


    public static class NativeMethods
    {
#pragma warning disable IDE1006
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_Canny(IntPtr src, IntPtr edges, double threshold1, double threshold2, int apertureSize, int L2gradient);
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern IntPtr core_Mat_new1();
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern IntPtr core_Mat_new8(int rows, int cols, MatType type, IntPtr data, ulong step);
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern IntPtr core_Mat_datastart(IntPtr self);
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern IntPtr core_Mat_dataend(IntPtr self);
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern ulong core_Mat_sizeof();
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern IntPtr cuda_GpuMat_new1();
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern IntPtr cuda_GpuMat_new3(int rows, int cols, MatType type, IntPtr data, ulong step);
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern IntPtr cuda_GpuMat_datastart(IntPtr obj);
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern IntPtr cuda_GpuMat_dataend(IntPtr obj);
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int cuda_getCudaEnabledDeviceCount();
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern IntPtr core_InputArray_new_byGpuMat(IntPtr mat);
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern IntPtr core_InputArray_new_byMat(IntPtr mat);
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern IntPtr core_OutputArray_new_byGpuMat(IntPtr mat);
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern IntPtr core_OutputArray_new_byMat(IntPtr mat);
        #pragma warning restore CS1633 // Unbekannte #pragma-Direktive.
    }
}