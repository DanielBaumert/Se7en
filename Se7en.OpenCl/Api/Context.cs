using Se7en.OpenCl.Api.Enum;
using Se7en.OpenCl.Api.Native;
using Se7en.Utils;
using System;
using System.Runtime.InteropServices;

namespace Se7en.OpenCl
{

    // =>[^<]+([^>]+)[^<]+([^>]+)>\(([^,]+), out _\)\[0\];
    // Utils.GetTInfo<$1, $2>(_handle, $3, _getInfoHandler, out _).First();
    // =>[^<]+<([^>]+)[^<]+<([^>]+)>\(([^,]+), out _\)\.ToStrg\(\);
    // => Utils.GetTInfo<$1, $2>(_handle, $3, _getInfoHandler, out _).ToStrg();
    // ((IHandleObjInfo<DeviceInfo>)this).GetTInfo<uint>(DeviceInfo.PreferredLocalAtomicAlignment, out _)[0];

    [StructLayout(LayoutKind.Sequential)]
    public readonly unsafe struct Context : IRefCountedHandle
    {

        public static readonly Context Zero = new Context(IntPtr.Zero);
        public readonly IntPtr Handle;
        internal Context(IntPtr handle)
            => Handle = handle;

        public readonly uint GetReferenceCount()
           => Utils.GetTInfo<ContextInfo, uint>(Handle, ContextInfo.ReferenceCount, Cl.GetContextInfo);
        public readonly string GetProperties()
            => Utils.GetTInfo<ContextInfo, byte>(Handle, ContextInfo.Properties, Cl.GetContextInfo, out _).ToStrg();
        public readonly Device[] GetDevices()
            => Utils.GetTInfo<ContextInfo, Device>(Handle, ContextInfo.Devices, Cl.GetContextInfo, out _);

        #region IRefCountedHandle Members

        public ErrorCode Retain()
            => Cl.RetainContext(Handle);

        public ErrorCode Release()
            => Cl.ReleaseContext(Handle);

        #endregion

        #region IDisposable Members
        public void Dispose()
            => Release();

        #endregion

        public static implicit operator IntPtr(Context ctx) => ctx.Handle;

    }
}