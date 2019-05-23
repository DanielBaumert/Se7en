﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Se7en.AI {
    public class InputSynapse : ISynapse {
        internal INeuron _toNeuron;

        public double Weight { get; set; }
        public double Output { get; set; }
        public double PreviousWeight { get; set; }

        public InputSynapse(INeuron toNeuron) {
            _toNeuron = toNeuron;
            Weight = 1;
        }

        public InputSynapse(INeuron toNeuron, double output) {
            _toNeuron = toNeuron;
            Output = output;
            Weight = 1;
            PreviousWeight = 1;
        }

        public double GetOutput() => Output;

        public bool IsFromNeuron(Guid fromNeuronId) => false;

        public void UpdateWeight(double learningRate, double delta) => throw new InvalidOperationException("It is not allowed to call this method on Input Connecion");
    }
}
