using OpenTl.Schema;
using SeP.Client.Cross.Infrastructure.Models.ResultCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SeP.Client.Cross.Modules.Telegram.Models
{
	class TgDialogService : SeP.Client.Cross.Infrastructure.Interfaces.IDialog
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public Func<Task<Result<ICollection<Infrastructure.Interfaces.IMessage>>>> GetAsync { get; set; }

		public Func<Infrastructure.Interfaces.IMessage, Task<Result>> SendAsync { get; set; }

		public Func<Infrastructure.Interfaces.IMessage, Task<Result>> DeleteAsync { get; set; }
	}
}