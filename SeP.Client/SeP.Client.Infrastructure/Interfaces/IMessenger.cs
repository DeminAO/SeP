using Models;
using SeP.Client.Infrastructure.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeP.Client.Infrastructure.Interfaces
{
	public interface IMessenger
	{
		MessengerTypes MessengerType { get; }
		string AuthorityViewName { get; }
		Task<bool> Authorize(params object[] authParams);
		Task<IEnumerable<DialogData>> GetDialogs();
	}
}
