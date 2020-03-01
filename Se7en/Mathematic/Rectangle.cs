using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Se7en.Mathematic
{
    [StructLayout(LayoutKind.Explicit)]
    public struct Rectangle
    {
        /// <summary>
        /// The x-coordinate of the upper-left corner of the rectangle.
        /// The y-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        [FieldOffset(0)]
        public Vector2i Position;
        /// <summary>
        /// The x-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        [FieldOffset(0)]
        public int X;
        /// <summary>
        /// The y-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        [FieldOffset(4)]
        public int Y;
        /// <summary>
        /// The x-coordinate of the lower-right corner of the rectangle.
        /// The y-coordinate of the lower-right corner of the rectangle.
        /// </summary>
        [FieldOffset(8)]
        public Vector2i Size;
        /// <summary>
        /// The x-coordinate of the lower-right corner of the rectangle.
        /// </summary>
        [FieldOffset(8)]
        public int Width;
        /// <summary>
        /// The y-coordinate of the lower-right corner of the rectangle.
        /// </summary>
        [FieldOffset(12)]
        public int Height;
        /// <summary>
        /// The x-coordinate of the upper-left corner of the rectangle.
        /// </summary>

        public Rectangle(int width, int height) : this()
        {
            X = 0;
            Y = 0;
            Width = width;
            Height = height;
        }
        public Rectangle(int x, int y, int width, int height) : this()
        {
            X = x;
            Y = y;
            Width = x + width;
            Height = y + height;
        }
        public Rectangle(Vector2i size) : this()
        {
            Position = Vector2i.Zero;
            Size = size;
        }
        public Rectangle(Vector2i position, Vector2i size) : this()
        {
            Position = position;
            Size = position + size;
        }
        public static bool operator ==(Rectangle a, Rectangle b) => a.Position == b.Position && a.Size == b.Size;
        public static bool operator !=(Rectangle a, Rectangle b) => a.Position != b.Position || a.Size != b.Size;

        public bool IsInside(Vector2i loc)
            => X <= loc.X && loc.X <= X + Width && Y <= loc.Y && loc.Y <= Y + Height;

        public bool IsInside(int x, int y)
            => X <= x && x >= X + Width && Y <= y && y >= Y + Height;

        public override bool Equals(object obj)
        {
            if(obj is Rectangle rectangle)
            {
                return X == rectangle.X && Y == rectangle.Y && Width == rectangle.Width && Height == rectangle.Height;
            }
            return base.Equals(obj);
        }
        public override int GetHashCode() => base.GetHashCode();

    }
}
