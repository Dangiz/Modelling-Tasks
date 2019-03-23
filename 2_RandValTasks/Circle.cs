using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandValTasks
{
    /// <summary>
    /// Represents a circle class model
    /// </summary>
    public class Circle
    {
        public RandPoint Center { get; set; }
        public double Radius { get => radius; set { if (value > 0) radius = value; else throw new ArgumentException("Circle radius cannot be less then zero"); } }

        double radius;

        public Circle(double x,double y,double r)
        {
            Center = new RandPoint(x, y);
            Radius = r;
        }

        /// <summary>
        /// Calculating intersection area of two circles by monte-carlo method
        /// </summary>
        /// <param name="a">Circle a</param>
        /// <param name="b">Circle b</param>
        /// <param name="count">Count of random point</param>
        /// <returns>Area value</returns>
        public static double CaclCircleIntersectionArea(Circle a,Circle b,int count=100000)
        {
            if (RandPoint.GetDistance(a.Center, b.Center) >= a.Radius + b.Radius)
                return 0;

            var left = Math.Max(a.Center.X - a.Radius, b.Center.X - b.Radius);
            var right = Math.Min(a.Center.X + a.Radius, b.Center.X + b.Radius);
            var up = Math.Min(a.Center.Y + a.Radius, b.Center.Y + b.Radius);
            var down = Math.Max(a.Center.Y - a.Radius, b.Center.Y - b.Radius);

            var rectArea = (right - left) * (up - down);
            int intersectionHitCount = 0;
            Random random = new Random();

            for (int i=0;i<count;i++)
            {
                var tempPoint = GetRectangleRandomPoint(left, up, right, down,random);
                if (RandPoint.GetDistance(tempPoint, a.Center) <= a.Radius && RandPoint.GetDistance(tempPoint, b.Center) <= b.Radius)
                    intersectionHitCount++;
            }
            return (double)intersectionHitCount/count*rectArea;
        }

        private static RandPoint GetRectangleRandomPoint(double left,double up,double right,double down,Random random)
        {
            
            return new RandPoint(left + random.NextDouble() * (right - left), down + random.NextDouble() * (up - down));
        }
    }
}
