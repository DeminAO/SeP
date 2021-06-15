using OpenTl.Schema;
using CrossMessenger.Client.Infrastructure.Models.ResultCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrossMessenger.Client.Modules.Telegram.Models
{
	class TgDialogService : Infrastructure.Interfaces.IDialog
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public Task<Result> DeleteAsync(Infrastructure.Interfaces.IMessage message)
		{
			throw new NotImplementedException();
		}

		public Task<Result<ICollection<Infrastructure.Interfaces.IMessage>>> GetAsync()
		{
			throw new NotImplementedException();
		}

		public Task<Result> SendAsync(Infrastructure.Interfaces.IMessage message)
		{
			throw new NotImplementedException();
		}
	}
}