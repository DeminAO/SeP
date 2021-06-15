using CrossMessenger.Client.Infrastructure.Interfaces;

namespace CrossMessenger.Client.Modules.Telegram.Models
{
	public class TgIdentifier : IIdentifier
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
