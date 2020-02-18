using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Se7en.Mathematic {

    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct Vector2i {

        public static readonly Vector2i Zero = new Vector2i { X = 0, Y = 0 };
        public static readonly Vector2i One = new Vector2i { X = 1, Y = 1 };
        public static readonly Vector2i UnitX = new Vector2i { X = 1, Y = 0 };
        public static readonly Vector2i UnitY = new Vector2i { X = 0, Y = 1 };

        [FieldOffset(0)]
        public int X;

        [FieldOffset(4)]
        public int Y;

        public int this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => index switch
            {
                0 => X,
                1 => Y,
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
                    default:
                        throw new IndexOutOfRangeException("index");
                };
            }
        }

        public Vector2i(int value) : this(value, value) {
        }

        public Vector2i(int x = 0, int y = 0) {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Returns the amount of the vector.
        /// </summary>
        /// <returns>The vector's amount.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Amount()
            => (float) System.Math.Sqrt((X * X) + (Y * Y));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2i Add(int valueX = 0, int valueY = 0)
          => new Vector2i { X = X + valueX, Y = Y + valueY };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2i Sub(int valueX = 0, int valueY = 0)
            => new Vector2i { X = X - valueX, Y = Y - valueY };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2i Mul(int valueX = 1, int valueY = 1)
            => new Vector2i { X = X * valueX, Y = Y * valueY };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2i Div(int valueX = 1, int valueY = 1, int valueZ = 1)
            => new Vector2i { X = X / valueX, Y = Y / valueY };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
           => $"({X}, {Y})";

        #region Public static methods 

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Dot(Vector2i vectorA, Vector2i vectorB)
           => (vectorA.X * vectorB.X) + (vectorA.Y * vectorB.Y);

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool IsKomplanar(Vector2i vectorA, Vector2i vectorB, Vector2i vectorC) {
        //    double v1 = vectorA.X * vectorB.Y * vectorC.Z,
        //           v2 = vectorB.X * vectorC.Y * vectorA.Z,
        //           v3 = vectorC.X * vectorA.Y * vectorB.Z,
        //           v4 = vectorA.Z * vectorB.Y * vectorC.X,
        //           v5 = vectorB.Z * vectorC.Y * vectorA.X,
        //           v6 = vectorC.Z * vectorA.Y * vectorB.X;
        //    return v1 + v2 + v3 - v4 - v5 - v6 == 0;
        //}

        /// <summary>
        /// Computes the cross product of two vectors. !! isnt a real cross
        /// </summary>
        /// <param name="vector1">The first vector.</param>
        /// <param name="vector2">The second vector.</param>
        /// <returns>The cross product.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2i Cross(Vector2i vectorA, Vector2i vectorB)
            => new Vector2i {
                X = (vectorA.Y * vectorB.X) - (vectorA.X - vectorB.Y),
                Y = -((vectorA.X - vectorB.Y) - (vectorA.Y * vectorB.X))
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2i Abs(Vector2i vector)
            => new Vector2i {
                X = System.Math.Abs(vector.X),
                Y = System.Math.Abs(vector.Y)
            };

        /// <summary>
        /// Returns the Euclidean distance between the two given points.
        /// </summary>
        /// <param name="value1">The first point.</param>
        /// <param name="value2">The second point.</param>
        /// <returns>The distance.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Distance(Vector2i vectorA, Vector2i vectorB) {
            int dx = vectorA.X - vectorB.X,
                dy = vectorA.Y - vectorB.Y;
            return (int)System.Math.Sqrt((dx * dx) + (dy * dy));
        }

        /// <summary>
        /// Returns a vector with the same direction as the given vector, but with a length of 1.
        /// </summary>
        /// <param name="value">The vector to normalize.</param>
        /// <returns>The normalized vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2i Normalize(Vector2i vector) {
            float invNorm = 1.0f / vector.Amount();
            return new Vector2i {
                X = (int)(vector.X * invNorm), 
                Y = (int)(vector.Y * invNorm)
            };
        }

        /// <summary>
        /// Returns the reflection of a vector off a surface that has the specified normal.
        /// </summary>
        /// <param name="vector">The source vector.</param>
        /// <param name="normal">The normal of the surface being reflected off.</param>
        /// <returns>The reflected vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2i Reflect(Vector2i vector, Vector2i normal) {
            int dot = Dot(vector, normal);
            return new Vector2i {
                X = (int)(vector.X - (2.0f * dot * normal.X)),
                Y = (int)(vector.Y - (2.0f * dot * normal.Y))
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
        public static Vector2i Clamp(Vector2i value1, Vector2i min, Vector2i max) {
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

            return new Vector2i { X = x, Y = y };
        }

        /// <summary>
        /// Linearly interpolates between two vectors based on the given weighting.
        /// </summary>
        /// <param name="value1">The first source vector.</param>
        /// <param name="value2">The second source vector.</param>
        /// <param name="amount">Value between 0 and 1 indicating the weight of the second source vector.</param>
        /// <returns>The interpolated vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2i Lerp(Vector2i vectorA, Vector2i vectorB, int amount)
            => new Vector2i {
                X = vectorA.X + (vectorB.X - vectorA.X) * amount,
                Y = vectorA.Y + (vectorB.Y - vectorA.Y) * amount
            };

        #endregion

        #region Compare

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector2i left, Vector2i right)
            => left.X == right.X && left.Y == right.Y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector2i left, Vector2i right)
            => left.X != right.X || left.Y != right.Y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj)
            => obj is Vector2i ? (Vector2i)obj == this : false;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vector2i other)
            => X == other.X && Y == other.Y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
            => X.GetHashCode() ^ Y.GetHashCode();

        #endregion Compare

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
        public static Vector2i operator /(Vector2i vector, int value) {
            float invDiv = 1.0f / value;
            return new Vector2i {
                X = (int)(vector.X * invDiv),
                Y = (int)(vector.Y * invDiv)
            };
        }

        #endregion operator (Vector2i vector, int value)

        #region operator (Vector2i vector, Vector2i value)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2i operator +(Vector2i vector, Vector2i value)
            => new Vector2i {
                X = vector.X + value.X,
                Y = vector.Y + value.Y,
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2i operator -(Vector2i vector, Vector2i value)
            => new Vector2i {
                X = vector.X - value.X,
                Y = vector.Y - value.Y,
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

        #endregion operator (Vector2i vector, Vector2i value)

        #region Convert

        public static implicit operator Vector2f(Vector2i vector)
                => new Vector2f { X = vector.X, Y = vector.Y };

        #endregion Convert
    }
}