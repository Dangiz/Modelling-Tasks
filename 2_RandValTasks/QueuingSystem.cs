using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueuingSystemStructs
{
	public class QueuingSystem
	{
		public Queue<Task> TaskQueue { get; set; }
		public List<Task> TasksCache { get; }
		public StringBuilder Log { get; }

		public QueuingSystem(Queue<Task> taskQueue)
		{
			TaskQueue = taskQueue;
			TasksCache = new List<Task>();
			Log = new StringBuilder();
		}

		public double Execute(bool useAdvancedLogging = false)
		{
			var commonWorkTime = 0.0;

			while (TaskQueue.Count > 0)
			{

				var currentTask = TaskQueue.Dequeue();

				if (currentTask.EnqueueTimeMoment > commonWorkTime)
				{
					commonWorkTime = currentTask.EnqueueTimeMoment;
				}

				commonWorkTime += currentTask.TimeToComplete;
				currentTask.CompleteTimeMoment = commonWorkTime;

				if(useAdvancedLogging)
				{
					Log.AppendLine($"{currentTask.EnqueueTimeMoment:F} {currentTask.TimeToComplete:F} {currentTask.CompleteTimeMoment:F} {currentTask.CommonTimeInQueue:F}");
				}

				TasksCache.Add(currentTask);
			}

			var intervals=CalculateIntervals();
			Log.AppendLine($"~u:{TasksCache.Sum(task => task.CommonTimeInQueue) / TasksCache.Count}");
			Log.AppendLine($"{intervals.Sum(pair => pair.Value.Sum() / commonWorkTime)}");
			return commonWorkTime;
		}

		private Dictionary<int, List<double>> CalculateIntervals()
		{
			var intervalsResult = new Dictionary<int, List<double>>();
			var criticalMoments = new List<double>();
			criticalMoments.AddRange(TasksCache.Select(task => task.EnqueueTimeMoment));
			criticalMoments.AddRange(TasksCache.Select(task => task.CompleteTimeMoment));
			criticalMoments.Sort();

			intervalsResult[0] = new List<double> { criticalMoments[0] };

			for(int i=0;i<criticalMoments.Count-1;i++)
			{
				var currentMoment = criticalMoments[i];
				var nextMoment = criticalMoments[i + 1];
				var currentEnqueueTasksCount = TasksCache.Count(task=>task.EnqueueTimeMoment<=currentMoment && task.CompleteTimeMoment>currentMoment);

				if(!intervalsResult.ContainsKey(currentEnqueueTasksCount))
				{
					intervalsResult[currentEnqueueTasksCount] = new List<double>();
				}

				intervalsResult[currentEnqueueTasksCount].Add(nextMoment - currentMoment);

			}

			return intervalsResult;

		}
	}
}
