namespace AlgorithmsIlluminated
{
    public static class HasIdenticalIndexValue
    {
        // Input: sorted (from smallest to largest) array A of n distinct integers
        // Output: true if there is an index i such that A[i] = i, otherwise false
        public static bool Solve(int[] a)
        {
            // find index that A[i] == i in sorted array using binary search
            return IdenticalIndexBinarySearch(a, 0, a.Length - 1);
        }

        // Input: sorted (from smallest to largest) array A of n distinct integers,
        //   left and right endpoints l, r ε {1, 2, ..., n} with l <= r
        // Output: true if there is an index i such that A[i] = i, otherwise false
        private static bool IdenticalIndexBinarySearch(int[] a, int l, int r)
        {
            if (l >= r)
            {
                return l == a[l];
            }

            var m = (l + r) / 2;

            if (m < a[m])
            {
                return IdenticalIndexBinarySearch(a, l, m - 1);
            }

            if (m > a[m])
            {
                return IdenticalIndexBinarySearch(a, m + 1, r);
            }

            return true;
        }
    }
}
