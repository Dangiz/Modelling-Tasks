using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandValTasks
{
    public class NormallyDistributedRandom
    {
        public NormallyDistributedRandom(Random random, double standartDeviation)
        {
            this.random = random;
            StandartDeviation = standartDeviation;
        }

        private Random random { get; set; }
        public double StandartDeviation { get; set; }
        public double GetNormallyDistributedDouble()
        {
            //double result = 0;
            //for (int i = 0; i < 12; i++)
            //    result += random.NextDouble() - 6;
            return StandartDeviation* Math.Cos(2*Math.PI*random.NextDouble())*Math.Sqrt(-2*Math.Log(random.NextDouble()));
        }
    }
}
