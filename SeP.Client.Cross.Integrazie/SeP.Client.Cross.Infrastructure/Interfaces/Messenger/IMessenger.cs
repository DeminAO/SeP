using CrossMessenger.Client.Infrastructure.Models.ResultCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrossMessenger.Client.Infrastructure.Interfaces
{
	public interface IMessenger
	{
		Task<Result<IEnumerable<IDialog>>> GetAsync();
		Task<Result> RemoveAsync(IDialog dialog);
		Task<Result<IDialog>> AddAsync();
	}
}
