using System;

namespace Se7en.OpenCvSharp
{
    [Serializable]
    public struct LineSegmentPoint : IEquatable<LineSegmentPoint>
    {
        /// <summary>
        /// 1st Point
        /// </summary>
        public Point P1;

        /// <summary>
        /// 2nd Point
        /// </summary>
        public Point P2;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="p1">1st Point</param>
        /// <param name="p2">2nd Point</param>
        public LineSegmentPoint(Point p1, Point p2)
        {
            P1 = p1;
            P2 = p2;
        }

        /// <summary>
        /// Calculates a intersection of the specified two lines
        /// </summary>
        /// <param name="line1"></param>
        /// <param name="line2"></param>
        /// <returns></returns>
        public static Point? LineIntersection(LineSegmentPoint line1, LineSegmentPoint line2)
        {
            int x = line1.P1.X;
            int y = line1.P1.Y;
            int f = line1.P2.X - line1.P1.X;
            int g = line1.P2.Y - line1.P1.Y;
            int x2 = line2.P1.X;
            int y2 = line2.P1.Y;
            int f2 = line2.P2.X - line2.P1.X;
            int g2 = line2.P2.Y - line2.P1.Y;
            double det = (double)(f2 * g - f * g2);
            if (det == 0.0)
            {
                return null;
            }
            int dx = x2 - x;
            int dy = y2 - y;
            double t = (double)(f2 * dy - g2 * dx) / det;
            double num = (double)(f * dy - g * dx) / det;
            return new Point?(new Point
            {
                X = (int)System.Math.Round((double)x + (double)f * t),
                Y = (int)System.Math.Round((double)y + (double)g * t)
            });
        }

        /// <summary>
        /// Calculates a intersection of the specified two lines
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public Point? LineIntersection(LineSegmentPoint line) => LineIntersection(this, line);
        /// <summary>
        /// Calculates a intersection of the specified two segments
        /// </summary>
        /// <param name="seg1"></param>
        /// <param name="seg2"></param>
        /// <returns></returns>
        public static Point? SegmentIntersection(LineSegmentPoint seg1, LineSegmentPoint seg2)
        {
            if (IntersectedSegments(seg1, seg2))
            {
                return LineIntersection(seg1, seg2);
            }
            return null;
        }
        /// <summary>
        /// Calculates a intersection of the specified two segments
        /// </summary>
        /// <param name="seg"></param>
        /// <returns></returns>
        public Point? SegmentIntersection(LineSegmentPoint seg) => SegmentIntersection(this, seg);

        /// <summary>
        /// Returns a boolean value indicating whether the specified two segments intersect.
        /// </summary>
        /// <param name="seg1"></param>
        /// <param name="seg2"></param>
        /// <returns></returns>
        public static bool IntersectedSegments(LineSegmentPoint seg1, LineSegmentPoint seg2)
        {
            Point p = seg1.P1;
            Point p2 = seg1.P2;
            Point p3 = seg2.P1;
            Point p4 = seg2.P2;

            if (p.X >= p2.X)
            {
                if ((p.X < p3.X && p.X < p4.X) || (p2.X > p3.X && p2.X > p4.X))
                {
                    return false;
                }
            }
            else if ((p2.X < p3.X && p2.X < p4.X) || (p.X > p3.X && p.X > p4.X))
            {
                return false;
            }
            if (p.Y >= p2.Y)
            {
                if ((p.Y < p3.Y && p.Y < p4.Y) || (p2.Y > p3.Y && p2.Y > p4.Y))
                {
                    return false;
                }
            }
            else if ((p2.Y < p3.Y && p2.Y < p4.Y) || (p.Y > p3.Y && p.Y > p4.Y))
            {
                return false;
            }

            return checked(
                (
                    unchecked(checked(p.X - p2.X)) * unchecked((long)(checked(p3.Y - p.Y))) +
                    unchecked(checked(p.Y - p2.Y)) * unchecked((long)(checked(p.X - p3.X)))
                ) * (
                    unchecked(checked(p.X - p2.X)) * unchecked((long)(checked(p4.Y - p.Y))) +
                    unchecked(checked(p.Y - p2.Y)) * unchecked((long)(checked(p.X - p4.X)))
                ) <= 0L
                &&
                (
                    unchecked(checked(p3.X - p4.X)) * unchecked((long)(checked(p.Y - p3.Y))) +
                    unchecked(checked(p3.Y - p4.Y)) * unchecked((long)(checked(p3.X - p.X)))
                ) * (
                    unchecked(checked(p3.X - p4.X)) * unchecked((long)(checked(p2.Y - p3.Y))) +
                    unchecked(checked(p3.Y - p4.Y)) * unchecked((long)(checked(p3.X - p2.X)))
                ) <= 0L);
        }



        /// <summary>
        /// Returns a boolean value indicating whether the specified two segments intersect.
        /// </summary>
        /// <param name="seg"></param>
        /// <returns></returns>
        public bool IntersectedSegments(LineSegmentPoint seg) => IntersectedSegments(this, seg);

        /// <summary>
        /// Returns a boolean value indicating whether a line and a segment intersect.
        /// </summary>
        /// <param name="line">Line</param>
        /// <param name="seg">Segment</param>
        /// <returns></returns>
                public static bool IntersectedLineAndSegment(LineSegmentPoint line, LineSegmentPoint seg)
        {
            Point p = line.P1;
            Point p2 = line.P2;
            Point p3 = seg.P1;
            Point p4 = seg.P2;
            return  (
                        (p.X - p2.X) * (long)(p3.Y - p.Y)  + (p.Y - p2.Y) * (long)(p.X - p3.X)
                    ) * (
                        (p.X - p2.X) * (long)(p4.Y - p.Y)  + (p.Y - p2.Y) * (long)(p.X - p4.X)
                    ) <= 0L;
        }
        /// <summary>
        /// Calculates a intersection of a line and a segment
        /// </summary>
        /// <param name="line"></param>
        /// <param name="seg"></param>
        /// <returns></returns>
        public static Point? LineAndSegmentIntersection(LineSegmentPoint line, LineSegmentPoint seg)
        {
            if (IntersectedLineAndSegment(line, seg))
            {
                return LineIntersection(line, seg);
            }
            return null;
        }
        public double Length() => P1.DistanceTo(P2);

        /// <summary>
		/// Translates the Point by the specified amount. 
		/// </summary>
		/// <param name="x">The amount to offset the x-coordinate. </param>
		/// <param name="y">The amount to offset the y-coordinate. </param>
		/// <returns></returns>
        public void Offset(int x, int y)
        {
            P1.X += x;
            P1.Y += y;
            P2.X += x;
            P2.Y += y;
        }
        /// <summary>
		/// Translates the Point by the specified amount. 
		/// </summary>
		/// <param name="p">The Point used offset this CvPoint.</param>
		/// <returns></returns>
        public void Offset(Point p) => Offset(p.X, p.Y);
        public bool Equals(LineSegmentPoint other) => P1 == other.P1 && P2 == other.P2;

        /// <summary>
        /// Compares two CvPoint objects. The result specifies whether the members of each object are equal.
        /// </summary>
        /// <param name="lhs">A Point to compare.</param>
        /// <param name="rhs">A Point to compare.</param>
        /// <returns>This operator returns true if the members of left and right are equal; otherwise, false.</returns>
        public static bool operator ==(LineSegmentPoint lhs, LineSegmentPoint rhs) => lhs.Equals(rhs);
        /// <summary>
        /// Compares two CvPoint objects. The result specifies whether the members of each object are unequal.
        /// </summary>
        /// <param name="lhs">A Point to compare.</param>
        /// <param name="rhs">A Point to compare.</param>
        /// <returns>This operator returns true if the members of left and right are unequal; otherwise, false.</returns>
        public static bool operator !=(LineSegmentPoint lhs, LineSegmentPoint rhs) => !lhs.Equals(rhs);
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
        public override int GetHashCode() => P1.GetHashCode() + P2.GetHashCode();
        public override string ToString() => $"CvLineSegmentPoint (P1:{P1} P2:{P2})";
    }
}