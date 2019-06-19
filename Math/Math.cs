using System;
using System.Runtime.CompilerServices;

namespace Se7en.Math {

    public static class Math {
        public const float PI = 3.1415926535897932384626433832795F;

        public static int Mod(this int n, int m) 
            => ((int)(n / (float)m) * n);

        public static int ModPow2(this int n, int mPow2) 
            => n & (mPow2 - 1);

        public static uint Mod2(this uint n) 
            => ((n << 31) >> 31);

        public static uint Mod4(this uint n) 
            => ((n << 30) >> 30);

        public static uint Mod8(this uint n) 
            => ((n << 29) >> 29);

        public static uint Mod16(this uint n) 
            => ((n << 28) >> 28);

        #region Abs

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Abs(this int value)
            => (value ^ (value >> 31)) - (value >> 31);

        #endregion

        #region Min

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte Min(this byte val1, byte val2)
            => (val1 <= val2) ? val1 : val2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short Min(this short val1, short val2)
            => (val1 <= val2) ? val1 : val2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Min(this float val1, float val2)
            => (val1 <= val2) ? val1 : val2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Min(this int val1, int val2)
            => (val1 <= val2) ? val1 : val2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Min(this long val1, long val2)
            => (val1 <= val2) ? val1 : val2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Min(this double val1, double val2)
            => (val1 <= val2) ? val1 : val2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Min(this decimal val1, decimal val2)
            => (val1 <= val2) ? val1 : val2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte Min(this sbyte val1, sbyte val2)
            => (val1 <= val2) ? val1 : val2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort Min(this ushort val1, ushort val2)
            => (val1 <= val2) ? val1 : val2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Min(this uint val1, uint val2)
            => (val1 <= val2) ? val1 : val2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Min(this ulong val1, ulong val2)
            => (val1 <= val2) ? val1 : val2;

        #endregion Min

        #region Max

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte Max(this byte val1, byte val2)
            => (val1 >= val2) ? val1 : val2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short Max(this short val1, short val2)
            => (val1 >= val2) ? val1 : val2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Max(this float val1, float val2)
            => (val1 >= val2) ? val1 : val2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Max(this int val1, int val2)
            => (val1 >= val2) ? val1 : val2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Max(this long val1, long val2)
            => (val1 >= val2) ? val1 : val2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Max(this double val1, double val2)
            => (val1 >= val2) ? val1 : val2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Max(this decimal val1, decimal val2)
            => (val1 >= val2) ? val1 : val2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte Max(this sbyte val1, sbyte val2)
            => (val1 >= val2) ? val1 : val2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort Max(this ushort val1, ushort val2)
            => (val1 >= val2) ? val1 : val2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Max(this uint val1, uint val2)
            => (val1 >= val2) ? val1 : val2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Max(this ulong val1, ulong val2)
            => (val1 >= val2) ? val1 : val2;

        #endregion Max

        #region Sign

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sign(this byte value)
            => value == 0 ? 0 : 1;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sign(this short value)
            => value < 0 ? -1 : value > 0 ? 1 : 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sign(this float value)
            => value < 0 ? -1 : value > 0 ? 1 : float.IsNaN(value) ? throw new ArithmeticException("Arithmetic_NaN") : 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sign(this int value)
            => value < 0 ? -1 : value > 0 ? 1 : 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sign(this long value)
            => value < 0 ? -1 : value > 0 ? 1 : 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sign(this double value)
             => value < 0 ? -1 : value > 0 ? 1 : double.IsNaN(value) ? throw new ArithmeticException("Arithmetic_N") : 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sign(this decimal value)
            => value < 0 ? -1 : value > 0 ? 1 : 0;

         [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sign(this sbyte value)
            => value < 0 ? -1 : value > 0 ? 1 : 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sign(this ushort value)
            => value > 0 ? 1 : 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sign(this uint value)
            => value > 0 ? 1 : 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sign(this ulong value)
            => value > 0 ? 1 : 0;

        #endregion Sign
    }
}