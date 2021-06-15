using Prism.Ioc;
using Prism.Modularity;
using CrossMessenger.Client.Modules.Telegram.Models;

namespace CrossMessenger.Client.Modules.Telegram
{
	public class TgModule : IModule
	{
		public async void OnInitialized(IContainerProvider containerProvider)
		{
			var rep = new TgRepository();
			var rse = await rep.LogInAsync(new TgPhoneLoginRequest() { Phone = "+79526035426" });

			var code = "";

			var res2 = await rep.LogInAsync(new TgCodeLoginRequest { Code = code });

			var res3 = await rep.GetDialogsAsync();

			var tmp = 0;
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.Register<ITgRepository, TgRepository>();
		}
	}
}
