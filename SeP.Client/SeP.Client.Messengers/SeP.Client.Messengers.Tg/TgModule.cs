using Prism.Ioc;
using Prism.Modularity;
using SeP.Client.Infrastructure.Constants;
using SeP.Client.Infrastructure.Interfaces;

namespace SeP.Client.Messengers.Tg
{

	[Module(ModuleName = ModuleNames.TgMessengerModule)]
	[ModuleDependency(ModuleNames.MessengerCollectionServiceModule)]
	public class TgModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{
			// регистрацич сервиса в коллекции мессенджеров

			var svc = containerProvider.Resolve<IMessengerCollectionService>();
			var messenger = containerProvider.Resolve<ITgMessenger>();
			svc.RegisterMessenger(messenger);
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterSingleton<ITgMessenger, Tg>();
			// todo: 
			// containerRegistry.RegisterForNavigation<TgAuthority>(ViewNames.TgAuthority);

		}
	}
}
