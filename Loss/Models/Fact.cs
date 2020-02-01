using Loss.Helpers;
using System.Collections.ObjectModel;

namespace Loss.Models
{
	public class Fact : BindableBase
	{
		private Models.Predicate parent;
		private ObservableCollection<string> arguments;

		public Models.Predicate Parent
		{
			get => parent;
			set => SetProperty(ref parent, value);
		}

		public ObservableCollection<string> Arguments
		{
			get
			{
				if (arguments == null)
					arguments = new ObservableCollection<string>();

				return arguments;
			}
			set
			{
				SetProperty(ref arguments, value);
				SetProperty(nameof(StringArguments));
			}
		}

		private string stringArguments;
		public string StringArguments
		{
			get => string.Join(", ", Arguments);
			set
			{
				SetProperty(ref stringArguments, value);
				var args = stringArguments.Split(new string[] { ", ", "," }, System.StringSplitOptions.RemoveEmptyEntries);
				Arguments = new ObservableCollection<string>(args);
			}
		}
	}
}
