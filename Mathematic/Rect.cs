using System.Runtime.InteropServices;

namespace Se7en.Mathematic {
    [StructLayout(LayoutKind.Sequential)]
    public struct Rect {
        /// <summary>
        /// The x-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        public int Left;
        /// <summary>
        /// The y-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        public int Top;
        /// <summary>
        /// The x-coordinate of the lower-right corner of the rectangle.
        /// </summary>
        public int Right;
        /// <summary>
        /// The y-coordinate of the lower-right corner of the rectangle.
        /// </summary>
        public int Bottom;

        public int X => Left;
        public int Y  => Top; 
        public int Width  => Right - Left;
        public int Height => Bottom - Top;

        public Vector2i Location  => new Vector2i(X, Y); 
        public Vector2i Size => new Vector2i(Width, Height);

        public static bool operator ==(Rect a, Rect b) => a.Location == b.Location && a.Size == b.Size;
        public static bool operator !=(Rect a, Rect b) => a.Location != b.Location || a.Size != b.Size;

        public bool IsInside(Vector2i loc)
            => X <= loc.X && loc.X <= X + Width && Y <= loc.Y && loc.Y <= Y + Height;

        public bool IsInside(int x, int y)
            => X <= x && x >= X + Width && Y <= y && y >= Y + Height;

        public override bool Equals(object obj) => base.Equals(obj);
        public override int GetHashCode() => base.GetHashCode();
    }
}
