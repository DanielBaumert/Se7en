
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Se7en.Graphic {
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public unsafe struct SSize2 {
        [FieldOffset(0)]
        public void* Ptr;
        [FieldOffset(0)]
        public int Width;
        [FieldOffset(4)]
        public int Height;

        public static SSize2 Empty = new SSize2();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SSize2(int width, int height) : this() {
            Width = width;
            Height = height;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SSize2(SSize2 size) : this() {
            Width = size.Width;
            Height = size.Height;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(SSize2 left, SSize2 right) => left.Width == right.Width && left.Height == right.Height;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(SSize2 left, SSize2 right) => left.Width != right.Width && left.Height != right.Height;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj != null && obj is SSize2 ? (SSize2)obj == this : false;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(SSize2 size) => size != null ? size.Width == Width & size.Height == Height : false;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => base.GetHashCode();
    }
}
