using System.Windows;
using Prism.Ioc;
using Prism.Modularity;
using SeP.Client.Infrastructure.Interfaces;
using SeP.Client.Infrastructure.Services;

namespace SeP.Client.Shell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
	{
        protected override void RegisterTypes(IContainerRegistry container)
        {
            container.RegisterSingleton<IProxyDialog, ProxyDialog>();
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<Views.Shell>();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog() { ModulePath = @".\Modules" };
        }
    }
}
