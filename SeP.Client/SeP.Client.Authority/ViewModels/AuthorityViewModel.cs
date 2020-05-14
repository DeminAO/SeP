using Prism.Commands;
using SeP.Client.Infrastructure.Base.ViewModels;
using SeP.Client.Infrastructure.Enums;
using SeP.Client.Infrastructure.Interfaces;
using SeP.Client.Infrastructure.Services;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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

				messengersTypes.Add(KeyValuePair.Create(MessengerTypes.Empty, ""));
				
				return messengersTypes;
			}
		}

		public ICommand SelectMessengerTypeCommand { get; private set; }

		public AuthorityViewModel(IMessengerCollectionService messengerService)
		{
			this.messengerService = messengerService;

			SelectMessengerTypeCommand = new DelegateCommand<MessengerTypes?>((mes) => OnSelectMessengerTypeCommandAsync(mes));
		}

		private void OnSelectMessengerTypeCommandAsync(MessengerTypes? mes) //=> Task.Run(() =>
		{
			var tmp = mes;
			if (mes == null) return;

			ProxyDialog.ShowInfo(tmp.ToString());
		}//);
	}
}
