using Integrazie.Client.ViewModels;
using Integrazie.Client.Views;
using Prism;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Navigation;
using SeP.Client.Cross.Modules.Telegram;
using Xamarin.Forms;

namespace Integrazie.Client
{
	public partial class App : Prism.Unity.PrismApplication
	{
		#region Prism  

		public App(IPlatformInitializer platformInitializer = null) : base(platformInitializer) { }

		protected override void OnInitialized()
		{
			InitializeComponent();
			
			DependencyService.RegisterSingleton(this.NavigationService);

			NavigationService.NavigateAsync(nameof(AboutPage));
		}

		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			DependencyService.Register<ITgRepository, TgRepository>();

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
