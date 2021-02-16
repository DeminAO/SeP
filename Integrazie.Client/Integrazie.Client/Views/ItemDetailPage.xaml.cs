using Integrazie.Client.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Integrazie.Client.Views
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