using CrossMessenger.Client.Infrastructure.Enums;
using CrossMessenger.Client.Settings.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace CrossMessenger.Client.Settings.ViewModels
{
	public class SettingsPageViewModel: BindableBase
	{
		public bool Changed => SettingsCollection.Any(x => !x.IsChecked);

		private ObservableCollection<SettingModel> settingsCollection;
		public ObservableCollection<SettingModel> SettingsCollection
		{
			get => settingsCollection ?? (settingsCollection = new ObservableCollection<SettingModel>());
			set => SetProperty(ref settingsCollection, value);
		}

		public ICommand InitCommand { get; private set; }

		public SettingsPageViewModel()
		{
			InitCommand = new DelegateCommand(OnInit);
		}

		private void OnInit()
		{
			var list = Enum
				.GetValues(typeof(MessengersTypes))
				.Cast<MessengersTypes>()
				.Select(x => new SettingModel
				{
					Name = x.ToString(),
					IsAuthorized = false,
					IsChecked = true
				})
				.ToList();

			list.ForEach(x => x.PropertyChanged += (s, e) => RaisePropertyChanged(nameof(Changed)));

			SettingsCollection = new ObservableCollection<SettingModel>(list);
		}
	}
}
