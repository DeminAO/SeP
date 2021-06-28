namespace CrossMessenger.Client.Infrastructure.Interfaces.Services
{
	public interface ISettingsStore
	{
		bool GetIsAnabledModule(string mouleName);
		void Set(string moduleName, bool val);
	}

}
