using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Se7en.Math {
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct Vector2i {
        public int this[int index] {
            get => index switch
            {
                0 => X,
                1 => Y,
                _ => throw new IndexOutOfRangeException("index")
            };
            set {
                if (index == 0)
                    X = value;
                else if (index == 1)
                    Y = value;
                else
                    throw new IndexOutOfRangeException("index");
            }
        }

        [FieldOffset(0)]
        public int X;
        [FieldOffset(4)]
        public int Y;

        public Vector2i(int x = 0, int y = 0, int z = 0) {
            X = x;
            Y = y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2i Add(int valueX = 0, int valueY = 0)
            => new Vector2i {
                X = X + valueX,
                Y = Y + valueY
            };
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2i Sub(int valueX = 0, int valueY = 0)
            => new Vector2i {
                X = X - valueX,
                Y = Y - valueY
            };
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2i Mult(int valueX = 1, int valueY = 1)
            => new Vector2i {
                X = X * valueX,
                Y = Y * valueY
            };
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2i Div(int valueX = 1, int valueY = 1)
            => new Vector2i {
                X = X / valueX,
                Y = Y / valueY
            };

        #region Compare

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector2i left, Vector2i right)
            => left.X == right.X && left.Y == right.Y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector2i left, Vector2i right)
            => left.X != right.X && left.Y != right.Y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj)
            => obj is Vector2i ? (Vector2i)obj == this : false;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
            => X.GetHashCode() ^ Y.GetHashCode();

        #endregion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
            => $"({X}, {Y})";

        #region operator (Vector2i vector, int value)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2i operator +(Vector2i vector, int value)
            => new Vector2i {
                X = vector.X + value,
                Y = vector.Y + value
            };
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2i operator -(Vector2i vector, int value)
            => new Vector2i {
                X = vector.X - value,
                Y = vector.Y - value
            };
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2i operator *(Vector2i vector, int value)
            => new Vector2i {
                X = vector.X * value,
                Y = vector.Y * value
            };
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2i operator /(Vector2i vector, int value)
            => new Vector2i {
                X = vector.X / value,
                Y = vector.Y / value
            };

        #endregion
        #region operator (Vector2i vector, Vector2i value)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2i operator +(Vector2i vector, Vector2i value)
            => new Vector2i {
                X = vector.X + value.X,
                Y = vector.Y + value.Y
            };
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2i operator -(Vector2i vector, Vector2i value)
            => new Vector2i {
                X = vector.X - value.X,
                Y = vector.Y - value.Y
            };
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2i operator *(Vector2i vector, Vector2i value)
            => new Vector2i {
                X = vector.X * value.X,
                Y = vector.Y * value.Y,
            };
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2i operator /(Vector2i vector, Vector2i value)
            => new Vector2i {
                X = vector.X / value.X,
                Y = vector.Y / value.Y,
            };

        #endregion
        #region Convert

        public static implicit operator Vector2f(Vector2i vector) 
            => new Vector2f {  X = vector.X, Y = vector.Y};

        #endregion

    }
}
