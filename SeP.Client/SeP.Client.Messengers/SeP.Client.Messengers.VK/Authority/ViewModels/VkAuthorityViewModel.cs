using Citrina;
using Prism.Commands;
using SeP.Client.Infrastructure.Base.ViewModels;
using SeP.Client.Infrastructure.Enums;
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
		private readonly IVkMessenger vk;

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

		public VkAuthorityViewModel(IVkMessenger messenger)
		{
			vk = messenger;
			AuthUrl = vk.GetAuthUri();
		}

		private void OnAuthUrlChanged()
		{
			var url = AuthUrl.AbsoluteUri;

			if (string.IsNullOrEmpty(url))
			{
				return;
			}

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
				.Select(x => KeyValuePair.Create(x[0], x[1]))
				.ToList();

			var code = parameters.FirstOrDefault(x => x.Key == "code").Value;
			if (string.IsNullOrEmpty(code))
			{
				return;
			}

			_ = InitAccount(code);
		}

		private async Task InitAccount(string code)
		{
			if(await vk.Authorize(code))
			{
				// var t = await vk.GetDialogs(); 
			}
		}
	}
}
