using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Se7en.AI {

    /// <summary>
    /// Factory used to create layers.
    /// </summary>
    public class NeuralLayerFactory {
        public NeuralLayer CreateNeuralLayer(int numberOfNeurons) => CreateNeuralLayer(numberOfNeurons, new SigmoidActivationFunction(Utils.Random.NextDouble()), new WeightedSumFunction());
        public NeuralLayer CreateNeuralLayer(int numberOfNeurons, IActivationFunction activationFunction) => CreateNeuralLayer(numberOfNeurons, activationFunction, new WeightedSumFunction());
        public NeuralLayer CreateNeuralLayer(int numberOfNeurons, IActivationFunction activationFunction, IInputFunction inputFunction) {
            var layer = new NeuralLayer();

            for(int i = 0; i < numberOfNeurons; i++) {
                Neuron neuron = new Neuron(activationFunction, inputFunction);
                layer.Neurons.Add(neuron);
            }

            return layer;
        }
    }
}
