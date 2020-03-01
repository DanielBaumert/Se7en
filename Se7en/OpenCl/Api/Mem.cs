using Se7en.OpenCl.Api.Enum;
using Se7en.OpenCl.Api.Native;
using System;
using System.Runtime.InteropServices;

namespace Se7en.OpenCl
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly unsafe struct Mem : IRefCountedHandle
    {
        public readonly IntPtr Handle;

        internal Mem(IntPtr handle)
            => Handle = handle;

        public readonly MemObjectType Type => Utils.GetTInfo<MemInfo, MemObjectType>(Handle, MemInfo.Type, Cl.GetMemObjectInfo);
        public readonly MemFlags Flags => Utils.GetTInfo<MemInfo, MemFlags>(Handle, MemInfo.Flags, Cl.GetMemObjectInfo);
        public readonly uint Size => Utils.GetTInfo<MemInfo, uint>(Handle, MemInfo.Size, Cl.GetMemObjectInfo);
        public readonly IntPtr HostPtr => Utils.GetTInfo<MemInfo, IntPtr>(Handle, MemInfo.HostPtr, Cl.GetMemObjectInfo);
        public readonly uint MapCount => Utils.GetTInfo<MemInfo, uint>(Handle, MemInfo.MapCount, Cl.GetMemObjectInfo);
        public readonly uint ReferenceCount => Utils.GetTInfo<MemInfo, uint>(Handle, MemInfo.ReferenceCount, Cl.GetMemObjectInfo);
        public readonly Context Context => Utils.GetTInfo<MemInfo, Context>(Handle, MemInfo.Context, Cl.GetMemObjectInfo);
        public readonly IntPtr AssociatedMemObject => Utils.GetTInfo<MemInfo, IntPtr>(Handle, MemInfo.Context, Cl.GetMemObjectInfo);
        public readonly uint Offset => Utils.GetTInfo<MemInfo, uint>(Handle, MemInfo.Offset, Cl.GetMemObjectInfo);
        public readonly IntPtr UsesSvmPointer => Utils.GetTInfo<MemInfo, IntPtr>(Handle, MemInfo.UsesSvmPointer, Cl.GetMemObjectInfo);

        #region IRefCountedHandle Members

        public ErrorCode Retain()
            => Cl.RetainMemObject(this);

        public ErrorCode Release()
            => Cl.ReleaseMemObject(this);

        #endregion

        #region IDisposable Members
        public void Dispose()
            => Release();

        #endregion

        public static implicit operator IntPtr(Mem memObj)
            => memObj.Handle;
    }

}
