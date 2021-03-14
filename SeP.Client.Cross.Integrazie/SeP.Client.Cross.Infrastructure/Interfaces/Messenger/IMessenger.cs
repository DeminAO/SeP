using SeP.Client.Cross.Infrastructure.Models.ResultCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeP.Client.Cross.Infrastructure.Interfaces
{
	public interface IMessenger
	{
		Task<Result<ICollection<IDialog>>> GetDialogsAsync();
		Task<Result<ILogInResponse>> LogInAsync(ILogInRequest logInRequest);
	}
}
