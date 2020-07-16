using Prism.Commands;
using SeP.Client.Infrastructure.Base.ViewModels;
using SeP.Client.Infrastructure.Constants;
using SeP.Client.Infrastructure.Enums;
using SeP.Client.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Input;

namespace SeP.Client.Authority.ViewModels
{
	public class AuthorityViewModel : BaseViewModel
	{
		private readonly IMessengerCollectionService messengerService;

		private List<KeyValuePair<MessengerTypes, string>> messengersTypes;
		public List<KeyValuePair<MessengerTypes, string>> MessengersTypes
		{
			get
			{
				if (messengersTypes == null)
					messengersTypes = messengerService
						.Messengers
						.Select(x => KeyValuePair.Create(x.MessengerType, Path.GetFullPath($".\\Images\\{x.MessengerType}.png")))
						.ToList();

				return messengersTypes;
			}
		}

		public ICommand SelectMessengerTypeCommand { get; private set; }
		public ICommand CloseCommand { get; private set; }

		public AuthorityViewModel(IMessengerCollectionService messengerService)
		{
			this.messengerService = messengerService;

			CloseCommand = new DelegateCommand(OnCloseCommand);
			SelectMessengerTypeCommand = new DelegateCommand<MessengerTypes?>((mes) => OnSelectMessengerTypeCommandAsync(mes));
		}

		private void OnSelectMessengerTypeCommandAsync(MessengerTypes? mes)
		{
			if (!mes.HasValue) return;

			messengerService.ShowAuthority(mes.Value);
		}

		private void OnCloseCommand()
		{
			RegionManager
				.Regions
				.FirstOrDefault(x => x.Name.Contains(RegionNames.AuthorityRegion))
				?.RemoveAll();
			RegionManager
				.Regions
				.FirstOrDefault(x => x.Name.Contains(RegionNames.GlobalRegion))
				?.RemoveAll();

		}
	}
}
