using Se7en.OpenCl.Api.Enum;
using Se7en.OpenCl.Api.Native;
using System;
using System.Runtime.InteropServices;

namespace Se7en.OpenCl
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly unsafe struct CommandQueue : IRefCountedHandle
    {
        public readonly IntPtr Handle;

        internal CommandQueue(IntPtr handle)
            => Handle = handle;

        public Context Context 
            => Utils.GetTInfo<CommandQueueInfo, Context>(Handle, CommandQueueInfo.Context, Cl.GetCommandQueueInfo);
        public Device Device
            => Utils.GetTInfo<CommandQueueInfo, Device>(Handle, CommandQueueInfo.Device, Cl.GetCommandQueueInfo);
        public uint ReferenceCount
            => Utils.GetTInfo<CommandQueueInfo, uint>(Handle, CommandQueueInfo.ReferenceCount, Cl.GetCommandQueueInfo);
        public CommandQueueProperties Properties
            => Utils.GetTInfo<CommandQueueInfo, CommandQueueProperties>(Handle, CommandQueueInfo.Properties, Cl.GetCommandQueueInfo);
        public uint Size
            => Utils.GetTInfo<CommandQueueInfo, uint>(Handle, CommandQueueInfo.Size, Cl.GetCommandQueueInfo);

        #region IRefCountedHandle Members

        public ErrorCode Retain()
           => Cl.RetainCommandQueue(Handle);

        public ErrorCode Release()
            => Cl.ReleaseCommandQueue(Handle);

        #endregion

        #region IDisposable Members

        public void Dispose()
            => Release();

        #endregion

        public static implicit operator IntPtr(CommandQueue queue)
            => queue.Handle;
    }
}
