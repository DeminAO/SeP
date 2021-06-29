using CrossMessenger.Client.Infrastructure.Models.ResultCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrossMessenger.Client.Infrastructure.Interfaces
{
	public interface IDialog
	{
		IIdentifier Identifier { get; }
		Task<Result<ICollection<IMessage>>> GetAsync();
	}
}
