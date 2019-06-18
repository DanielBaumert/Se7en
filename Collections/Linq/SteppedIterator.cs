using System.Collections.Generic;

namespace Se7en.Collections.Linq {

    public class SteppedIterator {

        public static IEnumerable<int> Create(int startIndex, int endIndex, int stepSize) {
            for (int i = startIndex; i < endIndex; i = i + stepSize) {
                yield return i;
            }
        }
    }
}