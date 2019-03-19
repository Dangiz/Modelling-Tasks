using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandValTasks
{
    public class PuassonStreamSequenceGenerator
    {
        public PuassonStreamSequenceGenerator(Random random, double lambda)
        {
            this.random = random;
            Lambda = lambda;
            lastTImeMoment = 0;
        }

        public PuassonStreamSequenceGenerator(double lambda)
        {
            Lambda = lambda;
            random = new Random();
            lastTImeMoment = 0;
        }

        private Random random { get; set; }
        public double Lambda { get; set; }
        private double lastTImeMoment { get; set; }

        public double GetNextTimeMoment()
        {
            lastTImeMoment-= 1 / Lambda * Math.Log(random.NextDouble());
            return lastTImeMoment;
        }


    }
}
