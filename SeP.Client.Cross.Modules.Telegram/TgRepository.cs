using SeP.Client.Cross.Infrastructure.Interfaces;
using SeP.Client.Cross.Infrastructure.Models.ResultCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeP.Client.Cross.Modules.Telegram
{
	using OpenTl.ClientApi.MtProto.Exceptions;
	using OpenTl.Schema;
	using Org.BouncyCastle.Bcpg;
	using SeP.Client.Cross.Modules.Telegram.Models;
	using System.Runtime.CompilerServices;

	public class TgRepository : ITgRepository
	{
		private TUser _user;

		private string phone;

		private OpenTl.Schema.Auth.ISentCode sentCode;

		public async Task<Result<ILogInResponse>> LogInAsync(ILogInRequest logInRequest)
		{
			var _clientApi = await new TgClientRepository().GetClient();

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

		public async Task<Result<IEnumerable<Infrastructure.Interfaces.IDialog>>> GetDialogsAsync()
		{
			var _clientApi = await new TgClientRepository().GetClient();
			try
			{
				var contacts = await _clientApi.ContactsService.GetContactsAsync();
				return Result<IEnumerable<Infrastructure.Interfaces.IDialog>>
					.GetSucceed(
					contacts.Contacts.Join(contacts.Users.OfType<TUser>(), x => x.UserId, x => x.Id, (c, u) => (c, u))
					.Select(x => new TgDialogService
					{
						Id = x.c.UserId,
						Name = x.u.Username,
						DeleteAsync = _ => Task.FromResult(Result.GetFailure("not impl")),
						SendAsync = _ => Task.FromResult(Result.GetFailure("not impl")),
						GetAsync = () => Task.FromResult(Result<ICollection<SeP.Client.Cross.Infrastructure.Interfaces.IMessage>>.GetFailure("not impl"))
					}));
			}
			catch (Exception e)
			{
				return Result<IEnumerable<Infrastructure.Interfaces.IDialog>>
					.GetFailure(e.GetBaseException().Message);
			}
		}
	}
}