using Prism.Ioc;
using Prism.Modularity;

namespace SeP.Client.Cross.Modules.Telegram
{
	public class TgModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{
			
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.Register<ITgRepository, TgRepository>();
		}
	}
}
