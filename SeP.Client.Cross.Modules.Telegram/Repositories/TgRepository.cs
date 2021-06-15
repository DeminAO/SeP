using CrossMessenger.Client.Infrastructure.Models.ResultCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrossMessenger.Client.Modules.Telegram
{
	using OpenTl.ClientApi.MtProto.Exceptions;
	using OpenTl.Schema;
	using Org.BouncyCastle.Bcpg;
	using CrossMessenger.Client.Modules.Telegram.Models;
	using System.Runtime.CompilerServices;
	public class TgRepository : ITgRepository
	{
		private TUser _user;

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
						Identifier = new TgIdentifier
						{
							Name = x.u.Username,
							Id = x.c.UserId
						}
					}));
			}
			catch (Exception e)
			{
				return Result<IEnumerable<Infrastructure.Interfaces.IDialog>>
					.GetFailure(e.GetBaseException().Message);
			}
		}

		public Task<Result<IEnumerable<Infrastructure.Interfaces.IDialog>>> GetAsync()
		{
			throw new NotImplementedException();
		}

		public Task<Result> RemoveAsync(Infrastructure.Interfaces.IDialog dialog)
		{
			throw new NotImplementedException();
		}

		public Task<Result<Infrastructure.Interfaces.IDialog>> AddAsync()
		{
			throw new NotImplementedException();
		}
	}
}