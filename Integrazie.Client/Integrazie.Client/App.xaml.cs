using CrossMessenger.Client.Modules.Telegram;
using Prism;
using Prism.Ioc;
using Prism.Modularity;
using Xamarin.Forms;

namespace CrossMessenger.Client
{
	public partial class App : Prism.Unity.PrismApplication
	{
		#region Prism  

		public App(IPlatformInitializer platformInitializer = null)
			: base(platformInitializer) { }

		protected override void OnInitialized()
		{
			InitializeComponent();
			MainPage = new AppShell();

			DependencyService.RegisterSingleton(this.NavigationService);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="containerRegistry"></param>
		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.Register<IModuleInitializer, ModuleInitializer>();
			containerRegistry.RegisterForNavigation<Settings.Views.SettingsPage, Settings.ViewModels.SettingsPageViewModel>();
			containerRegistry.RegisterForNavigation<Messeging.Views.DialogsViewPage, Messeging.ViewModels.DialogsViewPageViewModel>();
		}

		protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
		{
			moduleCatalog.AddModule<TgModule>();
			// base.ConfigureModuleCatalog(moduleCatalog);
		}

		#endregion Prism
	}
}
