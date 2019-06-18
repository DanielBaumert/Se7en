using System;
using System.Collections.Generic;

namespace Se7en.OpenCvSharp {

    public class VectorOfVec2f : DisposableCvObject, IStdVector<Vec2f>, IDisposable {

        public VectorOfVec2f()
            => ptr = NativeMethods.vector_Vec2f_new1();

        public VectorOfVec2f(int size) {
            if (size < 0) {
                throw new ArgumentOutOfRangeException("size");
            }
            ptr = NativeMethods.vector_Vec2f_new2(new IntPtr(size));
        }

        public VectorOfVec2f(IEnumerable<Vec2f> data) {
            if (data == null) {
                throw new ArgumentNullException("data");
            }
            Vec2f[] array = EnumerableEx.ToArray(data);
            ptr = NativeMethods.vector_Vec2f_new3(array, new IntPtr(array.Length));
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged() {
            NativeMethods.vector_Vec2f_delete(this.ptr);
            base.DisposeUnmanaged();
        }

        /// <summary>
        /// vector.size()
        /// </summary>
        public int Size {
            get {
                int result = NativeMethods.vector_Vec2f_getSize(ptr).ToInt32();
                GC.KeepAlive(this);
                return result;
            }
        }

        /// <summary>
        /// &amp;vector[0]
        /// </summary>
        public IntPtr ElemPtr {
            get {
                IntPtr result = NativeMethods.vector_Vec2f_getPointer(ptr);
                GC.KeepAlive(this);
                return result;
            }
        }

        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        public Vec2f[] ToArray() => ToArray<Vec2f>();

        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <typeparam name="T">structure that has two float members (ex. CvLineSegmentPolar, CvPoint2D32f, PointF)</typeparam>
        public T[] ToArray<T>() where T : struct {
            int typeSize = MarshalHelper.SizeOf<T>();
            if (typeSize != 8) {
                throw new OpenCvSharpException();
            }
            int arySize = Size;
            if (arySize == 0) {
                return new T[0];
            }
            T[] dst = new T[arySize];
            using (ArrayAddress1<T> dstPtr = new ArrayAddress1<T>(dst)) {
                MemoryHelper.CopyMemory(dstPtr, this.ElemPtr, typeSize * dst.Length);
            }
            GC.KeepAlive(this);
            return dst;
        }
    }
}