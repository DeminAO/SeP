using SeP.Client.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace SeP.Client.Infrastructure.Services
{
	public class ProxyDialog : IProxyDialog
	{
		public void ShowInfo(string message)
		{
			MessageBox.Show(message, "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
		}
	}
}
