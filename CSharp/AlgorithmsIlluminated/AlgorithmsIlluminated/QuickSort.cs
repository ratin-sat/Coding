using System;

namespace AlgorithmsIlluminated
{
    public static class QuickSort
    {
        // Input: array A of n distinct integers, and a function of choosing pivot element
        // Postcondition: elements of A are sorted from smallest to largest
        // Output: number of comparisons
        public static int Solve(int[] a, Func<int[], int, int, int> choosePivot)
        {
            return QuickSortAndCount(a, 0, a.Length - 1, choosePivot, 0);
        }

        // Use the first element as the pivot
        public static int FirstElement(int[] a, int l, int r)
        {
            return l;
        }

        // Use the last element as the pivot
        public static int LastElement(int[] a, int l, int r)
        {
            return r;
        }

        private static Random Random { get; } = new Random();

        // Use a random element as the pivot
        public static int RandomElement(int[] a, int l, int r)
        {
            return Random.Next(l, r + 1);
        }

        // Consider the first, middle, and final elements,
        //   then return the median of these elements as the pivot
        public static int MedianOfThreeElements(int[] a, int l, int r)
        {
            var m = (l + r) / 2;
            var x = a[l];
            var y = a[m];
            var z = a[r];

            if (x < y)
            {
                return x < z ? (y < z ?  m : r ) : l;
            }

            return x > z ? (y > z ? m : r ): l;
        }

        // Input: array A of n distinct integers, left and right endpoints l, r ε {1, 2, ..., n} with l <= r
        // Postcondition: elements of the subarray A[l], A[l+1], ..., A[r] are sorted from smallest to largest
        // Output: number of comparisons
        private static int QuickSortAndCount(int[] a, int l, int r, Func<int[], int, int, int> choosePivot, int count)
        {
            if (l >= r)
            {
                return count;
            }

            var p = choosePivot(a, l, r);
            Swap(a, l, p);
            p = Partition(a, l, r);
            var count1 = QuickSortAndCount(a, l, p - 1, choosePivot, p - l);
            var count2 = QuickSortAndCount(a, p + 1, r, choosePivot, r - p);

            return count + count1 + count2;
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
