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
            Bombardment bombardment = new Bombardment(6,60,150,60,30, new Random());
            int hits = 0;
            for (int i = 0; i < 1000; i++)
                hits += bombardment.BombsDropping();
            Console.WriteLine($"{hits}/6000");
        }
    }
}
