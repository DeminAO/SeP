using CrossMessenger.Client.Infrastructure.Models.ResultCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenTl.Schema;
using CrossMessenger.Client.Modules.Telegram.Models;

namespace CrossMessenger.Client.Modules.Telegram
{
	public class TgRepository : ITgRepository
	{
		public async Task<Result<IEnumerable<Infrastructure.Interfaces.IDialog>>> GetAsync()
		{
			try
			{
				var _clientApi = await new TgClientRepository().GetClient();
				var contacts = await _clientApi.ContactsService.GetContactsAsync();
				return Result<IEnumerable<Infrastructure.Interfaces.IDialog>>
					.GetSucceed(
						contacts.Contacts
						.Join(contacts.Users.OfType<TUser>(), x => x.UserId, x => x.Id, (c, u) => (c, u))
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

	}
}