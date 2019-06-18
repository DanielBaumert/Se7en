using System;

namespace Se7en.OpenCvSharp {

    [Serializable]
    public struct LineSegmentPolar : IEquatable<LineSegmentPolar> {

        /// <summary>
		/// Length of the line
		/// </summary>
        public float Rho;

        /// <summary>
        /// Angle of the line (radian)
        /// </summary>
        public float Theta;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="rho">Length of the line</param>
        /// <param name="theta">Angle of the line (radian)</param>
        public LineSegmentPolar(float rho, float theta) {
            Rho = rho;
            Theta = theta;
        }

        /// <summary>
        /// Specifies whether this object contains the same members as the specified Object.
        /// </summary>
        /// <param name="obj">The Object to test.</param>
        /// <returns>This method returns true if obj is the same type as this object and has the same members as this object.</returns>
        public bool Equals(LineSegmentPolar obj) => Rho == obj.Rho && Theta == obj.Theta;

        /// <summary>
        /// Compares two CvPoint objects. The result specifies whether the members of each object are equal.
        /// </summary>
        /// <param name="lhs">A Point to compare.</param>
        /// <param name="rhs">A Point to compare.</param>
        /// <returns>This operator returns true if the members of left and right are equal; otherwise, false.</returns>
        public static bool operator ==(LineSegmentPolar lhs, LineSegmentPolar rhs) {
            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Compares two CvPoint objects. The result specifies whether the members of each object are unequal.
        /// </summary>
        /// <param name="lhs">A Point to compare.</param>
        /// <param name="rhs">A Point to compare.</param>
        /// <returns>This operator returns true if the members of left and right are unequal; otherwise, false.</returns>
        public static bool operator !=(LineSegmentPolar lhs, LineSegmentPolar rhs) {
            return !lhs.Equals(rhs);
        }

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
        public override int GetHashCode() => Rho.GetHashCode() + Theta.GetHashCode();

        /// <summary>
        /// Calculates a intersection of the specified two lines
        /// </summary>
        /// <param name="line1"></param>
        /// <param name="line2"></param>
        /// <returns></returns>
        public static Point? LineIntersection(LineSegmentPolar line1, LineSegmentPolar line2) {
            LineSegmentPoint line3 = line1.ToSegmentPoint(5000.0);
            LineSegmentPoint seg2 = line2.ToSegmentPoint(5000.0);
            return LineSegmentPoint.LineIntersection(line3, seg2);
        }

        /// <summary>
        /// Calculates a intersection of the specified two lines
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public Point? LineIntersection(LineSegmentPolar line) => LineIntersection(this, line);

        /// <summary>
        /// CvLineSegmentPoint
        /// </summary>
        /// <param name="scale"></param>
        /// <returns></returns>
        public LineSegmentPoint ToSegmentPoint(double scale) {
            double cos = System.Math.Cos(Theta);
            double sin = System.Math.Sin(Theta);
            double x0 = cos * Rho;
            double y0 = sin * Rho;
            Point p3 = new Point {
                X = (int)System.Math.Round(x0 + scale * -sin),
                Y = (int)System.Math.Round(y0 + scale * cos)
            };
            Point p2 = new Point {
                X = (int)System.Math.Round(x0 - scale * -sin),
                Y = (int)System.Math.Round(y0 - scale * cos)
            };
            return new LineSegmentPoint(p3, p2);
        }

        /// <summary>
        /// Convert to a line segment with the specified x-coordinate as both ends
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <returns></returns>
        public LineSegmentPoint ToSegmentPointX(int x1, int x2) {
            if (x1 > x2) {
                throw new ArgumentOutOfRangeException();
            }
            int? y = YPosOfLine(x1);
            int? y2 = YPosOfLine(x2);
            if (y == null || y2 == null) {
                throw new Exception();
            }
            Point p3 = new Point(x1, y.Value);
            Point p2 = new Point(x2, y2.Value);
            return new LineSegmentPoint(p3, p2);
        }

        /// <summary>
        /// Convert to a line segment that uses specified y coordinates as both ends
        /// </summary>
        /// <param name="y1"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        public LineSegmentPoint ToSegmentPointY(int y1, int y2) {
            if (y1 > y2) {
                throw new ArgumentOutOfRangeException();
            }
            int? x = XPosOfLine(y1);
            int? x2 = XPosOfLine(y2);
            if (x == null || x2 == null) {
                throw new Exception();
            }
            Point p3 = new Point(x.Value, y1);
            Point p2 = new Point(x2.Value, y2);
            return new LineSegmentPoint(p3, p2);
        }

        /// <summary>
        /// Find the x-coordinate when passing the specified y-coordinate
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        public int? XPosOfLine(int y) {
            LineSegmentPolar axis = new LineSegmentPolar((float)y, 1.57079637f);
            Point? node = LineIntersection(axis);
            if (node != null) {
                return new int?(node.Value.X);
            }
            return null;
        }

        /// <summary>
        /// Find the y-coordinate when passing through the specified x-coordinate
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int? YPosOfLine(int x) {
            LineSegmentPolar axis = new LineSegmentPolar((float)x, 0f);
            Point? node = LineIntersection(axis);
            if (node != null) {
                return new int?(node.Value.Y);
            }
            return null;
        }

        public override string ToString() => $"CvLineSegmentPolar (Rho:{Rho} Theta:{Theta})";
    }
}