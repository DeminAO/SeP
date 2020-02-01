using Loss.Helpers;
using System.Collections.ObjectModel;

namespace Loss.Models
{

	public class Statement : BindableBase
	{
		private ObservableCollection<Models.Fact> predicates;
		private Models.Fact result;

		/// <summary>
		/// Предикаты высказыванич должны в конструкторе принимать мнимые аргументы.
		/// Так как предикат принимает количество аргументов - используем факт
		/// </summary>
		public ObservableCollection<Models.Fact> Predicates
		{
			get
			{
				if (predicates == null)
					Predicates = new ObservableCollection<Fact>();

				return predicates;
			}
			set => SetProperty(ref predicates, value);
		}

		/// <summary>
		/// Предикат - факт с мнимыми аргументами
		/// </summary>
		public Models.Fact Result
		{
			get
			{
				if (result == null)
					result = new Models.Fact();
				return result;
			}
			set => SetProperty(ref result, value);
		}
	}
}
