using System.Collections.Generic;
using AlgorithmsIlluminated.DataStructure;

namespace AlgorithmsIlluminated
{
    public static class MedianMaintenance
    {
        // Input: sequence of numbers s
        // Output: sequence of numbers which each element is the median of all elements you've seen thus far
        public static IEnumerable<int> Solve(IEnumerable<int> s)
        {
            return SolveByHeap(s);
        }

        private static IEnumerable<int> SolveByHeap(IEnumerable<int> s)
        {
            // we will negate FindMin, ExtractMin and Insert of h1
            // to make it behave like a max heap
            var h1 = new Heap<int>();
            // standard min heap h2
            var h2 = new Heap<int>();
            foreach (var x in s)
            {
                var y = h1.Count() > 0 ? -h1.FindMin() : int.MinValue;
                var z = h2.Count() > 0 ? h2.FindMin() : int.MaxValue;

                if (x < y)
                {
                    h1.Insert(-x);
                }
                else
                {
                    h2.Insert(x);
                }

                // rebalance h1 and h2
                if (h1.Count() - h2.Count() >= 2)
                {
                    h2.Insert(-h1.ExtractMin());
                }
                else if (h2.Count() - h1.Count() >= 2)
                {
                    h1.Insert(-h2.ExtractMin());
                }

                yield return h1.Count() >= h2.Count() ? -h1.FindMin() : h2.FindMin();
            }
        }
    }
}
