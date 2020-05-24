using Citrina;
using Prism.Commands;
using SeP.Client.Infrastructure.Base.ViewModels;
using SeP.Client.Infrastructure.Interfaces;
using System.Windows.Input;

namespace SeP.Client.Messengers.VK.Authority.ViewModels
{
	public class VkAuthorityViewModel : BaseViewModel, IAuthorityModel
	{
		private string test = "123345";
		public string Test
		{
			get => test;
			set => SetProperty(ref test, value);
		}

		public ICommand AuthCommand { get; private set; }

		public VkAuthorityViewModel()
		{
			AuthCommand = new DelegateCommand(OnAuthCommand);
		}

		private void OnAuthCommand()
		{
			var client = new CitrinaClient();
			var codeLink = client.AuthHelper.GenerateLink(LinkType.Code, 7654321, "http://test.com/account", DisplayOptions.Default, UserPermissions.Audio | UserPermissions.Offline, "some message");
		}
	}
}
