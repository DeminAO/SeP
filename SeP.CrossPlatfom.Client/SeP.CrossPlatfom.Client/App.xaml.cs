using Prism;
using Prism.Ioc;
using SeP.CrossPlatfom.Client.ViewModels;
using SeP.CrossPlatfom.Client.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace SeP.CrossPlatfom.Client
{
	public partial class App
	{
		public App(IPlatformInitializer initializer)
			: base(initializer)
		{
		}

		protected override async void OnInitialized()
		{
			InitializeComponent();

			await NavigationService.NavigateAsync("NavigationPage/MainPage");
		}

		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

			containerRegistry.RegisterForNavigation<NavigationPage>();
			containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
		}
	}
}
