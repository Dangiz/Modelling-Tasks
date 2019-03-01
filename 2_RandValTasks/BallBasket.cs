using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandValTasks
{
    public enum BallColor { White,Blue,Red }
    public class BallBasket
    {
        private Random random = new Random();
        public BallColor GetBall()
        {
            var temp = random.Next(0, 3);
            switch (temp)
            {
                case 0:
                    return BallColor.White;
                case 1:
                    return BallColor.Blue;
                case 2:
                    return BallColor.Red;
                default: throw new Exception("Some error occured");
            }
        }

        public double BallCombinationTest(BallColor[] combination,int testCount)
        {
            double successAmount=0;
            for(int i=0;i<testCount;i++)
            {
                int currentSuccessAmount = 0;
                for(int j=0;j<combination.Length;j++)
                {
                    if (combination[j] == GetBall())
                        currentSuccessAmount++;
                    else break;
                }
                if (currentSuccessAmount == combination.Length)
                    successAmount++;
            }
            return successAmount / testCount;
        }
    }
}
