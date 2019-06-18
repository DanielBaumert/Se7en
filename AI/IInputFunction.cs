using System.Collections.Generic;

namespace Se7en.AI {

    public interface IInputFunction {

        double CalculateInput(List<ISynapse> inputs);
    }
}