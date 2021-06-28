
using Prism.Ioc;
using Prism.Modularity;
using SeP.Client.Infrastructure.Constants;

namespace SeP.Client.Authority
{
	[Module(ModuleName = ModuleNames.AuthorityModule)]
	public class AuthorityModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{

		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterForNavigation<Views.Authority>(ViewNames.Authority);
		}
	}
}
