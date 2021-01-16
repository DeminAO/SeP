using Prism.Ioc;
using Prism.Modularity;
using SeP.Client.Infrastructure.Interfaces;
using System;

namespace SeP.Client.Services.MessengerCollectionService
{
	public class MessengerCollectionServiceModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{

		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterSingleton<IMessengerCollectionService, MessengerCollectionService>();
		}
	}
}
