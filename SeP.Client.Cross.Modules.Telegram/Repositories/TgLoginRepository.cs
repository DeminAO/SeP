using CrossMessenger.Client.Infrastructure.Interfaces;
using CrossMessenger.Client.Infrastructure.Models.ResultCore;
using CrossMessenger.Client.Modules.Telegram.Models;
using OpenTl.ClientApi.MtProto.Exceptions;
using OpenTl.Schema;
using System;
using System.Threading.Tasks;

namespace CrossMessenger.Client.Modules.Telegram
{
	public class TgLoginRepository : IAuthorizer
	{
		OpenTl.ClientApi.IClientApi _clientApi;

		private string phone;

		private OpenTl.Schema.Auth.ISentCode sentCode;

		public async Task<Result<ILogInResponse>> LogInAsync(ILogInRequest logInRequest)
		{
			_clientApi = await new TgClientRepository().GetClient();

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
					await _clientApi.AuthService.SignInAsync(phone, sentCode, codeRequest.Code).ConfigureAwait(false);

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

		public async Task<Result<ILogOutResponse>> LogOut()
		{
			try
			{
				await _clientApi.AuthService.LogoutAsync();
				return Result<ILogOutResponse>.GetSucceed(new LogoutResult());
			}
			catch (Exception e)
			{
				return Result<ILogOutResponse>.GetFailure(e.GetBaseException().Message);
			}
		}
	}
}