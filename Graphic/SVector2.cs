using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Se7en.Graphic {
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct SVector2 {

        public static SVector2 Empty = new SVector2(0, 0);

        [FieldOffset(0)]
        public void* Ptr;
        [FieldOffset(0)]
        public int X;
        [FieldOffset(4)]
        public int Y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SVector2(int x, int y) : this() {
            X = x;
            Y = y;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe override bool Equals(object obj) {
            if(obj is SVector2 vector) {
                return vector.X == X && vector.Y == Y;
            }
            return false;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => base.GetHashCode();
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SVector2 operator +(SVector2 left, SVector2 right) => new SVector2(left.X + right.X, left.Y + right.Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SVector2 operator -(SVector2 left, SVector2 right) => new SVector2(left.X - right.X, left.Y - right.Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SVector2 operator *(SVector2 left, SVector2 right) => new SVector2(left.X * right.X, left.Y * right.Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SVector2 operator /(SVector2 left, SVector2 right) => new SVector2(left.X / right.X, left.Y / right.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static implicit operator SPoint2(SVector2 p) => *(SPoint2*)&p;
    }
}
