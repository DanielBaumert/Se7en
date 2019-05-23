using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Se7en.AI {
    public class WeightedSumFunction : IInputFunction {
        public double CalculateInput(List<ISynapse> inputs) => inputs.Select(x => x.Weight * x.GetOutput()).Sum();
    }
}
