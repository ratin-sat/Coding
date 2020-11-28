using System;
using AlgorithmsIlluminated.DataModel;

namespace AlgorithmsIlluminated
{
    public static class ClosestPair
    {
        // Input: n >= 2 points p1 = (x1, y1), ..., pn = (xn, yn) in the plane
        // Output: The pair pi, pj of points with smallest Euclidean distance d(pi, pj)
        public static Tuple<Point2D, Point2D> Solve(Point2D[] p)
        {
            return new Tuple<Point2D, Point2D>(new Point2D(), new Point2D());
        }
    }
}
