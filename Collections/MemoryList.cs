using Se7en.WinApi;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Se7en.Collections {

    [Serializable]
    public unsafe struct MemoryList<T> where T : unmanaged {
        private const int _defaultCapacity = 4;
        //#region Events
        //public event Action<PerformanceList<T>, T, int> Added;
        //public event Action<PerformanceList<T>, T, int> Removed;
        //public event Action<PerformanceList<T>> Changed;
        //#endregion

        public static readonly T* EmptyArray;

        private readonly void* _ListPointer;
        private int _Count;
        private int _Capacity;
        private int _ItemSize;
        private IntPtr _MemoryPointer;

        public void* ListPointer { get => _ListPointer; }
        public int Count { get => _Count; }
        public T* MemoryPointer { get => (T*)_MemoryPointer; }

        //Properties
        public T this[int index] {
            get {
                if ((uint)index >= (uint)_Count)
                    throw new ArgumentOutOfRangeException();
                return *((T*)_MemoryPointer + index);
            }
            set {
                if ((uint)index >= (uint)_Count)
                    throw new ArgumentOutOfRangeException();
                *((T*)_MemoryPointer + index) = value;
            }
        }

        //Constructor

        //private PerformanceList() {
        //    Count = 0;
        //    Capcity = 1024;
        //    Items = new T[Capcity];
        //    IsReadOnly = false;
        //}
        public MemoryList(int count = 0) : this() {
            _ItemSize = sizeof(T);
            _Count = count;
            _Capacity = count > _defaultCapacity ? _Count : _defaultCapacity;
            _MemoryPointer = Kernel32.GlobalAlloc(GlobalAllocFlag.GMEM_ZEROINIT, _Capacity * _ItemSize);
        }

        public MemoryList(T[] items) : this() {
            _ItemSize = sizeof(T);
            _Count = items.Length;
            _Capacity = items.Length;
            fixed (T* itemsPtr = items) {
                _MemoryPointer = Kernel32.GlobalAlloc(GlobalAllocFlag.GMEM_ZEROINIT, _Capacity * _ItemSize);
                Kernel32.CopyMemory(_MemoryPointer, (IntPtr)itemsPtr, (uint)(_Capacity * sizeof(T)));
            }
        }

        public MemoryList(IEnumerable<T> source) : this() {
            _ItemSize = sizeof(T);
            if (source == null)
                throw new ArgumentNullException();

            if (source is ICollection<T> c) {
                _Capacity = _Count = c.Count;

                if (_Count == 0) {
                    _MemoryPointer = Kernel32.GlobalAlloc(GlobalAllocFlag.GMEM_ZEROINIT, _Capacity * _ItemSize);
                } else {
                    _MemoryPointer = Kernel32.GlobalAlloc(GlobalAllocFlag.GMEM_ZEROINIT, _Capacity * _ItemSize);
                    T firstElement = (c as IList<T>)[0];
                    Kernel32.CopyMemory(_MemoryPointer, (IntPtr)(&firstElement), (uint)(_ItemSize * _Count));
                }
            } else {
                _Capacity = _Count = 0;
                _MemoryPointer = Kernel32.GlobalAlloc(GlobalAllocFlag.GMEM_ZEROINIT, _Capacity * _ItemSize);
                ;

                using (IEnumerator<T> en = source.GetEnumerator()) {
                    while (en.MoveNext()) {
                        Add(en.Current);
                    }
                }
            }
        }

        //Add
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(T item) {
            if (_Count == _Capacity) {
                T* newItemsPtr = (T*)Kernel32.GlobalAlloc(GlobalAllocFlag.GMEM_ZEROINIT, (_Capacity *= 2) * sizeof(T));

                Kernel32.CopyMemory((IntPtr)newItemsPtr, _MemoryPointer, (uint)(_Count * _ItemSize));
                Kernel32.GlobalFree(_MemoryPointer);
                _MemoryPointer = (IntPtr)newItemsPtr;
            }

            *((T*)_MemoryPointer + _Count++) = item;
        }

        public void AddRange(params T[] source) => AddRange(_Count, source);

        public void AddRange(int index, T[] source) {
            if (source == null)
                throw new ArgumentNullException();

            if ((uint)index > (uint)_Count)
                throw new ArgumentOutOfRangeException();

            fixed (T* sourcePtr = source) {
                for (int iElements = 0, nElements = source.Length; iElements < nElements; iElements++) {
                    Insert(index, *(sourcePtr + iElements));
                    index += 1;
                }
            }

            /*if ((uint)index > (uint)Count) throw new ArgumentOutOfRangeException();
            if (Count == Items.Length) {
                T[] newItems = new T[Count + 1];
                Array.Copy(Items, 0, newItems, 0, Count);
                Items = newItems;
            }
            if (index < Count) {
                Array.Copy(Items, index, Items, index + 1, Count - index);
            }
            Count += 1;
            Items[index] = item;*/
            //Changed?.Invoke(this);
        }

        public void AddRange(MemoryList<T> source) {
            int filledCount = _Count + source.Count;

            if (filledCount >= _Capacity) {
                IntPtr newItemsPtr = Kernel32.GlobalAlloc(GlobalAllocFlag.GMEM_ZEROINIT, (_Capacity *= 2) * sizeof(T));

                Kernel32.CopyMemory(newItemsPtr, _MemoryPointer, (uint)(_Count * _ItemSize));
                Kernel32.GlobalFree(_MemoryPointer);
                _MemoryPointer = newItemsPtr;
            }

            Kernel32.CopyMemory((IntPtr)((T*)_MemoryPointer + _Count), source._MemoryPointer, (uint)(_ItemSize * source._Count));
        }

        //Contains
        public bool Contains(T item) => Contains(item, 0, _Count);

        public bool Contains(T item, int start) => Contains(item, start, _Count);

        public bool Contains(T item, int start, int end) {
            if (Equals(item, null)) {
                for (int i = start; i < end; i += 1) {
                    if (Equals(*((T*)_MemoryPointer + i), null)) {
                        return true;
                    }
                }
            } else {
                EqualityComparer<T> c = EqualityComparer<T>.Default;
                for (int i = 0; i < _Count; i++) {
                    if (c.Equals(*((T*)_MemoryPointer + i), item)) {
                        return true;
                    }
                }
            }
            return false;
        }

        //Remove
        public void RemoveAt(int index) => Remove(index);

        public bool Remove(T item) {
            int itemIndex = IndexOf(item);
            if (itemIndex < 0)
                return false;
            Remove(itemIndex);
            return true;
        }

        public void Remove(int index) {
            if ((uint)index >= (uint)_Count)
                throw new ArgumentOutOfRangeException();
            _Count -= 1;
            T item = *((T*)_MemoryPointer + index);
            if (index < _Count) {
                Kernel32.CopyMemory((IntPtr)((T*)_MemoryPointer + index), (IntPtr)((T*)_MemoryPointer + index + 1), (uint)((_Count - index) * _ItemSize));
                _Count--;
            }
            //Removed?.Invoke(this, item, index);
            //Changed?.Invoke(this);
        }

        //CopyTo
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(T[] targetArray) => CopyTo(targetArray, 0, 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(T[] targetArray, int arrayIndex) => CopyTo(targetArray, arrayIndex, 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(T[] targetArray, int arrayIndex, int count) {
            fixed (T* target = targetArray) {
                CopyTo(target, arrayIndex, count);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(T* target, int dstIndex, int srcCount) => Kernel32.MoveMemory((IntPtr)target, _MemoryPointer, (uint)(srcCount * _ItemSize));

        //IndexOf
        public int IndexOf(T item) => IndexOf(item, 0, _Count);

        public int IndexOf(T item, int start) => IndexOf(item, start, _Count);

        public unsafe int IndexOf(T item, int start, int end) {
            int range = _Count;
            if (!Contains(item, start, end))
                return -1;

            if (start != 0 && end != range)
                range = start > end
                     ? start - end
                     : end - start;
            EqualityComparer<T> c = EqualityComparer<T>.Default;

            for (int i = 0; i < _Count; i++) {
                if (c.Equals(*((T*)_MemoryPointer + i), item))
                    return i;
            }
            return -1;
        }

        public void Insert(int index, T item) {
            if ((uint)index > (uint)_Count)
                throw new ArgumentOutOfRangeException();

            if (_Count == _Capacity) {
                T* newItemsPtr = (T*)Kernel32.GlobalAlloc(GlobalAllocFlag.GMEM_ZEROINIT, (_Capacity *= 2) * sizeof(T));

                Kernel32.CopyMemory((IntPtr)newItemsPtr, _MemoryPointer, (uint)(_Count * _ItemSize));
                Kernel32.GlobalFree(_MemoryPointer);
                _MemoryPointer = (IntPtr)newItemsPtr;
            }

            if (index < _Count) {
                Kernel32.CopyMemory((IntPtr)((T*)_MemoryPointer + index + 1), (IntPtr)((T*)_MemoryPointer + index), (uint)((_Count - index) * _ItemSize));
            }

            _Count += 1;
            *((T*)_MemoryPointer + index) = item;
        }

        public void Insert(int index, T[] source) {
            if ((uint)index > (uint)_Count)
                throw new ArgumentOutOfRangeException();

            if (_Count == _Capacity) {
                T* newItemsPtr = (T*)Kernel32.GlobalAlloc(GlobalAllocFlag.GMEM_ZEROINIT, (_Capacity *= 2) * sizeof(T));

                Kernel32.CopyMemory((IntPtr)newItemsPtr, _MemoryPointer, (uint)(_Count * _ItemSize));
                Kernel32.GlobalFree(_MemoryPointer);
                _MemoryPointer = (IntPtr)newItemsPtr;
            }

            if (index < _Count) {
                IntPtr dst = (IntPtr)((T*)_MemoryPointer + index + source.Length);
                IntPtr src = (IntPtr)((T*)_MemoryPointer + index);
                uint byteCount = (uint)((_Count - index - source.Length) * _ItemSize);
                Kernel32.CopyMemory(dst, src, byteCount);
            }

            _Count += 1;
            fixed (T* sourcePtr = source) {
                Kernel32.MoveMemory((IntPtr)((T*)_MemoryPointer + index), (IntPtr)sourcePtr, (uint)(source.Length * _ItemSize));
            }
        }

        public void Clear() {
            if ((T*)_MemoryPointer != EmptyArray)
                _MemoryPointer = (IntPtr)EmptyArray;

            _Count = 0;
            //Changed?.Invoke(this);
        }

        public void Reverse() { //bubble
            for (int iElement = 0, nElement = _Count / 2; iElement < nElement; iElement += 1) {
                T t1 = *((T*)_MemoryPointer + iElement);
                *((T*)_MemoryPointer + iElement) = *((T*)_MemoryPointer + _Count - 1 - iElement);
                *((T*)_MemoryPointer + _Count - 1 - iElement) = t1;
            }
            //Changed?.Invoke(this);
        }

        public IEnumerable<T> Distinct() {
            Set<T> set = new Set<T>(null);
            for (int i = 0; i < _Count; i++) {
                T element = this[i];
                if (set.Add(element))
                    yield return element;
            }
        }

        public static implicit operator MemoryList<T>(T[] source) => new MemoryList<T>(source);

        public unsafe static explicit operator T*(MemoryList<T> source) => (T*)source._MemoryPointer;

        public unsafe static explicit operator MemoryList<T>(T* source) => (MemoryList<T>)source;
    }
}