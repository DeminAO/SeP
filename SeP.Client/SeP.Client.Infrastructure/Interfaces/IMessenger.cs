using SeP.Client.Infrastructure.Enums;

namespace SeP.Client.Infrastructure.Interfaces
{
	public interface IMessenger
	{
		MessengerTypes MessengerType { get; }
		bool Authorize(params object[] authParams);
	}
}
