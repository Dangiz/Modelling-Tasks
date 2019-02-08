using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingCourseTasks
{
    public class DifferentialEquationsNumericalSolver
    {
        public static List<KeyValuePair<double,double>> SolveFirstOrderDE(Func<double,double,double> f,double x0,double t0,double tEnd,double N)
        {
            if (tEnd <= t0)
                throw new ArgumentException("tEnd cannot be smaller than t0");
            double h = (tEnd - t0) / N;
            List<KeyValuePair<double, double>> result =new List<KeyValuePair<double, double>>();
            for (int i = 0; i < N; i++)
            {
                result.Add(new KeyValuePair<double,double>(t0, x0));
                x0 = x0 + h * f(x0, t0);
                t0 += h;
            }
            result.Add(new KeyValuePair<double, double>(t0, x0));
            return result;
        }

        public static List<KeyValuePair<double,double>> SolveFirstOrderDESystem(Func<double, double, double, double> f,Func<double,double,double,double> g,double x0,double y0,double t0,double tEnd,double N)
        {
            if (tEnd <= t0)
                throw new ArgumentException("tEnd cannot be smaller than t0");
            double h = (tEnd - t0) / N;
            List<KeyValuePair<double, double>> result = new List<KeyValuePair<double, double>>();
            for (int i = 0; i < N; i++)
            {
                result.Add(new KeyValuePair<double, double>(x0, y0));
                double tempX = x0;
                x0 = x0 + h * f(x0,y0, t0);
                y0 = y0 + h * f(tempX, y0, t0);
                t0 += h;
            }
            result.Add(new KeyValuePair<double, double>(x0, y0));
            return result;
        }
    }
}
