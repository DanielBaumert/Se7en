using System;
#pragma warning disable

namespace Se7en.AI {
    public class SigmoidActivationFunction : IActivationFunction {
        private double _coeficient;

        public SigmoidActivationFunction(double coeficient) => _coeficient = coeficient;

        public double CalculateOutput(double input) => (1 / (1 + System.Math.Exp(-input * _coeficient)));
    }
}
