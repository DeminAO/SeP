using SeP.Client.Cross.Infrastructure.Models.ResultCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeP.Client.Cross.Infrastructure.Interfaces
{
	public interface IDialog
	{
		Task<Result<ICollection<IMessage>>> GetAsync();
		Task<Result> SendAsync(IMessage message);
		Task<Result> DeleteAsync(IMessage message);
	}

}
