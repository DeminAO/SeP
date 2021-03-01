using Integrazie.Client.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Integrazie.Client.ViewModels
{
	public class LoginPageViewModel : BaseViewModel
	{
		public Command LoginCommand { get; }

		public LoginPageViewModel()
		{
			LoginCommand = new Command(OnLoginClicked);
		}

		private async void OnLoginClicked(object obj)
		{
			// Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
			await navigation.NavigateAsync(nameof(AboutPage));
		}
	}
}
