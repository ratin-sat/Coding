using System;

namespace AlgorithmsIlluminated.DataModel
{
    public struct Point2D
    {
        public double X { get; }

        public double Y { get; }

        public Point2D(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public override bool Equals(object obj)
        {
            return obj is Point2D p &&
                   Math.Abs(this.X - p.X) <= double.Epsilon &&
                   Math.Abs(this.Y - p.Y) <= double.Epsilon;
        }

        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = (hashCode * -1521134295) + this.X.GetHashCode();
            hashCode = (hashCode * -1521134295) + this.Y.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Point2D left, Point2D right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Point2D left, Point2D right)
        {
            return !(left == right);
        }
    }
}
