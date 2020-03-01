using System;
using System.Runtime.InteropServices;

namespace Se7en.Collection
{
    public unsafe struct MemoryList<T> : IDisposable where T : unmanaged
    {
        public static MemoryList<T> Empty => new MemoryList<T>(4);

        private static int _size = sizeof(T);
        private T* _memPtr;
        private int _count;
        private int _byteCount;
        private int _capacity;

        public T this[int index] {
            get => *(_memPtr + index);
            set => *(_memPtr + index) = value;
        }

        public MemoryList(int capacity)
        {
            if (capacity < 4)
            {
                throw new ArgumentException("capacity must be equals or bigger then 4");
            }
            _capacity = capacity;
            _byteCount = _size * _capacity;

            _memPtr = (T*)Marshal.AllocHGlobal(_byteCount);

            _count = 0;
        }

        public T* GetItemPtr(int index) => _memPtr + index;

        /// <summary>
        /// Add a item to that list
        /// </summary>
        /// <param name="item">item to be adding</param>
        public void Add(T item)
        {
            if (_count == _capacity)
            {
                _capacity = _capacity * 2;
                int byteCount = _byteCount * 2;
                T* memPtr = (T*)Marshal.AllocHGlobal(byteCount);

                Buffer.MemoryCopy(_memPtr, memPtr, byteCount, _byteCount);
                Marshal.FreeHGlobal((IntPtr)_memPtr);

                _byteCount = byteCount;
                _memPtr = memPtr;
            }

            *(_memPtr + _count) = item;
            _count++;
        }

        public void RemoveFirst(Func<T, bool> func)
        {
            for (int i = 0; i < _count;)
            {
                T* itemPtr = _memPtr + i;
                if (func(*itemPtr))
                {
                    int destBytes = (_count - i) * _size;
                    Buffer.MemoryCopy(itemPtr + 1, itemPtr, destBytes, destBytes);
                    _count--;
                    return;
                }
                else
                {
                    i++;
                }
            }
        }
        /// <summary>
        /// Remove a item from the list on a spezial index
        /// </summary>
        /// <param name="index">item to be remove index</param>
        public void RemoveAt(int index)
        {
            T* itemPtr = _memPtr + index;
            int destBytes = (_count - index) * _size;
            Buffer.MemoryCopy(itemPtr + 1, itemPtr, destBytes, destBytes);
            _count--;
        }

        public void RemoveAll(Func<T, bool> func)
        {
            for (int i = 0; i < _count;)
            {
                T* itemPtr = _memPtr + i;
                if (func(*itemPtr))
                {
                    int destBytes = (_count - i) * _size;
                    Buffer.MemoryCopy(itemPtr + 1, itemPtr, destBytes, destBytes);
                    _count--;
                }
                else
                {
                    i++;
                }
            }
        }

        public void Dispose()
            => Marshal.FreeHGlobal((IntPtr)_memPtr);

    }
}
