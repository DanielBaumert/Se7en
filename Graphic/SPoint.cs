using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
namespace Se7en.Graphic {
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public unsafe struct SPoint2 {
        [FieldOffset(0)]
        public void* Ptr;
        [FieldOffset(0)]
        public int X;
        [FieldOffset(4)]
        public int Y;

        public static SPoint2 Empty = new SPoint2();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SPoint2(int x, int y) : this() {
            X = x;
            Y = y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SPoint2(SPoint2 point) : this() {
            X = point.X;
            Y = point.Y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(SPoint2 left, SPoint2 right) => left.X == right.X && left.Y == right.Y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(SPoint2 left, SPoint2 right) => left.X != right.X && left.Y != right.Y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj != null && obj is SPoint2 ? (SPoint2)obj == this : false;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(SPoint2 point) => point != null ? point.X == X & point.Y == Y : false;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => base.GetHashCode();

        public unsafe static implicit operator SVector2(SPoint2 p) => *(SVector2*)&p;
    }
}
