using SeP.Client.Cross.Integrazie.Services;
using SeP.Client.Cross.Integrazie.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeP.Client.Cross.Integrazie
{
	public partial class App : Application
	{

		public App()
		{
			InitializeComponent();

			DependencyService.Register<MockDataStore>();
			MainPage = new AppShell();
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
