using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Se7en.Math {

    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct Vector2f {

        public float this[float index] {
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
        public float X;

        [FieldOffset(4)]
        public float Y;

        public Vector2f(float x = 0, float y = 0, float z = 0) {
            X = x;
            Y = y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2f Add(float valueX = 0, float valueY = 0)
            => new Vector2f {
                X = X + valueX,
                Y = Y + valueY
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2f Sub(float valueX = 0, float valueY = 0)
            => new Vector2f {
                X = X - valueX,
                Y = Y - valueY
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2f Mult(float valueX = 1, float valueY = 1)
            => new Vector2f {
                X = X * valueX,
                Y = Y * valueY
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2f Div(float valueX = 1, float valueY = 1)
            => new Vector2f {
                X = X / valueX,
                Y = Y / valueY
            };

        #region Compare

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector2f left, Vector2f right)
            => left.X == right.X && left.Y == right.Y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector2f left, Vector2f right)
            => left.X != right.X && left.Y != right.Y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj)
            => obj is Vector2f ? (Vector2f)obj == this : false;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
            => X.GetHashCode() ^ Y.GetHashCode();

        #endregion Compare

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
            => $"({X}, {Y})";

        #region operator (Vector2f vector, float value)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2f operator +(Vector2f vector, float value)
            => new Vector2f {
                X = vector.X + value,
                Y = vector.Y + value
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2f operator -(Vector2f vector, float value)
            => new Vector2f {
                X = vector.X - value,
                Y = vector.Y - value
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2f operator *(Vector2f vector, float value)
            => new Vector2f {
                X = vector.X * value,
                Y = vector.Y * value
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2f operator /(Vector2f vector, float value)
            => new Vector2f {
                X = vector.X / value,
                Y = vector.Y / value
            };

        #endregion operator (Vector2f vector, float value)

        #region operator (Vector2f vector, Vector2f value)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2f operator +(Vector2f vector, Vector2f value)
            => new Vector2f {
                X = vector.X + value.X,
                Y = vector.Y + value.Y
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2f operator -(Vector2f vector, Vector2f value)
            => new Vector2f {
                X = vector.X - value.X,
                Y = vector.Y - value.Y
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2f operator *(Vector2f vector, Vector2f value)
            => new Vector2f {
                X = vector.X * value.X,
                Y = vector.Y * value.Y,
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2f operator /(Vector2f vector, Vector2f value)
            => new Vector2f {
                X = vector.X / value.X,
                Y = vector.Y / value.Y,
            };

        #endregion operator (Vector2f vector, Vector2f value)
    }
}