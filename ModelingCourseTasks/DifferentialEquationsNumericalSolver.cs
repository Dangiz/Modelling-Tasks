using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandValTasks
{
    public class DifferentialEquationsNumericalSolver
    {
        public static List<Point> SolveFirstOrderDE(Func<double,double,double> f,double x0,double t0,double tEnd,double N)
        {
            if (tEnd <= t0)
                throw new ArgumentException("tEnd cannot be smaller than t0");
            double h = (tEnd - t0) / N;
            List<Point> result =new List<Point>();
            for (int i = 0; i < N; i++)
            {
                result.Add(new Point(t0, x0));
                x0 = x0 + h * f(x0, t0);
                t0 += h;
            }
            result.Add(new Point(t0, x0));
            return result;
        }

        public static List<Point> SolveFirstOrderDESystem(Func<double, double, double, double> f,Func<double,double,double,double> g,double x0,double y0,double t0,double tEnd,double N)
        {
            if (tEnd <= t0)
                throw new ArgumentException("tEnd cannot be smaller than t0");
            double h = (tEnd - t0) / N;
            List<Point> result = new List<Point>();
            for (int i = 0; i < N; i++)
            {
                result.Add(new Point(x0, y0));
                double tempX = x0;
                x0 = x0 + h * f(x0,y0, t0);
                y0 = y0 + h * g(tempX, y0, t0);
                t0 += h;
            }
            result.Add(new Point(x0, y0));
            return result;
        }
    }
}
