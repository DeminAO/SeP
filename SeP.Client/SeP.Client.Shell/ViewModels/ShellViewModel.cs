using Prism.Commands;
using SeP.Client.Infrastructure.Base.ViewModels;
using SeP.Client.Infrastructure.Constants;
using System.Windows.Input;

namespace SeP.Client.Shell.ViewModels
{
	public class ShellViewModel : BaseViewModel
	{
		public ICommand LoadedCommand { get; private set; }

		public ShellViewModel()
		{
			ViewName.Property = ViewNames.Shell;

			LoadedCommand = new DelegateCommand(OnLoadedCommand);
		}

		private void OnLoadedCommand()
		{
			Init();
		}

		private void Init()
		{
			RegionManager.RequestNavigate(RegionNames.LeftRegion, ViewNames.Correspondences);
			// RegionManager.RequestNavigate(RegionNames.GlobalRegion, ViewNames.Authority);
		}
	}
}
