using Prism.Ioc;
using Prism.Modularity;
using SeP.Core.Interfaces;

namespace SeP.Core.JsonService
{
	class JsonServiceModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{
			// throw new System.NotImplementedException();
		}

		public void RegisterTypes(IContainerRegistry container)
		{
			container.Register<IJsonService, JsonService>();
		}
	}
}
