using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandValTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var circleA = new Circle(0,0,1);
            var circleB = new Circle(2, 0, 2);
            Console.WriteLine(Circle.CaclCircleIntersectionArea(circleA, circleB));
        }
    }
}
