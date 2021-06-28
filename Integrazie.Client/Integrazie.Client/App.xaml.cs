using CrossMessenger.Client.Infrastructure.Interfaces.Services;
using CrossMessenger.Client.Modules.Telegram;
using Prism;
using Prism.Ioc;
using Prism.Modularity;
using Xamarin.Essentials;
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

	public class ModuleInitializer : IModuleInitializer
	{
		private ISettingsStore settingsStore;
		private IContainerProvider serviceLocator;

		public ModuleInitializer(ISettingsStore settingsStore, IContainerProvider serviceLocator)
		{
			this.settingsStore = settingsStore;
			this.serviceLocator = serviceLocator;
		}

		public void Initialize(IModuleInfo moduleInfo)
		{
			if (!settingsStore.GetIsAnabledModule(moduleInfo.ModuleName))
			{
				return;
			}

			if (serviceLocator.IsRegistered<IModule>(moduleInfo.ModuleType))
			{
				var module = this.serviceLocator.Resolve<IModule>(moduleInfo.ModuleType);
				module.OnInitialized(DependencyService.Get<IContainerProvider>());
			}
		}
	}

	public class SettingsStore : ISettingsStore
	{
		public bool GetIsAnabledModule(string moduleName)
		{
			return Preferences.Get(moduleName, true);
		}

		public void Set(string moduleName, bool val)
		{
			Preferences.Set(moduleName, val);
		}
	}
}
