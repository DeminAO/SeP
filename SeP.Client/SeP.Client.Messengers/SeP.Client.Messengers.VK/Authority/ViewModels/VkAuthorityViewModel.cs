using Citrina;
using Prism.Commands;
using SeP.Client.Infrastructure.Base.ViewModels;
using SeP.Client.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SeP.Client.Messengers.VK.Authority.ViewModels
{
	public class VkAuthorityViewModel : BaseViewModel, IAuthorityModel
	{
		private readonly IMessengerCollectionService messengerService;

		private readonly int appId = 7462896;
		private readonly string defRedirect = "https://oauth.vk.com/blank.html";
		private readonly UserPermissions permissions = UserPermissions.Friends | UserPermissions.Wall;
		private readonly string ebalaHash = "ACpKVGe2nBuHhz9PWmux";

		private readonly CitrinaClient client = new CitrinaClient();
		private UserAccessToken token;

		private Uri authUrl;
		public Uri AuthUrl
		{
			get => authUrl;
			set
			{
				SetProperty(ref authUrl, value);
				OnAuthUrlChanged();
			}
		}

		public ICommand AuthCommand { get; private set; }

		public VkAuthorityViewModel(IMessengerCollectionService messengerService)
		{
			this.messengerService = messengerService;

			AuthCommand = new DelegateCommand(() => OnAuthCommandAsync());

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

			AuthUrl = new Uri(codeLink);
		}
		private void OnAuthUrlChanged()
		{
			var url = AuthUrl.AbsoluteUri;
			
			if (string.IsNullOrEmpty(url)) return;

			// todo: вынести в отдельный метод
			var parameters = url
				.Split(new char[] { '#', '?' })
				.SelectMany(x => 
					x.Split('&')
					.Select(y => 
						y.Split('=')
					)
				)
				.Where(x => x.Count() == 2)
				.Select(x => KeyValuePair.Create(x[0], x[1]));

			var code = parameters.FirstOrDefault(x => x.Key == "code").Value;
			if (string.IsNullOrEmpty(code)) return;

			InitAccount(code);
		}

		private async Task InitAccount(string code)
		{
			var call = await client.AuthHelper.GetAccessTokenAsync(
				appId,
				ebalaHash,
				defRedirect,
				code
			);

			var accessToken = call.AccessToken;

			token = new UserAccessToken(
				value: accessToken.Value,
				expiresIn: 3600,
				userId: ((UserAccessToken)call.AccessToken).UserId,
				appId: appId // accessToken.ApplicationId
			);

		}

		private async Task OnAuthCommandAsync()
		{
			try
			{
				
				var request = await client.Wall.Get(token, ownerId: 7654321, count: 5);

				if (request.IsError)
					throw new Exception(request.Error.Message);

				var posts = request.Response.Items;
				var postsObtainedCount = request.Response.Count;
				
			}
			catch (Exception e)
			{
				throw e;
			}
		}
	}
}
