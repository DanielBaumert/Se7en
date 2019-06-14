using System;

namespace Se7en.OpenCvSharp
{
    /// <summary>
    /// 4-Tuple of int (System.Int32)
    /// </summary>
        [Serializable]
    public struct Vec4i : IVec<int>, IEquatable<Vec4i>
    {
        /// <summary>
        /// Initializer
        /// </summary>
        public Vec4i(int item0, int item1, int item2, int item3)
        {
           Item0 = item0;
           Item1 = item1;
           Item2 = item2;
           Item3 = item3;
        }

        /// <summary>
        /// Indexer
        /// </summary>
        public int this[int i] {
            get {
                switch (i)
                {
                    case 0:
                        return Item0;
                    case 1:
                        return Item1;
                    case 2:
                        return Item2;
                    case 3:
                        return Item3;
                    default:
                        throw new ArgumentOutOfRangeException("i");
                }
            }
            set {
                switch (i)
                {
                    case 0:
                        Item0 = value;
                        return;
                    case 1:
                        Item1 = value;
                        return;
                    case 2:
                        Item2 = value;
                        return;
                    case 3:
                        Item3 = value;
                        return;
                    default:
                        throw new ArgumentOutOfRangeException("i");
                }
            }
        }

        
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Vec4i other) 
            => Item0 == other.Item0 && Item1 == other.Item1 && Item2 == other.Item2 && Item3 == other.Item3;

        
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj) 
            => obj != null && obj is Vec4i && Equals((Vec4i)obj);

        
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Vec4i a, Vec4i b) 
            => a.Equals(b);

        
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Vec4i a, Vec4i b) 
            => !a.Equals(b);

        
        /// <returns></returns>
        public override int GetHashCode() 
            => ((Item0 * 397 ^ Item1) * 397 ^ Item2) * 397 ^  Item3;

        /// <summary>
        /// The value of the first component of this object.
        /// </summary>
        public int Item0;

        /// <summary>
        /// The value of the second component of this object.
        /// </summary>
        public int Item1;

        /// <summary>
        /// The value of the third component of this object.
        /// </summary>
        public int Item2;

        /// <summary>
        /// The value of the fourth component of this object.
        /// </summary>
        public int Item3;
    }
}