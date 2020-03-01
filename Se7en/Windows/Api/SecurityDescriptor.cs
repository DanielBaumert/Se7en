using System;
using System.Runtime.InteropServices;

namespace Se7en.Windows.Api
{
    /// <summary>
    /// The SECURITY_DESCRIPTOR structure contains the security information associated with an object. Applications use this structure to set and query an object's security status.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SecurityDescriptor
    {
        public byte revision;
        public byte size;
        public short control;
        public IntPtr owner;
        public IntPtr group;
        /// <summary>
        /// See system access control list.
        /// </summary>
        public IntPtr sacl;
        public IntPtr dacl;
    }
}
