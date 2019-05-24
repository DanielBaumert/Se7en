using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace OptTwlCtrl.OpenCvSharp
{
    public abstract class DisposableObject : IDisposable
	{
		/// <summary>
		/// Gets a value indicating whether this instance has been disposed.
		/// </summary>
		public bool IsDisposed { get; protected set; }

		/// <summary>
		/// Gets or sets a value indicating whether you permit disposing this instance.
		/// </summary>
		public bool IsEnabledDispose { get; set; }

		/// <summary>
		/// Gets or sets a memory address allocated by AllocMemory.
		/// </summary>
		protected IntPtr AllocatedMemory { get; set; }

		/// <summary>
		/// Gets or sets the byte length of the allocated memory
		/// </summary>
		protected long AllocatedMemorySize { get; set; }

		/// <summary>
		/// Default constructor
		/// </summary>
		protected DisposableObject() : this(true)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="isEnabledDispose">true if you permit disposing this class by GC</param>
		protected DisposableObject(bool isEnabledDispose)
		{
			this.IsDisposed = false;
			this.IsEnabledDispose = isEnabledDispose;
			this.AllocatedMemory = IntPtr.Zero;
			this.AllocatedMemorySize = 0L;
		}

		/// <summary>
		/// Releases the resources
		/// </summary>
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Releases the resources
		/// </summary>
		/// <param name="disposing">
		/// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
		/// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
		/// </param>
		private void Dispose(bool disposing)
		{
			if (Interlocked.Exchange(ref this.disposeSignaled, 1) != 0)
			{
				return;
			}
			this.IsDisposed = true;
			if (this.IsEnabledDispose)
			{
				if (disposing)
				{
					this.DisposeManaged();
				}
				this.DisposeUnmanaged();
			}
		}

		/// <summary>
		/// Destructor
		/// </summary>
		~DisposableObject()
		{
			this.Dispose(false);
		}

		/// <summary>
		/// Releases managed resources
		/// </summary>
		protected virtual void DisposeManaged()
		{
		}

		/// <summary>
		/// Releases unmanaged resources
		/// </summary>
		protected virtual void DisposeUnmanaged()
		{
			if (this.dataHandle.IsAllocated)
			{
				this.dataHandle.Free();
			}
			if (this.AllocatedMemorySize > 0L)
			{
				GC.RemoveMemoryPressure(this.AllocatedMemorySize);
				this.AllocatedMemorySize = 0L;
			}
			if (this.AllocatedMemory != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(this.AllocatedMemory);
				this.AllocatedMemory = IntPtr.Zero;
			}
		}

		/// <summary>
		/// Pins the object to be allocated by cvSetData.
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		protected internal GCHandle AllocGCHandle(object obj)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			if (this.dataHandle.IsAllocated)
			{
				this.dataHandle.Free();
			}
			this.dataHandle = GCHandle.Alloc(obj, GCHandleType.Pinned);
			return this.dataHandle;
		}

		/// <summary>
		/// Allocates the specified size of memory.
		/// </summary>
		/// <param name="size"></param>
		/// <returns></returns>
		protected IntPtr AllocMemory(int size)
		{
			if (size <= 0)
			{
				throw new ArgumentOutOfRangeException("size");
			}
			if (this.AllocatedMemory != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(this.AllocatedMemory);
			}
			this.AllocatedMemory = Marshal.AllocHGlobal(size);
			this.NotifyMemoryPressure((long)size);
			return this.AllocatedMemory;
		}

		/// <summary>
		/// Notifies the allocated size of memory.
		/// </summary>
		/// <param name="size"></param>
		protected void NotifyMemoryPressure(long size)
		{
			if (!this.IsEnabledDispose)
			{
				return;
			}
			if (size == 0L)
			{
				return;
			}
			if (size <= 0L)
			{
				throw new ArgumentOutOfRangeException("size");
			}
			if (this.AllocatedMemorySize > 0L)
			{
				GC.RemoveMemoryPressure(this.AllocatedMemorySize);
			}
			this.AllocatedMemorySize = size;
			GC.AddMemoryPressure(size);
		}

		/// <summary>
		/// If this object is disposed, then ObjectDisposedException is thrown.
		/// </summary>
		public void ThrowIfDisposed()
		{
			if (this.IsDisposed)
			{
				throw new ObjectDisposedException(base.GetType().FullName);
			}
		}

		/// <summary>
		/// Gets or sets a handle which allocates using cvSetData.
		/// </summary>
		protected GCHandle dataHandle;
		private volatile int disposeSignaled;
	}
}