using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelingCourseTasks;
using OxyPlot;
using OxyPlot.Series;

namespace WpfInterface
{
    public class ViewController
    {
        public PlotModel Model { get; private set; }

        private LineSeries PairsToSeries(List<KeyValuePair<double, double>> pairs)
        {
            LineSeries lineSeries = new LineSeries();
            foreach (var pair in pairs)
            {
                lineSeries.Points.Add(new DataPoint(pair.Key, pair.Value));
            }

            return lineSeries;
        }
        public ViewController()
        {

            double a = 20;
            double b = 10;
            Model = new PlotModel();

            for (double x0 = 0; x0 <= a/b*2; x0+=0.2)
            {
                Model.Series.Add(
                PairsToSeries(DifferentialEquationsNumericalSolver.SolveFirstOrderDE((x, t) => a * x - b * x * x, x0, 0, 1, 1000)));
            }
        }
    }
}
