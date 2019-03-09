 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandValTasks
{
    public class Bombardment
    {
        public Bombardment(int ammoAmount, double targetWidth, double targetLength, double lengthStandartDeviation, double widthStandartDeviation, Random random)
        {
            AmmoAmount = ammoAmount;
            TargetWidth = targetWidth;
            TargetLength = targetLength;
            LengthStandartDeviation = lengthStandartDeviation;
            WidthStandartDeviation = widthStandartDeviation;
            Random = random;
        }

        public int AmmoAmount { get; set; }
        public double TargetWidth { get; set; }
        public double TargetLength { get; set; }
        public double LengthStandartDeviation { get; set; }
        public double WidthStandartDeviation { get; set; }
        private Random Random { get; set; }

        public int BombsDropping()
        {
            var randomX = new NormallyDistributedRandom(Random, WidthStandartDeviation);
            var randomY = new NormallyDistributedRandom(Random, LengthStandartDeviation);
            int hits = 0;
            for(int i=0;i<AmmoAmount; i++)
            {
                var BombHitPointX = randomX.GetNormallyDistributedDouble();
                var BombHitPointY = randomY.GetNormallyDistributedDouble();
                if (Math.Abs(BombHitPointX) < TargetWidth / 2 && Math.Abs(BombHitPointY) < TargetLength / 2)
                    hits++;
            }
            return hits;
        }

    }
}
