using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Se7en.Math
{
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct Point2D
    {
        public static readonly Point2D Empty = new Point2D(0, 0);
        [FieldOffset(0)]
        public int X;
        [FieldOffset(4)]
        public int Y;

        public Point2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj)
        {
            if (obj != null && obj is Point2D point)
            {
                return point.X == X && point.Y == Y;
            }
            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Offset(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => base.GetHashCode();
        public override string ToString() => base.ToString();
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Point2D left, Point2D right) => left.X == right.X & left.Y == right.Y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Point2D left, Point2D right) => left.X != right.X | left.Y != right.Y;


        public unsafe static implicit operator Vector2D(Point2D p) => *(Vector2D*)&p;
    }
}
