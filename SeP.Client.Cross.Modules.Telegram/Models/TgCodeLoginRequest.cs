using CrossMessenger.Client.Infrastructure.Interfaces;

namespace CrossMessenger.Client.Modules.Telegram.Models
{
	public class TgCodeLoginRequest : ILogInRequest
	{
		public string Code { get; set; }
	}

}
