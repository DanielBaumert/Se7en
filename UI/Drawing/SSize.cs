
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Se7en.Graphic {
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public unsafe struct SSize {
        [FieldOffset(0)]
        public void* Ptr;
        [FieldOffset(0)]
        public int Width;
        [FieldOffset(4)]
        public int Height;

        public static SSize Empty = new SSize();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SSize(int width, int height) : this() {
            Width = width;
            Height = height;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SSize(SSize size) : this() {
            Width = size.Width;
            Height = size.Height;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(SSize left, SSize right) => left.Width == right.Width && left.Height == right.Height;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(SSize left, SSize right) => left.Width != right.Width && left.Height != right.Height;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj != null && obj is SSize ? (SSize) obj == this : false;
       
    }
}
