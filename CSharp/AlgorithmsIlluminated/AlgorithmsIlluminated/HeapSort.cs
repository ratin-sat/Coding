using AlgorithmsIlluminated.DataStructure;

namespace AlgorithmsIlluminated
{
    public static class HeapSort
    {
        // Input: array A of n distinct integers
        // Output: array with the same integers, sorted from smallest to largest
        public static int[] Solve(int[] a)
        {
            var n = a.Length;
            var b = new int[n];

            var h = new Heap<int>();
            h.Heapify(a);
            for (var i = 0; i < n; i++)
            {
                b[i] = h.ExtractMin();
            }

            return b;
        }
    }
}
