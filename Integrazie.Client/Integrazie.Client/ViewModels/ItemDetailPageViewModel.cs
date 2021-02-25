using Integrazie.Client.Models;
using Prism.Navigation;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Integrazie.Client.ViewModels
{
	[QueryProperty(nameof(ItemId), nameof(ItemId))]
	public class ItemDetailPageViewModel : BaseViewModel, INavigationAware
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
			get
			{
				return itemId;
			}
			set
			{
				itemId = value;
			}
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

		public void OnNavigatedFrom(INavigationParameters parameters)
		{
			//
		}

		public void OnNavigatedTo(INavigationParameters parameters)
		{
			if (parameters[nameof(ItemId)] is Guid id)
			{
				_ = LoadItemId(id);
			}
		}
	}
}
