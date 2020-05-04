using CommonServiceLocator;
using Prism.Mvvm;
using Prism.Regions;
using SeP.Client.Infrastructure.Constants;
using SeP.Client.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeP.Client.Infrastructure.Base.ViewModels
{
	public class BaseViewModel : BindableBase, INavigationAware
	{
		public PropertyBase<string> ViewName { get; } = new PropertyBase<string>() { HasErrorFunc = (p) => false };

		public IRegionManager RegionManager { get; private set; }
		public IProxyDialog ProxyDialog { get; private set; }

		public BaseViewModel()
		{
			RegionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
			ProxyDialog = ServiceLocator.Current.GetInstance<IProxyDialog>();
		}

		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return false;
		}

		public void OnNavigatedFrom(NavigationContext navigationContext) { }

		public void OnNavigatedTo(NavigationContext navigationContext) { }

	}
}
