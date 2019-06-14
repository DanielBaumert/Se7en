using System;

namespace Se7en.OpenCvSharp
{
    /// <summary>
    /// 2-Tuple of float (System.Single)
    /// </summary>
        [Serializable]
    public struct Vec2f : IVec<float>, IEquatable<Vec2f>
    {
       
        public Vec2f(float item0, float item1)
        {
            Item0 = item0;
            Item1 = item1;
        }

        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public float this[int i] {
            get {
                if (i == 0)
                {
                    return this.Item0;
                }
                if (i != 1)
                {
                    throw new ArgumentOutOfRangeException("i");
                }
                return Item1;
            }
            set {
                if (i == 0)
                {
                    Item0 = value;
                    return;
                }
                if (i != 1)
                {
                    throw new ArgumentOutOfRangeException("i");
                }
                Item1 = value;
            }
        }

        public bool Equals(Vec2f other) 
            => this.Item0.Equals(other.Item0) && this.Item1.Equals(other.Item1);


        public override bool Equals(object obj) 
            => obj != null && obj is Vec2f && this.Equals((Vec2f)obj);

        public static bool operator ==(Vec2f a, Vec2f b) 
            => a.Equals(b);


        public static bool operator !=(Vec2f a, Vec2f b) 
            => !(a == b);


        public override int GetHashCode() 
            => Item0.GetHashCode() * 397 ^ this.Item1.GetHashCode();

        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public float Item0;

        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public float Item1;
    }
}