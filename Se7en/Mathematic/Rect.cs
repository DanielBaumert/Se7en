using System.Runtime.InteropServices;

namespace Se7en.Mathematic
{
    [StructLayout(LayoutKind.Explicit, Size = 16)]
    public struct Rect
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
        public int Left;
        /// <summary>
        /// The y-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        [FieldOffset(4)]
        public int Top;
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
        public int Right;
        /// <summary>
        /// The y-coordinate of the lower-right corner of the rectangle.
        /// </summary>
        [FieldOffset(12)]
        public int Bottom;
        /// <summary>
        /// The x-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        public int X => Left;
        /// <summary>
        /// The y-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        public int Y => Top;
        /// <summary>
        /// The x-coordinate of the lower-right corner of the rectangle minus the x-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        public int Width => Right - Left;
        /// <summary>
        /// The y-coordinate of the lower-right corner of the rectangle minus the y-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        public int Height => Bottom - Top;
        public Rect(int width, int height) : this()
        {
            Left = 0;
            Top = 0;
            Right = width;
            Bottom = height;
        }
        public Rect(int x, int y, int width, int height) : this()
        {
            Left = x;
            Top = y;
            Right = x + width;
            Bottom = y + height;
        }
        public Rect(Vector2i size) : this()
        {
            Position = Vector2i.Zero;
            Size = size;
        }
        public Rect(Vector2i position, Vector2i size) : this()
        {
            Position = position;
            Size = position + size;
        }
        public static bool operator ==(Rect a, Rect b) => a.Equals(b);
        public static bool operator !=(Rect a, Rect b) => !a.Equals(b);

        public bool Equals(Rect r) => r.Left == Left && r.Top == Top && r.Right == Right && r.Bottom == Bottom;

        public bool IsInside(Vector2i loc)
            => X <= loc.X && loc.X <= X + Width && Y <= loc.Y && loc.Y <= Y + Height;

        public bool IsInside(int x, int y)
            => X <= x && x >= X + Width && Y <= y && y >= Y + Height;

        public override bool Equals(object obj)
        {
            if(obj is Rect r)
            {
                return Equals(r);
            }
            return false;

        }
        public override int GetHashCode() => base.GetHashCode();
    }
}
