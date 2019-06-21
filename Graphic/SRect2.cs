using Se7en.Mathematic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Se7en.Graphic {

    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct SRect2 {

        [FieldOffset(0)]
        public void* Ptr;

        [FieldOffset(0)]
        public Vector2i Position;

        [FieldOffset(0)]
        public int X;

        [FieldOffset(4)]
        public int Y;

        [FieldOffset(8)]
        public Vector2i Size;

        [FieldOffset(8)]
        public int Width;

        [FieldOffset(12)]
        public int Height;

        public static SRect2 Empty = new SRect2();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SRect2(int x, int y, int width, int height) : this() {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SRect2(Vector2i location, int width, int height) : this() {
            Position = location;
            Width = width;
            Height = height;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SRect2(int x, int y, Vector2i size) : this() {
            X = x;
            Y = y;
            Size = size;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SRect2(Vector2i location, Vector2i size) : this() {
            Position = location;
            Size = size;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => base.GetHashCode();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(SRect2 left, SRect2 right) => left.Position == right.Position && left.Size == right.Size;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(SRect2 left, SRect2 right) => left.Position != right.Position && left.Size != right.Size;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj != null && obj is SRect2 ? (SRect2)obj == this : false;
    }
}