using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossMessenger.Client.Settings.Models
{
	public class SettingModel : BindableBase
	{
		public bool IsAuthorized { get; set; }

		private string name;
		public string Name
		{
			get => name;
			set => SetProperty(ref name, value);
		}

		private bool isChecked;
		public bool IsChecked
		{
			get => isChecked;
			set => SetProperty(ref isChecked, value);
		}

	}
}
