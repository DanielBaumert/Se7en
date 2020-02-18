using System;
using System.Runtime.CompilerServices;

namespace Se7en.Utils
{

    ///=>[^<]+([^>]+)[^<]+([^>]+)>\(([^,]+), out _\)\[0\];
    ///Utils.GetTInfo<$1, $2>(_handle, $3, _getInfoHandler, out _).First();
    ///=>[^<]+<([^>]+)[^<]+<([^>]+)>\(([^,]+), out _\)\.ToStrg\(\);
    ///=> Utils.GetTInfo<$1, $2>(_handle, $3, _getInfoHandler, out _).ToStrg();
    ///((IHandleObjInfo<DeviceInfo>)this).GetTInfo<uint>(DeviceInfo.PreferredLocalAtomicAlignment, out _)[0];
    public static class Utils
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static string ToStrg(this byte[] source)
        {
            fixed(byte* sourcePtr = source)
            {
                return new string((sbyte*) sourcePtr).TrimEnd('\0');
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe T First<T>(this T[] source) where T : unmanaged
        {
            fixed (T* sourcePtr = source)
                return *sourcePtr;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe T First<T>(this T[] source, Func<T, bool> comp) where T : unmanaged
        {
            fixed (T* sourcePtr = source)
            {
                for (int i = 0, n = source.Length; i < n; i++)
                {
                    T* obj = sourcePtr + i;
                    if (comp(*obj))
                        return *sourcePtr;
                }
                return default;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe IndexElement<T> FirstWithIndex<T>(this T[] source, Func<T, bool> comp)
            where T : unmanaged
        {
            fixed (T* sourcePtr = source)
            {
                for (int i = 0, n = source.Length; i < n; i++)
                {
                    T* obj = sourcePtr + i;
                    if (comp(*obj))
                        return new IndexElement<T>(i, *obj);
                }
                return default;
            }
        }

       
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static TOut[] SelectUnsafe<TIn, TOut>(this TIn[] source, Func<TIn, TOut> selectAction)
            where TIn : unmanaged
            where TOut : unmanaged
        {
            int length = source.Length;
            TOut[] target = new TOut[length];
            fixed (TOut* targetPtr = target)
            {
                fixed (TIn* sourcePtr = source)
                {
                    for (int iElement = 0; iElement < length; iElement++)
                    {
                        *(targetPtr + iElement) = selectAction(*(sourcePtr + iElement));
                    }
                }
            }
            return target;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe int ToInt(this bool val) => *(int*)&val;
    }
}
