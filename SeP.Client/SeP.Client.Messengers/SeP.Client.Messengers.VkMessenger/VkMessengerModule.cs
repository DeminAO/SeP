using Prism.Ioc;
using Prism.Modularity;
using SeP.Client.Infrastructure.Constants;
using SeP.Client.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeP.Client.Messengers.VkMessenger
{
	[Module(ModuleName = ModuleNames.VkMessengerModule)]
	[ModuleDependency(ModuleNames.MessengerCollectionServiceModule)]
	public class VkMessengerModule : IModule
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
			containerRegistry.RegisterSingleton<IVkMessenger, VkMessenger>();
		}
	}
}
