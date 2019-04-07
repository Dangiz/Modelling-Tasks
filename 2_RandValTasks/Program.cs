using System;
using System.Collections.Generic;
using QueuingSystemStructs;

namespace RandValTasks
{
	class Program
    {
        static void Main(string[] args)
		{
			var eqnueueTimeGenerator = new PuassonStreamSequenceGenerator(2);
			var timeToCompleteGenerator = new PuassonStreamSequenceGenerator(0.5);
			var queue = new Queue<Task>();

			for(int i=0;i<1000;i++)
			{
				queue.Enqueue(new Task() { EnqueueTimeMoment = eqnueueTimeGenerator.GetNextTimeMoment(), TimeToComplete = timeToCompleteGenerator.GetNextInterval() });
			}

			var queueingSystem = new QueuingSystem(queue);
			queueingSystem.Execute(true);
			Console.WriteLine(queueingSystem.Log);
		}

		private static void Phone()
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
		}

		private static void BombsAway()
        {
            Bombardment bombardment = new Bombardment(6, 60, 150, 60, 30, new Random());
            int testCount = 1000;
            int hits = 0;
            for (int i = 0; i < testCount; i++)
                hits += bombardment.BombsDropping();
            Console.WriteLine((double)hits/testCount);
        }
    }
}
