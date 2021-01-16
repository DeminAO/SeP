using Prism.Ioc;
using Prism.Modularity;
using SeP.Client.Infrastructure.Constants;
using SeP.Client.Infrastructure.Interfaces;
using SeP.Client.Messengers.VK.Authority.Models;
using SeP.Client.Messengers.VK.Authority.ViewModels;
using SeP.Client.Messengers.VK.Authority.Views;

namespace SeP.Client.Messengers.VkMessenger
{
	[Module(ModuleName = ModuleNames.VkMessengerModule)]
	[ModuleDependency(ModuleNames.MessengerCollectionServiceModule)]
	public class VkModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{
			// регистрацич сервиса в коллекции мессенджеров

			var svc = containerProvider.Resolve<IMessengerCollectionService>();
			var messenger = containerProvider.Resolve<IVkMessenger>();
			svc.RegisterMessenger(messenger);
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterSingleton<IVkMessenger, Vk>();
			containerRegistry.RegisterForNavigation<VkAuthority>(ViewNames.VkAuthority);
			
		}
	}
}