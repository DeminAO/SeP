using SeP.Client.Cross.Infrastructure.Models.ResultCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeP.Client.Cross.Infrastructure.Interfaces
{
	public interface IDialog
	{
		string Name { get; }
		Func<Task<Result<ICollection<IMessage>>>> GetAsync { get; }
		Func<IMessage, Task<Result>> SendAsync { get; }
		Func<IMessage, Task<Result>> DeleteAsync { get; }
	}

}
