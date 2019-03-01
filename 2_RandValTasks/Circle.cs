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
        Point Center { get; set; }
        public double Radius { get => radius; set { if (value > 0) radius = value; else throw new ArgumentException("Circle radius cannot be less then zero"); } }

        double radius;

        /// <summary>
        /// Calculating intersection area of two circles by monte-carlo method
        /// </summary>
        /// <param name="a">Circle a</param>
        /// <param name="b">Circle b</param>
        /// <returns>Area value</returns>
        public static double CaclCircleIntersectionArea(Circle a,Circle b)
        {

        }
    }
}
