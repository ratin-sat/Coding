using System;

namespace AlgorithmsIlluminated
{
    public static class DSelect
    {
        // Input: array A of n >= 1 distinct numbers, and an integer i ε {1, 2, ..., n}
        // Output: the ith order statistic of A
        public static int Solve(int[] a, int i)
        {
            return MedianOfMediansSelect(a, i - 1, 0, a.Length - 1);
        }

        // Input: array A of n >= 1 distinct numbers, and a zero-index i ε {0, 1, ..., n-1}
        //   a zero-index i ε {0, 1, ..., n-1},
        //   a zero-index left and right endpoints l, r ε {0, 1, 2, ..., n-1} with l <= r
        // Output: the ith order statistic of A
        private static int MedianOfMediansSelect(int[] a, int i, int l, int r)
        {
            var n = r - l + 1;

            // base case
            if (n == 1)
            {
                return a[l];
            }

            // m = number of groups of 5
            var m = (n + 4) / 5;
            // first-round winners
            var c = new int[m];
            var lh = l;
            for (var h = 0; h < m - 1; h++)
            {
                c[h] = Median5(a, lh, lh + 4);
                lh += 5;
            }
            c[m - 1] = Median5(a, lh, r);

            // median-of-medians
            var p = MedianOfMediansSelect(c, m / 2, 0, m - 1);
            var pi = l;
            while (pi <= r)
            {
                if (a[pi] == p)
                {
                    break;
                }
                pi++;
            }
            // partition A around p
            Swap(a, l, pi);
            pi = Partition(a, l, r);
            // j = p's position in partitioned array
            var j = pi - l;

            if (j == i)
            {
                return p;
            }

            if (j > i)
            {
                // recursively call on the first half
                return MedianOfMediansSelect(a, i, l, pi - 1);
            }

            // recursively call on the second half
            return MedianOfMediansSelect(a, i - j - 1, pi + 1, r);
        }

        // Input: array A of n >= 1 distinct numbers, and a zero-index i ε {0, 1, ..., n-1}
        //   a zero-index left and right endpoints l, r ε {0, 1, 2, ..., n-1} with l <= r
        // Output: median of the subarray A[l], A[l+1], ..., A[r]
        private static int Median5(int[] a, int l, int r)
        {
            var n = r - l + 1;
            var c = new int[n];
            Array.Copy(a, l, c, 0, n);
            Array.Sort(c);
            return c[n / 2];
        }

        // Input: array A of n distinct integers, left and right endpoints l, r ε {0, 1, 2, ..., n-1} with l <= r
        // Postcondition: elements of the subarray A[l], A[l+1], ..., A[r] are partitioned around A[l]
        // Output: final position of pivot element
        private static int Partition(int[] a, int l, int r)
        {
            var pivot = a[l];
            var i = l + 1;
            for (var j = l + 1; j <= r; j++)
            {
                if (a[j] < pivot)
                {
                    Swap(a, i, j);
                    i++;
                }
            }

            Swap(a, l, i - 1);
            return i - 1;
        }

        // Swap the values between A[i] and A[j]
        private static void Swap(int[] a, int i, int j)
        {
            var tmp = a[i];
            a[i] = a[j];
            a[j] = tmp;
        }
    }
}
