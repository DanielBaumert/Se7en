using Se7en.Math;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Se7en.UI.Drawing
{
    [StructLayout(LayoutKind.Explicit, Size = 16)]
    public struct Rectangle2D
    {
        public static readonly Rectangle2D Empty = new Rectangle2D(Point2D.Empty, Size2D.Empty);
        [FieldOffset(0)]
        public Point2D Position;
        [FieldOffset(0)]
        public int X;
        [FieldOffset(4)]
        public int Y;
        [FieldOffset(8)]
        public Size2D Size;
        [FieldOffset(8)]
        public int Width;
        [FieldOffset(12)]
        public int Height;


        public unsafe Rectangle2D(Point2D position, Size2D size) : this(
            *(int*)&position, // X
            *((int*)&position + 1), //y
            *(int*)&size,  //width
            *((int*)&size + 1)) //height
        { }
        public Rectangle2D(int x, int y, int width, int height) : this()
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj)
        {
            if(obj != null && obj is Rectangle2D rect)
            {
                return Position == rect.Position & Size == rect.Size;
            }
            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => base.GetHashCode();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]

        public static bool operator ==(Rectangle2D left, Rectangle2D right) => left.Position == right.Position & left.Size == right.Size;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Rectangle2D left, Rectangle2D right) => left.Position != right.Position | left.Size != right.Size;

    }
}
