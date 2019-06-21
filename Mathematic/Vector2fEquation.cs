using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Se7en.Mathematic {
    public struct Vector2fEquation {

        public readonly Vector2f PositionVector;
        public readonly Vector2f DirectionVector;

        public Vector2fEquation(Vector2f positionvector, Vector2f directionvector) {
            PositionVector = positionvector;
            DirectionVector = directionvector;
        }



    }
}
