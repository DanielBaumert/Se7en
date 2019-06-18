using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Se7en.Collections.Linq {

    public static class Linq {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void ParallelForEach<T>(this T[] source, UnsafeAction<T> action, int step = 1) where T : unmanaged {
            T* sourcePtr = source.GetSourcePtr();
            Parallel.ForEach(SteppedIterator.Create(0, source.Length, step), i => action(sourcePtr + i));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void ParallelForEach<T>(this T[] source, UnsafeAction<T, int> action, int step = 1) where T : unmanaged {
            T* sourcePtr = source.GetSourcePtr();
            Parallel.ForEach(SteppedIterator.Create(0, source.Length, step), i => action(sourcePtr + i, i));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void ForEach<T>(this T[] source, UnsafeAction<T> action, int step = 1) where T : unmanaged {
            T* sourcePtr = source.GetSourcePtr();
            for (int i = 0; i < source.Length; i += step) {
                action(sourcePtr + i);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void ForEach<T>(this T[] source, UnsafeAction<T, int> action, int step = 1) where T : unmanaged {
            T* sourcePtr = source.GetSourcePtr();
            for (int i = 0; i < source.Length; i += step) {
                action(sourcePtr + i, i);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<TOut> SelectWhere<T, TOut>(this T[] source, Func<T, bool> compare, Func<T, int, TOut> selector) where T : unmanaged {
            for (int i = 0; i < source.Length; i++) {
                T element = source[i];
                if (compare(element))
                    yield return selector(element, i);
            }
        }

        #region Conatins

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static bool Contains<T1>(this T1[] source, UnsafeFunc<T1, bool> contains) where T1 : unmanaged {
            fixed (T1* sourcePtr = source) {
                for (int iElement = 0, nElement = source.Length; iElement < nElement; iElement++) {
                    if (contains(sourcePtr + iElement)) {
                        return true;
                    }
                }
            }
            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static bool Contains<T>(this T[] source, T element) where T : unmanaged {
            fixed (T* sourcePtr = source) {
                for (int iElement = 0, nElements = source.Length; iElement < nElements; iElement++) {
                    if ((object)*(sourcePtr + iElement) == (object)element) {
                        return true;
                    }
                }
            }
            return false;
        }

        #endregion Conatins

        /// <summary>
        /// Return the element from the middle
        /// </summary>
        /// <param name="source"></param>
        /// <returns>Element at center</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T ElementAtCenter<T>(this T[] source) {
            if (source.Length > 0) {
                return source[source.Length / 2];
            }
            return default;
        }

        #region SelectWhere

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<TOut> SelectWhere<TIn, TOut>(this IEnumerable<TIn> source, Func<TIn, bool> compare, Func<TIn, TOut> selector) {
            foreach (TIn element in source) {
                if (compare(element)) {
                    yield return selector(element);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<TOut> SelectWhere<TIn, TOut>(this IEnumerable<TIn> source, Func<TIn, bool> compare, Func<TIn, int, TOut> selector) {
            int i = -1;
            foreach (TIn element in source) {
                checked { i++; }
                if (compare(element)) {
                    yield return selector(element, i);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<TOut> SelectWhere<TIn, TOut>(this IEnumerable<TIn> source, Func<TIn, int, bool> compare, Func<TIn, int, TOut> selector) {
            int i = -1;
            foreach (TIn element in source) {
                i++;
                if (compare(element, i)) {
                    yield return selector(element, i);
                }
            }
        }

        #endregion SelectWhere

        #region ForISelect

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static TOut[] ForISelect<TSource1, TSource2, TOut>(TSource1[] sourceA, TSource2[] sourceB, UnsafeFunc2<TSource1, TSource2, TOut> select) where TOut : unmanaged where TSource1 : unmanaged where TSource2 : unmanaged {
            if (sourceA.Length != sourceB.Length) {
                return default;
            }
            int count = sourceA.Length;
            TOut[] output = new TOut[count];

            fixed (TOut* outSourcePtr = output) {
                fixed (TSource1* sourceAPtr = sourceA) {
                    fixed (TSource2* sourceBPtr = sourceB) {
                        for (int i = 0; i < count; i += 1) {
                            *(outSourcePtr + i) = select(sourceAPtr + i, sourceBPtr + i);
                        }
                    }
                }
            }

            return output;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static TOut[] ForISelect<TSource1, TSource2, TOut>(int end, TSource1[] sourceA, TSource2[] sourceB, UnsafeFunc2<TSource1, TSource2, TOut> select) where TOut : unmanaged where TSource1 : unmanaged where TSource2 : unmanaged
            => ForISelect(0, end, sourceA, sourceB, select);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static TOut[] ForISelect<TSource1, TSource2, TOut>(int start, int end, TSource1[] sourceA, TSource2[] sourceB, UnsafeFunc2<TSource1, TSource2, TOut> select) where TOut : unmanaged where TSource1 : unmanaged where TSource2 : unmanaged {
            TOut[] output = new TOut[System.Math.Abs(end - start)];
            fixed (TOut* outSourcePtr = output) {
                fixed (TSource1* sourceAPtr = sourceA) {
                    fixed (TSource2* sourceBPtr = sourceB) {
                        for (int i = start; i < end; i += 1) {
                            *(outSourcePtr + i) = select(sourceAPtr + i, sourceBPtr + i);
                        }
                    }
                }
            }
            return output;
        }

        #endregion ForISelect

        #region ForIConvert

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<TOut> ForIConvert<T1, T2, TOut>(int start, int end, T1[] sourceA, T2[] sourceB, Func<IntPtr, IntPtr, TOut> func) where T1 : unmanaged where T2 : unmanaged {
            for (int i = start; i < end; i += 1) {
                InnerLoopCall(i, out TOut p);
                yield return p;
            }

            void InnerLoopCall(int i, out TOut p) {
                unsafe {
                    fixed (T1* t1Ptr = sourceA) {
                        fixed (T2* t2Ptr = sourceB) {
                            p = func((IntPtr)(t1Ptr + i), (IntPtr)(t2Ptr + i));
                        }
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<TOut> ForrIConvert<T1, T2, TOut>(int start, int end, T1[] sourceA, T2[] sourceB, Func<IntPtr, IntPtr, TOut> func) where T1 : unmanaged where T2 : unmanaged {
            TOut InnerLoop(int i) {
                TOut outVal;
                unsafe {
                    fixed (T1* t1Ptr = sourceA) {
                        fixed (T2* t2Ptr = sourceB) {
                            outVal = func((IntPtr)(t1Ptr + i), (IntPtr)(t2Ptr + i));
                        }
                    }
                }
                return outVal;
            }

            for (int i = start - 1, n = end - 1; i > n; i -= 1) {
                yield return InnerLoop(i);
            }
        }

        #endregion ForIConvert

        /// <summary>
        /// Calculate the query from a window inside a array from the center started |A|A|B|[start]|B|A|A ..window (5)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="sum"></param>
        /// <param name="convert"></param>
        /// <param name="window"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T QueryAtCenter<T>(this T[] source, System.Func<T, int> sum, Func<int, T> convert, int window) {
            int center = source.Length / 2;
            int halfWindow = window / 2;
            int startOffset = center - halfWindow;

            int query = source.Skip(startOffset).Take(window).Sum(sum) / window;
            return convert(query);
        }
    } //class-Linq-end
}