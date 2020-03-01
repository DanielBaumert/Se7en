using Se7en.OpenCl.Api.Enum;
using System;
using System.Runtime.InteropServices;

namespace Se7en.OpenCl
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ContextProperty
    {
        private static readonly ContextProperty _zero = new ContextProperty(0);

        private readonly uint _propertyName;
        private readonly IntPtr _propertyValue;

        public ContextProperty(ContextProperties property, IntPtr value)
        {
            _propertyName = (uint)property;
            _propertyValue = value;
        }

        public ContextProperty(ContextProperties property)
        {
            _propertyName = (uint)property;
            _propertyValue = IntPtr.Zero;
        }

        public static ContextProperty Zero {
            get {
                return _zero;
            }
        }
    }
}