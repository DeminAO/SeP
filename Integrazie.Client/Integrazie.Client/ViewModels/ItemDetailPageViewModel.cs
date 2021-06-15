using CrossMessenger.Client.Models;
using Prism.Navigation;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CrossMessenger.Client.ViewModels
{
	public class ItemDetailPageViewModel : BaseViewModel
	{
		private Guid itemId;
		private string text;
		private string description;
		public Guid Id { get; set; }

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

		public Guid ItemId
		{
			get => itemId;
			set => SetProperty(ref itemId, value);
		}

		public Command BackCommand { get; }

		public ItemDetailPageViewModel()
		{

			BackCommand = new Command(() => _ = GoBackAsync());
		}

		public async Task LoadItemId(Guid itemId)
		{
			try
			{
				var item = await DataStore.GetItemAsync(itemId);
				Id = item.Id;
				Text = item.Text;
				Description = item.Description;
			}
			catch (Exception)
			{
				Debug.WriteLine("Failed to Load Item");
			}
		}

		public override async Task OnNavigatedToAsync(INavigationParameters parameters)
		{
			if (parameters[nameof(ItemId)] is Guid id)
			{
				await LoadItemId(id);
			}
		}
	}
}
