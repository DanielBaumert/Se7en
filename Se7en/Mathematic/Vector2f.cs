using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Se7en.Mathematic {

    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct Vector2f {

        public readonly static Vector2f Zero = new Vector2f { X = 0, Y = 0 };
        public readonly static Vector2f One = new Vector2f { X = 1, Y = 1 };
        public readonly static Vector2f UnitX = new Vector2f { X = 1, Y = 0 };
        public readonly static Vector2f UnitY = new Vector2f { X = 0, Y = 1 };

        [FieldOffset(0)]
        public float X;

        [FieldOffset(4)]
        public float Y;

        public float this[int index] {
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

        public Vector2f(float value) : this(value, value) {
        }

        public Vector2f(float x = 0, float y = 0) {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Returns the amount of the vector.
        /// </summary>
        /// <returns>The vector's amount.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Amount()
            => (float)System.Math.Sqrt((X * X) + (Y * Y));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2f Add(float valueX = 0, float valueY = 0)
          => new Vector2f { X = X + valueX, Y = Y + valueY };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2f Sub(float valueX = 0, float valueY = 0)
            => new Vector2f { X = X - valueX, Y = Y - valueY };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2f Mul(float valueX = 1, float valueY = 1)
            => new Vector2f { X = X * valueX, Y = Y * valueY };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2f Div(float valueX = 1, float valueY = 1)
            => new Vector2f { X = X / valueX, Y = Y / valueY };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
           => $"({X}, {Y})";

        #region Public static methods 

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Dot(Vector2f vectorA, Vector2f vectorB)
           => (vectorA.X * vectorB.X) + (vectorA.Y * vectorB.Y);

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool IsKomplanar(Vector2f vectorA, Vector2f vectorB, Vector2f vectorC) {
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
        public static Vector2f Cross(Vector2f vectorA, Vector2f vectorB)
            => new Vector2f {
                X = (vectorA.Y * vectorB.X) - (vectorA.X - vectorB.Y),
                Y = -((vectorA.X - vectorB.Y) - (vectorA.Y * vectorB.X))
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2f Abs(Vector2f vector)
            => new Vector2f {
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
        public static float Distance(Vector2f vectorA, Vector2f vectorB) {
            float dx = vectorA.X - vectorB.X,
                  dy = vectorA.Y - vectorB.Y;
            return (float)System.Math.Sqrt((dx * dx) + (dy * dy));
        }

        /// <summary>
        /// Returns a vector with the same direction as the given vector, but with a length of 1.
        /// </summary>
        /// <param name="value">The vector to normalize.</param>
        /// <returns>The normalized vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2f Normalize(Vector2f vector) {
            float invNorm = 1.0f / vector.Amount();
            return new Vector2f { X = vector.X * invNorm, Y = vector.Y = invNorm, };
        }

        /// <summary>
        /// Returns the reflection of a vector off a surface that has the specified normal.
        /// </summary>
        /// <param name="vector">The source vector.</param>
        /// <param name="normal">The normal of the surface being reflected off.</param>
        /// <returns>The reflected vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2f Reflect(Vector2f vector, Vector2f normal) {
            float dot = Dot(vector, normal);
            return new Vector2f {
                X = vector.X - (2.0f * dot * normal.X),
                Y = vector.Y - (2.0f * dot * normal.Y)
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
        public static Vector2f Clamp(Vector2f value1, Vector2f min, Vector2f max) {
            float x = (value1.X > max.X)
                        ? max.X
                        : (value1.X < min.X)
                            ? min.X
                            : value1.X;

            float y = (value1.Y > max.Y)
                        ? max.Y
                        : (value1.Y < min.Y)
                            ? min.Y
                            : value1.Y;

            return new Vector2f { X = x, Y = y };
        }

        /// <summary>
        /// Linearly interpolates between two vectors based on the given weighting.
        /// </summary>
        /// <param name="value1">The first source vector.</param>
        /// <param name="value2">The second source vector.</param>
        /// <param name="amount">Value between 0 and 1 indicating the weight of the second source vector.</param>
        /// <returns>The interpolated vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2f Lerp(Vector2f vectorA, Vector2f vectorB, float amount)
            => new Vector2f {
                X = vectorA.X + (vectorB.X - vectorA.X) * amount,
                Y = vectorA.Y + (vectorB.Y - vectorA.Y) * amount
            };

        #endregion

        #region Compare

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector2f left, Vector2f right)
            => left.X == right.X && left.Y == right.Y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector2f left, Vector2f right)
            => left.X != right.X || left.Y != right.Y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj)
            => obj is Vector2f ? (Vector2f)obj == this : false;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vector2f other)
            => X == other.X && Y == other.Y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
            => X.GetHashCode() ^ Y.GetHashCode();

        #endregion Compare

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
        public static Vector2f operator /(Vector2f vector, float value) {
            float invDiv = 1.0f / value;
            return new Vector2f {
                X = vector.X * invDiv,
                Y = vector.Y * invDiv
            };
        }

        #endregion operator (Vector2f vector, float value)

        #region operator (Vector2f vector, Vector2f value)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2f operator +(Vector2f vector, Vector2f value)
            => new Vector2f {
                X = vector.X + value.X,
                Y = vector.Y + value.Y,
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2f operator -(Vector2f vector, Vector2f value)
            => new Vector2f {
                X = vector.X - value.X,
                Y = vector.Y - value.Y,
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