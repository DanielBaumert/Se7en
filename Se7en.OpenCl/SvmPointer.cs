using Se7en.OpenCl.Api.Enum;
using Se7en.OpenCl.Api.Native;
using Se7en.Utils;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Se7en.OpenCl
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe readonly struct SvmPointer : IDisposable
    {
        internal readonly IntPtr _handle;
        private readonly Context _ctx;
        public byte this[int offset] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => *((byte*)_handle + offset);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => *((byte*)_handle + offset) = value;
        }

        public byte this[int x, int y, int width] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => *((byte*)_handle + (y * width) + x);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => *((byte*)_handle + (y * width) + x) = value;
        }

        internal SvmPointer(Context ctx, IntPtr ptr)
        {
            _ctx = ctx;
            _handle = ptr;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal ErrorCode Lock(CommandQueue queue, IntPtr length)
            => Cl.EnqueueSVMMap(queue, true.ToInt(), MapFlags.Read | MapFlags.Write, this, length, 0, null, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal ErrorCode Unlock(CommandQueue queue)
            => Cl.EnqueueSVMUnmap(queue, this, 0, null, out _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose() => Cl.SVMFree(_ctx, _handle);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator IntPtr(SvmPointer pointer) => pointer._handle;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator void*(SvmPointer pointer) => (void*)pointer._handle;
    }


    [StructLayout(LayoutKind.Sequential)]
    public readonly unsafe struct SvmPointer<T> : IDisposable
        where T : unmanaged
    {
        internal readonly SvmPointer _pointer;
        public readonly T* Pointer => (T*)_pointer;

        public T this[int offset] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => *(Pointer + offset);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => *(Pointer + offset) = value;
        }
        public T this[int x, int y, int width] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => *(Pointer + (y * width) + x);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => *(Pointer + (y * width) + x) = value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal SvmPointer(SvmPointer svmPointer) => _pointer = svmPointer;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose() => _pointer.Dispose();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator SvmPointer<T>(SvmPointer pointer) => new SvmPointer<T>(pointer);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator SvmPointer(SvmPointer<T> pointer) => pointer._pointer;
    }
    /*------------------------------------------------------------------------------------------------------------*/
    //[StructLayout(LayoutKind.Sequential)]
    //public readonly unsafe struct SVMCoarseGrainBuffer : IDisposable
    //{
    //    internal readonly SvmPointer _pointer;
    //    internal readonly CommandQueue _queue;
    //    public readonly IntPtr Length;
    //    public byte this[int offset] {
    //        [MethodImpl(MethodImplOptions.AggressiveInlining)]
    //        get => _pointer[offset];
    //        [MethodImpl(MethodImplOptions.AggressiveInlining)]
    //        set => _pointer[offset] = value;
    //    }
    //    public byte this[int x, int y, int width] {
    //        [MethodImpl(MethodImplOptions.AggressiveInlining)]
    //        get => _pointer[x, y, width];
    //        [MethodImpl(MethodImplOptions.AggressiveInlining)]
    //        set => _pointer[x, y, width] = value;
    //    }

    //    public SVMCoarseGrainBuffer(Context ctx, CommandQueue commandQueue, IntPtr length) {
    //        _queue = commandQueue;
    //        _pointer = new SvmPointer(ctx, Cl.SVMAlloc(ctx, SVMMemFlags.ReadWrite | SVMMemFlags.FineGrainBuffer, length));
    //        Length = length;
    //    }

    //    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    //    internal ErrorCode Lock()
    //        => _pointer.Lock(_queue, Length);
    //    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    //    internal ErrorCode Unlock()
    //        => _pointer.Unlock(_queue);

    //    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    //    public void Dispose() => _pointer.Dispose();

    //    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    //    public static implicit operator SvmPointer(SVMCoarseGrainBuffer coarseGrainBuffer) => coarseGrainBuffer._pointer;

    //}

    //[StructLayout(LayoutKind.Sequential)]
    //public readonly unsafe struct SVMCoarseGrainBuffer<T>
    //    where T : unmanaged
    //{
    //    internal readonly SvmPointer<T> _pointer;


    //    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    //    public static implicit operator SvmPointer<T>(SVMCoarseGrainBuffer<T> coarseGrainBuffer) => coarseGrainBuffer._pointer;
    //}
}
