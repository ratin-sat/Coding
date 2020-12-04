using System;

namespace AlgorithmsIlluminated
{
    public static class RSelect
    {
        // Input: array A of n >= 1 distinct numbers, and an integer i ε {1, 2, ..., n}
        // Output: the ith order statistic of A
        public static int Solve(int[] a, int i)
        {
            return RandomizedLinearTimeSelect(a, i - 1, 0, a.Length - 1);
        }

        // Input: array A of n >= 1 distinct numbers,
        //   a zero-index i ε {0, 1, ..., n-1},
        //   left and right endpoints l, r ε {1, 2, ..., n} with l <= r
        // Output: the ith order statistic of A
        private static int RandomizedLinearTimeSelect(int[] a, int i, int l, int r)
        {
            // base case
            if (l == r)
            {
                return a[l];
            }

            // partition around a random pivot
            var p = RandomPivot(l, r);
            Swap(a, l, p);
            p = Partition(a, l, r);

            // j = position in partitioned array
            var j = p - l;
            if (j == i)
            {
                // found the ith order statistic of A at l + j
                return a[l + j];
            }
            if (j > i)
            {
                // recursively select the first part of A
                return RandomizedLinearTimeSelect(a, i, l, p - 1);
            }

            // recursively select the second part of A
            return RandomizedLinearTimeSelect(a, i - j - 1, p + 1, r);
        }

        private static Random Random { get; } = new Random();

        // Use a random element as the pivot
        private static int RandomPivot(int l, int r)
        {
            return Random.Next(l, r + 1);
        }

        // Input: array A of n distinct integers, left and right endpoints l, r ε {1, 2, ..., n} with l <= r
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
