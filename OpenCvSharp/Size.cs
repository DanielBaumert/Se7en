using System;

namespace Se7en.OpenCvSharp {

    [Serializable]
    public struct Size : IEquatable<Size> {

        /// <param name="width"></param>
        /// <param name="height"></param>
        public Size(int width, int height) {
            Width = width;
            Height = height;
        }

        /// <param name="width"></param>
        /// <param name="height"></param>
        public Size(double width, double height) {
            Width = (int)width;
            Height = (int)height;
        }

        public static Size Zero => default;

        /// <summary>
        /// Specifies whether this object contains the same members as the specified Object.
        /// </summary>
        /// <param name="obj">The Object to test.</param>
        /// <returns>This method returns true if obj is the same type as this object and has the same members as this object.</returns>
        public bool Equals(Size obj) => Width == obj.Width && Height == obj.Height;

        /// <summary>
        /// Compares two CvPoint objects. The result specifies whether the members of each object are equal.
        /// </summary>
        /// <param name="lhs">A Point to compare.</param>
        /// <param name="rhs">A Point to compare.</param>
        /// <returns>This operator returns true if the members of left and right are equal; otherwise, false.</returns>
        public static bool operator ==(Size lhs, Size rhs) => lhs.Equals(rhs);

        /// <summary>
        /// Compares two CvPoint objects. The result specifies whether the members of each object are unequal.
        /// </summary>
        /// <param name="lhs">A Point to compare.</param>
        /// <param name="rhs">A Point to compare.</param>
        /// <returns>This operator returns true if the members of left and right are unequal; otherwise, false.</returns>
        public static bool operator !=(Size lhs, Size rhs) => !lhs.Equals(rhs);

        /// <summary>
        /// Specifies whether this object contains the same members as the specified Object.
        /// </summary>
        /// <param name="obj">The Object to test.</param>
        /// <returns>This method returns true if obj is the same type as this object and has the same members as this object.</returns>
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        /// Returns a hash code for this object.
        /// </summary>
        /// <returns>An integer value that specifies a hash value for this object.</returns>
        public override int GetHashCode() => Width.GetHashCode() ^ Height.GetHashCode();

        /// <summary>
        /// Converts this object to a human readable string.
        /// </summary>
        /// <returns>A string that represents this object.</returns>
        public override string ToString() => string.Format("(width:{0} height:{1})", Width, Height);

        public int Width;
        public int Height;
    }
}