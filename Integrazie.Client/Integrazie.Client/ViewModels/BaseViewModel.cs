using CrossMessenger.Client.Models;
using CrossMessenger.Client.Services;
using Prism.Mvvm;
using Prism.Navigation;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CrossMessenger.Client.ViewModels
{
	public class BaseViewModel : BindableBase, INavigationAware
	{
		protected readonly IDataStore<Item> DataStore;
		protected readonly INavigationService navigation;

		bool isBusy = false;
		public bool IsBusy
		{
			get => isBusy;
			set => SetProperty(ref isBusy, value);
		}

		string title = string.Empty;
		public string Title
		{
			get => title;
			set => SetProperty(ref title, value);
		}
		
		string backTitle = "<";
		public string BackTitle
		{
			get => backTitle;
			set => SetProperty(ref backTitle, "<" + value);
		}
		
		string backViewName;
		public string BackViewName
		{
			get => backViewName;
			set => SetProperty(ref backViewName, value);
		}

		private readonly string currentViewName;

		public BaseViewModel()
		{
			this.navigation = DependencyService.Get<INavigationService>();
			this.DataStore = DependencyService.Get<IDataStore<Item>>();

			currentViewName = this.GetType().Name.Replace("ViewModel", string.Empty);
		}

		/// <summary>
		/// При переопределении в дочернем классе,
		/// позволяет добавить в параметры навигации (с этой вьюмодели) дополнительные данные
		/// </summary>
		/// <param name="parameters"></param>
		public virtual void OnNavigatedFrom(INavigationParameters parameters)
		{
			parameters.Add("BackTitle", Title);
			parameters.Add("BackViewName", currentViewName);
		}

		public async Task GoBackAsync()
		{
			if (!string.IsNullOrEmpty(BackViewName))
			{
				await navigation.NavigateAsync(BackViewName);
			}
			await navigation.GoBackAsync();
		}

		/// <summary>
		/// use <see cref="OnNavigatedToAsync(INavigationParameters)"/>
		/// </summary>
		/// <param name="parameters"></param>
		public void OnNavigatedTo(INavigationParameters parameters)
		{
			if (parameters[nameof(BackTitle)] is string backTitle)
			{
				BackTitle = backTitle;
			}
			if (parameters[nameof(BackViewName)] is string backView)
			{
				BackViewName = backView;
			}

			_ = OnNavigatedToAsync(parameters);
		}

		/// <summary>
		/// При переопределении в дочернем классе, позволяет обработать параметры навигации
		/// </summary>
		public virtual Task OnNavigatedToAsync(INavigationParameters parameters) => Task.CompletedTask;
	}
}