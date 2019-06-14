using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Se7en.OpenCvSharp
{

    /// <typeparam name="T"></typeparam>
        public class ArrayAddress1<T> : DisposableObject
    {

        /// <param name="array"></param>
        public ArrayAddress1(T[] array)
        {
            this.array = array ?? throw new ArgumentNullException();
            gch = GCHandle.Alloc(array, GCHandleType.Pinned);
        }


        /// <param name="enumerable"></param>
        public ArrayAddress1(IEnumerable<T> enumerable) : this(EnumerableEx.ToArray<T>(enumerable))
            => original = enumerable;

        public ArrayAddress1(T[,] array)
        {
            this.array = array ?? throw new ArgumentNullException();
            gch = GCHandle.Alloc(array, GCHandleType.Pinned);
        }

        /// <summary>
        /// Releases managed resources
        /// </summary>
        protected override void DisposeManaged()
        {
            original = null;
            base.DisposeManaged();
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            if (gch.IsAllocated)
            {
                gch.Free();
            }
            base.DisposeUnmanaged();
        }


        public IntPtr Pointer => gch.AddrOfPinnedObject();


        /// <param name="self"></param>
        /// <returns></returns>
        public static implicit operator IntPtr(ArrayAddress1<T> self) => self.Pointer;


        public int Length => array.Length;

        protected Array array;

        protected GCHandle gch;

        protected object original;
    }
}