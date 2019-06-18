using System;

namespace Se7en.OpenCvSharp {

    /// <summary>
	/// Proxy datatype for passing Mat's and vector&lt;&gt;'s as input parameters
	/// </summary>
	public class InputArray : DisposableCvObject {
        private readonly object obj;
        public bool IsUtilMap { get => obj is UtilMap; }

        internal InputArray(UtilMap mat) {
            if (mat == null) {
                throw new ArgumentNullException("mat");
            }
            ptr = UtilMap._InputArray(mat.Ptr);
            GC.KeepAlive(mat);
            obj = mat;
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged() {
            if (ptr != IntPtr.Zero) {
                NativeMethods.core_InputArray_delete(ptr);
            }
            base.DisposeUnmanaged();
        }

        public static implicit operator InputArray(UtilMap mat) => new InputArray(mat);
    }
}