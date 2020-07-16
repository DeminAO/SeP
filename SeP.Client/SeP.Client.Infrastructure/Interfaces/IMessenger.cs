using SeP.Client.Infrastructure.Enums;

namespace SeP.Client.Infrastructure.Interfaces
{
	public interface IMessenger
	{
		MessengerTypes MessengerType { get; }
		string AuthorityViewName { get; }
		bool Authorize(params object[] authParams);
	}
}
