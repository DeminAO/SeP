using CrossMessenger.Client.Models;
using CrossMessenger.Client.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CrossMessenger.Client.ViewModels
{
	public class NewItemPageViewModel : BaseViewModel
	{
		private string text;
		private string description;

		public NewItemPageViewModel()
		{
			Title = "New Item";
			SaveCommand = new Command(() => _ = OnSave(), ValidateSave);
			CancelCommand = new Command(() => _ = OnCancel());
			this.PropertyChanged +=
				(_, __) => SaveCommand.ChangeCanExecute();
		}

		private bool ValidateSave()
		{
			return !String.IsNullOrWhiteSpace(text)
				&& !String.IsNullOrWhiteSpace(description);
		}

		public string Text
		{
			get => text;
			set => SetProperty(ref text, value);
		}

		public string Description
		{
			get => description;
			set => SetProperty(ref description, value);
		}

		public Command SaveCommand { get; }
		public Command CancelCommand { get; }

		private Task OnCancel()
		{
			// This will pop the current page off the navigation stack
			return navigation.GoBackAsync();
			//return navigation.NavigateAsync(nameof(ItemsPage))
			//	.ContinueWith(t => _ =  Application.Current.MainPage.Navigation.PopAsync());
		}

		private async Task OnSave()
		{
			Item newItem = new Item()
			{
				Id = Guid.NewGuid(),
				Text = Text,
				Description = Description
			};

			await DataStore.AddItemAsync(newItem);

			// This will pop the current page off the navigation stack
			await OnCancel();
		}
	}
}
