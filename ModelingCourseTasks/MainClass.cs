using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingCourseTasks
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            BallBasket basket = new BallBasket();
            BallColor[] combo = new BallColor[] { BallColor.White, BallColor.Blue, BallColor.Red };
            Console.WriteLine(basket.BallCombinationTest(combo, 1000000));
        }
    }
}
