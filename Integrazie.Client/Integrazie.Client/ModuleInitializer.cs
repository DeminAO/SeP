using CrossMessenger.Client.Infrastructure.Interfaces.Services;
using Prism.Ioc;
using Prism.Modularity;
using Xamarin.Forms;

namespace CrossMessenger.Client
{
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
}
