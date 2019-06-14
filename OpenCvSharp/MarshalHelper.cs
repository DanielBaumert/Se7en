using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Se7en.OpenCvSharp
{
    public static class MarshalHelper
    {
        public static int SizeOf<T>() 
            => typeof(T).GetTypeInfo().IsValueType
                ? Marshal.SizeOf<T>()
                : IntPtr.Size;

        public static T PtrToStructure<T>(IntPtr p) where T : struct 
            => Marshal.PtrToStructure<T>(p);
    }
}