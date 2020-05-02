using Prism.Commands;
using SeP.Client.Infrastructure.Base;
using SeP.Client.Infrastructure.Base.ViewModels;
using SeP.Client.Infrastructure.Constants;
using SeP.Client.SignUp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SeP.Client.SignUp.ViewModels
{
	public class SignUpViewModel : BaseViewModel
	{

		private string login;
		public string Login
		{
			get => login;
			set => SetProperty(ref login, value);
		}

		private string initials;
		public string Initials
		{
			get => initials;
			set => SetProperty(ref initials, value);
		}

		private string password;
		public string Password
		{
			get => password;
			set => SetProperty(ref password, value);
		}
		
		private string confirmPassword;
		public string ConfirmPassword
		{
			get => confirmPassword;
			set => SetProperty(ref confirmPassword, value);
		}

		public ICommand NavigateToLogInCommand { get; private set; }
		public ICommand SignUpCommand { get; private set; }

		public SignUpViewModel()
		{
			SignUpCommand = new DelegateCommand(() => OnSignUpCommand());
			NavigateToLogInCommand = new DelegateCommand(() => OnNavigateToLogInCommand());
		}

		private async Task OnSignUpCommand()
		{
			try
			{
				if (
					string.IsNullOrWhiteSpace(Login)
					||
					string.IsNullOrWhiteSpace(Password)
					||
					string.IsNullOrWhiteSpace(ConfirmPassword)
					||
					ConfirmPassword != Password
					||
					string.IsNullOrWhiteSpace(Initials)
				) return;

				var result = await Service.SignInAsync(Login, Password, Initials);

				if (!result.IsSuccess)
				{
					ProxyDialog.ShowInfo(result.Error);
					return;
				}

				RegionManager.RequestNavigate(RegionNames.MainRegion, ViewNames.SignIn);
			}
			catch (Exception e)
			{
				ProxyDialog.ShowInfo(e.Message);
			}
		}

		private void OnNavigateToLogInCommand()
		{
			RegionManager.RequestNavigate(RegionNames.MainRegion, ViewNames.SignIn);
		}

	}
}
