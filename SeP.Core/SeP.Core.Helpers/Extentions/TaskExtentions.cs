using System;
using System.Threading.Tasks;

namespace SeP.Core.Helpers.Extentions
{
	public static class TaskExtentions
	{
		public static async Task Catch(this Task task, Func<Task> next, Action<Exception> except)
		{
			await task;
			try
			{
				await next();
			}
			catch (Exception e)
			{
				except(e);
			}
		}

		public static async Task Next(this Task task, Action action)
		{
			await task;
			action();
		}
	}
}
