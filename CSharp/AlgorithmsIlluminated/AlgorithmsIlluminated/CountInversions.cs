namespace AlgorithmsIlluminated
{
    public static class CountInversions
    {
        // Input: An array A of distinct integers
        // Output: The number of inversions of A -
        //   The number of pairs (i, j) of array indices with i < j and A[i] > A[j]
        public static long Solve(int[] a)
        {
            return BruteForceCountInv(a);
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
    }
}
