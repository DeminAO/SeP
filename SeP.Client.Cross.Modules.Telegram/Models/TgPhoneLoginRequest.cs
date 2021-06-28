using CrossMessenger.Client.Infrastructure.Interfaces;

namespace CrossMessenger.Client.Modules.Telegram.Models
{
	public class TgPhoneLoginRequest : ILogInRequest
	{
		public string Phone { get; set; }
	}

	public class WaitCode : ILogInResponse { }

	public class SucceedLogin : ILogInResponse { }

	public class TgIdentifier : IIdentifier
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}

	public class TgCodeLoginRequest : ILogInRequest
	{
		public string Code { get; set; }
	}

}
