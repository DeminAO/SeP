using Prism.Ioc;
using Prism.Modularity;
using SeP.Client.Infrastructure.Constants;

namespace SeP.Client.SignUp
{
	public class SignUpModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{
			// throw new NotImplementedException();
		}

		public void RegisterTypes(IContainerRegistry container)
		{
			container.RegisterForNavigation<Views.SignUp>(ViewNames.SignUp);
		}
	}
}
