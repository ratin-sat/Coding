using System;

namespace AlgorithmsIlluminated
{
    public static class CountInversions
    {
        // Input: An array A of distinct integers
        // Output: The number of inversions of A -
        //   The number of pairs (i, j) of array indices with i < j and A[i] > A[j]
        public static long Solve(int[] a)
        {
            (var b, var numInv) = SortAndCountInv(a);
            return numInv;
        }

        // Input: An array A of distinct integers
        // Output: The number of inversions of A
        private static long BruteForceCountInv(int[] a)
        {
            var numInv = 0L;
            for (var i = 0; i < a.Length - 1; i++)
            {
                for (var j = i + 1; j < a.Length; j++)
                {
                    if (a[i] > a[j])
                    {
                        numInv += 1;
                    }
                }
            }

            return numInv;
        }

        // Input: An array A of distinct integers
        // Output: Sorted array B with the same integers, and the number of inversions of A
        private static (int[], long) SortAndCountInv(int[] a)
        {
            var n = a.Length;

            // base case
            if (n <= 1)
            {
                return (a, 0L);
            }

            // recursive case
            var m = n / 2;
            var h1 = new int[m];
            var h2 = new int[n - m];
            Array.Copy(a, 0, h1, 0, h1.Length);
            Array.Copy(a, m, h2, 0, h2.Length);

            (var c, var leftInv) = SortAndCountInv(h1);
            (var d, var rightInv) = SortAndCountInv(h2);
            (var b, var splitInv) = MergeAndCountSplitInv(c, d);

            return (b, leftInv + rightInv + splitInv);
        }

        // Input: Sorted arrays C and D
        // Output: Sorted array B merged from C and D, and the number of split inversions
        private static (int[], long) MergeAndCountSplitInv(int[] c, int[] d)
        {
            var merged = new int[c.Length + d.Length];
            var countInv = 0L;
            var l = 0;
            var r = 0;
            var i = 0;
            while (i < merged.Length)
            {
                if (r >= d.Length || (l < c.Length && c[l] <= d[r]))
                {
                    merged[i++] = c[l++];
                }
                else
                {
                    merged[i++] = d[r++];
                    countInv += c.Length - l;
                }
            }

            return (merged, countInv);
        }
    }
}
