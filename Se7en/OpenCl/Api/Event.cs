using Se7en.OpenCl.Api.Enum;
using Se7en.OpenCl.Api.Native;
using System;
using System.Runtime.InteropServices;

namespace Se7en.OpenCl
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly unsafe struct Event : IRefCountedHandle
    {
        public readonly IntPtr Handle;

        internal Event(IntPtr handle)
            => Handle = handle;

        public CommandExecutionStatus CommandExecutionStatus => Utils.GetTInfo<EventInfo, CommandExecutionStatus>(Handle, EventInfo.CommandExecutionStatus, Cl.GetEventInfo);
        public CommandQueue CommandQueue => Utils.GetTInfo<EventInfo, CommandQueue>(Handle, EventInfo.CommandQueue, Cl.GetEventInfo);
        public CommandType CommandType => Utils.GetTInfo<EventInfo, CommandType>(Handle, EventInfo.CommandType, Cl.GetEventInfo);
        public Context Context => Utils.GetTInfo<EventInfo, Context>(Handle, EventInfo.Context, Cl.GetEventInfo);
        public uint ReferenceCount => Utils.GetTInfo<EventInfo, uint>(Handle, EventInfo.ReferenceCount, Cl.GetEventInfo);

        public void WaitForComplete() => Cl.WaitForEvents(1, new Event []{ this });

        #region IRefCountedHandle Members

        public ErrorCode Retain()
            => Cl.RetainEvent(Handle);

        public ErrorCode Release()
            => Cl.ReleaseEvent(Handle);

        #endregion

        #region IDisposable Members

        public void Dispose()
            => Release();

        #endregion
    }
}