using System;
using System.Runtime.InteropServices;

namespace Se7en.OpenCvSharp
{


    public static class NativeMethods
    {
#pragma warning disable IDE1006

        #region CPU Matrix

        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_Mat_new1();
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_Mat_new2(int rows, int cols, MatType type);
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
        public static extern IntPtr cuda_GpuMat_new2(int rows, int cols, MatType type);
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
        #region Filter

        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_Canny(IntPtr src, IntPtr edges, double threshold1, double threshold2, int apertureSize, int L2gradient);
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_GaussianBlur(IntPtr src, IntPtr dst, Size ksize, double sigmaX, double sigmaY, int borderType);
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_cvtColor(IntPtr src, IntPtr dst, ColorConversionCodes code, int dstCn);
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_HoughLines(IntPtr src, IntPtr lines, double rho, double theta, int threshold, double srn, double stn);
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_HoughLinesP(IntPtr src, IntPtr lines, double rho, double theta, int threshold, double minLineLength, double maxLineG);
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_erode(IntPtr src, IntPtr dst, IntPtr kernel, Point anchor, int iterations, int borderType, Scalar borderValue);
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_addWeighted(IntPtr src1, double alpha, IntPtr src2, double beta, double gamma, IntPtr dst, int dtype);
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_bitwise_not(IntPtr src, IntPtr dst, IntPtr mask);
        #endregion
        #region Vec2f

        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Vec2f_new1();
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Vec2f_new2(IntPtr size);
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Vec2f_new3([In] Vec2f[] data, IntPtr dataLength);
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_Vec2f_delete(IntPtr vector);
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Vec2f_getSize(IntPtr vector);
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Vec2f_getPointer(IntPtr vector);

        #endregion
        #region Vec4i

        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Vec4i_new1();
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Vec4i_new2(IntPtr size);
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Vec4i_new3([In] Vec4i[] data, IntPtr dataLength);
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Vec4i_getSize(IntPtr vector);
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_Vec4i_getPointer(IntPtr vector);
        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_Vec4i_delete(IntPtr vector);

        #endregion

        #region Drawings

        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_line(IntPtr img, Point pt1, Point pt2, Scalar color, int thickness, int lineType, int shift);

        #endregion

        [DllImport("OpenCvSharpExtern", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int cuda_getCudaEnabledDeviceCount();
#pragma warning restore CS1633 // Unbekannte #pragma-Direktive.
    }
}