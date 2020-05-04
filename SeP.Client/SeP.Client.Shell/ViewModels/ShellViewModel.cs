using Prism.Commands;
using SeP.Client.Infrastructure.Base.ViewModels;
using SeP.Client.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SeP.Client.Shell.ViewModels
{
	public class ShellViewModel : BaseViewModel
	{
		private string test = "testing string";
		public string Test
		{
			get => test;
			set => SetProperty(ref test, value);
		}

		public ICommand LoadedCommand { get; private set; }

		public ShellViewModel()
		{
			ViewName.Property = ViewNames.Shell;

			LoadedCommand = new DelegateCommand(OnLoadedCommand);
		}

		private void OnLoadedCommand()
		{
			RegionManager.RequestNavigate(RegionNames.MainRegion, ViewNames.Auth);
		}
	}
}
