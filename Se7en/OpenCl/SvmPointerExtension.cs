using System;

namespace Se7en.OpenCl
{
    public static class SvmPointerExtension
    {
        /// <summary>
        /// Convert the unmanaged memory into a managed array
        /// </summary>
        /// <param name="svmMem">Pointer to the umanaged shared virtual memory</param>
        /// <returns>Return a managed array that point to the shared virtual memory</returns>
        public unsafe static byte[] ToArray(this SvmPointer svmMem)
        {
            byte[] buffer = null;
            var a = __makeref(svmMem);
            var b = __makeref(buffer);
            //**(IntPtr**)(&b) = new IntPtr(ptr);
            //**(IntPtr**)(&b) = (IntPtr)((byte*)(**(IntPtr**)(&a)) + 10);
            **(IntPtr**)(&b) = (**(IntPtr**)(&a));
            //nullRect = __refvalue(b, byte[]);
            return buffer;
        }
        /// <summary>
        /// Convert the unmanaged memory into a managed array
        /// </summary>
        /// <typeparam name="T">Unmanaged return type</typeparam>
        /// <param name="svmMem">Pointer to the umanaged shared virtual memory</param>
        /// <returns>Return a managed array that point to the shared virtual memory</returns>
        public unsafe static T[] ToArray<T>(this SvmPointer<T> svmMem) where T : unmanaged
        {
            T[] buffer = null;
            var a = __makeref(svmMem);
            var b = __makeref(buffer);
            //**(IntPtr**)(&b) = new IntPtr(ptr);
            //**(IntPtr**)(&b) = (IntPtr)((byte*)(**(IntPtr**)(&a)) + 10);
            **(IntPtr**)(&b) = (**(IntPtr**)(&a));
            //nullRect = __refvalue(b, byte[]);
            return buffer;
        }
    }
}
