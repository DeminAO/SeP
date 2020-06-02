using System.Collections.Generic;

namespace SeP.Client.Infrastructure.Interfaces
{
	public interface IMessengerCollectionService
	{
		List<IMessenger> Messengers { get; }

		void RegisterMessenger(IMessenger messenger);
	}
}
