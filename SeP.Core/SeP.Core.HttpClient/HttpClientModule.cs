using Prism.Ioc;
using Prism.Modularity;
using SeP.Core.Interfaces;

namespace SeP.Core.HttpClientService
{
	class HttpClientModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{
			// throw new System.NotImplementedException();
		}

		public void RegisterTypes(IContainerRegistry container)
		{
			container.Register<IHttpClientService, HttpClientService>();
		}
	}
}
