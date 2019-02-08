using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingCourseTasks
{
    public class DifferentialEquationsNumericalSolver
    {
        public static Dictionary<double,double> SolveFirstOrderDE(Func<double,double,double> f,double x0,double t0,double h,double N)
        {
            Dictionary<double,double> result=new Dictionary<double, double>();
            for (int i = 0; i < N; i++)
            {
                result.Add(t0, x0);
                x0 = x0 + h * f(x0, t0);
                t0 += h;
            }
            result.Add(t0, x0);
            return result;
        }
    }
}
