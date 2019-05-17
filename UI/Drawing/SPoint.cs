using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Se7en.Graphic {
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public unsafe struct SPoint {
        [FieldOffset(0)]
        public void* Ptr;
        [FieldOffset(0)]
        public int X;
        [FieldOffset(4)]
        public int Y;

        public static SPoint Empty = new SPoint();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SPoint(int x, int y) : this() {
            X = x;
            Y = y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SPoint(SPoint point) : this() {
            X = point.X;
            Y = point.Y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(SPoint left, SPoint right) => left.X == right.X && left.Y == right.Y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(SPoint left, SPoint right) => left.X != right.X && left.Y != right.Y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj != null && obj is SPoint ? (SPoint)obj == this : false;
    }
}
