using Integrazie.Client.Models;
using Integrazie.Client.Services;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace Integrazie.Client.ViewModels
{
	public class BaseViewModel : BindableBase
	{
		protected readonly IDataStore<Item> DataStore;
		protected readonly INavigationService navigation;

		bool isBusy = false;
		public bool IsBusy
		{
			get { return isBusy; }
			set { SetProperty(ref isBusy, value); }
		}

		string title = string.Empty;
		public string Title
		{
			get { return title; }
			set { SetProperty(ref title, value); }
		}

		public BaseViewModel()
		{
			this.navigation = DependencyService.Get<INavigationService>();
			this.DataStore = DependencyService.Get<IDataStore<Item>>();
		}
	}
}
