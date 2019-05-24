using System;
using System.Runtime.InteropServices;

namespace OptTwlCtrl.OpenCvSharp
{


    public static class NativeMethods
    {
#pragma warning disable IDE1006
        #region CPU Matrix

        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_Mat_new1();
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern IntPtr core_Mat_new8(int rows, int cols, MatType type, IntPtr data, ulong step);
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern IntPtr core_Mat_datastart(IntPtr self);
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern IntPtr core_Mat_dataend(IntPtr self);
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_Mat_delete(IntPtr mat);
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern ulong core_Mat_sizeof();
        
        #endregion
        #region GPU Matrix

        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr cuda_GpuMat_new1();
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern IntPtr cuda_GpuMat_new3(int rows, int cols, MatType type, IntPtr data, ulong step);
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern IntPtr cuda_GpuMat_datastart(IntPtr obj);
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern IntPtr cuda_GpuMat_dataend(IntPtr obj);
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_GpuMat_delete(IntPtr obj);

        #endregion
        #region Input Array

        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_InputArray_new_byGpuMat(IntPtr mat);
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern IntPtr core_InputArray_new_byMat(IntPtr mat);
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_InputArray_delete(IntPtr ia);
        
        #endregion
        #region Output Array

        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_OutputArray_new_byGpuMat(IntPtr mat);
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern IntPtr core_OutputArray_new_byMat(IntPtr mat);
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_OutputArray_delete(IntPtr oa);
        
        #endregion

        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_Canny(IntPtr src, IntPtr edges, double threshold1, double threshold2, int apertureSize, int L2gradient);
        
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int cuda_getCudaEnabledDeviceCount();
#pragma warning restore CS1633 // Unbekannte #pragma-Direktive.
    }
}