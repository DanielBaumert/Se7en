using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Se7en.Math {

    [StructLayout(LayoutKind.Explicit, Size = 12)]
    public struct Vector3f {

        public float this[int index] {
            get => index switch
            {
                0 => X,
                1 => Y,
                2 => Z,
                _ => throw new IndexOutOfRangeException("index")
            };
            set {
                if (index == 0)
                    X = value;
                else if (index == 1)
                    Y = value;
                else if (index == 2)
                    Z = value;
                else
                    throw new IndexOutOfRangeException("index");
            }
        }

        [FieldOffset(0)]
        public float X;

        [FieldOffset(4)]
        public float Y;

        [FieldOffset(8)]
        public float Z;

        public Vector3f(float x = 0, float y = 0, float z = 0) {
            X = x;
            Y = y;
            Z = z;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3f Add(float valueX = 0, float valueY = 0, float valueZ = 0)
            => new Vector3f {
                X = X + valueX,
                Y = Y + valueY,
                Z = Z + valueZ
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3f Sub(float valueX = 0, float valueY = 0, float valueZ = 0)
            => new Vector3f {
                X = X - valueX,
                Y = Y - valueY,
                Z = Z - valueZ
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3f Mult(float valueX = 1, float valueY = 1, float valueZ = 1)
            => new Vector3f {
                X = X * valueX,
                Y = Y * valueY,
                Z = Z * valueZ
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3f Div(float valueX = 1, float valueY = 1, float valueZ = 1)
            => new Vector3f {
                X = X / valueX,
                Y = Y / valueY,
                Z = Z / valueZ
            };

        #region Compare

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector3f left, Vector3f right)
            => left.X == right.X && left.Y == right.Y && left.Z == right.Z;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector3f left, Vector3f right)
            => left.X != right.X && left.Y != right.Y && left.Z != right.Z;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj)
            => obj is Vector3f ? (Vector3f)obj == this : false;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
            => X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();

        #endregion Compare

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
            => $"({X}, {Y}, {Z})";

        #region operator (Vector3f vector, float value)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3f operator +(Vector3f vector, float value)
            => new Vector3f {
                X = vector.X + value,
                Y = vector.Y + value,
                Z = vector.Z + value
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3f operator -(Vector3f vector, float value)
            => new Vector3f {
                X = vector.X - value,
                Y = vector.Y - value,
                Z = vector.Z - value
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3f operator *(Vector3f vector, float value)
            => new Vector3f {
                X = vector.X * value,
                Y = vector.Y * value,
                Z = vector.Z * value
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3f operator /(Vector3f vector, float value)
            => new Vector3f {
                X = vector.X / value,
                Y = vector.Y / value,
                Z = vector.Z / value
            };

        #endregion operator (Vector3f vector, float value)

        #region operator (Vector3f vector, Vector3f value)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3f operator +(Vector3f vector, Vector3f value)
            => new Vector3f {
                X = vector.X + value.X,
                Y = vector.Y + value.Y,
                Z = vector.Z + value.Z
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3f operator -(Vector3f vector, Vector3f value)
            => new Vector3f {
                X = vector.X - value.X,
                Y = vector.Y - value.Y,
                Z = vector.Z - value.Z
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3f operator *(Vector3f vector, Vector3f value)
            => new Vector3f {
                X = vector.X * value.X,
                Y = vector.Y * value.Y,
                Z = vector.Z * value.Z
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3f operator /(Vector3f vector, Vector3f value)
            => new Vector3f {
                X = vector.X / value.X,
                Y = vector.Y / value.Y,
                Z = vector.Z / value.Z
            };

        #endregion operator (Vector3f vector, Vector3f value)
    }
}