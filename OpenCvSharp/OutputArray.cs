using System;

namespace Se7en.OpenCvSharp
{
    /// <summary>
	/// Proxy datatype for passing Mat's and List&lt;&gt;'s as output parameters
	/// </summary>
	public class OutputArray : DisposableCvObject
    {
        private readonly object obj;
        public bool IsUtilMap { get => obj is UtilMap; }
        internal OutputArray(UtilMap mat) {
            if (mat == null) {
                throw new ArgumentNullException("mat");
            }
            ptr = UtilMap._OutputArray(mat.Ptr);
            GC.KeepAlive(mat);
            obj = mat;
        }
        public bool IsReady() => ptr != IntPtr.Zero && !IsDisposed && obj != null && IsUtilMap;
        public void ThrowIfNotReady() {
            if (!IsReady()) {
                throw new OpenCvSharpException("Invalid OutputArray");
            }
        }
        public virtual void AssignResult() {
            if (!IsReady()) {
                throw new NotSupportedException();
            }
            if (!IsUtilMap) {
                throw new OpenCvSharpException("Not supported OutputArray-compatible type");
            }
        }
        public void Fix() {
            AssignResult();
            Dispose();
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged() {
            if (ptr != IntPtr.Zero) {
                NativeMethods.core_OutputArray_delete(ptr);
            }
            base.DisposeUnmanaged();
        }

        public static implicit operator OutputArray(UtilMap mat) => new OutputArray(mat);
    }
}