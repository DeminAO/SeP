using Prism.Commands;
using SeP.Client.Auth.Services;
using SeP.Client.Infrastructure.Base;
using SeP.Client.Infrastructure.Base.ViewModels;
using SeP.Client.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SeP.Client.Auth.ViewModels
{
	public class AuthViewModel : BaseViewModel
	{
		private string login;
		public string Login
		{
			get => login;
			set => SetProperty(ref login, value);
		}

		private string password;
		public string Password
		{
			get => password;
			set => SetProperty(ref password, value);
		}

		public ICommand LogInCommand { get; private set; }
		public ICommand NavigateToSignUpCommand { get; private set; }

		public AuthViewModel()
		{
			LogInCommand = new DelegateCommand(() => OnLogInCommand());
			NavigateToSignUpCommand = new DelegateCommand(OnNavigateToSignUpCommand);
		}

		private void OnNavigateToSignUpCommand()
		{
			RegionManager.RequestNavigate(RegionNames.MainRegion, ViewNames.SignUp);
		}

		private async Task OnLogInCommand()
		{
			try
			{
				if (
					string.IsNullOrWhiteSpace(Login)
					||
					string.IsNullOrWhiteSpace(Password)
				) return;

				var result = await Service.SignInAsync(Login, Password);

				if (!result.IsSuccess)
				{
					ProxyDialog.ShowInfo(result.Error);
					return;
				}

				RegionManager.RequestNavigate(RegionNames.LeftRegion, ViewNames.Correspondences);
			}
			catch (Exception e)
			{
				ProxyDialog.ShowInfo(e.Message);
			}
		}
	}
}
