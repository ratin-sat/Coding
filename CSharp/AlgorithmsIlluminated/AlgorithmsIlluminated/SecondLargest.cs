using System;

namespace AlgorithmsIlluminated
{
    public static class SecondLargest
    {
        // Input: unsorted array a of n distinct integers
        // Output: second-largest interger in the array
        // Assumption: n is a power of 2
        // Restriction: use at most n + log(n) - 2 comparisons
        public static int Solve(int[] a)
        {
            // consider computing the largest number using a knockout tournament
            // we store the winner at the first element and record all losers it has beaten in each round
            // the second-largest number will be one of the losers in the record

            // knockout tournament uses n - 1 comparisons
            var record = KnockoutTournament(a);
            // looking for second-largest in record uses log(n) - 1 comparisons
            var second = record[1];
            for (var i = 2; i < record.Length; i++)
            {
                second = Math.Max(second, record[i]);
            }

            return second;
        }

        // Input: unsorted array a of n distinct integers
        // Output: array with winner stored at the first element and all losers it has beaten in each round
        private static int[] KnockoutTournament(int[] a)
        {
            var n = a.Length;

            // base case
            if (n == 1)
            {
                return a;
            }

            // recursive step
            var m = n / 2;
            var h1 = new int[m];
            var h2 = new int[m];
            Array.Copy(a, 0, h1, 0, m);
            Array.Copy(a, m, h2, 0, m);

            var r1 = KnockoutTournament(h1);
            var r2 = KnockoutTournament(h2);

            // knockout of the log(n)-th round
            return Knockout(r1, r2);
        }

        // Input: two records of length n with the winner stored at the first element
        // Output: array of length n + 1 with the winner's record
        private static int[] Knockout(int[] r1, int[] r2)
        {
            var n = r1.Length;
            var record = new int[n + 1];
            var loser = Math.Min(r1[0], r2[0]);
            // copy winner's record and add loser of this round to the record
            var wr = r1[0] > r2[0] ? r1 : r2;
            Array.Copy(wr, 0, record, 0, n);
            record[n] = loser;

            return record;
        }
    }
}
