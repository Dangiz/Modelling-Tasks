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
            DateTime startMoment=new DateTime(2019,3,19,21,35,00);
            var generator=new PuassonStreamSequenceGenerator(1);
            for (int i = 0; i < 1000; i++)
            {
                startMoment=startMoment.AddMinutes(generator.GetNextTimeMoment());
                Console.WriteLine(startMoment);
            }
        }

        private static void BombsAway()
        {
            Bombardment bombardment = new Bombardment(6, 60, 150, 60, 30, new Random());
            int hits = 0;
            for (int i = 0; i < 1000; i++)
                hits += bombardment.BombsDropping();
            Console.WriteLine($"{hits}/6000");
        }
    }
}
