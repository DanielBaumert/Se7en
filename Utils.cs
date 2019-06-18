using System;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;

namespace Se7en {

    public unsafe delegate void UnsafeAction<T1>(T1* arg1) where T1 : unmanaged;

    public unsafe delegate void UnsafeAction<T1, T2>(T1* arg1, T2 arg2) where T1 : unmanaged;

    public unsafe delegate void UnsafeAction<T1, T2, T3>(T1* arg1, T2 arg2, T3 arg3) where T1 : unmanaged;

    public unsafe delegate void UnsafeAction<T1, T2, T3, T4>(T1* arg1, T2 arg2, T3 arg3, T4 arg) where T1 : unmanaged;

    public unsafe delegate TOut UnsafeFunc<T1, TOut>(T1* arg1) where T1 : unmanaged;

    public unsafe delegate TOut UnsafeFunc<T1, T2, TOut>(T1* arg1, T2 arg2) where T1 : unmanaged;

    public unsafe delegate TOut UnsafeFunc<T1, T2, T3, TOut>(T1* arg1, T2 arg2, T3 arg3) where T1 : unmanaged;

    public unsafe delegate TOut UnsafeFunc<T1, T2, T3, T4, TOut>(T1* arg1, T2 arg2, T3 arg3, T4 arg) where T1 : unmanaged;

    public unsafe delegate TOut UnsafeFunc2<TIn1, Tin2, TOut>(TIn1* sourceA, Tin2* sourceB) where TIn1 : unmanaged where Tin2 : unmanaged;

    public unsafe delegate void UnsafeActionPrtArray<TTarget, TIn1, Tin2>(TTarget*[] target, TIn1* sourceA, Tin2 sourceB) where TTarget : unmanaged where TIn1 : unmanaged;

    public static class Utils {
        //TODO salat
        public static Random Random = new Random();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe int ToInt(this bool value) => *(byte*)&value;

        //TODO Adding multiplay support
        public static int PixelWidth(this PixelFormat pixelFormat)
            => pixelFormat switch
            {
                PixelFormat.Format24bppRgb => 24,
                PixelFormat.Format32bppArgb => 32,
                PixelFormat.Format32bppPArgb => 32,
                PixelFormat.Format32bppRgb => 32,
                _ => throw new NotSupportedException(pixelFormat.ToString())
            };
    }
}