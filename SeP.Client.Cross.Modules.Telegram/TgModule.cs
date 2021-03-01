using Prism.Ioc;
using Prism.Modularity;
using System;

namespace SeP.Client.Cross.Modules.Telegram
{
	public interface ITgRepository
	{

	}
	public class TgRepository : ITgRepository
	{
	}

	public class TgModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{
			
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.Register<ITgRepository, TgRepository>();
		}
	}
}
