using CrossMessenger.Client.Infrastructure.Interfaces.Services;
using Xamarin.Essentials;

namespace CrossMessenger.Client
{
	public class SettingsStore : ISettingsStore
	{
		public bool GetIsAnabledModule(string moduleName)
		{
			return Preferences.Get(moduleName, true);
		}

		public void Set(string moduleName, bool val)
		{
			Preferences.Set(moduleName, val);
		}
	}
}
