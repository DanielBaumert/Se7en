using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Se7en.Graphic {

    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct SRect {
        [FieldOffset(0)]
        public void* Ptr;
        [FieldOffset(0)]
        public SPoint Location;
        [FieldOffset(0)]
        public int X;
        [FieldOffset(4)]
        public int Y;
        [FieldOffset(8)]
        public SSize Size;
        [FieldOffset(8)]
        public int Width;
        [FieldOffset(12)]
        public int Height;

        public static SRect Empty = new SRect();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SRect(int x, int y, int width, int height) : this() {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SRect(SPoint location, int width, int height) : this() {
            Location = location;
            Width = width;
            Height = height;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SRect(int x, int y, SSize size) : this() {
            X = x;
            Y = y;
            Size = size;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SRect(SPoint location, SSize size) : this() {
            Location = location;
            Size = size;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(SRect left, SRect right) => left.Location == right.Location && left.Size == right.Size;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(SRect left, SRect right) => left.Location != right.Location && left.Size != right.Size;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj != null && obj is SRect ? (SRect)obj == this : false;
    }
}
