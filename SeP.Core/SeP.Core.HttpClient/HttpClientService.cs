using SeP.Core.Interfaces;
using System.Net.Http;

namespace SeP.Core.HttpClientService
{
	public class HttpClientService: IHttpClientService
	{
		private static HttpClient _client = new HttpClient();
	}
}
