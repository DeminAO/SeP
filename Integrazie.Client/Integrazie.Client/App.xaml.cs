using CrossMessenger.Client.Infrastructure.Interfaces.Services;
//using CrossMessaging.Client.CryptoService;
using Prism;
using Prism.Ioc;
using Prism.Modularity;
using Xamarin.Forms;

namespace CrossMessenger.Client
{
	public partial class App : Prism.Unity.PrismApplication
	{
		public App(IPlatformInitializer platformInitializer = null)
			: base(platformInitializer) { }

		protected override void OnInitialized()
		{
			InitializeComponent();
			MainPage = new AppShell();

			DependencyService.RegisterSingleton(this.NavigationService);
		}

		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.Register<ISettingsStore, SettingsStore>();
			// containerRegistry.Register<ICryptoService, CryptoService>();
			containerRegistry.Register<IModuleInitializer, ModuleInitializer>();
			containerRegistry.RegisterForNavigation<Settings.Views.SettingsPage, Settings.ViewModels.SettingsPageViewModel>();
			containerRegistry.RegisterForNavigation<Messeging.Views.DialogsViewPage, Messeging.ViewModels.DialogsViewPageViewModel>();
		}
	}
}
