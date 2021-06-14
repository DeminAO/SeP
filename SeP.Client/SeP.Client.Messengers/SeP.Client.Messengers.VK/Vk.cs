using Citrina;
using Models;
using SeP.Client.Infrastructure.Constants;
using SeP.Client.Infrastructure.Enums;
using SeP.Client.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeP.Client.Messengers.VkMessenger
{
	public class Vk : IVkMessenger
	{
		private readonly UserPermissions permissions =
			UserPermissions.Friends 
			| UserPermissions.Wall 
			// | UserPermissions.Messages
			| UserPermissions.Notifications
			| UserPermissions.Notify
			;

		private readonly string _hash = "ACpKVGe2nBuHhz9PWmux";

		private readonly CitrinaClient client = new CitrinaClient();
		private UserAccessToken token;

		private readonly int appId = 7462896;

		private readonly string defRedirect = "https://oauth.vk.com/blank.html";

		public MessengerTypes MessengerType { get; } = MessengerTypes.VK;
		public string AuthorityViewName { get; } = ViewNames.VkAuthority;
		private Uri authUrl;

		public Vk()
		{
			InitAuthUrl();
		}

		private void InitAuthUrl()
		{
			var codeLink = client.AuthHelper.GenerateLink(
				LinkType.Code,
				appId,
				defRedirect,
				DisplayOptions.Default,
				permissions,
				"some message"
			);

			authUrl = new Uri(codeLink);
		}

		public async Task<bool> Authorize(params object[] authParams)
		{
			if (!(authParams?.FirstOrDefault() is string code))
			{
				return false;
			}

			var call = await client.AuthHelper.GetAccessTokenAsync(
				   appId,
				   _hash,
				   defRedirect,
				   code
			   );

			var accessToken = call.AccessToken;

			token = new UserAccessToken(
				value: accessToken.Value,
				expiresIn: 3600,
				userId: ((UserAccessToken)call.AccessToken).UserId,
				appId: accessToken.ApplicationId
			);

			return true;
		}

		public Uri GetAuthUri() => authUrl;

		public async Task<IEnumerable<DialogData>> GetDialogs()
		{
			var result = await client.Messages.GetDialogs(token);
			if (result.IsError)
			{
				return Enumerable.Empty<DialogData>();
			}

			return result.Response.Items.Select(x => new DialogData
			{
				Title = x.Message.Title,
				ShortMessage = x.Message.Body,
				DateTime = x.Message.Date
			});
		}
	}
}
