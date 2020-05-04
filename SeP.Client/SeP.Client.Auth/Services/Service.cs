using SeP.Client.Infrastructure.Services;
using SeP.Core.Proto;
using System.Threading.Tasks;

namespace SeP.Client.Auth.Services
{
	public static class Service
	{
		public static async Task<string> SayHelloAsync(string name)
		{
			var request = new HelloRequest { Name = name };
			var result = await ProxyClient.Invoke(client => client.SayHelloAsync(request));
			return result.Message;
		}

		public static async Task<Infrastructure.Contracts.ReplignDataBase> SignInAsync(string login, string password)
		{
			var request = new SignInRequest 
			{ 
				Login = login, 
				Password = password 
			};

			var result = await ProxyClient.Invoke(client => client.SignInAsync(request));

			return new Infrastructure.Contracts.ReplignDataBase { Error = result.Error, IsSuccess = result.IsSuccessed };
		}
	}
}
