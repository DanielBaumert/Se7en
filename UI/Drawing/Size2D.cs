using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Se7en.UI.Drawing
{
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct Size2D
    {
        public static readonly Size2D Empty = new Size2D(0, 0);
        [FieldOffset(0)]
        public int Width;
        [FieldOffset(4)]
        public int Height;

        public Size2D(int width, int height)
        {
            Width = width;
            Height = height;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Offset(int dw, int dh)
        {
            Width += dw;
            Height += dh;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj)
        {
            if (obj != null && obj is Size2D size)
            {
                return size.Width == Width && size.Height == Height;
            }
            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Size2D size)
        {
            if (size != null)
            {
                return size.Width == Width & size.Height == Height;
            }
            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => base.GetHashCode();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Size2D left, Size2D right) => left.Width == right.Width & left.Height == right.Height;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Size2D left, Size2D right) => left.Width != right.Width | left.Height != right.Height;
    }
}
