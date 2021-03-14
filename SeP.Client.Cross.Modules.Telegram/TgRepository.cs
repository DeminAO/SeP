using SeP.Client.Cross.Infrastructure.Interfaces;
using SeP.Client.Cross.Infrastructure.Models.ResultCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeP.Client.Cross.Modules.Telegram
{
	using OpenTl.ClientApi;
	using OpenTl.ClientApi.MtProto.Exceptions;
	using OpenTl.Schema;
	using Org.BouncyCastle.Bcpg;
	using SeP.Client.Cross.Modules.Telegram.Models;

	public class TgRepository : ITgRepository
	{
		private IClientApi _clientApi;
		private TUser _user;

		private string phone;
		private bool isPhoneSetted => !string.IsNullOrWhiteSpace(phone);

		private string code;
		private bool isCodeSetted => !string.IsNullOrWhiteSpace(code);

		private OpenTl.Schema.Auth.ISentCode sentCode;

		public async Task<Result<ILogInResponse>> LogInAsync(ILogInRequest logInRequest)
		{
			if (logInRequest is TgPhoneLoginRequest request)
			{
				phone = request.Phone;
				sentCode = await _clientApi.AuthService.SendCodeAsync(request.Phone).ConfigureAwait(false);

				return Result<ILogInResponse>.GetSucceed(new WaitCode());
			}

			if (logInRequest is TgCodeLoginRequest codeRequest)
			{
				try
				{
					_user = await _clientApi.AuthService.SignInAsync(phone, sentCode, codeRequest.Code).ConfigureAwait(false);

					_clientApi.UpdatesService.StartReceiveUpdates(TimeSpan.FromSeconds(1));

					return Result<ILogInResponse>.GetSucceed(new SucceedLogin());
				}
				catch (CloudPasswordNeededException pe)
				{
					return Result<ILogInResponse>.GetFailure(pe.Message);
				}
				catch (PhoneCodeInvalidException)
				{
					return Result<ILogInResponse>.GetFailure("uncorrect code");
				}
			}

			return Result<ILogInResponse>.GetFailure("unknown reqest");
		}

		Task<Result<ICollection<Infrastructure.Interfaces.IDialog>>> IMessenger.GetDialogsAsync()
		{
			throw new NotImplementedException();
		}
	}
}