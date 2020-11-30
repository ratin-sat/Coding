using System;

namespace AlgorithmsIlluminated
{
    public static class Karatsuba
    {
        // Input: two positive integers x and y
        // Output: the product xy
        public static string Solve(string x, string y)
        {
            // base case
            if (x.Length == 1 && y.Length == 1)
            {
                // compute xy in one step and return the result
                return OneStepMult(x, y);
            }

            // recursive case
            // divide x and y into first half of length n - m and second half of length m
            var n = Math.Max(x.Length, y.Length);
            var m = (n + 1) / 2;
            // a, b = first and second halves of x
            (var a, var b) = Divide(x, m);
            // c, d = first and second halves of y
            (var c, var d) = Divide(y, m);
            // p = a + b
            var p = GradeSchoolAdd(a, b);
            // q = c + d
            var q = GradeSchoolAdd(c, d);

            // recursively compute the product of ac, bd, pq
            var ac = Solve(a, c);
            var bd = Solve(b, d);
            var pq = Solve(p, q);

            // adbc = pq - ac - bd;
            var adbc = GradeSchoolSubtract(GradeSchoolSubtract(pq, ac), bd);
            // xy = 10^(2m) * ac + 10^(m) * adbc + bd
            var xy = GradeSchoolAdd(GradeSchoolAdd(ac + new string('0', 2 * m), adbc + new string('0', m)), bd);

            return RemoveLeadingZeros(xy);
        }

        // Input: positive number x of length n
        // Output: first half of length n - m and second half of length m of x
        private static (string, string) Divide(string x, int m)
        {
            if (x.Length <= m)
            {
                return ("0", x);
            }

            var p = x.Length - m;
            return (x.Substring(0, p), x.Substring(p, m));
        }

        // Input: two single-digit positive integers x and y
        // Output: the product xy
        private static string OneStepMult(string x, string y) => (ValueAt(x, 0) * ValueAt(y, 0)).ToString();

        // Input: two positive integers x and y
        // Output: summation of x and y
        private static string GradeSchoolAdd(string x, string y)
        {
            var n = Math.Max(x.Length, y.Length);
            var buffer = new char[n + 1];
            var carry = 0;
            var i = 0;
            while (i < n)
            {
                var sum = ValueAt(x, i) + ValueAt(y, i) + carry;
                buffer[n - i] = IntToChar(sum % 10);
                carry = sum < 10 ? 0 : 1;
                i++;
            }

            if (carry != 0)
            {
                buffer[n - i] = IntToChar(carry);
                i++;
            }

            return new string(buffer, buffer.Length - i, i);
        }

        // Input: two positive integers x and y
        // Output: subtraction between x and y
        // Assumption: x > y
        private static string GradeSchoolSubtract(string x, string y)
        {
            var n = x.Length;
            var buffer = new char[n];
            var carry = 0;
            var i = 0;
            while (i < n)
            {
                var diff = ValueAt(x, i) - ValueAt(y, i) - carry;
                carry = diff < 0 ? 1 : 0;
                buffer[buffer.Length - i - 1] = IntToChar((diff + 10) % 10);
                i++;
            }

            return new string(buffer, buffer.Length - i, i);
        }

        // Input: numeric string s and zero-based index from right i
        // Output: value of number at i if i is less than length of s, otherwise 0
        private static int ValueAt(string s, int i) => i < s.Length ? CharToInt(s[s.Length - i - 1]) : 0;

        // Remove leading zeros from number x
        private static string RemoveLeadingZeros(string x)
        {
            var i = 0;
            while (i < x.Length && x[i] == '0')
            {
                i++;
            }

            return i == x.Length ? "0" : x.Substring(i, x.Length - i);
        }

        // Convert numeric character c to integer
        private static int CharToInt(char c) => c - '0';

        // Convert single-digit integer i to numeric character
        private static char IntToChar(int i) => (char)(i + '0');
    }
}
