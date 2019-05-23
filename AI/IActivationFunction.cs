using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Se7en.AI {
    public interface IActivationFunction {
        double CalculateOutput(double input);
    }
}
