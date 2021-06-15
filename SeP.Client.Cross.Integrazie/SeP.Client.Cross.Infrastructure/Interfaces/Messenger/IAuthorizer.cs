using CrossMessenger.Client.Infrastructure.Models.ResultCore;
using System.Threading.Tasks;

namespace CrossMessenger.Client.Infrastructure.Interfaces
{
	public interface IAuthorizer
	{
		Task<Result<ILogOutResponse>> LogOut();
		Task<Result<ILogInResponse>> LogInAsync(ILogInRequest logInRequest);
	}
}
