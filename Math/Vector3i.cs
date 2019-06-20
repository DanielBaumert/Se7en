﻿using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Se7en.Math {

    [StructLayout(LayoutKind.Explicit, Size = 12)]
    public struct Vector3i {

        public readonly static Vector3i Zero = new Vector3i { X = 0, Y = 0, Z = 0 };
        public readonly static Vector3i One = new Vector3i { X = 1, Y = 1, Z = 1 };
        public readonly static Vector3i UnitX = new Vector3i { X = 1, Y = 0, Z = 0 };
        public readonly static Vector3i UnitY = new Vector3i { X = 0, Y = 1, Z = 0 };
        public readonly static Vector3i UnitZ = new Vector3i { X = 0, Y = 0, Z = 1 };

        [FieldOffset(0)]
        public int X;

        [FieldOffset(4)]
        public int Y;

        [FieldOffset(8)]
        public int Z;

        public int this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => index switch
            {
                0 => X,
                1 => Y,
                2 => Z,
                _ => throw new IndexOutOfRangeException("index")
            };
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                switch (index) {
                    case 0:
                        X = value;
                        break;
                    case 1:
                        Y = value;
                        break;
                    case 2:
                        Z = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("index");
                };
            }
        }

        public Vector3i(int value) : this(value, value, value) {
        }

        public Vector3i(int x = 0, int y = 0, int z = 0) {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Returns the amount of the vector.
        /// </summary>
        /// <returns>The vector's amount.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Amount()
            => (int)System.Math.Sqrt((X * X) + (Y * Y) + (Z * Z));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3i Add(int valueX = 0, int valueY = 0, int valueZ = 0)
          => new Vector3i { X = X + valueX, Y = Y + valueY, Z = Z + valueZ };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3i Sub(int valueX = 0, int valueY = 0, int valueZ = 0)
            => new Vector3i { X = X - valueX, Y = Y - valueY, Z = Z - valueZ };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3i Mul(int valueX = 1, int valueY = 1, int valueZ = 1)
            => new Vector3i { X = X * valueX, Y = Y * valueY, Z = Z * valueZ };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3i Div(int valueX = 1, int valueY = 1, int valueZ = 1)
            => new Vector3i { X = X / valueX, Y = Y / valueY, Z = Z / valueZ };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
           => $"({X}, {Y}, {Z})";

        #region Public static methods 

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Dot(Vector3i vectorA, Vector3i vectorB)
           => (vectorA.X * vectorB.X) + (vectorA.Y * vectorB.Y) + (vectorA.Z * vectorB.Z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsKomplanar(Vector3i vectorA, Vector3i vectorB, Vector3i vectorC) {
            double v1 = vectorA.X * vectorB.Y * vectorC.Z,
                   v2 = vectorB.X * vectorC.Y * vectorA.Z,
                   v3 = vectorC.X * vectorA.Y * vectorB.Z,
                   v4 = vectorA.Z * vectorB.Y * vectorC.X,
                   v5 = vectorB.Z * vectorC.Y * vectorA.X,
                   v6 = vectorC.Z * vectorA.Y * vectorB.X;
            return v1 + v2 + v3 - v4 - v5 - v6 == 0;
        }

        /// <summary>
        /// Computes the cross product of two vectors.
        /// </summary>
        /// <param name="vector1">The first vector.</param>
        /// <param name="vector2">The second vector.</param>
        /// <returns>The cross product.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3i Cross(Vector3i vectorA, Vector3i vectorB)
            => new Vector3i {
                X = (vectorA.Y * vectorB.Z) - (vectorA.Z * vectorB.Y),
                Y = -((vectorA.Z * vectorB.X) - (vectorA.X * vectorB.Z)),
                Z = (vectorA.X * vectorB.Y) - (vectorA.Y * vectorB.X)
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3i Abs(Vector3i vector)
            => new Vector3i {
                X = System.Math.Abs(vector.X),
                Y = System.Math.Abs(vector.Y),
                Z = System.Math.Abs(vector.Z),
            };

        /// <summary>
        /// Returns the Euclidean distance between the two given points.
        /// </summary>
        /// <param name="value1">The first point.</param>
        /// <param name="value2">The second point.</param>
        /// <returns>The distance.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Distance(Vector3i vectorA, Vector3i vectorB) {
            int dx = vectorA.X - vectorB.X,
                  dy = vectorA.Y - vectorB.Y,
                  dz = vectorA.Z - vectorB.Z;
            return (int)System.Math.Sqrt((dx * dx) + (dy * dy) + (dz + dz));
        }

        /// <summary>
        /// Returns a vector with the same direction as the given vector, but with a length of 1.
        /// </summary>
        /// <param name="value">The vector to normalize.</param>
        /// <returns>The normalized vector.</returns
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3i Normalize(Vector3i vector) {
            int invNorm = 1.0f / vector.Amount();
            return new Vector3i { X = vector.X * invNorm, Y = vector.Y = invNorm, Z = vector.Z * invNorm };
        }

        /// <summary>
        /// Returns the reflection of a vector off a surface that has the specified normal.
        /// </summary>
        /// <param name="vector">The source vector.</param>
        /// <param name="normal">The normal of the surface being reflected off.</param>
        /// <returns>The reflected vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3i Reflect(Vector3i vector, Vector3i normal) {
            int dot = Dot(vector, normal);
            return new Vector3i {
                X = vector.X - (2.0f * dot * normal.X),
                Y = vector.Y - (2.0f * dot * normal.Y),
                Z = vector.Z - (2.0f * dot * normal.Z)
            };
        }

        /// <summary>
        /// Restricts a vector between a min and max value.
        /// </summary>
        /// <param name="value1">The source vector.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>The restricted vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3i Clamp(Vector3i value1, Vector3i min, Vector3i max) {
            int x = (value1.X > max.X)
                        ? max.X
                        : (value1.X < min.X)
                            ? min.X
                            : value1.X;

            int y = (value1.Y > max.Y)
                        ? max.Y
                        : (value1.Y < min.Y)
                            ? min.Y
                            : value1.Y;

            int z = (value1.Z > max.Z)
                        ? max.Z
                        : (value1.Z < min.Z)
                            ? min.Z
                            : value1.Z;

            return new Vector3i(x, y, z);
        }

        /// <summary>
        /// Linearly interpolates between two vectors based on the given weighting.
        /// </summary>
        /// <param name="value1">The first source vector.</param>
        /// <param name="value2">The second source vector.</param>
        /// <param name="amount">Value between 0 and 1 indicating the weight of the second source vector.</param>
        /// <returns>The interpolated vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3i Lerp(Vector3i vectorA, Vector3i vectorB, int amount)
            => new Vector3i {
                X = vectorA.X + (vectorB.X - vectorA.X) * amount,
                Y = vectorA.Y + (vectorB.Y - vectorA.Y) * amount,
                Z = vectorA.Z + (vectorB.Z - vectorA.Z) * amount,
            };

        #endregion


        #region Compare

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector3i left, Vector3i right)
            => left.X == right.X && left.Y == right.Y && left.Z == right.Z;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector3i left, Vector3i right)
            => left.X != right.X || left.Y != right.Y || left.Z != right.Z;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj)
            => obj is Vector3i ? (Vector3i)obj == this : false;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vector3i other)
            => X == other.X && Y == other.Y && Z == other.Z;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
            => X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();

        #endregion Compare

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
        public static Vector3i operator /(Vector3i vector, int value) {
            int invDiv = 1.0f / value;
            return new Vector3i {
                X = vector.X * invDiv,
                Y = vector.Y * invDiv,
                Z = vector.Z * invDiv
            };
        }

        #endregion operator (Vector3i vector, int value)

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

        #endregion operator (Vector3i vector, Vector3i value)
    }
}