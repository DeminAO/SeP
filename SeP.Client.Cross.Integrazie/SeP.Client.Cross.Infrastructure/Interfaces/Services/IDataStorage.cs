using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrossMessenger.Client.Infrastructure.Interfaces.Services
{
	public interface IDataStorage
	{
		Task<IEnumerable<T>> GetItems<T>() where T : new();
		Task PutItems<T>(IEnumerable<T> items);
	}
}