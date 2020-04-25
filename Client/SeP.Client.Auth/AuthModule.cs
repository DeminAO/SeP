using Prism.Ioc;
using Prism.Modularity;
using SeP.Client.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeP.Client.Auth
{
	public class AuthModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{
			// throw new NotImplementedException();
		}

		public void RegisterTypes(IContainerRegistry container)
		{
			// container.Register<object, Auth.Views.Auth>(ViewNames.Auth);
			container.RegisterForNavigation<Views.Auth>(ViewNames.Auth);

			//var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
			//regionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(Views.Auth));
		}
	}
}
