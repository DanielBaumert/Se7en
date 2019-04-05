using Se7en.WinApi;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Se7en.Collections.Linq
{
    public static class Utils
    {

        public unsafe static void ForEach<T>(this MemoryList<T> source, UnsafeAction<T> action, int step = 1) where T : unmanaged
        {
            for (int i = 0; i < source.Count; i += step)
            {
                action(((T*)source) + i);
            }
        }

        public unsafe static void ForEach<T>(this MemoryList<T> source, UnsafeAction<T, int> action, int step = 1) where T : unmanaged
        {
            for (int i = 0; i < source.Count; i += step)
            {
                action(((T*)source) + i, i);
            }
        }

        public unsafe static void ParallelForEach<T>(this MemoryList<T> source, UnsafeAction<T> action, int step = 1) where T : unmanaged
            => Parallel.ForEach(SteppedIterator.Create(0, source.Count, step), i => action(((T*)source) + i));

        public unsafe static void ParallelForEach<T>(this MemoryList<T> source, UnsafeAction<T, int> action, int step = 1) where T : unmanaged
            => Parallel.ForEach(SteppedIterator.Create(0, source.Count, step), i => action(((T*)source) + i, i));

        public static IEnumerable<TOut> SelectWhere<T1, TOut>(this MemoryList<T1> source, Func<T1, bool> compare, Func<T1, TOut> selector) where T1 : unmanaged
        {
            for (int i = 0; i < source.Count; i++)
            {
                T1 element = source[i];
                if (compare(element)) yield return selector(element);
            }
        }
        public static IEnumerable<TOut> SelectWhere<T1, TOut>(this MemoryList<T1> source, Func<T1, bool> compare, Func<T1, int, TOut> selector) where T1 : unmanaged
        {
            for (int i = 0; i < source.Count; i++)
            {
                T1 element = source[i];
                if (compare(element)) yield return selector(element, i);
            }
        }

        public static MemoryList<T> ToMemoryList<T>(this IEnumerable<T> source) where T : unmanaged => new MemoryList<T>(source);

        public unsafe static T[] ToArray<T>(this MemoryList<T> source) where T : unmanaged
        {
            int count = source.Count;
            T[] array = new T[count];
            fixed(T* arrayPtr = array)  Kernel32.CopyMemory((IntPtr)arrayPtr, (IntPtr) source.MemoryPointer, (uint)(sizeof(T) * count));
            return array;
        }
    }
}