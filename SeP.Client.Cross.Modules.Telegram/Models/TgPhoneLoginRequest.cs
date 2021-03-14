using SeP.Client.Cross.Infrastructure.Interfaces;

namespace SeP.Client.Cross.Modules.Telegram.Models
{
	public class TgPhoneLoginRequest
	{
		public string Phone { get; set; }
	}
	
	public class TgCodeLoginRequest
	{
		public string Code { get; set; }
	}

	public class WaitCode : ILogInResponse
	{

	}

	public class SucceedLogin : ILogInResponse
	{

	}

}
