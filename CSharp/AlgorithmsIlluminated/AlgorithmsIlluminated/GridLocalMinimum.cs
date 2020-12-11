namespace AlgorithmsIlluminated
{
    public static class GridLocalMinimum
    {
        // Input: n-by-n grid of distinct numbers
        // Output: a local minimum - a number smaller than all its neighbors -
        //   (A neighbor of a number is one immediately above, below, to the left, or to the right)
        // Restriction: use only O(n) comparisons between pairs of numbers
        public static int Solve(int[,] g)
        {
            return BinarySearchLocalMinimum(g, 0, g.GetLength(0) - 1);
        }

        // Input: n-by-n grid of distinct numbers
        //   zero-index row indices ri, rj ε {0, 1, 2, ..., n-1} with ri <= rj
        // Output: a local minimum
        private static int BinarySearchLocalMinimum(int[,] g, int ri, int rj)
        {
            // base case
            if (ri >= rj)
            {
                return RowMin(g, ri).value;
            }

            // find the minimum index c and value min of mid-row rm
            var rm = (ri + rj) / 2;
            (var c, var min) = RowMin(g, rm);

            var ltTop = rm <= 0 ? true : min < g[rm - 1, c];
            var ltBot = rm >= g.GetLength(0) - 1 ? true : min < g[rm + 1, c];

            // min is a local minimum if it was less than top and bottom neighbor
            if (ltTop && ltBot)
            {
                return min;
            }

            // recursively call on the top part if min was greater than top neighbor
            if (!ltTop)
            {
                return BinarySearchLocalMinimum(g, ri, rm - 1);
            }

            // recursively call on the bottom part
            return BinarySearchLocalMinimum(g, rm + 1, rj);
        }

        // Input: n-by-n grid of distinct numbers
        //   zero-index row index r ε {0, 1, 2, ..., n-1}
        // Output: index and value of minimum of row r
        private static (int index, int value) RowMin(int[,] g, int r)
        {
            var mi = 0;
            var min = g[r, 0];
            var n = g.GetLength(1);
            for (var i = 1; i < n; i++)
            {
                if (g[r, i] < min)
                {
                    mi = i;
                    min = g[r, i];
                }
            }

            return (mi, min);
        }
    }
}
