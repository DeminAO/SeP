using SeP.Client.Infrastructure.Services;
using System.Threading.Tasks;

namespace SeP.Client.Auth.Services
{
	public static class Service
	{
		public static async Task<string> SayHelloAsync(string name)
			=> await ProxyClient.Invoke(client => client.SayHelloAsync(name));
	}
}
