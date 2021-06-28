using Prism.Ioc;
using Prism.Modularity;
using CrossMessenger.Client.Modules.Telegram.Models;

namespace CrossMessenger.Client.Modules.Telegram
{
	public class TgModule : IModule
	{
		public async void OnInitialized(IContainerProvider containerProvider)
		{
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.Register<ITgRepository, TgRepository>();
		}
	}
}
