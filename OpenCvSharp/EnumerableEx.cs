using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Se7en.OpenCvSharp
{
    /// <summary>
    /// IEnumerable&lt;T&gt; extension methods for .NET Framework 2.0 
    /// </summary>
    internal static class EnumerableEx
    {
        /// <summary>
        /// Enumerable.Select
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static IEnumerable<TResult> Select<TSource, TResult>(IEnumerable<TSource> enumerable, Func<TSource, TResult> selector)
            => enumerable.Select(selector);

        /// <summary>
        /// Enumerable.Select -&gt; ToArray
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static TResult[] SelectToArray<TSource, TResult>(IEnumerable<TSource> enumerable, Func<TSource, TResult> selector)
            => enumerable.Select(selector).ToArray<TResult>();

        /// <summary>
        /// Enumerable.Select -&gt; ToArray
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static TResult[] SelectToArray<TSource, TResult>(IEnumerable enumerable, Func<TSource, TResult> selector)
            => enumerable.Cast<TSource>().Select(selector).ToArray<TResult>();

        /// <summary>
        /// Enumerable.Select -&gt; ToArray
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IntPtr[] SelectPtrs(IEnumerable<UtilMap> enumerable) 
            => SelectToArray(enumerable, delegate (UtilMap obj)
               {
                   if (obj == null)
                   {
                       throw new ArgumentException("enumerable contains null");
                   }
                   obj.ThrowIfDisposed();
                   return obj.Ptr;
               });

        /// <summary>
        /// Enumerable.Select -&gt; ToArray
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IntPtr[] SelectPtrs(IEnumerable<InputArray> enumerable)
            => SelectToArray(enumerable, delegate (InputArray obj)
               {
                   if (obj == null)
                   {
                       throw new ArgumentException("enumerable contains null");
                   }
                   obj.ThrowIfDisposed();
                   return obj.CvPtr;
               });

        /// <summary>
        /// Enumerable.Where
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Where<TSource>(IEnumerable<TSource> enumerable, Func<TSource, bool> predicate) 
            => enumerable.Where(predicate);

        /// <summary>
        /// Enumerable.Where -&gt; ToArray
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static TSource[] WhereToArray<TSource>(IEnumerable<TSource> enumerable, Func<TSource, bool> predicate) 
            => enumerable.Where(predicate).ToArray<TSource>();

        /// <summary>
        /// Enumerable.ToArray
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static TSource[] ToArray<TSource>(IEnumerable<TSource> enumerable)
        {
            if (enumerable == null)
            {
                return null;
            }
            return enumerable.ToArray<TSource>();
        }

        /// <summary>
        /// Enumerable.Any
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static bool Any<TSource>(IEnumerable<TSource> enumerable, Func<TSource, bool> predicate) => enumerable.Any(predicate);

        /// <summary>
        /// Enumerable.Any
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static bool AnyNull<TSource>(IEnumerable<TSource> enumerable) where TSource : class
        {
            if (enumerable == null)
            {
                throw new ArgumentNullException("enumerable");
            }
            return enumerable.Any((TSource e) => e == null);
        }

        /// <summary>
        /// Enumerable.All
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static bool All<TSource>(IEnumerable<TSource> enumerable, Func<TSource, bool> predicate) 
            => enumerable.All(predicate);

        /// <summary>
        /// Enumerable.Count
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static int Count<TSource>(IEnumerable<TSource> enumerable, Func<TSource, bool> predicate) 
            => enumerable.Count(predicate);

        /// <summary>
        /// Enumerable.Count
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static int Count<TSource>(IEnumerable<TSource> enumerable) 
            => enumerable.Count<TSource>();

        
        /// <typeparam name="TSource"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static bool IsEmpty<TSource>(IEnumerable<TSource> enumerable) 
            => !enumerable.Any<TSource>();
    }
}