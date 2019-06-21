using Se7en.WinApi;
using System;

namespace Se7en.Collections {
    public unsafe struct MemoryList2<T> where T : unmanaged {

        public int ItemSize { get; private set; }
        public T* Ptr { get; private set; }
        public int Count { get; private set; }
        public int ByteCount { get; private set; }

        public T this[int i] {
            get => *(Ptr + i);
            set => *(Ptr + i) = value;
        }

        public MemoryList2(int count = 0) {
            ItemSize = sizeof(T);
            Count = count;
            ByteCount = ItemSize * Count;

            Ptr = (T*) Kernel32.GlobalAlloc(GlobalAllocFlag.GPTR, ByteCount);
        }

        public void Add(T item) {
            Count++;
            ByteCount = ItemSize * Count;

            T* newPtr = (T*)Kernel32.GlobalAlloc(GlobalAllocFlag.GPTR, ByteCount);

            Buffer.MemoryCopy(Ptr, newPtr, ByteCount, ByteCount - ItemSize);
            *(newPtr + (Count - 1)) = item;

            Kernel32.GlobalFree((IntPtr) Ptr);
            Ptr = newPtr;
        }
        public void AddAt(T item, int index) {
            throw new NotSupportedException();

            Count++;
            ByteCount = ItemSize * Count;

            T* newPtr = (T*)Kernel32.GlobalAlloc(GlobalAllocFlag.GPTR, ByteCount);

            Buffer.MemoryCopy(Ptr, newPtr, ByteCount, ByteCount - ItemSize);
            *(newPtr + (Count - 1)) = item;

            Kernel32.GlobalFree((IntPtr)Ptr);
            Ptr = newPtr;
        }

        public void AddRange(T[] array) {
            throw new NotSupportedException();
            Count += array.Length;
            int arrayByteCount = ItemSize * array.Length;
            ByteCount = ItemSize * Count;
            T* newPtr = (T*) Kernel32.GlobalAlloc(GlobalAllocFlag.GPTR, ByteCount);

            Buffer.MemoryCopy(Ptr, newPtr, ByteCount, ByteCount - arrayByteCount);
            fixed (T* arrayPtr = array) {
                Buffer.MemoryCopy(arrayPtr, newPtr + ByteCount - arrayByteCount, ByteCount, arrayByteCount);
            }

            Kernel32.GlobalFree((IntPtr)Ptr);
            Ptr = newPtr;
        }

    }
}
