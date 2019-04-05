using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Se7en.Math
{
    [StructLayout(LayoutKind.Explicit)]
    public struct Vector2D
    {

        public static Vector2D Empty = new Vector2D(0, 0);

        [FieldOffset(0)]
        public int X;
        [FieldOffset(4)]
        public int Y;

        public Vector2D(int x, int y)
        {
            X = x;
            Y = y;
        }


        public unsafe override bool Equals(object obj)
        {
            if (obj is Vector2D vector)
            {
                return vector.X == X && vector.Y == Y;
            }
            return false;
        }

        public static Vector2D operator +(Vector2D left, Vector2D right) => new Vector2D(left.X + right.X, left.Y + right.Y);
        public static Vector2D operator -(Vector2D left, Vector2D right) => new Vector2D(left.X - right.X, left.Y - right.Y);
        public static Vector2D operator *(Vector2D left, Vector2D right) => new Vector2D(left.X * right.X, left.Y * right.Y);
        public static Vector2D operator /(Vector2D left, Vector2D right) => new Vector2D(left.X / right.X, left.Y / right.Y);
        public unsafe static implicit operator Point2D(Vector2D p) => *(Point2D*)&p;

    }
}
