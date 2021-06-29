using Prism.Ioc;
using Prism.Modularity;
using CrossMessenger.Client.Modules.Telegram.Authorization;

namespace CrossMessenger.Client.Modules.Telegram
{
	public class TgModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.Register<ITgRepository, TgRepository>();
			containerRegistry.RegisterForNavigation<InputCode>(nameof(InputCode));
			containerRegistry.RegisterForNavigation<InputPhone>(nameof(InputPhone));
		}
	}
}
