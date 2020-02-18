using System;
using System.Runtime.InteropServices;

namespace Se7en.Utils
{
    internal readonly struct PinnedObject : IDisposable
    {
        internal readonly GCHandle Handle;

        internal PinnedObject(object obj)
           => Handle = GCHandle.Alloc(obj, GCHandleType.Pinned);

        public void Dispose()
            => Handle.Free();

        public static implicit operator IntPtr(PinnedObject pinned)
           => pinned.Handle.AddrOfPinnedObject();
    }
}
