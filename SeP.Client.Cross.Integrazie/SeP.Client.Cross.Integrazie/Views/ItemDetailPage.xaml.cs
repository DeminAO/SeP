using SeP.Client.Cross.Integrazie.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace SeP.Client.Cross.Integrazie.Views
{
	public partial class ItemDetailPage : ContentPage
	{
		public ItemDetailPage()
		{
			InitializeComponent();
			BindingContext = new ItemDetailViewModel();
		}
	}
}