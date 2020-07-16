using System;
using System.Windows;
using System.Windows.Controls;

namespace SeP.Client.Messengers.VK.Authority.Helpers.Attached
{
	public class WebBrowserAttached
	{
		public static readonly DependencyProperty SourceUrlProperty =
		DependencyProperty.RegisterAttached("SourceUrl", typeof(Uri), typeof(WebBrowserAttached), new UIPropertyMetadata(null, SourceUrlPropertyChanged));

		public static Uri GetSourceUrl(WebBrowser browser)
		{
			return (Uri)browser.GetValue(SourceUrlProperty);
		}

		public static void SetSourceUrl(WebBrowser browser, Uri value)
		{
			browser.SetValue(SourceUrlProperty, value);
		}

		public static void SourceUrlPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
		{
			if(
				!(obj is WebBrowser browser) 
				|| 
				!(e.NewValue is Uri uri) 
				|| 
				browser.Source == uri
			   ) return;

			browser.Navigated -= Browser_Navigated;
			browser.Navigated += Browser_Navigated;
			
			browser.Source = uri;
		}

		private static void Browser_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
		{
			if (!(sender is WebBrowser browser)) return;
			browser.SetValue(SourceUrlProperty, browser.Source);
		}
	}
}
