using CommonServiceLocator;
using Prism.Mvvm;
using Prism.Regions;
using SeP.Client.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeP.Client.Infrastructure.Base.ViewModels
{
	public class BaseViewModel : BindableBase, INavigationAware
	{
		public IRegionManager RegionManager;
		public IProxyDialog ProxyDialog;

		public BaseViewModel()
		{
			RegionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
			ProxyDialog = ServiceLocator.Current.GetInstance<IProxyDialog>();
		}

		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		public void OnNavigatedFrom(NavigationContext navigationContext) { }

		public void OnNavigatedTo(NavigationContext navigationContext) { }
	}
}
