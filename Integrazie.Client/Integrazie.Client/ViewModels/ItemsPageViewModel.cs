using Integrazie.Client.Models;
using Integrazie.Client.Views;
using Prism.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Integrazie.Client.ViewModels
{
	public class ItemsPageViewModel : BaseViewModel
	{
		private Item _selectedItem;

		private ObservableCollection<Item> items;
		public ObservableCollection<Item> Items
		{
			get => items ?? (items = new ObservableCollection<Item>());
			set => SetProperty(ref items, value);
		}
		public Command LoadItemsCommand { get; }
		public Command AddItemCommand { get; }
		public Command<Item> ItemTapped { get; }

		public ItemsPageViewModel()
		{
			Title = "Browse";
			Items = new ObservableCollection<Item>();
			LoadItemsCommand = new Command(() => _ = ExecuteLoadItemsCommand());

			ItemTapped = new Command<Item>(OnItemSelected);

			AddItemCommand = new Command(OnAddItem);
		}

		async Task ExecuteLoadItemsCommand()
		{
			IsBusy = true;

			try
			{
				Items.Clear();
				Items = new ObservableCollection<Item>(await DataStore.GetItemsAsync(true));
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
			finally
			{
				IsBusy = false;
			}
		}

		public void OnAppearing()
		{
			IsBusy = true;
			SelectedItem = null;
		}

		public Item SelectedItem
		{
			get => _selectedItem;
			set
			{
				SetProperty(ref _selectedItem, value);
				OnItemSelected(value);
			}
		}

		private async void OnAddItem(object obj)
		{
			await navigation.NavigateAsync(nameof(NewItemPage));
		}

		async void OnItemSelected(Item item)
		{
			if (item == null)
			{
				return;
			}

			var navpars = new NavigationParameters
			{
				{ "ItemId", item.Id }
			};
			await navigation.NavigateAsync(nameof(ItemDetailPage), navpars);
		}
	}
}