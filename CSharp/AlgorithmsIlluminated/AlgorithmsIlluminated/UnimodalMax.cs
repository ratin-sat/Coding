namespace AlgorithmsIlluminated
{
    public static class UnimodalMax
    {
        // Input: an unimodal array u of n distinct elements -
        //   meaning that its entries are in increasing order up until its maximum element,
        //   after which its elements are in decreasing order
        // Output: maximum element of u
        // Restriction: run in O(log(n)) time
        public static int Solve(int[] u)
        {
            // find maximum element in unimodal array using binary search
            return UnimodalMaxBinarySearch(u, 0, u.Length - 1);
        }

        // Input: an unimodal array u of n distinct elements,
        //   left and right endpoints l, r ε {1, 2, ..., n} with l <= r
        // Output: maximum element of u
        private static int UnimodalMaxBinarySearch(int[] u, int l, int r)
        {
            if (l == r)
            {
                return u[l];
            }

            var m = (l + r) / 2;

            if (u[m] < u[m - 1])
            {
                return UnimodalMaxBinarySearch(u, l, m - 1);
            }

            if (u[m] < u[m + 1])
            {
                return UnimodalMaxBinarySearch(u, m + 1, r);
            }

            return u[m];
        }
    }
}
