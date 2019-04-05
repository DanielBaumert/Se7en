using Se7en.Collections;

namespace Se7en.AI
{ 
   public class AiNetworker
   {

        MemoryList<float> ConnectionValue;
        MemoryList<Connector> Connections;


        public AiNetworker()
        {
            ConnectionValue = new MemoryList<float>();
            Connections = new MemoryList<Connector>();
        }

        public unsafe void Push(float[] input, float[] output)
        {




        }

        public void AddInput(int inputs, int outputs)
        {

        }

   }
}
