using SeP.Client.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;
using SeP.Client.Infrastructure.Enums;
using Prism.Regions;
using SeP.Client.Infrastructure.Constants;

namespace SeP.Client.Services.MessengerCollectionService
{
	public class MessengerCollectionService : IMessengerCollectionService
	{
		private readonly IRegionManager regionManager;

		public List<IMessenger> Messengers { get; } = new List<IMessenger>();

		public MessengerCollectionService(IRegionManager regionManager)
		{
			this.regionManager = regionManager;
		}

		public void RegisterMessenger(IMessenger messenger)
		{
			if (Messengers.Any(x => x.GetType().Name == messenger.GetType().Name))
				throw new Exception("Messenger is already exists");

			Messengers.Add(messenger);
		}

		public void ShowAuthority(MessengerTypes messengerType)
		{
			var messenger = Messengers.FirstOrDefault(x => x.MessengerType == messengerType);
			regionManager.RequestNavigate(RegionNames.AuthorityRegion, messenger.AuthorityViewName);
		}
	}
}
