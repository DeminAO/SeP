using Prism.Ioc;
using Prism.Modularity;
using SeP.Client.Infrastructure.Constants;

namespace SeP.Client.Correspondences
{
	public class CorrespondencesModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{
		}

		public void RegisterTypes(IContainerRegistry container)
		{
			container.RegisterForNavigation<Views.Correspondences>(ViewNames.Correspondences);
		}
	}
}
