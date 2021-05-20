using SeP.Client.Cross.Infrastructure.Interfaces;

namespace SeP.Client.Cross.Modules.Telegram.Models
{
	public class TgPhoneLoginRequest : ILogInRequest
	{
		public string Phone { get; set; }
	}
	
	public class TgCodeLoginRequest : ILogInRequest
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
