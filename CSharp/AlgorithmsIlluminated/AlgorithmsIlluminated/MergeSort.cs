using System;

namespace AlgorithmsIlluminated
{
    public static class MergeSort
    {
        // Input: array A of n distinct integers
        // Output: array with the same integers, sorted from smallest to largest
        public static int[] Solve(int[] a)
        {
            var n = a.Length;

            // base case
            if (n == 1)
            {
                return a;
            }

            // divide array A into first and second halves
            var m = n / 2;
            var h1 = new int[m];
            var h2 = new int[n - m];
            Array.Copy(a, 0, h1, 0, m);
            Array.Copy(a, m, h2, 0, n - m);

            // recursively sort first half of A
            var c = Solve(h1);
            // recursively sort second half of A
            var d = Solve(h2);

            return Merge(c, d);
        }

        // Input: sorted arrays C and D
        // Output: sorted array B
        private static int[] Merge(int[] c, int[] d)
        {
            var b = new int[c.Length + d.Length];
            var bi = 0;
            var ci = 0;
            var di = 0;
            while (bi < b.Length)
            {
                if (di >= d.Length || (ci < c.Length && c[ci] < d[di]))
                {
                    b[bi++] = c[ci++];
                }
                else
                {
                    b[bi++] = d[di++];
                }
            }

            return b;
        }
    }
}
