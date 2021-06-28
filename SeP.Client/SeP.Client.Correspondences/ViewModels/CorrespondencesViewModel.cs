using Models;
using Prism.Commands;
using Prism.Logging;
using SeP.Client.Infrastructure.Base.ViewModels;
using SeP.Client.Infrastructure.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SeP.Client.Correspondences.ViewModels
{
	public class CorrespondencesViewModel : BaseViewModel
	{
		ILoggerFacade logger;
		private readonly IMessengerCollectionService _mcs;

		private ObservableCollection<DialogData> dialogs;
		public ObservableCollection<DialogData> Dialogs
		{
			get => dialogs;
			set => SetProperty(ref dialogs, value);
		}

		private bool progress;
		public bool Progress
		{
			get => progress;
			set => SetProperty(ref progress, value);
		}

		private string error;
		public string Error
		{
			get => error;
			set => SetProperty(ref error, value);
		}

		public ICommand LoadedCommand { get; private set; }

		public CorrespondencesViewModel(IMessengerCollectionService messengerCollectionService)
		{
			_mcs = messengerCollectionService;
			dialogs = new ObservableCollection<DialogData>();
			LoadedCommand = new DelegateCommand(() => _ = OnInitialisedAsync());
		}

		private async Task OnInitialisedAsync()
		{
			Progress = true;

			foreach(var m in _mcs.Messengers)
			{
				try
				{
					var itemsTask = m.GetDialogs();
					Dialogs.AddRange(await itemsTask);
				}
				catch (Exception e)
				{
					logger.Log(e.Message, Category.Exception, Priority.High);
					Error = $"Ошибка загрузки контактов, {m.MessengerType}";
				}
			}

			Progress = false;
		}
	}
}
