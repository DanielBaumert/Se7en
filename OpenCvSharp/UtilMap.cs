public class UtilMap : DisposableObject
    {
        public IntPtr DataStart { get => _DataStart(Ptr); }
        public IntPtr Ptr;

        private readonly static Func<IntPtr> _Create;
        private readonly static Func<int, int, MatType, IntPtr, ulong, IntPtr> _Create2;
        private readonly static Func<IntPtr, IntPtr> _DataStart;
        private readonly static Action<IntPtr> _DisposeUnmanaged;

        public readonly static Func<IntPtr, IntPtr> _InputArray;
        public readonly static Func<IntPtr, IntPtr> _OutputArray;

        static UtilMap() {
            if (Cv2.GetCudaEnabledDeviceCount() > 0) {
                _Create = NativeMethods.cuda_GpuMat_new1;
                _Create2 = NativeMethods.cuda_GpuMat_new3;
                _DataStart = NativeMethods.cuda_GpuMat_datastart;
                _DisposeUnmanaged = NativeMethods.cuda_GpuMat_delete;
                _InputArray = NativeMethods.core_InputArray_new_byGpuMat;
                _OutputArray = NativeMethods.core_OutputArray_new_byGpuMat;
            } else {
                _Create = NativeMethods.core_Mat_new1;
                _Create2 = NativeMethods.core_Mat_new8;
                _DataStart = NativeMethods.core_Mat_datastart;
                _DisposeUnmanaged = NativeMethods.cuda_GpuMat_delete;
                _InputArray = NativeMethods.core_InputArray_new_byMat;
                _OutputArray = NativeMethods.core_OutputArray_new_byMat;
            }
        }

        public UtilMap() => Ptr = _Create();

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged() {
            if (Ptr != IntPtr.Zero) {
                _DisposeUnmanaged(Ptr);
            }
            base.DisposeUnmanaged();
        }

        public UtilMap(int rows, int cols, MatType type, IntPtr data, ulong step = 0L) => Ptr = _Create2(rows, cols, type, data, step);
        

    }
