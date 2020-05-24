using SeP.Client.Infrastructure.Enums;
using System.Collections.Generic;

namespace SeP.Client.Infrastructure.Interfaces
{
	public interface IMessengerCollectionService
	{
		List<IMessenger> Messengers { get; }

		void RegisterMessenger(IMessenger messenger);

		void ShowAuthority(MessengerTypes messengerType);
	}
}
