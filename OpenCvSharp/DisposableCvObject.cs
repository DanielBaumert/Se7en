using System;

namespace Se7en.OpenCvSharp {

    /// <summary>
	/// DisposableObject + ICvPtrHolder
	/// </summary>
	public abstract class DisposableCvObject : DisposableObject, ICvPtrHolder {

        /// <summary>
        /// Default constructor
        /// </summary>
        protected DisposableCvObject() : this(true) {
        }

        /// <param name="ptr"></param>
        protected DisposableCvObject(IntPtr ptr) : this(ptr, true) {
        }

        /// <param name="isEnabledDispose"></param>
        protected DisposableCvObject(bool isEnabledDispose) : this(IntPtr.Zero, isEnabledDispose) {
        }

        /// <param name="ptr"></param>
        /// <param name="isEnabledDispose"></param>
        protected DisposableCvObject(IntPtr ptr, bool isEnabledDispose) : base(isEnabledDispose) => this.ptr = ptr;

        /// <summary>
        /// releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged() {
            base.DisposeUnmanaged();
            ptr = IntPtr.Zero;
        }

        /// <summary>
        /// Native pointer of OpenCV structure
        /// </summary>
        public IntPtr CvPtr {
            get {
                ThrowIfDisposed();
                return ptr;
            }
        }

        IntPtr ICvPtrHolder.CvPtr => throw new NotImplementedException();

        /// <summary>
        /// Data pointer
        /// </summary>
        protected IntPtr ptr;
    }
}