using SeP.Client.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SeP.Client.Services.MessengerCollectionService
{
	public class MessengerCollectionService : IMessengerCollectionService
	{
		public List<IMessenger> Messengers { get; } = new List<IMessenger>();

		public void RegisterMessenger(IMessenger messenger)
		{
			if (Messengers.Any(x => x.GetType().Name == messenger.GetType().Name))
				throw new Exception("Messenger is already exists");

			Messengers.Add(messenger);
		}
	}
}
