using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Se7en.Math {
    [StructLayout(LayoutKind.Explicit, Size = 12)]
    public struct Vector3i {
        public int this[int index] {
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
        public int X;
        [FieldOffset(4)]
        public int Y;
        [FieldOffset(8)]
        public int Z;

        public Vector3i(int x = 0, int y = 0, int z = 0) {
            X = x;
            Y = y;
            Z = z;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3i Add(int valueX = 0, int valueY = 0, int valueZ = 0)
            => new Vector3i {
                X = X + valueX,
                Y = Y + valueY,
                Z = Z + valueZ
            };
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3i Sub(int valueX = 0, int valueY = 0, int valueZ = 0)
            => new Vector3i {
                X = X - valueX,
                Y = Y - valueY,
                Z = Z - valueZ
            };
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3i Mult(int valueX = 1, int valueY = 1, int valueZ = 1)
            => new Vector3i {
                X = X * valueX,
                Y = Y * valueY,
                Z = Z * valueZ
            };
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3i Div(int valueX = 1, int valueY = 1, int valueZ = 1)
            => new Vector3i {
                X = X / valueX,
                Y = Y / valueY,
                Z = Z / valueZ
            };

        #region Compare

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector3i left, Vector3i right)
            => left.X == right.X && left.Y == right.Y && left.Z == right.Z;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector3i left, Vector3i right)
            => left.X != right.X && left.Y != right.Y && left.Z != right.Z;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj)
            => obj is Vector3i ? (Vector3i)obj == this : false;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
            => X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();

        #endregion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
            => $"({X}, {Y}, {Z})";

        #region operator (Vector3i vector, int value)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3i operator +(Vector3i vector, int value)
            => new Vector3i {
                X = vector.X + value,
                Y = vector.Y + value,
                Z = vector.Z + value
            };
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3i operator -(Vector3i vector, int value)
            => new Vector3i {
                X = vector.X - value,
                Y = vector.Y - value,
                Z = vector.Z - value
            };
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3i operator *(Vector3i vector, int value)
            => new Vector3i {
                X = vector.X * value,
                Y = vector.Y * value,
                Z = vector.Z * value
            };
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3i operator /(Vector3i vector, int value)
            => new Vector3i {
                X = vector.X / value,
                Y = vector.Y / value,
                Z = vector.Z / value
            };

        #endregion
        #region operator (Vector3i vector, Vector3i value)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3i operator +(Vector3i vector, Vector3i value)
            => new Vector3i {
                X = vector.X + value.X,
                Y = vector.Y + value.Y,
                Z = vector.Z + value.Z
            };
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3i operator -(Vector3i vector, Vector3i value)
            => new Vector3i {
                X = vector.X - value.X,
                Y = vector.Y - value.Y,
                Z = vector.Z - value.Z
            };
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3i operator *(Vector3i vector, Vector3i value)
            => new Vector3i {
                X = vector.X * value.X,
                Y = vector.Y * value.Y,
                Z = vector.Z * value.Z
            };
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3i operator /(Vector3i vector, Vector3i value)
            => new Vector3i {
                X = vector.X / value.X,
                Y = vector.Y / value.Y,
                Z = vector.Z / value.Z
            };

        #endregion
    }
}
