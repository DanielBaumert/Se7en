using System;
using System.Collections.Generic;

namespace Se7en.OpenCvSharp {

    public class VectorOfVec4i : DisposableCvObject, IStdVector<Vec4i>, IDisposable {

        public VectorOfVec4i() {
            ptr = NativeMethods.vector_Vec4i_new1();
        }

        /// <param name="size"></param>
        public VectorOfVec4i(int size) {
            if (size < 0) {
                throw new ArgumentOutOfRangeException("size");
            }
            ptr = NativeMethods.vector_Vec4i_new2(new IntPtr(size));
        }

        /// <param name="ptr"></param>
        public VectorOfVec4i(IntPtr ptr) {
            this.ptr = ptr;
        }

        /// <param name="data"></param>
        public VectorOfVec4i(IEnumerable<Vec4i> data) {
            if (data == null)
                throw new ArgumentNullException("data");
            Vec4i[] array = EnumerableEx.ToArray<Vec4i>(data);
            ptr = NativeMethods.vector_Vec4i_new3(array, new IntPtr(array.Length));
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged() {
            NativeMethods.vector_Vec4i_delete(ptr);
            base.DisposeUnmanaged();
        }

        /// <summary>
        /// vector.size()
        /// </summary>
        public int Size {
            get {
                int result = NativeMethods.vector_Vec4i_getSize(ptr).ToInt32();
                GC.KeepAlive(this);
                return result;
            }
        }

        /// <summary>
        /// &amp;vector[0]
        /// </summary>
        public IntPtr ElemPtr {
            get {
                IntPtr result = NativeMethods.vector_Vec4i_getPointer(ptr);
                GC.KeepAlive(this);
                return result;
            }
        }

        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <returns></returns>
        public Vec4i[] ToArray() => ToArray<Vec4i>();

        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <typeparam name="T">structure that has four int members (ex. CvLineSegmentPoint, CvRect)</typeparam>
        /// <returns></returns>
        public T[] ToArray<T>() where T : struct {
            int typeSize = MarshalHelper.SizeOf<T>();
            if (typeSize != 16) {
                throw new OpenCvSharpException();
            }
            int arySize = Size;
            if (arySize == 0) {
                return new T[0];
            }
            T[] dst = new T[arySize];
            using (ArrayAddress1<T> dstPtr = new ArrayAddress1<T>(dst)) {
                MemoryHelper.CopyMemory(dstPtr, ElemPtr, typeSize * dst.Length);
            }
            GC.KeepAlive(this);
            return dst;
        }
    }
}