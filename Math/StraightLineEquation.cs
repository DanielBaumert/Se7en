using System;

namespace Se7en.Math {
    public struct StraightLineEquation  {

        private readonly float Slop;
        private readonly float Shift;

        public StraightLineEquation(int slop, int shift) {
            Slop = slop;
            Shift = shift;
        }
        public StraightLineEquation(Vector2f p1, Vector2f p2) {
            if (p1.X == p2.X)
                throw new ArgumentException($"p1.x - p2.x == 0");

            Vector2f delta = p2 - p1;

            Slop = delta.Y / delta.X;
            Shift = p1.Y - Slop * p1.X;
        }

        public StraightLineEquation(Vector2f p1, float x, float y)
            : this(p1.X, p1.Y, x, y) { }
        public StraightLineEquation(float x, float y, Vector2f p2)
            : this(x, y, p2.X, p2.Y) { }
        public StraightLineEquation(float xVal1, float yVal1, float xVal2, float yVal2) {
            if (xVal1 == xVal2)
                throw new ArgumentException($"xstart != xEnd");

            float dx = xVal1 - xVal2;
            float dy = yVal1 - yVal2;

            Slop = dy / dx;
            Shift = yVal1 - Slop * xVal1;
        }

        public float GetValue(int x) => Slop * x + Shift;

    }
}
