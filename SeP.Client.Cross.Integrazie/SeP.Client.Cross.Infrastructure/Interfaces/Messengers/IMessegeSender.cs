using CrossMessenger.Client.Infrastructure.Models.ResultCore;
using System.Threading.Tasks;

namespace CrossMessenger.Client.Infrastructure.Interfaces
{
	public interface IMessegeSender
	{
		Task<Result> SendAsync(IMessage message);
		Task<Result> DeleteAsync(IMessage message);
	}

}
