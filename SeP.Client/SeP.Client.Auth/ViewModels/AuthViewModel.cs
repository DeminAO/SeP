using Prism.Commands;
using SeP.Client.Auth.Services;
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
		private string name;
		public string Name
		{
			get => name;
			set => SetProperty(ref name, value);
		}

		public ICommand LogInCommand { get; private set; }

		public AuthViewModel()
		{
			LogInCommand = new DelegateCommand(() => OnLogInCommand());
		}

		private async Task OnLogInCommand()
		{
			try
			{
				if (string.IsNullOrEmpty(Name)) throw new Exception("Име пустое.");

				var tmp = await Service.SayHelloAsync(Name);

				ProxyDialog.ShowInfo(tmp);

				RegionManager.RequestNavigate(RegionNames.LeftRegion, ViewNames.Correspondences);
			}
			catch (Exception e)
			{
				ProxyDialog.ShowInfo(e.Message);
			}
		}
	}
}
