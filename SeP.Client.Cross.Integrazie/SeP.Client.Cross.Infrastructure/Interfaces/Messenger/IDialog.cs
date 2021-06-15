using CrossMessenger.Client.Infrastructure.Models.ResultCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrossMessenger.Client.Infrastructure.Interfaces
{
	public interface IDialog
	{
		string Name { get; }
		Task<Result<ICollection<IMessage>>> GetAsync();
		Task<Result> SendAsync(IMessage message);
		Task<Result> DeleteAsync(IMessage message);
	}

}
