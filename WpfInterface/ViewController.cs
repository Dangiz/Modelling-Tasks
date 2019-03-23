using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandValTasks;
using OxyPlot;
using OxyPlot.Series;

namespace WpfInterface
{
    public class ViewController
    {
        public PlotModel Model { get; private set; }

        private LineSeries PointsToSeries(List<Point> points)
        {
            LineSeries lineSeries = new LineSeries();
            foreach (var point in points)
            {
                lineSeries.Points.Add(new DataPoint(point.X, point.Y));
            }

            return lineSeries;
        }

        /// <summary>
        /// 1st task demonstration
        /// </summary>
        private void SetFirstOrderModel()
        {
            double a = 20;
            double b = 10;
            Model = new PlotModel();

            for (double x0 = 0; x0 <= a / b * 2; x0 += 0.2)
            {
                Model.Series.Add(
                PointsToSeries(DifferentialEquationsNumericalSolver.SolveFirstOrderDE((x, t) => a * x - b * x * x, x0, 0, 1, 1000)));
            }
        }

        private ColumnSeries IntervalsToSeries(List<double> intervals)
        {
            var max = intervals.Max();
            var min = intervals.Min();
            var step = (max - min) / 20;
            var hitCountes = new double[40];

            foreach (var interval in intervals)
            {
                hitCountes[(int)(interval / step)]++;
            }

           // hitCountes = hitCountes.Select(count => count / intervals.Count).ToArray();
            var columnSeries = new ColumnSeries();

            foreach (var hitCount in hitCountes)
            {
                columnSeries.Items.Add(new ColumnItem(hitCount));
            }

            return columnSeries;
        }

        private void SetPuassonModel()
        {
            DateTime startMoment = new DateTime(2019, 3, 18, 00, 00, 00);
            DateTime endMoment = new DateTime(2019, 3, 24, 23, 59, 00);
            var generator = new PuassonStreamSequenceGenerator(0.1);
            var intervals = new List<double>();
            while (startMoment < endMoment)
            {
                var interval = generator.GetNextInterval();
                intervals.Add(interval);
                startMoment = startMoment.AddHours(interval);
                Console.WriteLine(startMoment);
            }
            Model.Series.Add(IntervalsToSeries(intervals));
        }

        /// <summary>
        /// 2nd task demonstration
        /// </summary>
        private void SetFirstOrderSystemModel()
        {
            Model = new PlotModel();
            var k = 0.1;
            double B = 10;
            double B2 = 13.4;
            var temp = DifferentialEquationsNumericalSolver.SolveFirstOrderDESystem((x, y, t) => y, (x, y, t) => -k * y - x * x * x + B * Math.Cos(t), 1, 1, 0, 100, 10000);
            var temp2 = DifferentialEquationsNumericalSolver.SolveFirstOrderDESystem((x, y, t) => y, (x, y, t) => -k * y - x * x * x + B2 * Math.Cos(t), 1, 1, 0, 100, 10000);
            Model.Series.Add(PointsToSeries(temp));
            Model.Series.Add(PointsToSeries(temp2));
        }

        public ViewController()
        {
            Model = new PlotModel();
            SetPuassonModel();
        }


    }
}
