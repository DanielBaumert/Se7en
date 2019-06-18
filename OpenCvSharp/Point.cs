using System;

namespace Se7en.OpenCvSharp
{
    [Serializable]
    public struct Point : IEquatable<Point>
    {
        
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(double x, double y)
        {
            X = (int)x;
            Y = (int)y;
        }


        /// <summary>
        /// Specifies whether this object contains the same members as the specified Object.
        /// </summary>
        /// <param name="obj">The Object to test.</param>
        /// <returns>This method returns true if obj is the same type as this object and has the same members as this object.</returns>
        public bool Equals(Point obj) => X == obj.X && Y == obj.Y;

        /// <summary>
        /// Compares two Point objects. The result specifies whether the values of the X and Y properties of the two Point objects are equal.
        /// </summary>
        /// <param name="lhs">A Point to compare.</param>
        /// <param name="rhs">A Point to compare.</param>
        /// <returns>This operator returns true if the X and Y values of left and right are equal; otherwise, false.</returns>
        public static bool operator ==(Point lhs, Point rhs) => lhs.Equals(rhs);

        /// <summary>
        /// Compares two Point objects. The result specifies whether the values of the X or Y properties of the two Point objects are unequal.
        /// </summary>
        /// <param name="lhs">A Point to compare.</param>
        /// <param name="rhs">A Point to compare.</param>
        /// <returns>This operator returns true if the values of either the X properties or the Y properties of left and right differ; otherwise, false.</returns>
        public static bool operator !=(Point lhs, Point rhs) => !lhs.Equals(rhs);

        /// <summary>
        /// Unary plus operator
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public static Point operator +(Point pt) => pt;

        /// <summary>
        /// Unary minus operator
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public static Point operator -(Point pt) => new Point(-pt.X, -pt.Y);

        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static Point operator +(Point p1, Point p2) => new Point(p1.X + p2.X, p1.Y + p2.Y);

        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static Point operator -(Point p1, Point p2) => new Point(p1.X - p2.X, p1.Y - p2.Y);

        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="pt"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public static Point operator *(Point pt, double scale) => new Point((int)((double)pt.X * scale), (int)((double)pt.Y * scale));

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
        public override int GetHashCode() => X.GetHashCode() ^ Y.GetHashCode();

        /// <summary>
        /// Converts this object to a human readable string.
        /// </summary>
        /// <returns>A string that represents this object.</returns>
        public override string ToString() => string.Format("(x:{0} y:{1})", X, Y);

        /// <summary>
        /// Returns the distance between the specified two points
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static double Distance(Point p1, Point p2) => System.Math.Sqrt(System.Math.Pow((double)(p2.X - p1.X), 2.0) + System.Math.Pow((double)(p2.Y - p1.Y), 2.0));

        /// <summary>
        /// Returns the distance between the specified two points
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public double DistanceTo(Point p) => Distance(this, p);

        /// <summary>
        /// Calculates the dot product of two 2D vectors.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static double DotProduct(Point p1, Point p2) => (double)(p1.X * p2.X + p1.Y * p2.Y);

        /// <summary>
        /// Calculates the dot product of two 2D vectors.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public double DotProduct(Point p) => DotProduct(this, p);

        /// <summary>
        /// Calculates the cross product of two 2D vectors.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static double CrossProduct(Point p1, Point p2) => (double)(p1.X * p2.Y - p2.X * p1.Y);

        /// <summary>
        /// Calculates the cross product of two 2D vectors.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public double CrossProduct(Point p) => CrossProduct(this, p);

        public int X;
        public int Y;
        public const int SizeOf = 8;
    }
}
