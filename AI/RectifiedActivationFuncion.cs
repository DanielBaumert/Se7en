using System;
namespace Se7en.AI {
    public class RectifiedActivationFuncion : IActivationFunction {
        public double CalculateOutput(double input) => System.Math.Max(0, input);
    }
}
