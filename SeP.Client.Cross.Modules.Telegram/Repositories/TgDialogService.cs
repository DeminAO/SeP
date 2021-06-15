using OpenTl.Schema;
using CrossMessenger.Client.Infrastructure.Models.ResultCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CrossMessenger.Client.Infrastructure.Interfaces;

namespace CrossMessenger.Client.Modules.Telegram.Models
{
	class TgDialogService : Infrastructure.Interfaces.IDialog
	{
		public IIdentifier Identifier { get; set; }
		public Task<Result> DeleteAsync(Infrastructure.Interfaces.IMessage message)
		{
			throw new NotImplementedException();
		}

		public Task<Result<ICollection<Infrastructure.Interfaces.IMessage>>> GetAsync()
		{
			throw new NotImplementedException();
		}
	}
}