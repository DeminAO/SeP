using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Loss.Helpers
{
	public class BindableBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public void SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
		{
			field = value;
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		
		public void SetProperty([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

	}
}
