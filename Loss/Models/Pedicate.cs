using Loss.Helpers;

namespace Loss.Models
{
	public class Predicate : BindableBase
	{
		private string name;
		private int? argumentsCount;

		public string Name
		{
			get => name;
			set => SetProperty(ref name, value);
		}

		public int? ArgumentsCount
		{
			get => argumentsCount;
			set => SetProperty(ref argumentsCount, value);
		}
	}
}
