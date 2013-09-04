using System;
using Tasky.Core.BL;

namespace TaskyiOS
{
	public class TaskClickedEventArgs : EventArgs
	{
		public Task Task { get; set; }

		public TaskClickedEventArgs (Task task) : base ()
		{
			this.Task = task;
		}
	}
}

