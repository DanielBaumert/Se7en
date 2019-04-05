using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Se7en.Collections.Linq
{
    public class SteppedIterator
    {
        public static IEnumerable<int> Create(int startIndex, int endIndex, int stepSize)
        {
            for (int i = startIndex; i < endIndex; i = i + stepSize)
            {
                yield return i;
            }
        }
    }
}
