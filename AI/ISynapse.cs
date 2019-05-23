using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Se7en.AI {
    public interface ISynapse {
        double Weight { get; set; }
        double PreviousWeight { get; set; }
        double GetOutput();
        bool IsFromNeuron(Guid fromNeuronId);
        void UpdateWeight(double learningRate, double delta);
    }
}
