using CrossMessenger.Client.Models;
using CrossMessenger.Client.Modules.Telegram;
using CrossMessenger.Client.Services;
using CrossMessenger.Client.ViewModels;
using CrossMessenger.Client.Views;
using Prism;
using Prism.Ioc;
using Prism.Modularity;
using Xamarin.Forms;

namespace CrossMessenger.Client
{
	public partial class App : Prism.Unity.PrismApplication
	{
		#region Prism  

		public App(IPlatformInitializer platformInitializer = null) : base(platformInitializer) { }

		protected override void OnInitialized()
		{
			InitializeComponent();
			MainPage = new AppShell();

			DependencyService.RegisterSingleton(this.NavigationService);

			NavigationService.NavigateAsync(nameof(AboutPage));
		}

		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			// DependencyService.Register<ITgRepository, TgRepository>();
			DependencyService.Register<IDataStore<Item>, MockDataStore>();

			containerRegistry.RegisterForNavigation<AboutPage, AboutPageViewModel>();
			containerRegistry.RegisterForNavigation<ItemDetailPage, ItemDetailPageViewModel>();
			containerRegistry.RegisterForNavigation<NewItemPage, NewItemPageViewModel>();

		}

		protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
		{
			moduleCatalog.AddModule<TgModule>();
			// base.ConfigureModuleCatalog(moduleCatalog);
		}

		#endregion Prism

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
