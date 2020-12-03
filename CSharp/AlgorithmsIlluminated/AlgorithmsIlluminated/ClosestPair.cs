using System;
using System.Linq;
using AlgorithmsIlluminated.DataModel;

namespace AlgorithmsIlluminated
{
    public static class ClosestPair
    {
        // Input: n >= 2 points p1 = (x1, y1), ..., pn = (xn, yn) in the plane
        // Output: The pair pi, pj of points with smallest Euclidean distance d(pi, pj)
        public static (Point2D, Point2D) Solve(Point2D[] p)
        {
            // points sorted by x-coordinate
            var px = p.OrderBy(pi => pi.X).ToArray();
            // points sorted by y-coordinate
            var py = p.OrderBy(pi => pi.Y).ToArray();

            return ClosestPairDAC(px, py);
        }

        // Input: two copies Px and Py of n >= 2 points in the plane,
        //   sorted by x- and y-coordinate, respectively
        // Output: the pair pi, pj of distinct points with smallest Euclidean distance between them
        private static (Point2D, Point2D) ClosestPairDAC(Point2D[] px, Point2D[] py)
        {
            var n = px.Length;

            // base cases
            if (n == 2)
            {
                return (px[0], px[1]);
            }
            if (n == 3)
            {
                return ClosestPairFromThreePairs((px[0], px[1]), (px[0], px[2]), (px[1], px[2]));
            }

            var m = n / 2;
            // lx, rx = first and second halves of px sorted by x-coordinate
            var lx = px.Take(m).ToArray();
            var rx = px.Skip(m).ToArray();
            // lx, rx = first and second halves of py sorted by y-coordinate
            var ly = py.Where(p => p.X < px[m].X).ToArray();
            var ry = py.Where(p => p.X >= px[m].X).ToArray();

            // compute best left pair and best right pair recursively
            var lpair = ClosestPairDAC(lx, ly);
            var rpair = ClosestPairDAC(rx, ry);
            // compute best split pair
            var dl = DistanceSquare(lpair);
            var dr = DistanceSquare(rpair);
            var dSquare = Math.Min(dl, dr);
            (var hasSplitPair, var spair) = ClosestSplitPair(px, py, dSquare);

            if (!hasSplitPair)
            {
                return dl < dr ? lpair : rpair;
            }

            // return best of lpair, rpair, spair
            var ds = DistanceSquare(spair);
            return dl < dr ? (dl < ds ? lpair : spair) : (dr < ds ? rpair : spair);
        }

        // Input: two copies Px and Py of n >= 2 points in the plane,
        //   sorted by x- and y- coordinate, and a parameter d
        // Output: the closest pair, provided it is a split pair
        private static (bool, (Point2D, Point2D)) ClosestSplitPair(Point2D[] px, Point2D[] py, double dSquare)
        {
            // xbar = largest x-coordinate in left half
            var xbar = px[px.Length / 2].X;
            var d = Math.Sqrt(dSquare);
            // Sy = points with x-coordinate between xbar - d and xbar + d, sorted by y-coordinate
            var sy = py.Where(p => p.X >= xbar - d && p.X <= xbar + d).ToArray();

            var best = dSquare;
            var hasSplitPair = false;
            var bestPair = (new Point2D(), new Point2D());
            for (var i = 0; i < sy.Length - 1; i++)
            {
                for (var j = 1; j < Math.Min(7, sy.Length - i); j++)
                {
                    var candidate = DistanceSquare((sy[i], sy[i + j]));
                    if (candidate < best)
                    {
                        best = candidate;
                        bestPair = (sy[i], sy[i + j]);
                        hasSplitPair = true;
                    }
                }
            }

            return (hasSplitPair, bestPair);
        }

        // Return the closest pair out of 3 candidates pair1, pair2, pair3
        private static (Point2D, Point2D) ClosestPairFromThreePairs(
            (Point2D, Point2D) pair1,
            (Point2D, Point2D) pair2,
            (Point2D, Point2D) pair3)
        {
            var d1 = DistanceSquare(pair1);
            var d2 = DistanceSquare(pair2);
            var d3 = DistanceSquare(pair3);

            return d1 < d2 ? (d1 < d3 ? pair1 : pair3) : (d2 < d3 ? pair2 : pair3);
        }

        // Compute squared Euclidean distance of pair of points p1 and p2
        private static double DistanceSquare((Point2D p1, Point2D p2) pair)
        {
            var dx = pair.p1.X - pair.p2.X;
            var dy = pair.p1.Y - pair.p2.Y;
            return (dx * dx) + (dy * dy);
        }
    }
}
