using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandValTasks
{
    public struct RandPoint
    {
        public double X, Y;

        public RandPoint(double x, double y)
        {
            X = x;
            Y = y;
        }
        public static double GetDistance(RandPoint a, RandPoint b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }

        
    }
}
