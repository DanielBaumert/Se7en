﻿using System;

namespace OptTwlCtrl.OpenCvSharp
{
    public class UtilMap : DisposableObject
    {
        public IntPtr DataStart { get => DataStart1(Ptr); }
        public IntPtr Ptr;

        private readonly static Func<IntPtr> Create1;
        private readonly static Func<int, int, MatType, IntPtr, ulong, IntPtr> Create2;
        private readonly static Func<IntPtr, IntPtr> DataStart1;
        private readonly static Action<IntPtr> DisposeUnmanaged1;

        public readonly static Func<IntPtr, IntPtr> InputArray;
        public readonly static Func<IntPtr, IntPtr> OutputArray;

        static UtilMap() {
            if (Cv2.GetCudaEnabledDeviceCount() > 0) {
                Create1 = NativeMethods.cuda_GpuMat_new1;
                Create2 = NativeMethods.cuda_GpuMat_new3;
                DataStart1 = NativeMethods.cuda_GpuMat_datastart;
                DisposeUnmanaged1 = NativeMethods.cuda_GpuMat_delete;
                InputArray = NativeMethods.core_InputArray_new_byGpuMat;
                OutputArray = NativeMethods.core_OutputArray_new_byGpuMat;
            } else {
                Create1 = NativeMethods.core_Mat_new1;
                Create2 = NativeMethods.core_Mat_new8;
                DataStart1 = NativeMethods.core_Mat_datastart;
                DisposeUnmanaged1 = NativeMethods.cuda_GpuMat_delete;
                InputArray = NativeMethods.core_InputArray_new_byMat;
                OutputArray = NativeMethods.core_OutputArray_new_byMat;
            }
        }

        public UtilMap() => Ptr = Create1();

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged() {
            if (Ptr != IntPtr.Zero) {
                DisposeUnmanaged1(Ptr);
            }
            base.DisposeUnmanaged();
        }

        public UtilMap(int rows, int cols, MatType type, IntPtr data, ulong step = 0L) => Ptr = Create2(rows, cols, type, data, step);
        

    }
}