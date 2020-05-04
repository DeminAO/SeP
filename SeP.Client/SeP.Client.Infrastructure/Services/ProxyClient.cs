using System;
using System.Threading.Tasks;

namespace SeP.Client.Infrastructure.Services
{
	public static class ProxyClient
	{
		public static async Task<T> Invoke<T>(Func<Proxy.Client, Task<T>> clientFunc)
		{
			try
			{
				return await clientFunc(new Proxy.Client());
			}
			catch
			{
				throw;
			}
		}
	}
}
