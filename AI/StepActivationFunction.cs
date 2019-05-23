using System;
#pragma warning disable

namespace Se7en.AI {
    public class StepActivationFunction : IActivationFunction {
        private double _treshold;
        public StepActivationFunction(double treshold) => _treshold = treshold;
        public double CalculateOutput(double input) => Convert.ToDouble(input > _treshold);
    }
}
