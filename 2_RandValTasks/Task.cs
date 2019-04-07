using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuingSystemStructs
{
	public struct Task
	{
		string Name { get; set; }
		public double EnqueueTimeMoment { get; set; }
		public double TimeToComplete { get; set; }
		public double CompleteTimeMoment { get; set; }
		public double CommonTimeInQueue { get{ return CompleteTimeMoment - EnqueueTimeMoment; } }
	}
}
