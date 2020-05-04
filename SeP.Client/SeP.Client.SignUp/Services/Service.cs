using SeP.Client.Infrastructure.Services;
using SeP.Core.Proto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SeP.Client.SignUp.Services
{
	public static class Service
	{

		public static async Task<Infrastructure.Contracts.SignUpReplignData> SignInAsync(string login, string password, string initials)
		{
			var request = new SignUpRequest
			{
				Login = login,
				Password = password,
				Initials = initials
			};

			var result = await ProxyClient.Invoke(client => client.SignUpAsync(request));

			return new Infrastructure.Contracts.SignUpReplignData 
			{ 
				Error = result.Error, 
				IsSuccess = result.IsSuccessed,
				NewId = result.NewId
			};
		}
	}
}
