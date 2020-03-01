using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Se7en.OpenCl.Api.Enum;
using Se7en.OpenCl.Api.Native;
using Se7en.Utils;

namespace Se7en.OpenCl
{
    /// <summary>
    /// Hold the GPU program ready to run
    /// </summary>
    public readonly unsafe struct OpenClBridge : IDisposable
    {
        private readonly CommandQueue _commandQueue;
        private readonly IntPtr[] _memObj;
        private readonly int* _memObjSize;

        public readonly Context Context;
        public readonly Kernel Kernel;
        public readonly int Arguments;
        internal OpenClBridge(Context ctx, Device device, Kernel kernel)
        {
            Context = ctx;
            Kernel = kernel;

            _commandQueue = new CommandQueue(Cl.CreateCommandQueue(ctx, device, CommandQueueProperties.None, out _));
            Arguments = Kernel.NumArgs;
            _memObj = new IntPtr[Arguments];
            _memObjSize = (int*)Marshal.AllocHGlobal(Arguments * sizeof(int));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argIndex"></param>
        /// <param name="items"></param>
        /// <param name="length"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WriteInBuffer<T>(int argIndex, T* items, int length) where T : unmanaged
            => WriteBuffer(argIndex, items, length, MemFlags.CopyHostPtr | MemFlags.ReadOnly);
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argIndex"></param>
        /// <param name="items"></param>
        /// <param name="length"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WriteInOutBuffer<T>(int argIndex, T* items, int length) where T : unmanaged
          => WriteBuffer(argIndex, items, length, MemFlags.CopyHostPtr | MemFlags.ReadWrite);
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argIndex"></param>
        /// <param name="length">length in bytes</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WriteOutBuffer(int argIndex, int length)
        {
            fixed (IntPtr* memObjPtr = _memObj)
            {
                ErrorCode err;
                if (*(memObjPtr + argIndex) == IntPtr.Zero)
                {
                    *(_memObjSize + argIndex) = length;
                    IntPtr lmem = (*(memObjPtr + argIndex) = Cl.CreateBuffer(Context, MemFlags.WriteOnly, length, IntPtr.Zero, out err));
                    err = Cl.SetKernelArg(Kernel, (uint)argIndex, IntPtr.Size, lmem);
                }
                else if (*(_memObjSize + argIndex) < length)
                {
                    (*(Mem*)(memObjPtr + argIndex)).Dispose();
                    *(_memObjSize + argIndex) = length;
                    IntPtr lmem = (*(memObjPtr + argIndex) = Cl.CreateBuffer(Context, MemFlags.WriteOnly, length, IntPtr.Zero, out err));
                    err = Cl.SetKernelArg(Kernel, (uint)argIndex, IntPtr.Size, lmem);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argIndex"></param>
        /// <param name="items"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WriteInBuffer<T>(int argIndex, T[] items) where T : unmanaged
            => WriteBuffer(argIndex, items, MemFlags.CopyHostPtr | MemFlags.ReadOnly);
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argIndex"></param>
        /// <param name="items"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WriteInOutBuffer<T>(int argIndex, T[] items) where T : unmanaged
            => WriteBuffer(argIndex, items, MemFlags.CopyHostPtr | MemFlags.ReadWrite);
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argIndex"></param>
        /// <param name="localBuffer"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WriteOutBuffer<T>(int argIndex, T[] localBuffer) where T : unmanaged
        {
            int size = sizeof(T) * localBuffer.Length;
            fixed (IntPtr* memObjPtr = _memObj)
            {
                ErrorCode err;
                if (*(memObjPtr + argIndex) == IntPtr.Zero)
                {
                    *(_memObjSize + argIndex) = size;
                    *(memObjPtr + argIndex) = Cl.CreateBuffer(Context, MemFlags.WriteOnly, size, IntPtr.Zero, out err);
                    err = Cl.SetKernelArg(Kernel, (uint)argIndex, IntPtr.Size, (IntPtr)(memObjPtr + argIndex));
                }
                else if (*(_memObjSize + argIndex) < size)
                {
                    (*(Mem*)(memObjPtr + argIndex)).Dispose();
                    *(_memObjSize + argIndex) = size;
                    *(memObjPtr + argIndex) = Cl.CreateBuffer(Context, MemFlags.WriteOnly, size, IntPtr.Zero, out err);
                    err = Cl.SetKernelArg(Kernel, (uint)argIndex, IntPtr.Size, (IntPtr)(memObjPtr + argIndex));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argIndex"></param>
        /// <param name="localBuffer"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ReadOutBuffer<T>(int argIndex, T[] localBuffer) where T : unmanaged
        {
            fixed (IntPtr* memObjPtr = _memObj)
            fixed (T* localBufferPtr = localBuffer)
            {
                ErrorCode err;
                if ((err = Cl.EnqueueReadBuffer(_commandQueue, *(memObjPtr + argIndex), true.ToInt(), 0, sizeof(T) * localBuffer.Length, localBufferPtr, 0, null, out Event @event)) == ErrorCode.Success)
                {
                    @event.WaitForComplete();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argIndex"></param>
        /// <param name="localBuffer"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ReadOutBuffer<T>(int argIndex, T* localBuffer) where T : unmanaged
        {
            fixed (IntPtr* memObjPtr = _memObj)
            {
                ErrorCode err;
                if ((err = Cl.EnqueueReadBuffer(_commandQueue, *(memObjPtr + argIndex), true.ToInt(), 0, *(_memObjSize + argIndex), localBuffer, 0, null, out Event @event)) == ErrorCode.Success)
                {
                    @event.WaitForComplete();
                }
            }
        }
        /// <summary>
        /// Runing the GPU program
        /// </summary>
        /// <param name="workGroupSizePtr">image dimention in 3D</param>
        /// <param name="workingDim">global_id(n) (n := { (1D := 1), (2D := 2), (3D := 3) }</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Execute(IntPtr[] workGroupSizePtr, uint workingDim = 1)
        {
            ErrorCode err;
            if ((err = Cl.EnqueueNDRangeKernel(_commandQueue, Kernel, workingDim, null, workGroupSizePtr, null, 0, null, out Event @event)) != ErrorCode.Success)
            {
                throw new Exception($"{err}");
            }
            @event.WaitForComplete();
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetSvmArgs(params SvmPointer[] args)
        {
            ErrorCode err;
            int count = args.Length;
            fixed (SvmPointer* argsPtr = args)
            {
                for (uint i = 0; i < count; i++)
                {
                    if ((err = Cl.SetKernelArgSVMPointer(Kernel, i, *(argsPtr + i))) != ErrorCode.Success)
                    {
                        throw new Exception($"{err}");
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetSvmArgs(uint[] argIndex = null, params SvmPointer[] args)
        {
            ErrorCode err;
            int count = args.Length;
            if (argIndex != null)
            {
                if (count != argIndex.Length)
                {
                    throw new IndexOutOfRangeException($"{nameof(argIndex)}.length != {nameof(args)}.length");
                }

                fixed (uint* argIndexPtr = argIndex)
                fixed (SvmPointer* argsPtr = args)
                {
                    for (int i = 0; i < count; i++)
                    {
                        if ((err = Cl.SetKernelArgSVMPointer(Kernel, *(argIndexPtr + i), *(argsPtr + i))) != ErrorCode.Success)
                        {
                            throw new Exception($"{err}");
                        }
                    }
                }
            }
            throw new ArgumentNullException(nameof(argIndex));
        }
        /// <summary>
        /// Runing the GPU program
        /// </summary>
        /// <param name="workGroupSizePtr">image dimention in 3D</param>
        /// <param name="workingDim">global_id(n) (n := { (1D := 1), (2D := 2), (3D := 3) }</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Execute(IntPtr[] workGroupSizePtr, SvmPointer[] args, uint workingDim = 1)
        {
            SetSvmArgs(args);
            ErrorCode err;
            if ((err = Cl.EnqueueNDRangeKernel(_commandQueue, Kernel, workingDim, null, workGroupSizePtr, null, 0, null, out Event @event)) != ErrorCode.Success)
            {
                throw new Exception($"{err}");
            }
            @event.WaitForComplete();
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void WriteBuffer<T>(int argIndex, T* mem, int length, MemFlags flags) where T : unmanaged
        {
            int size = length;

            fixed (IntPtr* memObjPtr = _memObj)
            {
                ErrorCode err;
                if (*(memObjPtr + argIndex) == IntPtr.Zero)
                {
                    *(_memObjSize + argIndex) = size;
                    *(memObjPtr + argIndex) = Cl.CreateBuffer(Context, flags, size, (IntPtr)mem, out err);
                    err = Cl.SetKernelArg(Kernel, (uint)argIndex, IntPtr.Size, (IntPtr)(memObjPtr + argIndex));
                }
                else if (*(_memObjSize + argIndex) < size)
                {
                    (*(Mem*)(memObjPtr + argIndex)).Dispose();
                    *(_memObjSize + argIndex) = size;
                    *(memObjPtr + argIndex) = Cl.CreateBuffer(Context, flags, size, (IntPtr)mem, out err);
                    err = Cl.SetKernelArg(Kernel, (uint)argIndex, IntPtr.Size, (IntPtr)(memObjPtr + argIndex));
                }
                err = Cl.EnqueueWriteBuffer(_commandQueue, *(memObjPtr + argIndex), true.ToInt(), IntPtr.Zero, size, (IntPtr)mem, 0, null, out _);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void WriteBuffer<T>(int argIndex, T[] mem, MemFlags flags) where T : unmanaged
        {
            int size = sizeof(T) * mem.Length;

            fixed (IntPtr* memObjPtr = _memObj)
            fixed (T* itemsPtr = mem)
            {
                ErrorCode err;
                if (*(memObjPtr + argIndex) == IntPtr.Zero)
                {
                    *(_memObjSize + argIndex) = size;
                    *(memObjPtr + argIndex) = Cl.CreateBuffer(Context, flags, size, (IntPtr)itemsPtr, out err);
                    err = Cl.SetKernelArg(Kernel, (uint)argIndex, IntPtr.Size, (IntPtr)(memObjPtr + argIndex));
                }
                else if (*(_memObjSize + argIndex) < size)
                {
                    (*(Mem*)(memObjPtr + argIndex)).Dispose();
                    *(_memObjSize + argIndex) = size;
                    *(memObjPtr + argIndex) = Cl.CreateBuffer(Context, flags, size, (IntPtr)itemsPtr, out err);
                    err = Cl.SetKernelArg(Kernel, (uint)argIndex, IntPtr.Size, (IntPtr)(memObjPtr + argIndex));
                }
                err = Cl.EnqueueWriteBuffer(_commandQueue, *(memObjPtr + argIndex), true.ToInt(), IntPtr.Zero, size, (IntPtr)itemsPtr, 0, null, out _);
            }
        }

        public void Dispose()
        {
            _commandQueue.Dispose();
            fixed (IntPtr* memObjPtr = _memObj)
            {
                for (int iMemObj = 0; iMemObj < Arguments; iMemObj++)
                {
                    (*(Mem*)(memObjPtr + iMemObj)).Dispose();
                }
            }
            Marshal.FreeHGlobal((IntPtr)_memObjSize);
        }
    }
}
